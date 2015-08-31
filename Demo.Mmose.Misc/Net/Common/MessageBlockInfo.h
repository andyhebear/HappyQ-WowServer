#pragma once

namespace Demo
{
	namespace Mmose
	{
		namespace Net
		{

			ref class MessageBlock;
			private delegate void DelegateTaskManagerCallback(MessageBlock^ refMessageBlock);
			private delegate void DelegateSendBufferStream(MessageBlock^ refMessageBlock);
			private delegate void DelegateProcessBufferStream(MessageBlock^ refMessageBlock);

			private enum MessageBlockType
			{
				TASK_WORKER_TYPE_NONE			= 0,
				TASK_WORKER_TYPE_ACCEPT			= 1,
				TASK_WORKER_TYPE_SEND			= 2,
				TASK_WORKER_TYPE_RECEIVE		= 3,
				TASK_WORKER_TYPE_PROCSS			= 4
			};

			private ref class MessageBlockInfo
			{
			internal:
				MessageBlockInfo();

			internal:
				Demo::Mmose::Net::MessageBlock^	m_pMessageBlock;			// MessageBlock�ĵ�ַ
			public:
				property Demo::Mmose::Net::MessageBlock^ MessageBlock
				{
					Demo::Mmose::Net::MessageBlock^ get()
					{
						return m_pMessageBlock;
					}
				};

			public:
				DelegateTaskManagerCallback^	m_TaskManagerCallback;		// TaskManager�̵߳Ĵ������(û��ʹ��)
				DelegateSendBufferStream^		m_SendBufferStream;			// TaskWorker�̵߳Ĵ������
				DelegateProcessBufferStream^	m_ProcessBufferStream;		// TaskWorker�̵߳Ĵ������

			public:
				MessageBlockType        m_OperatorType;				// ��ǰ��������
				System::UInt32          m_TransferredNumberOfBytes;	// ��ʾ�Ѵ���(����/����)������
				System::UInt32          m_SendNumberOfBytes;		// ��ʾ��Ҫ���͵���

			public: 
				// Server�� ��Ҫ������(==ServiceHandler^)
				System::Object^			m_pServiceHandler;          // ���ܻ�����ɵĴ������

			internal:
				static UINT32 NeedSpaceSize();
				static UINT32 GetMessageBlockInfoSize();
				static void AllocMessageBlockInfo(void* pMessageBlock);
				static void FreeMessageBlockInfo(void* pMessageBlock);
				static void CleanMessageBlockInfo(void* pMessageBlock);

			internal:
				static void* GetWSABUF(Demo::Mmose::Net::MessageBlock^ messageBlock);		// ��ɶ˿���Ҫ������
				static void* GetOVERLAPPED(Demo::Mmose::Net::MessageBlock^ messageBlock);	// ���ͻ���յ����ݽṹ

				static MessageBlockInfo^ GetMessageBlockInfo(Demo::Mmose::Net::MessageBlock^ messageBlock);
				static MessageBlockInfo^ GetMessageBlockInfo(void* pMessageBlock);
			};

		}
	}
}