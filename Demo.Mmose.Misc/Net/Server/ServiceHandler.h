#pragma once

namespace Demo
{
	namespace Mmose
	{
		namespace Net
		{

			ref class MessageBlock;
			ref class SocketServer;
			ref class ServiceHandle;
			ref class ServiceHandleManager;

			public ref class ProcessDataAtServerEventArgs : public System::EventArgs
			{
			public:
				ProcessDataAtServerEventArgs( MessageBlock^ messageBlock, ServiceHandle^ serviceHandle, ServiceHandleManager^ serviceHandleManager  )
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

			public ref class DisconnectAtServerEventArgs : public System::EventArgs
			{
			public:
				DisconnectAtServerEventArgs( ServiceHandle^ serviceHandle, ServiceHandleManager^ serviceHandleManager )
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
				property ServiceHandleManager^ DisconnectHandleManager
				{
					ServiceHandleManager^ get()
					{
						return m_ServiceHandleManager;
					}
				}
			};

			[Demo::Mmose::Core::Common::MultiThreadedSupport( "zh-CHS", "当前的类所有成员都可锁定,支持多线程操作" )]
			public ref class ServiceHandle abstract 
			{
				#pragma region zh-CHS 私有成员变量 | en Private Member Variables
			protected:
				// 是否在线
				System::Boolean m_bIsOnline;

				// 远程的端口
				System::Int32 m_RemotePort;

				// 最初登陆的时间
				System::DateTime m_FirstTime;

				// 在线时间
				System::TimeSpan m_OnlineTime;

				// 共接收到数据包的数量
				System::Int64 m_MessageBlockNumbers;

				// 30秒内收到的数据包的数量
				System::Int32 m_MessageBlockNumbers60sec;

				// 两次接收到数据的包的间隔时间的累计
				System::TimeSpan m_AddUpMessageBlockSpacingTime;

				// 最后接收到数据包的时间
				System::DateTime m_LastMessageBlockTime;

				// 两次接收到数据的包的间隔时间
				System::TimeSpan m_MessageBlockSpacingTime;

				// 远程的IP地址
				System::String^ m_RemoteIP;

				// 客户端的地址
				System::String^ m_RemoteAddress;
				#pragma endregion

				#pragma region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
			protected:
				ServiceHandle();
				#pragma endregion

				#pragma region zh-CHS 共有属性 | en Public Properties
			public:
				// 客户端是否在线
				property System::Boolean IsOnline
				{
				public:
					System::Boolean get()
					{
						return m_bIsOnline;
					}
				}

				// 远程的端口
				property System::Int32 RemotePort
				{
				public:
					System::Int32 get()
					{
						return m_RemotePort;
					}
				}

				// 客户端最初连接的时间
				property System::DateTime FirstTime
				{
				public:
					System::DateTime get()
					{
						return m_FirstTime;
					}
				}

				// 远程的IP地址
				property System::String^ RemoteOnlyIP
				{
				public:
					System::String^ get()
					{
						return m_RemoteIP;
					}
				}

				// 客户端连接的在线时间
				property System::TimeSpan OnlineTime
				{
				public:
					System::TimeSpan get()
					{
						return m_OnlineTime;
					}
				}

				// 客户端的连接过来的地址
				property System::String^ ClientAddress
				{
				public:
					System::String^ get()
					{
						return m_RemoteAddress;
					}
				}

				// 共接收到数据包消息的数量
				property System::Int64 MessageBlockNumbers
				{
				public:
					System::Int64 get()
					{
						return m_MessageBlockNumbers;
					}
				}

				// 60秒内收到的数据包的数量
				property System::Int32 MessageBlockNumbers60sec
				{
				public:
					System::Int32 get()
					{
						return m_MessageBlockNumbers60sec;
					}
				}

				// 最后接收到数据包的时间
				property System::DateTime LastMessageBlockTime
				{
				public:
					System::DateTime get()
					{
						return m_LastMessageBlockTime;
					}
				}

				// 两次数据接收到数据包的间隔时间
				property System::TimeSpan MessageBlockSpacingTime
				{
				public:
					System::TimeSpan get()
					{
						return m_MessageBlockSpacingTime;
					}
				}
				#pragma endregion

				#pragma region zh-CHS 共有方法 | en Public Methods
			public:
				// 发送数据到客户端
				virtual void SendTo(MessageBlock^ sendMessageBlock) abstract;

				// 关闭客户端
				virtual void CloseSocket() abstract;
				#pragma endregion
			};

			[Demo::Mmose::Core::Common::MultiThreadedSupport( "zh-CHS", "当前的类所有成员都可锁定,支持多线程操作" )]
			public ref class ServiceHandler : public ServiceHandle
			{
				#pragma region zh-CHS 私有成员变量 | en Private Member Variables
			private:
				// 检查句柄,防止Socket多线程出错(发送、接收、处理)
				Demo::Mmose::Core::Common::Atom::LockCheck							m_LockCheck;

			    // 接受数据的Queue列表(防止多线程中发送的顺序不同)
			    System::Threading::Collections::ConcurrentQueue<MessageBlock^>		m_SendMessageQueue;
				Demo::Mmose::Core::Common::Atom::LockInOut							m_SendLockInOut;

			    // 处理数据的Queue列表(防止多线程中处理的顺序不同)
			    System::Threading::Collections::ConcurrentQueue<MessageBlock^>		m_ProcessMessageQueue;
				Demo::Mmose::Core::Common::Atom::LockInOut							m_ProcessLockInOut;

				DelegateSendBufferStream^											m_DelegateSendBufferStream;
				DelegateProcessBufferStream^										m_DelegateProcessBufferStream;

				// 
				initonly static System::TimeSpan		s_60secTimeSpan; 
				#pragma endregion

				#pragma region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
			internal:
				ServiceHandler(SocketServer^ value);
				~ServiceHandler() { CloseSocket(); }
				!ServiceHandler() { CloseSocket(); }
			private:
				static ServiceHandler();
				#pragma endregion

				#pragma region zh-CHS 共有属性 | en Public Properties
			private:
				SocketServer^ m_pSocketServer;
			public:
				property SocketServer^ Owner
				{
					SocketServer^ get()
					{
						return m_pSocketServer;
					}
				}
				#pragma endregion

				#pragma region zh-CHS 内部属性 | en Internal Properties
			private:
				System::IntPtr m_hClientSocket;
			internal:
				property System::IntPtr ClientSocket
				{
					System::IntPtr get()
					{
						return m_hClientSocket;
					}

					void set(System::IntPtr value)
					{
						m_hClientSocket = value;
					}
				}
				#pragma endregion

				#pragma region zh-CHS 共有方法 | en Public Methods
			public:
				// ---------- ServiceHandle ----------
				virtual void SendTo(MessageBlock^ sendMessageBlock) override;
				virtual void CloseSocket() override;
				// ---------- ServiceHandle ----------
				#pragma endregion

				#pragma region zh-CHS 内部方法 | en Internal Methods
			internal:
				// ---------- IServiceHandler ----------
				void OnAccept(MessageBlock^ acceptMessageBlock);
				void OnReadStream(MessageBlock^ readMessageBlock);
				void OnWriteStream(MessageBlock^ writeMessageBlock);
				// ---------- IServiceHandler ----------

				// ---------- ITaskWorkerHandler ----------
				// 在TaskWorker(TASK_WORKER_TYPE_SEND)线程中工作(或内部调用)
				void OnSendBufferStream(MessageBlock^ sendMessageBlock);
				// 在TaskWorker(TASK_WORKER_TYPE_PROCSS)线程中工作(或内部调用)
				void OnProcessBufferStream(MessageBlock^ processMessageBlock);
				// ---------- ITaskWorkerHandler ----------

				void InitReceiveBufferStream(MessageBlock^ receiveMessageBlock);

				void PostSendStream(MessageBlockInfo^ sendMessageBlockInfo);
				void PostProcessStream(MessageBlockInfo^ processMessageBlockInfo);

				// 初始化ServiceHandle数据
				void InitServiceHandle();

				// 释放ServiceHandle
				void FiniClientHandler(void);

				// 关闭句柄,防止Scoket多线程出错(发送、接收、处理)
				void InvalidHandle();

				// 计算ServiceHandle数据,防止Socket多线程出错(发送、接收、处理)
				void CalcClientHandler(void);

				// 释放自我
				void FreeThis(void);
				#pragma endregion

				#pragma region zh-CHS 共有事件 | en Public Event
			private:
				System::EventHandler<ProcessDataAtServerEventArgs^>^ m_EventProcessData;
				System::Threading::SpinLock m_LockProcessData;
			public:
				event System::EventHandler<ProcessDataAtServerEventArgs^>^ EventProcessData
				{
					void add(System::EventHandler<ProcessDataAtServerEventArgs^>^ value)
					{
						m_LockProcessData.Enter();
						{
							m_EventProcessData += value;
						}
						m_LockProcessData.Exit();
					}

					void remove(System::EventHandler<ProcessDataAtServerEventArgs^>^ value)
					{
						m_LockProcessData.Enter();
						{
							m_EventProcessData -= value;
						}
						m_LockProcessData.Exit();
					}
				}

			private:
				System::EventHandler<DisconnectAtServerEventArgs^>^ m_EventDisconnect;
				System::Threading::SpinLock m_LockDisconnect;
			public:
				event System::EventHandler<DisconnectAtServerEventArgs^>^ EventDisconnect
				{
					void add(System::EventHandler<DisconnectAtServerEventArgs^>^ value)
					{
						m_LockDisconnect.Enter();
						{
							m_EventDisconnect += value;
						}
						m_LockDisconnect.Exit();
					}

					void remove(System::EventHandler<DisconnectAtServerEventArgs^>^ value)
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
