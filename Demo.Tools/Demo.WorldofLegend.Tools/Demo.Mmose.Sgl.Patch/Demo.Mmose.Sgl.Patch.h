// Demo.Mmose.Sgl.Patch.h : PROJECT_NAME Ӧ�ó������ͷ�ļ�
//

#pragma once

#ifndef __AFXWIN_H__
	#error "�ڰ������ļ�֮ǰ������stdafx.h�������� PCH �ļ�"
#endif

#include "resource.h"		// ������


// CDemoMmoseSglPatchApp:
// �йش����ʵ�֣������ Demo.Mmose.Sgl.Patch.cpp
//

class CDemoMmoseSglPatchApp : public CWinApp
{
public:
	CDemoMmoseSglPatchApp();

// ��д
	public:
	virtual BOOL InitInstance();

// ʵ��

	DECLARE_MESSAGE_MAP()
};

extern CDemoMmoseSglPatchApp theApp;