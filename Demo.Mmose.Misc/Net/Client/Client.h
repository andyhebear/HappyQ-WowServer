#pragma once

namespace Demo
{
	namespace Mmose
	{
		namespace Net
		{

			ref class TaskManager;
			ref class SocketClient;
			ref class MessageBlockManager;

			[Demo::Mmose::Core::Common::MultiThreadedSupport( "zh-CHS", "当前的类所有成员都可锁定,支持多线程操作" )]
			public ref class Client
			{
				#pragma region zh-CHS 私有静态成员变量 | en Private Static Member Variables
			private:
				static System::Threading::SpinLock s_Lock;

				static System::Collections::Generic::List<SocketClient^> s_SocketClientList;
				#pragma endregion

				#pragma region zh-CHS 内部静态成员变量 | en Internal Static Member Variables
			internal:
				//数据缓冲区(池)的大小
				static int s_ClientCachedSize;

				//数据缓冲区大小
				static int s_ClientBufferSize;

				//进行管理线程池的线程池大小
				static int s_ClientManageThreadPoolSize;	

				//进行数据发送的线程池大小
				static int s_ClientSendThreadPoolSize;

				//进行数据接收的线程池大小
				static int s_ClientReceiveThreadPoolSize;

				//进行数据处理的线程池大小
				static int s_ClientProcessThreadPoolSize;

				//检测客户端是否在线的最大有效时间
				static int s_ClientOutTimeInterval;
				#pragma endregion

				#pragma region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
			private:
				Client() { }

				static Client();
				#pragma endregion

				#pragma region zh-CHS 共有静态属性 | en Public Static Properties
			private:
				// 客户端是否初始化
				static System::Boolean s_isInit;
			public:
				property static bool IsInit
				{
					bool get()
					{
						return s_isInit;
					}
				}
				#pragma endregion

				#pragma region zh-CHS 内部静态属性 | en Internal Static Properties
			internal:
				// 数据缓冲区(池)的管理
				static Demo::Mmose::Net::MessageBlockManager^ s_MessageBlockManager;
				property static Demo::Mmose::Net::MessageBlockManager^ MessageBlockManager
				{
					Demo::Mmose::Net::MessageBlockManager^ get()
					{
						return s_MessageBlockManager;
					}
				}

				// 数据发送、接收、处理的管理
				static Demo::Mmose::Net::TaskManager^ s_TaskManager;
				property static Demo::Mmose::Net::TaskManager^ TaskManager
				{
					Demo::Mmose::Net::TaskManager^ get()
					{
						return s_TaskManager;
					}
				}
				#pragma endregion

				#pragma region zh-CHS 共有静态属性 | en Public Static Properties
			public:
				// 客户端的初始化
				static void Init( System::Int32 ClientCachedSize, System::Int32 ClientBufferSize, System::Int32 ClientManageThreadPoolSize, System::Int32 ClientSendThreadPoolSize, System::Int32 ClientReceiveThreadPoolSize, System::Int32 ClientProcessThreadPoolSize, System::Int32 ClientOutTimeInterval );

				// 客户端的缺省初始化
				static void InitDefault();

				// 客户端的释放
				static void Fini();
				#pragma endregion

				#pragma region zh-CHS 内部静态方法 | en Internal Static Methods
			internal:
				// 实例化一个内部主要的SocketClient
				static void AddNewInstance(SocketClient^ newInstance);
				#pragma endregion
			};

		}
	}
}