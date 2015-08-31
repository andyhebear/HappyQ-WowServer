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

				s_ServerCachedSize = 3000;				// ȱʡ�����Ϊ3000(�ͻ���*3)
				s_ServerBufferSize = 4096;				// ȱʡ�����СΪ4096
				s_ServerManageThreadPoolSize = 1;		// ȱʡ(�����)ֻ��Ҫ1�������߳�
				s_ServerSendThreadPoolSize = 1;			// ȱʡ(�����)ֻ��Ҫ1�������߳�
				s_ServerReceiveThreadPoolSize = 3;		// ȱʡ(�����)ֻ��Ҫ3�������߳�
				s_ServerProcessThreadPoolSize = 3;		// ȱʡ(�����)��Ҫ3�������߳�
				s_ServerMaxClients = 3000;				// ȱʡ�������ӿͻ�Ϊ600
				s_ServerOutTimeInterval = 180;			// ȱʡ���ߵ������Чʱ��Ϊ3����

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

					// ��ʼ������
					static WSADATA s_WSAData;
					::memset(&s_WSAData, 0, sizeof(WSADATA));

					if (::WSAStartup(MAKEWORD(2,2),&s_WSAData) != NO_ERROR)
						throw gcnew System::Exception("Server::Init(...) - WSAStartup(...) != NO_ERROR error\n");

					// ��ʼ��������
					s_MessageBlockManager->Init(Server::s_ServerCachedSize, Server::s_ServerBufferSize);

					// ��ʼ�������ͺʹ����߳�
					s_TaskManager->CreateSendTaskWorker(Server::s_ServerSendThreadPoolSize);
					s_TaskManager->CreateProcessTaskWorker(Server::s_ServerProcessThreadPoolSize);

					// ��ʼ���������߳�
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

					// �ȹر�ȫ���Ѿ������˵�Socket,Ȼ�����ͷž��
					for each(SocketServer^ socketServer in s_SocketServerList)
					{
						if (socketServer != nullptr)
							socketServer->StopServer();
					}

					// �ͷ�����
					::WSACleanup();

					// �̵߳�ֹͣ
					s_TaskManager->Stop();

					// �ͷŻ�����
					s_MessageBlockManager->Fini();

					// �ͷ�ȫ���Ѿ������˵�Socket �������
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

				// �˴�����Ҫ�����û�г�ʼ��
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