#include "StdAfx.h"
#include "IOCompletionPort.h"

namespace Demo
{
	namespace Mmose
	{
		namespace Threading
		{

			IOCompletionPort::IOCompletionPort()
			{
			}

			void IOCompletionPort::InitIOCompletionPort( System::UInt32 numConcurrentThreads )
			{
				HANDLE hIOCPHandle = ::CreateIoCompletionPort( INVALID_HANDLE_VALUE, NULL, 0, (DWORD)numConcurrentThreads );;
				if ( hIOCPHandle == NULL )
					throw gcnew System::InvalidOperationException("IOCompletionPort::IOCompletionPort(...) - hIOCPHandle == NULL error\n");
				else
					m_IOCPHandle.Handle = (System::IntPtr)hIOCPHandle;
			}

			void IOCompletionPort::PostStatus( System::Threading::WaitCallback^ waitCallback, System::Object^ oState )
			{
				System::Runtime::InteropServices::GCHandle callbackHandle = System::Runtime::InteropServices::GCHandle::Alloc( waitCallback );

				System::Runtime::InteropServices::GCHandle stateHandle;
				if ( oState != nullptr )
					stateHandle = System::Runtime::InteropServices::GCHandle::Alloc( oState );

				UINT iReturnValue = ::PostQueuedCompletionStatus( m_IOCPHandle.Handle.ToPointer(), 0, (ULONG_PTR)(LPVOID)(System::IntPtr)callbackHandle, (LPOVERLAPPED)(LPVOID)(( oState == nullptr ) ? System::IntPtr::Zero : (System::IntPtr)stateHandle) );
				if ( iReturnValue == 0 )
				{
					callbackHandle.Free();

					if ( oState != nullptr )
						stateHandle.Free();

					throw gcnew System::InvalidOperationException("IOCompletionPort::PostStatus(...) - iReturnValue == 0 error!\n");
				}
			}

			void IOCompletionPort::GetStatus( System::UInt32 milliseconds, System::Boolean% timedOut, System::Threading::WaitCallback^% waitCallback, System::Object^% oState )
			{
				HGLOBAL hState = NULL;
				HGLOBAL hCallback = NULL;
				DWORD numBytesTransferred;
				BOOL bReturn = ::GetQueuedCompletionStatus( m_IOCPHandle.Handle.ToPointer(), &numBytesTransferred, (PULONG_PTR)&hCallback, (LPOVERLAPPED*)&hState, milliseconds );
				DWORD ioError = ::GetLastError();

				if (bReturn == FALSE)
				{
					timedOut = ( ( hState == NULL ) && ( ioError == WAIT_TIMEOUT ) );
					if (timedOut == true)
						return;

					timedOut = ( ( numBytesTransferred == 0 ) && ( ioError == ERROR_OPERATION_ABORTED ) );
					if (timedOut == true)
						return;
				}

				// Get the delegate to the callback method
				if (hCallback != NULL)
				{
					System::Runtime::InteropServices::GCHandle gcHandle = (System::Runtime::InteropServices::GCHandle)(System::IntPtr)hCallback;
					waitCallback = (System::Threading::WaitCallback^)gcHandle.Target;
					gcHandle.Free();
				}

				// Get the parameter to pass to the callback method
				if ( hState != NULL )
				{
					System::Runtime::InteropServices::GCHandle stateHandle = (System::Runtime::InteropServices::GCHandle)(System::IntPtr)hState;
					oState = stateHandle.Target;
					stateHandle.Free();
				}
			}

		}
	}
}