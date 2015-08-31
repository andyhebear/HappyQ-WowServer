using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dundas.Charting.WinControl;
using Demo.Stock.X.Common;

namespace Demo.Stock.X.Tools
{
    public partial class KLineViewFormDocument : Form
    {
        private MSFL.MSFLPriceRecord[] m_PriceRecordArray = new MSFL.MSFLPriceRecord[0];
        private void GetPriceRecord( MSFL.MSFLSecurityInfo msflSecurityInfo )
        {
            IntPtr hSecurity = msflSecurityInfo.hSecurity;

            int iErr = MSFL.MSFL1_LockSecurity( hSecurity, MSFL.MSFL_LOCK_PREV_WRITE_LOCK );
            if ( iErr != (int)MSFL.MSFL_ERR.MSFL_NO_ERR )
                return;

            ushort wPriceRecCount = 0;
            iErr = MSFL.MSFL1_GetDataRecordCount( hSecurity, ref wPriceRecCount );
            if ( iErr != (int)MSFL.MSFL_ERR.MSFL_NO_ERR )
                return;

            if ( wPriceRecCount > 0 )
            {
                iErr = MSFL.MSFL1_SeekBeginData( hSecurity );
                if ( iErr != (int)MSFL.MSFL_ERR.MSFL_NO_ERR )
                    return;

                MSFL.DateTime sDateTime = new MSFL.DateTime();
                m_PriceRecordArray = new MSFL.MSFLPriceRecord[wPriceRecCount];

                iErr = MSFL.MSFL2_ReadMultipleRecs( hSecurity, m_PriceRecordArray, ref sDateTime, ref wPriceRecCount, (int)MSFL.MSFL_FIND.MSFL_FIND_USE_CURRENT_POS );
                if ( iErr != (int)MSFL.MSFL_ERR.MSFL_NO_ERR )
                    return;

                // Unlock the security (we're done using it)
                iErr = MSFL.MSFL1_UnlockSecurity( hSecurity );
            }
        }

        public KLineViewFormDocument( MSFL.MSFLSecurityInfo msflSecurityInfo )
        {
            GetPriceRecord( msflSecurityInfo );

            InitializeComponent();
        }

        private void KLineViewFormDocument_Load( object sender, EventArgs e )
        {
            CreateChart();
        }

        private void CreateChart()
        {
            ChartArea chartArea1 = new ChartArea();
            ChartArea chartArea2 = new ChartArea();

            Legend legend1 = new Legend();

            Series series1 = new Series();
            Series series2 = new Series();
            Series series3 = new Series();

            // chart1
            this.chart1.BackColor = Color.FromArgb( ( (byte)( 211 ) ), ( (byte)( 223 ) ), ( (byte)( 240 ) ) );
            this.chart1.BackGradientEndColor = Color.White;
            this.chart1.BackGradientType = GradientType.TopBottom;

            this.chart1.BorderLineColor = Color.FromArgb( ( (byte)( 26 ) ), ( (byte)( 59 ) ), ( (byte)( 105 ) ) );
            this.chart1.BorderLineStyle = ChartDashStyle.Solid;
            this.chart1.BorderLineWidth = 1;

            this.chart1.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;

            // chartArea1
            chartArea1.AxisX.LabelStyle.TruncatedLabels = false;
            chartArea1.AxisX.LabelStyle.ShowEndLabels = false;
            chartArea1.AxisX.LabelStyle.Format = "m";

            chartArea1.AxisX.LineColor = Color.FromArgb( ( (byte)( 64 ) ), ( (byte)( 64 ) ), ( (byte)( 64 ) ), ( (byte)( 64 ) ) );

            chartArea1.AxisX.MajorGrid.LineColor = Color.FromArgb( ( (byte)( 64 ) ), ( (byte)( 64 ) ), ( (byte)( 64 ) ), ( (byte)( 64 ) ) );
            chartArea1.AxisX.MinorGrid.Enabled = true;
            chartArea1.AxisX.MinorGrid.Interval = 1;
            //chartArea1.AxisX.MinorGrid.IntervalType = DateTimeIntervalType.Days;
            chartArea1.AxisX.MinorGrid.LineColor = Color.FromArgb( ( (byte)( 64 ) ), ( (byte)( 64 ) ), ( (byte)( 64 ) ), ( (byte)( 64 ) ) );

            chartArea1.AxisX.StartFromZero = false;
            chartArea1.AxisX.Interval = 7;
            //chartArea1.AxisX.View.Zoomable = true;
            //chartArea1.CursorX.AutoScroll = true;

            chartArea1.AxisY.Enabled = AxisEnabled.False;
            chartArea1.AxisY.StartFromZero = false;

            chartArea1.AxisY2.Enabled = AxisEnabled.True;
            chartArea1.AxisY2.LineColor = Color.FromArgb( ( (byte)( 64 ) ), ( (byte)( 64 ) ), ( (byte)( 64 ) ), ( (byte)( 64 ) ) );
            chartArea1.AxisY2.MajorGrid.LineColor = Color.FromArgb( ( (byte)( 64 ) ), ( (byte)( 64 ) ), ( (byte)( 64 ) ), ( (byte)( 64 ) ) );
            chartArea1.AxisY2.StartFromZero = false;
            chartArea1.AxisY2.MinorGrid.Enabled = true;
            chartArea1.AxisY2.MinorGrid.Interval = 1;
            chartArea1.AxisY2.MinorGrid.LineColor = Color.FromArgb( ( (byte)( 64 ) ), ( (byte)( 64 ) ), ( (byte)( 64 ) ), ( (byte)( 64 ) ) );
            chartArea1.AxisY2.Interval = 4;

            chartArea1.BackColor = Color.FromArgb( ( (byte)( 64 ) ), ( (byte)( 165 ) ), ( (byte)( 191 ) ), ( (byte)( 228 ) ) );
            chartArea1.BackGradientEndColor = Color.White;
            chartArea1.BackGradientType = GradientType.TopBottom;
            chartArea1.BorderColor = Color.FromArgb( ( (byte)( 64 ) ), ( (byte)( 64 ) ), ( (byte)( 64 ) ), ( (byte)( 64 ) ) );
            chartArea1.BorderStyle = ChartDashStyle.Solid;

            chartArea1.Name = "PriceArea";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 76F;
            chartArea1.Position.Width = 92F;
            chartArea1.Position.X = 4F;
            chartArea1.Position.Y = 4F;
            chartArea1.ShadowColor = Color.Transparent;

            // chartArea2
            chartArea2.AlignWithChartArea = "PriceArea";

            chartArea2.AxisX.Enabled = AxisEnabled.False;

            chartArea2.AxisY.Enabled = AxisEnabled.False;
            chartArea2.AxisY.StartFromZero = false;

            chartArea2.AxisY2.Enabled = AxisEnabled.True;
            chartArea2.AxisY2.LineColor = Color.FromArgb( ( (byte)( 64 ) ), ( (byte)( 64 ) ), ( (byte)( 64 ) ), ( (byte)( 64 ) ) );
            chartArea2.AxisY2.MajorGrid.LineColor = Color.FromArgb( ( (byte)( 64 ) ), ( (byte)( 64 ) ), ( (byte)( 64 ) ), ( (byte)( 64 ) ) );
            chartArea2.AxisY2.StartFromZero = false;
            //chartArea2.AxisY2.Interval = 5000;

            chartArea2.BackColor = Color.FromArgb( ( (byte)( 64 ) ), ( (byte)( 165 ) ), ( (byte)( 191 ) ), ( (byte)( 228 ) ) );
            chartArea2.BackGradientEndColor = Color.White;
            chartArea2.BackGradientType = GradientType.TopBottom;
            chartArea2.BorderColor = Color.FromArgb( ( (byte)( 64 ) ), ( (byte)( 64 ) ), ( (byte)( 64 ) ), ( (byte)( 64 ) ) );
            chartArea2.BorderStyle = ChartDashStyle.Solid;

            chartArea2.Name = "VolumeArea";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 16F;
            chartArea2.Position.Width = 92F;
            chartArea2.Position.X = 4F;
            chartArea2.Position.Y = 80F;
            chartArea2.ShadowColor = Color.Transparent;

            this.chart1.ChartAreas.Add( chartArea1 );
            this.chart1.ChartAreas.Add( chartArea2 );

            series1.ChartArea = "PriceArea";
            series1.Name = "PriceSeries";
            series1.Type = SeriesChartType.CandleStick;
            series1.ShowInLegend = false;
            series1.XValueType = ChartValueTypes.DateTime;
            series1.YValuesPerPoint = 4;
            series1.ShadowOffset = 1;
            series1.BorderColor = Color.FromArgb( ( (byte)( 180 ) ), ( (byte)( 26 ) ), ( (byte)( 59 ) ), ( (byte)( 105 ) ) );
            series1["PointWidth"] = "0.5";

            series2.ChartArea = "VolumeArea";
            series2.Name = "VolumeSeries";
            series2.Type = SeriesChartType.Column;
            series2.ShowInLegend = false;
            series2.ShadowOffset = 1;
            series2.XValueType = ChartValueTypes.DateTime;
            series2.BorderColor = Color.FromArgb( ( (byte)( 180 ) ), ( (byte)( 26 ) ), ( (byte)( 59 ) ), ( (byte)( 105 ) ) );
            series2["PointWidth"] = "0.5";

            series3.ChartArea = "PriceArea";
            series3.Name = "CurveAtPriceSeries";
            series3.Type = SeriesChartType.Spline;
            series3.ShowInLegend = false;
            series3.ShadowOffset = 2;
            series3.BorderWidth = 3;
            series3.XValueType = ChartValueTypes.DateTime;
            series3.ShowLabelAsValue = true;
            series3.Color = System.Drawing.Color.FromArgb( ( (System.Byte)( 220 ) ), ( (System.Byte)( 252 ) ), ( (System.Byte)( 180 ) ), ( (System.Byte)( 65 ) ) );
            series3["LineTension"] = "0.4";

            this.chart1.Series.Add( series1 );
            this.chart1.Series.Add( series2 );
            this.chart1.Series.Add( series3 );

            // Populate series data
            FillData();
        }

        private const double UP = 1.0;
        private const double DOWN = 0.0;
        private void FillData()
        {
            StringBuilder szBuf = new StringBuilder( MSFL.MSFL_MAX_NAME_LENGTH + 1 );

            // The number of days for stock data
            int period = m_PriceRecordArray.Length > 60 ? 60 : m_PriceRecordArray.Length;

            // numbers for summing price info
            double fHigh = 0.0f, fLow = 0.0f;
            double fVolumeHigh = 0.0f, fVolumeLow = 0.0f;
         
            for ( int iIndex = 0; iIndex < period; iIndex++ )
            {
                MSFL.MSFLPriceRecord msflPriceRecord = m_PriceRecordArray[iIndex];

                // The first High value
                double high = Math.Round( msflPriceRecord.fHigh, 2 );
                if ( high > fHigh )
                    fHigh = high;

                // The first Close value
                double close = Math.Round( msflPriceRecord.fClose, 2 );

                // The first Low value
                double low = Math.Round( msflPriceRecord.fLow, 2 );
                if ( fLow == 0.0f )
                    fLow = low;
                else if ( low < fLow )
                    fLow = low;

                // The first Open value
                double open = Math.Round( msflPriceRecord.fOpen, 2 );

                // The first Volume value
                double volume = Math.Truncate( msflPriceRecord.fVolume );
                if ( volume > fVolumeHigh )
                    fVolumeHigh = volume;

                if ( volume == 0.0f )
                    fVolumeLow = volume;
                else if ( volume < fVolumeLow )
                    fVolumeLow = volume;

                // Set data points values
                MSFL.MSFL1_FormatDate( szBuf, (ushort)szBuf.Capacity, msflPriceRecord.lDate );
                DateTime dateTime = DateTime.Parse( szBuf.ToString() );

                chart1.Series["PriceSeries"].Points.AddXY( dateTime, high );
                //chart1.Series["PriceSeries"].Points[iIndex].XValue = dateTime;

                if ( ( iIndex % 7 ) == 0 )
                    chart1.Series["CurveAtPriceSeries"].Points.AddXY( dateTime, high );

                double isUpOrDown = open <= close ? UP : DOWN;

                chart1.Series["PriceSeries"].Points[iIndex].YValues[1] = low;
                chart1.Series["PriceSeries"].Points[iIndex].YValues[2] = isUpOrDown == UP ? open : close; // open
                chart1.Series["PriceSeries"].Points[iIndex].YValues[3] = isUpOrDown == UP ? close : open; // close

                //chart1.Series["PriceSeries"].Points[iIndex].YValues[4] = isUpOrDown;

                if ( isUpOrDown == UP )
                {
                    chart1.Series["PriceSeries"].Points[iIndex].Color = Color.Green;
                    chart1.Series["PriceSeries"].Points[iIndex].BackGradientEndColor = Color.White;
                    chart1.Series["PriceSeries"].Points[iIndex].BackGradientType = GradientType.VerticalCenter;

                    chart1.Series["PriceSeries"].Points[iIndex].BorderWidth = 1;
                    chart1.Series["PriceSeries"].Points[iIndex].BorderColor = Color.Green;
                    chart1.Series["PriceSeries"].Points[iIndex].BorderStyle = ChartDashStyle.Solid;
                }
                else
                {
                    chart1.Series["PriceSeries"].Points[iIndex].Color = Color.Red;
                    chart1.Series["PriceSeries"].Points[iIndex].BackGradientEndColor = Color.White;
                    chart1.Series["PriceSeries"].Points[iIndex].BackGradientType = GradientType.VerticalCenter;

                    chart1.Series["PriceSeries"].Points[iIndex].BorderWidth = 1;
                    chart1.Series["PriceSeries"].Points[iIndex].BorderColor = Color.Red;
                    chart1.Series["PriceSeries"].Points[iIndex].BorderStyle = ChartDashStyle.Solid;
                }

                // Set volume values
                chart1.Series["VolumeSeries"].Points.AddXY( dateTime, volume );

                if ( isUpOrDown == UP )
                {
                    chart1.Series["VolumeSeries"].Points[iIndex].Color = Color.Green;
                    chart1.Series["VolumeSeries"].Points[iIndex].BackGradientEndColor = Color.White;
                    chart1.Series["VolumeSeries"].Points[iIndex].BackGradientType = GradientType.VerticalCenter;

                    chart1.Series["VolumeSeries"].Points[iIndex].BorderColor = Color.Green;
                }
                else
                {
                    chart1.Series["VolumeSeries"].Points[iIndex].Color = Color.Red;
                    chart1.Series["VolumeSeries"].Points[iIndex].BackGradientEndColor = Color.White;
                    chart1.Series["VolumeSeries"].Points[iIndex].BackGradientType = GradientType.VerticalCenter;

                    chart1.Series["VolumeSeries"].Points[iIndex].BorderColor = Color.Red;
                }
            }


            double fSun = fHigh - fLow;
            chart1.ChartAreas["PriceArea"].AxisY.Interval = fSun / 10;

            //fSun = fVolumeHigh - fVolumeLow;
            //chart1.ChartAreas["VolumeArea"].AxisY2.Interval = Math.Truncate( fSun ) / 5;
        }

        private MSFL.MSFLPriceRecord[] ScanU50PointInfo()
        {
            return null;
        }
    }
}
