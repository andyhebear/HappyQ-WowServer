#include "StdAfx.h"
#include "ServerInc.h"
#include "Server.h"

namespace Demo
{
	namespace Mmose
	{
		namespace Net
		{

			static Server::Server()
			{
				s_isInit = false;

				s_ServerCachedSize = 3000;				// 缺省缓冲池为3000(客户端*3)
				s_ServerBufferSize = 4096;				// 缺省缓冲大小为4096
				s_ServerManageThreadPoolSize = 1;		// 缺省(服务端)只需要1个管理线程
				s_ServerSendThreadPoolSize = 1;			// 缺省(服务端)只需要1个发送线程
				s_ServerReceiveThreadPoolSize = 3;		// 缺省(服务端)只需要3个接收线程
				s_ServerProcessThreadPoolSize = 3;		// 缺省(服务端)需要3个处理线程
				s_ServerMaxClients = 3000;				// 缺省最大的连接客户为600
				s_ServerOutTimeInterval = 180;			// 缺省在线的最大有效时间为3分钟

				s_SocketServerList = gcnew System::Collections::Generic::List<SocketServer^>(1024);
				s_MessageBlockManager = gcnew Demo::Mmose::Net::MessageBlockManager();
				s_TaskManager = gcnew Demo::Mmose::Net::TaskManager();
			}

			void Server::Init( System::Int32 ServerCachedSize, System::Int32 ServerBufferSize, System::Int32 ServerManageThreadPoolSize, System::Int32 ServerSendThreadPoolSize, System::Int32 ServerReceiveThreadPoolSize, System::Int32 ServerProcessThreadPoolSize, System::Int32 ServerMaxClients, System::Int32 ServerOutTimeInterval )
			{
				s_ServerCachedSize = ServerCachedSize;
				s_ServerBufferSize = ServerBufferSize;
				s_ServerManageThreadPoolSize = ServerManageThreadPoolSize;
				s_ServerSendThreadPoolSize = ServerSendThreadPoolSize;
				s_ServerReceiveThreadPoolSize = ServerReceiveThreadPoolSize;
				s_ServerProcessThreadPoolSize = ServerProcessThreadPoolSize;
				s_ServerMaxClients = ServerMaxClients;
				s_ServerOutTimeInterval = ServerOutTimeInterval;

				InitDefault();
			}

			void Server::InitDefault()
			{
				if (s_isInit == true)
					throw gcnew System::Exception("Server::Init(...) - s_isInit == true error\n");

				s_Lock.Enter();
				try
				{
					if (s_isInit == true)
						throw gcnew System::Exception("Server::Init(...) - s_isInit == true error\n");

					// 初始化网络
					static WSADATA s_WSAData;
					::memset(&s_WSAData, 0, sizeof(WSADATA));

					if (::WSAStartup(MAKEWORD(2,2),&s_WSAData) != NO_ERROR)
						throw gcnew System::Exception("Server::Init(...) - WSAStartup(...) != NO_ERROR error\n");

					// 初始化缓冲区
					s_MessageBlockManager->Init(Server::s_ServerCachedSize, Server::s_ServerBufferSize);

					// 开始创建发送和处理线程
					s_TaskManager->CreateSendTaskWorker(Server::s_ServerSendThreadPoolSize);
					s_TaskManager->CreateProcessTaskWorker(Server::s_ServerProcessThreadPoolSize);

					// 开始创建管理线程
					s_TaskManager->Start(Server::s_ServerManageThreadPoolSize);

					s_isInit	= true;
				}
				finally
				{
					s_Lock.Exit();
				}
			}

			void Server::Fini(void)
			{
				if (s_isInit == false)
					throw gcnew System::Exception("Server::Fini(...) - s_isInit == false error\n");

				s_Lock.Enter();
				try
				{
					if (s_isInit == false)
						throw gcnew System::Exception("Server::Fini(...) - s_isInit == false error\n");

					// 先关闭全部已经创建了的Socket,然后再释放句柄
					for each(SocketServer^ socketServer in s_SocketServerList)
					{
						if (socketServer != nullptr)
							socketServer->StopServer();
					}

					// 释放网络
					::WSACleanup();

					// 线程的停止
					s_TaskManager->Stop();

					// 释放缓冲区
					s_MessageBlockManager->Fini();

					// 释放全部已经创建了的Socket 清空数据
					s_SocketServerList->Clear();

					s_isInit	= false;
				}
				finally
				{
					s_Lock.Exit();
				}
			}

			void Server::AddNewInstance(SocketServer^ newInstance)
			{
				if (newInstance == nullptr)
					throw gcnew System::Exception("Server::AddNewInstance(...) - newInstance == nullptr error\n");

				// 此处不需要检测有没有初始化
				s_Lock.Enter();
				try
				{
					s_SocketServerList->Add(newInstance);
				}
				finally
				{
					s_Lock.Exit();
				}
			}

		}
	}
}  