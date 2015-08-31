using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Demo.Stock.LHP.Main
{
    public partial class OptionControlSub3FromB : UserControl
    {
        public OptionControlSub3FromB()
        {
            InitializeComponent();
        }

        public OptionControlSub3FromBSub1 m_OptionControlSub3FromBSub1 = new OptionControlSub3FromBSub1();
        public OptionControlSub3FromBSub2 m_OptionControlSub3FromBSub2 = new OptionControlSub3FromBSub2();
        public OptionControlSub3FromBSub3 m_OptionControlSub3FromBSub3 = new OptionControlSub3FromBSub3();
        public OptionControlSub3FromBSub4 m_OptionControlSub3FromBSub4 = new OptionControlSub3FromBSub4();

        private UserControl m_CurrentUserControl = null;

        private void OptionControlSub3FromB_Load( object sender, EventArgs e )
        {
            {
                m_OptionControlSub3FromBSub1.Dock = DockStyle.Fill;
                m_OptionControlSub3FromBSub1.Visible = false;

                this.panelInfo.Controls.Add( m_OptionControlSub3FromBSub1 );
            }

            {
                m_OptionControlSub3FromBSub2.Dock = DockStyle.Fill;
                m_OptionControlSub3FromBSub2.Visible = false;

                this.panelInfo.Controls.Add( m_OptionControlSub3FromBSub2 );
            }

            {
                m_OptionControlSub3FromBSub3.Dock = DockStyle.Fill;
                m_OptionControlSub3FromBSub3.Visible = false;
                m_OptionControlSub3FromBSub3.Enabled = false;

                this.panelInfo.Controls.Add( m_OptionControlSub3FromBSub3 );
            }

            {
                m_OptionControlSub3FromBSub4.Dock = DockStyle.Fill;
                m_OptionControlSub3FromBSub4.Visible = false;
                m_OptionControlSub3FromBSub4.Enabled = false;

                this.panelInfo.Controls.Add( m_OptionControlSub3FromBSub4 );
            }

            this.comboBoxTask.SelectedIndex = 0;

            RadioButtonOne_CheckedChanged( this, EventArgs.Empty );
            RadioButtonDay_CheckedChanged( this, EventArgs.Empty );
            RadioButtonWeek_CheckedChanged( this, EventArgs.Empty );
            RadioButtonMonth_CheckedChanged( this, EventArgs.Empty );
            CheckBoxTrigger_CheckedChanged( this, EventArgs.Empty );
            checkBoxSpace_CheckedChanged( this, EventArgs.Empty );
            checkBoxRun_CheckedChanged( this, EventArgs.Empty );
            checkBoxEnd_CheckedChanged( this, EventArgs.Empty );
        }

        private void RadioButtonOne_CheckedChanged( object sender, EventArgs e )
        {
            if ( RadioButtonOne.Checked == true )
            {
                if ( m_CurrentUserControl != null )
                {
                    if ( m_CurrentUserControl != m_OptionControlSub3FromBSub1 )
                        m_CurrentUserControl.Visible = false;
                }

                m_CurrentUserControl = m_OptionControlSub3FromBSub1;
                m_CurrentUserControl.Visible = true;
            }
        }

        private void RadioButtonDay_CheckedChanged( object sender, EventArgs e )
        {
            if ( RadioButtonDay.Checked == true )
            {
                if ( m_CurrentUserControl != null )
                {
                    if ( m_CurrentUserControl != m_OptionControlSub3FromBSub2 )
                        m_CurrentUserControl.Visible = false;
                }

                m_CurrentUserControl = m_OptionControlSub3FromBSub2;
                m_CurrentUserControl.Visible = true;
            }
        }

        private void RadioButtonWeek_CheckedChanged( object sender, EventArgs e )
        {
            if ( RadioButtonWeek.Checked == true )
            {
                if ( m_CurrentUserControl != null )
                {
                    if ( m_CurrentUserControl != m_OptionControlSub3FromBSub3 )
                        m_CurrentUserControl.Visible = false;
                }

                m_CurrentUserControl = m_OptionControlSub3FromBSub3;
                m_CurrentUserControl.Visible = true;
            }
        }

        private void RadioButtonMonth_CheckedChanged( object sender, EventArgs e )
        {
            if ( RadioButtonMonth.Checked == true )
            {
                if ( m_CurrentUserControl != null )
                {
                    if ( m_CurrentUserControl != m_OptionControlSub3FromBSub4 )
                        m_CurrentUserControl.Visible = false;
                }

                m_CurrentUserControl = m_OptionControlSub3FromBSub4;
                m_CurrentUserControl.Visible = true;
            }
        }

        private void CheckBoxTrigger_CheckedChanged( object sender, EventArgs e )
        {
            labelTask.Enabled = this.CheckBoxTrigger.Checked;
            comboBoxTask.Enabled = this.CheckBoxTrigger.Checked;
            groupBoxTask.Enabled = this.CheckBoxTrigger.Checked;
            groupBoxSetting.Enabled = this.CheckBoxTrigger.Checked;
        }

        private void checkBoxSpace_CheckedChanged( object sender, EventArgs e )
        {
            dateTimePickerSpace.Enabled = checkBoxSpace.Checked;
            labelSpace.Enabled = checkBoxSpace.Checked;
            dateTimePickerSpaceTime.Enabled = checkBoxSpace.Checked;
        }

        private void checkBoxRun_CheckedChanged( object sender, EventArgs e )
        {
            dateTimePickerRun.Enabled = checkBoxRun.Checked;
        }

        private void checkBoxEnd_CheckedChanged( object sender, EventArgs e )
        {
            dateTimePickerEnd.Enabled = checkBoxEnd.Checked;
            dateTimePickerTimeEnd.Enabled = checkBoxEnd.Checked;
        }
    }
}
