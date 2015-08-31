#include "StdAfx.h"
#include "ClientInc.h"
#include "ConnectHandler.h"

namespace Demo
{
	namespace Mmose
	{
		namespace Net
		{

			ConnectHandle::ConnectHandle() : m_bIsOnline(false)
				, m_RemotePort(0)
				, m_FirstTime(0)
				, m_OnlineTime(0)
				, m_MessageBlockNumbers60sec(0)
				, m_LastMessageBlockTime(0)
				, m_MessageBlockNumbers(0)
				, m_MessageBlockSpacingTime(0)
				, m_AddUpMessageBlockSpacingTime(0)
				, m_RemoteIP(System::String::Empty)
				, m_RemoteAddress(System::String::Empty)
			{
			}


			//---------------------------------------------------------------------------


			ConnectHandler::ConnectHandler (SocketClient^ value) : m_pSocketClient(value)
				, m_LockCheck(true)
			{
				m_DelegateSendBufferStream = gcnew DelegateSendBufferStream(this, &Demo::Mmose::Net::ConnectHandler::OnSendBufferStream);
				m_DelegateProcessBufferStream = gcnew DelegateProcessBufferStream(this, &Demo::Mmose::Net::ConnectHandler::OnProcessBufferStream);
			}

			// ---------- IConnectHandler ----------

			void ConnectHandler::OnReadStream(MessageBlock^ readMessageBlock)
			{
				if (m_LockCheck.IsValid() == false)
				{
					Client::MessageBlockManager->ReleaseMessageBlock(readMessageBlock);
					return;
				}

				// 计算ServiceHandler的数据(1)
				CalcClientHandler();

				MessageBlockInfo^ pReadMessageBlockInfo     = MessageBlockInfo::GetMessageBlockInfo(readMessageBlock);
				if (pReadMessageBlockInfo == nullptr)
				{
					Client::MessageBlockManager->ReleaseMessageBlock(readMessageBlock);
					CloseSocket();

					throw gcnew System::Exception("ConnectHandler::OnReadStream(...) - pReadMessageBlockInfo == NULL error\n");
				}

				if (pReadMessageBlockInfo->m_OperatorType != TASK_WORKER_TYPE_RECEIVE)
				{
					Client::MessageBlockManager->ReleaseMessageBlock(readMessageBlock);
					CloseSocket();

					throw gcnew System::Exception("ConnectHandler::OnReadStream(...) - pReadMessageBlockInfo->m_OperatorType != TASK_WORKER_TYPE_RECEIVE error\n");
				}

				// 如果接受到的数据小于等于零 可能是Socket已关闭的IOCP信号
				if (pReadMessageBlockInfo->m_TransferredNumberOfBytes <= 0)
				{
					Client::MessageBlockManager->ReleaseMessageBlock(readMessageBlock);
					CloseSocket();

					return;
				}
				else
					readMessageBlock->WritePointer(pReadMessageBlockInfo->m_TransferredNumberOfBytes);


				//-------------------------------------------------------------------------------
				// 测试接收消息块
				//*(readMessageBlock.WritePointer()) = '\0';
				//AtlTrace("ConnectHandler = %p : Remote Receive DataBuffer = %s  Length = %d  TransferredNumberOfBytes = %d  ReadPointer() = %p  WritePointer() = %p\n",
				//	this, readMessageBlock.ReadPointer(), readMessageBlock.Length(), pReadMessageBlockInfo->m_TransferredNumberOfBytes, readMessageBlock.ReadPointer(), readMessageBlock.WritePointer());
				//--------------------------------------------------------------------------------

				// 发送给处理程序
				PostProcessStream(pReadMessageBlockInfo);

				MessageBlock^ pMessageBlock = Client::MessageBlockManager->AcquireMessageBlock();
				if (pMessageBlock == nullptr)
				{
					CloseSocket();

					throw gcnew System::Exception("ConnectHandler::OnReadStream(...) - pMessageBlock == NULL error\n");
				}

				// 初始化一个新的接受数据
				InitReceiveBufferStream(pMessageBlock);
			}

			void ConnectHandler::OnWriteStream(MessageBlock^ writeMessageBlock)
			{
				if (m_LockCheck.IsValid() == false)
				{
					Client::MessageBlockManager->ReleaseMessageBlock(writeMessageBlock);
					return;
				}

				MessageBlockInfo^ pWriteMessageBlockInfo = MessageBlockInfo::GetMessageBlockInfo(writeMessageBlock);
				if (pWriteMessageBlockInfo == nullptr)
				{
					Client::MessageBlockManager->ReleaseMessageBlock(writeMessageBlock);
					CloseSocket();

					throw gcnew System::Exception("ConnectHandler::OnWriteStream(...) - pWriteMessageBlockInfo == NULL error\n");
				}

				if (pWriteMessageBlockInfo->m_OperatorType != TASK_WORKER_TYPE_SEND)
				{
					Client::MessageBlockManager->ReleaseMessageBlock(writeMessageBlock);
					CloseSocket();

					throw gcnew System::Exception("ConnectHandler::OnWriteStream(...) - pReadMessageBlockInfo->m_OperatorType != TASK_WORKER_TYPE_RECEIVE error\n");
				}

				// 检测发送出去的数据是否过小于需发送的数据,则把剩余的数据发送完毕
				int iNumberOfBytes = pWriteMessageBlockInfo->m_SendNumberOfBytes - pWriteMessageBlockInfo->m_TransferredNumberOfBytes;
				if ( iNumberOfBytes > 0 )
				{
					MessageBlock^ pMessageBlock = Client::MessageBlockManager->AcquireMessageBlock();
					if (pMessageBlock != nullptr)
					{
						// 跳过已发送掉的数据
						pWriteMessageBlockInfo->MessageBlock->ReadPointer(pWriteMessageBlockInfo->m_TransferredNumberOfBytes);

						::memcpy(pMessageBlock->WritePointer().ToPointer(), pWriteMessageBlockInfo->MessageBlock->ReadPointer().ToPointer(), iNumberOfBytes );
						pMessageBlock->WritePointer(iNumberOfBytes);
						pWriteMessageBlockInfo->MessageBlock->ReadPointer(iNumberOfBytes);

						MessageBlockInfo^ pMessageBlockInfo = MessageBlockInfo::GetMessageBlockInfo(pMessageBlock);
						if (pMessageBlockInfo == nullptr)
						{
							Client::MessageBlockManager->ReleaseMessageBlock(pMessageBlock);
							Client::MessageBlockManager->ReleaseMessageBlock(writeMessageBlock);
							CloseSocket();

							throw gcnew System::Exception("ConnectHandler::OnWriteStream(...) - pMessageBlockInfo == NULL error\n");
						}

						PostSendStream(pMessageBlockInfo);
					}
					else
					{
						Client::MessageBlockManager->ReleaseMessageBlock(writeMessageBlock);
						CloseSocket();

						throw gcnew System::Exception("ConnectHandler::OnWriteStream(...) - pMessageBlock == NULL error\n");
					}

				}

				Client::MessageBlockManager->ReleaseMessageBlock(writeMessageBlock);
			}

			// ---------- IConnectHandler ----------



			// ---------- ITaskWorkerHandler ----------

			void ConnectHandler::OnSendBufferStream(MessageBlock^ /*sendMessageBlock*/ /* 不发送这个数据的,将处理列表中的数据 */ )
			{
				if (m_SendLockInOut.InLock() == false) return;
				try
				{
					// 在发送的线程中调用的
					MessageBlock^ sendMessageBlock = nullptr;
					do
					{
						if (m_SendMessageQueue.TryDequeue(sendMessageBlock) == false)
							break;

						if (sendMessageBlock == nullptr) break;

						// 以上从缓冲池内取出来,是为了防止多线程中发送时次序错误，不使用参数的数据
						// -----------------------------------------------------------------------

						if (m_LockCheck.IsValid() == false)
						{
							do
							{
								Client::MessageBlockManager->ReleaseMessageBlock(sendMessageBlock);
								sendMessageBlock = nullptr;

								if (m_SendMessageQueue.TryDequeue(sendMessageBlock) == false)
									break;
							} while (sendMessageBlock != nullptr);

							break;
						}

						MessageBlockInfo^ pSendMessageBlockInfo = MessageBlockInfo::GetMessageBlockInfo(sendMessageBlock);
						if (pSendMessageBlockInfo == nullptr)
						{
							Client::MessageBlockManager->ReleaseMessageBlock(sendMessageBlock);
							CloseSocket();

							throw gcnew System::Exception("ConnectHandler::OnSendBufferStream(...) - pSendMessageBlockInfo == NULL error\n");
						}

						MessageBlockInfo::CleanMessageBlockInfo(sendMessageBlock->HeadPointer());

						LPWSABUF pWsaBuf									= (LPWSABUF)MessageBlockInfo::GetWSABUF(sendMessageBlock);
						pWsaBuf->len										= (ULONG)sendMessageBlock->Length;
						pWsaBuf->buf										= (char*)sendMessageBlock->ReadPointer().ToPointer();

						pSendMessageBlockInfo->m_OperatorType				= TASK_WORKER_TYPE_SEND;
						pSendMessageBlockInfo->m_TransferredNumberOfBytes   = 0;
						pSendMessageBlockInfo->m_SendNumberOfBytes          = (System::UInt32)sendMessageBlock->Length;

						//-------------------------------------------------------------------------------
						// 测试发送消息块
						//*(sendMessageBlock.WritePointer()) = '\0';
						//AtlTrace("ConnectHandler = %p : Local Send DataBuffer = %s  Length = %d\n", this, sendMessageBlock.ReadPointer(), sendMessageBlock.Length());
						//--------------------------------------------------------------------------------

						DWORD iNumberOfBytesSent = 0;
						if ( ::WSASend((SOCKET)this->Owner->ConnectSocket.ToPointer(), pWsaBuf, 1, &iNumberOfBytesSent, 0, (LPOVERLAPPED)sendMessageBlock->HeadPointer(), NULL) == SOCKET_ERROR )
						{
							if( ::WSAGetLastError() != WSA_IO_PENDING )
							{
								Client::MessageBlockManager->ReleaseMessageBlock(sendMessageBlock);
								CloseSocket();

								throw gcnew System::Exception("ConnectHandler::OnSendBufferStream(...) - WSASend(...) == SOCKET_ERROR and WSAGetLastError(...) != ERROR_IO_PENDING error\n");
							}
						}
					} while (sendMessageBlock != nullptr);

				}
				finally
				{
					m_SendLockInOut.OutLock();
				}
			}

			void ConnectHandler::OnProcessBufferStream(MessageBlock^ /*processMessageBlock*/ /* 不处理这个数据的,将处理列表中的数据 */)
			{
				if (m_ProcessLockInOut.InLock() == false) return;
				try
				{
					// 在处理的线程中调用的
					MessageBlock^ processMessageBlock = nullptr;
					do
					{
						if (m_ProcessMessageQueue.TryDequeue(processMessageBlock) == false)
							break;

						if (processMessageBlock == nullptr) break;

						// 以上从缓冲池内取出来,是为了防止多线程中处理时次序错误，不使用参数的数据
						// -----------------------------------------------------------------------

						if (m_LockCheck.IsValid() == false)
						{
							do
							{
								Client::MessageBlockManager->ReleaseMessageBlock(processMessageBlock);

								if (m_ProcessMessageQueue.TryDequeue(processMessageBlock) == false)
									break;
							} while (processMessageBlock != nullptr);

							break;
						}

						// 回调函数处理全部的数据
						System::EventHandler<ProcessDataAtClientEventArgs^>^ tempEvent = this->Owner->m_EventProcessMessageBlock;
						if ( tempEvent != nullptr )
						{
							ProcessDataAtClientEventArgs^ processDataEventArgs = gcnew ProcessDataAtClientEventArgs( processMessageBlock, this, this->Owner->ConnectHandlerManager );
							tempEvent( this, processDataEventArgs );
						}
					} while (processMessageBlock != nullptr);
				}
				finally
				{
					m_ProcessLockInOut.OutLock();
				}
			}

			void ConnectHandler::InitReceiveBufferStream(MessageBlock^ receiveMessageBlock)
			{
				// 此处的CheckHandle() 总是为真 因为InitReceiveBufferStream(...)总是先在别处检验过再调用的

				MessageBlockInfo^ pReceiveMessageBlockInfo = MessageBlockInfo::GetMessageBlockInfo(receiveMessageBlock);
				if (pReceiveMessageBlockInfo == nullptr)
				{
					Client::MessageBlockManager->ReleaseMessageBlock(receiveMessageBlock);
					CloseSocket();

					throw gcnew System::Exception("ConnectHandler::OnReceiveBufferStream(...) - pReceiveMessageBlockInfo == NULL error\n");
				}

				MessageBlockInfo::CleanMessageBlockInfo(receiveMessageBlock->HeadPointer());

				// 初始化数据
				LPWSABUF pWsaBuf										= (LPWSABUF)MessageBlockInfo::GetWSABUF(receiveMessageBlock);
				pWsaBuf->len											= (u_long)(receiveMessageBlock->EndPointer().ToInt64() - receiveMessageBlock->WritePointer().ToInt64());
				pWsaBuf->buf											= (char*)receiveMessageBlock->WritePointer().ToPointer();

				pReceiveMessageBlockInfo->m_OperatorType                = TASK_WORKER_TYPE_RECEIVE;
				pReceiveMessageBlockInfo->m_TransferredNumberOfBytes    = 0;
				pReceiveMessageBlockInfo->m_SendNumberOfBytes           = 0;

				DWORD Flags = 0;
				DWORD RecvBytes = 0;
				if ( ::WSARecv((SOCKET)this->Owner->ConnectSocket.ToPointer(), pWsaBuf, 1, &RecvBytes, &Flags, (LPOVERLAPPED)receiveMessageBlock->HeadPointer(), NULL) == SOCKET_ERROR )
				{
					if( ::WSAGetLastError() != WSA_IO_PENDING )
					{
						Client::MessageBlockManager->ReleaseMessageBlock(receiveMessageBlock);
						CloseSocket();

						throw gcnew System::Exception("ConnectHandler::OnReceiveBufferStream(...) - WSARecv(...) == SOCKET_ERROR and WSAGetLastError(...) != ERROR_IO_PENDING error\n");
					}
				}
			}

			// ---------- ITaskWorkerHandler ----------



			// ---------- ConnectHandle ----------

			void ConnectHandler::SendTo(MessageBlock^ sendMessageBlock)
			{
				if (m_LockCheck.IsValid() == false)
				{
					Client::MessageBlockManager->ReleaseMessageBlock(sendMessageBlock);
					return ;
				}

				MessageBlockInfo^ pSendMessageBlockInfo = MessageBlockInfo::GetMessageBlockInfo(sendMessageBlock);
				if (pSendMessageBlockInfo == nullptr)
				{
					Client::MessageBlockManager->ReleaseMessageBlock(sendMessageBlock);
					CloseSocket();

					throw gcnew System::Exception("ConnectHandler::SendTo(...) - pSendMessageBlockInfo == nullptr error\n");
				}

				// 设置新的标识
				PostSendStream(pSendMessageBlockInfo);
			}

			void ConnectHandler::CloseSocket()
			{
				if (m_LockCheck.IsValid() == false)
					return ;

				InvalidHandle();
				FiniClientHandler();
			}

			// ---------- ConnectHandle ----------

			void ConnectHandler::PostSendStream(MessageBlockInfo^ sendMessageBlockInfo)
			{
				// 初始化数据
				sendMessageBlockInfo->m_OperatorType            = TASK_WORKER_TYPE_SEND;
				sendMessageBlockInfo->m_SendBufferStream		= m_DelegateSendBufferStream;

				m_SendMessageQueue.Enqueue(sendMessageBlockInfo->MessageBlock);

				Client::TaskManager->SendTaskWorker->QueueUserWorkItem(sendMessageBlockInfo);
			}

			void ConnectHandler::PostProcessStream(MessageBlockInfo^ processMessageBlockInfo)
			{
				// 初始化数据
				processMessageBlockInfo->m_OperatorType         = TASK_WORKER_TYPE_PROCSS;
				processMessageBlockInfo->m_ProcessBufferStream	= m_DelegateProcessBufferStream;

				m_ProcessMessageQueue.Enqueue(processMessageBlockInfo->MessageBlock);

				Client::TaskManager->ProcessTaskWorker->QueueUserWorkItem(processMessageBlockInfo);
			}

			void ConnectHandler::InitClientHandler()
			{
				m_bIsOnline						= true;

				// 获取地址
				SOCKADDR_IN remoteAddr;
				int iRemoteAddrLen  = sizeof(SOCKADDR_IN);   
				if( ::getpeername((SOCKET)this->Owner->ConnectSocket.ToPointer(), (SOCKADDR*)&remoteAddr, &iRemoteAddrLen) != SOCKET_ERROR )   
				{
					m_RemoteIP          = System::Runtime::InteropServices::Marshal::PtrToStringAnsi( (System::IntPtr)::inet_ntoa(remoteAddr.sin_addr) );  
					m_RemotePort        = ::ntohs(remoteAddr.sin_port);

					System::Text::StringBuilder^ stringBuilder = gcnew System::Text::StringBuilder();
					stringBuilder->Append(m_RemoteIP);
					stringBuilder->Append(":");
					stringBuilder->Append(m_RemotePort.ToString());

					m_RemoteAddress     = stringBuilder->ToString();
				}
				else
					throw gcnew System::Exception("ConnectHandler::InitServiceHandle(...) - getpeername(...) == SOCKET_ERROR error\n");

				m_FirstTime						= System::DateTime::Now;
				m_OnlineTime					= System::TimeSpan::Zero;
				m_LastMessageBlockTime			= System::DateTime::Now;
				m_MessageBlockNumbers			= 0;
				m_MessageBlockSpacingTime		= System::TimeSpan::Zero;
				m_MessageBlockNumbers60sec		= 0;
				m_AddUpMessageBlockSpacingTime	= System::TimeSpan::Zero;

				MessageBlock^ pMessageBlock = Client::MessageBlockManager->AcquireMessageBlock();
				if (pMessageBlock == nullptr)
				{
					CloseSocket();

					throw gcnew System::Exception("ConnectHandler::InitClientHandler(...) - pMessageBlock == NULL error\n");
				}

				// 初始化一个接受数据(准备开始接受数据)
				InitReceiveBufferStream(pMessageBlock);
			}

			void ConnectHandler::CalcClientHandler(void)
			{
				// 计算数据
				// 因为只有初始化一个接收以后才能接收收到的数据，所以不会产生多线程的计算问题。

				// 当前的时间
				System::DateTime iNowTime		= System::DateTime::Now;

				// 计算在线的时间
				m_OnlineTime					= iNowTime - m_FirstTime;

				// 计算两次接收包的间隔时间
				if(m_LastMessageBlockTime != System::DateTime::MinValue)
					m_MessageBlockSpacingTime	= iNowTime - m_LastMessageBlockTime;

				// 计算60秒内收到的数据包的数量
				m_AddUpMessageBlockSpacingTime	+= m_MessageBlockSpacingTime;
				if(m_AddUpMessageBlockSpacingTime > System::TimeSpan::FromSeconds(60))
				{
					m_AddUpMessageBlockSpacingTime	= m_MessageBlockSpacingTime;
					m_MessageBlockNumbers60sec		= 1;
				}
				else
				{
					m_MessageBlockNumbers60sec++;
				}

				// 计算最后接收包的时间
				m_LastMessageBlockTime			= iNowTime;

				// 计算共接收到包的数量
				m_MessageBlockNumbers++;
			}

			void ConnectHandler::FiniClientHandler (void)
			{
				m_bIsOnline						= false;
				m_RemoteIP						= System::String::Empty;
				m_RemotePort					= 0;
				m_RemoteAddress                 = System::String::Empty;

				m_FirstTime						= System::DateTime::MinValue;
				m_OnlineTime					= System::TimeSpan::Zero;
				m_LastMessageBlockTime			= System::DateTime::MinValue;
				m_MessageBlockNumbers			= 0;
				m_MessageBlockSpacingTime		= System::TimeSpan::Zero;

				m_MessageBlockNumbers60sec		= 0;
				m_AddUpMessageBlockSpacingTime	= System::TimeSpan::Zero;
			}

			void ConnectHandler::InvalidHandle()
			{
				if ( m_LockCheck.SetInvalid() == false )
					return;

				this->Owner->StopConnect();

				// 回调函数处理数据的断开
				System::EventHandler<DisconnectAtClientEventArgs^>^ tempEvent = this->Owner->m_EventDisconnect;
				if ( tempEvent != nullptr )
				{
					DisconnectAtClientEventArgs^ disconnectEventArgs = gcnew DisconnectAtClientEventArgs( this, this->Owner->ConnectHandlerManager );
					tempEvent( this, disconnectEventArgs );
				}
			}

		}
	}
}