using System;
using System.IO;
using System.Text;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

namespace Demo.EncodeConvert.Tool
{
    public partial class EncodeConvertForm : Form
    {
        private class EncodeConvertFileInfo
        {
            public bool m_bIsFolder = false;
            public string m_strFolderOrFile = string.Empty;
        }

        Dictionary<string, EncodeConvertFileInfo> m_EncodeConvertFileInfo = new Dictionary<string, EncodeConvertFileInfo>();

        public EncodeConvertForm()
        {
            InitializeComponent();
        }

        private void EncodeConvertForm_Load( object sender, EventArgs e )
        {
            this.SourceComboBox.SelectedIndex = 3;
            this.TargetComboBox.SelectedIndex = 0;
        }

        private void ConversionButton_Click( object sender, EventArgs e )
        {
            string strInclude = ";" + this.IncludeTextBox.Text.ToLower() + ";";
            string strFilter = ";" + this.FilterTextBox.Text.ToLower() + ";";

            foreach ( KeyValuePair<string, EncodeConvertFileInfo> keyValuePair in m_EncodeConvertFileInfo )
            {
                EncodeConvertFileInfo encodeConvertFileInfo = keyValuePair.Value;

                if ( encodeConvertFileInfo.m_bIsFolder )
                {
                    ArrayList listFileName = new ArrayList();
                    this.GetSubDirFiles( encodeConvertFileInfo.m_strFolderOrFile, ref listFileName, strInclude, strFilter, this.SubFolderCheckBox.Checked );

                    foreach ( string strFile in listFileName )
                        ConvertFile( strFile, this.SourceComboBox.Text, this.TargetComboBox.Text );
                }
                else
                {
                    ConvertFile( encodeConvertFileInfo.m_strFolderOrFile, this.SourceComboBox.Text, this.TargetComboBox.Text );
                }
            }

            FileListBox.Items.Clear();
            m_EncodeConvertFileInfo.Clear();
        }

        private void GetSubDirFiles( string strFolderPath, ref ArrayList strFiles, string strInclude, string strFilter, bool bIsIncludeSub )
        {
            string strFileExt = string.Empty;
            DirectoryInfo directoryInfo = new DirectoryInfo( strFolderPath );
            FileInfo[] fileInfoArray = directoryInfo.GetFiles();

            foreach ( FileInfo fileInfo in fileInfoArray )
            {
                strFileExt = fileInfo.Extension.Replace( ".", "" );
                if ( ( strInclude.IndexOf( ";*;" ) >= 0 ) || ( strInclude.IndexOf( ";" + strFileExt + ";" ) >= 0 ) )
                {
                    if ( ( strFilter.IndexOf( ";*;" ) >= 0 ) || ( strFilter.IndexOf( ";" + strFileExt + ";" ) >= 0 ) )
                        continue;

                    strFiles.Add( fileInfo.FullName );
                }
            }

            if ( bIsIncludeSub )
            {
                DirectoryInfo[] subFileInfoArray = directoryInfo.GetDirectories();

                foreach ( DirectoryInfo subDirectoryInfo in subFileInfoArray )
                    this.GetSubDirFiles( subDirectoryInfo.FullName, ref strFiles, strInclude, strFilter, bIsIncludeSub );
            }
        }

        private Encoding GetEncoding( string strEncoding )
        {
            return Encoding.GetEncoding( strEncoding );
        }

        private void ConvertFile( string strFile, string strSourceEncode, string strTargetEncode )
        {
            Encoding encoding1 = GetEncoding( strSourceEncode );
            Encoding encoding2 = GetEncoding( strTargetEncode );

            if ( File.Exists( strFile ) == false )
                return;

            int iIndex = 0;
            string strFileNameBak = strFile;

            if ( BakFileCheckBox.Checked == true )
            {
                strFileNameBak += ".bak";

                do
                {
                    if ( File.Exists( strFileNameBak ) == false )
                    {
                        File.Move( strFile, strFileNameBak );
                        break;
                    }
                    else
                    {
                        ++iIndex;
                        strFileNameBak = strFile + ".bak" + iIndex;
                    }
                } while ( true );
            }

            StreamReader streamReader = new StreamReader( strFileNameBak, encoding1, true );
            StreamWriter streamWriter = new StreamWriter( strFile, false, encoding2 );

            string strLine = null;
            do
            {
                strLine = streamReader.ReadLine();
                streamWriter.WriteLine( strLine );
            } while (strLine != null);

            streamReader.Close();
            streamWriter.Close();

            this.InfoRichTextBox.AppendText( "文件 " + strFile + " 转换完成!\n" );
        }


        private void RemoveAllFileButton_Click( object sender, EventArgs e )
        {
            this.FileListBox.Items.Clear();
            this.m_EncodeConvertFileInfo.Clear();
        }

        private void RemoveFileButton_Click( object sender, EventArgs e )
        {
            for ( int index = this.FileListBox.SelectedIndices.Count - 1; index >= 0; index-- )
            {
                int Itemindex = this.FileListBox.SelectedIndices[index];

                m_EncodeConvertFileInfo.Remove( this.FileListBox.Items[Itemindex] as string );

                this.FileListBox.Items.RemoveAt( Itemindex );
            }
        }

        private void AddFileButton_Click( object sender, EventArgs e )
        {
            string strInclude = ";" + this.IncludeTextBox.Text.ToLower() + ";";
            string strFilter = ";" + this.FilterTextBox.Text.ToLower() + ";";

            System.Diagnostics.Debug.WriteLine( strInclude );
            if ( this.openFileDialog.ShowDialog( this ) == DialogResult.OK )
            {
                string[] strFileNameArray = this.openFileDialog.FileNames;

                foreach ( string strFile in strFileNameArray )
                {
                    string strExtension = new FileInfo( strFile ).Extension.Replace( ".", "" ).ToLower();

                    System.Diagnostics.Debug.WriteLine( strExtension );

                    if ( ( strInclude.IndexOf( ";*;" ) >= 0 ) || ( strInclude.IndexOf( strExtension + ";" ) >= 0 ) )
                    {
                        if ( ( strFilter.IndexOf( ";*;" ) >= 0 ) || ( strFilter.IndexOf( strExtension + ";" ) >= 0 ) )
                            continue;

                        EncodeConvertFileInfo outEncodeConvertFileInfo = null;
                        if ( m_EncodeConvertFileInfo.TryGetValue( strFile, out outEncodeConvertFileInfo ) )
                            continue;

                        EncodeConvertFileInfo encodeConvertFileInfo = new EncodeConvertFileInfo();
                        encodeConvertFileInfo.m_strFolderOrFile = strFile;
                        encodeConvertFileInfo.m_bIsFolder = false;

                        m_EncodeConvertFileInfo.Add( strFile, encodeConvertFileInfo );

                        FileListBox.Items.Add( strFile );
                    }
                }
            }
        }

        private void AddFolderButton_Click( object sender, EventArgs e )
        {
            if ( this.folderBrowserDialog.ShowDialog( this ) == DialogResult.OK )
            {
                string strFolder = folderBrowserDialog.SelectedPath;

                EncodeConvertFileInfo encodeConvertFileInfo = new EncodeConvertFileInfo();
                encodeConvertFileInfo.m_strFolderOrFile = strFolder;
                encodeConvertFileInfo.m_bIsFolder = true;

                m_EncodeConvertFileInfo.Add( strFolder, encodeConvertFileInfo );

                FileListBox.Items.Add( (string)strFolder );
            }
        }

        private void AboutButton_Click( object sender, EventArgs e )
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }
    }
}


