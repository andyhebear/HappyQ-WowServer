#include "StdAfx.h"
#include "CommonInc.h"
#include "TaskWorker.h"

namespace Demo
{
	namespace Mmose
	{
		namespace Net
		{

			TaskWorker::TaskWorker(MessageBlockType taskWorkerType, TaskManager^ Owner) : m_pTaskManager(Owner)
				, m_TaskWorkerType(taskWorkerType)
				, m_bIsThreadRun(false)
			{
				m_WaitCallback = gcnew System::Threading::WaitCallback(this, &TaskWorker::ThreadCallback);
			}

			void TaskWorker::Start( System::Int32 iThreadPoolSize )
			{
				if ( iThreadPoolSize <= 0 )
					throw("TaskManager::Start(...) - iThreadPoolSize <= 0 error\n");

				m_Lock.Enter();
				try
				{
					if ( m_bIsThreadRun == true )
						throw("TaskManager::Start(...) - m_bIsThreadRun == true error\n");

					m_iThreadPoolSize = iThreadPoolSize;
					m_ThreadManager = gcnew Demo::Mmose::Threading::IOCPThreadPool(m_iThreadPoolSize);

					m_bIsThreadRun	= true;
				}
				finally
				{
					m_Lock.Exit();
				}
			}
			
			void TaskWorker::Stop()
			{
				if (m_bIsThreadRun == false)
					return;

			    m_Lock.Enter();
				try
			    {
					do
					{
						if (m_bIsThreadRun == false)
							break;

						m_ThreadManager->InternalDispose();

						m_bIsThreadRun	= false;

					} while (false);
				}
				finally
				{
					m_Lock.Exit();
				}
			}
			
			void TaskWorker::ThreadCallback( System::Object^ state )
			{
			    MessageBlockInfo^ pMessageBlockInfo = safe_cast<MessageBlockInfo^>(state);
			    if (pMessageBlockInfo == nullptr)
			        gcnew System::Exception("TaskWorker::ThreadCallback(...) - pMessageBlockInfo == nullptr error\n");

			    if (pMessageBlockInfo->MessageBlock == nullptr)
			        gcnew System::Exception("TaskWorker::ThreadCallback(...) - pMessageBlockInfo->m_pMessageBlock == nullptr error\n");

			    switch (pMessageBlockInfo->m_OperatorType)
			    {
			    case TASK_WORKER_TYPE_SEND:

					if (pMessageBlockInfo->m_SendBufferStream == nullptr)
						gcnew System::Exception("TaskWorker::ThreadCallback(...) - pMessageBlockInfo->m_SendBufferStream == nullptr error\n");

			        pMessageBlockInfo->m_SendBufferStream(pMessageBlockInfo->MessageBlock);

			        break;
			    case TASK_WORKER_TYPE_PROCSS:

					if (pMessageBlockInfo->m_ProcessBufferStream == nullptr)
						gcnew System::Exception("TaskWorker::ThreadCallback(...) - pMessageBlockInfo->m_ProcessBufferStream == nullptr error\n");

			        pMessageBlockInfo->m_ProcessBufferStream(pMessageBlockInfo->MessageBlock);

			        break;
			    case TASK_WORKER_TYPE_RECEIVE:

			        gcnew System::Exception("TaskWorker::ThreadCallback(...) - TASK_WORKER_TYPE_RECEIVE error\n");
			    default:

			        gcnew System::Exception("TaskWorker::ThreadCallback(...) - default(...) error\n");
			    }
			}

		}
	}
}