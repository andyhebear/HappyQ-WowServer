using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Demo.Stock.X.U50.Common;

namespace Demo.Stock.X.U50
{
    public partial class PolicyCControl : UserControl
    {
        [DllImport( "user32", EntryPoint = "PostMessage", SetLastError = true )]
        private static extern int PostMessage( int hwnd, int wMsg, int wParam, int lParam );
        private const short CB_SHOWDROPDOWN = 0X14F;

        private DateTime m_DateEnd = DateTime.Now;

        private DateTime m_DateBegin = DateTime.Now - TimeSpan.FromDays( 3.0 );

        private DateTime m_DateStop = DateTime.Now - TimeSpan.FromDays( 3.0 );

        private DateTime m_DateSelection = DateTime.Now;

        public PolicyCControl()
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

        private bool m_IsInitializing = false;
        private void ConfigCControl_Load( object sender, EventArgs e )
        {
            if ( m_IsInitializing == true )
                return;
            else
                m_IsInitializing = true;
            
            this.LabelDataTimeNow.Text = DateTime.Now.ToLongDateString();
            this.LabelDataTimeNow.BackColor = MainForm.Instance.AxSkinFramework.GetColor( XtremeSkinFramework.XTPColorManagerColor.STDCOLOR_BTNFACE );
            this.ComboBoxSelectDateTime.Text = m_DateEnd.ToLongDateString();
            this.ComboBoxDataTimeStop.Text = m_DateStop.ToLongDateString();

            this.CheckBoxAllOutput.Visible = false;
            this.CheckBoxOneOutput.Visible = false;
            this.CheckBoxDataTimePriority.Visible = false;
            this.CheckBoxKLinePriority.Visible = false;
        }

        public void SetConfigPolicy( U50Policy policy )
        {
            if ( policy.IsDateNow == true )
            {
                this.RadioButtonDataTimeNow.Checked = true;
                this.RadioButtonSelectDataTime.Checked = false;
            }
            else
            {
                this.RadioButtonSelectDataTime.Checked = true;
                this.RadioButtonDataTimeNow.Checked = false;
            }

            this.ComboBoxSelectDateTime.Text = policy.DateSelect.ToLongDateString();
            this.NumericUpDownKLine.Value = policy.KN;

            if ( policy.IsAllowDate == true )
                this.CheckBoxDataTime.Checked = true;
            else
                this.CheckBoxDataTime.Checked = false;

            this.NumericUpDownDataTimeStep.Value = policy.DateStep;
            this.ComboBoxDataTimeStop.Text = policy.DateEnd.ToLongDateString();

            if ( policy.IsAllowKN == true )
                this.CheckBoxKLine.Checked = true;
            else
                this.CheckBoxKLine.Checked = false;

            this.NumericUpDownKLineStep.Value = policy.KNStep;
            this.NumericUpDownKLineStop.Value = policy.KNEnd;

            if ( policy.Priority == U50PriorityType.BaseDate )
            {
                this.CheckBoxKLinePriority.Checked = false;
                this.CheckBoxDataTimePriority.Checked = true;
            }
            else if ( policy.Priority == U50PriorityType.BaseKN )
            {
                this.CheckBoxDataTimePriority.Checked = false;
                this.CheckBoxKLinePriority.Checked = true;
            }

            if ( policy.Output == U50OutputType.All )
            {
                this.CheckBoxOneOutput.Checked = false;
                this.CheckBoxAllOutput.Checked = true;
            }
            else if ( policy.Output == U50OutputType.One )
            {
                this.CheckBoxAllOutput.Checked = false;
                this.CheckBoxOneOutput.Checked = true;
            }
        }

        public U50Policy GetConfigPolicy()
        {
            U50Policy configPolicy = new U50Policy();

            if ( this.RadioButtonDataTimeNow.Checked == true )
                configPolicy.IsDateNow = true;
            else
                configPolicy.IsDateNow = false;

            configPolicy.DateSelect = DateTime.Parse( this.ComboBoxSelectDateTime.Text );
            configPolicy.KN = (uint)this.NumericUpDownKLine.Value;

            if ( this.CheckBoxDataTime.Checked == true )
                configPolicy.IsAllowDate = true;

            configPolicy.DateStep = (uint)this.NumericUpDownDataTimeStep.Value;
            configPolicy.DateEnd = DateTime.Parse( this.ComboBoxDataTimeStop.Text );

            if ( this.CheckBoxKLine.Checked == true )
                configPolicy.IsAllowKN = true;

            configPolicy.KNStep = (uint)this.NumericUpDownKLineStep.Value;
            configPolicy.KNEnd = (uint)this.NumericUpDownKLineStop.Value;

            if ( this.CheckBoxAllOutput.Checked == true )
            {
                configPolicy.Output = U50OutputType.All;
            }
            else if ( this.CheckBoxOneOutput.Checked == true )
            {
                configPolicy.Output = U50OutputType.One;
            }

            if ( this.CheckBoxDataTimePriority.Checked == true )
            {
                configPolicy.Priority = U50PriorityType.BaseDate;
            }
            else if ( this.CheckBoxKLinePriority.Checked == true )
            {
                configPolicy.Priority = U50PriorityType.BaseKN;
            }

            return configPolicy;
        }

        private void ComboBoxSelectDateTime_DropDown( object sender, EventArgs e )
        {
            this.axDatePickerSelectDataTime.Left = this.ComboBoxSelectDateTime.Left;
            this.axDatePickerSelectDataTime.Top = this.ComboBoxSelectDateTime.Top + ComboBoxSelectDateTime.Height + 1;

            this.axDatePickerSelectDataTime.EnsureVisible( DateTime.Now - TimeSpan.FromDays( 90.0 ) );

            if ( this.axDatePickerSelectDataTime.ShowModal( 2, 2 ) == true )
            {
                int nCount = this.axDatePickerSelectDataTime.Selection.BlocksCount;
                if ( nCount > 0 )
                {
                    if ( this.axDatePickerSelectDataTime.Selection[nCount - 1].DateEnd > DateTime.Now )
                        m_DateEnd = DateTime.Now;
                    else
                        m_DateEnd = this.axDatePickerSelectDataTime.Selection[nCount - 1].DateEnd;

                    if ( this.axDatePickerSelectDataTime.Selection[0].DateBegin > ( m_DateEnd - TimeSpan.FromDays( 3.0 ) ) )
                        m_DateBegin = m_DateEnd - TimeSpan.FromDays( 2.0 );
                    else
                        m_DateBegin = this.axDatePickerSelectDataTime.Selection[0].DateBegin;

                    m_DateSelection = m_DateEnd;

                    this.ComboBoxSelectDateTime.Text = m_DateSelection.ToLongDateString();

                    this.NumericUpDownKLine.Value = ( m_DateEnd - m_DateBegin ).Days + 1;
                }
            }

            PostMessage( this.ComboBoxSelectDateTime.Handle.ToInt32(), CB_SHOWDROPDOWN, 0, 0 );
        }

        private void ComboBoxDataTimeStop_DropDown( object sender, EventArgs e )
        {
            this.axDatePickerDataTimeStop.Left = this.ComboBoxDataTimeStop.Left;
            this.axDatePickerDataTimeStop.Top = this.ComboBoxDataTimeStop.Top + ComboBoxSelectDateTime.Height + 1;

            this.axDatePickerDataTimeStop.EnsureVisible( DateTime.Now - TimeSpan.FromDays( 90.0 ) );

            if ( this.axDatePickerDataTimeStop.ShowModal( 2, 2 ) == true )
            {
                int nCount = this.axDatePickerDataTimeStop.Selection.BlocksCount;
                if ( nCount > 0 )
                {
                    if ( this.axDatePickerDataTimeStop.Selection[nCount - 1].DateEnd > DateTime.Now )
                        m_DateStop = DateTime.Now;
                    else
                        m_DateStop = this.axDatePickerDataTimeStop.Selection[nCount - 1].DateEnd;

                    this.ComboBoxDataTimeStop.Text = m_DateStop.ToLongDateString();
                }
            }

            PostMessage( this.ComboBoxDataTimeStop.Handle.ToInt32(), CB_SHOWDROPDOWN, 0, 0 );
        }

        private void CheckBoxDataTime_CheckedChanged( object sender, EventArgs e )
        {
            if ( CheckBoxDataTime.Checked == true )
            {
                this.GroupBoxDataTime.Enabled = true;

                this.CheckBoxDataTimePriority.Visible = true;
                if ( CheckBoxKLinePriority.Checked == false )
                    this.CheckBoxDataTimePriority.Checked = true;

                this.CheckBoxAllOutput.Visible = true;
                this.CheckBoxOneOutput.Visible = true;
                if ( this.CheckBoxAllOutput.Checked == false )
                    this.CheckBoxOneOutput.Checked = true;
            }
            else
            {
                this.GroupBoxDataTime.Enabled = false;

                this.CheckBoxDataTimePriority.Visible = false;
                this.CheckBoxDataTimePriority.Checked = false;

                if ( CheckBoxKLinePriority.Visible == true )
                    this.CheckBoxKLinePriority.Checked = true;

                if ( CheckBoxKLine.Checked == false )
                {
                    this.CheckBoxAllOutput.Visible = false;
                    this.CheckBoxAllOutput.Checked = false;
                    this.CheckBoxOneOutput.Visible = false;
                    this.CheckBoxOneOutput.Visible = false;
                }
                else
                {
                    this.CheckBoxAllOutput.Visible = false;
                    this.CheckBoxAllOutput.Checked = false;
                    this.CheckBoxOneOutput.Visible = true;
                    this.CheckBoxOneOutput.Checked = true;
                }
            }
        }

        private void CheckBoxKLine_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.CheckBoxKLine.Checked == true )
            {
                this.GroupBoxKLine.Enabled = true;

                this.CheckBoxKLinePriority.Visible = true;
                if ( CheckBoxDataTimePriority.Checked == false )
                    this.CheckBoxKLinePriority.Checked = true;

                if ( CheckBoxDataTime.Checked == true )
                {
                    this.CheckBoxAllOutput.Visible = true;
                    this.CheckBoxOneOutput.Visible = true;
                    if ( this.CheckBoxAllOutput.Checked == false )
                        this.CheckBoxOneOutput.Checked = true;
                }
                else
                {
                    this.CheckBoxAllOutput.Visible = false;
                    this.CheckBoxAllOutput.Checked = false;
                    this.CheckBoxOneOutput.Visible = true;
                    this.CheckBoxOneOutput.Checked = true;
                }
            }
            else
            {
                this.GroupBoxKLine.Enabled = false;

                this.CheckBoxKLinePriority.Visible = false;
                this.CheckBoxKLinePriority.Checked = false;

                if ( CheckBoxDataTimePriority.Visible == true )
                    this.CheckBoxDataTimePriority.Checked = true;

                if ( CheckBoxDataTime.Checked == false )
                {
                    this.CheckBoxAllOutput.Visible = false;
                    this.CheckBoxAllOutput.Checked = false;
                    this.CheckBoxOneOutput.Visible = false;
                    this.CheckBoxOneOutput.Checked = false;
                }
            }
        }

        private void RadioButtonDataTimeNow_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.RadioButtonDataTimeNow.Checked == true )
            {
                this.LabelDataTimeNow.Enabled = true;
                this.ComboBoxSelectDateTime.Enabled = false;
            }
        }

        private void RadioButtonSelectDataTime_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.RadioButtonSelectDataTime.Checked == true )
            {
                this.LabelDataTimeNow.Enabled = false;
                this.ComboBoxSelectDateTime.Enabled = true;
            }
        }

        private void TrackBarDataTimeStep_Scroll( object sender, EventArgs e )
        {
            this.NumericUpDownDataTimeStep.Value = this.TrackBarDataTimeStep.Value;
        }

        private void TrackBarKLineStep_Scroll( object sender, EventArgs e )
        {
            this.NumericUpDownKLineStep.Value = this.TrackBarKLineStep.Value;
        }

        private void TrackBarKLineStop_Scroll( object sender, EventArgs e )
        {
            this.NumericUpDownKLineStop.Value = this.TrackBarKLineStop.Value;
        }

        private void TrackBarDateTimeKLine_Scroll( object sender, EventArgs e )
        {
            this.NumericUpDownKLine.Value = this.TrackBarDateTimeKLine.Value;
        }

        private void CheckBoxDataTimePriority_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.CheckBoxDataTimePriority.Visible == false )
            {
                //if ( this.CheckBoxDataTimePriority.Checked == true )
                //    this.CheckBoxDataTimePriority.Checked = false;
            }
            else
            {
                if ( this.CheckBoxKLinePriority.Visible == true )
                {
                    if ( this.CheckBoxDataTimePriority.Checked == true )
                        this.CheckBoxKLinePriority.Checked = false;
                    else
                        this.CheckBoxKLinePriority.Checked = true;
                }
                else
                {
                    if ( this.CheckBoxDataTimePriority.Checked == false )
                        this.CheckBoxDataTimePriority.Checked = true;
                }
            }
        }

        private void CheckBoxKLinePriority_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.CheckBoxKLinePriority.Visible == false )
            {
                //if ( this.CheckBoxKLinePriority.Checked == true )
                //    this.CheckBoxKLinePriority.Checked = false;
            }
            else
            {
                if ( this.CheckBoxDataTimePriority.Visible == true )
                {
                    if ( this.CheckBoxKLinePriority.Checked == true )
                        this.CheckBoxDataTimePriority.Checked = false;
                    else
                        this.CheckBoxDataTimePriority.Checked = true;
                }
                else
                {
                    if ( this.CheckBoxKLinePriority.Checked == false )
                        this.CheckBoxKLinePriority.Checked = true;
                }
            }
        }

        private void CheckBoxAllOutput_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.CheckBoxAllOutput.Visible == false )
            {
                //if ( this.CheckBoxAllOutput.Checked == true )
                //    this.CheckBoxAllOutput.Checked = false;
            }
            else
            {
                if ( this.CheckBoxOneOutput.Visible == true )
                {
                    if ( this.CheckBoxAllOutput.Checked == true )
                        this.CheckBoxOneOutput.Checked = false;
                    else
                        this.CheckBoxOneOutput.Checked = true;
                }
                else
                {
                    if ( this.CheckBoxAllOutput.Checked == false )
                        this.CheckBoxAllOutput.Checked = true;
                }
            }

        }

        private void CheckBoxOneOutput_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.CheckBoxOneOutput.Visible == false )
            {
                //if ( this.CheckBoxOneOutput.Checked == true )
                //    this.CheckBoxOneOutput.Checked = false;
            }
            else
            {
                if ( this.CheckBoxAllOutput.Visible == true )
                {
                    if ( this.CheckBoxOneOutput.Checked == true )
                        this.CheckBoxAllOutput.Checked = false;
                    else
                        this.CheckBoxAllOutput.Checked = true;
                }
                else
                {
                    if ( this.CheckBoxOneOutput.Checked == false )
                        this.CheckBoxOneOutput.Checked = true;
                }
            }
        }
    }
}
