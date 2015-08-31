#include "StdAfx.h"
#include "ServerInc.h"
#include "SocketServer.h"

namespace Demo
{
	namespace Mmose
	{
		namespace Net
		{

			static SocketServer::SocketServer()
			{
				m_NumberThread = 0;
			}

			SocketServer::SocketServer () : m_IsStartServer(false)
				, m_lpfnAcceptEx(System::IntPtr::Zero)
				, m_hListen((System::IntPtr)(HANDLE)INVALID_SOCKET)
				, m_hCompletionPort((System::IntPtr)INVALID_HANDLE_VALUE)
				, m_pSockAddress(System::String::Empty)
				, m_EventAcceptor(nullptr)
				, m_EventGlobalDisconnect(nullptr)
				, m_EventProcessGlobalMessageBlock(nullptr)
				, m_iMaxClients(Server::s_ServerMaxClients)
			{
				m_pManagerHandler = gcnew Demo::Mmose::Net::ServiceHandleManager(this);

				// ���Լ���ӵ�ȫ�ֵ��б���
				Server::AddNewInstance(this);
			}

			bool SocketServer::StartServer(System::String^ strHostNamePort)
			{
				int iFind = strHostNamePort->IndexOf(':');
				if ( iFind < 0 )
					return false;

				System::String^ strHostName = strHostNamePort->Substring( 0, iFind );
				System::IntPtr ptrHostName = System::Runtime::InteropServices::Marshal::StringToHGlobalAnsi(strHostName);
				const char* charHostName = static_cast<const char*>(ptrHostName.ToPointer());

				System::String^ strHost = System::String::Empty;
				if ( ::inet_addr( charHostName ) != INADDR_NONE )
				{
					strHost = strHostName;
					System::Runtime::InteropServices::Marshal::FreeHGlobal( ptrHostName );
				}
				else
				{
					::hostent* pHostAddr = ::gethostbyname( charHostName );
					System::Runtime::InteropServices::Marshal::FreeHGlobal( ptrHostName );

					if( pHostAddr != NULL )
					{
						SOCKADDR_IN SockAddr;
						::memcpy ( &SockAddr.sin_addr.s_addr, pHostAddr->h_addr_list[0], pHostAddr->h_length);
						strHost = System::Runtime::InteropServices::Marshal::PtrToStringAnsi(static_cast<System::IntPtr>(::inet_ntoa(SockAddr.sin_addr)));
					}
					else
						return false;
				}

				System::String^ strPort = strHostNamePort->Substring( iFind + 1 );
				System::UInt32 iPort = System::Convert::ToUInt32( strPort );

				// �����Ǹ��������Ķ˿ں͵�ַ
				return StartServer( strHost, iPort );
			}

			void SocketServer::ThreadPoolFunction()
			{
				if (m_hCompletionPort.ToPointer() == 0 || m_hCompletionPort.ToPointer() == INVALID_HANDLE_VALUE)
					throw gcnew System::Exception("SocketServer::ServerThread(...) - m_hCompletionPort == 0 || m_hCompletionPort == INVALID_HANDLE_VALUE error\n");

				// ��ʼ�߳�

				//����ѭ���ĵȴ��ص����������
				while(true)
				{
					// �µĳ�ʼ��
					DWORD iTransferredBytes = 0;
					ULONG iCompletionKey = 0;
					LPOVERLAPPED* lpOverlapped = NULL;

					INT iReturn = ::GetQueuedCompletionStatus(
						m_hCompletionPort.ToPointer(),		// ԭ�ȵ���ɶ˿ھ��
						&iTransferredBytes,                 // �ص�������ɵ��ֽ���
						reinterpret_cast<PULONG_PTR>(&iCompletionKey),		// ԭ�Ⱥ���ɶ˿ھ����������������(ûʹ��)
						(LPOVERLAPPED*)&lpOverlapped,		// ���ڽ�������ɵ�IO�������ص��ṹ(����λ��MessageBlockβ����MessageBlockInfo�ṹ)
						INFINITE);                          // ����ɶ˿��ϵȴ���ʱ�� INFINITE Ϊ���޵ȴ�

					if (iReturn == FALSE && lpOverlapped == NULL)
					{
						if( ::GetLastError() == WAIT_TIMEOUT )
							continue;
						else
							break; 
					}
					else if (iReturn == FALSE && iTransferredBytes == 0 )
					{
						if( ::GetLastError() == ERROR_OPERATION_ABORTED )
						{
							// �������ľ���Ѿ��ر� �򷵻�ERROR_OPERATION_ABORTED
							break;
						}
					}

					if (lpOverlapped == NULL)
						throw gcnew System::Exception("SocketServer::ServerThread(...) - lpOverlapped == NULL error\n");

					MessageBlockInfo^ pMessageBlockInfo = MessageBlockInfo::GetMessageBlockInfo(lpOverlapped); 
					if ( pMessageBlockInfo == nullptr)
						throw gcnew System::Exception("SocketServer::ServerThread(...) - pMessageBlockInfo == nullptr error\n");

					MessageBlock^ pMessageBlock = pMessageBlockInfo->MessageBlock;
					if ( pMessageBlock == nullptr)
						throw gcnew System::Exception("SocketServer::ServerThread(...) - pMessageBlock == nullptr error\n");

					//AtlTrace("SocketServer::ServerThread(...) - m_OperatorType == %d\n", pMessageBlockInfo->m_OperatorType);

					switch(pMessageBlockInfo->m_OperatorType)
					{
					case TASK_WORKER_TYPE_ACCEPT: // ACCEPT�ɹ���ķ���
						{
							bool bReturn = true;
							do
							{
								ServiceHandler^ pServiceHandler = dynamic_cast<ServiceHandler^>(pMessageBlockInfo->m_pServiceHandler);
								if ( pServiceHandler == nullptr )
								{
									bReturn = false;
									break;
								}

								SOCKET clientSocket = (SOCKET)pServiceHandler->ClientSocket.ToPointer();
								if ( clientSocket == INVALID_SOCKET )
								{
									bReturn = false;
									break;
								}

								SOCKET listenSocket = (SOCKET)this->ListenSocket.ToPointer();
								if ( listenSocket == INVALID_SOCKET )
								{
									// �������׽����Ѿ��Ͽ�
									bReturn = false;
									break;
								}

								// 
								if( ::setsockopt( clientSocket, SOL_SOCKET, SO_UPDATE_ACCEPT_CONTEXT, (const char*)&listenSocket, sizeof( SOCKET ) ) == SOCKET_ERROR )
								{
									// ���ܼ������׽����Ѿ��Ͽ�
									bReturn = false;
									break;
								}

								// ���µĿͻ��׽�������ɶ˿�����
								if ( ::CreateIoCompletionPort( (HANDLE)clientSocket, m_hCompletionPort.ToPointer(), NULL, 0 ) == NULL )
								{
									bReturn = false;
									break;
								}

								// ����һ���µ�Accept
								if ( this->Accept() == false )
								{
									// ��������������(�Ѹ�)
									//System::Diagnostics::Debug::WriteLine("SocketServer::ServerThread(.TASK_WORKER_TYPE_ACCEPT.) - pAcceptHandler->Accept() == false warning(��������������)\n");
								}

								// ���յ������ݴ�С
								pMessageBlockInfo->m_TransferredNumberOfBytes = iTransferredBytes;
								// ֪ͨ���µĲ���Accept����
								pServiceHandler->OnAccept(pMessageBlock);
							} while (false); // do

							if ( bReturn == false )
								Server::MessageBlockManager->ReleaseMessageBlock(pMessageBlock);
						}

						break;
					case TASK_WORKER_TYPE_SEND: // �������ݳɹ���ķ���
						{
							bool bReturn = true;
							do
							{
								ServiceHandler^ pServiceHandler = dynamic_cast<ServiceHandler^>(pMessageBlockInfo->m_pServiceHandler);
								if ( pServiceHandler == nullptr)
								{
									bReturn = false;
									break;
								}

								SOCKET clientSocket = (SOCKET)pServiceHandler->ClientSocket.ToPointer();
								if ( clientSocket == INVALID_SOCKET )
								{
									bReturn = false;
									break;
								}

								SOCKET pListenSocket = (SOCKET)this->ListenSocket.ToPointer();
								if ( pListenSocket == INVALID_SOCKET )
								{
									bReturn = false;
									break;
								}

								// �ѷ��ͳ�ȥ�����ݴ�С
								pMessageBlockInfo->m_TransferredNumberOfBytes = iTransferredBytes;
								// ֪ͨ�ѷ��ͳ�ȥ����
								pServiceHandler->OnWriteStream(pMessageBlock);
							} while (false);

							if ( bReturn == false )
								Server::MessageBlockManager->ReleaseMessageBlock(pMessageBlock);
						}
						break;
					case TASK_WORKER_TYPE_RECEIVE: // �������ݳɹ���ķ���
						{
							bool bReturn = true;
							do
							{
								ServiceHandler^ pServiceHandler = dynamic_cast<ServiceHandler^>(pMessageBlockInfo->m_pServiceHandler);
								if ( pServiceHandler == nullptr)
								{
									bReturn = false;
									break;
								}

								SOCKET clientSocket = (SOCKET)pServiceHandler->ClientSocket.ToPointer();
								if ( clientSocket == INVALID_SOCKET )
								{
									bReturn = false;
									break;
								}

								SOCKET pListenSocket = (SOCKET)this->ListenSocket.ToPointer();
								if ( pListenSocket == INVALID_SOCKET )
								{
									bReturn = false;
									break;
								}

								// �ѽ��յ������ݴ�С
								pMessageBlockInfo->m_TransferredNumberOfBytes = iTransferredBytes;
								// ֪ͨ���µ������յ�
								pServiceHandler->OnReadStream(pMessageBlock);
							} while (false);

							if ( bReturn == false )
								Server::MessageBlockManager->ReleaseMessageBlock(pMessageBlock);
						}

						break;
					case TASK_WORKER_TYPE_PROCSS: // ������������������ (TASK_WORKER_TYPE_PROCSS ��TaskWorker�д���)
						Server::MessageBlockManager->ReleaseMessageBlock(pMessageBlock);

						throw gcnew System::Exception("SocketServer::ServerThread(...) - pMessageBlockInfo->m_OperatorType == TASK_WORKER_TYPE_PROCSS error\n");
					case TASK_WORKER_TYPE_NONE: // ������������������ (TASK_WORKER_TYPE_NONE �޴���)
						Server::MessageBlockManager->ReleaseMessageBlock(pMessageBlock);

						throw gcnew System::Exception("SocketServer::ServerThread(...) - pMessageBlockInfo->m_OperatorType == TASK_WORKER_TYPE_NONE error\n");
					default: // ��������
						Server::MessageBlockManager->ReleaseMessageBlock(pMessageBlock);

						throw gcnew System::Exception("SocketServer::ServerThread(...) - pMessageBlockInfo->m_OperatorType == default(...) error\n");
					}
				}

				// �����߳�
			}

			bool SocketServer::StartServer( System::String^ strHost, System::UInt32 iPort )
			{
				// �����û�г�ʼ��
				if ( Server::IsInit == false )
					throw gcnew System::Exception("SocketServer::StartServer(...) - Server::IsInit == false error\n");

				if ( m_IsStartServer == true )
					return false;

				bool bReturn = true;
				m_Lock.Enter();
				try
				{
					do
					{
						if ( m_IsStartServer == true )
						{
							bReturn = false;
							break;
						}

						// ����һ��IO��ɶ˿�
						m_hCompletionPort = (System::IntPtr)::CreateIoCompletionPort(INVALID_HANDLE_VALUE, NULL, 0, 0);
						if ( m_hCompletionPort == System::IntPtr::Zero )
						{
							bReturn = false;
							break;
						}

						// ���ݴ�����������������Ӧ��Ĵ����߳�
						for( INT iIndex = 0; iIndex < Demo::Mmose::Net::Server::s_ServerReceiveThreadPoolSize; iIndex++ )
						{
							System::Threading::Thread^ iocpThread = gcnew System::Threading::Thread( gcnew System::Threading::ThreadStart( this, &Demo::Mmose::Net::SocketServer::ThreadPoolFunction ) );
							iocpThread->Name = "Socket Server Receive Thread-" + System::Threading::Interlocked::Increment(m_NumberThread).ToString();
							iocpThread->IsBackground = true;
							iocpThread->Start();
						}

						// ����һ�������׽���(�����ص�����)
						m_hListen = (System::IntPtr)(HANDLE)::WSASocket( AF_INET, SOCK_STREAM, 0, NULL, 0, WSA_FLAG_OVERLAPPED );
						if ( (SOCKET)m_hListen.ToPointer() == INVALID_SOCKET )
						{                
							bReturn = false;
							break;
						}

						HANDLE hCompletionPort = ::CreateIoCompletionPort((HANDLE)m_hListen, m_hCompletionPort.ToPointer(), NULL, 0);
						if ( hCompletionPort == NULL )
						{
							bReturn = false;
							break;
						}

						SOCKADDR_IN ServiceAddr;
						ServiceAddr.sin_family = AF_INET;
						ServiceAddr.sin_port = ::htons( (u_short)iPort );

						if (strHost == nullptr)
							ServiceAddr.sin_addr.s_addr = ::htonl(INADDR_ANY);
						else
						{
							System::IntPtr ptrHost = System::Runtime::InteropServices::Marshal::StringToHGlobalAnsi(strHost);
							const char* charHost = static_cast<const char*>(ptrHost.ToPointer());

							ServiceAddr.sin_addr.s_addr = ::inet_addr( charHost );

							System::Runtime::InteropServices::Marshal::FreeHGlobal( ptrHost );
						}

						if ( ::bind( (SOCKET)m_hListen.ToPointer(), (PSOCKADDR)&ServiceAddr, sizeof(SOCKADDR_IN) ) == SOCKET_ERROR )
						{
							bReturn = false;
							break;
						}

						if ( ::listen( (SOCKET)m_hListen.ToPointer(), 5/*5��ͬʱ����*/ ) == SOCKET_ERROR )
						{
							bReturn = false;
							break;
						}

						//Accept function GUID
						GUID guidAcceptEx = WSAID_ACCEPTEX;

						//get acceptex function pointer
						DWORD dwBytes = 0;

						LPFN_ACCEPTEX lpfnAcceptEx; //AcceptEx����ָ��
						if( ::WSAIoctl( (SOCKET)m_hListen.ToPointer(), SIO_GET_EXTENSION_FUNCTION_POINTER, &guidAcceptEx, sizeof(guidAcceptEx), &lpfnAcceptEx, sizeof(m_lpfnAcceptEx), &dwBytes, NULL, NULL ) == SOCKET_ERROR )
						{
							bReturn = false;
							break;
						}
						else
						{
							m_lpfnAcceptEx = (System::IntPtr)((void*)lpfnAcceptEx);
						}

						for (int iIndex = 0; iIndex < 5/*5��ͬʱ����*/; iIndex++)
						{
							if ( Accept() == false )
							{
								bReturn = false;
								break;
							}
						}

						System::Text::StringBuilder^ strSockAddress = gcnew System::Text::StringBuilder();

						if (strHost == nullptr)
							strSockAddress->Append("127.0.0.1");
						else
							strSockAddress->Append(strHost);

						strSockAddress->Append(":");
						strSockAddress->Append(iPort.ToString());

						m_pSockAddress = strSockAddress->ToString();

						m_IsStartServer = true;
					} while (false); // do
				}
				finally
				{
					m_Lock.Exit();

					if ( bReturn == false )
					{
						// �ر�ȫ�����ߵ�Socket, �����Ѿ��м�����Socket��
						m_pManagerHandler->CloseAllSocket();

						if ((SOCKET)m_hListen.ToPointer() != INVALID_SOCKET)
						{
							::closesocket((SOCKET)m_hListen.ToPointer());
							m_hListen = (System::IntPtr)(HANDLE)INVALID_SOCKET;
						}

						if (m_hCompletionPort.ToPointer() != INVALID_HANDLE_VALUE)
						{
							::CloseHandle( m_hCompletionPort.ToPointer() );
							m_hCompletionPort = (System::IntPtr)INVALID_HANDLE_VALUE;
						}
					}
				}

				return bReturn;
			}

			void SocketServer::StopServer(void)
			{
				if ( m_IsStartServer == false )
					return;

				m_Lock.Enter();
				try
				{
					do
					{
						if ( m_IsStartServer == false )
							break;

						// �ر�ȫ�����ߵ�Socket
						m_pManagerHandler->CloseAllSocket();

						::closesocket((SOCKET)m_hListen.ToPointer());
						m_hListen = (System::IntPtr)(HANDLE)INVALID_SOCKET;

						::CloseHandle( m_hCompletionPort.ToPointer() );
						m_hCompletionPort = (System::IntPtr)INVALID_HANDLE_VALUE;

						m_IsStartServer = false;
					} while (false); //do
				}
				finally
				{
					m_Lock.Exit();
				}
			}

			bool SocketServer::Accept()
			{
				SOCKET acceptSocket									= INVALID_SOCKET;
				Demo::Mmose::Net::MessageBlock^ pMessageBlock       = nullptr;
				ServiceHandler^ pServiceHandler						= nullptr;

				bool bReturn = true;
				do
				{
					// ��ʹ��AcceptExǰ��Ҫ�����ؽ�һ���׽���������ڶ�������������Ŀ���ǽ�ʡʱ��
					// ͨ�����Դ���һ���׽��ֿ�
					acceptSocket = ::WSASocket(AF_INET, SOCK_STREAM, IPPROTO_TCP, 0, 0, WSA_FLAG_OVERLAPPED);
					if ( acceptSocket == INVALID_SOCKET )
					{
						bReturn = false;
						break;
					}

					int iBufferSize = 0;
					::setsockopt(acceptSocket, SOL_SOCKET, SO_SNDBUF, (const char*)&iBufferSize, sizeof(int));
					::setsockopt(acceptSocket, SOL_SOCKET, SO_RCVBUF, (const char*)&iBufferSize, sizeof(int));

					BOOL bNoDelay = TRUE;
					::setsockopt((SOCKET)m_hListen.ToPointer(), IPPROTO_TCP, TCP_NODELAY, (const char*)&bNoDelay, sizeof(BOOL));

					// ׼������ AcceptEx �������ú���ʹ���ص��ṹ������ɶ˿�����
					pMessageBlock = Demo::Mmose::Net::Server::MessageBlockManager->AcquireMessageBlock();
					if (pMessageBlock == nullptr)
					{
						bReturn = false;
						break;
					}
					else
					{
						MessageBlockInfo::CleanMessageBlockInfo(pMessageBlock->HeadPointer());
					}

					pServiceHandler = m_pManagerHandler->AcquireServiceHandler();
					if (pServiceHandler == nullptr)
					{
					    bReturn = false;
					    break;
					}
					else
					{
					    pServiceHandler->ClientSocket = (System::IntPtr)(HANDLE)acceptSocket;
					}

					MessageBlockInfo^ pMessageBlockInfo = MessageBlockInfo::GetMessageBlockInfo(pMessageBlock);
					if (pMessageBlockInfo == nullptr)
					{
						bReturn = false;
						break;
					}
					else
					{
						pMessageBlockInfo->m_OperatorType = TASK_WORKER_TYPE_ACCEPT;
						pMessageBlockInfo->m_TransferredNumberOfBytes = 0;
						pMessageBlockInfo->m_SendNumberOfBytes = 0;

						pMessageBlockInfo->m_pServiceHandler = pServiceHandler;
					}

					DWORD dwBytes = 0;
					LPFN_ACCEPTEX lpfnAcceptEx = (LPFN_ACCEPTEX)m_lpfnAcceptEx.ToPointer();

					// ����AcceptEx��������ַ������Ҫ��ԭ�е��������16���ֽ�
					// ע������ʹ�����ص�ģ�ͣ��ú�������ɽ�������ɶ˿ڹ����Ĺ����߳��д���
					BOOL bSuccess = lpfnAcceptEx( (SOCKET)m_hListen.ToPointer(), acceptSocket, pMessageBlock->WritePointer().ToPointer(),
						0 /* ��Ϊ�� ������ֱ�ӷ��� */ /* pMessageBloc->BufferSize() - ( ( sizeof(SOCKADDR_IN) + 16 ) *2 ) */,
						sizeof(SOCKADDR_IN) + 16, sizeof(SOCKADDR_IN) + 16, &dwBytes, (LPOVERLAPPED)pMessageBlock->HeadPointer() );
					if( bSuccess == FALSE )
					{
						if( ::WSAGetLastError() != ERROR_IO_PENDING )
						{
							bReturn = false;
							break;
						}
					}
				} while (false);

				if (bReturn == false)
				{
					if (acceptSocket != INVALID_SOCKET)
					{
					    ::closesocket(acceptSocket);
					    acceptSocket = INVALID_SOCKET;
					}

					if (pMessageBlock != nullptr)
					{
						Server::MessageBlockManager->ReleaseMessageBlock(pMessageBlock);
					    pMessageBlock = nullptr;
					}

					if (pServiceHandler != nullptr)
					{
					    m_pManagerHandler->ReleaseServiceHandler(pServiceHandler);
					    pServiceHandler = nullptr;
					}
				}

				return bReturn;
			}

		}
	}
}