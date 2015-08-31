#include "StdAfx.h"
#include "ClientInc.h"
#include "SocketClient.h"

namespace Demo
{
	namespace Mmose
	{
		namespace Net
		{
			static SocketClient::SocketClient()
			{
				m_NumberThread = 0;
			}

			SocketClient::SocketClient () : m_IsStartClient(false)
				, m_Connect((System::IntPtr)(HANDLE)INVALID_SOCKET)
				, m_hCompletionPort((System::IntPtr)INVALID_HANDLE_VALUE)
			{
				m_ConnectHandler = gcnew Demo::Mmose::Net::ConnectHandler(this);
				m_ConnectHandlerManager = gcnew Demo::Mmose::Net::ConnectHandlerManager(this);

				// ���Լ���ӵ�ȫ�ֵ��б���
				Client::AddNewInstance(this);
			}

			void SocketClient::ThreadPoolFunction()
			{
				HANDLE hCompletionPort = (HANDLE)m_hCompletionPort.ToPointer();
				if (hCompletionPort == 0 || hCompletionPort == INVALID_HANDLE_VALUE)
					throw gcnew System::Exception("SocketClient::ServerThread(...) - hCompletionPort == 0 || hCompletionPort == INVALID_HANDLE_VALUE error\n");

				// ��ʼ�߳�
				bool bIsThreadTerminate = false;

				//����ѭ���ĵȴ��ص����������
				while(true)
				{
					// �µĳ�ʼ��
					DWORD iTransferredBytes = 0;
					ULONG iCompletionKey = 0;
					LPOVERLAPPED* lpOverlapped = NULL;

					INT iReturn = ::GetQueuedCompletionStatus(
						hCompletionPort,                    // ԭ�ȵ���ɶ˿ھ��
						&iTransferredBytes,                 // �ص�������ɵ��ֽ���
						reinterpret_cast<PULONG_PTR>(&iCompletionKey),                    // ԭ�Ⱥ���ɶ˿ھ����������������
						(LPOVERLAPPED*)&lpOverlapped,		// ���ڽ�������ɵ�IO�������ص��ṹ
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
							// �����ӵľ���Ѿ��ر� �򷵻�ERROR_OPERATION_ABORTED
							break;
						}
					}

					if (lpOverlapped == NULL)
						throw gcnew System::Exception("SocketClient::ServerThread(...) - lpOverlapped == NULL error\n");

					MessageBlockInfo^ pMessageBlockInfo = MessageBlockInfo::GetMessageBlockInfo(lpOverlapped); 
					if ( pMessageBlockInfo == nullptr)
						throw gcnew System::Exception("SocketClient::ServerThread(...) - pMessageBlockInfo == nullptr error\n");

					MessageBlock^ pMessageBlock = pMessageBlockInfo->MessageBlock;
					if ( pMessageBlock == nullptr)
						throw gcnew System::Exception("SocketClient::ServerThread(...) - pMessageBlock == nullptr error\n");

					switch(pMessageBlockInfo->m_OperatorType)
					{
					case TASK_WORKER_TYPE_SEND: // �������ݳɹ���ķ���
						{
							bool bReturn = true;
							do
							{
								SOCKET connectSocket = (SOCKET)m_Connect.ToPointer();
								if ( connectSocket == INVALID_SOCKET )
								{
									bReturn = false;
									break;
								}

								// �ѽ��յ������ݴ�С
								pMessageBlockInfo->m_TransferredNumberOfBytes = iTransferredBytes;
								// ֪ͨ���µ������յ�
								m_ConnectHandler->OnWriteStream(pMessageBlock);
							} while (false);

							if ( bReturn == false )
								Client::MessageBlockManager->ReleaseMessageBlock(pMessageBlock);
						}

						break;
					case TASK_WORKER_TYPE_RECEIVE: // �������ݳɹ���ķ���
						{
							bool bReturn = true;
							do
							{
								SOCKET connectSocket = (SOCKET)m_Connect.ToPointer();
								if ( connectSocket == INVALID_SOCKET )
								{
									bReturn = false;
									break;
								}

								if ( iTransferredBytes <= 0 )
								{
									// ������ܵ�������С�ڵ����� ��Socket�ѹرյ�IOCP�ź�
									bIsThreadTerminate = true;

									bReturn = false;
									break;
								}

								// �ѽ��յ������ݴ�С
								pMessageBlockInfo->m_TransferredNumberOfBytes = iTransferredBytes;
								// ֪ͨ���µ������յ�
								m_ConnectHandler->OnReadStream(pMessageBlock);
							} while (false);

							if ( bReturn == false )
								Client::MessageBlockManager->ReleaseMessageBlock(pMessageBlock);
						}

						break;
					case TASK_WORKER_TYPE_PROCSS: // ������������������ (TASK_WORKER_TYPE_PROCSS ��TaskWorker�д���)
						Client::MessageBlockManager->ReleaseMessageBlock(pMessageBlock);

						throw gcnew System::Exception("SocketClient::ServerThread(...) - pMessageBlockInfo->m_OperatorType == TASK_WORKER_TYPE_PROCSS error\n");
					case TASK_WORKER_TYPE_NONE:  // ������������������ (TASK_WORKER_TYPE_NONE �޴���)
						Client::MessageBlockManager->ReleaseMessageBlock(pMessageBlock);

						throw gcnew System::Exception("SocketClient::ServerThread(...) - pMessageBlockInfo->m_OperatorType == TASK_WORKER_TYPE_NONE error\n");
					case TASK_WORKER_TYPE_ACCEPT: // ������������������ (TASK_WORKER_TYPE_ACCEPT �޴���)
						Client::MessageBlockManager->ReleaseMessageBlock(pMessageBlock);

						throw gcnew System::Exception("SocketClient::ServerThread(...) - pMessageBlockInfo->m_OperatorType == TASK_WORKER_TYPE_ACCEPT error\n");
					default: // ��������
						Client::MessageBlockManager->ReleaseMessageBlock(pMessageBlock);

						throw gcnew System::Exception("SocketClient::ServerThread(...) - pMessageBlockInfo->m_OperatorType == default(...) error\n");
					}

					if ( bIsThreadTerminate == true )
						break;
				}

				// �����߳�
			}

			bool SocketClient::StartConnectServer(System::String^ strHostNamePort)
			{
				// �����û�г�ʼ��
				if ( Client::IsInit == false )
					throw gcnew System::Exception("SocketClient::StartConnectServer(...) - Client::IsInit == false error\n");

				if ( m_IsStartClient == true )
					return false;

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

				// ��ȡ��ַ
				SOCKADDR_IN ServiceAddr;
				ServiceAddr.sin_family = AF_INET;
				ServiceAddr.sin_port = ::htons( (u_short)iPort );

				if (strHost == System::String::Empty)
					ServiceAddr.sin_addr.s_addr = ::htonl(INADDR_ANY);
				else
				{
					System::IntPtr ptrHost = System::Runtime::InteropServices::Marshal::StringToHGlobalAnsi(strHost);
					const char* charHost = static_cast<const char*>(ptrHost.ToPointer());

					ServiceAddr.sin_addr.s_addr = ::inet_addr( charHost );

					System::Runtime::InteropServices::Marshal::FreeHGlobal( ptrHost );
				}

				// �����Ǹ������ӵĶ˿ں͵�ַ

				bool bReturn = true;
				m_Lock.Enter();
				try
				{
					do
					{
						if ( m_IsStartClient == true )
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
						for( INT iIndex = 0; iIndex < Client::s_ClientReceiveThreadPoolSize; iIndex++ )
						{
							System::Threading::Thread^ iocpThread = gcnew System::Threading::Thread( gcnew System::Threading::ThreadStart( this, &Demo::Mmose::Net::SocketClient::ThreadPoolFunction ) );
							iocpThread->Name = "Socket Client Receive Thread-" + System::Threading::Interlocked::Increment(m_NumberThread).ToString();
							iocpThread->IsBackground = true;
							iocpThread->Start();
						}

						// ����һ���������׽���(�����ص�����)
						m_Connect = (System::IntPtr)(HANDLE)::WSASocket( AF_INET, SOCK_STREAM, 0, NULL, 0, WSA_FLAG_OVERLAPPED );
						if ( m_Connect == (System::IntPtr)(HANDLE)INVALID_SOCKET )
						{
							bReturn = false;
							break;
						}

						HANDLE hCompletionPort = ::CreateIoCompletionPort((HANDLE)m_Connect.ToPointer(), m_hCompletionPort.ToPointer(), NULL, 0);
						if ( hCompletionPort == NULL )
						{
							bReturn = false;
							break;
						}

						if ( ::connect( (SOCKET)m_Connect.ToPointer(), (PSOCKADDR)&ServiceAddr, sizeof(SOCKADDR_IN) ) == SOCKET_ERROR )
						{
							bReturn = false;
							break;
						}

						// ��ʼ��ConnectHandler
						m_ConnectHandler->InitClientHandler();

						System::Text::StringBuilder^ strSockAddress = gcnew System::Text::StringBuilder();
						strSockAddress->Append(strHost);
						strSockAddress->Append(":");
						strSockAddress->Append(iPort.ToString());

						m_pSockAddress = strSockAddress->ToString();

						m_IsStartClient = true;
					} while (false); // do
				}
				finally
				{
					m_Lock.Exit();

					if ( bReturn == false )
					{
						if (m_Connect != (System::IntPtr)(HANDLE)INVALID_SOCKET)
						{
							::closesocket((SOCKET)m_Connect.ToPointer());
							m_Connect = (System::IntPtr)(HANDLE)INVALID_SOCKET;
						}

						if (m_hCompletionPort != (System::IntPtr)INVALID_HANDLE_VALUE)
						{
							::CloseHandle( m_hCompletionPort.ToPointer() );
							m_hCompletionPort = (System::IntPtr)INVALID_HANDLE_VALUE;
						}
					}
				}

				return bReturn;
			}

			void SocketClient::StopConnect(void)
			{
				if ( m_IsStartClient == false )
					return;

				m_Lock.Enter();
				try
				{
					do
					{
						if ( m_IsStartClient == false )
							break;

						::closesocket((SOCKET)m_Connect.ToPointer());
						m_Connect = (System::IntPtr)(HANDLE)INVALID_SOCKET;

						::CloseHandle( m_hCompletionPort.ToPointer() );
						m_hCompletionPort = (System::IntPtr)INVALID_HANDLE_VALUE;

						m_IsStartClient = false;
					} while (false); //do
				}
				finally
				{
					m_Lock.Exit();
				}
			}

			void SocketClient::SendBuffer(MessageBlock^ sendMessageBlock)
			{
				m_ConnectHandler->SendTo(sendMessageBlock);
			}
		}
	}
}