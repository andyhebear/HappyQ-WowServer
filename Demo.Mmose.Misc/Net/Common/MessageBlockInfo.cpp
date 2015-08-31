#include "StdAfx.h"
#include "CommonInc.h"
#include "MessageBlockInfo.h"

namespace Demo
{
	namespace Mmose
	{
		namespace Net
		{

			MessageBlockInfo::MessageBlockInfo() : m_OperatorType(Demo::Mmose::Net::TASK_WORKER_TYPE_NONE)
				, m_pMessageBlock(nullptr)
				, m_TransferredNumberOfBytes(0)
				, m_SendNumberOfBytes(0)

				, m_TaskManagerCallback(nullptr)
				, m_SendBufferStream(nullptr)
				, m_ProcessBufferStream(nullptr)

				, m_pServiceHandler(nullptr)
			{
			}

			void MessageBlockInfo::AllocMessageBlockInfo(void* pMessageBlock)
			{
				System::Runtime::InteropServices::GCHandle infoHandle = System::Runtime::InteropServices::GCHandle::Alloc( gcnew MessageBlockInfo() );

				void* pIntPtr = (void*)((LPBYTE)pMessageBlock + MessageBlockInfo::GetMessageBlockInfoSize());
				
				void* handle = ((System::IntPtr)infoHandle).ToPointer();

				::memcpy(pIntPtr, &handle, System::IntPtr::Size);
			}

			MessageBlockInfo^ MessageBlockInfo::GetMessageBlockInfo(Demo::Mmose::Net::MessageBlock^ messageBlock)
			{
				void* pIntPtr = (void*)((LPBYTE)messageBlock->HeadPointer() + MessageBlockInfo::GetMessageBlockInfoSize());

				void* handle = NULL;
				::memcpy(&handle, pIntPtr, System::IntPtr::Size);

				System::Runtime::InteropServices::GCHandle gcHandle = (System::Runtime::InteropServices::GCHandle)(System::IntPtr)handle;

				return safe_cast<MessageBlockInfo^>(gcHandle.Target);
			}


			MessageBlockInfo^ MessageBlockInfo::GetMessageBlockInfo(void* pMessageBlock)
			{
				void* pIntPtr = (void*)((LPBYTE)pMessageBlock + MessageBlockInfo::GetMessageBlockInfoSize());

				void* handle = NULL;
				::memcpy(&handle, pIntPtr, System::IntPtr::Size);

				System::Runtime::InteropServices::GCHandle gcHandle = (System::Runtime::InteropServices::GCHandle)(System::IntPtr)handle;

				return safe_cast<MessageBlockInfo^>(gcHandle.Target);
			}

			void MessageBlockInfo::FreeMessageBlockInfo(void* pMessageBlock)
			{
				void* pIntPtr = (void*)((LPBYTE)pMessageBlock + sizeof(OVERLAPPED) + sizeof(WSABUF));

				void* handle = NULL;
				::memcpy(&handle, pIntPtr, System::IntPtr::Size);

				if (handle != NULL)
				{
					System::Runtime::InteropServices::GCHandle gcHandle = (System::Runtime::InteropServices::GCHandle)(System::IntPtr)handle;
					gcHandle.Free();
				}
			}
			
			void MessageBlockInfo::CleanMessageBlockInfo(void* pMessageBlock)
			{
				::memset(pMessageBlock, 0, MessageBlockInfo::GetMessageBlockInfoSize());    
			}

			UINT32 MessageBlockInfo::GetMessageBlockInfoSize()
			{
				return sizeof(OVERLAPPED)  + sizeof(WSABUF);
			}

			void* MessageBlockInfo::GetWSABUF(Demo::Mmose::Net::MessageBlock^ messageBlock)
			{
				return (void*)((LPBYTE)messageBlock->HeadPointer() + sizeof(OVERLAPPED));
			}
	
			void* MessageBlockInfo::GetOVERLAPPED(Demo::Mmose::Net::MessageBlock^ messageBlock)
			{
				return messageBlock->HeadPointer();
			}

			UINT32 MessageBlockInfo::NeedSpaceSize()
			{
				return 512; // ±ØÐë´óÓÚ GetInfoSize();
			}

		}
	}
}