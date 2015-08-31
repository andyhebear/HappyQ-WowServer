#pragma once

namespace Demo
{
	namespace Mmose
	{
		namespace Net
		{

			ref class MessageBlock;
			ref class ServiceHandle;
			ref class ServiceHandler;
			ref class ServiceHandleManager;

			public ref class GlobalProcessDataAtServerEventArgs : public System::EventArgs
			{
			public:
				GlobalProcessDataAtServerEventArgs( MessageBlock^ messageBlock, ServiceHandle^ serviceHandle, ServiceHandleManager^ serviceHandleManager )
				{
					m_MessageBlock = messageBlock;
					m_ServiceHandle = serviceHandle;
					m_ServiceHandleManager = serviceHandleManager;
				}

			private:
				MessageBlock^ m_MessageBlock;
			public:
				property MessageBlock^ ProcessData
				{
					MessageBlock^ get()
					{
						return m_MessageBlock;
					}
				}

			private:
				ServiceHandle^ m_ServiceHandle;
			public:
				property ServiceHandle^ ProcessHandle
				{
					ServiceHandle^ get()
					{
						return m_ServiceHandle;
					}
				}

			private:
				ServiceHandleManager^ m_ServiceHandleManager;
			public:
				property ServiceHandleManager^ AcceptorHandleManager
				{
					ServiceHandleManager^ get()
					{
						return m_ServiceHandleManager;
					}
				}
			};

			public ref class GlobalDisconnectAtServerEventArgs : public System::EventArgs
			{
			public:
				GlobalDisconnectAtServerEventArgs( ServiceHandle^ serviceHandle, ServiceHandleManager^ serviceHandleManager )
				{
					m_ServiceHandle = serviceHandle;
					m_ServiceHandleManager = serviceHandleManager;
				}

			private:
				ServiceHandle^ m_ServiceHandle;
			public:
				property ServiceHandle^ DisconnectHandle
				{
					ServiceHandle^ get()
					{
						return m_ServiceHandle;
					}
				}

			private:
				ServiceHandleManager^ m_ServiceHandleManager;
			public:
				property ServiceHandleManager^ AcceptorHandleManager
				{
					ServiceHandleManager^ get()
					{
						return m_ServiceHandleManager;
					}
				}
			};

			public ref class AcceptorEventArgs : public System::EventArgs
			{
			public:
				AcceptorEventArgs( ServiceHandler^ serviceHandler, ServiceHandleManager^ serviceHandleManager )
				{
					m_ServiceHandler = serviceHandler;
					m_ServiceHandleManager = serviceHandleManager;
				}

			private:
				ServiceHandler^ m_ServiceHandler;
			public:
				property ServiceHandler^ AcceptorHandle
				{
					ServiceHandler^ get()
					{
						return m_ServiceHandler;
					}
				}

			private:
				ServiceHandleManager^ m_ServiceHandleManager;
			public:
				property ServiceHandleManager^ AcceptorHandleManager
				{
					ServiceHandleManager^ get()
					{
						return m_ServiceHandleManager;
					}
				}
			};

			[Demo::Mmose::Core::Common::MultiThreadedSupport( "zh-CHS", "当前的类所有成员都可锁定,支持多线程操作" )]
			public ref class SocketServer
			{
				#pragma region zh-CHS 私有静态成员变量 | en Private Static Member Variables
			private:
				static System::Int32			m_NumberThread;
				#pragma endregion

				#pragma region zh-CHS 私有成员变量 | en Private Member Variables
			private:
				System::IntPtr                  m_hCompletionPort;

				System::IntPtr                  m_lpfnAcceptEx;		//AcceptEx函数指针

				System::Threading::SpinLock		m_Lock;
				#pragma endregion

				#pragma region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
			internal:
				static SocketServer();

			public:
				SocketServer ();
				~SocketServer () { StopServer(); }
				!SocketServer () { StopServer(); }
				#pragma endregion

				#pragma region zh-CHS 共有属性 | en Public Properties
			private:
				// 网络是否已经连接
				// 服务是否开启
				System::Boolean m_IsStartServer;
			public:
				property System::Boolean IsListened
				{
					System::Boolean get()
					{
						return m_IsStartServer;
					}
				}

			private:
				// 网络是否已经连接
				// 服务的地址
				System::String^ m_pSockAddress;
			public:
				property System::String^ ListenAddress
				{
					System::String^ get()
					{
						return m_pSockAddress;
					}
				}

			private:
				// 服务端所有连接的客户句柄
				// 所有连接的客户群的管理
				Demo::Mmose::Net::ServiceHandleManager^ m_pManagerHandler;
			public:
				property Demo::Mmose::Net::ServiceHandleManager^ ServiceHandleManager
				{
					Demo::Mmose::Net::ServiceHandleManager^ get()
					{
						return m_pManagerHandler;
					}
				}

			private:
				// 初始化最多的连接数(如果不初始化,就用全局的最多连接数)(SocketServer 调用)
				// 最大的连接数
				System::UInt32 m_iMaxClients;
			public:
				property System::UInt32 MaxClients
				{
					System::UInt32 get()
					{
						return m_iMaxClients;
					}

					void set(System::UInt32 value)
					{
						m_iMaxClients = value;
					}
				}
				#pragma endregion

				#pragma region zh-CHS 内部属性 | en Internal Properties
			private:
				// 当前监听的SOCKET句柄
				System::IntPtr m_hListen;
			internal:
				property System::IntPtr ListenSocket
				{
					System::IntPtr get()
					{
						return m_hListen;
					}
				};
				#pragma endregion

				#pragma region zh-CHS 共有方法 | en Public Methods
			public:
				// 开始服务(地址和端口)
				bool StartServer(System::String^ strHostNamePort);

				// 开始服务(端口)
				bool StartServer(System::UInt32 iPort) { return StartServer(nullptr, iPort); }

				// 停止服务
				void StopServer( void );
				#pragma endregion

				#pragma region zh-CHS 私有方法 | en Private Methods
			private:
				// 开始服务(地址和端口)
				bool StartServer(System::String^ strHost, System::UInt32 iPort);

				// 开始Accept监听
				bool Accept();

				// 主处理服务
				void ThreadPoolFunction();
				#pragma endregion

				#pragma region zh-CHS 共有事件 | en Public Event
			internal:
				// 设置当前处理数据包的回调函数
				System::EventHandler<GlobalProcessDataAtServerEventArgs^>^ m_EventProcessGlobalMessageBlock;
			private:
				System::Threading::SpinLock m_LockProcessGlobalMessageBlock;
			public:
				event System::EventHandler<GlobalProcessDataAtServerEventArgs^>^ EventProcessGlobalData
				{
					void add(System::EventHandler<GlobalProcessDataAtServerEventArgs^>^ value)
					{
						m_LockProcessGlobalMessageBlock.Enter();
						{
							m_EventProcessGlobalMessageBlock += value;
						}
						m_LockProcessGlobalMessageBlock.Exit();
					}

					void remove(System::EventHandler<GlobalProcessDataAtServerEventArgs^>^ value)
					{
						m_LockProcessGlobalMessageBlock.Enter();
						{
							m_EventProcessGlobalMessageBlock -= value;
						}
						m_LockProcessGlobalMessageBlock.Exit();
					}
				}

			internal:
				System::EventHandler<GlobalDisconnectAtServerEventArgs^>^ m_EventGlobalDisconnect;
			private:
				System::Threading::SpinLock m_LockGlobalDisconnect;
			public:
				event System::EventHandler<GlobalDisconnectAtServerEventArgs^>^ EventGlobalDisconnect
				{
					void add(System::EventHandler<GlobalDisconnectAtServerEventArgs^>^ value)
					{
						m_LockGlobalDisconnect.Enter();
						{
							m_EventGlobalDisconnect += value;
						}
						m_LockGlobalDisconnect.Exit();
					}

					void remove(System::EventHandler<GlobalDisconnectAtServerEventArgs^>^ value)
					{
						m_LockGlobalDisconnect.Enter();
						{
							m_EventGlobalDisconnect -= value;
						}
						m_LockGlobalDisconnect.Exit();
					}
				}

			internal:
				// 设置当前接收处理的回调函数
				System::EventHandler<AcceptorEventArgs^>^ m_EventAcceptor;
			private:
				System::Threading::SpinLock m_LockAcceptor;
			public:
				event System::EventHandler<AcceptorEventArgs^>^ EventAcceptor
				{
					void add(System::EventHandler<AcceptorEventArgs^>^ value)
					{
						m_LockAcceptor.Enter();
						{
							m_EventAcceptor += value;
						}
						m_LockAcceptor.Exit();
					}

					void remove(System::EventHandler<AcceptorEventArgs^>^ value)
					{
						m_LockAcceptor.Enter();
						{
							m_EventAcceptor -= value;
						}
						m_LockAcceptor.Exit();
					}
				}
				#pragma endregion
			};

		}
	}
}