#pragma once

#include "IOCompletionPort.h"

namespace Demo
{
	namespace Mmose
	{
		namespace Threading
		{

			public ref class IOCPThreadPool
			{
			public:
				literal System::UInt32 TIMEOUT_INFINITE = (System::UInt32)System::Threading::Timeout::Infinite;

			public:
				IOCPThreadPool( System::UInt32 maxThreadsAllowed ) { InitThreadPool( INFINITE, maxThreadsAllowed, 0 ); }
				IOCPThreadPool( System::UInt32 idleThreadTimeout, System::UInt32 maxThreadsAllowed ) { InitThreadPool( idleThreadTimeout, maxThreadsAllowed, 0 ); }
				IOCPThreadPool( System::UInt32 idleThreadTimeout, System::UInt32 maxThreadsAllowed, System::UInt32 maxConcurrency ) { InitThreadPool( idleThreadTimeout, maxThreadsAllowed, maxConcurrency ); }
				~IOCPThreadPool() { InternalDispose(); }
				!IOCPThreadPool() { InternalDispose(); }

			public:
				// 线程池内可运行的最大线程数
				property System::Int64 MaxThreadsAllowed
				{
					System::Int64 get() { return m_maxThreadsAllowed; }
				}

				// 有多少线程在线程池内
				property System::Int64 ThreadsInPool
				{
					System::Int64 get() { return m_numThreadsInPool; }
				}

				// 线程池内最高运行时的线程数
				property System::Int64 MaxThreadsEverInPool
				{
					System::Int64 get() { return m_maxThreadsEverInPool; }
				}

				// 正在处理数据的线程数
				property System::Int64 BusyThreads
				{
					System::Int64 get() { return m_numBusyThreads; }
				}

				// QueueUserWorkItem(...)的调用次数
				property System::Int64 ItemsPosted
				{
					System::Int64 get() { return m_itemsPosted; }
				}

				// 回调处理后的次数
				property System::Int64 ItemsProcessed
				{
					System::Int64 get() { return m_itemsProcessed; }
				}

				// 等待回调处理的时间长度
				property System::Int64 ItemsPending
				{
					System::Int64 get() { return m_idleThreadTimeout; }
				}

			public:
				void QueueUserWorkItem( System::Threading::WaitCallback^ waitCallback, System::Object^ oState );
				void QueueUserWorkItem( System::Threading::WaitCallback^ waitCallback ) { QueueUserWorkItem( waitCallback, nullptr ); }

			internal:
				void InitThreadPool( System::UInt32 idleThreadTimeout, System::UInt32 maxThreadsAllowed, System::UInt32 maxConcurrency );
				void InternalDispose();

			private:
				void AddThreadToPool();
				// 线程的回调函数
				void ThreadPoolFunction();

			internal:
				static System::Int64 InterlockedMax(System::Int64% target, System::Int64 val );

			private:
				System::Int64							m_itemsPosted;
				System::Int64							m_numBusyThreads;
				System::Int64							m_itemsProcessed;
				System::Int64							m_numThreadsInPool;
				System::Int64							m_idleThreadTimeout;
				System::Int64							m_maxThreadsAllowed;
				System::Int64							m_maxThreadsEverInPool;

				System::Boolean							m_IsInit;
				System::Boolean							m_ThreadTerminate;

				System::Threading::SpinLock				m_Lock;
				IOCompletionPort						m_IOCP;
			};

		}
	}
}