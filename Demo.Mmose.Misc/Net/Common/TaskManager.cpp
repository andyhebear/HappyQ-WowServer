#include "StdAfx.h"
#include "CommonInc.h"
#include "TaskManager.h"

namespace Demo
{
	namespace Mmose
	{
		namespace Net
		{

			TaskManager::TaskManager()  : m_iThreadPoolSize(5)
				, m_bIsThreadRun(false)
			{
				m_WaitCallback = gcnew System::Threading::WaitCallback(this, &TaskManager::ThreadCallback);

				m_SendTaskWorker = gcnew TaskWorker(TASK_WORKER_TYPE_SEND, this);
				m_ProcessTaskWorker = gcnew TaskWorker(TASK_WORKER_TYPE_PROCSS, this);
			}

			void TaskManager::Start(System::Int32 iThreadPoolSize)
			{
				if ( iThreadPoolSize <= 0 )
					throw gcnew System::Exception("TaskManager::Start(...) - iThreadPoolSize <= 0 error\n");

				m_Lock.Enter();
			    {
					if ( m_bIsThreadRun == true )
						throw gcnew System::Exception("TaskManager::Start(...) - iThreadPoolSize <= 0 error\n");

					m_iThreadPoolSize = iThreadPoolSize;
					m_ThreadManager = gcnew Demo::Mmose::Threading::IOCPThreadPool(m_iThreadPoolSize);

					m_bIsThreadRun	= true;
				}
			    m_Lock.Exit();
			}
			
			void TaskManager::Stop()
			{
				if ( m_bIsThreadRun == false )
					return;

				m_Lock.Enter();
				{
					if ( m_bIsThreadRun == false )
						throw gcnew System::Exception("TaskManager::Start(...) - iThreadPoolSize <= 0 error\n");

					m_ThreadManager->InternalDispose();

					m_SendTaskWorker->Stop();
					m_ProcessTaskWorker->Stop();

					m_bIsThreadRun	= false;
				}
				m_Lock.Exit();
			}
			
			void TaskManager::ThreadCallback( System::Object^ state )
			{
			    MessageBlockInfo^ pMessageBlockInfo = safe_cast<MessageBlockInfo^>(state);
			    if (pMessageBlockInfo == nullptr)
			        throw gcnew System::Exception("TaskManager::ThreadCallback(...) - pMessageBlockInfo == nullptr error\n");

			    if (pMessageBlockInfo->MessageBlock == nullptr)
			        throw gcnew System::Exception("TaskManager::ThreadCallback(...) - pMessageBlockInfo->m_pMessageBlock == nullptr error\n");

			    if (pMessageBlockInfo->m_TaskManagerCallback == nullptr)
			        throw gcnew System::Exception("TaskManager::ThreadCallback(...) - pMessageBlockInfo->m_TaskManagerCallback == nullptr error\n");

				pMessageBlockInfo->m_TaskManagerCallback(pMessageBlockInfo->MessageBlock);
			}
			
			void TaskManager::CreateSendTaskWorker(System::Int32 iThreadPoolSize)
			{
				if ( m_SendTaskWorker->IsStart == true )
					throw gcnew System::Exception("TaskManager::CreateSendTaskWorker(...) - m_SendTaskWorker.IsStart() == true error\n");
			
				m_SendTaskWorker->Start( iThreadPoolSize ) ;
			}
			
			void TaskManager::CreateProcessTaskWorker(System::Int32 iThreadPoolSize)
			{
				if ( m_ProcessTaskWorker->IsStart == true )
					throw gcnew System::Exception("TaskManager::CreateSendTaskWorker(...) - m_SendTaskWorker.IsStart() == true error\n");
			
				m_ProcessTaskWorker->Start( iThreadPoolSize );
			}

		}
	}
}