// Demo.Mmose.Sgl.PatchDlg.cpp : 实现文件
//

#include "stdafx.h"
#include "Demo.Mmose.Sgl.Patch.h"
#include "Demo.Mmose.Sgl.PatchDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// 用于应用程序“关于”菜单项的 CAboutDlg 对话框

class CAboutDlg : public CDialog
{
public:
	CAboutDlg();

// 对话框数据
	enum { IDD = IDD_ABOUTBOX };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 支持

// 实现
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


// CDemoMmoseSglPatchDlg 对话框




CDemoMmoseSglPatchDlg::CDemoMmoseSglPatchDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CDemoMmoseSglPatchDlg::IDD, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);

	CString strType = _T("Styles");

	HRSRC res = ::FindResource( NULL, MAKEINTRESOURCE(IDR_STYLES_OFFICE2007), strType );

	HGLOBAL gl = ::LoadResource( NULL, res );

	LPVOID lp = ::LockResource( gl );	//返回指向资源内存的地址的指针。

	TCHAR szPathCopy[_MAX_PATH];   
	::GetTempPath( _MAX_PATH, szPathCopy );   
	::GetTempFileName( szPathCopy, _T("CHQ"), 0, szPathCopy);  

	m_strFilename = szPathCopy;	//保存的临时文件名

	HANDLE fp = ::CreateFile( m_strFilename ,GENERIC_WRITE, 0, NULL, CREATE_ALWAYS, 0, NULL );

	//sizeofResource 得到资源文件的大小
	DWORD dwSize;
	if ( !::WriteFile( fp, lp, SizeofResource (NULL,res), &dwSize, NULL ) )
		return;

	::CloseHandle ( fp );//关闭句柄

	::FreeResource ( gl );//释放内存

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


// CDemoMmoseSglPatchDlg 消息处理程序

BOOL CDemoMmoseSglPatchDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// 将“关于...”菜单项添加到系统菜单中。

	// IDM_ABOUTBOX 必须在系统命令范围内。
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

	// 设置此对话框的图标。当应用程序主窗口不是对话框时，框架将自动
	//  执行此操作
	SetIcon(m_hIcon, TRUE);			// 设置大图标
	SetIcon(m_hIcon, FALSE);		// 设置小图标

	// TODO: 在此添加额外的初始化代码
	VARIANT vURL;
	::VariantInit(&vURL);
	vURL.vt = VT_BSTR;
	vURL.bstrVal = ::SysAllocString(_T("about:blank"));

	m_WebBrowser.Navigate2( &vURL, NULL, NULL, NULL, NULL );

	return TRUE;  // 除非将焦点设置到控件，否则返回 TRUE
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

// 如果向对话框添加最小化按钮，则需要下面的代码
//  来绘制该图标。对于使用文档/视图模型的 MFC 应用程序，
//  这将由框架自动完成。

void CDemoMmoseSglPatchDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // 用于绘制的设备上下文

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// 使图标在工作区矩形中居中
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// 绘制图标
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialog::OnPaint();
	}
}

//当用户拖动最小化窗口时系统调用此函数取得光标
//显示。
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
		::AfxMessageBox(_T("补丁文件失败！"));
	else
		::AfxMessageBox(_T("补丁文件成功！"));
}

void CDemoMmoseSglPatchDlg::OnClose()
{
	// TODO: Add your message handler code here and/or call default

	//::DeleteFile( m_strFilename );

	CDialog::OnClose();
}