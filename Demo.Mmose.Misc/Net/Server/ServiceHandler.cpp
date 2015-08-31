#include "StdAfx.h"
#include "ServerInc.h"
#include "ServiceHandler.h"

#include <time.h>

namespace Demo
{
	namespace Mmose
	{
		namespace Net
		{

			ServiceHandle::ServiceHandle() : m_bIsOnline(false)
				, m_RemotePort(0)
				, m_FirstTime(System::DateTime::MinValue)
				, m_OnlineTime(System::TimeSpan::Zero)
				, m_MessageBlockNumbers60sec(0)
				, m_LastMessageBlockTime(System::DateTime::MinValue)
				, m_MessageBlockNumbers(0)
				, m_MessageBlockSpacingTime(System::TimeSpan::Zero)
				, m_AddUpMessageBlockSpacingTime(System::TimeSpan::Zero)
				, m_RemoteIP(System::String::Empty)
				, m_RemoteAddress(System::String::Empty)
			{
			}


			//---------------------------------------------------------------------------

			ServiceHandler::ServiceHandler(SocketServer^ value) : m_pSocketServer(value)
				, m_hClientSocket((HANDLE)INVALID_SOCKET)
				, m_EventProcessData(nullptr)
				, m_EventDisconnect(nullptr)
				, m_SendLockInOut(false)
				, m_ProcessLockInOut(false)
				, m_LockCheck(true)
			{
				m_DelegateSendBufferStream = gcnew DelegateSendBufferStream(this, &Demo::Mmose::Net::ServiceHandler::OnSendBufferStream);
				m_DelegateProcessBufferStream = gcnew DelegateProcessBufferStream(this, &Demo::Mmose::Net::ServiceHandler::OnProcessBufferStream);
			}

			static ServiceHandler::ServiceHandler()
			{
				s_60secTimeSpan = System::TimeSpan::FromSeconds(60);
			}

			// ---------- IServiceHandler ��ʼ----------

			void ServiceHandler::OnAccept(MessageBlock^ acceptMessageBlock)
			{
				// Ӧ���޴˿���
				if (m_LockCheck.IsValid() == false)
				{
					Server::MessageBlockManager->ReleaseMessageBlock(acceptMessageBlock);
					return;
				}

				if (m_pSocketServer->ServiceHandleManager->OnlineClients > (int)m_pSocketServer->MaxClients)
				{
					Server::MessageBlockManager->ReleaseMessageBlock(acceptMessageBlock);
					CloseSocket();

					return;
				}

				// ��ʼ��ServiceHandler
				InitServiceHandle();

				MessageBlockInfo^ pAcceptMessageBlockInfo = MessageBlockInfo::GetMessageBlockInfo(acceptMessageBlock);
				if (pAcceptMessageBlockInfo == nullptr)
				{
					Server::MessageBlockManager->ReleaseMessageBlock(acceptMessageBlock);
					CloseSocket();

					throw gcnew System::Exception("ServiceHandler::OnAccept(...) - pAcceptMessageBlockInfo == nullptr error\n");
				}

				// �������ǲ�����ִ�����е�(m_TransferredNumberOfBytesʼ������)
				if ( pAcceptMessageBlockInfo->m_TransferredNumberOfBytes > 0 )
				{
					MessageBlock^ pMessageBlock = Server::MessageBlockManager->AcquireMessageBlock();
					if (pMessageBlock != nullptr)
					{
						::memcpy(pMessageBlock->WritePointer().ToPointer(), pAcceptMessageBlockInfo->MessageBlock->ReadPointer().ToPointer(), pAcceptMessageBlockInfo->m_TransferredNumberOfBytes );
						pAcceptMessageBlockInfo->MessageBlock->ReadPointer(pAcceptMessageBlockInfo->m_TransferredNumberOfBytes);

						MessageBlockInfo^ pMessageBlockInfo = MessageBlockInfo::GetMessageBlockInfo(pMessageBlock);
						if (pMessageBlockInfo == nullptr)
						{
							Server::MessageBlockManager->ReleaseMessageBlock(pMessageBlock);
							Server::MessageBlockManager->ReleaseMessageBlock(acceptMessageBlock);
							CloseSocket();

							throw gcnew System::Exception("ServiceHandler::OnAccept(...) - pMessageBlockInfo == nullptr error\n");
						}

						// �����µı�ʶ
						pMessageBlockInfo->m_OperatorType				= TASK_WORKER_TYPE_RECEIVE;
						pMessageBlockInfo->m_TransferredNumberOfBytes	= pAcceptMessageBlockInfo->m_TransferredNumberOfBytes;
						pMessageBlockInfo->m_SendNumberOfBytes			= pAcceptMessageBlockInfo->m_SendNumberOfBytes;

						pMessageBlockInfo->m_pServiceHandler			= pAcceptMessageBlockInfo->m_pServiceHandler;

						// ��ȡ��Ҫ������
						OnReadStream(pMessageBlock);
					}
					else
					{
						Server::MessageBlockManager->ReleaseMessageBlock(acceptMessageBlock);
						CloseSocket();

						throw gcnew System::Exception("ServiceHandler::OnAccept(...) - pMessageBlock == nullptr error\n");
					}
				}

				MessageBlock^ receiveMessageBlock  = acceptMessageBlock;
				receiveMessageBlock->ResetPointer();

				// ��ʼ��һ���µĽ�������
				InitReceiveBufferStream(receiveMessageBlock);
			}

			void ServiceHandler::OnReadStream(MessageBlock^ readMessageBlock)
			{
				if (m_LockCheck.IsValid() == false)
				{
					Server::MessageBlockManager->ReleaseMessageBlock(readMessageBlock);
					return;
				}

				// ����ServiceHandler������(1)
				CalcClientHandler();

				MessageBlockInfo^ pReadMessageBlockInfo     = MessageBlockInfo::GetMessageBlockInfo(readMessageBlock);
				if (pReadMessageBlockInfo == nullptr)
				{
					Server::MessageBlockManager->ReleaseMessageBlock(readMessageBlock);
					CloseSocket();

					throw gcnew System::Exception("ServiceHandler::OnReadStream(...) - pReadMessageBlockInfo == NULL error\n");
				}

				if (pReadMessageBlockInfo->m_OperatorType != TASK_WORKER_TYPE_RECEIVE)
				{
					Server::MessageBlockManager->ReleaseMessageBlock(readMessageBlock);
					CloseSocket();

					throw gcnew System::Exception("ServiceHandler::OnReadStream(...) - pReadMessageBlockInfo->m_OperatorType != TASK_WORKER_TYPE_RECEIVE error\n");
				}

				// ������ܵ�������С�ڵ����� ������Socket�ѹرյ�IOCP�ź�
				if (pReadMessageBlockInfo->m_TransferredNumberOfBytes <= 0)
				{
					Server::MessageBlockManager->ReleaseMessageBlock(readMessageBlock);
					CloseSocket();

					return;
				}
				else
					readMessageBlock->WritePointer(pReadMessageBlockInfo->m_TransferredNumberOfBytes);

				//-------------------------------------------------------------------------------
				// ���Խ�����Ϣ��
				//*(readMessageBlock.WritePointer()) = '\0';
				//AtlTrace("ServiceHandler = %p : Remote Receive DataBuffer = %s  Length = %d  TransferredNumberOfBytes = %d  ReadPointer() = %p  WritePointer() = %p\n",
				//	this, readMessageBlock.ReadPointer(), readMessageBlock.Length(), pReadMessageBlockInfo->m_TransferredNumberOfBytes, readMessageBlock.ReadPointer(), readMessageBlock.WritePointer());
				//--------------------------------------------------------------------------------

				// ���͸��������
				PostProcessStream(pReadMessageBlockInfo);

				MessageBlock^ pMessageBlock = Server::MessageBlockManager->AcquireMessageBlock();
				if (pMessageBlock == nullptr)
				{
					CloseSocket();

					throw gcnew System::Exception("ServiceHandler::OnReadStream(...) - pMessageBlock == NULL error\n");
				}

				// ��ʼ��һ���µĽ�������
				InitReceiveBufferStream(pMessageBlock);
			}

			void ServiceHandler::OnWriteStream(MessageBlock^ writeMessageBlock)
			{
				if (m_LockCheck.IsValid() == false)
				{
					Server::MessageBlockManager->ReleaseMessageBlock(writeMessageBlock);
					return;
				}

				MessageBlockInfo^ pWriteMessageBlockInfo = MessageBlockInfo::GetMessageBlockInfo(writeMessageBlock);
				if (pWriteMessageBlockInfo == nullptr)
				{
					Server::MessageBlockManager->ReleaseMessageBlock(writeMessageBlock);
					CloseSocket();

					throw gcnew System::Exception("ServiceHandler::OnWriteStream(...) - pWriteMessageBlockInfo == NULL error\n");
				}

				if (pWriteMessageBlockInfo->m_OperatorType != TASK_WORKER_TYPE_SEND)
				{
					Server::MessageBlockManager->ReleaseMessageBlock(writeMessageBlock);
					CloseSocket();

					throw gcnew System::Exception("ServiceHandler::OnWriteStream(...) - pReadMessageBlockInfo->m_OperatorType != TASK_WORKER_TYPE_RECEIVE error\n");
				}

				// ��ⷢ�ͳ�ȥ�������Ƿ�С���跢�͵�����,���ʣ������ݷ������
				int iNumberOfBytes = pWriteMessageBlockInfo->m_SendNumberOfBytes - pWriteMessageBlockInfo->m_TransferredNumberOfBytes;
				if ( iNumberOfBytes > 0 )
				{
					MessageBlock^ pMessageBlock = Server::MessageBlockManager->AcquireMessageBlock();
					if (pMessageBlock != nullptr)
					{
						// �����ѷ��͵�������
						pWriteMessageBlockInfo->MessageBlock->ReadPointer(pWriteMessageBlockInfo->m_TransferredNumberOfBytes);

						::memcpy(pMessageBlock->WritePointer().ToPointer(), pWriteMessageBlockInfo->MessageBlock->ReadPointer().ToPointer(), iNumberOfBytes );
						pMessageBlock->WritePointer(iNumberOfBytes);
						pWriteMessageBlockInfo->MessageBlock->ReadPointer(iNumberOfBytes);

						MessageBlockInfo^ pMessageBlockInfo = MessageBlockInfo::GetMessageBlockInfo(pMessageBlock);
						if (pMessageBlockInfo == nullptr)
						{
							Server::MessageBlockManager->ReleaseMessageBlock(pMessageBlock);
							Server::MessageBlockManager->ReleaseMessageBlock(writeMessageBlock);
							CloseSocket();

							throw gcnew System::Exception("ServiceHandler::OnWriteStream(...) - pMessageBlockInfo == NULL error\n");
						}

						// �����µı�ʶ
						PostSendStream(pMessageBlockInfo);
					}
					else
					{
						Server::MessageBlockManager->ReleaseMessageBlock(writeMessageBlock);
						CloseSocket();

						throw gcnew System::Exception("ServiceHandler::OnWriteStream(...) - pMessageBlock == NULL error\n");
					}
				}

				Server::MessageBlockManager->ReleaseMessageBlock(writeMessageBlock);
			}

			// ---------- IServiceHandler ����----------



			// ---------- ClientHandler_Server ----------

			void ServiceHandler::SendTo(MessageBlock^ sendMessageBlock)
			{
				if (m_LockCheck.IsValid() == false)
				{
					Server::MessageBlockManager->ReleaseMessageBlock(sendMessageBlock);
					return;
				}

				MessageBlockInfo^ pSendMessageBlockInfo = MessageBlockInfo::GetMessageBlockInfo(sendMessageBlock);
				if (pSendMessageBlockInfo == nullptr)
				{
					Server::MessageBlockManager->ReleaseMessageBlock(sendMessageBlock);
					CloseSocket();

					throw gcnew System::Exception("ServiceHandler::SendTo(...) - pSendMessageBlockInfo == NULL error\n");
				}

				// �����µı�ʶ
				PostSendStream(pSendMessageBlockInfo);
			}

			void ServiceHandler::CloseSocket()
			{
				if (m_LockCheck.IsValid() == false)
					return;

				InvalidHandle();
				FiniClientHandler();
				FreeThis();
			}

			// ---------- ClientHandler_Server ----------



			// ---------- ITaskWorkerHandler ----------

			void ServiceHandler::OnSendBufferStream(MessageBlock^ /*sendMessageBlock*/)
			{
				if (m_SendLockInOut.InLock() == false) return;
				try
				{
					// �ڷ��͵��߳��е��õ�
					MessageBlock^ sendMessageBlock = nullptr;
					do
					{
						if (m_SendMessageQueue.TryDequeue(sendMessageBlock) == false)
							break;

						if (sendMessageBlock == nullptr) break;

						// ���ϴӻ������ȡ����,��Ϊ�˷�ֹ���߳��з���ʱ������󣬲�ʹ�ò���������
						// -----------------------------------------------------------------------

						if (m_LockCheck.IsValid() == false)
						{
							do
							{
								Server::MessageBlockManager->ReleaseMessageBlock(sendMessageBlock);
								sendMessageBlock = nullptr;

								if (m_SendMessageQueue.TryDequeue(sendMessageBlock) == false)
									break;
							} while (sendMessageBlock != nullptr);

							break;
						}

						MessageBlockInfo^ pSendMessageBlockInfo = MessageBlockInfo::GetMessageBlockInfo(sendMessageBlock);
						if (pSendMessageBlockInfo == nullptr)
						{
							Server::MessageBlockManager->ReleaseMessageBlock(sendMessageBlock);
							CloseSocket();

							throw gcnew System::Exception("ServiceHandler::OnSendBufferStream(...) - pSendMessageBlockInfo == NULL error\n");
						}

						MessageBlockInfo::CleanMessageBlockInfo(sendMessageBlock->HeadPointer());

						LPWSABUF pWsaBuf									= (LPWSABUF)MessageBlockInfo::GetWSABUF(sendMessageBlock);
						pWsaBuf->len										= (ULONG)sendMessageBlock->Length;
						pWsaBuf->buf										= (char*)sendMessageBlock->ReadPointer().ToPointer();

						pSendMessageBlockInfo->m_OperatorType               = TASK_WORKER_TYPE_SEND;
						pSendMessageBlockInfo->m_TransferredNumberOfBytes   = 0;
						pSendMessageBlockInfo->m_SendNumberOfBytes          = (System::UInt32)sendMessageBlock->Length;

						pSendMessageBlockInfo->m_pServiceHandler            = this;

						//-------------------------------------------------------------------------------
						// ���Է�����Ϣ��
						//*(sendMessageBlock.WritePointer()) = '\0';
						//AtlTrace("ServiceHandler = %p : Local Send DataBuffer = %s  Length = %d\n", this, sendMessageBlock.ReadPointer(), sendMessageBlock.Length());
						//--------------------------------------------------------------------------------

						DWORD iNumberOfBytesSent = 0;
						if ( ::WSASend((SOCKET)m_hClientSocket.ToPointer(), pWsaBuf, 1, &iNumberOfBytesSent, 0, (LPOVERLAPPED)sendMessageBlock->HeadPointer(), NULL) == SOCKET_ERROR )
						{
							if( ::WSAGetLastError() != WSA_IO_PENDING )
							{
								Server::MessageBlockManager->ReleaseMessageBlock(sendMessageBlock);
								CloseSocket();

								throw gcnew System::Exception("ServiceHandler::OnSendBufferStream(...) - WSASend(...) == SOCKET_ERROR and WSAGetLastError(...) != ERROR_IO_PENDING error\n");
							}
						}
					} while (sendMessageBlock != nullptr);
				}
				finally
				{
					m_SendLockInOut.OutLock();
				}
			}

			void ServiceHandler::OnProcessBufferStream(MessageBlock^ /*processMessageBlock*/)
			{
				if (m_ProcessLockInOut.InLock() == false) return;
				try
				{
					// �ڴ�����߳��е��õ�
					MessageBlock^ processMessageBlock = nullptr;
					do
					{
						if (m_ProcessMessageQueue.TryDequeue(processMessageBlock) == false)
							break;

						if (processMessageBlock == nullptr) break;

						// ���ϴӻ������ȡ����,��Ϊ�˷�ֹ���߳��д���ʱ������󣬲�ʹ�ò���������
						// -----------------------------------------------------------------------

						if (m_LockCheck.IsValid() == false)
						{
							do
							{
								Server::MessageBlockManager->ReleaseMessageBlock(processMessageBlock);
								processMessageBlock = nullptr;

								if (m_SendMessageQueue.TryDequeue(processMessageBlock) == false)
									break;
							} while (processMessageBlock != nullptr);

							break;
						}

						System::Int64 writeLength	= processMessageBlock->WriteLength;
						System::Int64 readLength	= processMessageBlock->ReadLength;

						// �ص���������ȫ��������
						System::EventHandler<GlobalProcessDataAtServerEventArgs^>^ tempEvent = this->Owner->m_EventProcessGlobalMessageBlock;
						if ( tempEvent != nullptr )
						{
							GlobalProcessDataAtServerEventArgs^ processDataEventArgs = gcnew GlobalProcessDataAtServerEventArgs( processMessageBlock, this, this->Owner->ServiceHandleManager );
							tempEvent( this, processDataEventArgs );
						}

						processMessageBlock->ResetPointer();
						processMessageBlock->WritePointer(writeLength);
						processMessageBlock->ReadPointer(readLength);

						// �ص���������ǰ������
						System::EventHandler<ProcessDataAtServerEventArgs^>^ tempEvent2 = this->m_EventProcessData;
						if ( tempEvent2 != nullptr )
						{
							ProcessDataAtServerEventArgs^ processDataEventArgs = gcnew ProcessDataAtServerEventArgs( processMessageBlock, this, this->Owner->ServiceHandleManager );
							tempEvent2( this, processDataEventArgs );
						}

						Server::MessageBlockManager->ReleaseMessageBlock(processMessageBlock);

					} while (processMessageBlock != nullptr);
				}
				finally
				{
					m_ProcessLockInOut.OutLock();
				}
			}

			void ServiceHandler::InitReceiveBufferStream(MessageBlock^ receiveMessageBlock)
			{
				// �˴���CheckHandle() ����Ϊ�� ��ΪInitReceiveBufferStream(...)�������ڱ𴦼�����ٵ��õ�

				MessageBlockInfo^ pReceiveMessageBlockInfo = MessageBlockInfo::GetMessageBlockInfo(receiveMessageBlock);
				if (pReceiveMessageBlockInfo == nullptr)
				{
					Server::MessageBlockManager->ReleaseMessageBlock(receiveMessageBlock);
					CloseSocket();

					throw gcnew System::Exception("ServiceHandler::OnReceiveBufferStream(...) - pReceiveMessageBlockInfo == NULL error\n");
				}

				MessageBlockInfo::CleanMessageBlockInfo(receiveMessageBlock->HeadPointer());

				// ��ʼ������
				LPWSABUF pWsaBuf										= (LPWSABUF)((LPBYTE)receiveMessageBlock->HeadPointer() + sizeof(OVERLAPPED));
				pWsaBuf->len											= (u_long)(receiveMessageBlock->EndPointer().ToInt64() - receiveMessageBlock->WritePointer().ToInt64());
				pWsaBuf->buf											= (char*)receiveMessageBlock->WritePointer().ToPointer();

				pReceiveMessageBlockInfo->m_OperatorType                = TASK_WORKER_TYPE_RECEIVE;
				pReceiveMessageBlockInfo->m_TransferredNumberOfBytes    = 0;
				pReceiveMessageBlockInfo->m_SendNumberOfBytes           = 0;

				pReceiveMessageBlockInfo->m_pServiceHandler             = this;

				DWORD Flags = 0;
				DWORD RecvBytes = 0;
				if ( ::WSARecv((SOCKET)m_hClientSocket.ToPointer(), pWsaBuf, 1, &RecvBytes, &Flags, (LPOVERLAPPED)receiveMessageBlock->HeadPointer(), NULL) == SOCKET_ERROR )
				{
					if( ::WSAGetLastError() != WSA_IO_PENDING )
					{
						Server::MessageBlockManager->ReleaseMessageBlock(receiveMessageBlock);
						CloseSocket();

						throw gcnew System::Exception("ServiceHandler::OnReceiveBufferStream(...) - WSARecv(...) == SOCKET_ERROR and WSAGetLastError(...) != ERROR_IO_PENDING error\n");
					}
				}
			}

			// ---------- ITaskWorkerHandler ----------

			void ServiceHandler::PostSendStream(MessageBlockInfo^ sendMessageBlockInfo)
			{
				// ��ʼ������
				sendMessageBlockInfo->m_OperatorType			= TASK_WORKER_TYPE_SEND;
				sendMessageBlockInfo->m_SendBufferStream		= m_DelegateSendBufferStream;

				m_SendMessageQueue.Enqueue(sendMessageBlockInfo->MessageBlock);

				Server::TaskManager->SendTaskWorker->QueueUserWorkItem(sendMessageBlockInfo);
			}

			void ServiceHandler::PostProcessStream(MessageBlockInfo^ processMessageBlockInfo)
			{
				// ��ʼ������
				processMessageBlockInfo->m_OperatorType			= TASK_WORKER_TYPE_PROCSS;
				processMessageBlockInfo->m_ProcessBufferStream	= m_DelegateProcessBufferStream;

				m_ProcessMessageQueue.Enqueue(processMessageBlockInfo->MessageBlock);

				Server::TaskManager->ProcessTaskWorker->QueueUserWorkItem(processMessageBlockInfo);
			}

			void ServiceHandler::InitServiceHandle()
			{
				m_bIsOnline						= true;

				// ��ȡ��ַ
				SOCKADDR_IN remoteAddr;
				int iRemoteAddrLen  = sizeof(SOCKADDR_IN);   
				if( ::getpeername((SOCKET)m_hClientSocket.ToPointer(), (SOCKADDR*)&remoteAddr, &iRemoteAddrLen) != SOCKET_ERROR )   
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
					throw gcnew System::Exception("ServiceHandler::InitServiceHandle(...) - getpeername(...) == SOCKET_ERROR error\n");

				// ��ʼ��ServiceHandler������
				m_FirstTime						= System::DateTime::Now;
				m_OnlineTime					= System::TimeSpan::Zero;
				m_LastMessageBlockTime			= System::DateTime::Now;
				m_MessageBlockNumbers			= 0;
				m_MessageBlockSpacingTime		= System::TimeSpan::Zero;
				m_MessageBlockNumbers60sec		= 0;
				m_AddUpMessageBlockSpacingTime	= System::TimeSpan::Zero;


				// ����������� ������ܻ��ڻص�OnAcceptor(...)ʱ������CloseSocket()�����
				m_pSocketServer->ServiceHandleManager->AddValidClientHandler(this);

				// �����½��մ���Ļص�����
				System::EventHandler<AcceptorEventArgs^>^ tempEvent = this->Owner->m_EventAcceptor;
				if ( tempEvent != nullptr )
				{
					AcceptorEventArgs^ acceptorEventArgs = gcnew AcceptorEventArgs( this, this->Owner->ServiceHandleManager );
					tempEvent( this, acceptorEventArgs );
				}
			}

			void ServiceHandler::CalcClientHandler(void)
			{
				// ��������
				// ��Ϊֻ�г�ʼ��һ�������Ժ���ܽ����յ������ݣ����Բ���������̵߳ļ������⡣

				// ��ǰ��ʱ��
				System::DateTime iNowTime		= System::DateTime::Now;

				// �������ߵ�ʱ��
				m_OnlineTime					= iNowTime - m_FirstTime;

				// �������ν��հ��ļ��ʱ��
				if(m_LastMessageBlockTime != System::DateTime::MinValue)
					m_MessageBlockSpacingTime	= iNowTime - m_LastMessageBlockTime;

				// ����60�����յ������ݰ�������
				m_AddUpMessageBlockSpacingTime	+= m_MessageBlockSpacingTime;
				if(m_AddUpMessageBlockSpacingTime > s_60secTimeSpan)
				{
					m_AddUpMessageBlockSpacingTime	= m_MessageBlockSpacingTime;
					m_MessageBlockNumbers60sec		= 1;
				}
				else
					m_MessageBlockNumbers60sec++;

				// ���������հ���ʱ��
				m_LastMessageBlockTime			= iNowTime;

				// ���㹲���յ���������
				m_MessageBlockNumbers++;
			}

			void ServiceHandler::FiniClientHandler(void)
			{
				m_bIsOnline						= false;

				m_pSocketServer->ServiceHandleManager->DelInvalidClientHandler(this);

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

			void ServiceHandler::InvalidHandle()
			{
				if ( m_LockCheck.SetInvalid() == false )
					return;

				::closesocket((SOCKET)m_hClientSocket.ToPointer());
				m_hClientSocket = (System::IntPtr)(HANDLE)INVALID_SOCKET;


				// �ص���������ȫ�����ݵĶϿ�
				System::EventHandler<GlobalDisconnectAtServerEventArgs^>^ tempEvent = this->Owner->m_EventGlobalDisconnect;
				if ( tempEvent != nullptr )
				{
					GlobalDisconnectAtServerEventArgs^ disconnectEventArgs = gcnew GlobalDisconnectAtServerEventArgs( this, this->Owner->ServiceHandleManager );
					tempEvent( this, disconnectEventArgs );
				}

				// �ص���������ǰ���ݵĶϿ�
				System::EventHandler<DisconnectAtServerEventArgs^>^ tempEvent2 = this->m_EventDisconnect;
				if ( tempEvent2 != nullptr )
				{
					DisconnectAtServerEventArgs^ disconnectEventArgs = gcnew DisconnectAtServerEventArgs( this, this->Owner->ServiceHandleManager );
					tempEvent2( this, disconnectEventArgs );
				}
			}

			void ServiceHandler::FreeThis(void)
			{
				m_pSocketServer->ServiceHandleManager->ReleaseServiceHandler(this); // �����ڴ��
			}

		}
	}
}