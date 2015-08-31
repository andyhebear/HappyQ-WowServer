#pragma once

namespace Demo
{
	namespace Mmose
	{
		namespace Net
		{

			// �����̰߳�ȫ��
			[Demo::Mmose::Core::Common::MultiThreadedNoSupport( "zh-CHS", "��ǰ�������г�Աû������(��֧�־ֲ�����),��֧�ֶ��̲߳���" )]
			public ref class MessageBlock 
			{
			public:
				MessageBlock();
				~MessageBlock() { Free(); }
				!MessageBlock() { Free(); }

			public:
				property System::Int64 Size
				{
					System::Int64 get()
					{
						return m_BufferSize;
					}
				}

				property System::Int64 Length
				{
					System::Int64 get()
					{
						return m_WriteOffset - m_ReadOffset;
					}
				}

				property System::Int64 ReadLength
				{
					System::Int64 get()
					{
						return m_ReadOffset;
					}
				}

				property System::Int64 WriteLength
				{
					System::Int64 get()
					{
						return m_WriteOffset;
					}
				}

			public:
				 void ResetPointer();

				 System::IntPtr BasePointer();
				 System::IntPtr EndPointer();

				 void ReadPointer(System::Int64 iReadSize);
				 System::IntPtr ReadPointer();

				 void WritePointer(System::Int64 iWriteSize);
				 System::IntPtr WritePointer();

			internal:
				 void* HeadPointer() { return (void*)m_BaseBuffer; }
				 void Free();

				// ���仺�����ڴ�
				void SetBufferSize(System::Int32 iSize);

			private:
				LPBYTE				m_Buffer;
				LPBYTE				m_BaseBuffer;
				System::Int64		m_BufferSize;
				System::Int64		m_ReadOffset;
				System::Int64		m_WriteOffset;
			};

		}
	}
}