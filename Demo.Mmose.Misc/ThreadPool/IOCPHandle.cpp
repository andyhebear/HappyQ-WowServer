#include "StdAfx.h"
#include "IOCPHandle.h"

namespace Demo
{
	namespace Mmose
	{
		namespace Threading
		{

			SafeIOCPHandle::SafeIOCPHandle() : SafeHandleZeroOrMinusOneIsInvalid(true)
			{
				m_Handle = (System::IntPtr)INVALID_HANDLE_VALUE;
			}

			bool SafeIOCPHandle::ReleaseHandle()
			{
				return ::CloseHandle( m_Handle.ToPointer() ) != FALSE;
			}

		}
	}
}