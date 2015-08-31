#include "StdAfx.h"
#include "ZipArchive.h"
#include "ZipVirtualStreamReader.h"

#pragma managed(push, off)

#include <tchar.h>

#include "../ChilkatVC9/include/CkByteData.h"
#include "../ChilkatVC9/include/CkZip.h"
#include "../ChilkatVC9/include/CkZipEntry.h"

#pragma managed(pop)

namespace Demo
{
	namespace Mmose
	{
		namespace Zip
		{

			ZipArchive::ZipArchive(void) : m_ImplZip(new CkZip), m_PackageName(System::String::Empty), m_StreamWriterList(gcnew System::Collections::Generic::List<Demo::Mmose::Zip::ZipVirtualStreamWriter^>())
			{
				if ( m_ImplZip->UnlockComponent(GlobalString::ZIP_LICENCE) == false)
					throw gcnew System::Exception( "ZipArchive::ZipArchive(...) - m_ImplZip->UnlockComponent() == false error!" );

				m_ImplZip->put_Utf8(true);
			}

			ZipArchive::~ZipArchive(void)
			{
				if (m_ImplZip != NULL)
				{
					for each ( Demo::Mmose::Zip::ZipVirtualStreamWriter^ streamWriter in m_StreamWriterList )
						streamWriter->Close();

					if (m_StreamWriterList->Count > 0)
						m_ImplZip->WriteZipAndClose();
					else
						m_ImplZip->CloseZip();

					delete m_ImplZip;
					m_ImplZip = NULL;

					m_StreamWriterList->Clear();

					m_PackageName = System::String::Empty;
				}
			}

			ZipArchive::!ZipArchive(void)
			{
				if (m_ImplZip != NULL)
				{
					for each ( Demo::Mmose::Zip::ZipVirtualStreamWriter^ streamWriter in m_StreamWriterList )
						streamWriter->Close();

					if (m_StreamWriterList->Count > 0)
						m_ImplZip->WriteZipAndClose();
					else
						m_ImplZip->CloseZip();

					delete m_ImplZip;
					m_ImplZip = NULL;

					m_StreamWriterList->Clear();

					m_PackageName = System::String::Empty;
				}
			}

			Demo::Mmose::Stream::VirtualStream^ ZipArchive::OpenFile( System::String^ strFileName, System::IO::FileAccess fileAccess )
			{
				if (fileAccess != System::IO::FileAccess::Read)
					throw gcnew System::ArgumentException("fileAccess != System::IO::FileAccess::Read", "fileAccess");

				array<System::Byte>^ utf8Bytes = System::Text::Encoding::UTF8->GetBytes(strFileName);
				pin_ptr<const unsigned char> bytePinPtr = &utf8Bytes[0];

				CkZipEntry* pZipEntry = m_ImplZip->GetEntryByName((const char*)bytePinPtr);
				if (pZipEntry == NULL)
					return nullptr;

				CkByteData byteInflate;

				bool bResult = pZipEntry->Inflate(byteInflate);

				delete pZipEntry;

				if (bResult == false)
					return nullptr;

				array<System::Byte>^ byteArray = gcnew array<System::Byte>(byteInflate.getSize());
				System::Runtime::InteropServices::Marshal::Copy((System::IntPtr)(void*)byteInflate.getBytes(), byteArray, 0, byteInflate.getSize());

				return gcnew Demo::Mmose::Zip::ZipVirtualStreamReader(byteArray);
			}

			Demo::Mmose::Stream::VirtualStream^ ZipArchive::CreateFile( System::String^ strFileName )
			{
				array<System::Byte>^ utf8Bytes = System::Text::Encoding::UTF8->GetBytes(strFileName);
				pin_ptr<const unsigned char> bytePinPtr = &utf8Bytes[0];

				CkZipEntry* pZipEntry = m_ImplZip->GetEntryByName((const char*)bytePinPtr);
				if (pZipEntry != NULL)
				{
					delete pZipEntry;
					return nullptr;
				}

				pZipEntry = m_ImplZip->AppendNew((const char*)bytePinPtr);
				if (pZipEntry == NULL)
					return nullptr;

				Demo::Mmose::Zip::ZipVirtualStreamWriter^ streamWriter = gcnew Demo::Mmose::Zip::ZipVirtualStreamWriter(pZipEntry);

				m_StreamWriterList->Add(streamWriter);

				return streamWriter;
			}

			void ZipArchive::DeleteFile( System::String^ strFileName )
			{
				array<System::Byte>^ utf8Bytes = System::Text::Encoding::UTF8->GetBytes(strFileName);
				pin_ptr<const unsigned char> bytePinPtr = &utf8Bytes[0];

				CkZipEntry* pZipEntry = m_ImplZip->GetEntryByName((const char*)bytePinPtr);
				if (pZipEntry == NULL)
					return;
				 
				 m_ImplZip->DeleteEntry(*pZipEntry);

				 delete pZipEntry;

				 m_ImplZip->WriteZip();
			}

			System::Boolean ZipArchive::OpenPackage( System::String^ strArchivePath )
			{
				array<System::Byte>^ utf8Bytes = System::Text::Encoding::UTF8->GetBytes(strArchivePath);
				pin_ptr<const unsigned char> bytePinPtr = &utf8Bytes[0];

				bool bResult = m_ImplZip->OpenZip((const char*)bytePinPtr);

				if (bResult == true)
					m_PackageName = strArchivePath;

				return bResult;
			}

			System::Boolean ZipArchive::CreatePackage( System::String^ strArchivePath )
			{
				if (System::IO::File::Exists(strArchivePath) == true)
					return false;

				array<System::Byte>^ utf8Bytes = System::Text::Encoding::UTF8->GetBytes(strArchivePath);
				pin_ptr<const unsigned char> bytePinPtr = &utf8Bytes[0];

				bool bResult = m_ImplZip->NewZip((const char*)bytePinPtr);

				if (bResult == true)
				{
					m_ImplZip->WriteZip();
					m_PackageName = strArchivePath;
				}

				return bResult;
			}

			void ZipArchive::ClosePackage()
			{
				m_ImplZip->CloseZip();
			}

			Demo::Mmose::Stream::IStreamArchive^ ZipArchive::CreateInstance()
			{
				return gcnew ZipArchive();
			}
		}
	}
}