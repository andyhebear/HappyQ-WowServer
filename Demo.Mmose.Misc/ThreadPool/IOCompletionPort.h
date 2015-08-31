#pragma once

#include "IOCPHandle.h"

namespace Demo
{
	namespace Mmose
	{
		namespace Threading
		{

			private ref class IOCompletionPort
			{
			internal:
				IOCompletionPort();
				~IOCompletionPort() { InternalDispose(); }
				!IOCompletionPort() { InternalDispose(); }

			internal:
				void InitIOCompletionPort( System::UInt32 numConcurrentThreads );
				void PostStatus( System::Threading::WaitCallback^ waitCallback, System::Object^ oState );
				void GetStatus( System::UInt32 milliseconds, System::Boolean% timedOut, System::Threading::WaitCallback^% waitCallback, System::Object^% oState );

			internal:
				void InternalDispose() { m_IOCPHandle.Close(); }

			private:
				SafeIOCPHandle m_IOCPHandle;
			};

		}
	}
}