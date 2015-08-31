using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Demo.Stock.LHP
{
    public partial class ScanUpControlSub2 : UserControl
    {
        public ScanUpControlSub2()
        {
            InitializeComponent();
        }

        private void ScanUpControlSub2_Load( object sender, EventArgs e )
        {
            this.RadioButtonCloseAnyOne_CheckedChanged( this, EventArgs.Empty );
            this.RadioButtonCloseBig_CheckedChanged( this, EventArgs.Empty );
            this.RadioButtonCloseSmall_CheckedChanged( this, EventArgs.Empty );
            this.RadioButtonCloseBigAndSmall_CheckedChanged( this, EventArgs.Empty );

            this.RadioButtonCloseUpAnyOne_CheckedChanged( this, EventArgs.Empty );
            this.RadioButtonCloseUpBig_CheckedChanged( this, EventArgs.Empty );
            this.RadioButtonCloseUpSmall_CheckedChanged( this, EventArgs.Empty );
            this.RadioButtonCloseUpBigAndSmall_CheckedChanged( this, EventArgs.Empty );

            this.RadioButtonARPFAnyOne_CheckedChanged( this, EventArgs.Empty );
            this.RadioButtonARPFBig_CheckedChanged( this, EventArgs.Empty );
            this.RadioButtonARPFSmall_CheckedChanged( this, EventArgs.Empty );
            this.RadioButtonARPFBigAndSmall_CheckedChanged( this, EventArgs.Empty );

            this.RadioButtonVolumeAnyOne_CheckedChanged( this, EventArgs.Empty );
            this.RadioButtonVolumeBig_CheckedChanged( this, EventArgs.Empty );
            this.RadioButtonVolumeSmall_CheckedChanged( this, EventArgs.Empty );
            this.RadioButtonVolumeBigAndSmall_CheckedChanged( this, EventArgs.Empty );

            this.RadioButtonVolume23AnyOne_CheckedChanged( this, EventArgs.Empty );
            this.RadioButtonVolume23Big_CheckedChanged( this, EventArgs.Empty );
            this.RadioButtonVolume23Small_CheckedChanged( this, EventArgs.Empty );
            this.RadioButtonVolume23BigAndSmall_CheckedChanged( this, EventArgs.Empty );

            this.RadioButtonVolumeUpAnyOne_CheckedChanged( this, EventArgs.Empty );
            this.RadioButtonVolumeUpBig_CheckedChanged( this, EventArgs.Empty );
            this.RadioButtonVolumeUpSmall_CheckedChanged( this, EventArgs.Empty );
            this.RadioButtonVolumeUpBigAndSmall_CheckedChanged( this, EventArgs.Empty );
        }

        private void RadioButtonCloseAnyOne_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.RadioButtonCloseAnyOne.Checked == true )
            {
                this.MaskedTextBoxCloseBig.Enabled = false;
                this.MaskedTextBoxCloseSmall.Enabled = false;
                this.MaskedTextBoxCloseBig2.Enabled = false;
                this.MaskedTextBoxCloseSmall2.Enabled = false;
            }
        }

        private void RadioButtonCloseBig_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.RadioButtonCloseBig.Checked == true )
            {
                this.MaskedTextBoxCloseBig.Enabled = true;
                this.MaskedTextBoxCloseSmall.Enabled = false;
                this.MaskedTextBoxCloseBig2.Enabled = false;
                this.MaskedTextBoxCloseSmall2.Enabled = false;
            }
        }

        private void RadioButtonCloseSmall_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.RadioButtonCloseSmall.Checked == true )
            {
                this.MaskedTextBoxCloseSmall.Enabled = true;
                this.MaskedTextBoxCloseBig.Enabled = false;
                this.MaskedTextBoxCloseBig2.Enabled = false;
                this.MaskedTextBoxCloseSmall2.Enabled = false;
            }
        }

        private void RadioButtonCloseBigAndSmall_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.RadioButtonCloseBigAndSmall.Checked == true )
            {
                this.MaskedTextBoxCloseBig.Enabled = false;
                this.MaskedTextBoxCloseSmall.Enabled = false;
                this.MaskedTextBoxCloseBig2.Enabled = true;
                this.MaskedTextBoxCloseSmall2.Enabled = true;
            }
        }

        private void RadioButtonCloseUpAnyOne_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.RadioButtonCloseUpAnyOne.Checked == true )
            {
                this.MaskedTextBoxCloseUpBig.Enabled = false;
                this.MaskedTextBoxCloseUpSmall.Enabled = false;
                this.MaskedTextBoxCloseUpBig2.Enabled = false;
                this.MaskedTextBoxCloseUpSmall2.Enabled = false;
            }
        }

        private void RadioButtonCloseUpBig_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.RadioButtonCloseUpBig.Checked == true )
            {
                this.MaskedTextBoxCloseUpBig.Enabled = true;
                this.MaskedTextBoxCloseUpSmall.Enabled = false;
                this.MaskedTextBoxCloseUpBig2.Enabled = false;
                this.MaskedTextBoxCloseUpSmall2.Enabled = false;
            }
        }

        private void RadioButtonCloseUpSmall_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.RadioButtonCloseUpSmall.Checked == true )
            {
                this.MaskedTextBoxCloseUpSmall.Enabled = true;
                this.MaskedTextBoxCloseUpBig.Enabled = false;
                this.MaskedTextBoxCloseUpBig2.Enabled = false;
                this.MaskedTextBoxCloseUpSmall2.Enabled = false;
            }
        }

        private void RadioButtonCloseUpBigAndSmall_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.RadioButtonCloseUpBigAndSmall.Checked == true )
            {
                this.MaskedTextBoxCloseUpBig.Enabled = false;
                this.MaskedTextBoxCloseUpSmall.Enabled = false;
                this.MaskedTextBoxCloseUpBig2.Enabled = true;
                this.MaskedTextBoxCloseUpSmall2.Enabled = true;
            }
        }

        private void RadioButtonARPFAnyOne_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.RadioButtonARPFAnyOne.Checked == true )
            {
                this.MaskedTextBoxARPFBig.Enabled = false;
                this.MaskedTextBoxARPFSmall.Enabled = false;
                this.MaskedTextBoxARPFBig2.Enabled = false;
                this.MaskedTextBoxARPFSmall2.Enabled = false;
            }
        }

        private void RadioButtonARPFBig_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.RadioButtonARPFBig.Checked == true )
            {
                this.MaskedTextBoxARPFBig.Enabled = true;
                this.MaskedTextBoxARPFSmall.Enabled = false;
                this.MaskedTextBoxARPFBig2.Enabled = false;
                this.MaskedTextBoxARPFSmall2.Enabled = false;
            }
        }

        private void RadioButtonARPFSmall_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.RadioButtonARPFSmall.Checked == true )
            {
                this.MaskedTextBoxARPFSmall.Enabled = true;
                this.MaskedTextBoxARPFBig.Enabled = false;
                this.MaskedTextBoxARPFBig2.Enabled = false;
                this.MaskedTextBoxARPFSmall2.Enabled = false;
            }
        }

        private void RadioButtonARPFBigAndSmall_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.RadioButtonARPFBigAndSmall.Checked == true )
            {
                this.MaskedTextBoxARPFBig.Enabled = false;
                this.MaskedTextBoxARPFSmall.Enabled = false;
                this.MaskedTextBoxARPFBig2.Enabled = true;
                this.MaskedTextBoxARPFSmall2.Enabled = true;
            }
        }

        private void RadioButtonVolumeAnyOne_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.RadioButtonVolumeAnyOne.Checked == true )
            {
                this.MaskedTextBoxVolumeBig.Enabled = false;
                this.MaskedTextBoxVolumeSmall.Enabled = false;
                this.MaskedTextBoxVolumeBig2.Enabled = false;
                this.MaskedTextBoxVolumeSmall2.Enabled = false;
            }
        }

        private void RadioButtonVolumeBig_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.RadioButtonVolumeBig.Checked == true )
            {
                this.MaskedTextBoxVolumeBig.Enabled = true;
                this.MaskedTextBoxVolumeSmall.Enabled = false;
                this.MaskedTextBoxVolumeBig2.Enabled = false;
                this.MaskedTextBoxVolumeSmall2.Enabled = false;
            }
        }

        private void RadioButtonVolumeSmall_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.RadioButtonVolumeSmall.Checked == true )
            {
                this.MaskedTextBoxVolumeSmall.Enabled = true;
                this.MaskedTextBoxVolumeBig.Enabled = false;
                this.MaskedTextBoxVolumeBig2.Enabled = false;
                this.MaskedTextBoxVolumeSmall2.Enabled = false;
            }
        }

        private void RadioButtonVolumeBigAndSmall_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.RadioButtonVolumeBigAndSmall.Checked == true )
            {
                this.MaskedTextBoxVolumeBig.Enabled = false;
                this.MaskedTextBoxVolumeSmall.Enabled = false;
                this.MaskedTextBoxVolumeBig2.Enabled = true;
                this.MaskedTextBoxVolumeSmall2.Enabled = true;
            }
        }

        private void RadioButtonVolume23AnyOne_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.RadioButtonVolume23AnyOne.Checked == true )
            {
                this.MaskedTextBoxVolume23Big.Enabled = false;
                this.MaskedTextBoxVolume23Small.Enabled = false;
                this.MaskedTextBoxVolume23Big2.Enabled = false;
                this.MaskedTextBoxVolume23Small2.Enabled = false;
            }
        }

        private void RadioButtonVolume23Big_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.RadioButtonVolume23Big.Checked == true )
            {
                this.MaskedTextBoxVolume23Big.Enabled = true;
                this.MaskedTextBoxVolume23Small.Enabled = false;
                this.MaskedTextBoxVolume23Big2.Enabled = false;
                this.MaskedTextBoxVolume23Small2.Enabled = false;
            }
        }

        private void RadioButtonVolume23Small_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.RadioButtonVolume23Small.Checked == true )
            {
                this.MaskedTextBoxVolume23Small.Enabled = true;
                this.MaskedTextBoxVolume23Big.Enabled = false;
                this.MaskedTextBoxVolume23Big2.Enabled = false;
                this.MaskedTextBoxVolume23Small2.Enabled = false;
            }
        }

        private void RadioButtonVolume23BigAndSmall_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.RadioButtonVolume23BigAndSmall.Checked == true )
            {
                this.MaskedTextBoxVolume23Big.Enabled = false;
                this.MaskedTextBoxVolume23Small.Enabled = false;
                this.MaskedTextBoxVolume23Big2.Enabled = true;
                this.MaskedTextBoxVolume23Small2.Enabled = true;
            }
        }

        private void RadioButtonVolumeUpAnyOne_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.RadioButtonVolumeUpAnyOne.Checked == true )
            {
                this.MaskedTextBoxVolumeUpBig.Enabled = false;
                this.MaskedTextBoxVolumeUpSmall.Enabled = false;
                this.MaskedTextBoxVolumeUpBig2.Enabled = false;
                this.MaskedTextBoxVolumeUpSmall2.Enabled = false;
            }
        }

        private void RadioButtonVolumeUpBig_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.RadioButtonVolumeUpBig.Checked == true )
            {
                this.MaskedTextBoxVolumeUpBig.Enabled = true;
                this.MaskedTextBoxVolumeUpSmall.Enabled = false;
                this.MaskedTextBoxVolumeUpBig2.Enabled = false;
                this.MaskedTextBoxVolumeUpSmall2.Enabled = false;
            }
        }

        private void RadioButtonVolumeUpSmall_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.RadioButtonVolumeUpSmall.Checked == true )
            {
                this.MaskedTextBoxVolumeUpSmall.Enabled = true;
                this.MaskedTextBoxVolumeUpBig.Enabled = false;
                this.MaskedTextBoxVolumeUpBig2.Enabled = false;
                this.MaskedTextBoxVolumeUpSmall2.Enabled = false;
            }
        }

        private void RadioButtonVolumeUpBigAndSmall_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.RadioButtonVolumeUpBigAndSmall.Checked == true )
            {
                this.MaskedTextBoxVolumeUpBig.Enabled = false;
                this.MaskedTextBoxVolumeUpSmall.Enabled = false;
                this.MaskedTextBoxVolumeUpBig2.Enabled = true;
                this.MaskedTextBoxVolumeUpSmall2.Enabled = true;
            }
        }
    }
}
