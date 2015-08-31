using System;
using System.IO;
using System.Windows.Forms;
using Demo.Stock.X.Tools;

namespace Demo.Stock.X
{
    public partial class ToolsForm : Form
    {
        public ToolsForm()
        {
            InitializeComponent();
        }

        protected override void OnVisibleChanged( EventArgs eventArgs )
        {
            base.OnVisibleChanged( eventArgs );

            if ( this.Visible == true )
            {
                MainForm.Instance.AxSkinFramework.ApplyWindow( this.Handle.ToInt32() );
                this.BackColor = MainForm.Instance.AxSkinFramework.GetColor( XtremeSkinFramework.XTPColorManagerColor.STDCOLOR_BTNFACE );
            }
        }

        private void ToolsForm_Load( object sender, EventArgs e )
        {
        }

        private RandomDStockForm m_RandomDStockForm = new RandomDStockForm();
        private void ButtonRandomDStock_Click( object sender, EventArgs e )
        {
            m_RandomDStockForm.Show();
        }

        private void ButtonMSFLView_Click( object sender, EventArgs e )
        {
            MSFLViewForm msflViewForm = new MSFLViewForm();
            msflViewForm.Show();
        }

        private void ButtonKLineView_Click( object sender, EventArgs e )
        {
            KLineViewForm klineViewForm = new KLineViewForm();
            klineViewForm.Show();
        }

        private void ButtonBackupSetting_Click( object sender, EventArgs e )
        {
            this.FolderBrowserDialogSetting.ShowNewFolderButton = true;
            this.FolderBrowserDialogSetting.Description = "选择你需要备份的文件目录";
            if ( this.FolderBrowserDialogSetting.ShowDialog() == DialogResult.OK )
            {
                string[] strFiles = Directory.GetFiles( "Demo.Stock.Config", "*.*" );
                for ( int iIndex = 0; iIndex < strFiles.Length; iIndex++ )
                {
                    string strFile = strFiles[iIndex];
                    string strFileName = this.FolderBrowserDialogSetting.SelectedPath + "\\" + Path.GetFileName( strFile );

                    if ( File.Exists( strFileName ) == true )
                    {
                        DialogResult dialogResult = MessageBox.Show( strFileName + "文件已经存在,是否需要覆盖掉它？", "文件已存在", MessageBoxButtons.YesNoCancel );

                        if ( dialogResult == DialogResult.Cancel )
                            return;
                        else if ( dialogResult == DialogResult.No )
                            continue;
                        else if ( dialogResult == DialogResult.Yes )
                        {
                            File.SetAttributes( strFileName, FileAttributes.Archive );
                            File.Delete( strFileName );

                            File.Copy( strFile, strFileName );
                        }
                    }
                    else
                        File.Copy( strFile, strFileName );
                }
            }
        }

        private void ButtonRestoreSetting_Click( object sender, EventArgs e )
        {
            this.FolderBrowserDialogSetting.ShowNewFolderButton = false;
            this.FolderBrowserDialogSetting.Description = "选择你已经备份的文件目录";
            if ( this.FolderBrowserDialogSetting.ShowDialog() == DialogResult.OK )
            {
                string[] strFiles = Directory.GetFiles( this.FolderBrowserDialogSetting.SelectedPath, "*.*" );
                for ( int iIndex = 0; iIndex < strFiles.Length; iIndex++ )
                {
                    string strFile = strFiles[iIndex];
                    string strFileName = "Demo.Stock.Config\\" + Path.GetFileName( strFile );

                    if ( File.Exists( strFileName ) == true )
                    {
                        DialogResult dialogResult = MessageBox.Show( strFileName + "文件已经存在,是否需要覆盖掉它？", "文件已存在", MessageBoxButtons.YesNoCancel );

                        if ( dialogResult == DialogResult.Cancel )
                            return;
                        else if ( dialogResult == DialogResult.No )
                            continue;
                        else if ( dialogResult == DialogResult.Yes )
                        {
                            File.SetAttributes( strFileName, FileAttributes.Archive );
                            File.Delete( strFileName );

                            File.Copy( strFile, strFileName );
                        }
                        else
                            return;
                    }
                    else
                        File.Copy( strFile, strFileName );
                }
            }
        }
    }
}
