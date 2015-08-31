#pragma once


namespace Demo
{
	namespace Mmose
	{
		namespace Net
		{

			ref class TaskManager;
			ref class SocketServer;
			ref class MessageBlockManager;

			[Demo::Mmose::Core::Common::MultiThreadedSupport( "zh-CHS", "当前的类所有成员都可锁定,支持多线程操作" )]
			public ref class Server
			{
				#pragma region zh-CHS 私有静态成员变量 | en Private Static Member Variables
			private:
				static System::Threading::SpinLock s_Lock;

				static System::Collections::Generic::List<SocketServer^>^ s_SocketServerList;
				#pragma endregion

				#pragma region zh-CHS 内部静态成员变量 | en Internal Static Member Variables
			internal:
				//数据缓冲区(池)的大小
				static int s_ServerCachedSize;

				//数据缓冲区大小
				static int s_ServerBufferSize;

				//进行管理线程池的线程池大小
				static int s_ServerManageThreadPoolSize;

				//进行数据发送的线程池大小
				static int s_ServerSendThreadPoolSize;

				//进行数据接收的线程池大小
				static int s_ServerReceiveThreadPoolSize;

				//进行数据处理的线程池大小
				static int s_ServerProcessThreadPoolSize;

				//服务端用户最大的可连接数
				static int s_ServerMaxClients;

				//检测客户端是否在线的最大有效时间
				static int s_ServerOutTimeInterval;
				#pragma endregion

				#pragma region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
			private:
				Server() { }

				static Server();
				#pragma endregion

				#pragma region zh-CHS 共有静态属性 | en Public Static Properties
			private:
				// 服务端的是否已初始化
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

				#pragma region zh-CHS 共有静态属性 | en Public Static Properties
			public:
				// 服务的初始化
				static void Init( System::Int32 ServerCachedSize, System::Int32 ServerBufferSize, System::Int32 ServerManageThreadPoolSize, System::Int32 ServerSendThreadPoolSize, System::Int32 ServerReceiveThreadPoolSize, System::Int32 ServerProcessThreadPoolSize, System::Int32 ServerMaxClients, System::Int32 ServerOutTimeInterval );

				// 服务端的缺省初始化
				static void InitDefault();

				// 服务的释放
				static void Fini();
				#pragma endregion

				#pragma region zh-CHS 内部静态属性 | en Internal Static Properties
			private:
				// 数据发送、接收、处理的管理
				static Demo::Mmose::Net::MessageBlockManager^ s_MessageBlockManager;
			internal:
				property static Demo::Mmose::Net::MessageBlockManager^ MessageBlockManager
				{
					Demo::Mmose::Net::MessageBlockManager^ get()
					{
						return s_MessageBlockManager;
					}
				}

			private:
				// 数据缓冲区(池)的管理
				static Demo::Mmose::Net::TaskManager^ s_TaskManager;
			internal:
				property static Demo::Mmose::Net::TaskManager^ TaskManager
				{
					Demo::Mmose::Net::TaskManager^ get()
					{
						return s_TaskManager;
					}
				}
				#pragma endregion

				#pragma region zh-CHS 内部静态方法 | en Internal Static Methods
			internal:
				// 添加一个实例化至内部主要的SocketServer
				static void AddNewInstance(SocketServer^ newInstance);
				#pragma endregion
			};
		}
	}
}