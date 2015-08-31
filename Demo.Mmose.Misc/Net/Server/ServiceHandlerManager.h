#pragma once

namespace Demo
{
	namespace Mmose
	{
		namespace Net
		{

			ref class MessageBlock;
			ref class ServiceHandle;
			ref class SocketServer;
			ref class ServiceHandleManager;

			[Demo::Mmose::Core::Common::MultiThreadedSupport( "zh-CHS", "当前的类所有成员都可锁定,支持多线程操作" )]
			public ref class ServiceHandleManager
			{
				#pragma region zh-CHS 私有成员变量 | en Private Member Variables
			private:
				// 在线的客户端
				System::Threading::SpinLock                                 m_LockBusy;
				System::Collections::Generic::Dictionary<System::String^, ServiceHandler^>	m_Busy;

				// 客户端的已经使用的连接处理
				System::Threading::SpinLock                                 m_Lock;
				System::Collections::Generic::HashSet<ServiceHandler^>		m_StockHandlerManager;
				#pragma endregion

				#pragma region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
			internal:
				ServiceHandleManager(SocketServer^ value);
				~ServiceHandleManager() { CloseAllSocket(); } // 释放全部客户端的处理句柄
				#pragma endregion

				#pragma region zh-CHS 共有属性 | en Public Properties
			private:
				// 总共连接数
				System::Int64												m_iTotalClients;
			public:
				// 共有多少客户端连接过(包括在线和不在线)
				property System::Int64 TotalClients
				{
					System::Int64 get()
					{
						return m_iTotalClients;
					}
				}

			public:
				// 共有多少有效客户端(在线)
				property System::Int64 OnlineClients
				{
					System::Int64 get()
					{
						return (UINT)m_Busy.Count;
					}
				}

			private:
				SocketServer^ m_pSocketServer;
			public:
				// 
				property SocketServer^ Owner
				{
					SocketServer^ get()
					{
						return m_pSocketServer;
					}
				}

				// 通过索引获取客户端
				property ServiceHandle^ default [System::String^]
				{
					ServiceHandle^ get(System::String^ strHostNamePort);
				}
				#pragma endregion

				#pragma region zh-CHS 共有方法 | en Public Methods
			public:
				// 发送全部的数据到客户端
				void SendToAll(MessageBlock^ sendMessageBlock);

				// 获取需要发送的数据包
				MessageBlock^ GetNewSendMessageBlock();

				// 检查全部的在线状态
				void CheckAllOnlineState();
				#pragma endregion

				#pragma region zh-CHS 内部方法 | en Internal Methods
			internal:
				// 添加新的客户端-用于管理客户端(ServiceHandler 调用)
				void AddValidClientHandler(ServiceHandler^ pServiceHandler);
				// 某客户端已无效-用于管理客户端(ServiceHandler 调用)
				void DelInvalidClientHandler(ServiceHandler^ pServiceHandler);

				// 给出新的客户端处理句柄(SocketServer 调用)
				ServiceHandler^ AcquireServiceHandler();
				// 释放客户端处理的句柄(ServiceHandler 调用)
				void ReleaseServiceHandler(ServiceHandler^ pServiceHandler);

				// 关闭全部的Socket(SocketServer 调用)
				void CloseAllSocket();
				#pragma endregion
			};

		}
	}
}