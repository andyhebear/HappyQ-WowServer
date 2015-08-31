using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Demo.Stock.X.Tools
{
    public partial class KLineU50ConfigC : UserControl
    {
        private UserControl m_CurrentConfigBControlSub = null;
        private KLineU50ConfigCSub0 m_KLineU50ConfigCSub0 = new KLineU50ConfigCSub0();
        private KLineU50ConfigCSub1 m_KLineU50ConfigCSub1 = new KLineU50ConfigCSub1();
        private KLineU50ConfigCSub2 m_KLineU50ConfigCSub2 = new KLineU50ConfigCSub2();
        private KLineU50ConfigCSub3 m_KLineU50ConfigCSub3 = new KLineU50ConfigCSub3();
        private KLineU50ConfigCSub4 m_KLineU50ConfigCSub4 = new KLineU50ConfigCSub4();
        private KLineU50ConfigCSub5 m_KLineU50ConfigCSub5 = new KLineU50ConfigCSub5();
        private KLineU50ConfigCSub6 m_KLineU50ConfigCSub6 = new KLineU50ConfigCSub6();

        public KLineU50ConfigC()
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

        private void KLineU50ConfigC_Load( object sender, EventArgs eventArgs )
        {
            m_KLineU50ConfigCSub0.Dock = DockStyle.Fill;
            m_KLineU50ConfigCSub0.BackColor = MainForm.Instance.AxSkinFramework.GetColor( XtremeSkinFramework.XTPColorManagerColor.STDCOLOR_BTNFACE );
            m_KLineU50ConfigCSub0.Visible = false;

            m_KLineU50ConfigCSub1.Dock = DockStyle.Fill;
            m_KLineU50ConfigCSub1.BackColor = MainForm.Instance.AxSkinFramework.GetColor( XtremeSkinFramework.XTPColorManagerColor.STDCOLOR_BTNFACE );
            m_KLineU50ConfigCSub1.Visible = false;

            m_KLineU50ConfigCSub2.Dock = DockStyle.Fill;
            m_KLineU50ConfigCSub2.BackColor = MainForm.Instance.AxSkinFramework.GetColor( XtremeSkinFramework.XTPColorManagerColor.STDCOLOR_BTNFACE );
            m_KLineU50ConfigCSub2.Visible = false;

            m_KLineU50ConfigCSub3.Dock = DockStyle.Fill;
            m_KLineU50ConfigCSub3.BackColor = MainForm.Instance.AxSkinFramework.GetColor( XtremeSkinFramework.XTPColorManagerColor.STDCOLOR_BTNFACE );
            m_KLineU50ConfigCSub3.Visible = false;

            m_KLineU50ConfigCSub4.Dock = DockStyle.Fill;
            m_KLineU50ConfigCSub4.BackColor = MainForm.Instance.AxSkinFramework.GetColor( XtremeSkinFramework.XTPColorManagerColor.STDCOLOR_BTNFACE );
            m_KLineU50ConfigCSub4.Visible = false;

            m_KLineU50ConfigCSub5.Dock = DockStyle.Fill;
            m_KLineU50ConfigCSub5.BackColor = MainForm.Instance.AxSkinFramework.GetColor( XtremeSkinFramework.XTPColorManagerColor.STDCOLOR_BTNFACE );
            m_KLineU50ConfigCSub5.Visible = false;

            m_KLineU50ConfigCSub6.Dock = DockStyle.Fill;
            m_KLineU50ConfigCSub6.BackColor = MainForm.Instance.AxSkinFramework.GetColor( XtremeSkinFramework.XTPColorManagerColor.STDCOLOR_BTNFACE );
            m_KLineU50ConfigCSub6.Visible = false;

            this.Panel.Controls.Add( m_KLineU50ConfigCSub0 );
            this.Panel.Controls.Add( m_KLineU50ConfigCSub1 );
            this.Panel.Controls.Add( m_KLineU50ConfigCSub2 );
            this.Panel.Controls.Add( m_KLineU50ConfigCSub3 );
            this.Panel.Controls.Add( m_KLineU50ConfigCSub4 );
            this.Panel.Controls.Add( m_KLineU50ConfigCSub5 );
            this.Panel.Controls.Add( m_KLineU50ConfigCSub6 );

            this.ButtonO_Click( this, EventArgs.Empty );
        }

        private void ButtonO_Click( object sender, EventArgs eventArgs )
        {
            if ( m_CurrentConfigBControlSub != null && m_CurrentConfigBControlSub != m_KLineU50ConfigCSub0 )
                m_CurrentConfigBControlSub.Visible = false;

            m_CurrentConfigBControlSub = m_KLineU50ConfigCSub0;
            m_KLineU50ConfigCSub0.Visible = true;

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

        private void ButtonPDU_Click( object sender, EventArgs eventArgs )
        {
            if ( m_CurrentConfigBControlSub != null && m_CurrentConfigBControlSub != m_KLineU50ConfigCSub1 )
                m_CurrentConfigBControlSub.Visible = false;

            m_CurrentConfigBControlSub = m_KLineU50ConfigCSub1;
            m_KLineU50ConfigCSub1.Visible = true;

            this.ButtonPDU.Enabled = false;
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
        }

        private void ButtonPCD_Click( object sender, EventArgs eventArgs )
        {
            if ( m_CurrentConfigBControlSub != null && m_CurrentConfigBControlSub != m_KLineU50ConfigCSub2 )
                m_CurrentConfigBControlSub.Visible = false;

            m_CurrentConfigBControlSub = m_KLineU50ConfigCSub2;
            m_KLineU50ConfigCSub2.Visible = true;

            this.ButtonPCD.Enabled = false;
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
        }

        private void ButtonTDU_Click( object sender, EventArgs eventArgs )
        {
            if ( m_CurrentConfigBControlSub != null && m_CurrentConfigBControlSub != m_KLineU50ConfigCSub3 )
                m_CurrentConfigBControlSub.Visible = false;

            m_CurrentConfigBControlSub = m_KLineU50ConfigCSub3;
            m_KLineU50ConfigCSub3.Visible = true;

            this.ButtonTDU.Enabled = false;
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
        }

        private void ButtonTCD_Click( object sender, EventArgs eventArgs )
        {
            if ( m_CurrentConfigBControlSub != null && m_CurrentConfigBControlSub != m_KLineU50ConfigCSub4 )
                m_CurrentConfigBControlSub.Visible = false;

            m_CurrentConfigBControlSub = m_KLineU50ConfigCSub4;
            m_KLineU50ConfigCSub4.Visible = true;

            this.ButtonTCD.Enabled = false;
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
        }

        private void ButtonTCU_Click( object sender, EventArgs eventArgs )
        {
            if ( m_CurrentConfigBControlSub != null && m_CurrentConfigBControlSub != m_KLineU50ConfigCSub5 )
                m_CurrentConfigBControlSub.Visible = false;

            m_CurrentConfigBControlSub = m_KLineU50ConfigCSub5;
            m_KLineU50ConfigCSub5.Visible = true;

            this.ButtonTCU.Enabled = false;
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
        }

        private void ButtonVacUC_Click( object sender, EventArgs eventArgs )
        {
            if ( m_CurrentConfigBControlSub != null && m_CurrentConfigBControlSub != m_KLineU50ConfigCSub6 )
                m_CurrentConfigBControlSub.Visible = false;

            m_CurrentConfigBControlSub = m_KLineU50ConfigCSub6;
            m_KLineU50ConfigCSub6.Visible = true;

            this.ButtonVacUC.Enabled = false;
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
        }
    }
}
