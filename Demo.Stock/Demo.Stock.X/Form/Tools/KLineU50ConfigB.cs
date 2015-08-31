using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Demo.Stock.X.Tools
{
    public partial class KLineU50ConfigB : UserControl
    {
        [DllImport( "user32", EntryPoint = "PostMessage", SetLastError = true )]
        private static extern int PostMessage( int hwnd, int wMsg, int wParam, int lParam );
        private const short CB_SHOWDROPDOWN = 0X14F;

        private DateTime m_DateEnd = DateTime.Now;
        private DateTime m_DateBegin = DateTime.Now - TimeSpan.FromDays( 3.0 );
        private DateTime m_DateStop = DateTime.Now - TimeSpan.FromDays( 3.0 );
        private DateTime m_DateSelection = DateTime.Now;

        public KLineU50ConfigB()
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

        private void KLineU50ConfigB_Load( object sender, EventArgs eventArgs )
        {
            this.LabelDataTimeNow.Text = DateTime.Now.ToLongDateString();
            this.LabelDataTimeNow.BackColor = MainForm.Instance.AxSkinFramework.GetColor( XtremeSkinFramework.XTPColorManagerColor.STDCOLOR_BTNFACE );
            this.ComboBoxSelectDateTime.Text = m_DateEnd.ToLongDateString();
            this.ComboBoxDataTimeStop.Text = m_DateStop.ToLongDateString();
        }

        private void ComboBoxSelectDateTime_DropDown( object sender, EventArgs eventArgs )
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

            KLineU50ConfigB.PostMessage( this.ComboBoxSelectDateTime.Handle.ToInt32(), CB_SHOWDROPDOWN, 0, 0 );
        }

        private void ComboBoxDataTimeStop_DropDown( object sender, EventArgs eventArgs )
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

            KLineU50ConfigB.PostMessage( this.ComboBoxDataTimeStop.Handle.ToInt32(), CB_SHOWDROPDOWN, 0, 0 );
        }

        private void TrackBarDataTimeStep_Scroll( object sender, EventArgs eventArgs )
        {
            this.NumericUpDownDataTimeStep.Value = this.TrackBarDataTimeStep.Value;
        }

        private void TrackBarDateTimeKLine_Scroll( object sender, EventArgs eventArgs )
        {
            this.NumericUpDownKLine.Value = this.TrackBarDateTimeKLine.Value;
        }

        private void TrackBarKLineStep_Scroll( object sender, EventArgs eventArgs )
        {
            this.NumericUpDownKLineStep.Value = this.TrackBarKLineStep.Value;
        }

        private void TrackBarKLineStop_Scroll( object sender, EventArgs eventArgs )
        {
            this.NumericUpDownKLineStop.Value = this.TrackBarKLineStop.Value;
        }

        private void CheckBoxKLine_CheckedChanged( object sender, EventArgs eventArgs )
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

        private void CheckBoxDataTime_CheckedChanged( object sender, EventArgs eventArgs )
        {
            if ( this.CheckBoxDataTime.Checked == true )
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

        private void CheckBoxKLinePriority_CheckedChanged( object sender, EventArgs eventArgs )
        {
            if ( this.CheckBoxKLinePriority.Visible == true )
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

        private void CheckBoxDataTimePriority_CheckedChanged( object sender, EventArgs eventArgs )
        {
            if ( this.CheckBoxDataTimePriority.Visible == true )
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

        private void CheckBoxOneOutput_CheckedChanged( object sender, EventArgs eventArgs )
        {
            if ( this.CheckBoxOneOutput.Visible == true )
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

        private void CheckBoxAllOutput_CheckedChanged( object sender, EventArgs eventArgs )
        {
            if ( this.CheckBoxAllOutput.Visible == true )
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

        private void RadioButtonSelectDataTime_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.RadioButtonSelectDataTime.Checked == true )
            {
                this.LabelDataTimeNow.Enabled = false;
                this.ComboBoxSelectDateTime.Enabled = true;
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
    }
}
