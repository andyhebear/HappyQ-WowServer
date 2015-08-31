using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Demo.Stock.X.U50.Common;

namespace Demo.Stock.X.U50
{
    /// <summary>
    /// 
    /// </summary>
    public partial class PolicyDControl : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        private UserControl m_CurrentConfigBControlSub = null;
        private PolicyDControlSub0 m_ConfigBControlSub0 = null;
        private PolicyDControlSub1 m_ConfigBControlSub1 = null;
        private PolicyDControlSub2 m_ConfigBControlSub2 = null;
        private PolicyDControlSub3 m_ConfigBControlSub3 = null;
        private PolicyDControlSub4 m_ConfigBControlSub4 = null;
        private PolicyDControlSub5 m_ConfigBControlSub5 = null;
        private PolicyDControlSub6 m_ConfigBControlSub6 = null;

        /// <summary>
        /// 
        /// </summary>
        public PolicyDControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
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
        private void ConfigBControl_Load( object sender, EventArgs e )
        {
            if ( m_IsInitializing == true )
                return;
            else
                m_IsInitializing = true;

            m_ConfigBControlSub0 = new PolicyDControlSub0();
            m_ConfigBControlSub0.Dock = DockStyle.Fill;
            m_ConfigBControlSub0.BackColor = MainForm.Instance.AxSkinFramework.GetColor( XtremeSkinFramework.XTPColorManagerColor.STDCOLOR_BTNFACE );
            m_ConfigBControlSub0.Visible = false;

            m_ConfigBControlSub1 = new PolicyDControlSub1();
            m_ConfigBControlSub1.Dock = DockStyle.Fill;
            m_ConfigBControlSub1.BackColor = MainForm.Instance.AxSkinFramework.GetColor( XtremeSkinFramework.XTPColorManagerColor.STDCOLOR_BTNFACE );
            m_ConfigBControlSub1.Visible = false;

            m_ConfigBControlSub2 = new PolicyDControlSub2();
            m_ConfigBControlSub2.Dock = DockStyle.Fill;
            m_ConfigBControlSub2.BackColor = MainForm.Instance.AxSkinFramework.GetColor( XtremeSkinFramework.XTPColorManagerColor.STDCOLOR_BTNFACE );
            m_ConfigBControlSub2.Visible = false;

            m_ConfigBControlSub3 = new PolicyDControlSub3();
            m_ConfigBControlSub3.Dock = DockStyle.Fill;
            m_ConfigBControlSub3.BackColor = MainForm.Instance.AxSkinFramework.GetColor( XtremeSkinFramework.XTPColorManagerColor.STDCOLOR_BTNFACE );
            m_ConfigBControlSub3.Visible = false;

            m_ConfigBControlSub4 = new PolicyDControlSub4();
            m_ConfigBControlSub4.Dock = DockStyle.Fill;
            m_ConfigBControlSub4.BackColor = MainForm.Instance.AxSkinFramework.GetColor( XtremeSkinFramework.XTPColorManagerColor.STDCOLOR_BTNFACE );
            m_ConfigBControlSub4.Visible = false;

            m_ConfigBControlSub5 = new PolicyDControlSub5();
            m_ConfigBControlSub5.Dock = DockStyle.Fill;
            m_ConfigBControlSub5.BackColor = MainForm.Instance.AxSkinFramework.GetColor( XtremeSkinFramework.XTPColorManagerColor.STDCOLOR_BTNFACE );
            m_ConfigBControlSub5.Visible = false;

            m_ConfigBControlSub6 = new PolicyDControlSub6();
            m_ConfigBControlSub6.Dock = DockStyle.Fill;
            m_ConfigBControlSub6.BackColor = MainForm.Instance.AxSkinFramework.GetColor( XtremeSkinFramework.XTPColorManagerColor.STDCOLOR_BTNFACE );
            m_ConfigBControlSub6.Visible = false;

            m_CurrentConfigBControlSub = m_ConfigBControlSub0;
            this.Panel.Controls.Add( m_ConfigBControlSub0 );
            this.Panel.Controls.Add( m_ConfigBControlSub1 );
            this.Panel.Controls.Add( m_ConfigBControlSub2 );
            this.Panel.Controls.Add( m_ConfigBControlSub3 );
            this.Panel.Controls.Add( m_ConfigBControlSub4 );
            this.Panel.Controls.Add( m_ConfigBControlSub5 );
            this.Panel.Controls.Add( m_ConfigBControlSub6 );

            this.ButtonO_Click( this, EventArgs.Empty );
        }

        public void SetConfigFiltrate( U50Filtrate filtrate )
        {
            m_ConfigBControlSub1.CheckBoxAllow.Checked = filtrate.PDU.Enabled;

            if ( filtrate.PDU.Select == U50SelectType.Any )
            {
                m_ConfigBControlSub1.RadioButtonAny.Checked = true;
            }
            else if ( filtrate.PDU.Select == U50SelectType.Big )
            {
                m_ConfigBControlSub1.RadioButtonBig.Checked = true;
            }
            else if ( filtrate.PDU.Select == U50SelectType.BigAndSmall )
            {
                m_ConfigBControlSub1.RadioButtonBigAndSmall.Checked = true;
            }
            else if ( filtrate.PDU.Select == U50SelectType.Small )
            {
                m_ConfigBControlSub1.RadioButtonSmall.Checked = true;
            }

            m_ConfigBControlSub1.MaskedTextBoxBig.Text = filtrate.PDU.Big.ToString( "000.0" );
            m_ConfigBControlSub1.MaskedTextBoxBig2.Text = filtrate.PDU.Big2.ToString( "000.0" );

            m_ConfigBControlSub1.MaskedTextBoxSmall.Text = filtrate.PDU.Small.ToString( "000.0" );
            m_ConfigBControlSub1.MaskedTextBoxSmall2.Text = filtrate.PDU.Small2.ToString( "000.0" );


            // 
            m_ConfigBControlSub2.CheckBoxAllow.Checked = filtrate.PCU.Enabled;

            if ( filtrate.PCU.Select == U50SelectType.Any )
            {
                m_ConfigBControlSub2.RadioButtonAny.Checked = true;
            }
            else if ( filtrate.PCU.Select == U50SelectType.Big )
            {
                m_ConfigBControlSub2.RadioButtonBig.Checked = true;
            }
            else if ( filtrate.PCU.Select == U50SelectType.BigAndSmall )
            {
                m_ConfigBControlSub2.RadioButtonBigAndSmall.Checked = true;
            }
            else if ( filtrate.PCU.Select == U50SelectType.Small )
            {
                m_ConfigBControlSub2.RadioButtonSmall.Checked = true;
            }

            m_ConfigBControlSub2.MaskedTextBoxBig.Text = filtrate.PCU.Big.ToString( "000.0" );
            m_ConfigBControlSub2.MaskedTextBoxBig2.Text = filtrate.PCU.Big2.ToString( "000.0" );

            m_ConfigBControlSub2.MaskedTextBoxSmall.Text = filtrate.PCU.Small.ToString( "000.0" );
            m_ConfigBControlSub2.MaskedTextBoxSmall2.Text = filtrate.PCU.Small2.ToString( "000.0" );


            // 
            m_ConfigBControlSub3.CheckBoxAllow.Checked = filtrate.TDU.Enabled;

            if ( filtrate.TDU.Select == U50SelectType.Any )
            {
                m_ConfigBControlSub3.RadioButtonAny.Checked = true;
            }
            else if ( filtrate.TDU.Select == U50SelectType.Big )
            {
                m_ConfigBControlSub3.RadioButtonBig.Checked = true;
            }
            else if ( filtrate.TDU.Select == U50SelectType.BigAndSmall )
            {
                m_ConfigBControlSub3.RadioButtonBigAndSmall.Checked = true;
            }
            else if ( filtrate.TDU.Select == U50SelectType.Small )
            {
                m_ConfigBControlSub3.RadioButtonSmall.Checked = true;
            }

            m_ConfigBControlSub3.MaskedTextBoxBig.Text = filtrate.TDU.Big.ToString( "000.0" );
            m_ConfigBControlSub3.MaskedTextBoxBig2.Text = filtrate.TDU.Big2.ToString( "000.0" );

            m_ConfigBControlSub3.MaskedTextBoxSmall.Text = filtrate.TDU.Small.ToString( "000.0" );
            m_ConfigBControlSub3.MaskedTextBoxSmall2.Text = filtrate.TDU.Small2.ToString( "000.0" );


            // 
            m_ConfigBControlSub4.CheckBoxAllow.Checked = filtrate.TCD.Enabled;

            if ( filtrate.TCD.Select == U50SelectType.Any )
            {
                m_ConfigBControlSub4.RadioButtonAny.Checked = true;
            }
            else if ( filtrate.TCD.Select == U50SelectType.Big )
            {
                m_ConfigBControlSub4.RadioButtonBig.Checked = true;
            }
            else if ( filtrate.TCD.Select == U50SelectType.BigAndSmall )
            {
                m_ConfigBControlSub4.RadioButtonBigAndSmall.Checked = true;
            }
            else if ( filtrate.TCD.Select == U50SelectType.Small )
            {
                m_ConfigBControlSub4.RadioButtonSmall.Checked = true;
            }

            m_ConfigBControlSub4.MaskedTextBoxBig.Text = filtrate.TCD.Big.ToString( "000.0" );
            m_ConfigBControlSub4.MaskedTextBoxBig2.Text = filtrate.TCD.Big2.ToString( "000.0" );

            m_ConfigBControlSub4.MaskedTextBoxSmall.Text = filtrate.TCD.Small.ToString( "000.0" );
            m_ConfigBControlSub4.MaskedTextBoxSmall2.Text = filtrate.TCD.Small2.ToString( "000.0" );

            // 
            m_ConfigBControlSub5.CheckBoxAllow.Checked = filtrate.TBU.Enabled;

            if ( filtrate.TBU.Select == U50SelectType.Any )
            {
                m_ConfigBControlSub5.RadioButtonAny.Checked = true;
            }
            else if ( filtrate.TBU.Select == U50SelectType.Big )
            {
                m_ConfigBControlSub5.RadioButtonBig.Checked = true;
            }
            else if ( filtrate.TBU.Select == U50SelectType.BigAndSmall )
            {
                m_ConfigBControlSub5.RadioButtonBigAndSmall.Checked = true;
            }
            else if ( filtrate.TBU.Select == U50SelectType.Small )
            {
                m_ConfigBControlSub5.RadioButtonSmall.Checked = true;
            }

            m_ConfigBControlSub5.MaskedTextBoxBig.Text = filtrate.TBU.Big.ToString( "000.0" );
            m_ConfigBControlSub5.MaskedTextBoxBig2.Text = filtrate.TBU.Big2.ToString( "000.0" );

            m_ConfigBControlSub5.MaskedTextBoxSmall.Text = filtrate.TBU.Small.ToString( "000.0" );
            m_ConfigBControlSub5.MaskedTextBoxSmall2.Text = filtrate.TBU.Small2.ToString( "000.0" );

            // 
            m_ConfigBControlSub6.CheckBoxAllow.Checked = filtrate.VacUC.Enabled;

            if ( filtrate.VacUC.Select == U50SelectType.Any )
            {
                m_ConfigBControlSub6.RadioButtonAny.Checked = true;
            }
            else if ( filtrate.VacUC.Select == U50SelectType.Big )
            {
                m_ConfigBControlSub6.RadioButtonBig.Checked = true;
            }
            else if ( filtrate.VacUC.Select == U50SelectType.BigAndSmall )
            {
                m_ConfigBControlSub6.RadioButtonBigAndSmall.Checked = true;
            }
            else if ( filtrate.VacUC.Select == U50SelectType.Small )
            {
                m_ConfigBControlSub6.RadioButtonSmall.Checked = true;
            }

            m_ConfigBControlSub6.MaskedTextBoxBig.Text = filtrate.VacUC.Big.ToString( "000.0" );
            m_ConfigBControlSub6.MaskedTextBoxBig2.Text = filtrate.VacUC.Big2.ToString( "000.0" );

            m_ConfigBControlSub6.MaskedTextBoxSmall.Text = filtrate.VacUC.Small.ToString( "000.0" );
            m_ConfigBControlSub6.MaskedTextBoxSmall2.Text = filtrate.VacUC.Small2.ToString( "000.0" );
        }

        public U50Filtrate GetConfigFiltrate()
        {
            U50Filtrate filtrate = new U50Filtrate();

            filtrate.PDU.Enabled = m_ConfigBControlSub1.CheckBoxAllow.Checked;

            if ( m_ConfigBControlSub1.RadioButtonAny.Checked == true )
            {
                filtrate.PDU.Select = U50SelectType.Any;
            }
            else if ( m_ConfigBControlSub1.RadioButtonBig.Checked == true )
            {
                filtrate.PDU.Select = U50SelectType.Big;
            }
            else if ( m_ConfigBControlSub1.RadioButtonBigAndSmall.Checked == true )
            {
                filtrate.PDU.Select = U50SelectType.BigAndSmall;
            }
            else if ( m_ConfigBControlSub1.RadioButtonSmall.Checked == true )
            {
                filtrate.PDU.Select = U50SelectType.Small;
            }

            filtrate.PDU.Big = float.Parse( m_ConfigBControlSub1.MaskedTextBoxBig.Text );
            filtrate.PDU.Big2 = float.Parse( m_ConfigBControlSub1.MaskedTextBoxBig2.Text );

            filtrate.PDU.Small = float.Parse( m_ConfigBControlSub1.MaskedTextBoxSmall.Text );
            filtrate.PDU.Small2 = float.Parse( m_ConfigBControlSub1.MaskedTextBoxSmall2.Text );


            // 
            filtrate.PCU.Enabled = m_ConfigBControlSub2.CheckBoxAllow.Checked;

            if ( m_ConfigBControlSub2.RadioButtonAny.Checked == true )
            {
                filtrate.PCU.Select = U50SelectType.Any;
            }
            else if ( m_ConfigBControlSub2.RadioButtonBig.Checked == true )
            {
                filtrate.PCU.Select = U50SelectType.Big;
            }
            else if ( m_ConfigBControlSub2.RadioButtonBigAndSmall.Checked == true )
            {
                filtrate.PCU.Select = U50SelectType.BigAndSmall;
            }
            else if ( m_ConfigBControlSub2.RadioButtonSmall.Checked == true )
            {
                filtrate.PCU.Select = U50SelectType.Small;
            }

            filtrate.PCU.Big = float.Parse( m_ConfigBControlSub2.MaskedTextBoxBig.Text );
            filtrate.PCU.Big2 = float.Parse( m_ConfigBControlSub2.MaskedTextBoxBig2.Text );

            filtrate.PCU.Small = float.Parse( m_ConfigBControlSub2.MaskedTextBoxSmall.Text );
            filtrate.PCU.Small2 = float.Parse( m_ConfigBControlSub2.MaskedTextBoxSmall2.Text );

            // 
            filtrate.TDU.Enabled = m_ConfigBControlSub3.CheckBoxAllow.Checked;

            if ( m_ConfigBControlSub3.RadioButtonAny.Checked == true )
            {
                filtrate.TDU.Select = U50SelectType.Any;
            }
            else if ( m_ConfigBControlSub3.RadioButtonBig.Checked == true )
            {
                filtrate.TDU.Select = U50SelectType.Big;
            }
            else if ( m_ConfigBControlSub3.RadioButtonBigAndSmall.Checked == true )
            {
                filtrate.TDU.Select = U50SelectType.BigAndSmall;
            }
            else if ( m_ConfigBControlSub3.RadioButtonSmall.Checked == true )
            {
                filtrate.TDU.Select = U50SelectType.Small;
            }

            filtrate.TDU.Big = float.Parse( m_ConfigBControlSub3.MaskedTextBoxBig.Text );
            filtrate.TDU.Big2 = float.Parse( m_ConfigBControlSub3.MaskedTextBoxBig2.Text );

            filtrate.TDU.Small = float.Parse( m_ConfigBControlSub3.MaskedTextBoxSmall.Text );
            filtrate.TDU.Small2 = float.Parse( m_ConfigBControlSub3.MaskedTextBoxSmall2.Text );

            // 
            filtrate.TCD.Enabled = m_ConfigBControlSub4.CheckBoxAllow.Checked;

            if ( m_ConfigBControlSub4.RadioButtonAny.Checked == true )
            {
                filtrate.TCD.Select = U50SelectType.Any;
            }
            else if ( m_ConfigBControlSub4.RadioButtonBig.Checked == true )
            {
                filtrate.TCD.Select = U50SelectType.Big;
            }
            else if ( m_ConfigBControlSub4.RadioButtonBigAndSmall.Checked == true )
            {
                filtrate.TCD.Select = U50SelectType.BigAndSmall;
            }
            else if ( m_ConfigBControlSub4.RadioButtonSmall.Checked == true )
            {
                filtrate.TCD.Select = U50SelectType.Small;
            }

            filtrate.TCD.Big = float.Parse( m_ConfigBControlSub4.MaskedTextBoxBig.Text );
            filtrate.TCD.Big2 = float.Parse( m_ConfigBControlSub4.MaskedTextBoxBig2.Text );

            filtrate.TCD.Small = float.Parse( m_ConfigBControlSub4.MaskedTextBoxSmall.Text );
            filtrate.TCD.Small2 = float.Parse( m_ConfigBControlSub4.MaskedTextBoxSmall2.Text );


            // 
            filtrate.TBU.Enabled = m_ConfigBControlSub5.CheckBoxAllow.Checked;

            if ( m_ConfigBControlSub5.RadioButtonAny.Checked == true )
            {
                filtrate.TBU.Select = U50SelectType.Any;
            }
            else if ( m_ConfigBControlSub5.RadioButtonBig.Checked == true )
            {
                filtrate.TBU.Select = U50SelectType.Big;
            }
            else if ( m_ConfigBControlSub5.RadioButtonBigAndSmall.Checked == true )
            {
                filtrate.TBU.Select = U50SelectType.BigAndSmall;
            }
            else if ( m_ConfigBControlSub5.RadioButtonSmall.Checked == true )
            {
                filtrate.TBU.Select = U50SelectType.Small;
            }

            filtrate.TBU.Big = float.Parse( m_ConfigBControlSub5.MaskedTextBoxBig.Text );
            filtrate.TBU.Big2 = float.Parse( m_ConfigBControlSub5.MaskedTextBoxBig2.Text );

            filtrate.TBU.Small = float.Parse( m_ConfigBControlSub5.MaskedTextBoxSmall.Text );
            filtrate.TBU.Small2 = float.Parse( m_ConfigBControlSub5.MaskedTextBoxSmall2.Text );

            // 
            filtrate.VacUC.Enabled = m_ConfigBControlSub6.CheckBoxAllow.Checked;

            if ( m_ConfigBControlSub6.RadioButtonAny.Checked == true )
            {
                filtrate.VacUC.Select = U50SelectType.Any;
            }
            else if ( m_ConfigBControlSub6.RadioButtonBig.Checked == true )
            {
                filtrate.VacUC.Select = U50SelectType.Big;
            }
            else if ( m_ConfigBControlSub6.RadioButtonBigAndSmall.Checked == true )
            {
                filtrate.VacUC.Select = U50SelectType.BigAndSmall;
            }
            else if ( m_ConfigBControlSub6.RadioButtonSmall.Checked == true )
            {
                filtrate.VacUC.Select = U50SelectType.Small;
            }

            filtrate.VacUC.Big = float.Parse( m_ConfigBControlSub6.MaskedTextBoxBig.Text );
            filtrate.VacUC.Big2 = float.Parse( m_ConfigBControlSub6.MaskedTextBoxBig2.Text );

            filtrate.VacUC.Small = float.Parse( m_ConfigBControlSub6.MaskedTextBoxSmall.Text );
            filtrate.VacUC.Small2 = float.Parse( m_ConfigBControlSub6.MaskedTextBoxSmall2.Text );

            return filtrate;
        }

        private void ButtonO_Click( object sender, EventArgs e )
        {
            if ( m_CurrentConfigBControlSub != null && m_CurrentConfigBControlSub != m_ConfigBControlSub0 )
                m_CurrentConfigBControlSub.Visible = false;

            m_CurrentConfigBControlSub = m_ConfigBControlSub0;
            m_ConfigBControlSub0.Visible = true;

            this.ButtonO.Enabled = false;
            if ( this.ButtonPDU.Enabled == false )
                this.ButtonPDU.Enabled = true;
            if ( this.ButtonPCD.Enabled == false )
                this.ButtonPCD.Enabled = true;
            if ( this.ButtonTDU.Enabled == false )
                this.ButtonTDU.Enabled = true;
            if ( this.ButtonTCD.Enabled == false )
                this.ButtonTCD.Enabled = true;
            if ( this.ButtonTCU.Enabled == false )
                this.ButtonTCU.Enabled = true;
            if ( this.ButtonVacUC.Enabled == false )
                this.ButtonVacUC.Enabled = true;
        }

        private void ButtonPDU_Click( object sender, EventArgs e )
        {
            if ( m_CurrentConfigBControlSub != null && m_CurrentConfigBControlSub != m_ConfigBControlSub1 )
                m_CurrentConfigBControlSub.Visible = false;

            m_CurrentConfigBControlSub = m_ConfigBControlSub1;
            m_ConfigBControlSub1.Visible = true;

            if ( this.ButtonO.Enabled == false )
                this.ButtonO.Enabled = true;
            if ( this.ButtonPCD.Enabled == false )
                this.ButtonPCD.Enabled = true;
            if ( this.ButtonTDU.Enabled == false )
                this.ButtonTDU.Enabled = true;
            if ( this.ButtonTCD.Enabled == false )
                this.ButtonTCD.Enabled = true;
            if ( this.ButtonTCU.Enabled == false )
                this.ButtonTCU.Enabled = true;
            if ( this.ButtonVacUC.Enabled == false )
                this.ButtonVacUC.Enabled = true;
            this.ButtonPDU.Enabled = false;
        }

        private void ButtonPCD_Click( object sender, EventArgs e )
        {
            if ( m_CurrentConfigBControlSub != null && m_CurrentConfigBControlSub != m_ConfigBControlSub2 )
                m_CurrentConfigBControlSub.Visible = false;

            m_CurrentConfigBControlSub = m_ConfigBControlSub2;
            m_ConfigBControlSub2.Visible = true;

            if ( this.ButtonO.Enabled == false )
                this.ButtonO.Enabled = true;
            if ( this.ButtonPDU.Enabled == false )
                this.ButtonPDU.Enabled = true;
            if ( this.ButtonTDU.Enabled == false )
                this.ButtonTDU.Enabled = true;
            if ( this.ButtonTCD.Enabled == false )
                this.ButtonTCD.Enabled = true;
            if ( this.ButtonTCU.Enabled == false )
                this.ButtonTCU.Enabled = true;
            if ( this.ButtonVacUC.Enabled == false )
                this.ButtonVacUC.Enabled = true;
            this.ButtonPCD.Enabled = false;
        }

        private void ButtonTDU_Click( object sender, EventArgs e )
        {
            if ( m_CurrentConfigBControlSub != null && m_CurrentConfigBControlSub != m_ConfigBControlSub3 )
                m_CurrentConfigBControlSub.Visible = false;

            m_CurrentConfigBControlSub = m_ConfigBControlSub3;
            m_ConfigBControlSub3.Visible = true;

            if ( this.ButtonO.Enabled == false )
                this.ButtonO.Enabled = true;
            if ( this.ButtonPDU.Enabled == false )
                this.ButtonPDU.Enabled = true;
            if ( this.ButtonPCD.Enabled == false )
                this.ButtonPCD.Enabled = true;
            if ( this.ButtonTCD.Enabled == false )
                this.ButtonTCD.Enabled = true;
            if ( this.ButtonTCU.Enabled == false )
                this.ButtonTCU.Enabled = true;
            if ( this.ButtonVacUC.Enabled == false )
                this.ButtonVacUC.Enabled = true;
            this.ButtonTDU.Enabled = false;
        }

        private void ButtonTCD_Click( object sender, EventArgs e )
        {
            if ( m_CurrentConfigBControlSub != null && m_CurrentConfigBControlSub != m_ConfigBControlSub4 )
                m_CurrentConfigBControlSub.Visible = false;

            m_CurrentConfigBControlSub = m_ConfigBControlSub4;
            m_ConfigBControlSub4.Visible = true;

            if ( this.ButtonO.Enabled == false )
                this.ButtonO.Enabled = true;
            if ( this.ButtonPDU.Enabled == false )
                this.ButtonPDU.Enabled = true;
            if ( this.ButtonPCD.Enabled == false )
                this.ButtonPCD.Enabled = true;
            if ( this.ButtonTDU.Enabled == false )
                this.ButtonTDU.Enabled = true;
            if ( this.ButtonTCU.Enabled == false )
                this.ButtonTCU.Enabled = true;
            if ( this.ButtonVacUC.Enabled == false )
                this.ButtonVacUC.Enabled = true;
            this.ButtonTCD.Enabled = false;
        }

        private void ButtonTCU_Click( object sender, EventArgs e )
        {
            if ( m_CurrentConfigBControlSub != null && m_CurrentConfigBControlSub != m_ConfigBControlSub5 )
                m_CurrentConfigBControlSub.Visible = false;

            m_CurrentConfigBControlSub = m_ConfigBControlSub5;
            m_ConfigBControlSub5.Visible = true;

            if ( this.ButtonO.Enabled == false )
                this.ButtonO.Enabled = true;
            if ( this.ButtonPDU.Enabled == false )
                this.ButtonPDU.Enabled = true;
            if ( this.ButtonPCD.Enabled == false )
                this.ButtonPCD.Enabled = true;
            if ( this.ButtonTDU.Enabled == false )
                this.ButtonTDU.Enabled = true;
            if ( this.ButtonTCD.Enabled == false )
                this.ButtonTCD.Enabled = true;
            if ( this.ButtonVacUC.Enabled == false )
                this.ButtonVacUC.Enabled = true;
            this.ButtonTCU.Enabled = false;
        }

        private void ButtonVacUC_Click( object sender, EventArgs e )
        {
            if ( m_CurrentConfigBControlSub != null && m_CurrentConfigBControlSub != m_ConfigBControlSub6 )
                m_CurrentConfigBControlSub.Visible = false;

            m_CurrentConfigBControlSub = m_ConfigBControlSub6;
            m_ConfigBControlSub6.Visible = true;

            if ( this.ButtonO.Enabled == false )
                this.ButtonO.Enabled = true;
            if ( this.ButtonPDU.Enabled == false )
                this.ButtonPDU.Enabled = true;
            if ( this.ButtonPCD.Enabled == false )
                this.ButtonPCD.Enabled = true;
            if ( this.ButtonTDU.Enabled == false )
                this.ButtonTDU.Enabled = true;
            if ( this.ButtonTCD.Enabled == false )
                this.ButtonTCD.Enabled = true;
            if ( this.ButtonTCU.Enabled == false )
                this.ButtonTCU.Enabled = true;
            this.ButtonVacUC.Enabled = false;
        }
    }
}
