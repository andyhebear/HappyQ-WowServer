#pragma once

namespace Demo
{
	namespace Mmose
	{
		namespace Threading
		{

			private ref class SafeIOCPHandle : Microsoft::Win32::SafeHandles::SafeHandleZeroOrMinusOneIsInvalid
			{
			internal:
				SafeIOCPHandle();
				~SafeIOCPHandle() { ReleaseHandle(); }
				!SafeIOCPHandle() { ReleaseHandle(); }

			internal:
				property System::IntPtr Handle
				{
					System::IntPtr get() { return m_Handle; }
					void set(System::IntPtr handle) { m_Handle = handle;  }
				}

			protected:
				virtual bool ReleaseHandle() override;

			private:
				System::IntPtr m_Handle;
			};

		}
	}
}