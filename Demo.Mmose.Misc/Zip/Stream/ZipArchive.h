#pragma once

#include "..\Demo.Mmose.Zip.h"
#include "ZipVirtualStreamWriter.h"

class CkZip;

namespace Demo
{
	namespace Mmose
	{
		namespace Zip
		{

			public ref class ZipArchive : public Demo::Mmose::Stream::IStreamArchive
			{
				#pragma region zh-CHS 私有成员变量 | en Private Member Variables
			private:
				CkZip* m_ImplZip;
				System::String^ m_PackageName;
				System::Collections::Generic::List<Demo::Mmose::Zip::ZipVirtualStreamWriter^>^ m_StreamWriterList;
				#pragma endregion

				#pragma region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
			public:
				ZipArchive(void);
				~ZipArchive(void);
				!ZipArchive(void);
				#pragma endregion

				#pragma region zh-CHS IStreamArchive 实现 | en IStreamArchive Implementation

				#pragma region zh-CHS 共有属性 | en Public Properties
			public:
				/// <summary>
				/// 
				/// </summary>
				property System::String^ PackageName
				{
					virtual System::String^ get() { return m_PackageName; }
				}
				#pragma endregion

				#pragma region zh-CHS 共有方法 | en Public Methods
				/// <summary>
				/// 
				/// </summary>
				/// <param name="strFileName"></param>
				/// <param name="fileAccess"></param>
				/// <returns></returns>
			public:
				virtual Demo::Mmose::Stream::VirtualStream^ OpenFile( System::String^ strFileName, System::IO::FileAccess fileAccess );

#undef CreateFile // BUG?
				/// <summary>
				/// 
				/// </summary>
				/// <param name="strFileName"></param>
				/// <returns></returns>
			public:
				virtual Demo::Mmose::Stream::VirtualStream^ CreateFile( System::String^ strFileName );

				/// <summary>
				/// 
				/// </summary>
				/// <param name="strFileName"></param>
			public:
				virtual void DeleteFile( System::String^ strFileName );

				/// <summary>
				/// 
				/// </summary>
				/// <param name="strArchiveName"></param>
				/// <returns></returns>
			public:
				virtual System::Boolean OpenPackage( System::String^ strArchivePath );

				/// <summary>
				/// 
				/// </summary>
				/// <param name="strArchiveName"></param>
				/// <returns></returns>
			public:
				virtual System::Boolean CreatePackage( System::String^ strArchivePath );

				/// <summary>
				/// 
				/// </summary>
			public:
				virtual void ClosePackage();

				/// <summary>
				/// 
				/// </summary>
				/// <returns></returns>
			public:
				virtual Demo::Mmose::Stream::IStreamArchive^ CreateInstance();
				#pragma endregion

				#pragma endregion
			};

		}
	}
}