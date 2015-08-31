#pragma once

namespace Demo
{
	namespace Mmose
	{
		namespace Net
		{

			// 线程安全的
			ref class MessageBlock;

			[Demo::Mmose::Core::Common::MultiThreadedSupport( "zh-CHS", "当前的类所有成员都可锁定,支持多线程操作" )]
			private ref class MessageBlockManager
			{
			public:
				MessageBlockManager();
				~MessageBlockManager() { Fini(); }
				!MessageBlockManager() { Fini(); }

			public:
				property System::Boolean IsInit
				{
					System::Boolean get()
					{
						return m_IsInit;
					}
				}

			public:
				void Init(System::UInt32 iNums, System::UInt32 iDefaultSize);
				void Fini();

				MessageBlock^ AcquireMessageBlock();
				void ReleaseMessageBlock(MessageBlock^ pMsgBlock);

			private:
				System::Boolean			m_IsInit;

				System::Int32			m_Misses;
				System::Int32			m_CachedSize;
				System::Int32			m_BufferSize;

				System::Threading::SpinLock										m_Lock;
				System::Threading::Collections::ConcurrentStack<MessageBlock^>	m_InstanceStack;
			};

		}
	}
}