using System;
using System.IO;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

namespace Demo_R.O.S.E.STB.Editor
{
    public partial class STBEditorForm : Form
    {
        public STBData m_STBData = new STBData();

        public STBEditorForm()
        {
            InitializeComponent();
        }

        string m_strFileName = string.Empty;
        private void LoadKoreaToolStripMenuItem_Click( object sender, EventArgs e )
        {
            if ( this.openFileDialog.ShowDialog() == DialogResult.OK )
            {
                this.dataGridView.SuspendLayout();

                STBData.LoadSTBDataKorea( ref m_STBData, this.openFileDialog.FileName );
                m_strFileName = this.openFileDialog.FileName;

                this.dataGridView.DataSource = m_STBData.DataTable;

                for ( int l_iIndex = 0; l_iIndex < m_STBData.ColumnsWidth.Length; l_iIndex++ )
                    this.dataGridView.Columns[l_iIndex].Width = m_STBData.ColumnsWidth[l_iIndex];

                for ( int l_iIndex = 0; l_iIndex < m_STBData.ColumnsHeaderText.Length; l_iIndex++ )
                    this.dataGridView.Columns[l_iIndex].HeaderText = m_STBData.ColumnsHeaderText[l_iIndex];

                this.dataGridView.Columns[0].ReadOnly = true;

                string l_strStructName = m_STBData.StructName == string.Empty ? "NULL" : m_STBData.StructName;
                this.Text = "Demo R.O.S.E.STB.Editor.Form" + "( " + m_strFileName + " )" + " Name = " + l_strStructName + " ";

                this.dataGridView.AllowUserToAddRows = false;
                this.dataGridView.AllowUserToDeleteRows = false;

                this.dataGridView.ResumeLayout();

                this.DelToolStripMenuItem.Enabled = true;
                this.AddToolStripMenuItem.Enabled = true;
                this.CloseToolStripMenuItem.Enabled = true;
                this.SaveToolStripMenuItem.Enabled = true;
                this.SaveAs949ToolStripMenuItem.Enabled = true;
                this.SaveAs936ToolStripMenuItem.Enabled = true;
                this.ColumnToolStripMenuItem.Enabled = true;
                this.StructToolStripMenuItem.Enabled = true;

                m_SaveLanguage = SaveLanguage.Korea;
            }
        }

        private void AboutToolStripMenuItem_Click( object sender, EventArgs e )
        {
            Demo_R.O.S.E.STB.Editor.AboutForm l_Form = new AboutForm();
            l_Form.ShowDialog(this);
        }

        private void AddToolStripMenuItem_Click( object sender, EventArgs e )
        {
            DataTable l_DataTable = this.dataGridView.DataSource as DataTable;
            DataRow l_DataRow = l_DataTable.NewRow();
            l_DataRow[0] = l_DataTable.Rows.Count;
            l_DataTable.Rows.Add( l_DataRow );
        }

        private void DelToolStripMenuItem_Click( object sender, EventArgs e )
        {
            DataTable l_DataTable = this.dataGridView.DataSource as DataTable;
            if ( this.dataGridView.CurrentRow.Index < l_DataTable.Rows.Count )
                l_DataTable.Rows[this.dataGridView.CurrentRow.Index].Delete();
        }

        private void CloseToolStripMenuItem_Click( object sender, EventArgs e )
        {
            this.DelToolStripMenuItem.Enabled = false;
            this.AddToolStripMenuItem.Enabled = false;
            this.CloseToolStripMenuItem.Enabled = false;
            this.SaveToolStripMenuItem.Enabled = false;
            this.SaveAs949ToolStripMenuItem.Enabled = false;
            this.SaveAs936ToolStripMenuItem.Enabled = false;
            this.ColumnToolStripMenuItem.Enabled = false;

            this.dataGridView.SuspendLayout();

            DataTable l_DataTable = this.dataGridView.DataSource as DataTable;
            l_DataTable.Columns.Clear();
            l_DataTable.Rows.Clear();

            this.Text = "Demo R.O.S.E.STB.Editor.Form";

            this.dataGridView.ResumeLayout();
        }

        enum SaveLanguage
        {
            None = 0x00,
            Korea = 0x01,
            China = 0x02,
        }

        SaveLanguage m_SaveLanguage = SaveLanguage.None;
        private void SaveToolStripMenuItem_Click( object sender, EventArgs e )
        {
            this.dataGridView.CommitEdit( DataGridViewDataErrorContexts.Commit );

            if ( m_SaveLanguage == SaveLanguage.Korea )
                STBData.SaveSTBDataKorea( ref m_STBData, m_STBData.FileName );
            else if ( m_SaveLanguage == SaveLanguage.China )
                STBData.SaveSTBDataChina( ref m_STBData, m_STBData.FileName );
        }

        private void SaveAsKoreaToolStripMenuItem_Click( object sender, EventArgs e )
        {
            this.saveFileDialog.FileName = m_strFileName;
            if ( this.saveFileDialog.ShowDialog() == DialogResult.OK )
            {
                this.dataGridView.CommitEdit( DataGridViewDataErrorContexts.Commit );

                STBData.SaveSTBDataKorea( ref m_STBData, this.saveFileDialog.FileName );
            }
        }

        private void ColumnToolStripMenuItem_Click( object sender, EventArgs e )
        {
            ColumnNamesForm l_ColumnNamesForm = new ColumnNamesForm(this);

            DataTable l_DataTable = this.dataGridView.DataSource as DataTable;
            for ( int iIndex = 0; iIndex < l_DataTable.Columns.Count - 1; iIndex++ )
                l_ColumnNamesForm.listBox.Items.Add( this.dataGridView.Columns[iIndex + 1].HeaderText );

            l_ColumnNamesForm.ShowDialog( this );
        }

        private void ExitToolStripMenuItem_Click( object sender, EventArgs e )
        {
            this.Close();
        }

        private void LoadChinaToolStripMenuItem_Click( object sender, EventArgs e )
        {
            if ( this.openFileDialog.ShowDialog() == DialogResult.OK )
            {
                this.dataGridView.SuspendLayout();

                STBData.LoadSTBDataChina( ref m_STBData, this.openFileDialog.FileName );
                m_strFileName = this.openFileDialog.FileName;

                this.dataGridView.DataSource = m_STBData.DataTable;

                for ( int l_iIndex = 0; l_iIndex < m_STBData.ColumnsWidth.Length; l_iIndex++ )
                    this.dataGridView.Columns[l_iIndex].Width = m_STBData.ColumnsWidth[l_iIndex];

                for ( int l_iIndex = 0; l_iIndex < m_STBData.ColumnsHeaderText.Length; l_iIndex++ )
                    this.dataGridView.Columns[l_iIndex].HeaderText = m_STBData.ColumnsHeaderText[l_iIndex];

                this.dataGridView.Columns[0].ReadOnly = true;

                string l_strStructName = m_STBData.StructName == string.Empty ? "NULL" : m_STBData.StructName;
                this.Text = "Demo R.O.S.E.STB.Editor.Form" + "( " + m_strFileName + " )" + " Name = " + l_strStructName + " ";

                this.dataGridView.AllowUserToAddRows = false;
                this.dataGridView.AllowUserToDeleteRows = false;

                this.dataGridView.ResumeLayout();

                this.DelToolStripMenuItem.Enabled = true;
                this.AddToolStripMenuItem.Enabled = true;
                this.CloseToolStripMenuItem.Enabled = true;
                this.SaveToolStripMenuItem.Enabled = true;
                this.SaveAs949ToolStripMenuItem.Enabled = true;
                this.SaveAs936ToolStripMenuItem.Enabled = true;
                this.ColumnToolStripMenuItem.Enabled = true;
                this.StructToolStripMenuItem.Enabled = true;

                m_SaveLanguage = SaveLanguage.China;
            }
        }

        private void SaveAsChinaToolStripMenuItem_Click( object sender, EventArgs e )
        {
            this.saveFileDialog.FileName = m_strFileName;
            if ( this.saveFileDialog.ShowDialog() == DialogResult.OK )
            {
                this.dataGridView.CommitEdit( DataGridViewDataErrorContexts.Commit );

                STBData.SaveSTBDataChina( ref m_STBData, this.saveFileDialog.FileName );
            }
        }

        private void StructToolStripMenuItem_Click( object sender, EventArgs e )
        {
            StructNameChangeForm l_ColumnNameChange = new StructNameChangeForm( this );
            l_ColumnNameChange.textBoxOriginal.Text = m_STBData.StructName;
            if ( l_ColumnNameChange.ShowDialog( this ) == DialogResult.OK )
            {
                m_STBData.StructName = l_ColumnNameChange.textBoxChange.Text;

                string l_strStructName = m_STBData.StructName == string.Empty ? "NULL" : m_STBData.StructName;
                this.Text = "Demo R.O.S.E.STB.Editor.Form" + "( " + m_strFileName + " )" + " Name = " + l_strStructName + " ";
            }
        }
    }
}

