#pragma once

namespace Demo
{
	namespace Mmose
	{
		namespace Net
		{

			ref class ConnectHandler;
			ref class ConnectHandlerManager;

			public ref class ProcessDataAtClientEventArgs : public System::EventArgs
			{
			public:
				ProcessDataAtClientEventArgs( MessageBlock^ messageBlock, ConnectHandle^ connectHandle, ConnectHandlerManager^ connectHandlerManager )
				{
					m_MessageBlock = messageBlock;
					m_ConnectHandle = connectHandle;
					m_ConnectHandlerManager = connectHandlerManager;
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
				ConnectHandle^ m_ConnectHandle;
			public:
				property ConnectHandle^ ProcessHandle
				{
					ConnectHandle^ get()
					{
						return m_ConnectHandle;
					}
				}

			private:
				ConnectHandlerManager^ m_ConnectHandlerManager;
			public:
				property ConnectHandlerManager^ DisconnectHandlerManager
				{
					ConnectHandlerManager^ get()
					{
						return m_ConnectHandlerManager;
					}
				}
			};

			public ref class DisconnectAtClientEventArgs : public System::EventArgs
			{
			public:
				DisconnectAtClientEventArgs( ConnectHandle^ connectHandle, ConnectHandlerManager^ connectHandlerManager )
				{
					m_ConnectHandle = connectHandle;
					m_ConnectHandlerManager = connectHandlerManager;
				}

			private:
				ConnectHandle^ m_ConnectHandle;
			public:
				property ConnectHandle^ DisconnectHandle
				{
					ConnectHandle^ get()
					{
						return m_ConnectHandle;
					}
				}

			private:
				ConnectHandlerManager^ m_ConnectHandlerManager;
			public:
				property ConnectHandlerManager^ DisconnectHandlerManager
				{
					ConnectHandlerManager^ get()
					{
						return m_ConnectHandlerManager;
					}
				}
			};

			[Demo::Mmose::Core::Common::MultiThreadedSupport( "zh-CHS", "当前的类所有成员都可锁定,支持多线程操作" )]
			public ref class SocketClient
			{
				#pragma region zh-CHS 私有静态成员变量 | en Private Static Member Variables
			private:
				static System::Int32			m_NumberThread;
				#pragma endregion

				#pragma region zh-CHS 私有成员变量 | en Private Member Variables
			private:
				System::IntPtr					m_hCompletionPort;

				System::Threading::SpinLock		m_Lock;
				#pragma endregion

				#pragma region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
			internal:
				static SocketClient();

			public:
				SocketClient();
				~SocketClient() { StopConnect(); }
				!SocketClient() { StopConnect(); }
				#pragma endregion

				#pragma region zh-CHS 共有属性 | en Public Properties
			private:
				// 当前是否已连接服务
				System::Boolean m_IsStartClient;
			public:
				property System::Boolean IsConnected
				{
					System::Boolean get()
					{
						return m_IsStartClient;
					}
				}

			private:
				// 网络是否已经连接
				// 服务的地址
				System::String^ m_pSockAddress;
			public:
				property System::String^ ConnectAddress
				{
					System::String^ get()
					{
						return m_pSockAddress;
					}
				}

			private:
				// 客户端连接服务端的句柄操作
				Demo::Mmose::Net::ConnectHandlerManager^ m_ConnectHandlerManager;
			public:
				property Demo::Mmose::Net::ConnectHandlerManager^ ConnectHandlerManager
				{
					Demo::Mmose::Net::ConnectHandlerManager^ get()
					{
						return m_ConnectHandlerManager;
					}
				}
				#pragma endregion

				#pragma region zh-CHS 内部属性 | en Internal Properties
			private:
				// 当前监听的SOCKET句柄
				System::IntPtr m_Connect;
			internal:
				property System::IntPtr ConnectSocket
				{
					System::IntPtr get()
					{
						return m_Connect;
					}
				};

			private:
				Demo::Mmose::Net::ConnectHandler^ m_ConnectHandler;
			internal:
				property Demo::Mmose::Net::ConnectHandler^ ConnectHandler
				{
					Demo::Mmose::Net::ConnectHandler^ get()
					{
						return m_ConnectHandler;
					}
				};
				#pragma endregion

				#pragma region zh-CHS 共有方法 | en Public Methods
			public:
				bool StartConnectServer(System::String^ strHostNamePort);
				void StopConnect(void);
				void SendBuffer(MessageBlock^ sendMessageBlock);
				#pragma endregion

				#pragma region zh-CHS 私有方法 | en Private Methods
			private:
				void ThreadPoolFunction();
				#pragma endregion

				#pragma region zh-CHS 共有事件 | en Public Event
			internal:
				// 设置或返回当前处理数据包的回调函数
				System::EventHandler<ProcessDataAtClientEventArgs^>^ m_EventProcessMessageBlock;
			private:
				System::Threading::SpinLock m_LockProcessMessageBlock;
			public:
				event System::EventHandler<ProcessDataAtClientEventArgs^>^ EventProcessData
				{
					void add(System::EventHandler<ProcessDataAtClientEventArgs^>^ value)
					{
						m_LockProcessMessageBlock.Enter();
						{
							m_EventProcessMessageBlock += value;
						}
						m_LockProcessMessageBlock.Exit();
					}

					void remove(System::EventHandler<ProcessDataAtClientEventArgs^>^ value)
					{
						m_LockProcessMessageBlock.Enter();
						{
							m_EventProcessMessageBlock -= value;
						}
						m_LockProcessMessageBlock.Exit();
					}
				}

			internal:
				// 设置或返回当前处理数据包的回调函数
				System::EventHandler<DisconnectAtClientEventArgs^>^ m_EventDisconnect;
			private:
				System::Threading::SpinLock m_LockDisconnect;
			public:
				event System::EventHandler<DisconnectAtClientEventArgs^>^ EventDisconnect
				{
					void add(System::EventHandler<DisconnectAtClientEventArgs^>^ value)
					{
						m_LockDisconnect.Enter();
						{
							m_EventDisconnect += value;
						}
						m_LockDisconnect.Exit();
					}

					void remove(System::EventHandler<DisconnectAtClientEventArgs^>^ value)
					{
						m_LockDisconnect.Enter();
						{
							m_EventDisconnect -= value;
						}
						m_LockDisconnect.Exit();
					}
				}
				#pragma endregion
			};

		}
	}
}