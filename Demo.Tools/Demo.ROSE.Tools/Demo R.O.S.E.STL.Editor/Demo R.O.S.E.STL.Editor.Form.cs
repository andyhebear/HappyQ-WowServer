using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Demo_R.O.S.E.STL.Editor
{
    public partial class STLEditorForm : Form
    {
        public STLData m_STLData = new STLData();

        public STLEditorForm()
        {
            InitializeComponent();
        }

        private void AboutToolStripMenuItem_Click( object sender, EventArgs e )
        {
            AboutForm l_AboutForm = new AboutForm();
            l_AboutForm.ShowDialog(this);
        }

        private void ExitToolStripMenuItem_Click( object sender, EventArgs e )
        {
            this.Close();
        }

        String m_strFileName = string.Empty;
        private void LoadToolStripMenuItem_Click( object sender, EventArgs e )
        {
            if ( this.openFileDialog.ShowDialog() == DialogResult.OK )
            {
                this.dataGridView.SuspendLayout();

                STLData.LoadSTLData( ref m_STLData, this.openFileDialog.FileName );
                m_strFileName = this.openFileDialog.FileName;

                this.Text = "Demo R.O.S.E.STL.Editor.Form" + "( " + this.openFileDialog.FileName + " )" + " - " + m_STLData.Length.ToString();

                this.dataGridView.DataSource = m_STLData.DataTable;
                this.dataGridView.Columns[0].ReadOnly = true;
                this.dataGridView.Columns[1].ReadOnly = true;
                this.dataGridView.AllowUserToAddRows = false;
                this.dataGridView.AllowUserToDeleteRows = false;

                this.dataGridView.ResumeLayout();

                this.CloseToolStripMenuItem.Enabled = true;
                this.SaveToolStripMenuItem.Enabled = true;
                this.SaveAsToolStripMenuItem.Enabled = true;
                this.LanguageToolStripMenuItem.Enabled = true;
                this.CommentToolStripMenuItem.Enabled = true;
                this.OtherToolStripMenuItem.Enabled = true;
                this.CommentToolStripMenuItem.Checked = true;
                this.OtherToolStripMenuItem.Checked = true;
                this.KoreanToolStripMenuItem.Checked = true;
                this.EnglishToolStripMenuItem.Checked = true;
                this.JapaneseToolStripMenuItem.Checked = true;
                this.ChinaTaiwanToolStripMenuItem.Checked = true;
                this.ChinaToolStripMenuItem.Checked = true;
                this.填充中文空字符串ToolStripMenuItem.Enabled = true;

                //　为了方便修改
                this.KoreanToolStripMenuItem.Checked = false;
                this.JapaneseToolStripMenuItem.Checked = false;
                this.OtherToolStripMenuItem.Checked = false;

                CheckedDataTable();
            }
        }

        #region Save STL Data
        private void SaveToolStripMenuItem_Click( object sender, EventArgs e )
        {
            this.dataGridView.CommitEdit( DataGridViewDataErrorContexts.Commit );

            SaveSTLData();

            STLData.SaveSTLData( m_STLData, m_STLData.FileName );
        }

        private void SaveAsToolStripMenuItem_Click( object sender, EventArgs e )
        {
            this.saveFileDialog.FileName = m_strFileName;
            if ( this.saveFileDialog.ShowDialog() == DialogResult.OK )
            {
                this.dataGridView.CommitEdit( DataGridViewDataErrorContexts.Commit );

                SaveSTLData();

                STLData.SaveSTLData( m_STLData, this.saveFileDialog.FileName );
            }
        }

        private void SaveSTLData()
        {
            for ( int iIndex = 0; iIndex < m_STLData.DataTable.Rows.Count; iIndex++ )
            {
                //////////////////////////////////////////////////////////////////////////
                m_STLData.KoreanString[iIndex].String = m_STLData.DataTable.Rows[iIndex].ItemArray[2] as string;
                
                if (m_STLData.KoreanString[iIndex].IsStringComment)
                    m_STLData.KoreanString[iIndex].StringComment = m_STLData.DataTable.Rows[iIndex].ItemArray[3] as string;

                if ( m_STLData.KoreanString[iIndex].IsStringOtherComment01 )
                    m_STLData.KoreanString[iIndex].StringOtherComment01 = m_STLData.DataTable.Rows[iIndex].ItemArray[4] as string;

                if ( m_STLData.KoreanString[iIndex].IsStringOtherComment02 )
                    m_STLData.KoreanString[iIndex].StringOtherComment02 = m_STLData.DataTable.Rows[iIndex].ItemArray[5] as string;

                //////////////////////////////////////////////////////////////////////////
                m_STLData.EnglishString[iIndex].String = m_STLData.DataTable.Rows[iIndex].ItemArray[6] as string;
  
                if ( m_STLData.EnglishString[iIndex].IsStringComment )
                    m_STLData.EnglishString[iIndex].StringComment = m_STLData.DataTable.Rows[iIndex].ItemArray[7] as string;

                if ( m_STLData.EnglishString[iIndex].IsStringOtherComment01 )
                    m_STLData.EnglishString[iIndex].StringOtherComment01 = m_STLData.DataTable.Rows[iIndex].ItemArray[8] as string;

                if ( m_STLData.EnglishString[iIndex].IsStringOtherComment02 )
                    m_STLData.EnglishString[iIndex].StringOtherComment02 = m_STLData.DataTable.Rows[iIndex].ItemArray[9] as string;

                //////////////////////////////////////////////////////////////////////////
                m_STLData.JapaneseString[iIndex].String = m_STLData.DataTable.Rows[iIndex].ItemArray[10] as string;

                if ( m_STLData.JapaneseString[iIndex].IsStringComment )
                    m_STLData.JapaneseString[iIndex].StringComment = m_STLData.DataTable.Rows[iIndex].ItemArray[11] as string;

                if ( m_STLData.JapaneseString[iIndex].IsStringOtherComment01 )
                    m_STLData.JapaneseString[iIndex].StringOtherComment01 = m_STLData.DataTable.Rows[iIndex].ItemArray[12] as string;

                if ( m_STLData.JapaneseString[iIndex].IsStringOtherComment02 )
                    m_STLData.JapaneseString[iIndex].StringOtherComment02 = m_STLData.DataTable.Rows[iIndex].ItemArray[13] as string;

                //////////////////////////////////////////////////////////////////////////
                m_STLData.ChinaTaiwanString[iIndex].String = m_STLData.DataTable.Rows[iIndex].ItemArray[14] as string;
   
                if ( m_STLData.ChinaTaiwanString[iIndex].IsStringComment )
                    m_STLData.ChinaTaiwanString[iIndex].StringComment = m_STLData.DataTable.Rows[iIndex].ItemArray[15] as string;

                if ( m_STLData.ChinaTaiwanString[iIndex].IsStringOtherComment01 )
                    m_STLData.ChinaTaiwanString[iIndex].StringOtherComment01 = m_STLData.DataTable.Rows[iIndex].ItemArray[16] as string;

                if ( m_STLData.ChinaTaiwanString[iIndex].IsStringOtherComment02 )
                    m_STLData.ChinaTaiwanString[iIndex].StringOtherComment02 = m_STLData.DataTable.Rows[iIndex].ItemArray[17] as string;

                //////////////////////////////////////////////////////////////////////////
                m_STLData.ChinaString[iIndex].String = m_STLData.DataTable.Rows[iIndex].ItemArray[18] as string;

                if ( m_STLData.ChinaString[iIndex].IsStringComment )
                    m_STLData.ChinaString[iIndex].StringComment = m_STLData.DataTable.Rows[iIndex].ItemArray[19] as string;

                if ( m_STLData.ChinaString[iIndex].IsStringOtherComment01 )
                    m_STLData.ChinaString[iIndex].StringOtherComment01 = m_STLData.DataTable.Rows[iIndex].ItemArray[20] as string;

                if ( m_STLData.ChinaString[iIndex].IsStringOtherComment02 )
                    m_STLData.ChinaString[iIndex].StringOtherComment02 = m_STLData.DataTable.Rows[iIndex].ItemArray[21] as string;
            }
        }
        #endregion

        private void CloseToolStripMenuItem_Click( object sender, EventArgs e )
        {
            this.CloseToolStripMenuItem.Enabled = false;
            this.SaveToolStripMenuItem.Enabled = false;
            this.SaveAsToolStripMenuItem.Enabled = false;
            this.LanguageToolStripMenuItem.Enabled = false;
            this.CommentToolStripMenuItem.Enabled = false;
            this.OtherToolStripMenuItem.Enabled = false;
            this.CommentToolStripMenuItem.Checked = false;
            this.OtherToolStripMenuItem.Checked = false;
            this.KoreanToolStripMenuItem.Checked = false;
            this.EnglishToolStripMenuItem.Checked = false;
            this.JapaneseToolStripMenuItem.Checked = false;
            this.ChinaTaiwanToolStripMenuItem.Checked = false;
            this.ChinaToolStripMenuItem.Checked = false;
            this.填充中文空字符串ToolStripMenuItem.Enabled = false;

            this.dataGridView.SuspendLayout();

            DataTable l_DataTable = this.dataGridView.DataSource as DataTable;
            l_DataTable.Columns.Clear();
            l_DataTable.Rows.Clear();

            this.dataGridView.ResumeLayout();

            this.Text = "Demo R.O.S.E.STL.Editor.Form";
        }

        #region Checked DataTable
        private void KoreanToolStripMenuItem_Click( object sender, EventArgs e )
        {
            if ( this.KoreanToolStripMenuItem.Checked == true )
                this.KoreanToolStripMenuItem.Checked = false;
            else
                this.KoreanToolStripMenuItem.Checked = true;

            CheckedDataTable();
        }

        private void EnglishToolStripMenuItem_Click( object sender, EventArgs e )
        {
            if ( this.EnglishToolStripMenuItem.Checked == true )
                this.EnglishToolStripMenuItem.Checked = false;
            else
                this.EnglishToolStripMenuItem.Checked = true;

            CheckedDataTable();
        }

        private void JapaneseToolStripMenuItem_Click( object sender, EventArgs e )
        {
            if ( this.JapaneseToolStripMenuItem.Checked == true )
                this.JapaneseToolStripMenuItem.Checked = false;
            else
                this.JapaneseToolStripMenuItem.Checked = true;

            CheckedDataTable();
        }

        private void ChinaTaiwanToolStripMenuItem_Click( object sender, EventArgs e )
        {
            if ( this.ChinaTaiwanToolStripMenuItem.Checked == true )
                this.ChinaTaiwanToolStripMenuItem.Checked = false;
            else
                this.ChinaTaiwanToolStripMenuItem.Checked = true;

            CheckedDataTable();
        }

        private void ChinaToolStripMenuItem_Click( object sender, EventArgs e )
        {
            if ( this.ChinaToolStripMenuItem.Checked == true )
                this.ChinaToolStripMenuItem.Checked = false;
            else
                this.ChinaToolStripMenuItem.Checked = true;

            CheckedDataTable();
        }

        private void CommentToolStripMenuItem_Click( object sender, EventArgs e )
        {
            if ( this.CommentToolStripMenuItem.Checked == true )
                this.CommentToolStripMenuItem.Checked = false;
            else
                this.CommentToolStripMenuItem.Checked = true;

            CheckedDataTable();
        }

        private void OtherToolStripMenuItem_Click( object sender, EventArgs e )
        {
            if ( this.OtherToolStripMenuItem.Checked == true )
                this.OtherToolStripMenuItem.Checked = false;
            else
                this.OtherToolStripMenuItem.Checked = true;

            CheckedDataTable();
        }

        private void CheckedDataTable()
        {
            this.dataGridView.SuspendLayout();

            if ( this.KoreanToolStripMenuItem.Checked == false )
            {
                this.dataGridView.Columns[2].Visible = false;
                this.dataGridView.Columns[3].Visible = false;
                this.dataGridView.Columns[4].Visible = false;
                this.dataGridView.Columns[5].Visible = false;
            }
            else
            {
                this.dataGridView.Columns[2].Visible = true;
                this.dataGridView.Columns[3].Visible = true;
                this.dataGridView.Columns[4].Visible = true;
                this.dataGridView.Columns[5].Visible = true;
            }

            if ( this.EnglishToolStripMenuItem.Checked == false )
            {
                this.dataGridView.Columns[6].Visible = false;
                this.dataGridView.Columns[7].Visible = false;
                this.dataGridView.Columns[8].Visible = false;
                this.dataGridView.Columns[9].Visible = false;
            }
            else
            {
                this.dataGridView.Columns[6].Visible = true;
                this.dataGridView.Columns[7].Visible = true;
                this.dataGridView.Columns[8].Visible = true;
                this.dataGridView.Columns[9].Visible = true;
            }

            if ( this.JapaneseToolStripMenuItem.Checked == false )
            {
                this.dataGridView.Columns[10].Visible = false;
                this.dataGridView.Columns[11].Visible = false;
                this.dataGridView.Columns[12].Visible = false;
                this.dataGridView.Columns[13].Visible = false;
            }
            else
            {
                this.dataGridView.Columns[10].Visible = true;
                this.dataGridView.Columns[11].Visible = true;
                this.dataGridView.Columns[12].Visible = true;
                this.dataGridView.Columns[13].Visible = true;
            }

            if ( this.ChinaTaiwanToolStripMenuItem.Checked == false )
            {
                this.dataGridView.Columns[14].Visible = false;
                this.dataGridView.Columns[15].Visible = false;
                this.dataGridView.Columns[16].Visible = false;
                this.dataGridView.Columns[17].Visible = false;
            }
            else
            {
                this.dataGridView.Columns[14].Visible = true;
                this.dataGridView.Columns[15].Visible = true;
                this.dataGridView.Columns[16].Visible = true;
                this.dataGridView.Columns[17].Visible = true;
            }

            if ( this.ChinaToolStripMenuItem.Checked == false )
            {
                this.dataGridView.Columns[18].Visible = false;
                this.dataGridView.Columns[19].Visible = false;
                this.dataGridView.Columns[20].Visible = false;
                this.dataGridView.Columns[21].Visible = false;
            }
            else
            {
                this.dataGridView.Columns[18].Visible = true;
                this.dataGridView.Columns[19].Visible = true;
                this.dataGridView.Columns[20].Visible = true;
                this.dataGridView.Columns[21].Visible = true;
            }

            if ( this.OtherToolStripMenuItem.Checked == false )
            {
                this.dataGridView.Columns[4].Visible = false;
                this.dataGridView.Columns[5].Visible = false;
                this.dataGridView.Columns[8].Visible = false;
                this.dataGridView.Columns[9].Visible = false;
                this.dataGridView.Columns[12].Visible = false;
                this.dataGridView.Columns[13].Visible = false;
                this.dataGridView.Columns[16].Visible = false;
                this.dataGridView.Columns[17].Visible = false;
                this.dataGridView.Columns[20].Visible = false;
                this.dataGridView.Columns[21].Visible = false;
            }
            else
            {
                if ( this.KoreanToolStripMenuItem.Checked == false)
                {
                    this.dataGridView.Columns[4].Visible = false;
                    this.dataGridView.Columns[5].Visible = false;
                }
                else
                {
                    this.dataGridView.Columns[4].Visible = true;
                    this.dataGridView.Columns[5].Visible = true;
                }

                if ( this.EnglishToolStripMenuItem.Checked == false )
                {
                    this.dataGridView.Columns[8].Visible = false;
                    this.dataGridView.Columns[9].Visible = false;
                }
                else
                {
                    this.dataGridView.Columns[8].Visible = true;
                    this.dataGridView.Columns[9].Visible = true;
                }

                if ( this.JapaneseToolStripMenuItem.Checked == false )
                {
                    this.dataGridView.Columns[12].Visible = false;
                    this.dataGridView.Columns[13].Visible = false;
                }
                else
                {
                    this.dataGridView.Columns[12].Visible = true;
                    this.dataGridView.Columns[13].Visible = true;
                }

                if ( this.ChinaTaiwanToolStripMenuItem.Checked == false )
                {
                    this.dataGridView.Columns[16].Visible = false;
                    this.dataGridView.Columns[17].Visible = false;
                }
                else
                {
                    this.dataGridView.Columns[16].Visible = true;
                    this.dataGridView.Columns[17].Visible = true;
                }

                if ( this.ChinaToolStripMenuItem.Checked == false )
                {
                    this.dataGridView.Columns[20].Visible = false;
                    this.dataGridView.Columns[21].Visible = false;
                }
                else
                {
                    this.dataGridView.Columns[20].Visible = true;
                    this.dataGridView.Columns[21].Visible = true;
                }
            }

            if ( this.CommentToolStripMenuItem.Checked == false )
            {
                this.dataGridView.Columns[3].Visible = false;
                this.dataGridView.Columns[7].Visible = false;
                this.dataGridView.Columns[11].Visible = false;
                this.dataGridView.Columns[15].Visible = false;
                this.dataGridView.Columns[19].Visible = false;
            }
            else
            {
                if ( this.KoreanToolStripMenuItem.Checked == false )
                    this.dataGridView.Columns[3].Visible = false;
                else
                    this.dataGridView.Columns[3].Visible = true;

                if ( this.EnglishToolStripMenuItem.Checked == false )
                    this.dataGridView.Columns[7].Visible = false;
                else
                    this.dataGridView.Columns[7].Visible = true;

                if ( this.JapaneseToolStripMenuItem.Checked == false )
                    this.dataGridView.Columns[11].Visible = false;
                else
                    this.dataGridView.Columns[11].Visible = true;

                if ( this.ChinaTaiwanToolStripMenuItem.Checked == false )
                    this.dataGridView.Columns[15].Visible = false;
                else
                    this.dataGridView.Columns[15].Visible = true;

                if ( this.ChinaToolStripMenuItem.Checked == false )
                    this.dataGridView.Columns[19].Visible = false;
                else
                    this.dataGridView.Columns[19].Visible = true;
            }

            this.dataGridView.ResumeLayout();
        }
        #endregion

        private void CoalitionFileToolStripMenuItem_Click( object sender, EventArgs e )
        {
            CoalitionForm l_CoalitionForm = new CoalitionForm();
            l_CoalitionForm.ShowDialog(this);
        }

        private void 填充中文空字符串ToolStripMenuItem_Click( object sender, EventArgs e )
        {
            // 填充空的字符串
            for ( int iIndex = 0; iIndex < m_STLData.DataTable.Rows.Count; iIndex++ )
            {
                // Korean
                string l_strFieldInfo2 = m_STLData.DataTable.Rows[iIndex][2].ToString();
                string l_strFieldInfo3 = m_STLData.DataTable.Rows[iIndex][3].ToString();
                string l_strFieldInfo4 = m_STLData.DataTable.Rows[iIndex][4].ToString();
                string l_strFieldInfo5 = m_STLData.DataTable.Rows[iIndex][5].ToString();

                // English
                string l_strFieldInfo6 = m_STLData.DataTable.Rows[iIndex][6].ToString();
                string l_strFieldInfo7 = m_STLData.DataTable.Rows[iIndex][7].ToString();
                string l_strFieldInfo8 = m_STLData.DataTable.Rows[iIndex][8].ToString();
                string l_strFieldInfo9 = m_STLData.DataTable.Rows[iIndex][9].ToString();

                // Japanese
                string l_strFieldInfo10 = m_STLData.DataTable.Rows[iIndex][10].ToString();
                string l_strFieldInfo11 = m_STLData.DataTable.Rows[iIndex][11].ToString();
                string l_strFieldInfo12 = m_STLData.DataTable.Rows[iIndex][12].ToString();
                string l_strFieldInfo13 = m_STLData.DataTable.Rows[iIndex][13].ToString();

                // China-Taiwan
                string l_strFieldInfo14 = m_STLData.DataTable.Rows[iIndex][14].ToString();
                string l_strFieldInfo15 = m_STLData.DataTable.Rows[iIndex][15].ToString();
                string l_strFieldInfo16 = m_STLData.DataTable.Rows[iIndex][16].ToString();
                string l_strFieldInfo17 = m_STLData.DataTable.Rows[iIndex][17].ToString();

                // China
                string l_strFieldInfo18 = m_STLData.DataTable.Rows[iIndex][18].ToString();
                string l_strFieldInfo19 = m_STLData.DataTable.Rows[iIndex][19].ToString();
                string l_strFieldInfo20 = m_STLData.DataTable.Rows[iIndex][20].ToString();
                string l_strFieldInfo21 = m_STLData.DataTable.Rows[iIndex][21].ToString();

                if ( l_strFieldInfo18 == null || l_strFieldInfo18 == string.Empty )
                {
                    if ( l_strFieldInfo6 != null && l_strFieldInfo6 != string.Empty )
                    {
                        m_STLData.DataTable.Rows[iIndex][18] = l_strFieldInfo6;

                        if ( l_strFieldInfo14 == null || l_strFieldInfo14 == string.Empty )
                            m_STLData.DataTable.Rows[iIndex][14] = l_strFieldInfo6;
                    }
                    else if ( l_strFieldInfo2 != null && l_strFieldInfo2 != string.Empty )
                    {
                        m_STLData.DataTable.Rows[iIndex][18] = l_strFieldInfo2;

                        if ( l_strFieldInfo14 == null || l_strFieldInfo14 == string.Empty )
                            m_STLData.DataTable.Rows[iIndex][14] = l_strFieldInfo2;
                    }
                    else if ( l_strFieldInfo10 != null && l_strFieldInfo10 != string.Empty )
                    {
                        m_STLData.DataTable.Rows[iIndex][18] = l_strFieldInfo10;

                        if ( l_strFieldInfo14 == null || l_strFieldInfo14 == string.Empty )
                            m_STLData.DataTable.Rows[iIndex][14] = l_strFieldInfo10;
                    }
                }

                if ( l_strFieldInfo19 == null || l_strFieldInfo19 == string.Empty )
                {
                    if ( l_strFieldInfo7 != null && l_strFieldInfo7 != string.Empty )
                    {
                        m_STLData.DataTable.Rows[iIndex][19] = l_strFieldInfo7;

                        if ( l_strFieldInfo15 == null || l_strFieldInfo15 == string.Empty )
                            m_STLData.DataTable.Rows[iIndex][15] = l_strFieldInfo7;
                    }
                    else if ( l_strFieldInfo3 != null && l_strFieldInfo3 != string.Empty )
                    {
                        m_STLData.DataTable.Rows[iIndex][19] = l_strFieldInfo3;

                        if ( l_strFieldInfo15 == null || l_strFieldInfo15 == string.Empty )
                            m_STLData.DataTable.Rows[iIndex][15] = l_strFieldInfo3;
                    }
                    else if ( l_strFieldInfo11 != null && l_strFieldInfo11 != string.Empty )
                    {
                        m_STLData.DataTable.Rows[iIndex][19] = l_strFieldInfo11;

                        if ( l_strFieldInfo15 == null || l_strFieldInfo15 == string.Empty )
                            m_STLData.DataTable.Rows[iIndex][15] = l_strFieldInfo11;
                    }
                }

                if ( l_strFieldInfo20 == null || l_strFieldInfo20 == string.Empty )
                {
                    if ( l_strFieldInfo8 != null && l_strFieldInfo8 != string.Empty )
                    {
                        m_STLData.DataTable.Rows[iIndex][20] = l_strFieldInfo8;

                        if ( l_strFieldInfo16 == null || l_strFieldInfo16 == string.Empty )
                            m_STLData.DataTable.Rows[iIndex][16] = l_strFieldInfo8;
                    }
                    else if ( l_strFieldInfo4 != null && l_strFieldInfo4 != string.Empty )
                    {
                        m_STLData.DataTable.Rows[iIndex][20] = l_strFieldInfo4;

                        if ( l_strFieldInfo16 == null || l_strFieldInfo16 == string.Empty )
                            m_STLData.DataTable.Rows[iIndex][16] = l_strFieldInfo4;
                    }
                    else if ( l_strFieldInfo12 != null && l_strFieldInfo12 != string.Empty )
                    {
                        m_STLData.DataTable.Rows[iIndex][20] = l_strFieldInfo12;

                        if ( l_strFieldInfo16 == null || l_strFieldInfo16 == string.Empty )
                            m_STLData.DataTable.Rows[iIndex][16] = l_strFieldInfo12;
                    }
                }

                if ( l_strFieldInfo21 == null || l_strFieldInfo21 == string.Empty )
                {
                    if ( l_strFieldInfo9 != null && l_strFieldInfo9 != string.Empty )
                    {
                        m_STLData.DataTable.Rows[iIndex][21] = l_strFieldInfo9;

                        if ( l_strFieldInfo17 == null || l_strFieldInfo17 == string.Empty )
                            m_STLData.DataTable.Rows[iIndex][17] = l_strFieldInfo6;
                    }
                    else if ( l_strFieldInfo5 != null && l_strFieldInfo5 != string.Empty )
                    {
                        m_STLData.DataTable.Rows[iIndex][21] = l_strFieldInfo5;

                        if ( l_strFieldInfo17 == null || l_strFieldInfo17 == string.Empty )
                            m_STLData.DataTable.Rows[iIndex][17] = l_strFieldInfo5;
                    }
                    else if ( l_strFieldInfo13 != null && l_strFieldInfo13 != string.Empty )
                    {
                        m_STLData.DataTable.Rows[iIndex][21] = l_strFieldInfo13;

                        if ( l_strFieldInfo17 == null || l_strFieldInfo17 == string.Empty )
                            m_STLData.DataTable.Rows[iIndex][17] = l_strFieldInfo13;
                    }
                }
            }
        }
    }
}

