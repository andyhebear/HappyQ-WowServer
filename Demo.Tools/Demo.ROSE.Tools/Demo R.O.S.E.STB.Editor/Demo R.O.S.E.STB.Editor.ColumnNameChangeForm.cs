using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Demo_R.O.S.E.STB.Editor
{
    public partial class ColumnNameChangeForm : Form
    {
        STBEditorForm m_STBEditorForm;

        public ColumnNameChangeForm( STBEditorForm mainForm )
        {
            InitializeComponent();

            m_STBEditorForm = mainForm;
        }
    }
}

