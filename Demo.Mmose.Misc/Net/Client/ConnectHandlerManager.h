#pragma once

namespace Demo
{
	namespace Mmose
	{
		namespace Net
		{

			ref class MessageBlock;
			ref class ConnectHandler;
			ref class SocketClient;

			[Demo::Mmose::Core::Common::MultiThreadedSupport( "zh-CHS", "当前的类所有成员都可锁定,支持多线程操作" )]
			public ref class ConnectHandlerManager
			{
				#pragma region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
			internal:
				ConnectHandlerManager(SocketClient^ value);
				~ConnectHandlerManager() { };
				#pragma endregion

				#pragma region zh-CHS 共有属性 | en Public Properties
			public:
				// 获取客户端的句柄
				property Demo::Mmose::Net::ConnectHandler^ ConnectHandler
				{
				public:
					Demo::Mmose::Net::ConnectHandler^ get();
				}

			private:
				SocketClient^ m_SocketClient;
			public:
				property SocketClient^ Owner
				{
				public:
					SocketClient^ get()
					{
						return m_SocketClient;
					}
				}
				#pragma endregion

				#pragma region zh-CHS 共有方法 | en Public Methods
			public:
				// 获取需要发送的数据包
				MessageBlock^ GetNewSendMessageBlock();
				#pragma endregion
			};

		}
	}
}