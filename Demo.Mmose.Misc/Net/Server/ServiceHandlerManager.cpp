#include "StdAfx.h"
#include "ServerInc.h"
#include "ServiceHandlerManager.h"

#include <time.h>

namespace Demo
{
	namespace Mmose
	{
		namespace Net
		{

			ServiceHandleManager::ServiceHandleManager(SocketServer^ value) : m_pSocketServer(value)
				, m_iTotalClients(0)
			{
			}

			ServiceHandle^ ServiceHandleManager::default::get(System::String^ strHostNamePort)
			{
				if (System::String::IsNullOrEmpty(strHostNamePort) == true)
			        throw gcnew System::Exception("ServiceHandleManager::Item::get(...) - strHostNamePort == IsNullOrEmpty error!\n");

				ServiceHandler^ pServiceHandler = nullptr;

				m_LockBusy.Enter();
				try
				{
					m_Busy.TryGetValue(strHostNamePort, pServiceHandler);
				}
				finally
				{
					m_LockBusy.Exit();
				}

				return pServiceHandler;
			}

			void ServiceHandleManager::SendToAll(MessageBlock^ sendMessageBlock)
			{
				if (sendMessageBlock == nullptr)
			        throw gcnew System::Exception("ServiceHandleManager::SendToAll(...) - sendMessageBlock == nullptr error!\n");

				System::Collections::Generic::List<ServiceHandler^>^ serviceHandlerList = nullptr;

				m_LockBusy.Enter();
				try
			    {
			        if (m_Busy.Count > 0)
			        {
						serviceHandlerList = gcnew System::Collections::Generic::List<ServiceHandler^>(m_Busy.Count);

						for each ( System::Collections::Generic::KeyValuePair<System::String^, ServiceHandler^> keyValuePair in m_Busy)
							serviceHandlerList->Add(keyValuePair.Value);
			        }
			    }
				finally
				{
					m_LockBusy.Exit();
				}

				if (serviceHandlerList != nullptr)
				{
					for each ( ServiceHandler^ serviceHandler in serviceHandlerList)
					{
						MessageBlock^ messageBlock = this->GetNewSendMessageBlock();
						if( messageBlock == nullptr )
							throw gcnew System::Exception("SocketHandlerManager::SendToAll(...) - GetNewSendMessageBlock(...) == false error!\n");

						::memcpy(messageBlock->WritePointer().ToPointer(), sendMessageBlock->ReadPointer().ToPointer(), (int)sendMessageBlock->Length);
						messageBlock->WritePointer (sendMessageBlock->Length);

						serviceHandler->SendTo(messageBlock);
					}
				}

				Server::MessageBlockManager->ReleaseMessageBlock(sendMessageBlock);
			}
			
			void ServiceHandleManager::AddValidClientHandler(ServiceHandler^ pServiceHandler)
			{
				if (pServiceHandler == nullptr)
			        throw gcnew System::Exception("ServiceHandleManager::AddValidClientHandler(...) - pServiceHandler == NULL error!\n");

				ServiceHandler^ pLookupServiceHandler = nullptr;

				do
				{
					// 因为 CloseSocket(...)会调用DelInvalidClientHandler()所以不能在m_LockBusy锁内调用
					if (pLookupServiceHandler != nullptr)
					{
						pLookupServiceHandler->CloseSocket();	// 关闭Socket
						pLookupServiceHandler = nullptr;
					}

					m_LockBusy.Enter();
					try
					{
						// 检查该连接是否已经存在
						if (m_Busy.TryGetValue(pServiceHandler->ClientAddress, pLookupServiceHandler) == true)
							m_Busy.Remove(pServiceHandler->ClientAddress); // 删除已经有连接的Socket

						if (pLookupServiceHandler == nullptr)
							m_Busy.Add(pServiceHandler->ClientAddress, pServiceHandler);
					}
					finally
					{
						m_LockBusy.Exit();
					}

				} while (pLookupServiceHandler != nullptr);

				System::Threading::Interlocked::Increment(m_iTotalClients); // 新连接(总连接计数)
			}
			
			void ServiceHandleManager::DelInvalidClientHandler(ServiceHandler^ pServiceHandler)
			{
				if (pServiceHandler == nullptr)
			        throw gcnew System::Exception("ServiceHandleManager::DelInvalidClientHandler(...) - pServiceHandler == NULL error!\n");

				m_LockBusy.Enter();
				try
			    {
			        if (m_Busy.Count > 0)
						m_Busy.Remove(pServiceHandler->ClientAddress);
			    }
				finally
				{
					m_LockBusy.Exit();
				}
			}
			
			void ServiceHandleManager::CheckAllOnlineState()
			{
				System::DateTime nowTime	= System::DateTime::Now;
			    System::Collections::Generic::List<ServiceHandler^>^ pTimeOutServiceHandler = nullptr;

				m_LockBusy.Enter();
				try
			    {
					if (m_Busy.Count > 0)
					{
						pTimeOutServiceHandler = gcnew System::Collections::Generic::List<ServiceHandler^>(m_Busy.Count);

						for each ( System::Collections::Generic::KeyValuePair<System::String^, ServiceHandler^> item in m_Busy)
						{
							// 检查是不是客户端超时了
							System::TimeSpan iTimeSpan = nowTime - item.Value->LastMessageBlockTime;

							if (iTimeSpan > System::TimeSpan::FromSeconds(Server::s_ServerOutTimeInterval))
								pTimeOutServiceHandler->Add(item.Value);
						}

						// 开始删除
						for each ( ServiceHandler^ item in pTimeOutServiceHandler)
							m_Busy.Remove(item->ClientAddress);
					}
			    }
				finally
				{
					m_LockBusy.Exit();
				}

				// 开始关闭Socket
				if (pTimeOutServiceHandler != nullptr)
				{
					for each ( ServiceHandler^ serviceHandler in pTimeOutServiceHandler)
						serviceHandler->CloseSocket();
				}
			}
			
			MessageBlock^ ServiceHandleManager::GetNewSendMessageBlock()
			{
				MessageBlock^ pMessageBlock	= Server::MessageBlockManager->AcquireMessageBlock();
				if (pMessageBlock == nullptr) 
					throw gcnew System::Exception("ServiceHandleManager::GetNewSendMessageBlock(...) - pMessageBlock == nullptr error!\n");

			    return pMessageBlock;
			}
			
			ServiceHandler^ ServiceHandleManager::AcquireServiceHandler()
			{
				// 初始化ServiceHandler
				ServiceHandler^ pServiceHandler = gcnew ServiceHandler(this->Owner);

				m_Lock.Enter();
				try
			    {
					m_StockHandlerManager.Add(pServiceHandler);
				}
				finally
				{
					m_Lock.Exit();
				}

			    return pServiceHandler;
			}

			void ServiceHandleManager::ReleaseServiceHandler(ServiceHandler^ pServiceHandler)
			{
			    if (pServiceHandler == nullptr)
			        throw gcnew System::Exception("SocketHandlerManager::ReleaseServiceHandler(...) - pServiceHandler == NULL error!\n");

				m_Lock.Enter();
				try
				{
					if (m_StockHandlerManager.Count > 0)
						m_StockHandlerManager.Remove(pServiceHandler);
				}
				finally
				{
					m_Lock.Exit();
				}
			}

			void ServiceHandleManager::CloseAllSocket()
			{
				System::Collections::Generic::List<ServiceHandler^>^ pCloseServiceHandlerList = nullptr;
			
				m_Lock.Enter();
				try
			    {
					m_LockBusy.Enter();
					try
					{
						m_Busy.Clear();
					}
					finally
					{
						m_LockBusy.Exit();
					}

			        if (m_StockHandlerManager.Count > 0)
			        {
						pCloseServiceHandlerList = gcnew System::Collections::Generic::List<ServiceHandler^>(m_StockHandlerManager.Count);

						for each ( ServiceHandler^ serviceHandler in m_StockHandlerManager)
							pCloseServiceHandlerList->Add(serviceHandler);

						m_StockHandlerManager.Clear();
			        }
				}
				finally
				{
					m_Lock.Exit();
				}

				// 开始关闭Socket
			    if (pCloseServiceHandlerList != nullptr)
			    {
					for each ( ServiceHandler^ serviceHandler in pCloseServiceHandlerList)
						serviceHandler->CloseSocket();
			    }
			}

		}
	}
}