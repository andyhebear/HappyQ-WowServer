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
    public partial class PolicyEControl : UserControl
    {
        private UserControl m_CurrentConfigEControlSub = null;
        private PolicyEControlSub0 m_ConfigEControlSub0 = null;
        private PolicyEControlSub1 m_ConfigEControlSub1 = null;
        private PolicyEControlSub2 m_ConfigEControlSub2 = null;
        private PolicyEControlSub3 m_ConfigEControlSub3 = null;
        private PolicyEControlSub4 m_ConfigEControlSub4 = null;
        private PolicyEControlSub5 m_ConfigEControlSub5 = null;
        private PolicyEControlSub6 m_ConfigEControlSub6 = null;


        public PolicyEControl()
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
        private void ConfigEControl_Load( object sender, EventArgs e )
        {
            if ( m_IsInitializing == true )
                return;
            else
                m_IsInitializing = true;

            m_ConfigEControlSub0 = new PolicyEControlSub0();
            m_ConfigEControlSub0.Dock = DockStyle.Fill;
            m_ConfigEControlSub0.BackColor = MainForm.Instance.AxSkinFramework.GetColor( XtremeSkinFramework.XTPColorManagerColor.STDCOLOR_BTNFACE );
            m_ConfigEControlSub0.Visible = false;

            m_ConfigEControlSub1 = new PolicyEControlSub1();
            m_ConfigEControlSub1.Dock = DockStyle.Fill;
            m_ConfigEControlSub1.BackColor = MainForm.Instance.AxSkinFramework.GetColor( XtremeSkinFramework.XTPColorManagerColor.STDCOLOR_BTNFACE );
            m_ConfigEControlSub1.Visible = false;

            m_ConfigEControlSub2 = new PolicyEControlSub2();
            m_ConfigEControlSub2.Dock = DockStyle.Fill;
            m_ConfigEControlSub2.BackColor = MainForm.Instance.AxSkinFramework.GetColor( XtremeSkinFramework.XTPColorManagerColor.STDCOLOR_BTNFACE );
            m_ConfigEControlSub2.Visible = false;

            m_ConfigEControlSub3 = new PolicyEControlSub3();
            m_ConfigEControlSub3.Dock = DockStyle.Fill;
            m_ConfigEControlSub3.BackColor = MainForm.Instance.AxSkinFramework.GetColor( XtremeSkinFramework.XTPColorManagerColor.STDCOLOR_BTNFACE );
            m_ConfigEControlSub3.Visible = false;

            m_ConfigEControlSub4 = new PolicyEControlSub4();
            m_ConfigEControlSub4.Dock = DockStyle.Fill;
            m_ConfigEControlSub4.BackColor = MainForm.Instance.AxSkinFramework.GetColor( XtremeSkinFramework.XTPColorManagerColor.STDCOLOR_BTNFACE );
            m_ConfigEControlSub4.Visible = false;

            m_ConfigEControlSub5 = new PolicyEControlSub5();
            m_ConfigEControlSub5.Dock = DockStyle.Fill;
            m_ConfigEControlSub5.BackColor = MainForm.Instance.AxSkinFramework.GetColor( XtremeSkinFramework.XTPColorManagerColor.STDCOLOR_BTNFACE );
            m_ConfigEControlSub5.Visible = false;

            m_ConfigEControlSub6 = new PolicyEControlSub6();
            m_ConfigEControlSub6.Dock = DockStyle.Fill;
            m_ConfigEControlSub6.BackColor = MainForm.Instance.AxSkinFramework.GetColor( XtremeSkinFramework.XTPColorManagerColor.STDCOLOR_BTNFACE );
            m_ConfigEControlSub6.Visible = false;
            m_ConfigEControlSub6.EventButtonSetting += new EventHandler( OnEventButtonSetting );

            m_CurrentConfigEControlSub = m_ConfigEControlSub0;
            this.Panel.Controls.Add( m_ConfigEControlSub0 );
            this.Panel.Controls.Add( m_ConfigEControlSub1 );
            this.Panel.Controls.Add( m_ConfigEControlSub2 );
            this.Panel.Controls.Add( m_ConfigEControlSub3 );
            this.Panel.Controls.Add( m_ConfigEControlSub4 );
            this.Panel.Controls.Add( m_ConfigEControlSub5 );
            this.Panel.Controls.Add( m_ConfigEControlSub6 );

            this.ButtonO_Click( this, EventArgs.Empty );

        }

        public void SetConfigExtend( U50Extend extend )
        {
            m_ConfigEControlSub1.CheckBoxAllow.Checked = extend.Info01.Enabled;

            if ( extend.Info01.Select == U50ExtendInfo01Type.Any )
            {
                m_ConfigEControlSub1.RadioButtonAny.Checked = true;
            }
            else if ( extend.Info01.Select == U50ExtendInfo01Type.High )
            {
                m_ConfigEControlSub1.RadioButtonHigh.Checked = true;
            }
            else if ( extend.Info01.Select == U50ExtendInfo01Type.HighNumber )
            {
                m_ConfigEControlSub1.RadioButtonHighNow.Checked = true;
            }


            m_ConfigEControlSub1.NumericUpDownKLine.Value = extend.Info01.HighNumber;
            m_ConfigEControlSub1.TrackBarKLine.Value = extend.Info01.HighNumber;

            // 
            m_ConfigEControlSub2.CheckBoxAllow.Checked = extend.Info02.Enabled;

            if ( extend.Info02.Select == U50SelectType.Any )
            {
                m_ConfigEControlSub2.RadioButtonAny.Checked = true;
            }
            else if ( extend.Info02.Select == U50SelectType.Big )
            {
                m_ConfigEControlSub2.RadioButtonBig.Checked = true;
            }
            else if ( extend.Info02.Select == U50SelectType.BigAndSmall )
            {
                m_ConfigEControlSub2.RadioButtonBigAndSmall.Checked = true;
            }
            else if ( extend.Info02.Select == U50SelectType.Small )
            {
                m_ConfigEControlSub2.RadioButtonSmall.Checked = true;
            }

            m_ConfigEControlSub2.MaskedTextBoxBig.Text = extend.Info02.Big.ToString( "0000000000" );
            m_ConfigEControlSub2.MaskedTextBoxBig2.Text = extend.Info02.Big2.ToString( "0000000000" );

            m_ConfigEControlSub2.MaskedTextBoxSmall.Text = extend.Info02.Small.ToString( "0000000000" );
            m_ConfigEControlSub2.MaskedTextBoxSmall2.Text = extend.Info02.Small2.ToString( "0000000000" );


            // 
            m_ConfigEControlSub3.CheckBoxAllow.Checked = extend.Info03.Enabled;

            if ( extend.Info03.Select == U50SelectType.Any )
            {
                m_ConfigEControlSub3.RadioButtonAny.Checked = true;
            }
            else if ( extend.Info03.Select == U50SelectType.Big )
            {
                m_ConfigEControlSub3.RadioButtonBig.Checked = true;
            }
            else if ( extend.Info03.Select == U50SelectType.BigAndSmall )
            {
                m_ConfigEControlSub3.RadioButtonBigAndSmall.Checked = true;
            }
            else if ( extend.Info03.Select == U50SelectType.Small )
            {
                m_ConfigEControlSub3.RadioButtonSmall.Checked = true;
            }

            m_ConfigEControlSub3.MaskedTextBoxBig.Text = extend.Info03.Big.ToString( "0000" );
            m_ConfigEControlSub3.MaskedTextBoxBig2.Text = extend.Info03.Big2.ToString( "0000" );

            m_ConfigEControlSub3.MaskedTextBoxSmall.Text = extend.Info03.Small.ToString( "0000" );
            m_ConfigEControlSub3.MaskedTextBoxSmall2.Text = extend.Info03.Small2.ToString( "0000" );


            // 
            m_ConfigEControlSub4.CheckBoxAllow.Checked = extend.Info04.Enabled;

            if ( extend.Info04.Select == U50ExtendInfo04Type.Any )
            {
                m_ConfigEControlSub4.RadioButtonAny.Checked = true;
            }
            else if ( extend.Info04.Select == U50ExtendInfo04Type.Yes )
            {
                m_ConfigEControlSub4.RadioButtonYes.Checked = true;
            }
            else if ( extend.Info04.Select == U50ExtendInfo04Type.No )
            {
                m_ConfigEControlSub4.RadioButtonNo.Checked = true;
            }

            // 
            m_ConfigEControlSub5.CheckBoxAllow.Checked = extend.Info05.Enabled;

            if ( extend.Info05.Select == U50SelectType.Any )
            {
                m_ConfigEControlSub5.RadioButtonAny.Checked = true;
            }
            else if ( extend.Info05.Select == U50SelectType.Big )
            {
                m_ConfigEControlSub5.RadioButtonBig.Checked = true;
            }
            else if ( extend.Info05.Select == U50SelectType.BigAndSmall )
            {
                m_ConfigEControlSub5.RadioButtonBigAndSmall.Checked = true;
            }
            else if ( extend.Info05.Select == U50SelectType.Small )
            {
                m_ConfigEControlSub5.RadioButtonSmall.Checked = true;
            }

            m_ConfigEControlSub5.MaskedTextBoxBig.Text = extend.Info05.Big.ToString( "00000" );
            m_ConfigEControlSub5.MaskedTextBoxBig2.Text = extend.Info05.Big2.ToString( "00000" );

            m_ConfigEControlSub5.MaskedTextBoxSmall.Text = extend.Info05.Small.ToString( "00000" );
            m_ConfigEControlSub5.MaskedTextBoxSmall2.Text = extend.Info05.Small2.ToString( "00000" );
        }

        public U50Extend GetConfigExtend()
        {
            U50Extend extend = new U50Extend();

            extend.Info01.Enabled = m_ConfigEControlSub1.CheckBoxAllow.Checked;

            if ( m_ConfigEControlSub1.RadioButtonAny.Checked == true )
            {
                extend.Info01.Select = U50ExtendInfo01Type.Any;
            }
            else if ( m_ConfigEControlSub1.RadioButtonHigh.Checked == true )
            {
                extend.Info01.Select = U50ExtendInfo01Type.High;
            }
            else if ( m_ConfigEControlSub1.RadioButtonHighNow.Checked == true )
            {
                extend.Info01.Select = U50ExtendInfo01Type.HighNumber;
            }

            extend.Info01.HighNumber = (int)m_ConfigEControlSub1.NumericUpDownKLine.Value;


            // 
            extend.Info02.Enabled = m_ConfigEControlSub2.CheckBoxAllow.Checked;

            if ( m_ConfigEControlSub2.RadioButtonAny.Checked == true )
            {
                extend.Info02.Select = U50SelectType.Any;
            }
            else if ( m_ConfigEControlSub2.RadioButtonBig.Checked == true )
            {
                extend.Info02.Select = U50SelectType.Big;
            }
            else if ( m_ConfigEControlSub2.RadioButtonBigAndSmall.Checked == true )
            {
                extend.Info02.Select = U50SelectType.BigAndSmall;
            }
            else if ( m_ConfigEControlSub2.RadioButtonSmall.Checked == true )
            {
                extend.Info02.Select = U50SelectType.Small;
            }

            extend.Info02.Big = long.Parse( m_ConfigEControlSub2.MaskedTextBoxBig.Text );
            extend.Info02.Big2 = long.Parse( m_ConfigEControlSub2.MaskedTextBoxBig2.Text );

            extend.Info02.Small = long.Parse( m_ConfigEControlSub2.MaskedTextBoxSmall.Text );
            extend.Info02.Small2 = long.Parse( m_ConfigEControlSub2.MaskedTextBoxSmall2.Text );

            // 
            extend.Info03.Enabled = m_ConfigEControlSub3.CheckBoxAllow.Checked;

            if ( m_ConfigEControlSub3.RadioButtonAny.Checked == true )
            {
                extend.Info03.Select = U50SelectType.Any;
            }
            else if ( m_ConfigEControlSub3.RadioButtonBig.Checked == true )
            {
                extend.Info03.Select = U50SelectType.Big;
            }
            else if ( m_ConfigEControlSub3.RadioButtonBigAndSmall.Checked == true )
            {
                extend.Info03.Select = U50SelectType.BigAndSmall;
            }
            else if ( m_ConfigEControlSub3.RadioButtonSmall.Checked == true )
            {
                extend.Info03.Select = U50SelectType.Small;
            }

            extend.Info03.Big = int.Parse( m_ConfigEControlSub3.MaskedTextBoxBig.Text );
            extend.Info03.Big2 = int.Parse( m_ConfigEControlSub3.MaskedTextBoxBig2.Text );

            extend.Info03.Small = int.Parse( m_ConfigEControlSub3.MaskedTextBoxSmall.Text );
            extend.Info03.Small2 = int.Parse( m_ConfigEControlSub3.MaskedTextBoxSmall2.Text );

            // 
            extend.Info04.Enabled = m_ConfigEControlSub4.CheckBoxAllow.Checked;

            if ( m_ConfigEControlSub4.RadioButtonAny.Checked == true )
            {
                extend.Info04.Select = U50ExtendInfo04Type.Any;
            }
            else if ( m_ConfigEControlSub4.RadioButtonYes.Checked == true )
            {
                extend.Info04.Select = U50ExtendInfo04Type.Yes;
            }
            else if ( m_ConfigEControlSub4.RadioButtonNo.Checked == true )
            {
                extend.Info04.Select = U50ExtendInfo04Type.No;
            }

            // 
            extend.Info05.Enabled = m_ConfigEControlSub5.CheckBoxAllow.Checked;

            if ( m_ConfigEControlSub5.RadioButtonAny.Checked == true )
            {
                extend.Info05.Select = U50SelectType.Any;
            }
            else if ( m_ConfigEControlSub5.RadioButtonBig.Checked == true )
            {
                extend.Info05.Select = U50SelectType.Big;
            }
            else if ( m_ConfigEControlSub5.RadioButtonBigAndSmall.Checked == true )
            {
                extend.Info05.Select = U50SelectType.BigAndSmall;
            }
            else if ( m_ConfigEControlSub5.RadioButtonSmall.Checked == true )
            {
                extend.Info05.Select = U50SelectType.Small;
            }

            extend.Info05.Big = int.Parse( m_ConfigEControlSub5.MaskedTextBoxBig.Text );
            extend.Info05.Big2 = int.Parse( m_ConfigEControlSub5.MaskedTextBoxBig2.Text );

            extend.Info05.Small = int.Parse( m_ConfigEControlSub5.MaskedTextBoxSmall.Text );
            extend.Info05.Small2 = int.Parse( m_ConfigEControlSub5.MaskedTextBoxSmall2.Text );

            return extend;
        }

        private void ButtonO_Click( object sender, EventArgs e )
        {
            if ( m_CurrentConfigEControlSub != null && m_CurrentConfigEControlSub != m_ConfigEControlSub0 )
                m_CurrentConfigEControlSub.Visible = false;

            m_CurrentConfigEControlSub = m_ConfigEControlSub0;
            m_ConfigEControlSub0.Visible = true;

            this.ButtonO.Enabled = false;
            if ( this.Button1.Enabled == false )
                this.Button1.Enabled = true;
            if ( this.Button2.Enabled == false )
                this.Button2.Enabled = true;
            if ( this.Button3.Enabled == false )
                this.Button3.Enabled = true;
            if ( this.Button4.Enabled == false )
                this.Button4.Enabled = true;
            if ( this.Button5.Enabled == false )
                this.Button5.Enabled = true;
            if ( this.Button6.Enabled == false )
                this.Button6.Enabled = true;
        }

        private void Button1_Click( object sender, EventArgs e )
        {
            if ( m_CurrentConfigEControlSub != null && m_CurrentConfigEControlSub != m_ConfigEControlSub1 )
                m_CurrentConfigEControlSub.Visible = false;

            m_CurrentConfigEControlSub = m_ConfigEControlSub1;
            m_ConfigEControlSub1.Visible = true;

            this.Button1.Enabled = false;
            if ( this.ButtonO.Enabled == false )
                this.ButtonO.Enabled = true;
            if ( this.Button2.Enabled == false )
                this.Button2.Enabled = true;
            if ( this.Button3.Enabled == false )
                this.Button3.Enabled = true;
            if ( this.Button4.Enabled == false )
                this.Button4.Enabled = true;
            if ( this.Button5.Enabled == false )
                this.Button5.Enabled = true;
            if ( this.Button6.Enabled == false )
                this.Button6.Enabled = true;
        }

        private void Button2_Click( object sender, EventArgs e )
        {
            if ( m_CurrentConfigEControlSub != null && m_CurrentConfigEControlSub != m_ConfigEControlSub2 )
                m_CurrentConfigEControlSub.Visible = false;

            m_CurrentConfigEControlSub = m_ConfigEControlSub2;
            m_ConfigEControlSub2.Visible = true;

            this.Button2.Enabled = false;
            if ( this.ButtonO.Enabled == false )
                this.ButtonO.Enabled = true;
            if ( this.Button1.Enabled == false )
                this.Button1.Enabled = true;
            if ( this.Button3.Enabled == false )
                this.Button3.Enabled = true;
            if ( this.Button4.Enabled == false )
                this.Button4.Enabled = true;
            if ( this.Button5.Enabled == false )
                this.Button5.Enabled = true;
            if ( this.Button6.Enabled == false )
                this.Button6.Enabled = true;
        }

        private void Button3_Click( object sender, EventArgs e )
        {
            if ( m_CurrentConfigEControlSub != null && m_CurrentConfigEControlSub != m_ConfigEControlSub3 )
                m_CurrentConfigEControlSub.Visible = false;

            m_CurrentConfigEControlSub = m_ConfigEControlSub3;
            m_ConfigEControlSub3.Visible = true;

            this.Button3.Enabled = false;
            if ( this.ButtonO.Enabled == false )
                this.ButtonO.Enabled = true;
            if ( this.Button1.Enabled == false )
                this.Button1.Enabled = true;
            if ( this.Button2.Enabled == false )
                this.Button2.Enabled = true;
            if ( this.Button4.Enabled == false )
                this.Button4.Enabled = true;
            if ( this.Button5.Enabled == false )
                this.Button5.Enabled = true;
            if ( this.Button6.Enabled == false )
                this.Button6.Enabled = true;
        }

        private void Button4_Click( object sender, EventArgs e )
        {
            if ( m_CurrentConfigEControlSub != null && m_CurrentConfigEControlSub != m_ConfigEControlSub4 )
                m_CurrentConfigEControlSub.Visible = false;

            m_CurrentConfigEControlSub = m_ConfigEControlSub4;
            m_ConfigEControlSub4.Visible = true;

            this.Button4.Enabled = false;
            if ( this.ButtonO.Enabled == false )
                this.ButtonO.Enabled = true;
            if ( this.Button1.Enabled == false )
                this.Button1.Enabled = true;
            if ( this.Button2.Enabled == false )
                this.Button2.Enabled = true;
            if ( this.Button3.Enabled == false )
                this.Button3.Enabled = true;
            if ( this.Button5.Enabled == false )
                this.Button5.Enabled = true;
            if ( this.Button6.Enabled == false )
                this.Button6.Enabled = true;
        }

        private void Button5_Click( object sender, EventArgs e )
        {
            if ( m_CurrentConfigEControlSub != null && m_CurrentConfigEControlSub != m_ConfigEControlSub5 )
                m_CurrentConfigEControlSub.Visible = false;

            m_CurrentConfigEControlSub = m_ConfigEControlSub5;
            m_ConfigEControlSub5.Visible = true;

            this.Button5.Enabled = false;
            if ( this.ButtonO.Enabled == false )
                this.ButtonO.Enabled = true;
            if ( this.Button1.Enabled == false )
                this.Button1.Enabled = true;
            if ( this.Button2.Enabled == false )
                this.Button2.Enabled = true;
            if ( this.Button3.Enabled == false )
                this.Button3.Enabled = true;
            if ( this.Button4.Enabled == false )
                this.Button4.Enabled = true;
            if ( this.Button6.Enabled == false )
                this.Button6.Enabled = true;
        }

        private void Button6_Click( object sender, EventArgs e )
        {
            if ( m_CurrentConfigEControlSub != null && m_CurrentConfigEControlSub != m_ConfigEControlSub6 )
                m_CurrentConfigEControlSub.Visible = false;

            m_CurrentConfigEControlSub = m_ConfigEControlSub6;
            m_ConfigEControlSub6.Visible = true;

            this.Button6.Enabled = false;
            if ( this.ButtonO.Enabled == false )
                this.ButtonO.Enabled = true;
            if ( this.Button1.Enabled == false )
                this.Button1.Enabled = true;
            if ( this.Button2.Enabled == false )
                this.Button2.Enabled = true;
            if ( this.Button3.Enabled == false )
                this.Button3.Enabled = true;
            if ( this.Button4.Enabled == false )
                this.Button4.Enabled = true;
            if ( this.Button5.Enabled == false )
                this.Button5.Enabled = true;
        }

        #region OnEventButtonSetting
         //<summary>
         //Triggers the EventButtonSetting event.
         //</summary>
        private void OnEventButtonSetting( object sender, EventArgs e )
        {
            if ( EventButtonSetting != null )
                EventButtonSetting( this, e );
        }
        #endregion
        public event EventHandler EventButtonSetting;
    }
}
