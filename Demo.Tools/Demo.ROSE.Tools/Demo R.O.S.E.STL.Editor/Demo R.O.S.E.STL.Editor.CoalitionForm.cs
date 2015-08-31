using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Demo_R.O.S.E.STL.Editor
{
    public partial class CoalitionForm : Form
    {
        public CoalitionForm()
        {
            InitializeComponent();
        }

        String m_strFileName = string.Empty;
        private void button1_Click( object sender, EventArgs e )
        {
            if ( this.openFileDialogFile1.ShowDialog() == DialogResult.OK )
            {
                this.textBoxFile1.Text = this.openFileDialogFile1.FileName;
                m_strFileName = this.openFileDialogFile1.FileName;
            }
        }

        private void button2_Click( object sender, EventArgs e )
        {
            if ( this.openFileDialogFile2.ShowDialog() == DialogResult.OK )
            {
                this.textBoxFile2.Text = this.openFileDialogFile2.FileName;
            }
        }

        private void button3_Click( object sender, EventArgs e )
        {
            this.saveFileDialog.FileName = m_strFileName;
            if ( this.saveFileDialog.ShowDialog() == DialogResult.OK )
            {
                this.textBoxSaveFile.Text = this.saveFileDialog.FileName;
            }
        }

        public STLData m_STLDataFile1 = new STLData();
        public STLData m_STLDataFile2 = new STLData();
        public STLData m_STLDataSave = new STLData();

        private void button4_Click( object sender, EventArgs e )
        {
            if ( STLData.LoadSTLData( ref m_STLDataFile1, this.textBoxFile1.Text ) == false )
            {
                MessageBox.Show(this.textBoxFile1.Text + "文件读取错误");
                return;
            }

            if ( STLData.LoadSTLData( ref m_STLDataFile2, this.textBoxFile2.Text ) == false )
            {
                MessageBox.Show( this.textBoxFile2.Text + "文件读取错误" );
                return;
            }

            STLData.Language l_LanguageKeep1 = new STLData.Language();
            if ( this.checkBox1.Checked == true )
                l_LanguageKeep1 |=  STLData.Language.Korean;

            if ( this.checkBox2.Checked == true )
                l_LanguageKeep1 |= STLData.Language.English;

            if ( this.checkBox3.Checked == true )
                l_LanguageKeep1 |= STLData.Language.Japanese;

            if ( this.checkBox4.Checked == true )
                l_LanguageKeep1 |= STLData.Language.ChinaTaiwan;

            if ( this.checkBox5.Checked == true )
                l_LanguageKeep1 |= STLData.Language.China;

            if ( STLData.CoalitionSTLData( ref m_STLDataSave, m_STLDataFile1, l_LanguageKeep1, m_STLDataFile2 ) == false )
            {
                MessageBox.Show( "文件合并检测时产生错误: 可能文件不匹配!" );
                return;
            }

            if ( STLData.SaveSTLData( m_STLDataSave, this.textBoxSaveFile.Text ) == false )
            {
                MessageBox.Show(this.textBoxSaveFile.Text + "文件保存错误" );
                return;
            }

            MessageBox.Show( "文件合并成功" );
        }
    }
}

