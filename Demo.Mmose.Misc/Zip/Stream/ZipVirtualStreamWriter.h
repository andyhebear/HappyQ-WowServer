#pragma once

class CkZipEntry;

namespace Demo
{
	namespace Mmose
	{
		namespace Zip
		{

			private ref class ZipVirtualStreamWriter : Demo::Mmose::Stream::VirtualStream
			{
				#pragma region zh-CHS 私有成员变量 | en Private Member Variables
			private:
				CkZipEntry* m_ZipEntry;
				#pragma endregion

				#pragma region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
			public:
				ZipVirtualStreamWriter(CkZipEntry* pZipEntry);
				~ZipVirtualStreamWriter(void);
				!ZipVirtualStreamWriter(void);
				#pragma endregion

				#pragma region zh-CHS 属性覆盖 | en Override Properties
			public:
				/// <summary>
				/// 
				/// </summary>
				property System::Boolean CanRead
				{
					virtual System::Boolean get() override { return false; }
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
					virtual System::Boolean get() override { return true; }
				}

				/// <summary>
				/// 
				/// </summary>
				property System::Int64 Length
				{
					virtual System::Int64 get() override { throw gcnew System::NotSupportedException(); }
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
				/// <returns></returns>
				virtual System::Int32 ReadByte() override;

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

				/// <summary>
				/// 
				/// </summary>
				/// <param name="value"></param>
				virtual void WriteByte( System::Byte value ) override;
				#pragma endregion
			};
		}
	}
}