using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

namespace Demo_R.O.S.E.LTB.Editor
{
    public partial class LTBEditorForm : Form
    {
        public LTBEditorForm()
        {
            InitializeComponent();
        }

        private void AboutDemoROSESTBEditorAToolStripMenuItem_Click( object sender, EventArgs e )
        {
            Demo_R.O.S.E.LTB.Editor.AboutForm l_Form = new AboutForm();
            l_Form.ShowDialog( this );
        }

        LTBData m_LTBData = new LTBData();
        string m_strFileName = string.Empty;
        private void LoadToolStripMenuItem_Click( object sender, EventArgs e )
        {
            if ( this.openFileDialog.ShowDialog() == DialogResult.OK )
            {
                this.dataGridView.SuspendLayout();

                LTBData.LoadLTBData( ref m_LTBData, this.openFileDialog.FileName );
                m_strFileName = this.openFileDialog.FileName;

                this.dataGridView.DataSource = m_LTBData.DataTable;

                this.dataGridView.Columns[0].ReadOnly = true;

                this.Text = "Demo R.O.S.E.STB.Editor.Form" + "( " + m_LTBData.RowCount.ToString() + " )";

                this.dataGridView.AllowUserToAddRows = false;
                this.dataGridView.AllowUserToDeleteRows = false;

                this.dataGridView.ResumeLayout();

                this.CloseToolStripMenuItem.Enabled = true;
                this.SaveToolStripMenuItem.Enabled = true;
                this.SaveAsToolStripMenuItem.Enabled = true;
                this.LanguageToolStripMenuItem.Enabled = true;
                this.自动填充空的字符串ToolStripMenuItem.Enabled = true;

                //　为了方便修改
                this.KoreanToolStripMenuItem.Checked = false;
                this.JapaneseToolStripMenuItem.Checked = false;


                CheckedDataTable();
            }
        }

        private void SaveToolStripMenuItem_Click( object sender, EventArgs e )
        {
            this.dataGridView.CommitEdit( DataGridViewDataErrorContexts.Commit );

            LTBData.SaveLTBData( ref m_LTBData, m_LTBData.FileName );
        }

        private void SaveAsToolStripMenuItem_Click( object sender, EventArgs e )
        {
            this.saveFileDialog.FileName = m_strFileName;
            if ( this.saveFileDialog.ShowDialog() == DialogResult.OK )
            {
                this.dataGridView.CommitEdit( DataGridViewDataErrorContexts.Commit );

                LTBData.SaveLTBData( ref m_LTBData, this.saveFileDialog.FileName );
            }
        }

        private void CloseToolStripMenuItem_Click( object sender, EventArgs e )
        {
            this.CloseToolStripMenuItem.Enabled = false;
            this.SaveToolStripMenuItem.Enabled = false;
            this.SaveAsToolStripMenuItem.Enabled = false;
            this.LanguageToolStripMenuItem.Enabled = false;
            this.自动填充空的字符串ToolStripMenuItem.Enabled = false;

            this.dataGridView.SuspendLayout();

            DataTable l_DataTable = this.dataGridView.DataSource as DataTable;
            if ( l_DataTable != null )
            {
                l_DataTable.Columns.Clear();
                l_DataTable.Rows.Clear();
            }

            this.Text = "Demo R.O.S.E.LTB.Editor.Form";

            this.dataGridView.ResumeLayout();
        }

        private void ExitToolStripMenuItem_Click( object sender, EventArgs e )
        {
            this.Close();
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

        private void Language01ToolStripMenuItem_Click( object sender, EventArgs e )
        {
            if ( this.Language01ToolStripMenuItem.Checked == true )
                this.Language01ToolStripMenuItem.Checked = false;
            else
                this.Language01ToolStripMenuItem.Checked = true;

            CheckedDataTable();
        }

        private void Language02ToolStripMenuItem_Click( object sender, EventArgs e )
        {
            if ( this.Language02ToolStripMenuItem.Checked == true )
                this.Language02ToolStripMenuItem.Checked = false;
            else
                this.Language02ToolStripMenuItem.Checked = true;

            CheckedDataTable();
        }

        private void CheckedDataTable()
        {
            this.dataGridView.SuspendLayout();

            if ( this.KoreanToolStripMenuItem.Checked == false )
                this.dataGridView.Columns[1].Visible = false;
            else
                this.dataGridView.Columns[1].Visible = true;

            if ( this.EnglishToolStripMenuItem.Checked == false )
                this.dataGridView.Columns[2].Visible = false;
            else
                this.dataGridView.Columns[2].Visible = true;

            if ( this.JapaneseToolStripMenuItem.Checked == false )
                this.dataGridView.Columns[3].Visible = false;
            else
                this.dataGridView.Columns[3].Visible = true;

            if ( this.ChinaTaiwanToolStripMenuItem.Checked == false )
                this.dataGridView.Columns[4].Visible = false;
            else
                this.dataGridView.Columns[4].Visible = true;

            if ( this.ChinaToolStripMenuItem.Checked == false )
                this.dataGridView.Columns[5].Visible = false;
            else
                this.dataGridView.Columns[5].Visible = true;

            if ( this.Language01ToolStripMenuItem.Checked == false )
                this.dataGridView.Columns[6].Visible = false;
            else
                this.dataGridView.Columns[6].Visible = true;

            if ( this.Language02ToolStripMenuItem.Checked == false )
                this.dataGridView.Columns[7].Visible = false;
            else
                this.dataGridView.Columns[7].Visible = true;

            this.dataGridView.ResumeLayout();
        }
        #endregion

        private void CoalitionFileToolStripMenuItem_Click( object sender, EventArgs e )
        {
            CoalitionForm l_CoalitionForm = new CoalitionForm();
            l_CoalitionForm.ShowDialog();
        }

        private void 自动填充空的字符串ToolStripMenuItem_Click( object sender, EventArgs e )
        {
            // 填充空的字符串
            for ( int iIndex = 0; iIndex < m_LTBData.DataTable.Rows.Count; iIndex++ )
            {
                string l_strFieldInfo1 = m_LTBData.DataTable.Rows[iIndex][1].ToString();
                string l_strFieldInfo2 = m_LTBData.DataTable.Rows[iIndex][2].ToString();
                string l_strFieldInfo3 = m_LTBData.DataTable.Rows[iIndex][3].ToString();
                string l_strFieldInfo4 = m_LTBData.DataTable.Rows[iIndex][4].ToString();
                string l_strFieldInfo5 = m_LTBData.DataTable.Rows[iIndex][5].ToString();

                if ( l_strFieldInfo5 == null || l_strFieldInfo5 == string.Empty )
                {
                    if ( l_strFieldInfo2 != null && l_strFieldInfo2 != string.Empty )
                    {
                        m_LTBData.DataTable.Rows[iIndex][5] = l_strFieldInfo2;

                        if ( l_strFieldInfo4 == null || l_strFieldInfo4 == string.Empty )
                            m_LTBData.DataTable.Rows[iIndex][4] = l_strFieldInfo2;
                    }
                    else if ( l_strFieldInfo1 != null && l_strFieldInfo1 != string.Empty )
                    {
                        m_LTBData.DataTable.Rows[iIndex][5] = l_strFieldInfo1;

                        if ( l_strFieldInfo4 == null || l_strFieldInfo4 == string.Empty )
                            m_LTBData.DataTable.Rows[iIndex][4] = l_strFieldInfo1;
                    }
                    else if ( l_strFieldInfo3 != null && l_strFieldInfo3 != string.Empty )
                    {
                        m_LTBData.DataTable.Rows[iIndex][5] = l_strFieldInfo3;

                        if ( l_strFieldInfo4 == null || l_strFieldInfo4 == string.Empty )
                            m_LTBData.DataTable.Rows[iIndex][4] = l_strFieldInfo3;
                    }
                }
            }
        }
    }
}

