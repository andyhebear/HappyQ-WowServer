#include "StdAfx.h"
#include "ZipVirtualStreamReader.h"


namespace Demo
{
	namespace Mmose
	{
		namespace Zip
		{

			ZipVirtualStreamReader::ZipVirtualStreamReader(array<System::Byte>^ stream) : m_Position(0)
			{
				if (stream == nullptr)
					throw gcnew System::ArgumentNullException("ZipVirtualStreamReader::Read(...) - stream == nullptr error!");

				m_ByteStream = stream;
			}

			ZipVirtualStreamReader::~ZipVirtualStreamReader(void)
			{
				if (m_ByteStream != nullptr)
					m_ByteStream = nullptr;
			}

			ZipVirtualStreamReader::!ZipVirtualStreamReader(void)
			{
				if (m_ByteStream != nullptr)
					m_ByteStream = nullptr;
			}

			void ZipVirtualStreamReader::Flush()
			{
				throw gcnew System::NotSupportedException();
			}

			System::Int32 ZipVirtualStreamReader::Read( array<System::Byte>^ buffer, System::Int32 offset, System::Int32 count )
			{
				if (buffer == nullptr)
					throw gcnew System::ArgumentNullException("ZipVirtualStreamReader::Read(...) - buffer == nullptr error!");
				if (offset < 0)
					throw gcnew System::ArgumentOutOfRangeException("ZipVirtualStreamReader::Read(...) - offset < 0 error!");
				if (count < 0)
					throw gcnew System::ArgumentOutOfRangeException("ZipVirtualStreamReader::Read(...) - count < 0 error!");
				if ((buffer->Length - offset) < count)
					throw gcnew System::ArgumentException("ZipVirtualStreamReader::Read(...) - (buffer->Length - offset) < count error!");

				int iResidualSize = m_ByteStream->Length - (int)m_Position;
				if (iResidualSize <= 0)
					return 0;

				if (iResidualSize > count)
					iResidualSize = count;

				System::Buffer::BlockCopy(m_ByteStream, (int)m_Position, buffer, offset, iResidualSize);

				m_Position += iResidualSize;

				return iResidualSize;
			}

			System::Int32 ZipVirtualStreamReader::ReadByte()
			{
				__int64 newPosition = m_Position + 1;

				if (newPosition < 0)
					throw gcnew System::ArgumentOutOfRangeException("ZipVirtualStreamReader::ReadByte(...) - newPosition < 0 error!");

				if (newPosition >= m_ByteStream->Length)
					throw gcnew System::ArgumentOutOfRangeException("ZipVirtualStreamReader::ReadByte(...) - newPosition >= m_ByteStream->Length error!");

				m_Position++;

				return m_ByteStream[m_Position];
			}

			System::Int64 ZipVirtualStreamReader::Seek( System::Int64 offset, System::IO::SeekOrigin origin )
			{
				switch (origin)
				{
				case System::IO::SeekOrigin::Begin:

					if (offset < 0)
						throw gcnew System::IO::IOException("ZipVirtualStreamReader::Seek(...) - SeekBeforeBegin error!");

					m_Position = offset;

					break;
				case System::IO::SeekOrigin::End:

					if ((m_ByteStream->Length + offset) < 0)
						throw gcnew System::IO::IOException ("ZipVirtualStreamReader::Seek(...) - SeekBeforeEnd error!");

					m_Position = m_ByteStream->Length + offset;

					break;
				case System::IO::SeekOrigin::Current:

					if ((m_Position + offset) < 0)
						throw gcnew System::IO::IOException ("ZipVirtualStreamReader::Seek(...) - SeekBeforeCurrent error!");

					m_Position = m_Position + offset;

					break;
				default:

					throw gcnew System::ArgumentException ("origin != System::IO::SeekOrigin", "origin");

					break;
				}

				return m_Position;
			}

			void ZipVirtualStreamReader::SetLength( System::Int64 value )
			{
				throw gcnew System::NotSupportedException();
			}

			void ZipVirtualStreamReader::Write( array<System::Byte>^ buffer, System::Int32 offset, System::Int32 count )
			{
				throw gcnew System::NotSupportedException();
			}

			void ZipVirtualStreamReader::WriteByte( System::Byte value )
			{
				throw gcnew System::NotSupportedException();
			}
		}
	}
}