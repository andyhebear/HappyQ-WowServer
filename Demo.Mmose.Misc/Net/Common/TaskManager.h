#pragma once

namespace Demo
{
	namespace Mmose
	{
		namespace Net
		{

			private ref class TaskManager
			{
			internal:
				TaskManager();
				~TaskManager() { Stop(); }

			public:
				property System::Int32 TaskThreadPoolSize
				{
					System::Int32 get()
					{
						return m_iThreadPoolSize;
					}
				}

				property TaskWorker^ SendTaskWorker
				{
					TaskWorker^ get()
					{
						return m_SendTaskWorker;
					}
				}

				property TaskWorker^ ProcessTaskWorker
				{
					TaskWorker^ get()
					{
						return m_ProcessTaskWorker;
					}
				}

				property System::Boolean IsStart
				{
					System::Boolean get()
					{
						return m_bIsThreadRun;
					}
				}

				// (��ʱû��ʹ��)
				//void QueueUserWorkItem( MessageBlockInfo^ messageBlockInfo ) { m_ThreadManager->QueueUserWorkItem( m_WaitCallback, messageBlockInfo ); }

				void CreateSendTaskWorker( System::Int32 iThreadPoolSize );
				void CreateProcessTaskWorker( System::Int32 iThreadPoolSize );

				void Start ( System::Int32 iThreadPoolSize );
				void Stop ();

			private:
				void ThreadCallback( System::Object^ state );

			private:
				System::Boolean							m_bIsThreadRun;

				// �������ݽ��ջ��ͻ�����̳߳ش�С
				System::Int32							m_iThreadPoolSize;

				TaskWorker^								m_SendTaskWorker;
				TaskWorker^								m_ProcessTaskWorker;

				Demo::Mmose::Threading::IOCPThreadPool^    m_ThreadManager;
				System::Threading::SpinLock				m_Lock;

				System::Threading::WaitCallback^		m_WaitCallback;
			};

		}
	}
}