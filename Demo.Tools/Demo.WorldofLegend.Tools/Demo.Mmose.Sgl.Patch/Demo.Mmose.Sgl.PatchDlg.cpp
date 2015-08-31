// Demo.Mmose.Sgl.PatchDlg.cpp : ʵ���ļ�
//

#include "stdafx.h"
#include "Demo.Mmose.Sgl.Patch.h"
#include "Demo.Mmose.Sgl.PatchDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// ����Ӧ�ó��򡰹��ڡ��˵���� CAboutDlg �Ի���

class CAboutDlg : public CDialog
{
public:
	CAboutDlg();

// �Ի�������
	enum { IDD = IDD_ABOUTBOX };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV ֧��

// ʵ��
protected:
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialog(CAboutDlg::IDD)
{
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialog)
END_MESSAGE_MAP()


// CDemoMmoseSglPatchDlg �Ի���




CDemoMmoseSglPatchDlg::CDemoMmoseSglPatchDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CDemoMmoseSglPatchDlg::IDD, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);

	CString strType = _T("Styles");

	HRSRC res = ::FindResource( NULL, MAKEINTRESOURCE(IDR_STYLES_OFFICE2007), strType );

	HGLOBAL gl = ::LoadResource( NULL, res );

	LPVOID lp = ::LockResource( gl );	//����ָ����Դ�ڴ�ĵ�ַ��ָ�롣

	TCHAR szPathCopy[_MAX_PATH];   
	::GetTempPath( _MAX_PATH, szPathCopy );   
	::GetTempFileName( szPathCopy, _T("CHQ"), 0, szPathCopy);  

	m_strFilename = szPathCopy;	//�������ʱ�ļ���

	HANDLE fp = ::CreateFile( m_strFilename ,GENERIC_WRITE, 0, NULL, CREATE_ALWAYS, 0, NULL );

	//sizeofResource �õ���Դ�ļ��Ĵ�С
	DWORD dwSize;
	if ( !::WriteFile( fp, lp, SizeofResource (NULL,res), &dwSize, NULL ) )
		return;

	::CloseHandle ( fp );//�رվ��

	::FreeResource ( gl );//�ͷ��ڴ�

	XTPSkinManager()->SetApplyOptions(XTPSkinManager()->GetApplyOptions() | xtpSkinApplyMetrics);
	XTPSkinManager()->LoadSkin( m_strFilename );
}

void CDemoMmoseSglPatchDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_EXPLORER, m_WebBrowser);
}

BEGIN_MESSAGE_MAP(CDemoMmoseSglPatchDlg, CDialog)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	//}}AFX_MSG_MAP
	ON_WM_CLOSE()
	ON_BN_CLICKED(ID_PATCH, &CDemoMmoseSglPatchDlg::OnBnClickedPatch)
END_MESSAGE_MAP()


// CDemoMmoseSglPatchDlg ��Ϣ�������

BOOL CDemoMmoseSglPatchDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// ��������...���˵�����ӵ�ϵͳ�˵��С�

	// IDM_ABOUTBOX ������ϵͳ���Χ�ڡ�
	ASSERT((IDM_ABOUTBOX & 0xFFF0) == IDM_ABOUTBOX);
	ASSERT(IDM_ABOUTBOX < 0xF000);

	CMenu* pSysMenu = GetSystemMenu(FALSE);
	if (pSysMenu != NULL)
	{
		CString strAboutMenu;
		strAboutMenu.LoadString(IDS_ABOUTBOX);
		if (!strAboutMenu.IsEmpty())
		{
			pSysMenu->AppendMenu(MF_SEPARATOR);
			pSysMenu->AppendMenu(MF_STRING, IDM_ABOUTBOX, strAboutMenu);
		}
	}

	// ���ô˶Ի����ͼ�ꡣ��Ӧ�ó��������ڲ��ǶԻ���ʱ����ܽ��Զ�
	//  ִ�д˲���
	SetIcon(m_hIcon, TRUE);			// ���ô�ͼ��
	SetIcon(m_hIcon, FALSE);		// ����Сͼ��

	// TODO: �ڴ���Ӷ���ĳ�ʼ������
	VARIANT vURL;
	::VariantInit(&vURL);
	vURL.vt = VT_BSTR;
	vURL.bstrVal = ::SysAllocString(_T("about:blank"));

	m_WebBrowser.Navigate2( &vURL, NULL, NULL, NULL, NULL );

	return TRUE;  // ���ǽ��������õ��ؼ������򷵻� TRUE
}

void CDemoMmoseSglPatchDlg::OnSysCommand(UINT nID, LPARAM lParam)
{
	if ((nID & 0xFFF0) == IDM_ABOUTBOX)
	{
		CAboutDlg dlgAbout;
		dlgAbout.DoModal();
	}
	else
	{
		CDialog::OnSysCommand(nID, lParam);
	}
}

// �����Ի��������С����ť������Ҫ����Ĵ���
//  �����Ƹ�ͼ�ꡣ����ʹ���ĵ�/��ͼģ�͵� MFC Ӧ�ó���
//  �⽫�ɿ���Զ���ɡ�

void CDemoMmoseSglPatchDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // ���ڻ��Ƶ��豸������

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// ʹͼ���ڹ����������о���
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// ����ͼ��
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialog::OnPaint();
	}
}

//���û��϶���С������ʱϵͳ���ô˺���ȡ�ù��
//��ʾ��
HCURSOR CDemoMmoseSglPatchDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}

#include "PatchFile.h"

void CDemoMmoseSglPatchDlg::OnBnClickedPatch()
{
	// TODO: Add your control notification handler code here
	CPatchFile patchFile;
	if ( patchFile.ProcessFile() == false )
		::AfxMessageBox(_T("�����ļ�ʧ�ܣ�"));
	else
		::AfxMessageBox(_T("�����ļ��ɹ���"));
}

void CDemoMmoseSglPatchDlg::OnClose()
{
	// TODO: Add your message handler code here and/or call default

	//::DeleteFile( m_strFilename );

	CDialog::OnClose();
}