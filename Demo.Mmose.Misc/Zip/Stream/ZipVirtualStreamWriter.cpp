#include "StdAfx.h"
#include "ZipVirtualStreamWriter.h"

#pragma managed(push, off)

#define WIN32_LEAN_AND_MEAN		// 从 Windows 头中排除极少使用的资料
#include <windows.h>

#include <tchar.h>

#include "../ChilkatVC9/include/CkByteData.h"
#include "../ChilkatVC9/include/CkZipEntry.h"

#pragma managed(pop)

namespace Demo
{
	namespace Mmose
	{
		namespace Zip
		{

			ZipVirtualStreamWriter::ZipVirtualStreamWriter(CkZipEntry* pZipEntry) : m_ZipEntry(pZipEntry)
			{
			}

			ZipVirtualStreamWriter::~ZipVirtualStreamWriter(void)
			{
				if (m_ZipEntry != NULL)
				{
					delete m_ZipEntry;
					m_ZipEntry = NULL;
				}
			}

			ZipVirtualStreamWriter::!ZipVirtualStreamWriter(void)
			{
				if (m_ZipEntry != NULL)
				{
					delete m_ZipEntry;
					m_ZipEntry = NULL;
				}
			}

			void ZipVirtualStreamWriter::Flush()
			{
			}

			System::Int32 ZipVirtualStreamWriter::Read( array<System::Byte>^ buffer, System::Int32 offset, System::Int32 count )
			{
				throw gcnew System::NotSupportedException();
			}

			System::Int32 ZipVirtualStreamWriter::ReadByte()
			{
				throw gcnew System::NotSupportedException();
			}

			System::Int64 ZipVirtualStreamWriter::Seek( System::Int64 offset, System::IO::SeekOrigin origin )
			{
				throw gcnew System::NotSupportedException();
			}

			void ZipVirtualStreamWriter::SetLength( System::Int64 value )
			{
				throw gcnew System::NotSupportedException();
			}

			void ZipVirtualStreamWriter::Write( array<System::Byte>^ buffer, System::Int32 offset, System::Int32 count )
			{
				if (buffer == nullptr)
					throw gcnew System::ArgumentNullException("ZipVirtualStreamWriter::Write(...) - buffer == nullptr error!");
				if (offset < 0)
					throw gcnew System::ArgumentOutOfRangeException("ZipVirtualStreamWriter::Write(...) - offset < 0 error!");
				if (count < 0)
					throw gcnew System::ArgumentOutOfRangeException("ZipVirtualStreamWriter::Write(...) - count < 0 error!");
				if ((buffer->Length - offset) < count)
					throw gcnew System::ArgumentException("ZipVirtualStreamWriter::Write(...) - (buffer->Length - offset) < count error!");

				System::Console::WriteLine( count.ToString() );

				CkByteData byteDeflated;

				pin_ptr<const unsigned char> bytePinPtr = &buffer[0];

				byteDeflated.append(bytePinPtr + offset, count);

				m_ZipEntry->AppendData(byteDeflated);
			}

			void ZipVirtualStreamWriter::WriteByte( System::Byte value )
			{
				CkByteData byteDeflated;
				byteDeflated.append(&value, 1);

				m_ZipEntry->AppendData(byteDeflated);
			}
		}
	}
}