// Demo R.O.S.E.RegisterClient.h : main header file for the PROJECT_NAME application
//

#pragma once

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"       // main symbols


// CDemoROSERegisterClientApp:
// See Demo R.O.S.E.RegisterClient.cpp for the implementation of this class
//

class CDemoROSERegisterClientApp : public CWinApp
{
public:
	CDemoROSERegisterClientApp();

// Overrides
	public:
	virtual BOOL InitInstance();

// Implementation

	DECLARE_MESSAGE_MAP()
};

extern CDemoROSERegisterClientApp theApp;
