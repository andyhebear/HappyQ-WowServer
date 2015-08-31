using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Demo.Stock.LHP.Common;

namespace Demo.Stock.LHP.Main
{
    public partial class OptionSub3From : Form
    {
        public OptionSub3From()
        {
            InitializeComponent();
        }

        OptionControlSub3FromA m_OptionControlSub3FromA = new OptionControlSub3FromA();
        OptionControlSub3FromB m_OptionControlSub3FromB = new OptionControlSub3FromB();

        private void OptionSub3From_Load( object sender, EventArgs e )
        {
            m_OptionControlSub3FromA.Parent = this.axTabControl;

            this.axTabControl.InsertItem( 0, "策略设置", m_OptionControlSub3FromA.Handle.ToInt32(), 0 );

            m_OptionControlSub3FromB.Parent = this.axTabControl;

            this.axTabControl.InsertItem( 1, "触发器设置", m_OptionControlSub3FromB.Handle.ToInt32(), 0 );

        }

        private void ButtonOK_Click( object sender, EventArgs e )
        {

        }

        private void ButtonCancel_Click( object sender, EventArgs e )
        {

        }

        public TriggerInfos.TriggerInfo GetTriggerInfo()
        {
            TriggerInfos.TriggerInfo triggerInfo = new TriggerInfos.TriggerInfo();

            triggerInfo.m_strTriggerName = m_OptionControlSub3FromA.TextBoxName.Text;
            triggerInfo.m_strStockFile = m_OptionControlSub3FromA.TextBoxStockList.Text;
            triggerInfo.m_strOpenSRFile = m_OptionControlSub3FromA.TextBoxSRFile.Text;
            triggerInfo.m_strOpenUTMR_DTMSFile = m_OptionControlSub3FromA.TextBoxSaveUTMR_DTMSFile.Text;
            triggerInfo.m_strSaveSRFile = m_OptionControlSub3FromA.TextBoxSaveSRFile.Text;
            triggerInfo.m_strSaveUTMR_DTMSFile = m_OptionControlSub3FromA.TextBoxSaveUTMR_DTMSFile.Text;
            triggerInfo.m_AllowUTMR_DTMS = m_OptionControlSub3FromA.CheckBoxUTMR_DTMS.Checked;

            triggerInfo.m_AllowTrigger = m_OptionControlSub3FromB.CheckBoxTrigger.Checked;

            switch ( m_OptionControlSub3FromB.comboBoxTask.SelectedIndex )
            {
                case 0:

                    triggerInfo.m_TriggerTask = TriggerInfos.TriggerTask.Tasking;

                    break;
                default:

                    triggerInfo.m_TriggerTask = TriggerInfos.TriggerTask.Tasking;

                    break;
            }

            if ( m_OptionControlSub3FromB.RadioButtonOne.Checked )
                triggerInfo.m_TriggerDate = TriggerInfos.TriggerDate.DateOne;
            else if ( m_OptionControlSub3FromB.RadioButtonDay.Checked )
                triggerInfo.m_TriggerDate = TriggerInfos.TriggerDate.DateDay;
            else if ( m_OptionControlSub3FromB.RadioButtonWeek.Checked )
                triggerInfo.m_TriggerDate = TriggerInfos.TriggerDate.DateWeek;
            else if ( m_OptionControlSub3FromB.RadioButtonMonth.Checked )
                triggerInfo.m_TriggerDate = TriggerInfos.TriggerDate.DateMonth;
            else
                triggerInfo.m_TriggerDate = TriggerInfos.TriggerDate.DateDay;

            triggerInfo.DateDay_TimeSpan = (int)m_OptionControlSub3FromB.m_OptionControlSub3FromBSub2.numericUpDown.Value;

            triggerInfo.m_DateTimeBegin = m_OptionControlSub3FromB.dateTimePickerBegin.Value.Date + m_OptionControlSub3FromB.dateTimePickerTimeBegin.Value.TimeOfDay;

            triggerInfo.m_AllowSpan = m_OptionControlSub3FromB.checkBoxSpace.Checked;
            triggerInfo.m_TimeSpanSpan = m_OptionControlSub3FromB.dateTimePickerSpace.Value;
            triggerInfo.m_TimeSpanSpanTime = m_OptionControlSub3FromB.dateTimePickerSpaceTime.Value;

            triggerInfo.m_AllowSpanRun = m_OptionControlSub3FromB.checkBoxRun.Checked;
            triggerInfo.m_TimeSpanRun = m_OptionControlSub3FromB.dateTimePickerRun.Value;

            triggerInfo.m_AllowEnd = m_OptionControlSub3FromB.checkBoxEnd.Checked;
            triggerInfo.m_DateTimeEnd = m_OptionControlSub3FromB.dateTimePickerEnd.Value.Date + m_OptionControlSub3FromB.dateTimePickerTimeEnd.Value.TimeOfDay;

            return triggerInfo;
        }

        public void SetTriggerInfo( TriggerInfos.TriggerInfo triggerInfo )
        {
            m_OptionControlSub3FromA.TextBoxName.Text = triggerInfo.m_strTriggerName;
            m_OptionControlSub3FromA.TextBoxStockList.Text = triggerInfo.m_strStockFile;
            m_OptionControlSub3FromA.TextBoxSRFile.Text = triggerInfo.m_strOpenSRFile;
            m_OptionControlSub3FromA.TextBoxSaveUTMR_DTMSFile.Text = triggerInfo.m_strOpenUTMR_DTMSFile;
            m_OptionControlSub3FromA.TextBoxSaveSRFile.Text = triggerInfo.m_strSaveSRFile;
            m_OptionControlSub3FromA.TextBoxSaveUTMR_DTMSFile.Text = triggerInfo.m_strSaveUTMR_DTMSFile;
            m_OptionControlSub3FromA.CheckBoxUTMR_DTMS.Checked = triggerInfo.m_AllowUTMR_DTMS;


            m_OptionControlSub3FromB.CheckBoxTrigger.Checked = triggerInfo.m_AllowTrigger;

            switch ( triggerInfo.m_TriggerTask )
            {
                case TriggerInfos.TriggerTask.Tasking:

                    m_OptionControlSub3FromB.comboBoxTask.SelectedIndex = 0;

                    break;
                default:

                    m_OptionControlSub3FromB.comboBoxTask.SelectedIndex = 0;

                    break;
            }

            if ( triggerInfo.m_TriggerDate == TriggerInfos.TriggerDate.DateOne )
                m_OptionControlSub3FromB.RadioButtonOne.Checked = true;
            else if ( triggerInfo.m_TriggerDate == TriggerInfos.TriggerDate.DateDay )
                m_OptionControlSub3FromB.RadioButtonDay.Checked = true;
            else if ( triggerInfo.m_TriggerDate == TriggerInfos.TriggerDate.DateWeek )
                m_OptionControlSub3FromB.RadioButtonWeek.Checked = true;
            else if ( triggerInfo.m_TriggerDate == TriggerInfos.TriggerDate.DateMonth )
                m_OptionControlSub3FromB.RadioButtonMonth.Checked = true;
            else
                m_OptionControlSub3FromB.RadioButtonDay.Checked = true;

            m_OptionControlSub3FromB.m_OptionControlSub3FromBSub2.numericUpDown.Value = triggerInfo.DateDay_TimeSpan;

            m_OptionControlSub3FromB.dateTimePickerBegin.Value = triggerInfo.m_DateTimeBegin.Date;
            m_OptionControlSub3FromB.dateTimePickerTimeBegin.Value = triggerInfo.m_DateTimeBegin;

            m_OptionControlSub3FromB.checkBoxSpace.Checked = triggerInfo.m_AllowSpan;
            m_OptionControlSub3FromB.dateTimePickerSpace.Value = triggerInfo.m_TimeSpanSpan;
            m_OptionControlSub3FromB.dateTimePickerSpaceTime.Value = triggerInfo.m_TimeSpanSpanTime;

            m_OptionControlSub3FromB.checkBoxRun.Checked = triggerInfo.m_AllowSpanRun;
            m_OptionControlSub3FromB.dateTimePickerRun.Value = triggerInfo.m_TimeSpanRun;

            m_OptionControlSub3FromB.checkBoxEnd.Checked = triggerInfo.m_AllowEnd;
            m_OptionControlSub3FromB.dateTimePickerEnd.Value = triggerInfo.m_DateTimeEnd.Date;
            m_OptionControlSub3FromB.dateTimePickerTimeEnd.Value = triggerInfo.m_DateTimeEnd;
        }
    }
}
