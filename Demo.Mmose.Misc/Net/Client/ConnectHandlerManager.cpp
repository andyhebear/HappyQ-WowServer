#include "StdAfx.h"
#include "ClientInc.h"
#include "ConnectHandlerManager.h"


namespace Demo
{
	namespace Mmose
	{
		namespace Net
		{

			ConnectHandlerManager::ConnectHandlerManager(SocketClient^ value) : m_SocketClient(value)
			{
			}

			Demo::Mmose::Net::ConnectHandler^ ConnectHandlerManager::ConnectHandler::get()
			{
				return m_SocketClient->ConnectHandler;
			}

			MessageBlock^ ConnectHandlerManager::GetNewSendMessageBlock()
			{
				MessageBlock^ pMessageBlock	= Client::MessageBlockManager->AcquireMessageBlock();
				if (pMessageBlock == nullptr)
					throw gcnew System::Exception("ConnectHandlerManager::GetNewSendMessageBlock(...) - pMessageBlock == nullptr error!\n");

				return pMessageBlock;
			}

		}
	}
}