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

				// 把自己添加到全局的列表中
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

				// 以上是给出监听的端口和地址
				return StartServer( strHost, iPort );
			}

			void SocketServer::ThreadPoolFunction()
			{
				if (m_hCompletionPort.ToPointer() == 0 || m_hCompletionPort.ToPointer() == INVALID_HANDLE_VALUE)
					throw gcnew System::Exception("SocketServer::ServerThread(...) - m_hCompletionPort == 0 || m_hCompletionPort == INVALID_HANDLE_VALUE error\n");

				// 开始线程

				//进入循环的等待重叠操作的完成
				while(true)
				{
					// 新的初始化
					DWORD iTransferredBytes = 0;
					ULONG iCompletionKey = 0;
					LPOVERLAPPED* lpOverlapped = NULL;

					INT iReturn = ::GetQueuedCompletionStatus(
						m_hCompletionPort.ToPointer(),		// 原先的完成端口句柄
						&iTransferredBytes,                 // 重叠操作完成的字节数
						reinterpret_cast<PULONG_PTR>(&iCompletionKey),		// 原先和完成端口句柄关联起来的数据(没使用)
						(LPOVERLAPPED*)&lpOverlapped,		// 用于接收已完成的IO操作的重叠结构(就是位于MessageBlock尾部的MessageBlockInfo结构)
						INFINITE);                          // 在完成端口上等待的时间 INFINITE 为无限等待

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
							// 当监听的句柄已经关闭 则返回ERROR_OPERATION_ABORTED
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
					case TASK_WORKER_TYPE_ACCEPT: // ACCEPT成功后的返回
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
									// 监听的套接字已经断开
									bReturn = false;
									break;
								}

								// 
								if( ::setsockopt( clientSocket, SOL_SOCKET, SO_UPDATE_ACCEPT_CONTEXT, (const char*)&listenSocket, sizeof( SOCKET ) ) == SOCKET_ERROR )
								{
									// 可能监听的套接字已经断开
									bReturn = false;
									break;
								}

								// 将新的客户套接字与完成端口连接
								if ( ::CreateIoCompletionPort( (HANDLE)clientSocket, m_hCompletionPort.ToPointer(), NULL, 0 ) == NULL )
								{
									bReturn = false;
									break;
								}

								// 创建一个新的Accept
								if ( this->Accept() == false )
								{
									// 可能连接数已满(已改)
									//System::Diagnostics::Debug::WriteLine("SocketServer::ServerThread(.TASK_WORKER_TYPE_ACCEPT.) - pAcceptHandler->Accept() == false warning(可能连接数已满)\n");
								}

								// 接收到的数据大小
								pMessageBlockInfo->m_TransferredNumberOfBytes = iTransferredBytes;
								// 通知有新的产生Accept产生
								pServiceHandler->OnAccept(pMessageBlock);
							} while (false); // do

							if ( bReturn == false )
								Server::MessageBlockManager->ReleaseMessageBlock(pMessageBlock);
						}

						break;
					case TASK_WORKER_TYPE_SEND: // 发送数据成功后的返回
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

								// 已发送出去的数据大小
								pMessageBlockInfo->m_TransferredNumberOfBytes = iTransferredBytes;
								// 通知已发送出去数据
								pServiceHandler->OnWriteStream(pMessageBlock);
							} while (false);

							if ( bReturn == false )
								Server::MessageBlockManager->ReleaseMessageBlock(pMessageBlock);
						}
						break;
					case TASK_WORKER_TYPE_RECEIVE: // 接受数据成功后的返回
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

								// 已接收到的数据大小
								pMessageBlockInfo->m_TransferredNumberOfBytes = iTransferredBytes;
								// 通知有新的数据收到
								pServiceHandler->OnReadStream(pMessageBlock);
							} while (false);

							if ( bReturn == false )
								Server::MessageBlockManager->ReleaseMessageBlock(pMessageBlock);
						}

						break;
					case TASK_WORKER_TYPE_PROCSS: // 不可能有这样的数据 (TASK_WORKER_TYPE_PROCSS 在TaskWorker中处理)
						Server::MessageBlockManager->ReleaseMessageBlock(pMessageBlock);

						throw gcnew System::Exception("SocketServer::ServerThread(...) - pMessageBlockInfo->m_OperatorType == TASK_WORKER_TYPE_PROCSS error\n");
					case TASK_WORKER_TYPE_NONE: // 不可能有这样的数据 (TASK_WORKER_TYPE_NONE 无处理)
						Server::MessageBlockManager->ReleaseMessageBlock(pMessageBlock);

						throw gcnew System::Exception("SocketServer::ServerThread(...) - pMessageBlockInfo->m_OperatorType == TASK_WORKER_TYPE_NONE error\n");
					default: // 出错啦！
						Server::MessageBlockManager->ReleaseMessageBlock(pMessageBlock);

						throw gcnew System::Exception("SocketServer::ServerThread(...) - pMessageBlockInfo->m_OperatorType == default(...) error\n");
					}
				}

				// 结束线程
			}

			bool SocketServer::StartServer( System::String^ strHost, System::UInt32 iPort )
			{
				// 检查有没有初始化
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

						// 创建一个IO完成端口
						m_hCompletionPort = (System::IntPtr)::CreateIoCompletionPort(INVALID_HANDLE_VALUE, NULL, 0, 0);
						if ( m_hCompletionPort == System::IntPtr::Zero )
						{
							bReturn = false;
							break;
						}

						// 根据处理器的数量创建相应多的处理线程
						for( INT iIndex = 0; iIndex < Demo::Mmose::Net::Server::s_ServerReceiveThreadPoolSize; iIndex++ )
						{
							System::Threading::Thread^ iocpThread = gcnew System::Threading::Thread( gcnew System::Threading::ThreadStart( this, &Demo::Mmose::Net::SocketServer::ThreadPoolFunction ) );
							iocpThread->Name = "Socket Server Receive Thread-" + System::Threading::Interlocked::Increment(m_NumberThread).ToString();
							iocpThread->IsBackground = true;
							iocpThread->Start();
						}

						// 创建一个监听套接字(进行重叠操作)
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

						if ( ::listen( (SOCKET)m_hListen.ToPointer(), 5/*5个同时连接*/ ) == SOCKET_ERROR )
						{
							bReturn = false;
							break;
						}

						//Accept function GUID
						GUID guidAcceptEx = WSAID_ACCEPTEX;

						//get acceptex function pointer
						DWORD dwBytes = 0;

						LPFN_ACCEPTEX lpfnAcceptEx; //AcceptEx函数指针
						if( ::WSAIoctl( (SOCKET)m_hListen.ToPointer(), SIO_GET_EXTENSION_FUNCTION_POINTER, &guidAcceptEx, sizeof(guidAcceptEx), &lpfnAcceptEx, sizeof(m_lpfnAcceptEx), &dwBytes, NULL, NULL ) == SOCKET_ERROR )
						{
							bReturn = false;
							break;
						}
						else
						{
							m_lpfnAcceptEx = (System::IntPtr)((void*)lpfnAcceptEx);
						}

						for (int iIndex = 0; iIndex < 5/*5个同时连接*/; iIndex++)
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
						// 关闭全部在线的Socket, 可能已经有监听的Socket了
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

						// 关闭全部在线的Socket
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
					// 在使用AcceptEx前需要事先重建一个套接字用于其第二个参数。这样目的是节省时间
					// 通常可以创建一个套接字库
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

					// 准备调用 AcceptEx 函数，该函数使用重叠结构并于完成端口连接
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

					// 调用AcceptEx函数，地址长度需要在原有的上面加上16个字节
					// 注意这里使用了重叠模型，该函数的完成将在与完成端口关联的工作线程中处理
					BOOL bSuccess = lpfnAcceptEx( (SOCKET)m_hListen.ToPointer(), acceptSocket, pMessageBlock->WritePointer().ToPointer(),
						0 /* 需为零 有连接直接返回 */ /* pMessageBloc->BufferSize() - ( ( sizeof(SOCKADDR_IN) + 16 ) *2 ) */,
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