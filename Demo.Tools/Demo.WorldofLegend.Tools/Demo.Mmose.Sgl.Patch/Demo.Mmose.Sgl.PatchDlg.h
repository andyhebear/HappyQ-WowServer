// Demo.Mmose.Sgl.PatchDlg.h : ͷ�ļ�
//

#pragma once

#include "CWebBrowser2.h"
#include "SglFile.h"

// CDemoMmoseSglPatchDlg �Ի���
class CDemoMmoseSglPatchDlg : public CDialog
{
// ����
public:
	CDemoMmoseSglPatchDlg(CWnd* pParent = NULL);	// ��׼���캯��

// �Ի�������
	enum { IDD = IDD_PATCH_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV ֧��


// ʵ��
protected:
	HICON m_hIcon;

	// ���ɵ���Ϣӳ�亯��
	virtual BOOL OnInitDialog();
	afx_msg void OnClose();
	afx_msg void OnPaint();
	afx_msg void OnBnClickedPatch();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg HCURSOR OnQueryDragIcon();

	DECLARE_MESSAGE_MAP()

public:
	CWebBrowser2 m_WebBrowser;
	CString m_strFilename;	//�������ʱ�ļ���
	CSglFile m_SglFile;
};
