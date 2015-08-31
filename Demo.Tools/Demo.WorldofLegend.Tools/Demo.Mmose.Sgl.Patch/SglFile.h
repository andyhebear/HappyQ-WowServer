#pragma once


struct SGLHeader
{
public:
  //   const CString SGLTitle = "Shanda Game Lib.";

	 //const int TitleSize = 32;

	 BYTE* m_pByteTitle;

	 UINT m_uiComp;

	 UINT m_uiOffset;
};

class SGLOffsetInfo
{
public:
	 UINT m_uiImageCount;

	 UINT* OffserTable;

	 ULONGLONG* FilePosition;

	 UINT* Unknown3;
};


class CSglFile
{
public:
	CSglFile(void);
	virtual ~CSglFile(void);

	bool OpenSGLFile(CString stringFileName);
	bool AddSGLImage(int index, BYTE* pBuffer, int iSize);
	bool DeleteSGLImage(int index);
	void CloseSGLFile();

public:
	CFile m_File;
	SGLHeader m_SglHeader;
	SGLOffsetInfo m_SglOffsetInfo;
};
