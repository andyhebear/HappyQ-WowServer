// Demo.Mmose.Sgl.PatchDlg.h : 头文件
//

#pragma once

#include "CWebBrowser2.h"
#include "SglFile.h"

// CDemoMmoseSglPatchDlg 对话框
class CDemoMmoseSglPatchDlg : public CDialog
{
// 构造
public:
	CDemoMmoseSglPatchDlg(CWnd* pParent = NULL);	// 标准构造函数

// 对话框数据
	enum { IDD = IDD_PATCH_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV 支持


// 实现
protected:
	HICON m_hIcon;

	// 生成的消息映射函数
	virtual BOOL OnInitDialog();
	afx_msg void OnClose();
	afx_msg void OnPaint();
	afx_msg void OnBnClickedPatch();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg HCURSOR OnQueryDragIcon();

	DECLARE_MESSAGE_MAP()

public:
	CWebBrowser2 m_WebBrowser;
	CString m_strFilename;	//保存的临时文件名
	CSglFile m_SglFile;
};
