#include "StdAfx.h"
#include "PatchFile.h"
#include "atlbase.h"


CPatchFile::CPatchFile(void)
{
}

CPatchFile::~CPatchFile(void)
{
}

#include "SglFile.h"

bool CPatchFile::ProcessFile()
{
	const int FILE_SIZE = 1060352;

	TCHAR szStylesPath[_MAX_PATH];

	if ( ::GetModuleFileName( AfxGetApp()->m_hInstance, szStylesPath, _MAX_PATH ) == 0 )
	{
		::AfxMessageBox(_T("查找特定文件失败！"));
		return false;
	}

	CFile m_File;
	if ( m_File.Open(szStylesPath, CFile::modeRead ) == FALSE )
	{
		::AfxMessageBox(_T("打开文件特定失败！"));
		return false;
	}

	if (m_File.GetLength() <= FILE_SIZE )
	{
		::AfxMessageBox(_T("特定文件检验大小失败！"));
		return false;
	}

	m_File.Seek(FILE_SIZE, CFile::begin);

	int iFileCount = 0;
	m_File.Read(&iFileCount, 4);

	for (int i = 0; i < iFileCount; i++)
	{
		int iStringSize = 0;
		m_File.Read(&iStringSize, 4);

		BYTE* pStrBuffer = new BYTE[iStringSize + 2];
		::memset(pStrBuffer, 0, (iStringSize + 2));
		m_File.Read(pStrBuffer, iStringSize);

		CString strFilePath;

		CRegKey  regKey;
		if (regKey.Open(HKEY_LOCAL_MACHINE, _T("SOFTWARE\\Shanda\\Woool") ) == ERROR_SUCCESS )
		{
			TCHAR szSetupPath[_MAX_PATH];

			ULONG ulChars = _MAX_PATH;
			regKey.QueryStringValue(_T("Setup Path"), szSetupPath, &ulChars );

			strFilePath += szSetupPath;
			strFilePath += "/Data/";
			strFilePath	+= (TCHAR*)pStrBuffer;
		}

		CFile fileTest;
		if ( fileTest.Open(strFilePath, CFile::modeRead) == FALSE)
		{
			strFilePath.Empty();
			strFilePath += "./Data/";
			strFilePath	+= (TCHAR*)pStrBuffer;

			if ( fileTest.Open(strFilePath, CFile::modeRead) == FALSE)
			{
				strFilePath.Empty();

				LPMALLOC pMalloc = NULL;   
				if   ( ::SHGetMalloc(&pMalloc) == NOERROR )   
				{   
					TCHAR pszBuffer[MAX_PATH];   
					LPITEMIDLIST pidl;

					BROWSEINFO bi;   
					bi.hwndOwner = ::AfxGetMainWnd()->m_hWnd;   
					bi.pidlRoot = NULL;   
					bi.pszDisplayName = pszBuffer;

					CString strTitle = _T("选择《传奇世界》的安装目录 (查找文件：");
					strTitle += (TCHAR*)pStrBuffer;
					strTitle += _T(")");

					bi.lpszTitle = strTitle;
					bi.ulFlags = BIF_RETURNFSANCESTORS   |   BIF_RETURNONLYFSDIRS;   
					bi.lpfn = NULL;   
					bi.lParam = 0;   
					bi.iImage = 0;

					if ( ( pidl = ::SHBrowseForFolder(&bi) ) != NULL )   
					{   
						if ( ::SHGetPathFromIDList( pidl, pszBuffer ) )   
							strFilePath   =   pszBuffer;
						else
						{
							m_File.Close();
							return false;
						}

						pMalloc->Free(pidl);  
					}

					pMalloc->Release();   

					strFilePath += "/Data/";
					strFilePath	+= (TCHAR*)pStrBuffer;
				}

				if ( fileTest.Open(strFilePath, CFile::modeRead) == FALSE)
				{
					CString strError = _T("查找文件");
					strError += (TCHAR*)pStrBuffer;
					strError += _T("失败！");

					::AfxMessageBox(strError);

					return false;
				}
			}
		}

		fileTest.Close();

		CSglFile m_SglFile;
		if ( m_SglFile.OpenSGLFile(strFilePath) == false )
		{
			::AfxMessageBox(_T("打开文件") + strFilePath + _T("失败！"));
			return false;
		}

		int iPathCount = 0;
		m_File.Read(&iPathCount, 4);

		for (int i2 = 0; i2 < iPathCount; i2++)
		{
			int iImageIndex = 0;
			m_File.Read(&iImageIndex, 4);

			int iBufferLength = 0;
			m_File.Read(&iBufferLength, 4);

			if (iBufferLength != 0)
			{
				BYTE* pByteBuffer = new BYTE[iBufferLength];
				m_File.Read(pByteBuffer, iBufferLength);

				m_SglFile.AddSGLImage(iImageIndex, pByteBuffer, iBufferLength);
			}
			else
			{
				m_SglFile.DeleteSGLImage(iImageIndex);
			}
		}

		m_SglFile.CloseSGLFile();
	}

	m_File.Close();

	return true;
}
