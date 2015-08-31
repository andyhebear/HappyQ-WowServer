#include "StdAfx.h"
#include "CommonInc.h"
#include "MessageBlock.h"

namespace Demo
{
	namespace Mmose
	{
		namespace Net
		{

			MessageBlock::MessageBlock() : m_Buffer(NULL)
				, m_BaseBuffer(NULL)
				, m_BufferSize(0)
				, m_ReadOffset(0)
				, m_WriteOffset(0)
			{
			}

			void MessageBlock::ResetPointer()
			{
				m_ReadOffset = 0;
				m_WriteOffset = 0;
			}

			System::IntPtr MessageBlock::BasePointer()
			{
				return (System::IntPtr)((void*)m_Buffer);
			}

			System::IntPtr MessageBlock::EndPointer()
			{
				return (System::IntPtr)((void*)(m_Buffer + m_BufferSize));
			}

			void MessageBlock::ReadPointer(System::Int64 iReadSize)
			{
				m_ReadOffset += iReadSize;
			}

			System::IntPtr MessageBlock::ReadPointer()
			{
				return (System::IntPtr)((void*)(m_Buffer + m_ReadOffset));
			}

			void MessageBlock::WritePointer(System::Int64 iWriteSize)
			{
				m_WriteOffset += iWriteSize;
			}

			System::IntPtr MessageBlock::WritePointer()
			{
				return (System::IntPtr)((void*)(m_Buffer + m_WriteOffset));
			}

			void MessageBlock::SetBufferSize(System::Int32 iSize)
			{
				Free();

				m_BufferSize = iSize;
				m_BaseBuffer = new BYTE[iSize + MessageBlockInfo::NeedSpaceSize()/*保留一些空间用来传输一些特殊的数据*/];
				m_Buffer = m_BaseBuffer + MessageBlockInfo::NeedSpaceSize();

				MessageBlockInfo::CleanMessageBlockInfo(m_BaseBuffer);
				MessageBlockInfo::AllocMessageBlockInfo(m_BaseBuffer);
				MessageBlockInfo^ pMessageBlockInfo = MessageBlockInfo::GetMessageBlockInfo(m_BaseBuffer);

				if (pMessageBlockInfo == nullptr)
					throw gcnew System::Exception("MessageBlock::SetBufferSize(...) - pMessageBlockInfo == nullptr error\n");
				else
					pMessageBlockInfo->m_pMessageBlock = this;
			}

			void MessageBlock::Free()
			{
				if(m_BaseBuffer != NULL)
				{
					MessageBlockInfo^ pMessageBlockInfo = MessageBlockInfo::GetMessageBlockInfo(m_BaseBuffer);
					if (pMessageBlockInfo == nullptr)
						throw gcnew System::Exception("MessageBlock::Free(...) - pMessageBlockInfo == nullptr error\n");
					else
						pMessageBlockInfo->m_pMessageBlock = nullptr;

					MessageBlockInfo::FreeMessageBlockInfo(m_BaseBuffer);

					delete[] m_BaseBuffer;
					m_BaseBuffer = NULL;
					m_Buffer = NULL;
				}

				m_BufferSize = 0;
				m_ReadOffset = 0;
				m_WriteOffset = 0;
			}

		}
	}
}