// Demo R.O.S.E.RegisterClientDlg.h : header file
//

#pragma once


// CDemoROSERegisterClientDlg dialog
class CDemoROSERegisterClientDlg : public CDialog
{
// Construction
public:
	CDemoROSERegisterClientDlg(CWnd* pParent = NULL);   // standard constructor

// Dialog Data
	enum { IDD = IDD_DEMOROSEREGISTERCLIENT_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support


// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()
};
