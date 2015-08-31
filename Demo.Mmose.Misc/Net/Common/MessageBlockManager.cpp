#include "StdAfx.h"
#include "MessageBlock.h"
#include "MessageBlockManager.h"

namespace Demo
{
	namespace Mmose
	{
		namespace Net
		{

			MessageBlockManager::MessageBlockManager() : m_IsInit(false)
				, m_Misses(0)
				, m_CachedSize(1000)
				, m_BufferSize(4096)
			{
			}

			MessageBlock^ MessageBlockManager::AcquireMessageBlock()
			{
				MessageBlock^ messageBlock = nullptr;

				while ( m_InstanceStack.TryPop( messageBlock ) == false )
				{
					System::Threading::Interlocked::Increment(m_Misses);

					for(int iIndex = 0; iIndex < m_CachedSize; iIndex++)
					{
						MessageBlock^ pMsgBlock	= gcnew MessageBlock();

						if(pMsgBlock != nullptr)
						{
							pMsgBlock->SetBufferSize(m_BufferSize);
							pMsgBlock->ResetPointer();

							m_InstanceStack.Push(pMsgBlock);
						}
					}
				}

				if (messageBlock == nullptr)
					throw("MessageBlockManager::AcquireMessageBlock(...) - messageBlock == nullptr error!");
				else
					messageBlock->ResetPointer();

				return messageBlock;
			}

			void MessageBlockManager::ReleaseMessageBlock(MessageBlock^ pMsgBlock)
			{
				if (pMsgBlock == nullptr)
					throw("MessageBlockManager::ReleaseMessageBlock(...) - pMsgBlock == NULL error!");

				m_InstanceStack.Push(pMsgBlock);
			}

			void MessageBlockManager::Init(System::UInt32 iNums, System::UInt32 iDefaultSize)
			{
				if (m_IsInit == true)
					throw("MessageBlockManager::Init(...) - m_IsInit == true error!");

				m_Lock.Enter();
				{
					do
					{
						if (m_IsInit == true)
							break;

						m_CachedSize	= iNums;
						m_BufferSize	= iDefaultSize;

						for(int iIndex = 0; iIndex < m_CachedSize; iIndex++)
						{
							MessageBlock^ pMsgBlock	= gcnew MessageBlock();
							if(pMsgBlock != nullptr)
							{
								pMsgBlock->SetBufferSize(m_BufferSize);
								pMsgBlock->ResetPointer();

								m_InstanceStack.Push(pMsgBlock);
							}
						}

						m_IsInit = true;

					} while (false);
				}
				m_Lock.Exit();
			}

			void MessageBlockManager::Fini()
			{
		        if (m_IsInit == false)
					return;

				m_Lock.Enter();
				{
					do
					{
						if (m_IsInit == false)
							break;

						MessageBlock^ messageBlock = nullptr;
						while ( m_InstanceStack.TryPop( messageBlock ) == true )
						{
							if (messageBlock != nullptr)
							{
								messageBlock->Free();
								messageBlock = nullptr;
							}
						}

						m_IsInit = false;

					} while (false);
				}
				m_Lock.Exit();
			}

		}
	}
}