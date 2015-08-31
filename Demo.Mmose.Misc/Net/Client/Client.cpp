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

				s_ClientCachedSize				= 120;		// ȱʡ�����Ϊ120(�����㹻)
				s_ClientBufferSize				= 4096;		// ȱʡ�����СΪ4096
				s_ClientManageThreadPoolSize	= 1;		// ȱʡ(�ͻ���)ֻ��Ҫ1�������߳�
				s_ClientSendThreadPoolSize		= 1;		// ȱʡ(�ͻ���)ֻ��Ҫ1�������߳�
				s_ClientReceiveThreadPoolSize	= 1;		// ȱʡ(�ͻ���)��Ҫ1�������߳�
				s_ClientProcessThreadPoolSize	= 1;		// ȱʡ(�ͻ���)��Ҫ1�������߳�
				s_ClientOutTimeInterval			= 180;		// ȱʡ���ߵ������Чʱ��Ϊ3����

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

						// ��ʼ������
						static WSADATA s_WSAData;
						::memset(&s_WSAData, 0, sizeof(WSADATA));

						if (::WSAStartup(MAKEWORD(2,2),&s_WSAData) != NO_ERROR)
							throw gcnew System::Exception("Client::Init(...) - WSAStartup(...) != NO_ERROR error\n");

						// ��ʼ�������
						s_MessageBlockManager->Init(s_ClientCachedSize, s_ClientBufferSize);

						// ��ʼ���������̳߳�
						s_TaskManager->CreateSendTaskWorker(s_ClientSendThreadPoolSize);
						// ��ʼ���������̳߳�
						s_TaskManager->CreateProcessTaskWorker(s_ClientProcessThreadPoolSize);

						// ��ʼ���������̳߳�
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

						// �ȹر�ȫ���Ѿ������˵�Socket,Ȼ�����ͷž��
						for each(SocketClient^ socketClient in s_SocketClientList)
						{
							// �رվ��
							if (socketClient != nullptr)
								socketClient->StopConnect();
						}

						// �ͷ�����
						::WSACleanup();

						// �̵߳�ֹͣ
						s_TaskManager->Stop();

						// �ͷŻ�����
						s_MessageBlockManager->Fini();

						// �ͷ�ȫ���Ѿ������˵�Socket �������
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