using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Collections;

namespace Demo_G.O.S.E.VFS.Editor
{
    public partial class VFSEditorForm : Form
    {
        #region class
        class ListViewItemFileInfo
        {
            public ListViewItem m_ListViewItem;
            public string m_strFullPath;
            public string m_strFileName;
            public uint m_iChecksum;
            public int m_iAttribute;
            public uint m_iFileSize;
            public string m_strInArchive;
            public uint m_iArchiveNumber;
        }

        class TreeNodeFileInfo
        {
            public TreeNode m_TreeNode;
            public bool m_IsDirectory;
            public List<ListViewItemFileInfo> m_ListViewItemFileInfo;
            public string m_strFullPath;
            public string m_strFileName;
            public uint m_iChecksum;
            public int m_iAttribute;
            public uint m_iFileSize;
            public string m_strInArchive;
            public uint m_iArchiveNumber;
        }

        #endregion

        #region ExtractAllThread
        class ExtractAllThread
        {
            public static bool s_isFormClose = false;
            public static bool s_isExtractAllThread = false;
            public static bool s_isThreadClose = false;
            public static TriggerVFS s_TriggerVFS = new TriggerVFS();
            public static TreeNode s_RootTree = null;
            public static HybridDictionary s_strHybridDictionary = new HybridDictionary( 5000, false );
            public static Hashtable s_nodeHybridDictionary = new Hashtable( 5000 );
            public static Hashtable s_ListItemHybridDictionary = new Hashtable( 5000 );



            public static bool s_MenuItem1;
            public static bool s_MenuItem2;
            public static bool s_MenuItem4;
            public static bool s_MenuItem5;
            public static bool s_MenuItem6;
            public static bool s_MenuItem7;
            public static bool s_MenuItem8;
            public static bool s_MenuItem9;
            public static bool s_MenuItem10;
            public static bool s_MenuItem11;
            public static bool s_MenuItem12;
            public static bool s_MenuItem13;
            public static bool s_MenuItem14;
            public static bool s_MenuItem15;
            private static void OpenMenu( VFSEditorForm vfsEditorForm )
            {
                vfsEditorForm.OpenFileToolStripMenuItem.Enabled = s_MenuItem1;
                vfsEditorForm.CloseCToolStripMenuItem.Enabled = s_MenuItem2;

                vfsEditorForm.LoadFileToolStripMenuItem.Enabled = s_MenuItem4;
                vfsEditorForm.打开方式ToolStripMenuItem.Enabled = s_MenuItem5;
                vfsEditorForm.解压缩ToolStripMenuItem.Enabled = s_MenuItem6;
                vfsEditorForm.RenToolStripMenuItem.Enabled = s_MenuItem7;
                vfsEditorForm.DeleteToolStripMenuItem.Enabled = s_MenuItem8;
                vfsEditorForm.AttributeToolStripMenuItem.Enabled = s_MenuItem9;
                vfsEditorForm.AddNewVFSToolStripMenuItem.Enabled = s_MenuItem10;
                vfsEditorForm.新建文件夹NToolStripMenuItem.Enabled = s_MenuItem11;
                vfsEditorForm.新建文件加ToolStripMenuItem.Enabled = s_MenuItem12;
                vfsEditorForm.AddFileToolStripMenuItem.Enabled = s_MenuItem13;
                vfsEditorForm.AddFolderToolStripMenuItem.Enabled = s_MenuItem14;
                vfsEditorForm.AllDecRToolStripMenuItem.Enabled = s_MenuItem15;
            }

            private static void CloseMenu( VFSEditorForm vfsEditorForm )
            {
                s_MenuItem1 = vfsEditorForm.OpenFileToolStripMenuItem.Enabled;
                s_MenuItem2 = vfsEditorForm.CloseCToolStripMenuItem.Enabled;

                s_MenuItem4 = vfsEditorForm.LoadFileToolStripMenuItem.Enabled;
                s_MenuItem5 = vfsEditorForm.打开方式ToolStripMenuItem.Enabled;
                s_MenuItem6 = vfsEditorForm.解压缩ToolStripMenuItem.Enabled;
                s_MenuItem7 = vfsEditorForm.RenToolStripMenuItem.Enabled;
                s_MenuItem8 = vfsEditorForm.DeleteToolStripMenuItem.Enabled;
                s_MenuItem9 = vfsEditorForm.AttributeToolStripMenuItem.Enabled;
                s_MenuItem10 = vfsEditorForm.AddNewVFSToolStripMenuItem.Enabled;
                s_MenuItem11 = vfsEditorForm.新建文件夹NToolStripMenuItem.Enabled;
                s_MenuItem12 = vfsEditorForm.新建文件加ToolStripMenuItem.Enabled;
                s_MenuItem13 = vfsEditorForm.AddFileToolStripMenuItem.Enabled;
                s_MenuItem14 = vfsEditorForm.AddFolderToolStripMenuItem.Enabled;
                s_MenuItem15 = vfsEditorForm.AllDecRToolStripMenuItem.Enabled;

                vfsEditorForm.OpenFileToolStripMenuItem.Enabled = false;
                vfsEditorForm.CloseCToolStripMenuItem.Enabled = false;

                vfsEditorForm.LoadFileToolStripMenuItem.Enabled = false;
                vfsEditorForm.打开方式ToolStripMenuItem.Enabled = false;
                vfsEditorForm.解压缩ToolStripMenuItem.Enabled = false;
                vfsEditorForm.RenToolStripMenuItem.Enabled = false;
                vfsEditorForm.DeleteToolStripMenuItem.Enabled = false;
                vfsEditorForm.AttributeToolStripMenuItem.Enabled = false;
                vfsEditorForm.AddNewVFSToolStripMenuItem.Enabled = false;
                vfsEditorForm.新建文件夹NToolStripMenuItem.Enabled = false;
                vfsEditorForm.新建文件加ToolStripMenuItem.Enabled = false;
                vfsEditorForm.AddFileToolStripMenuItem.Enabled = false;
                vfsEditorForm.AddFolderToolStripMenuItem.Enabled = false;
                vfsEditorForm.AllDecRToolStripMenuItem.Enabled = false;
            }



            static VFSEditorForm m_vfsExtractAllFileEditorForm;
            public static void InitExtractAllFile( VFSEditorForm vfsEditorForm )
            {
                m_vfsExtractAllFileEditorForm = vfsEditorForm;
                Thread tThread = new Thread( new ThreadStart( ExtractAllThread.ExtractAllFileThreadProc ) );
                tThread.Start();
            }

            private static void ExtractAllFileThreadProc()
            {
                s_isExtractAllThread = true;
                CloseMenu( m_vfsExtractAllFileEditorForm );

                m_vfsExtractAllFileEditorForm.richTextBox.AppendText( "开始解压全部文件中...\n" );

                if ( Directory.Exists( "Demo ExtractFile" ) == false )
                    Directory.CreateDirectory( "Demo ExtractFile" );

                for ( int iIndex = 0; iIndex < s_TriggerVFS.FileTreeArray.Length; iIndex++ )
                {
                    for ( int iIndex2 = 0; iIndex2 < s_TriggerVFS.FileTreeArray[iIndex].m_iFileCount; iIndex2++ )
                    {
                        m_vfsOpenIndexForm.progressBar1.PerformStep();

                        string strPathName = s_TriggerVFS.FileTreeArray[iIndex].m_strFiles[iIndex2];
                        string[] strPath = strPathName.Split( "\\".ToCharArray() );

                        m_vfsExtractAllFileEditorForm.progressBar1.PerformStep();

                        if ( strPath.Length == 0 )
                            continue;

                        string strKey = string.Empty;
                        for ( int iIndex3 = 0; iIndex3 < strPath.Length; iIndex3++ )
                        {
                            if ( s_isFormClose == true )
                            {
                                s_isThreadClose = true;
                                s_isExtractAllThread = false;
                                m_vfsExtractAllFileEditorForm.richTextBox.AppendText( "程序关闭中...当前的操作终止" );
                                m_vfsExtractAllFileEditorForm.Close();
                                return;
                            }

                            strKey = string.Concat( strKey, "\\", strPath[iIndex3] );

                            if ( iIndex3 == ( strPath.Length - 1 ) )
                            {
                                string l_strExtractFileFullPath = strKey.Substring( 1 );
                                m_vfsExtractAllFileEditorForm.richTextBox.AppendText( "文件" + l_strExtractFileFullPath + "开始解压中...\n" );

                                s_TriggerVFS.ExtractFile( l_strExtractFileFullPath, "Demo ExtractFile\\" + l_strExtractFileFullPath );

                                m_vfsExtractAllFileEditorForm.richTextBox.AppendText( "文件解压在 Demo ExtractFile\\" + l_strExtractFileFullPath + " 中, 完成!\n" );
                            }
                            else
                            {
                                if ( Directory.Exists( "Demo ExtractFile" + strKey ) == false )
                                {
                                    Directory.CreateDirectory( "Demo ExtractFile" + strKey );
                                    m_vfsExtractAllFileEditorForm.richTextBox.AppendText( "目录" + "Demo ExtractFile" + strKey + "创建完成!\n" );
                                }
                            }
                        }
                    }
                }

                m_vfsOpenIndexForm.progressBar1.Value = m_vfsOpenIndexForm.progressBar1.Maximum;
                m_vfsOpenIndexForm.progressBar1.Value = 0;

                m_vfsExtractAllFileEditorForm.richTextBox.AppendText( "文件全部解压完成!\n" );

                OpenMenu( m_vfsExtractAllFileEditorForm );
                s_isExtractAllThread = false;
            }



            static VFSEditorForm m_vfsExtractFileEditorForm;
            static string m_strExtractFileFullPath;
            static string m_strExtractFileName;
            public static void InitExtractFile( VFSEditorForm vfsEditorForm, string strExtractFile, string strExtractFileName )
            {
                m_vfsExtractFileEditorForm = vfsEditorForm;
                m_strExtractFileFullPath = strExtractFile;
                m_strExtractFileName = strExtractFileName;
                Thread tThread = new Thread( new ThreadStart( ExtractAllThread.ExtractFileThreadProc ) );
                tThread.Start();
            }

            private static void ExtractFileThreadProc()
            {
                s_isExtractAllThread = true;
                CloseMenu( m_vfsExtractFileEditorForm );

                if ( Directory.Exists( "Demo ExtractFile" ) == false )
                    Directory.CreateDirectory( "Demo ExtractFile" );

                m_vfsExtractFileEditorForm.richTextBox.AppendText( "文件" + m_strExtractFileFullPath + "开始解压中...\n" );

                s_TriggerVFS.ExtractFile( m_strExtractFileFullPath, "Demo ExtractFile\\" + m_strExtractFileName );

                m_vfsExtractFileEditorForm.richTextBox.AppendText( "文件解压在 Demo ExtractFile\\" + m_strExtractFileName + " 中, 完成!\n" );

                OpenMenu( m_vfsExtractFileEditorForm );
                s_isExtractAllThread = false;
            }



            static VFSEditorForm m_vfsExtractFileEditorFormTo;
            static string m_strExtractFileFullPathTo;
            static string m_strExtractFileFullPathTo2;
            public static void InitExtractFileTo( VFSEditorForm vfsEditorForm, string strExtractFile, string strExtractFileTo )
            {
                m_vfsExtractFileEditorFormTo = vfsEditorForm;
                m_strExtractFileFullPathTo = strExtractFile;
                m_strExtractFileFullPathTo2 = strExtractFileTo;

                Thread tThread = new Thread( new ThreadStart( ExtractAllThread.ExtractFileToThreadProc ) );
                tThread.Start();
            }

            private static void ExtractFileToThreadProc()
            {
                s_isExtractAllThread = true;
                CloseMenu( m_vfsExtractFileEditorFormTo );

                m_vfsExtractFileEditorFormTo.richTextBox.AppendText( "文件" + m_strExtractFileFullPathTo + "开始解压中...\n" );

                s_TriggerVFS.ExtractFile( m_strExtractFileFullPathTo, m_strExtractFileFullPathTo2 );

                m_vfsExtractFileEditorFormTo.richTextBox.AppendText( "文件解压在 " + m_strExtractFileFullPathTo2 + " 中, 完成!\n" );

                OpenMenu( m_vfsExtractFileEditorFormTo );
                s_isExtractAllThread = false;
            }



            static VFSEditorForm m_vfsExtractDirectoryFile;
            static TreeNode m_treeNode;
            public static void InitExtractDirectoryFile( VFSEditorForm vfsEditorForm, TreeNode treeNode )
            {
                m_vfsExtractDirectoryFile = vfsEditorForm;
                m_treeNode = treeNode;

                Thread tThread = new Thread( new ThreadStart( ExtractAllThread.InitExtractDirectoryFileThreadProc ) );
                tThread.Start();
            }

            private static void InitExtractDirectoryFileThreadProc()
            {
                s_isExtractAllThread = true;
                CloseMenu( m_vfsExtractDirectoryFile );

                InitExtractDirectoryFileThreadProc( m_treeNode );

                for ( int iIndex = m_vfsExtractDirectoryFile.progressBar1.Value; iIndex < m_vfsExtractDirectoryFile.progressBar1.Maximum; iIndex++ )
                    m_vfsExtractDirectoryFile.progressBar1.PerformStep();

                m_vfsExtractDirectoryFile.progressBar1.Value = m_vfsOpenIndexForm.progressBar1.Maximum;
                m_vfsExtractDirectoryFile.progressBar1.Value = 0;

                OpenMenu( m_vfsExtractDirectoryFile );
                s_isExtractAllThread = false;
            }

            private static void InitExtractDirectoryFileThreadProc( TreeNode treeParentNode )
            {
                if ( treeParentNode == null )
                    return;

                TreeNodeFileInfo l_TreeNodeFileInfo = ExtractAllThread.s_nodeHybridDictionary[treeParentNode] as TreeNodeFileInfo;
                if ( l_TreeNodeFileInfo == null )
                    return;

                if ( Directory.Exists( "Demo ExtractFile" ) == false )
                {
                    Directory.CreateDirectory( "Demo ExtractFile" );
                    m_vfsExtractDirectoryFile.richTextBox.AppendText( "目录" + "Demo ExtractFile" + "创建完成!\n" );
                }

                string strPathName = l_TreeNodeFileInfo.m_strFullPath;
                string[] strPath = strPathName.Split( "\\".ToCharArray() );


                if ( strPath.Length == 0 )
                    return;

                string strKey = string.Empty;
                for ( int iIndex3 = 0; iIndex3 < strPath.Length; iIndex3++ )
                {
                    strKey = string.Concat( strKey, "\\", strPath[iIndex3] );

                    if ( Directory.Exists( "Demo ExtractFile" + strKey ) == false )
                    {
                        Directory.CreateDirectory( "Demo ExtractFile" + strKey );
                        m_vfsExtractDirectoryFile.richTextBox.AppendText( "目录" + "Demo ExtractFile" + strKey + "创建完成!\n" );
                    }
                }

                m_vfsExtractDirectoryFile.richTextBox.AppendText( "开始解压目录" + l_TreeNodeFileInfo.m_strFullPath + "...\n" );

                for ( int iIndex = 0; iIndex < l_TreeNodeFileInfo.m_ListViewItemFileInfo.Count; iIndex++ )
                {
                    if ( s_isFormClose == true )
                    {
                        s_isThreadClose = true;
                        s_isExtractAllThread = false;
                        m_vfsExtractDirectoryFile.richTextBox.AppendText( "程序关闭中...当前的操作终止" );
                        m_vfsExtractDirectoryFile.Close();
                        return;
                    }

                    m_vfsExtractDirectoryFile.progressBar1.PerformStep();

                    string l_strExtractFileFullPath = l_TreeNodeFileInfo.m_ListViewItemFileInfo[iIndex].m_strFullPath.Substring( 1 );
                    m_vfsExtractDirectoryFile.richTextBox.AppendText( "文件" + l_strExtractFileFullPath + "开始解压中...\n" );

                    s_TriggerVFS.ExtractFile( l_strExtractFileFullPath, "Demo ExtractFile\\" + l_strExtractFileFullPath );

                    m_vfsExtractDirectoryFile.richTextBox.AppendText( "文件解压在 Demo ExtractFile\\" + l_strExtractFileFullPath + " 中, 完成!\n" );
                }

                m_vfsExtractDirectoryFile.richTextBox.AppendText( "目录" + l_TreeNodeFileInfo.m_strFullPath + "全部解压, 完成!\n" );

                for ( int iIndex = 0; iIndex < treeParentNode.Nodes.Count; iIndex++ )
                    InitExtractDirectoryFileThreadProc( treeParentNode.Nodes[iIndex] );
            }


            static VFSEditorForm m_vfsExtractSwapFile;
            static string m_strFileName;
            static string m_strChangeFile;
            static string m_strVfsFile;
            public static void InitExtractSwapFile( VFSEditorForm vfsEditorForm, string strFileName, string strChangeFile, string strVfsFile )
            {
                m_vfsExtractSwapFile = vfsEditorForm;
                m_strFileName = strFileName;
                m_strChangeFile = strChangeFile;
                m_strVfsFile = strVfsFile;

                Thread tThread = new Thread( new ThreadStart( ExtractAllThread.InitExtractSwapThreadProc ) );
                tThread.Start();
            }

            private static void InitExtractSwapThreadProc()
            {
                s_isExtractAllThread = true;
                CloseMenu( m_vfsExtractSwapFile );

                m_vfsExtractSwapFile.richTextBox.AppendText( "文件" + m_strFileName + "开始替换中...\n" );

                s_TriggerVFS.AddFile( m_strFileName, m_strChangeFile, m_strVfsFile );

                m_vfsExtractSwapFile.richTextBox.AppendText( "文件替换在 " + m_strChangeFile + " 中, 完成!\n" );

                OpenMenu( m_vfsExtractSwapFile );
                s_isExtractAllThread = false;
            }


            static VFSEditorForm m_vfsOpenIndexForm;
            public static void InitOpenIndex( VFSEditorForm vfsEditorForm )
            {
                m_vfsOpenIndexForm = vfsEditorForm;
                Thread tThread = new Thread( new ThreadStart( ExtractAllThread.OpenIndexThreadProc ) );
                tThread.Start();
            }

            private static void OpenIndexThreadProc()
            {
                s_isExtractAllThread = true;
                CloseMenu( m_vfsOpenIndexForm );

                m_vfsOpenIndexForm.richTextBox.AppendText( "文件开始读取中...\n" );

                s_TriggerVFS.OpenIndex( "data.idx", false );

                TreeNode l_RootTree = new TreeNode( "Root" );
                for ( int iIndex = 0; iIndex < s_TriggerVFS.FileTreeArray.Length; iIndex++ )
                {
                    m_vfsOpenIndexForm.richTextBox.AppendText( "VFS 文件" + s_TriggerVFS.VFSNames[iIndex] + " 存档数(" + s_TriggerVFS.FileTreeArray[iIndex].m_iFileCount.ToString() + ")\n" );

                    for ( int iIndex2 = 0; iIndex2 < s_TriggerVFS.FileTreeArray[iIndex].m_iFileCount; iIndex2++ )
                    {
                        m_vfsOpenIndexForm.progressBar1.PerformStep();

                        string strPathName = s_TriggerVFS.FileTreeArray[iIndex].m_strFiles[iIndex2];
                        string[] strPath = strPathName.Split( "\\".ToCharArray() );

                        if ( strPath.Length == 0 )
                            continue;

                        TreeNode l_ParentTree = l_RootTree;

                        string strKey = string.Empty;
                        TreeNodeFileInfo l_TreeNodeFileInfoDirectory = null;
                        for ( int iIndex3 = 0; iIndex3 < strPath.Length; iIndex3++ )
                        {
                            if ( s_isFormClose == true )
                            {
                                s_isThreadClose = true;
                                s_isExtractAllThread = false;
                                m_vfsOpenIndexForm.richTextBox.AppendText( "程序关闭中...当前的操作终止" );
                                m_vfsOpenIndexForm.Close();
                                return;
                            }

                            strKey = string.Concat( strKey, "\\", strPath[iIndex3] );

                            TreeNodeFileInfo l_TreeNodeFileInfo = s_strHybridDictionary[strKey] as TreeNodeFileInfo;

                            TreeNode l_TreeNode = null;
                            if ( l_TreeNodeFileInfo == null )
                            {
                                l_TreeNodeFileInfo = new TreeNodeFileInfo();
                                l_TreeNodeFileInfo.m_ListViewItemFileInfo = new List<ListViewItemFileInfo>();
                                l_TreeNode = new TreeNode( strPath[iIndex3] );
                                l_TreeNodeFileInfo.m_TreeNode = l_TreeNode;

                                if ( iIndex3 == ( strPath.Length - 1 ) )
                                {
                                    l_TreeNodeFileInfo.m_strFullPath = strKey;
                                    l_TreeNodeFileInfo.m_strFileName = strPath[strPath.Length - 1];
                                    l_TreeNodeFileInfo.m_strInArchive = s_TriggerVFS.VFSNames[iIndex];
                                    l_TreeNodeFileInfo.m_iArchiveNumber = s_TriggerVFS.FileTreeArray[iIndex].m_iFileCount;

                                    //string l_strFullPath = strKey.Substring( 1 );
                                    //TriggerVFS.FileInfo l_FileInfo = new TriggerVFS.FileInfo();
                                    //if ( s_TriggerVFS.GetFileInfo( l_strFullPath, ref l_FileInfo ) == true )
                                    //{
                                    //    l_TreeNodeFileInfo.m_iAttribute = l_FileInfo.m_iAttribute;
                                    //    l_TreeNodeFileInfo.m_iChecksum = l_FileInfo.m_iChecksum;
                                    //}
                                    //else
                                    //    m_vfsOpenIndexForm.richTextBox.AppendText( "GetFileInfo(" + l_strFullPath + ") Error!\n" );

                                    //l_TreeNodeFileInfo.m_iFileSize = s_TriggerVFS.GetFileSize( l_strFullPath );

                                    // 添加 ListViewItem
                                    ListViewItemFileInfo l_ListViewItemFileInfo = new ListViewItemFileInfo();
                                    l_ListViewItemFileInfo.m_ListViewItem = new ListViewItem( l_TreeNodeFileInfo.m_strFileName );
                                    l_ListViewItemFileInfo.m_strFullPath = strKey;
                                    l_ListViewItemFileInfo.m_strFileName = strPath[strPath.Length - 1];
                                    l_ListViewItemFileInfo.m_strInArchive = s_TriggerVFS.VFSNames[iIndex];
                                    l_ListViewItemFileInfo.m_iArchiveNumber = s_TriggerVFS.FileTreeArray[iIndex].m_iFileCount;
                                    l_TreeNodeFileInfoDirectory.m_ListViewItemFileInfo.Add( l_ListViewItemFileInfo );

                                    s_ListItemHybridDictionary.Add( l_ListViewItemFileInfo.m_ListViewItem, l_ListViewItemFileInfo );
                                }
                                else
                                {
                                    l_TreeNodeFileInfo.m_IsDirectory = true;
                                    l_TreeNodeFileInfo.m_strFullPath = strKey;
                                    l_TreeNodeFileInfo.m_strInArchive = string.Empty;

                                    l_ParentTree.Nodes.Add( l_TreeNode );
                                    s_strHybridDictionary.Add( strKey, l_TreeNodeFileInfo );
                                    s_nodeHybridDictionary.Add( l_TreeNode, l_TreeNodeFileInfo );
                                    l_TreeNodeFileInfoDirectory = l_TreeNodeFileInfo;
                                }
                            }
                            else
                            {
                                l_TreeNode = l_TreeNodeFileInfo.m_TreeNode;
                                l_TreeNodeFileInfoDirectory = l_TreeNodeFileInfo;
                            }

                            l_ParentTree = l_TreeNode;
                        }
                    }
                }

                m_vfsOpenIndexForm.progressBar1.Value = m_vfsOpenIndexForm.progressBar1.Maximum;
                m_vfsOpenIndexForm.progressBar1.Value = 0;

                m_vfsOpenIndexForm.richTextBox.AppendText( "文件读取完成!\n" );

                s_RootTree = l_RootTree;

                OpenMenu( m_vfsOpenIndexForm );
                s_isExtractAllThread = false;
            }
        }
        #endregion

        public VFSEditorForm()
        {
            InitializeComponent();
        }

        private void LoadFileToolStripMenuItem_Click( object sender, EventArgs e )
        {
            if ( File.Exists( "TriggerVFS.dll" ) == false )
            {
                MessageBox.Show( "TriggerVFS.dll文件在当前目录不存在!" );
                return;
            }

            if ( File.Exists( "data.idx" ) == false )
            {
                MessageBox.Show( "data.idx文件在当前目录不存在!" );
                return;
            }

            ExtractAllThread.InitOpenIndex( this );
            this.timer.Enabled = true;

            //this.richTextBox.Text += m_TriggerVFS.GetCurrentVersion().ToString();
            //this.richTextBox.Text += "\r\n" + m_TriggerVFS.GetTotalFileCount().ToString();

            //for ( int iIndex = 0; iIndex < m_TriggerVFS.VFSNames.Length; iIndex++ )
            //{
            //    this.richTextBox.Text += "\r\n" + m_TriggerVFS.VFSNames[iIndex];
            //}

            //this.richTextBox.Text += "\r\n" + m_TriggerVFS.GetLastError().ToString();

            //this.richTextBox.Text += "\r\n" + m_TriggerVFS.GetFileSize("SCRIPTS\\INIT.LUA");

            //this.richTextBox.Text += "\r\n" + m_TriggerVFS.GetFileLength( "SCRIPTS\\INIT.LUA" );

            //this.richTextBox.Text += "\r\n" + m_TriggerVFS.ExtractFile( "HELLO\\SYSINFO.DAT", "D:\\SYSINFO.DAT" ).ToString();

            //TriggerVFS.FileInfo l_FileInfo = new TriggerVFS.FileInfo();
            //this.richTextBox.Text += "\r\n" + m_TriggerVFS.GetFileInfo( "SCRIPTS\\INIT.LUA", ref l_FileInfo ).ToString();
            //this.richTextBox.Text += "\r\n" + l_FileInfo.m_iAttribute.ToString();
            //this.richTextBox.Text += "\r\n" + l_FileInfo.m_iChecksum.ToString();

            //this.richTextBox.Text += "\r\n" + m_TriggerVFS.RemoveFile( "HELLO\\SYSINFO.DAT" ).ToString();

            //TriggerVFS.FileInfo l_FileInfo = new TriggerVFS.FileInfo();
            //this.richTextBox.Text += "\r\n" + m_TriggerVFS.GetFileInfo( "SCRIPTS\\INIT.LUA", ref l_FileInfo ).ToString();
            //l_FileInfo.m_iAttribute = 0x64;
            //this.richTextBox.Text += "\r\n" + m_TriggerVFS.SetFileInfo( "SCRIPTS\\INIT.LUA", ref l_FileInfo ).ToString();
            
            //this.richTextBox.Text += "\r\n" + m_TriggerVFS.AddVfs( "test002.VFS", true ).ToString();

            //this.richTextBox.Text += "\r\n" + m_TriggerVFS.AddFile( "D:\\Uninstall.ico", "HELLO\\SYSINFO03.DAT", "3DDATA.VFS" ).ToString();

            //m_TriggerVFS.CloseIndex();

            //this.treeView.Nodes.Add( l_RootTree );
        }

        private void AboutToolStripMenuItem_Click( object sender, EventArgs e )
        {
            AboutForm l_AboutForm = new AboutForm();
            l_AboutForm.ShowDialog();
        }

        private void treeView_AfterSelect( object sender, TreeViewEventArgs e )
        {
            TreeNodeFileInfo l_TreeNodeFileInfo = ExtractAllThread.s_nodeHybridDictionary[e.Node] as TreeNodeFileInfo;

            if ( l_TreeNodeFileInfo == null )
                return;

            if ( l_TreeNodeFileInfo.m_IsDirectory == true )
            {
                this.listView.Items.Clear();
                for ( int iIndex = 0; iIndex < l_TreeNodeFileInfo.m_ListViewItemFileInfo.Count; iIndex++ )
                {
                    this.listView.Items.Add( l_TreeNodeFileInfo.m_ListViewItemFileInfo[iIndex].m_ListViewItem );
                }
            }

            this.textBox1.Text = l_TreeNodeFileInfo.m_strFullPath.ToString();
            this.textBox6.Text = l_TreeNodeFileInfo.m_strInArchive.ToString();
            this.textBox5.Text = l_TreeNodeFileInfo.m_iArchiveNumber.ToString();
            this.textBox3.Text = l_TreeNodeFileInfo.m_iAttribute.ToString();
            this.textBox2.Text = l_TreeNodeFileInfo.m_iChecksum.ToString();
            this.textBox4.Text = l_TreeNodeFileInfo.m_iFileSize.ToString();
            this.textBox7.Text = l_TreeNodeFileInfo.m_IsDirectory.ToString();
        }

        private void treeView_NodeMouseDoubleClick( object sender, TreeNodeMouseClickEventArgs e )
        {
            TreeNodeFileInfo l_TreeNodeFileInfo = ExtractAllThread.s_nodeHybridDictionary[e.Node] as TreeNodeFileInfo;
            if ( l_TreeNodeFileInfo == null )
                return;

            if ( l_TreeNodeFileInfo.m_IsDirectory == false )
                ExtractAllThread.InitExtractFile( this, l_TreeNodeFileInfo.m_strFullPath.Substring( 1 ), l_TreeNodeFileInfo.m_strFileName );
        }

        private void CloseToolStripMenuItem_Click( object sender, EventArgs e )
        {
            this.treeView.Nodes.Clear();

            this.OpenFileToolStripMenuItem.Enabled = false;
            this.CloseCToolStripMenuItem.Enabled = false;
            this.ExitToolStripMenuItem.Enabled = true;

            this.LoadFileToolStripMenuItem.Enabled = true;

            this.打开方式ToolStripMenuItem.Enabled = false;
            this.解压缩ToolStripMenuItem.Enabled = false;
            this.RenToolStripMenuItem.Enabled = false;
            this.DeleteToolStripMenuItem.Enabled = false;
            this.AttributeToolStripMenuItem.Enabled = false;
            this.AddNewVFSToolStripMenuItem.Enabled = false;
            this.新建文件夹NToolStripMenuItem.Enabled = false;
            this.新建文件加ToolStripMenuItem.Enabled = false;
            this.AddFileToolStripMenuItem.Enabled = false;
            this.AddFolderToolStripMenuItem.Enabled = false;
            this.AllDecRToolStripMenuItem.Enabled = false;

            ExtractAllThread.s_TriggerVFS.CloseIndex();
        }

        private void AllDecToolStripMenuItem_Click( object sender, EventArgs e )
        {
            ExtractAllThread.InitExtractAllFile(this);
        }

        private void ExitToolStripMenuItem_Click( object sender, EventArgs e )
        {
            ExtractAllThread.s_isFormClose = true;
            if ( ExtractAllThread.s_isExtractAllThread == true )
                return;

            this.Close();
        }

        private void timer1_Tick( object sender, EventArgs e )
        {
            if ( ExtractAllThread.s_RootTree == null || this.treeView.Nodes.Count != 0 )
                return;
            else
            {
                this.treeView.Nodes.Add( ExtractAllThread.s_RootTree );
                ExtractAllThread.s_RootTree.Expand();

                this.AddNewVFSToolStripMenuItem.Enabled = true;
                this.CloseCToolStripMenuItem.Enabled = true;
                this.ExitToolStripMenuItem.Enabled = true;

                this.LoadFileToolStripMenuItem.Enabled = false;

                //this.OpenFileToolStripMenuItem.Enabled = true;
                //this.打开方式ToolStripMenuItem.Enabled = true;
                //this.解压缩ToolStripMenuItem.Enabled = true;
                //this.RenToolStripMenuItem.Enabled = true;
                //this.DeleteToolStripMenuItem.Enabled = true;
                //this.AttributeToolStripMenuItem.Enabled = true;
                //this.新建文件夹NToolStripMenuItem.Enabled = true;
                //this.新建文件加ToolStripMenuItem.Enabled = true;
                //this.AddFileToolStripMenuItem.Enabled = true;
                //this.AddFolderToolStripMenuItem.Enabled = true;
                this.AllDecRToolStripMenuItem.Enabled = true;

                this.timer.Enabled = false;
            }
        }

        private void 解压缩ToolStripMenuItem_Click( object sender, EventArgs e )
        {
            if (this.treeView.SelectedNode == null)
                return;

            TreeNodeFileInfo l_TreeNodeFileInfo = ExtractAllThread.s_nodeHybridDictionary[this.treeView.SelectedNode] as TreeNodeFileInfo;
            if ( l_TreeNodeFileInfo == null )
                return;

            ExtractAllThread.InitExtractFile( this, l_TreeNodeFileInfo.m_strFullPath.Substring( 1 ), l_TreeNodeFileInfo.m_strFileName );
        }

        private void VFSEditorForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            ExtractAllThread.s_isFormClose = true;
            if ( ExtractAllThread.s_isExtractAllThread == true )
                e.Cancel = true;
        }

        private void 解压缩目录EToolStripMenuItem_Click( object sender, EventArgs e )
        {
            if ( this.treeView.SelectedNode == null )
                return;

            TreeNodeFileInfo l_TreeNodeFileInfo = ExtractAllThread.s_nodeHybridDictionary[this.treeView.SelectedNode] as TreeNodeFileInfo;
            if ( l_TreeNodeFileInfo == null )
                return;

            if ( l_TreeNodeFileInfo.m_IsDirectory == true )
                ExtractAllThread.InitExtractDirectoryFile( this, this.treeView.SelectedNode );
        }

        private void listView_MouseDoubleClick( object sender, MouseEventArgs e )
        {
            ListViewItem l_ListViewItem = this.listView.GetItemAt(e.X, e.Y);
            if ( l_ListViewItem == null )
                return;

            ListViewItemFileInfo l_ListItemFileInfo = ExtractAllThread.s_ListItemHybridDictionary[l_ListViewItem] as ListViewItemFileInfo;
            if ( l_ListItemFileInfo == null )
                return;

            ExtractAllThread.InitExtractFile( this, l_ListItemFileInfo.m_strFullPath.Substring( 1 ), l_ListItemFileInfo.m_strFileName );
        }

        ListViewItemFileInfo m_ListItemFileInfoRight = null; 
        private void 替换文件ToolStripMenuItem_Click( object sender, EventArgs e )
        {
            if ( m_ListItemFileInfoRight == null )
                return;

            this.openFileDialog.FileName = m_ListItemFileInfoRight.m_strFileName;
            if ( this.openFileDialog.ShowDialog() == DialogResult.OK )
            {
                ExtractAllThread.InitExtractSwapFile( this, this.openFileDialog.FileName, m_ListItemFileInfoRight.m_strFullPath.Substring( 1 ), m_ListItemFileInfoRight.m_strInArchive );
            }

            m_ListItemFileInfoRight = null;
        }

        private void listView_MouseClick( object sender, MouseEventArgs e )
        {
            ListViewItem l_ListViewItem = this.listView.GetItemAt( e.X, e.Y );
            if ( l_ListViewItem == null )
                return;

            ListViewItemFileInfo l_ListItemFileInfo = ExtractAllThread.s_ListItemHybridDictionary[l_ListViewItem] as ListViewItemFileInfo;
            if ( l_ListItemFileInfo == null )
                return;

            if ( e.Button == MouseButtons.Right )
                m_ListItemFileInfoRight = l_ListItemFileInfo;
            else
                m_ListItemFileInfoRight = null;

            if ( l_ListItemFileInfo.m_iChecksum == 0 )
            {
                string l_strFullPath = l_ListItemFileInfo.m_strFullPath.Substring( 1 );
                TriggerVFS.FileInfo l_FileInfo = new TriggerVFS.FileInfo();
                if ( ExtractAllThread.s_TriggerVFS.GetFileInfo( l_strFullPath, ref l_FileInfo ) == true )
                {
                    l_ListItemFileInfo.m_iAttribute = l_FileInfo.m_iAttribute;
                    l_ListItemFileInfo.m_iChecksum = l_FileInfo.m_iChecksum;
                }
                else
                    this.richTextBox.AppendText( "GetFileInfo(" + l_strFullPath + ") Error!\n" );

                l_ListItemFileInfo.m_iFileSize = ExtractAllThread.s_TriggerVFS.GetFileSize( l_strFullPath );
            }

            this.textBox1.Text = l_ListItemFileInfo.m_strFullPath.ToString();
            this.textBox6.Text = l_ListItemFileInfo.m_strInArchive.ToString();
            this.textBox5.Text = l_ListItemFileInfo.m_iArchiveNumber.ToString();
            this.textBox3.Text = l_ListItemFileInfo.m_iAttribute.ToString();
            this.textBox2.Text = string.Format( "0x{0:X}", ((int)l_ListItemFileInfo.m_iChecksum) );
            this.textBox4.Text = l_ListItemFileInfo.m_iFileSize.ToString();
            this.textBox7.Text = false.ToString();
        }

        private void 替换全部文件SToolStripMenuItem_Click( object sender, EventArgs e )
        {
            if ( this.treeView.SelectedNode == null )
                return;

            TreeNodeFileInfo l_TreeNodeFileInfo = ExtractAllThread.s_nodeHybridDictionary[this.treeView.SelectedNode] as TreeNodeFileInfo;
            if ( l_TreeNodeFileInfo == null )
                return;

            if ( l_TreeNodeFileInfo.m_IsDirectory == true )
            {
                for ( int iIndex = 0; iIndex < l_TreeNodeFileInfo.m_ListViewItemFileInfo.Count; iIndex++ )
                {
                    this.openFileDialog.FileName = l_TreeNodeFileInfo.m_ListViewItemFileInfo[iIndex].m_strFileName;
                    if ( this.openFileDialog.ShowDialog() == DialogResult.OK )
                    {
                        ExtractAllThread.InitExtractSwapFile( this, this.openFileDialog.FileName, l_TreeNodeFileInfo.m_ListViewItemFileInfo[iIndex].m_strFullPath.Substring( 1 ), l_TreeNodeFileInfo.m_ListViewItemFileInfo[iIndex].m_strInArchive );
                    }
                }
            }
        }

        private void 替换全部STL文件SToolStripMenuItem_Click( object sender, EventArgs e )
        {
            if ( this.treeView.SelectedNode == null )
                return;

            TreeNodeFileInfo l_TreeNodeFileInfo = ExtractAllThread.s_nodeHybridDictionary[this.treeView.SelectedNode] as TreeNodeFileInfo;
            if ( l_TreeNodeFileInfo == null )
                return;

            if ( l_TreeNodeFileInfo.m_IsDirectory == true )
            {
                for ( int iIndex = 0; iIndex < l_TreeNodeFileInfo.m_ListViewItemFileInfo.Count; iIndex++ )
                {
                    if ( l_TreeNodeFileInfo.m_ListViewItemFileInfo[iIndex].m_strFileName.IndexOf(".STL") <= 0 )
                        continue;

                    this.openFileDialog.FileName = l_TreeNodeFileInfo.m_ListViewItemFileInfo[iIndex].m_strFileName;
                    if ( this.openFileDialog.ShowDialog() == DialogResult.OK )
                    {
                        ExtractAllThread.InitExtractSwapFile( this, this.openFileDialog.FileName, l_TreeNodeFileInfo.m_ListViewItemFileInfo[iIndex].m_strFullPath.Substring( 1 ), l_TreeNodeFileInfo.m_ListViewItemFileInfo[iIndex].m_strInArchive );
                    }
                }
            }
        }

        private void 替换全部STB文件SToolStripMenuItem_Click( object sender, EventArgs e )
        {
            if ( this.treeView.SelectedNode == null )
                return;

            TreeNodeFileInfo l_TreeNodeFileInfo = ExtractAllThread.s_nodeHybridDictionary[this.treeView.SelectedNode] as TreeNodeFileInfo;
            if ( l_TreeNodeFileInfo == null )
                return;

            if ( l_TreeNodeFileInfo.m_IsDirectory == true )
            {
                for ( int iIndex = 0; iIndex < l_TreeNodeFileInfo.m_ListViewItemFileInfo.Count; iIndex++ )
                {
                    if ( l_TreeNodeFileInfo.m_ListViewItemFileInfo[iIndex].m_strFileName.IndexOf( ".STB" ) <= 0 )
                        continue;

                    this.openFileDialog.FileName = l_TreeNodeFileInfo.m_ListViewItemFileInfo[iIndex].m_strFileName;
                    if ( this.openFileDialog.ShowDialog() == DialogResult.OK )
                    {
                        ExtractAllThread.InitExtractSwapFile( this, this.openFileDialog.FileName, l_TreeNodeFileInfo.m_ListViewItemFileInfo[iIndex].m_strFullPath.Substring( 1 ), l_TreeNodeFileInfo.m_ListViewItemFileInfo[iIndex].m_strInArchive );
                    }
                }
            }
        }

        private void treeView_MouseClick( object sender, MouseEventArgs e )
        {
            if ( e.Button == MouseButtons.Right )
            {
                TreeNode l_TreeNode = this.treeView.GetNodeAt( e.X, e.Y );
                if ( l_TreeNode == null )
                    return;
                else
                    this.treeView.SelectedNode = l_TreeNode;
            }
        }
    }
}

