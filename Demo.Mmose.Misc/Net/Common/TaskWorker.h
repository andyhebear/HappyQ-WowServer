#pragma once

namespace Demo
{
	namespace Mmose
	{
		namespace Net
		{

			ref class TaskManager;
			ref class TaskWorker
			{
			internal:
				TaskWorker(MessageBlockType taskWorkerType, TaskManager^ Owner);
				~TaskWorker() { Stop(); }

			public:
				property System::Int32 TaskThreadPoolSize
				{
					System::Int32 get()
					{
						return m_iThreadPoolSize;
					}
				}

				property TaskManager^ Owner
				{
				public:
					TaskManager^ get()
					{
						return m_pTaskManager;
					}
				}

				void QueueUserWorkItem( MessageBlockInfo^ messageBlockInfo ) { m_ThreadManager->QueueUserWorkItem( m_WaitCallback, messageBlockInfo ); }

				void Start ( System::Int32 iThreadPoolSize );
				void Stop ();
			
				property System::Boolean IsStart
				{
					System::Boolean get()
					{
						return m_bIsThreadRun;
					}
				}

			private:
				void ThreadCallback( System::Object^ state );

			private:
				System::Boolean							m_bIsThreadRun;

				// 进行数据接收或发送或处理的线程池大小
				System::Int32							m_iThreadPoolSize;

				MessageBlockType						m_TaskWorkerType;
				TaskManager^							m_pTaskManager;
				Demo::Mmose::Threading::IOCPThreadPool^	m_ThreadManager;
				System::Threading::SpinLock				m_Lock;

				System::Threading::WaitCallback^		m_WaitCallback;
			};

		}
	}
}