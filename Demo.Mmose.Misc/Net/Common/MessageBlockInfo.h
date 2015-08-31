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
				Demo::Mmose::Net::MessageBlock^	m_pMessageBlock;			// MessageBlock的地址
			public:
				property Demo::Mmose::Net::MessageBlock^ MessageBlock
				{
					Demo::Mmose::Net::MessageBlock^ get()
					{
						return m_pMessageBlock;
					}
				};

			public:
				DelegateTaskManagerCallback^	m_TaskManagerCallback;		// TaskManager线程的处理调用(没有使用)
				DelegateSendBufferStream^		m_SendBufferStream;			// TaskWorker线程的处理调用
				DelegateProcessBufferStream^	m_ProcessBufferStream;		// TaskWorker线程的处理调用

			public:
				MessageBlockType        m_OperatorType;				// 当前操作类型
				System::UInt32          m_TransferredNumberOfBytes;	// 表示已传送(发送/接收)的数据
				System::UInt32          m_SendNumberOfBytes;		// 表示需要发送的数

			public: 
				// Server端 需要的数据(==ServiceHandler^)
				System::Object^			m_pServiceHandler;          // 接受或发送完成的处理调用

			internal:
				static UINT32 NeedSpaceSize();
				static UINT32 GetMessageBlockInfoSize();
				static void AllocMessageBlockInfo(void* pMessageBlock);
				static void FreeMessageBlockInfo(void* pMessageBlock);
				static void CleanMessageBlockInfo(void* pMessageBlock);

			internal:
				static void* GetWSABUF(Demo::Mmose::Net::MessageBlock^ messageBlock);		// 完成端口需要的数据
				static void* GetOVERLAPPED(Demo::Mmose::Net::MessageBlock^ messageBlock);	// 发送或接收的数据结构

				static MessageBlockInfo^ GetMessageBlockInfo(Demo::Mmose::Net::MessageBlock^ messageBlock);
				static MessageBlockInfo^ GetMessageBlockInfo(void* pMessageBlock);
			};

		}
	}
}