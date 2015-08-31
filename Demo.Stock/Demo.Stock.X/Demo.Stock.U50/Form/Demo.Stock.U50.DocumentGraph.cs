using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dundas.Charting.WinControl;

namespace Demo.Stock.X.U50
{
    public partial class DocumentU50Graph : UserControl
    {
        public DocumentU50Graph()
        {
            InitializeComponent();
        }

        private void UserU50Graph_Load( object sender, EventArgs e )
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
            chartArea1.AxisX.MinorGrid.LineColor = Color.FromArgb( ( (byte)( 64 ) ), ( (byte)( 64 ) ), ( (byte)( 64 ) ), ( (byte)( 64 ) ) );

            chartArea1.AxisX.StartFromZero = false;
            chartArea1.AxisX.Interval = 5;

            chartArea1.AxisY.Enabled = AxisEnabled.False;
            chartArea1.AxisY.StartFromZero = false;
            chartArea1.AxisY.Interval = 3;

            chartArea1.AxisY2.Enabled = AxisEnabled.True;
            chartArea1.AxisY2.LineColor = Color.FromArgb( ( (byte)( 64 ) ), ( (byte)( 64 ) ), ( (byte)( 64 ) ), ( (byte)( 64 ) ) );
            chartArea1.AxisY2.MajorGrid.LineColor = Color.FromArgb( ( (byte)( 64 ) ), ( (byte)( 64 ) ), ( (byte)( 64 ) ), ( (byte)( 64 ) ) );
            chartArea1.AxisY2.StartFromZero = false;
            chartArea1.AxisY2.MinorGrid.Enabled = true;
            chartArea1.AxisY2.MinorGrid.Interval = 1;
            chartArea1.AxisY2.MinorGrid.LineColor = Color.FromArgb( ( (byte)( 64 ) ), ( (byte)( 64 ) ), ( (byte)( 64 ) ), ( (byte)( 64 ) ) );
            chartArea1.AxisY2.Interval = 3;

            chartArea1.BackColor = Color.FromArgb( ( (byte)( 64 ) ), ( (byte)( 165 ) ), ( (byte)( 191 ) ), ( (byte)( 228 ) ) );
            chartArea1.BackGradientEndColor = Color.White;
            chartArea1.BackGradientType = GradientType.TopBottom;
            chartArea1.BorderColor = Color.FromArgb( ( (byte)( 64 ) ), ( (byte)( 64 ) ), ( (byte)( 64 ) ), ( (byte)( 64 ) ) );
            chartArea1.BorderStyle = ChartDashStyle.Solid;

            chartArea1.Name = "PriceArea";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 70F;
            chartArea1.Position.Width = 88F;
            chartArea1.Position.X = 7F;
            chartArea1.Position.Y = 10F;
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

            chartArea2.BackColor = Color.FromArgb( ( (byte)( 64 ) ), ( (byte)( 165 ) ), ( (byte)( 191 ) ), ( (byte)( 228 ) ) );
            chartArea2.BackGradientEndColor = Color.White;
            chartArea2.BackGradientType = GradientType.TopBottom;
            chartArea2.BorderColor = Color.FromArgb( ( (byte)( 64 ) ), ( (byte)( 64 ) ), ( (byte)( 64 ) ), ( (byte)( 64 ) ) );
            chartArea2.BorderStyle = ChartDashStyle.Solid;

            chartArea2.Name = "VolumeArea";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 18F;
            chartArea2.Position.Width = 88F;
            chartArea2.Position.X = 7F;
            chartArea2.Position.Y = 80F;
            chartArea2.ShadowColor = Color.Transparent;

            this.chart1.ChartAreas.Add( chartArea1 );
            this.chart1.ChartAreas.Add( chartArea2 );

            // legend1
            legend1.LegendStyle = LegendStyle.Table;
            legend1.TableStyle = LegendTableStyle.Auto;
            legend1.Alignment = StringAlignment.Near;
            legend1.Docking = LegendDocking.Top;
            legend1.DockInsideChartArea = false;
            legend1.DockToChartArea = "PriceArea";
            legend1.Name = "Default";
            legend1.Title = "U50形态股票报表";
            legend1.TitleSeparator = LegendSeparatorType.GradientLine;
            legend1.BorderColor = Color.Transparent;
            legend1.BackColor = Color.White;
            legend1.BackGradientEndColor = Color.FromArgb( ( (byte)( 211 ) ), ( (byte)( 223 ) ), ( (byte)( 240 ) ) );
            legend1.BackGradientType = GradientType.TopBottom;
            legend1.ShadowOffset = 1;
            this.chart1.Legends.Add( legend1 );

            LegendItem legendItem = new LegendItem();
            chart1.Legend.CustomItems.Add( legendItem );
            legendItem.Cells.Add( new LegendCell( LegendCellType.Text, "股票代号(xxxx)", ContentAlignment.TopLeft ) );
            legendItem.Cells.Add( new LegendCell( LegendCellType.Text, "起始日期(xxxx)", ContentAlignment.TopLeft ) );
            legendItem.Cells.Add( new LegendCell( LegendCellType.Text, "成交量变化(xxxx)", ContentAlignment.MiddleLeft ) );

            legendItem = new LegendItem();
            chart1.Legend.CustomItems.Add( legendItem );
            legendItem.Cells.Add( new LegendCell( LegendCellType.Text, "收盘价(xxxx)", ContentAlignment.MiddleLeft ) );
            legendItem.Cells.Add( new LegendCell( LegendCellType.Text, "K线总数(xxxx)", ContentAlignment.MiddleLeft ) );
            legendItem.Cells.Add( new LegendCell( LegendCellType.Text, "平均成交量(xxxx)", ContentAlignment.MiddleLeft ) );

            legendItem = new LegendItem();
            chart1.Legend.CustomItems.Add( legendItem );
            legendItem.Cells.Add( new LegendCell( LegendCellType.Text, "品质系数(xxxx)", ContentAlignment.MiddleLeft ) );

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
            series3.Name = "VolumeAtPriceSeries";
            series3.Type = SeriesChartType.Gantt;
            series3.ShowInLegend = false;
            series3.ShadowOffset = 1;
            series3.XValueType = ChartValueTypes.DateTime;
            //series3.BorderColor = Color.FromArgb( ( (byte)( 180 ) ), ( (byte)( 26 ) ), ( (byte)( 59 ) ), ( (byte)( 105 ) ) );
            series3["PointWidth"] = "0.5";

            this.chart1.Series.Add( series1 );
            this.chart1.Series.Add( series2 );

            // Populate series data
            FillData();
        }

        bool ddd = false;
        bool fff = false;
        /// <summary>
        /// Random Stock Data Generator
        /// </summary>
        private void FillData()
        {
            Random rand;
            // Use a number to calculate a starting value for 
            // the pseudo-random number sequence
            rand = new Random();

            // The number of days for stock data
            int period = 60;

            // The first High value
            double high = rand.NextDouble() * 40;

            // The first Close value
            double close = high - rand.NextDouble();

            // The first Low value
            double low = close - rand.NextDouble();

            // The first Open value
            double open = ( high - low ) * rand.NextDouble() + low;

            // The first Volume value
            double volume = 100 + 15 * rand.NextDouble();

            DateTime dayNow = DateTime.Parse( "1/2/2002" );
            // The first day X and Y values
            chart1.Series["PriceSeries"].Points.AddXY( dayNow, high );
            chart1.Series["VolumeSeries"].Points.AddXY( dayNow, volume );
            //chart1.Series["VolumeAtPriceSeries"].Points.AddXY( dayNow, volume );

            chart1.Series["PriceSeries"].Points[0].YValues[1] = low;

            // The Open value is not used.
            chart1.Series["PriceSeries"].Points[0].YValues[2] = open;
            chart1.Series["PriceSeries"].Points[0].YValues[3] = close;

            // Days loop
            for ( int day = 1; day <= period; day++ )
            {

                // Calculate High, Low and Close values
                dayNow += TimeSpan.FromDays( (float)day );
                high = chart1.Series["PriceSeries"].Points[day - 1].YValues[2] + rand.NextDouble();
                close = high - rand.NextDouble();
                low = close - rand.NextDouble();
                open = ( high - low ) * rand.NextDouble() + low;


                // Calculate volume
                volume = chart1.Series["VolumeSeries"].Points[day - 1].YValues[0] + 10 * rand.NextDouble() - 5;

                // The low cannot be less than yesterday close value.
                if ( low > chart1.Series["PriceSeries"].Points[day - 1].YValues[2] )
                    low = chart1.Series["PriceSeries"].Points[day - 1].YValues[2];

                // Set data points values
                chart1.Series["PriceSeries"].Points.AddXY( dayNow, high );
                chart1.Series["PriceSeries"].Points[day].XValue = chart1.Series["PriceSeries"].Points[day - 1].XValue + 1;
                chart1.Series["PriceSeries"].Points[day].YValues[1] = low;
                chart1.Series["PriceSeries"].Points[day].YValues[2] = open;
                chart1.Series["PriceSeries"].Points[day].YValues[3] = close;

                //chart1.Series["Price"].Points[day].XValue = chart1.Series["Price"].Points[day - 1].XValue + 1;
                //chart1.Series["Price"].Points[day].YValues[1] = low;
                //chart1.Series["Price"].Points[day].YValues[2] = open;
                //chart1.Series["Price"].Points[day].YValues[3] = open + 3;

                if ( fff == false )
                {
                    chart1.Series["PriceSeries"].Points[day].Color = Color.Green;
                    chart1.Series["PriceSeries"].Points[day].BackGradientEndColor = Color.White;
                    chart1.Series["PriceSeries"].Points[day].BackGradientType = GradientType.VerticalCenter;

                    chart1.Series["PriceSeries"].Points[day].BorderWidth = 1;
                    chart1.Series["PriceSeries"].Points[day].BorderColor = Color.Green;
                    chart1.Series["PriceSeries"].Points[day].BorderStyle = ChartDashStyle.Solid;

                    //chart1.Series["Price"].Points[day].

                    fff = true;
                }
                else
                {
                    chart1.Series["PriceSeries"].Points[day].Color = Color.Red;
                    chart1.Series["PriceSeries"].Points[day].BackGradientEndColor = Color.White;
                    chart1.Series["PriceSeries"].Points[day].BackGradientType = GradientType.VerticalCenter;

                    chart1.Series["PriceSeries"].Points[day].BorderWidth = 1;
                    chart1.Series["PriceSeries"].Points[day].BorderColor = Color.Red;
                    chart1.Series["PriceSeries"].Points[day].BorderStyle = ChartDashStyle.Solid;
                }

                // Set volume values
                chart1.Series["VolumeSeries"].Points.AddXY( dayNow, volume );
                chart1.Series["VolumeSeries"].Points[day].XValue = chart1.Series["VolumeSeries"].Points[day - 1].XValue + 1;
                //chart1.Series["Volume"].BorderColor
                if ( ddd == false )
                {
                    chart1.Series["VolumeSeries"].Points[day].Color = Color.Green;
                    chart1.Series["VolumeSeries"].Points[day].BackGradientEndColor = Color.White;
                    chart1.Series["VolumeSeries"].Points[day].BackGradientType = GradientType.VerticalCenter;

                    chart1.Series["VolumeSeries"].Points[day].BorderColor = Color.Green;
                    ddd = true;
                }
                else
                {
                    chart1.Series["VolumeSeries"].Points[day].Color = Color.Red;
                    chart1.Series["VolumeSeries"].Points[day].BackGradientEndColor = Color.White;
                    chart1.Series["VolumeSeries"].Points[day].BackGradientType = GradientType.VerticalCenter;

                    chart1.Series["VolumeSeries"].Points[day].BorderColor = Color.Red;
                }

                //// Set volume values
                //chart1.Series["VolumeAtPriceSeries"].Points.AddXY( dayNow, volume );
                //chart1.Series["VolumeAtPriceSeries"].Points[day].XValue = chart1.Series["VolumeSeries"].Points[day - 1].XValue + 1;
                ////chart1.Series["Volume"].BorderColor
                //if ( ddd == false )
                //{
                //    chart1.Series["VolumeAtPriceSeries"].Points[day].Color = Color.Green;
                //    chart1.Series["VolumeAtPriceSeries"].Points[day].BackGradientEndColor = Color.White;
                //    chart1.Series["VolumeAtPriceSeries"].Points[day].BackGradientType = GradientType.VerticalCenter;

                //    chart1.Series["VolumeAtPriceSeries"].Points[day].BorderColor = Color.Green;
                //    ddd = true;
                //}
                //else
                //{
                //    chart1.Series["VolumeAtPriceSeries"].Points[day].Color = Color.Red;
                //    chart1.Series["VolumeAtPriceSeries"].Points[day].BackGradientEndColor = Color.White;
                //    chart1.Series["VolumeAtPriceSeries"].Points[day].BackGradientType = GradientType.VerticalCenter;

                //    chart1.Series["VolumeAtPriceSeries"].Points[day].BorderColor = Color.Red;
                //}

            }
        }
    }
}
