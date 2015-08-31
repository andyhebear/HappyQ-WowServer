#include "StdAfx.h"
#include "DeflateStream.h"

#include <vcclr.h>

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

			DeflateStream::DeflateStream( System::IO::Stream^ streamData,  System::IO::Compression::CompressionMode compressionMode )
			{
				if (streamData == nullptr)
					throw gcnew System::ArgumentNullException("streamData");

				switch (compressionMode)
				{
				case System::IO::Compression::CompressionMode::Decompress:
					if (streamData->CanRead == false)
					{
						throw gcnew System::ArgumentException("streamData.CanRead == false", "streamData");
					}
					break;

				case System::IO::Compression::CompressionMode::Compress:
					if (streamData->CanWrite == false)
						throw gcnew System::ArgumentException("streamData.CanWrite == false", "streamData");

					break;
				default:
					throw gcnew System::ArgumentException("compressionMode ArgumentOutOfRange", "compressionMode");
				}

				m_StreamData = streamData;
				m_CompressionMode = compressionMode;
				m_Buffer = gcnew array<System::Byte>(0);
				m_ResidualBuffer = gcnew array<System::Byte>(0);
				m_ResidualRealSize = 0;
				m_LeaveOpen = false;
			}

			DeflateStream::DeflateStream( System::IO::Stream^ streamData,  System::IO::Compression::CompressionMode compressionMode, System::Boolean leaveOpen )
			{
				if (streamData == nullptr)
					throw gcnew System::ArgumentNullException("streamData");

				switch (compressionMode)
				{
				case System::IO::Compression::CompressionMode::Decompress:
					if (streamData->CanRead == false)
					{
						throw gcnew System::ArgumentException("streamData.CanRead == false", "streamData");
					}
					break;

				case System::IO::Compression::CompressionMode::Compress:
					if (streamData->CanWrite == false)
						throw gcnew System::ArgumentException("streamData.CanWrite == false", "streamData");

					break;
				default:
					throw gcnew System::ArgumentException("compressionMode ArgumentOutOfRange", "compressionMode");
				}

				m_StreamData = streamData;
				m_CompressionMode = compressionMode;
				m_Buffer = gcnew array<System::Byte>(0);
				m_ResidualBuffer = gcnew array<System::Byte>(0);
				m_ResidualRealSize = 0;
				m_LeaveOpen = leaveOpen;
			}

			DeflateStream::~DeflateStream(void)
			{
				if (m_LeaveOpen == true && m_StreamData != nullptr)
					m_StreamData->Close();

				m_StreamData = nullptr;
			}

			DeflateStream::!DeflateStream(void)
			{
				if (m_LeaveOpen == true && m_StreamData != nullptr)
					m_StreamData->Close();

				m_StreamData = nullptr;
			}

			void DeflateStream::Flush()
			{
				throw gcnew System::NotSupportedException();
			}

			System::Int32 DeflateStream::Read( array<System::Byte>^ buffer, System::Int32 offset, System::Int32 count )
			{
				if (m_CompressionMode != System::IO::Compression::CompressionMode::Decompress)
					throw gcnew System::InvalidOperationException("DeflateStream::Read(...) - m_CompressionMode != System::IO::Compression::CompressionMode::Decompress error!");

				if (buffer == nullptr)
					throw gcnew System::ArgumentNullException("DeflateStream::Read(...) - buffer == nullptr error!");
				if (offset < 0)
					throw gcnew System::ArgumentOutOfRangeException("DeflateStream::Read(...) - offset < 0 error!");
				if (count < 0)
					throw gcnew System::ArgumentOutOfRangeException("DeflateStream::Read(...) - count < 0 error!");
				if ((buffer->Length - offset) < count)
					throw gcnew System::ArgumentException("DeflateStream::Read(...) - (buffer->Length - offset) < count error!");
				if (m_StreamData == nullptr)
					throw gcnew System::ObjectDisposedException("m_StreamData", "DeflateStream::Read(...) - m_StreamData == nullptr error!");

				int iRealSize = buffer->Length - offset;

				if (m_ResidualBuffer->Length > 0 && m_ResidualRealSize > 0)
				{
					if (m_ResidualBuffer->Length < m_ResidualRealSize)
						throw gcnew System::InvalidOperationException("DeflateStream::Read(...) - m_ResidualBuffer->Length < m_ResidualRealSize error!");

					if (m_ResidualRealSize <= iRealSize)
					{
						int iResidualRealSize = m_ResidualRealSize;

						System::Buffer::BlockCopy(m_ResidualBuffer, 0, buffer, offset, iResidualRealSize);
						m_ResidualRealSize = 0;

						return iResidualRealSize;
					}
					else
					{
						System::Buffer::BlockCopy(m_ResidualBuffer, 0, buffer, offset, iRealSize);

						int iResidualSize = m_ResidualRealSize - iRealSize;
						int iResidualOffsetSrc = iRealSize;
						int iResidualOffsetDst = 0;

						while (iResidualSize > 0)
						{
							if (iResidualSize <= iRealSize)
							{
								System::Buffer::BlockCopy(m_ResidualBuffer, iResidualOffsetSrc, m_ResidualBuffer, iResidualOffsetDst, iResidualSize);

								iResidualSize = 0;
							}
							else
							{
								System::Buffer::BlockCopy(m_ResidualBuffer, iResidualOffsetSrc, m_ResidualBuffer, iResidualOffsetDst, iRealSize);

								iResidualSize -= iRealSize;
								iResidualOffsetSrc += iRealSize;
								iResidualOffsetDst += iRealSize;
							}
						}

						return iRealSize;
					}
				}

				if (m_Buffer->Length <= 0 )
					m_Buffer = gcnew array<System::Byte>(::Global::BUFFER_SIZE);

				int iLength = m_StreamData->Read(m_Buffer, 0, ::Global::BUFFER_SIZE);
				if (iLength <= 0)
					return 0;


				CkCompression compress;

				bool bSuccess = compress.UnlockComponent(GlobalString::COMPRESS_LICENCE);
				if (bSuccess == false)
					throw gcnew System::Exception( "DeflateStream::Decompress(...) - compress.UnlockComponent() == false error!" );

				compress.put_Algorithm(GlobalString::COMPRESS_ALGORITHM_DEFLATE);
				compress.put_Charset(GlobalString::COMPRESS_CHAR_SET);

				pin_ptr<const unsigned char> bytePinPtr = &m_Buffer[0];

				CkByteData byteCompress;
				byteCompress.append(bytePinPtr, iLength);

				CkByteData byteDeflated;


				bool bIsDeflate = compress.DecompressBytes(byteCompress, byteDeflated);
				if (bIsDeflate == false )
					throw gcnew System::Exception( "DeflateStream::Decompress(...) - compress.DecompressBytes() == false error!" );


				int iDeflatedSize = (int)byteDeflated.getSize();
				if (iRealSize >= iDeflatedSize )
				{
					System::Runtime::InteropServices::Marshal::Copy((System::IntPtr)(void*)byteDeflated.getBytes(), buffer, offset, iDeflatedSize);

					return iDeflatedSize;
				}
				else
				{
					System::Runtime::InteropServices::Marshal::Copy((System::IntPtr)(void*)byteDeflated.getBytes(), buffer, offset, iRealSize);

					 int iResidualSize = iDeflatedSize - iRealSize;
					 if (m_ResidualBuffer->Length < iResidualSize)
						 m_ResidualBuffer = gcnew array<System::Byte>(iResidualSize);

					System::Runtime::InteropServices::Marshal::Copy((System::IntPtr)(void*)(byteDeflated.getBytes() + iRealSize), m_ResidualBuffer, 0, iResidualSize);

					m_ResidualRealSize = iResidualSize;

					return iRealSize;
				}
			}

			System::Int64 DeflateStream::Seek( System::Int64 offset, System::IO::SeekOrigin origin )
			{
				throw gcnew System::NotSupportedException();
			}

			void DeflateStream::SetLength( System::Int64 value )
			{
				throw gcnew System::NotSupportedException();
			}

			void DeflateStream::Write( array<System::Byte>^ buffer, System::Int32 offset, System::Int32 count )
			{
				if (m_CompressionMode != System::IO::Compression::CompressionMode::Compress)
					throw gcnew System::InvalidOperationException("DeflateStream::Read(...) - m_CompressionMode != System::IO::Compression::CompressionMode::Decompress error!");

				if (buffer == nullptr)
					throw gcnew System::ArgumentNullException("DeflateStream::Read(...) - buffer == nullptr error!");
				if (offset < 0)
					throw gcnew System::ArgumentOutOfRangeException("DeflateStream::Read(...) - offset < 0 error!");
				if (count < 0)
					throw gcnew System::ArgumentOutOfRangeException("DeflateStream::Read(...) - count < 0 error!");
				if ((buffer->Length - offset) < count)
					throw gcnew System::ArgumentException("DeflateStream::Read(...) - (buffer->Length - offset) < count error!");
				if (m_StreamData == nullptr)
					throw gcnew System::ObjectDisposedException("m_StreamData", "DeflateStream::Read(...) - m_StreamData == nullptr error!");

				CkCompression compress;

				bool bSuccess = compress.UnlockComponent(GlobalString::COMPRESS_LICENCE);
				if (bSuccess == false)
					throw gcnew System::Exception( "DeflateStream::Compress(...) - compress.UnlockComponent() == false error!" );

				compress.put_Algorithm(GlobalString::COMPRESS_ALGORITHM_DEFLATE);
				compress.put_Charset(GlobalString::COMPRESS_CHAR_SET);

				pin_ptr<const unsigned char> bytePinPtr = &buffer[0];

				CkByteData byteCompress;
				byteCompress.append(bytePinPtr + offset, count);

				CkByteData byteDeflated;

				bool bIsDeflate = compress.CompressBytes(byteCompress, byteDeflated);
				if (bIsDeflate == false )
					throw gcnew System::Exception( "DeflateStream::CompressString(...) - compress.CompressString() == false error!" );

				int iDeflatedSize = (int)byteDeflated.getSize();

				if (m_Buffer->Length <= iDeflatedSize)
					m_Buffer = gcnew array<System::Byte>(iDeflatedSize);

				System::Runtime::InteropServices::Marshal::Copy((System::IntPtr)(void*)byteDeflated.getBytes(), m_Buffer, 0, iDeflatedSize);

				m_StreamData->Write(m_Buffer, 0, iDeflatedSize);
			}



			System::String^ DeflateStream::CompressString( System::String^ strData,  EncodingMode resultEncodingMode )
			{
				CkCompression compress;

				bool bSuccess = compress.UnlockComponent(GlobalString::COMPRESS_LICENCE);
				if (bSuccess == false)
					throw gcnew System::Exception( "DeflateStream::CompressString(...) - compress.UnlockComponent() == false error!" );

				compress.put_Algorithm(GlobalString::COMPRESS_ALGORITHM_DEFLATE);
				compress.put_Charset(GlobalString::COMPRESS_CHAR_SET);

				switch(resultEncodingMode)
				{
					case EncodingMode::Base64:
						compress.put_EncodingMode(GlobalString::COMPRESS_ENCODING_BASE64);
						break;
					case EncodingMode::Hex:
						compress.put_EncodingMode(GlobalString::COMPRESS_ENCODING_HEX);
						break;
					case EncodingMode::Url:
						compress.put_EncodingMode(GlobalString::COMPRESS_ENCODING_URL);
						break;
					case EncodingMode::QuotedPrintable:
						compress.put_EncodingMode(GlobalString::COMPRESS_ENCODING_QUOTED_PRINTABLE);
						break;
					default:
						break;
				}

				pin_ptr<const wchar_t> strPinPtr = ::PtrToStringChars(strData);

				CkString strCompress;
				strCompress.appendU(strPinPtr);

				CkString strDeflated;

				bool bIsDeflate = compress.CompressStringENC(strCompress, strDeflated);
				if (bIsDeflate == false )
					throw gcnew System::Exception( "DeflateStream::CompressString(...) - compress.CompressStringENC() == false error!" );

				return System::Runtime::InteropServices::Marshal::PtrToStringUni((System::IntPtr)(void*)strDeflated.getUnicode());
			}

			array<System::Byte>^ DeflateStream::CompressString( System::String^ strData )
			{
				CkCompression compress;

				bool bSuccess = compress.UnlockComponent(GlobalString::COMPRESS_LICENCE);
				if (bSuccess == false)
				{
					throw gcnew System::Exception( "DeflateStream::CompressString(...) - compress.UnlockComponent() == false error!" );
					return nullptr;
				}

				compress.put_Algorithm(GlobalString::COMPRESS_ALGORITHM_DEFLATE);
				compress.put_Charset(GlobalString::COMPRESS_CHAR_SET);

				pin_ptr<const wchar_t> strPinPtr = ::PtrToStringChars(strData);

				CkString strCompress;
				strCompress.appendU(strPinPtr);

				CkByteData byteDeflated;

				bool bIsDeflate = compress.CompressString(strCompress, byteDeflated);
				if (bIsDeflate == false )
					throw gcnew System::Exception( "DeflateStream::CompressString(...) - compress.CompressString() == false error!" );

				array<System::Byte>^ byteArray = gcnew array<System::Byte>(byteDeflated.getSize());
				System::Runtime::InteropServices::Marshal::Copy((System::IntPtr)(void*)byteDeflated.getBytes(), byteArray, 0, byteDeflated.getSize());

				return byteArray;
			}

			System::String^ DeflateStream::Compress( array<System::Byte>^ byteData, EncodingMode resultEncodingMode )
			{
				CkCompression compress;

				bool bSuccess = compress.UnlockComponent(GlobalString::COMPRESS_LICENCE);
				if (bSuccess == false)
					throw gcnew System::Exception( "DeflateStream::Compress(...) - compress.UnlockComponent() == false error!" );

				compress.put_Algorithm(GlobalString::COMPRESS_ALGORITHM_DEFLATE);
				compress.put_Charset(GlobalString::COMPRESS_CHAR_SET);

				switch(resultEncodingMode)
				{
					case EncodingMode::Base64:
						compress.put_EncodingMode(GlobalString::COMPRESS_ENCODING_BASE64);
						break;
					case EncodingMode::Hex:
						compress.put_EncodingMode(GlobalString::COMPRESS_ENCODING_HEX);
						break;
					case EncodingMode::Url:
						compress.put_EncodingMode(GlobalString::COMPRESS_ENCODING_URL);
						break;
					case EncodingMode::QuotedPrintable:
						compress.put_EncodingMode(GlobalString::COMPRESS_ENCODING_QUOTED_PRINTABLE);
						break;
					default:
						break;
				}

				pin_ptr<const unsigned char> bytePinPtr = &byteData[0];

				CkByteData byteCompress;
				byteCompress.append(bytePinPtr, byteData->Length);

				CkString strDeflated;

				bool bIsDeflate = compress.CompressBytesENC(byteCompress, strDeflated);
				if (bIsDeflate == false )
					throw gcnew System::Exception( "DeflateStream::CompressString(...) - compress.CompressStringENC() == false error!" );

				return System::Runtime::InteropServices::Marshal::PtrToStringUni((System::IntPtr)(void*)strDeflated.getUnicode());
			}

			array<System::Byte>^ DeflateStream::Compress( array<System::Byte>^ byteData )
			{
				CkCompression compress;

				bool bSuccess = compress.UnlockComponent(GlobalString::COMPRESS_LICENCE);
				if (bSuccess == false)
					throw gcnew System::Exception( "DeflateStream::Compress(...) - compress.UnlockComponent() == false error!" );

				compress.put_Algorithm(GlobalString::COMPRESS_ALGORITHM_DEFLATE);
				compress.put_Charset(GlobalString::COMPRESS_CHAR_SET);

				pin_ptr<const unsigned char> bytePinPtr = &byteData[0];

				CkByteData byteCompress;
				byteCompress.append(bytePinPtr, byteData->Length);

				CkByteData byteDeflated;

				bool bIsDeflate = compress.CompressBytes(byteCompress, byteDeflated);
				if (bIsDeflate == false )
					throw gcnew System::Exception( "DeflateStream::CompressString(...) - compress.CompressString() == false error!" );

				array<System::Byte>^ byteArray = gcnew array<System::Byte>(byteDeflated.getSize());
				System::Runtime::InteropServices::Marshal::Copy((System::IntPtr)(void*)byteDeflated.getBytes(), byteArray, 0, byteDeflated.getSize());

				return byteArray;
			}

			System::String^ DeflateStream::DecompressString( System::String^ strData, EncodingMode encodingMode )
			{
				CkCompression compress;

				bool bSuccess = compress.UnlockComponent(GlobalString::COMPRESS_LICENCE);
				if (bSuccess == false)
					throw gcnew System::Exception( "DeflateStream::DecompressString(...) - compress.UnlockComponent() == false error!" );

				compress.put_Algorithm(GlobalString::COMPRESS_ALGORITHM_DEFLATE);
				compress.put_Charset(GlobalString::COMPRESS_CHAR_SET);

				switch(encodingMode)
				{
					case EncodingMode::Base64:
						compress.put_EncodingMode(GlobalString::COMPRESS_ENCODING_BASE64);
						break;
					case EncodingMode::Hex:
						compress.put_EncodingMode(GlobalString::COMPRESS_ENCODING_HEX);
						break;
					case EncodingMode::Url:
						compress.put_EncodingMode(GlobalString::COMPRESS_ENCODING_URL);
						break;
					case EncodingMode::QuotedPrintable:
						compress.put_EncodingMode(GlobalString::COMPRESS_ENCODING_QUOTED_PRINTABLE);
						break;
					default:
						break;
				}

				pin_ptr<const wchar_t> strPinPtr = ::PtrToStringChars(strData);

				CkString strCompress;
				strCompress.appendU(strPinPtr);

				CkString strDeflated;

				bool bIsDeflate = compress.DecompressStringENC(strCompress, strDeflated);
				if (bIsDeflate == false )
					throw gcnew System::Exception( "DeflateStream::DecompressString(...) - compress.CompressStringENC() == false error!" );

				return System::Runtime::InteropServices::Marshal::PtrToStringUni((System::IntPtr)(void*)strDeflated.getUnicode());
			}

			System::String^ DeflateStream::DecompressString( array<System::Byte>^ byteData )
			{
				CkCompression compress;

				bool bSuccess = compress.UnlockComponent(GlobalString::COMPRESS_LICENCE);
				if (bSuccess == false)
					throw gcnew System::Exception( "DeflateStream::DecompressString(...) - compress.UnlockComponent() == false error!" );

				compress.put_Algorithm(GlobalString::COMPRESS_ALGORITHM_DEFLATE);
				compress.put_Charset(GlobalString::COMPRESS_CHAR_SET);

				pin_ptr<const unsigned char> bytePinPtr = &byteData[0];

				CkByteData byteCompress;
				byteCompress.append(bytePinPtr, byteData->Length);

				CkString strDeflated;

				bool bIsDeflate = compress.DecompressString(byteCompress, strDeflated);
				if (bIsDeflate == false )
					throw gcnew System::Exception( "DeflateStream::DecompressString(...) - compress.DecompressString() == false error!" );

				return System::Runtime::InteropServices::Marshal::PtrToStringUni((System::IntPtr)(void*)strDeflated.getUnicode());
			}

			array<System::Byte>^ DeflateStream::Decompress( System::String^ strData, EncodingMode encodingMode )
			{
				CkCompression compress;

				bool bSuccess = compress.UnlockComponent(GlobalString::COMPRESS_LICENCE);
				if (bSuccess == false)
					throw gcnew System::Exception( "DeflateStream::Decompress(...) - compress.UnlockComponent() == false error!" );

				compress.put_Algorithm(GlobalString::COMPRESS_ALGORITHM_DEFLATE);
				compress.put_Charset(GlobalString::COMPRESS_CHAR_SET);

				switch(encodingMode)
				{
					case EncodingMode::Base64:
						compress.put_EncodingMode(GlobalString::COMPRESS_ENCODING_BASE64);
						break;
					case EncodingMode::Hex:
						compress.put_EncodingMode(GlobalString::COMPRESS_ENCODING_HEX);
						break;
					case EncodingMode::Url:
						compress.put_EncodingMode(GlobalString::COMPRESS_ENCODING_URL);
						break;
					case EncodingMode::QuotedPrintable:
						compress.put_EncodingMode(GlobalString::COMPRESS_ENCODING_QUOTED_PRINTABLE);
						break;
					default:
						break;
				}

				pin_ptr<const wchar_t> strPinPtr = ::PtrToStringChars(strData);

				CkString strCompress;
				strCompress.appendU(strPinPtr);

				CkByteData byteDeflated;

				bool bIsDeflate = compress.DecompressBytesENC(strCompress, byteDeflated);
				if (bIsDeflate == false )
					throw gcnew System::Exception( "DeflateStream::Decompress(...) - compress.DecompressBytesENC() == false error!" );

				array<System::Byte>^ byteArray = gcnew array<System::Byte>(byteDeflated.getSize());
				System::Runtime::InteropServices::Marshal::Copy((System::IntPtr)(void*)byteDeflated.getBytes(), byteArray, 0, byteDeflated.getSize());

				return byteArray;
			}

			array<System::Byte>^ DeflateStream::Decompress( array<System::Byte>^ byteData )
			{
				CkCompression compress;

				bool bSuccess = compress.UnlockComponent(GlobalString::COMPRESS_LICENCE);
				if (bSuccess == false)
					throw gcnew System::Exception( "DeflateStream::Decompress(...) - compress.UnlockComponent() == false error!" );

				compress.put_Algorithm(GlobalString::COMPRESS_ALGORITHM_DEFLATE);
				compress.put_Charset(GlobalString::COMPRESS_CHAR_SET);

				pin_ptr<const unsigned char> bytePinPtr = &byteData[0];

				CkByteData byteCompress;
				byteCompress.append(bytePinPtr, byteData->Length);

				CkByteData byteDeflated;

				bool bIsDeflate = compress.DecompressBytes(byteCompress, byteDeflated);
				if (bIsDeflate == false )
					throw gcnew System::Exception( "DeflateStream::Decompress(...) - compress.DecompressBytes() == false error!" );

				array<System::Byte>^ byteArray = gcnew array<System::Byte>(byteDeflated.getSize());
				System::Runtime::InteropServices::Marshal::Copy((System::IntPtr)(void*)byteDeflated.getBytes(), byteArray, 0, byteDeflated.getSize());

				return byteArray;
			}

		}
	}
}