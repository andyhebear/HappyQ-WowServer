#pragma once

namespace Demo
{
	namespace Mmose
	{
		namespace Net
		{

			ref class SocketClient;
			ref class ConnectHandlerManager;

			[Demo::Mmose::Core::Common::MultiThreadedSupport( "zh-CHS", "当前的类所有成员都可锁定,支持多线程操作" )]
			public ref class ConnectHandle abstract
			{
				#pragma region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
			protected:
				ConnectHandle();
				#pragma endregion

				#pragma region zh-CHS 共有属性 | en Public Properties
			public:
				// 客户端是否在线
				property System::Boolean IsOnline
				{
					System::Boolean get()
					{
						return m_bIsOnline;
					}
				}

				// 远程的端口
				property System::Int32 RemotePort
				{
					System::Int32 get()
					{
						return m_RemotePort;
					}
				}

				// 最初连接服务端的时间
				property System::DateTime FirstTime
				{
					System::DateTime get()
					{
						return m_FirstTime;
					}
				}

				// 远程的IP地址
				property System::String^ RemoteOnlyIP
				{
					System::String^ get()
					{
						return m_RemoteIP;
					}
				}

				// 连接服务端的在线时间
				property System::TimeSpan OnlineTime
				{
					System::TimeSpan get()
					{
						return m_OnlineTime;
					}
				}

				// 服务端的连接地址
				property System::String^ ServerAddress
				{
					System::String^ get()
					{
						return m_RemoteAddress; 
					}
				}

				// 共接收到数据包消息的数量
				property System::Int64 MessageBlockNumbers
				{
					System::Int64 get()
					{
						return m_MessageBlockNumbers;
					}
				}

				// 60秒内收到的数据包的数量
				property System::Int32 MessageBlockNumbers60sec
				{
					System::Int32 get()
					{
						return m_MessageBlockNumbers60sec;
					}
				}

				// 最后接收到数据包的时间
				property System::DateTime LastMessageBlockTime
				{
					System::DateTime get()
					{
						return m_LastMessageBlockTime;
					}
				}

				// 两次数据接收到数据包的间隔时间
				property System::TimeSpan MessageBlockSpacingTime
				{
					System::TimeSpan get()
					{
						return m_MessageBlockSpacingTime;
					}
				}
				#pragma endregion

				#pragma region zh-CHS 共有方法 | en Public Methods
			public:
				// 发送数据到客户端
				virtual void SendTo(MessageBlock^ sendMessageBlock) = 0;

				// 关闭客户端
				virtual void CloseSocket() = 0;
				#pragma endregion

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

				// 服务端的地址
				System::String^ m_RemoteAddress;
				#pragma endregion
			};

			[Demo::Mmose::Core::Common::MultiThreadedSupport( "zh-CHS", "当前的类所有成员都可锁定,支持多线程操作" )]
			public ref class ConnectHandler : public ConnectHandle
			{
				#pragma region zh-CHS 私有成员变量 | en Private Member Variables
			private:
				// 用于客户Scoket句柄的锁
				Demo::Mmose::Core::Common::Atom::LockCheck							m_LockCheck;

			    // 接受数据的Queue列表(防止多线程中发送的顺序不同)
			    System::Threading::Collections::ConcurrentQueue<MessageBlock^>		m_SendMessageQueue;
				Demo::Mmose::Core::Common::Atom::LockInOut							m_SendLockInOut;

			    // 处理数据的Queue列表(防止多线程中处理的顺序不同)
			    System::Threading::Collections::ConcurrentQueue<MessageBlock^>		m_ProcessMessageQueue;
				Demo::Mmose::Core::Common::Atom::LockInOut							m_ProcessLockInOut;

				DelegateSendBufferStream^											m_DelegateSendBufferStream;
				DelegateProcessBufferStream^										m_DelegateProcessBufferStream;
				#pragma endregion

				#pragma region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
			internal:
				ConnectHandler (SocketClient^ value);

			public:
				~ConnectHandler() { CloseSocket(); }
				!ConnectHandler() { CloseSocket(); }
				#pragma endregion

				#pragma region zh-CHS 共有方法 | en Public Methods
			public:
				// ---------- ConnectHandle ----------
				// LinkHandler 虚函数的覆盖,多线程(处理)
				virtual void SendTo(MessageBlock^ sendMessageBlock) override;
				virtual void CloseSocket() override;
				// ---------- ConnectHandle ----------

				#pragma endregion

				#pragma region zh-CHS 内部属性 | en Internal Properties
			private:
				SocketClient^ m_pSocketClient;
			public:
				property SocketClient^ Owner
				{
					SocketClient^ get()
					{
						return m_pSocketClient;
					}
				}
				#pragma endregion

				#pragma region zh-CHS 内部方法 | en Internal Methods
			internal:
				// ---------- IConnectHandler ----------
				void OnReadStream(MessageBlock^ readMessageBlock);
				void OnWriteStream(MessageBlock^ writeMessageBlock);
				// ---------- IConnectHandler ----------

				// ---------- ITaskWorkerHandler ----------
				// ITaskWorkerHandler 接口的实现,多线程(发送、处理)
				// 在TaskWorker(TASK_WORKER_TYPE_SEND)线程中工作(或内部调用)
				void OnSendBufferStream(MessageBlock^ sendMessageBlock);
				// 在TaskWorker(TASK_WORKER_TYPE_PROCSS)线程中工作(或内部调用)
				void OnProcessBufferStream(MessageBlock^ processMessageBlock);
				// ---------- ITaskWorkerHandler ----------

			internal:
				void InitReceiveBufferStream(MessageBlock^ receiveMessageBlock);

				void PostSendStream(MessageBlockInfo^ sendMessageBlockInfo);
				void PostProcessStream(MessageBlockInfo^ processMessageBlockInfo);

				// 初始化LinkHandler数据
				void InitClientHandler();

				// 释放LinkHandler
				void FiniClientHandler(void);

				// 计算LinkHandler数据
				void CalcClientHandler();

				// 关闭句柄,防止Scoket多线程出错(发送、接收、处理)
				void InvalidHandle();
				#pragma endregion
			};
		}
	}
}