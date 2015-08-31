using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Demo_R.O.S.E.STB.Editor
{
    public partial class ColumnNamesForm : Form
    {
        STBEditorForm m_STBEditorForm;

        public ColumnNamesForm( STBEditorForm mainForm )
        {
            InitializeComponent();

            m_STBEditorForm = mainForm;
        }

        private void listBox_DoubleClick( object sender, EventArgs e )
        {
            if ( this.listBox.SelectedIndex == -1 )
                return;

            ColumnNameChangeForm l_ColumnNameChange = new ColumnNameChangeForm( m_STBEditorForm );
            l_ColumnNameChange.textBoxOriginal.Text = this.listBox.Items[this.listBox.SelectedIndex].ToString();
            if (l_ColumnNameChange.ShowDialog(this) == DialogResult.OK)
            {
                m_STBEditorForm.dataGridView.Columns[this.listBox.SelectedIndex + 1].HeaderText = l_ColumnNameChange.textBoxChange.Text;
                this.listBox.Items[this.listBox.SelectedIndex] = l_ColumnNameChange.textBoxChange.Text;
                m_STBEditorForm.m_STBData.ColumnsHeaderText[this.listBox.SelectedIndex + 1] = l_ColumnNameChange.textBoxChange.Text;

                this.listBox.Refresh();
            }
        }
    }
}

