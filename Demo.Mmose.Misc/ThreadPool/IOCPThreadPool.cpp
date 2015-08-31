#include "StdAfx.h"
#include "IOCPThreadPool.h"

namespace Demo
{
	namespace Mmose
	{
		namespace Threading
		{

			void IOCPThreadPool::InternalDispose()
			{
				if ( m_IsInit == false )
					return;

				m_Lock.Enter();
				{
					do
					{
						if ( m_IsInit == false )
							break;

						m_ThreadTerminate       = true;

						m_IOCP.InternalDispose();

						m_itemsPosted           = 0;
						m_numBusyThreads        = 0;
						m_itemsProcessed        = 0;
						m_numThreadsInPool      = 0;
						m_maxThreadsEverInPool  = 0;
						m_maxThreadsAllowed     = 0;
						m_idleThreadTimeout     = INFINITE;

						m_IsInit                = false;
					} while (false); // do
				}
				m_Lock.Exit();
			}

			void IOCPThreadPool::InitThreadPool( System::UInt32 idleThreadTimeout, System::UInt32 maxThreadsAllowed, System::UInt32 maxConcurrency )
			{
				if ( m_IsInit == true )
					return;

				m_Lock.Enter();
				{
					do
					{
						if ( m_IsInit == true )
							break;

						m_ThreadTerminate       = false;

						m_itemsPosted           = 0;
						m_numBusyThreads        = 0;
						m_itemsProcessed        = 0;
						m_numThreadsInPool      = 0;
						m_maxThreadsEverInPool  = 0;

						m_maxThreadsAllowed     = maxThreadsAllowed;
						m_idleThreadTimeout     = idleThreadTimeout;

						m_IOCP.InitIOCompletionPort( maxConcurrency );
						
						m_IsInit                = true;

						// 开始创建线程
						AddThreadToPool();
					} while (false); // do
				}
				m_Lock.Exit();
			}

			void IOCPThreadPool::QueueUserWorkItem( System::Threading::WaitCallback^ waitCallback, System::Object^ oState )
			{
				System::Threading::Interlocked::Increment(m_itemsPosted);

				m_IOCP.PostStatus( waitCallback, oState );
			}

			// 线程的回调函数
			void IOCPThreadPool::ThreadPoolFunction()
			{
				try
				{
					for ( bool fStayInPool = true; fStayInPool; )
					{
						System::Threading::WaitCallback^ pWaitCallback = nullptr;
						System::Object^ pState = nullptr;
						bool bTimedOut = false;

						// Thread stops executing & waits for something to do.
						System::Threading::Interlocked::Decrement( m_numBusyThreads );

						m_IOCP.GetStatus( (UINT32)m_idleThreadTimeout, bTimedOut, pWaitCallback, pState );

						// Thread wakes up and has something to do
						__int64 busyThreads = System::Threading::Interlocked::Increment( m_numBusyThreads );

						if ( bTimedOut == true || m_ThreadTerminate == true )
						{
							// The thread pool is NOT heavily used, remove this thread from the pool
							fStayInPool = false;
							break;	// Leave the loop
						}

						if ( ( busyThreads == m_numThreadsInPool ) && ( busyThreads < m_maxThreadsAllowed ) )
						{
							// Every thread in the pool is running and we haven't hit our maximum.
							AddThreadToPool();
						}

						System::Threading::Interlocked::Increment( m_itemsProcessed );

						// Execute the callback method
						if ( pWaitCallback != nullptr )
							pWaitCallback( pState );
					}	// for loop
				}  // try
				finally
				{
					// Remove a thread from the thread pool
					System::Threading::Interlocked::Decrement( m_numBusyThreads );

					if ( System::Threading::Interlocked::Decrement( m_numThreadsInPool ) == 0 )
					{
						// No more threads in the pool
					}
				}
			}

			void IOCPThreadPool::AddThreadToPool()
			{
				System::Threading::Interlocked::Increment(m_numThreadsInPool);
				IOCPThreadPool::InterlockedMax( m_maxThreadsEverInPool, m_numThreadsInPool );
				System::Threading::Interlocked::Increment(m_numBusyThreads);

				System::Threading::Thread^ iocpThread = gcnew System::Threading::Thread( gcnew System::Threading::ThreadStart( this, &Demo::Mmose::Threading::IOCPThreadPool::ThreadPoolFunction ) );
				iocpThread->Name = "IOCP Thread-" + m_itemsPosted.ToString();
				iocpThread->IsBackground = true;
				iocpThread->Start();
			}

			__int64 IOCPThreadPool::InterlockedMax(System::Int64% target, System::Int64 val )
			{
				__int64 iValue = target;
				__int64 iLocation = target;

				do
				{
					iValue = iLocation;
					iLocation = System::Threading::Interlocked::CompareExchange( target, iValue > val ? iValue : val, iValue );
				} while ( iValue != iLocation );

				return iLocation;
			}

		}
	}
}