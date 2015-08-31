#include "StdAfx.h"
#include "SglFile.h"

CSglFile::CSglFile(void)
{
}

CSglFile::~CSglFile(void)
{
}

bool CSglFile::OpenSGLFile(CString stringFileName)
{
	if ( m_File.Open(stringFileName, CFile::modeReadWrite | CFile::shareDenyWrite ) == FALSE )
	{
		::AfxMessageBox(_T("sgl文件打开失败！"));
		return false;
	}

	m_SglHeader.m_pByteTitle = new BYTE[33];
	::memset(m_SglHeader.m_pByteTitle, 0, 33);

	m_File.Read(m_SglHeader.m_pByteTitle, 32);

	if ( ::strcmp((char*)m_SglHeader.m_pByteTitle, "Shanda Game Lib." ) != 0 )
	{
		::AfxMessageBox(_T("sgl文件头比较失败！"));
		CloseSGLFile();
		return false;
	}

	m_File.Read(&m_SglHeader.m_uiComp, 4);
	m_File.Read(&m_SglHeader.m_uiOffset, 4);

	m_File.Seek(m_SglHeader.m_uiOffset, CFile::begin);

	m_File.Read(&m_SglOffsetInfo.m_uiImageCount, 4);

	m_SglOffsetInfo.OffserTable = new UINT[m_SglOffsetInfo.m_uiImageCount];
	m_SglOffsetInfo.FilePosition = new ULONGLONG[m_SglOffsetInfo.m_uiImageCount];

	for (UINT iIndex = 0; iIndex < m_SglOffsetInfo.m_uiImageCount; iIndex++)
	{
		m_SglOffsetInfo.FilePosition[iIndex] = m_File.GetPosition();
		m_File.Read(&m_SglOffsetInfo.OffserTable[iIndex], 4);
	}

	return true;
}

bool CSglFile::AddSGLImage(int index, BYTE* pBuffer, int iSize)
{
	ULONGLONG offsetInfo = m_File.SeekToEnd();
	m_File.Write(pBuffer, iSize);
	
	m_File.Seek(m_SglOffsetInfo.FilePosition[index], CFile::begin);

	UINT uiOffsetInfo = (UINT)offsetInfo;
	m_File.Write(&uiOffsetInfo, 4);

	m_SglOffsetInfo.OffserTable[index] = uiOffsetInfo;

	return true;
}

bool CSglFile::DeleteSGLImage(int index)
{
	m_File.Seek(m_SglOffsetInfo.FilePosition[index], CFile::begin);

	UINT uiOffsetInfo = 0;
	m_File.Write(&uiOffsetInfo, 4);

	return true;
}

void CSglFile::CloseSGLFile()
{
	m_File.Close();
}