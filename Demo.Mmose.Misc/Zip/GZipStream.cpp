#include "StdAfx.h"
#include "GZipStream.h"

#pragma managed(push, off)

#include <tchar.h>

#include "ChilkatVC9/include/CkCompression.h"
#include "ChilkatVC9/include/CkByteData.h"

#pragma managed(pop)

namespace Demo
{
	namespace Mmose
	{
		namespace Zip
		{

			GZipStream::GZipStream( System::IO::Stream^ streamData,  System::IO::Compression::CompressionMode compressionMode )
			{
			}

			GZipStream::GZipStream( System::IO::Stream^ streamData,  System::IO::Compression::CompressionMode compressionMode, System::Boolean leaveOpen )
			{
			}

			GZipStream::~GZipStream(void)
			{
			}

			GZipStream::!GZipStream(void)
			{
			}

			void GZipStream::Flush()
			{
				throw gcnew System::NotSupportedException();
			}

			System::Int32 GZipStream::Read( array<System::Byte>^ buffer, System::Int32 offset, System::Int32 count )
			{
				throw gcnew System::NotImplementedException();
			}

			System::Int64 GZipStream::Seek( System::Int64 offset, System::IO::SeekOrigin origin )
			{
				throw gcnew System::NotSupportedException();
			}

			void GZipStream::SetLength( System::Int64 value )
			{
				throw gcnew System::NotSupportedException();
			}

			void GZipStream::Write( array<System::Byte>^ buffer, System::Int32 offset, System::Int32 count )
			{
				throw gcnew System::NotImplementedException();
			}



			System::String^ GZipStream::CompressString( System::String^ strData,  EncodingMode resultEncodingMode )
			{
				throw gcnew System::NotImplementedException();
			}

			array<System::Byte>^ GZipStream::CompressString( System::String^ strData )
			{
				throw gcnew System::NotImplementedException();
			}

			System::String^ GZipStream::Compress( array<System::Byte>^ byteData, EncodingMode resultEncodingMode )
			{
				throw gcnew System::NotImplementedException();
			}

			array<System::Byte>^ GZipStream::Compress( array<System::Byte>^ byteData )
			{
				throw gcnew System::NotImplementedException();
			}

			System::String^ GZipStream::DecompressString( System::String^ strData, EncodingMode encodingMode )
			{
				throw gcnew System::NotImplementedException();
			}

			System::String^ GZipStream::DecompressString( array<System::Byte>^ byteData )
			{
				throw gcnew System::NotImplementedException();
			}

			array<System::Byte>^ GZipStream::Decompress( System::String^ strData, EncodingMode encodingMode )
			{
				throw gcnew System::NotImplementedException();
			}

			array<System::Byte>^ GZipStream::Decompress( array<System::Byte>^ byteData )
			{
				throw gcnew System::NotImplementedException();
			}

		}
	}
}