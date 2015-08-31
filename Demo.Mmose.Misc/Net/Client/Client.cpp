#include "StdAfx.h"
#include "ClientInc.h"
#include "Client.h"

namespace Demo
{
	namespace Mmose
	{
		namespace Net
		{



			static Client::Client()
			{
				s_isInit						= false;

				s_ClientCachedSize				= 120;		// 缺省缓冲池为120(或许足够)
				s_ClientBufferSize				= 4096;		// 缺省缓冲大小为4096
				s_ClientManageThreadPoolSize	= 1;		// 缺省(客户端)只需要1个管理线程
				s_ClientSendThreadPoolSize		= 1;		// 缺省(客户端)只需要1个发送线程
				s_ClientReceiveThreadPoolSize	= 1;		// 缺省(客户端)需要1个接收线程
				s_ClientProcessThreadPoolSize	= 1;		// 缺省(客户端)需要1个处理线程
				s_ClientOutTimeInterval			= 180;		// 缺省在线的最大有效时间为3分钟

				s_MessageBlockManager = gcnew Demo::Mmose::Net::MessageBlockManager();
				s_TaskManager = gcnew Demo::Mmose::Net::TaskManager();
			}

			void Client::Init( System::Int32 ClientCachedSize, System::Int32 ClientBufferSize, System::Int32 ClientManageThreadPoolSize, System::Int32 ClientSendThreadPoolSize, System::Int32 ClientReceiveThreadPoolSize, System::Int32 ClientProcessThreadPoolSize, System::Int32 ClientOutTimeInterval )
			{
				s_ClientCachedSize = ClientCachedSize;
				s_ClientBufferSize = ClientBufferSize;
				s_ClientManageThreadPoolSize = ClientManageThreadPoolSize;
				s_ClientSendThreadPoolSize = ClientSendThreadPoolSize;
				s_ClientReceiveThreadPoolSize = ClientReceiveThreadPoolSize;
				s_ClientProcessThreadPoolSize = ClientProcessThreadPoolSize;
				s_ClientOutTimeInterval = ClientOutTimeInterval;

				InitDefault();
			}

			void Client::InitDefault()
			{
				if (s_isInit == true)
					throw gcnew System::Exception("Client::Init(...) - s_isInit == true error\n");

				s_Lock.Enter();
				try
				{
					do
					{
						if (s_isInit == true)
							throw gcnew System::Exception("Client::Init(...) - s_isInit == true error\n");

						// 初始化网络
						static WSADATA s_WSAData;
						::memset(&s_WSAData, 0, sizeof(WSADATA));

						if (::WSAStartup(MAKEWORD(2,2),&s_WSAData) != NO_ERROR)
							throw gcnew System::Exception("Client::Init(...) - WSAStartup(...) != NO_ERROR error\n");

						// 初始化缓冲池
						s_MessageBlockManager->Init(s_ClientCachedSize, s_ClientBufferSize);

						// 开始启动发送线程池
						s_TaskManager->CreateSendTaskWorker(s_ClientSendThreadPoolSize);
						// 开始启动处理线程池
						s_TaskManager->CreateProcessTaskWorker(s_ClientProcessThreadPoolSize);

						// 开始启动管理线程池
						s_TaskManager->Start(s_ClientManageThreadPoolSize);

						s_isInit	= true;
					} while (false); // do
				}
				finally
				{
					s_Lock.Exit();
				}
			}

			void Client::Fini(void)
			{
				if (s_isInit == false)
					throw gcnew System::Exception("Client::Fini(...) - s_isInit == false error\n");

				s_Lock.Enter();
				try
				{
					do
					{
						if (s_isInit == false)
							throw gcnew System::Exception("Client::Fini(...) - s_isInit == false error\n");

						// 先关闭全部已经创建了的Socket,然后再释放句柄
						for each(SocketClient^ socketClient in s_SocketClientList)
						{
							// 关闭句柄
							if (socketClient != nullptr)
								socketClient->StopConnect();
						}

						// 释放网络
						::WSACleanup();

						// 线程的停止
						s_TaskManager->Stop();

						// 释放缓冲区
						s_MessageBlockManager->Fini();

						// 释放全部已经创建了的Socket 清空数据
						s_SocketClientList.Clear();

						s_isInit	= false;
					} while (false); // do
				}
				finally
				{
					s_Lock.Exit();
				}
			}

			void Client::AddNewInstance(SocketClient^ newInstance)
			{
				if (newInstance == nullptr)
					throw gcnew System::Exception("Client::AddNewInstance(...) - newInstance == nullptr error\n");

				s_Lock.Enter();
				try
				{
					s_SocketClientList.Add(newInstance);
				}
				finally
				{
					s_Lock.Exit();
				}
			}

		}
	}
}  