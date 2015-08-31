#pragma once

#include "Demo.Mmose.Zip.h"

namespace Demo
{
	namespace Mmose
	{
		namespace Zip
		{

			public ref class LzwStream : public System::IO::Stream
			{
				#pragma region zh-CHS 私有成员变量 | en Private Member Variables
			private:
				System::IO::Compression::CompressionMode m_CompressionMode;
				System::IO::Stream^ m_StreamData;
				array<System::Byte>^ m_Buffer;
				array<System::Byte>^ m_ResidualBuffer;
				System::Int32 m_ResidualRealSize;
				System::Boolean m_LeaveOpen;
				#pragma endregion

				#pragma region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
			public:
				LzwStream(System::IO::Stream^ streamData,  System::IO::Compression::CompressionMode compressionMode );
				LzwStream(System::IO::Stream^ streamData,  System::IO::Compression::CompressionMode compressionMode, System::Boolean leaveOpen );
				~LzwStream(void);
				!LzwStream(void);
				#pragma endregion

				#pragma region zh-CHS 共有静态方法 | en Public Static Methods
			public:
				/// <summary>
				/// 
				/// </summary>
				/// <param name="path"></param>
				/// <param name="access"></param>
				/// <returns></returns>
				static System::String^ CompressString( System::String^ strData,  EncodingMode resultEncodingMode );

				/// <summary>
				/// 
				/// </summary>
				/// <param name="path"></param>
				/// <param name="access"></param>
				/// <returns></returns>
				static array<System::Byte>^ CompressString( System::String^ strData );

				/// <summary>
				/// 
				/// </summary>
				/// <param name="path"></param>
				/// <param name="access"></param>
				/// <returns></returns>
				static System::String^ Compress( array<System::Byte>^ strData, EncodingMode resultEncodingMode );

				/// <summary>
				/// 
				/// </summary>
				/// <param name="path"></param>
				/// <param name="access"></param>
				/// <returns></returns>
				static array<System::Byte>^ Compress( array<System::Byte>^ strData );

				/// <summary>
				/// 
				/// </summary>
				/// <param name="path"></param>
				/// <returns></returns>
				static System::String^ DecompressString( System::String^ strData, EncodingMode encodingMode );

				/// <summary>
				/// 
				/// </summary>
				/// <param name="path"></param>
				/// <returns></returns>
				static System::String^ DecompressString( array<System::Byte>^ strData );

				/// <summary>
				/// 
				/// </summary>
				/// <param name="path"></param>
				/// <returns></returns>
				static array<System::Byte>^ Decompress( System::String^ strData, EncodingMode encodingMode );

				/// <summary>
				/// 
				/// </summary>
				/// <param name="path"></param>
				/// <returns></returns>
				static array<System::Byte>^ Decompress( array<System::Byte>^ strData );
				#pragma endregion

				#pragma region zh-CHS 属性覆盖 | en Override Properties
			public:
				/// <summary>
				/// 
				/// </summary>
				property System::IO::Stream^ BaseStream
				{
					virtual System::IO::Stream^ get() { return m_StreamData; }
				}

				/// <summary>
				/// 
				/// </summary>
				property System::Boolean CanRead
				{
					virtual System::Boolean get() override
					{
						if (m_StreamData == nullptr)
							return false;

						return ((m_CompressionMode == System::IO::Compression::CompressionMode::Decompress) && m_StreamData->CanRead);
					}
				}

				/// <summary>
				/// 
				/// </summary>
				property System::Boolean CanSeek
				{
					virtual System::Boolean get() override { return false; }
				}

				/// <summary>
				/// 
				/// </summary>
				property System::Boolean CanWrite
				{
					virtual System::Boolean get() override
					{
						if (m_StreamData == nullptr)
							return false;

						return ((m_CompressionMode == System::IO::Compression::CompressionMode::Compress) && m_StreamData->CanWrite);
					}
				}

				/// <summary>
				/// 
				/// </summary>
				property System::Int64 Length
				{
					virtual System::Int64 get() override { return /*m_FileStream.Length*/0; }
				}

				/// <summary>
				/// 
				/// </summary>
				property System::Int64 Position
				{
					virtual System::Int64 get() override { throw gcnew System::NotSupportedException(); }
					virtual void set(System::Int64 value) override { throw gcnew System::NotSupportedException(); }
				}
				#pragma endregion

				#pragma region zh-CHS 方法覆盖 | en Override Methods
			public:
				/// <summary>
				/// 
				/// </summary>
				virtual void Flush() override;

				/// <summary>
				/// 
				/// </summary>
				/// <param name="buffer"></param>
				/// <param name="offset"></param>
				/// <param name="count"></param>
				/// <returns></returns>
				virtual System::Int32 Read( array<System::Byte>^ buffer, System::Int32 offset, System::Int32 count ) override;

				/// <summary>
				/// 
				/// </summary>
				/// <param name="offset"></param>
				/// <param name="origin"></param>
				/// <returns></returns>
				virtual System::Int64 Seek( System::Int64 offset, System::IO::SeekOrigin origin ) override;

				/// <summary>
				/// 
				/// </summary>
				/// <param name="value"></param>
				virtual void SetLength( System::Int64 value ) override;

				/// <summary>
				/// 
				/// </summary>
				/// <param name="buffer"></param>
				/// <param name="offset"></param>
				/// <param name="count"></param>
				virtual void Write( array<System::Byte>^ buffer, System::Int32 offset, System::Int32 count ) override;
				#pragma endregion
			};
		}
	}
}