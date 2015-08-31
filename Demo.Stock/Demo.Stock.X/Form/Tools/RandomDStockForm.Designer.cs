namespace Demo.Stock.X.Tools
{
    partial class RandomDStockForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( RandomDStockForm ) );
            this.ButtonFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.NumericUpDownLowOpenPrice = new System.Windows.Forms.NumericUpDown();
            this.NumericUpDownLowClosePrice = new System.Windows.Forms.NumericUpDown();
            this.NumericUpDownLowHighestPrice = new System.Windows.Forms.NumericUpDown();
            this.NumericUpDownLowDailyTurnover = new System.Windows.Forms.NumericUpDown();
            this.NumericUpDownLowDailyAmount = new System.Windows.Forms.NumericUpDown();
            this.NumericUpDownHighOpenPrice = new System.Windows.Forms.NumericUpDown();
            this.NumericUpDownHighClosePrice = new System.Windows.Forms.NumericUpDown();
            this.NumericUpDownHighHighestPrice = new System.Windows.Forms.NumericUpDown();
            this.NumericUpDown1HighDailyTurnover = new System.Windows.Forms.NumericUpDown();
            this.NumericUpDownHighDailyAmount = new System.Windows.Forms.NumericUpDown();
            this.NumericUpDownFileCount = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.RichTextBoxCode = new System.Windows.Forms.RichTextBox();
            this.RichTextBoxName = new System.Windows.Forms.RichTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.DateTimePickerLowTradingTime = new System.Windows.Forms.DateTimePicker();
            this.DateTimePickerHighTradingTime = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.ButtonFolder = new System.Windows.Forms.Button();
            this.TextBoxFolder = new System.Windows.Forms.TextBox();
            this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.NumericUpDownHighMinimumPrice = new System.Windows.Forms.NumericUpDown();
            this.NumericUpDownLowMinimumPrice = new System.Windows.Forms.NumericUpDown();
            ( (System.ComponentModel.ISupportInitialize)( this.NumericUpDownLowOpenPrice ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.NumericUpDownLowClosePrice ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.NumericUpDownLowHighestPrice ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.NumericUpDownLowDailyTurnover ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.NumericUpDownLowDailyAmount ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.NumericUpDownHighOpenPrice ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.NumericUpDownHighClosePrice ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.NumericUpDownHighHighestPrice ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.NumericUpDown1HighDailyTurnover ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.NumericUpDownHighDailyAmount ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.NumericUpDownFileCount ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.NumericUpDownHighMinimumPrice ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.NumericUpDownLowMinimumPrice ) ).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonFile
            // 
            this.ButtonFile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonFile.Location = new System.Drawing.Point( 373, 504 );
            this.ButtonFile.Name = "ButtonFile";
            this.ButtonFile.Size = new System.Drawing.Size( 119, 27 );
            this.ButtonFile.TabIndex = 0;
            this.ButtonFile.Text = "DStock文件产生";
            this.ButtonFile.UseVisualStyleBackColor = true;
            this.ButtonFile.Click += new System.EventHandler( this.ButtonFile_Click );
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Location = new System.Drawing.Point( 253, 46 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 101, 12 );
            this.label1.TabIndex = 1;
            this.label1.Text = "随机最高的开盘价";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Location = new System.Drawing.Point( 253, 83 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 101, 12 );
            this.label2.TabIndex = 1;
            this.label2.Text = "随机最高的收盘价";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Location = new System.Drawing.Point( 12, 83 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 101, 12 );
            this.label3.TabIndex = 1;
            this.label3.Text = "随机最低的收盘价";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Location = new System.Drawing.Point( 12, 120 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 101, 12 );
            this.label4.TabIndex = 1;
            this.label4.Text = "随机最低的最高价";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Location = new System.Drawing.Point( 253, 194 );
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size( 101, 12 );
            this.label5.TabIndex = 1;
            this.label5.Text = "随机最高的成交量";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label6.Location = new System.Drawing.Point( 253, 231 );
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size( 113, 12 );
            this.label6.TabIndex = 1;
            this.label6.Text = "随机最高的成交金额";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label7.Location = new System.Drawing.Point( 12, 9 );
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size( 89, 12 );
            this.label7.TabIndex = 1;
            this.label7.Text = "随机开始的日期";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label8.Location = new System.Drawing.Point( 12, 46 );
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size( 101, 12 );
            this.label8.TabIndex = 1;
            this.label8.Text = "随机最低的开盘价";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label9.Location = new System.Drawing.Point( 253, 120 );
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size( 101, 12 );
            this.label9.TabIndex = 1;
            this.label9.Text = "随机最高的最高价";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label10.Location = new System.Drawing.Point( 12, 194 );
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size( 101, 12 );
            this.label10.TabIndex = 1;
            this.label10.Text = "随机最低的成交量";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label11.Location = new System.Drawing.Point( 12, 231 );
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size( 113, 12 );
            this.label11.TabIndex = 1;
            this.label11.Text = "随机最低的成交金额";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label12.Location = new System.Drawing.Point( 253, 9 );
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size( 89, 12 );
            this.label12.TabIndex = 1;
            this.label12.Text = "随机结束的日期";
            // 
            // NumericUpDownLowOpenPrice
            // 
            this.NumericUpDownLowOpenPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumericUpDownLowOpenPrice.Location = new System.Drawing.Point( 131, 40 );
            this.NumericUpDownLowOpenPrice.Maximum = new decimal( new int[] {
            100000,
            0,
            0,
            0} );
            this.NumericUpDownLowOpenPrice.Name = "NumericUpDownLowOpenPrice";
            this.NumericUpDownLowOpenPrice.Size = new System.Drawing.Size( 60, 21 );
            this.NumericUpDownLowOpenPrice.TabIndex = 2;
            this.NumericUpDownLowOpenPrice.ValueChanged += new System.EventHandler( this.NumericUpDownLowOpenPrice_ValueChanged );
            // 
            // NumericUpDownLowClosePrice
            // 
            this.NumericUpDownLowClosePrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumericUpDownLowClosePrice.Location = new System.Drawing.Point( 131, 77 );
            this.NumericUpDownLowClosePrice.Maximum = new decimal( new int[] {
            100000,
            0,
            0,
            0} );
            this.NumericUpDownLowClosePrice.Name = "NumericUpDownLowClosePrice";
            this.NumericUpDownLowClosePrice.Size = new System.Drawing.Size( 60, 21 );
            this.NumericUpDownLowClosePrice.TabIndex = 2;
            this.NumericUpDownLowClosePrice.ValueChanged += new System.EventHandler( this.NumericUpDownLowClosePrice_ValueChanged );
            // 
            // NumericUpDownLowHighestPrice
            // 
            this.NumericUpDownLowHighestPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumericUpDownLowHighestPrice.Location = new System.Drawing.Point( 131, 114 );
            this.NumericUpDownLowHighestPrice.Maximum = new decimal( new int[] {
            100000,
            0,
            0,
            0} );
            this.NumericUpDownLowHighestPrice.Name = "NumericUpDownLowHighestPrice";
            this.NumericUpDownLowHighestPrice.Size = new System.Drawing.Size( 60, 21 );
            this.NumericUpDownLowHighestPrice.TabIndex = 2;
            this.NumericUpDownLowHighestPrice.ValueChanged += new System.EventHandler( this.NumericUpDownLowHighestPrice_ValueChanged );
            // 
            // NumericUpDownLowDailyTurnover
            // 
            this.NumericUpDownLowDailyTurnover.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumericUpDownLowDailyTurnover.Location = new System.Drawing.Point( 131, 188 );
            this.NumericUpDownLowDailyTurnover.Maximum = new decimal( new int[] {
            100000000,
            0,
            0,
            0} );
            this.NumericUpDownLowDailyTurnover.Name = "NumericUpDownLowDailyTurnover";
            this.NumericUpDownLowDailyTurnover.Size = new System.Drawing.Size( 60, 21 );
            this.NumericUpDownLowDailyTurnover.TabIndex = 2;
            this.NumericUpDownLowDailyTurnover.ValueChanged += new System.EventHandler( this.NumericUpDownLowDailyTurnover_ValueChanged );
            // 
            // NumericUpDownLowDailyAmount
            // 
            this.NumericUpDownLowDailyAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumericUpDownLowDailyAmount.Location = new System.Drawing.Point( 131, 225 );
            this.NumericUpDownLowDailyAmount.Maximum = new decimal( new int[] {
            100000000,
            0,
            0,
            0} );
            this.NumericUpDownLowDailyAmount.Name = "NumericUpDownLowDailyAmount";
            this.NumericUpDownLowDailyAmount.Size = new System.Drawing.Size( 76, 21 );
            this.NumericUpDownLowDailyAmount.TabIndex = 2;
            this.NumericUpDownLowDailyAmount.ValueChanged += new System.EventHandler( this.NumericUpDownLowDailyAmount_ValueChanged );
            // 
            // NumericUpDownHighOpenPrice
            // 
            this.NumericUpDownHighOpenPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumericUpDownHighOpenPrice.Location = new System.Drawing.Point( 376, 40 );
            this.NumericUpDownHighOpenPrice.Maximum = new decimal( new int[] {
            100000,
            0,
            0,
            0} );
            this.NumericUpDownHighOpenPrice.Name = "NumericUpDownHighOpenPrice";
            this.NumericUpDownHighOpenPrice.Size = new System.Drawing.Size( 60, 21 );
            this.NumericUpDownHighOpenPrice.TabIndex = 2;
            this.NumericUpDownHighOpenPrice.ValueChanged += new System.EventHandler( this.NumericUpDownHighOpenPrice_ValueChanged );
            // 
            // NumericUpDownHighClosePrice
            // 
            this.NumericUpDownHighClosePrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumericUpDownHighClosePrice.Location = new System.Drawing.Point( 376, 77 );
            this.NumericUpDownHighClosePrice.Maximum = new decimal( new int[] {
            100000,
            0,
            0,
            0} );
            this.NumericUpDownHighClosePrice.Name = "NumericUpDownHighClosePrice";
            this.NumericUpDownHighClosePrice.Size = new System.Drawing.Size( 60, 21 );
            this.NumericUpDownHighClosePrice.TabIndex = 2;
            this.NumericUpDownHighClosePrice.ValueChanged += new System.EventHandler( this.NumericUpDownHighClosePrice_ValueChanged );
            // 
            // NumericUpDownHighHighestPrice
            // 
            this.NumericUpDownHighHighestPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumericUpDownHighHighestPrice.Location = new System.Drawing.Point( 376, 114 );
            this.NumericUpDownHighHighestPrice.Maximum = new decimal( new int[] {
            100000,
            0,
            0,
            0} );
            this.NumericUpDownHighHighestPrice.Name = "NumericUpDownHighHighestPrice";
            this.NumericUpDownHighHighestPrice.Size = new System.Drawing.Size( 60, 21 );
            this.NumericUpDownHighHighestPrice.TabIndex = 2;
            this.NumericUpDownHighHighestPrice.ValueChanged += new System.EventHandler( this.NumericUpDownHighHighestPrice_ValueChanged );
            // 
            // NumericUpDown1HighDailyTurnover
            // 
            this.NumericUpDown1HighDailyTurnover.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumericUpDown1HighDailyTurnover.Location = new System.Drawing.Point( 376, 188 );
            this.NumericUpDown1HighDailyTurnover.Maximum = new decimal( new int[] {
            100000000,
            0,
            0,
            0} );
            this.NumericUpDown1HighDailyTurnover.Name = "NumericUpDown1HighDailyTurnover";
            this.NumericUpDown1HighDailyTurnover.Size = new System.Drawing.Size( 60, 21 );
            this.NumericUpDown1HighDailyTurnover.TabIndex = 2;
            this.NumericUpDown1HighDailyTurnover.ValueChanged += new System.EventHandler( this.NumericUpDown1HighDailyTurnover_ValueChanged );
            // 
            // NumericUpDownHighDailyAmount
            // 
            this.NumericUpDownHighDailyAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumericUpDownHighDailyAmount.Location = new System.Drawing.Point( 376, 225 );
            this.NumericUpDownHighDailyAmount.Maximum = new decimal( new int[] {
            100000000,
            0,
            0,
            0} );
            this.NumericUpDownHighDailyAmount.Name = "NumericUpDownHighDailyAmount";
            this.NumericUpDownHighDailyAmount.Size = new System.Drawing.Size( 78, 21 );
            this.NumericUpDownHighDailyAmount.TabIndex = 2;
            this.NumericUpDownHighDailyAmount.ValueChanged += new System.EventHandler( this.NumericUpDownHighDailyAmount_ValueChanged );
            // 
            // NumericUpDownFileCount
            // 
            this.NumericUpDownFileCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumericUpDownFileCount.Location = new System.Drawing.Point( 129, 293 );
            this.NumericUpDownFileCount.Name = "NumericUpDownFileCount";
            this.NumericUpDownFileCount.Size = new System.Drawing.Size( 60, 21 );
            this.NumericUpDownFileCount.TabIndex = 2;
            this.NumericUpDownFileCount.ValueChanged += new System.EventHandler( this.NumericUpDownFileCount_ValueChanged );
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label13.Location = new System.Drawing.Point( 12, 295 );
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size( 113, 12 );
            this.label13.TabIndex = 1;
            this.label13.Text = "随机文件产生的数量";
            // 
            // RichTextBoxCode
            // 
            this.RichTextBoxCode.Location = new System.Drawing.Point( 12, 346 );
            this.RichTextBoxCode.Name = "RichTextBoxCode";
            this.RichTextBoxCode.Size = new System.Drawing.Size( 482, 62 );
            this.RichTextBoxCode.TabIndex = 3;
            this.RichTextBoxCode.Text = "123456789ABCDEFGHIJKLNMOPQRSTUVWXYZ";
            // 
            // RichTextBoxName
            // 
            this.RichTextBoxName.Location = new System.Drawing.Point( 12, 426 );
            this.RichTextBoxName.Name = "RichTextBoxName";
            this.RichTextBoxName.Size = new System.Drawing.Size( 480, 72 );
            this.RichTextBoxName.TabIndex = 3;
            this.RichTextBoxName.Text = "色人气旺任务热腾鬼斧神工的却仍然让他认识发考虑是否看健康绿色房间金属肌肉阴阳肚街霸最终魔王现身新世纪福音战士钢铁女友威力增强版画面停止问题";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label14.Location = new System.Drawing.Point( 12, 331 );
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size( 137, 12 );
            this.label14.TabIndex = 1;
            this.label14.Text = "随机产生的股票代码数据";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label15.Location = new System.Drawing.Point( 12, 411 );
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size( 137, 12 );
            this.label15.TabIndex = 1;
            this.label15.Text = "随机产生的股票代码名称";
            // 
            // DateTimePickerLowTradingTime
            // 
            this.DateTimePickerLowTradingTime.Location = new System.Drawing.Point( 131, 3 );
            this.DateTimePickerLowTradingTime.Name = "DateTimePickerLowTradingTime";
            this.DateTimePickerLowTradingTime.Size = new System.Drawing.Size( 116, 21 );
            this.DateTimePickerLowTradingTime.TabIndex = 4;
            this.DateTimePickerLowTradingTime.ValueChanged += new System.EventHandler( this.DateTimePickerLowTradingTime_ValueChanged );
            // 
            // DateTimePickerHighTradingTime
            // 
            this.DateTimePickerHighTradingTime.Location = new System.Drawing.Point( 376, 3 );
            this.DateTimePickerHighTradingTime.Name = "DateTimePickerHighTradingTime";
            this.DateTimePickerHighTradingTime.Size = new System.Drawing.Size( 116, 21 );
            this.DateTimePickerHighTradingTime.TabIndex = 4;
            this.DateTimePickerHighTradingTime.ValueChanged += new System.EventHandler( this.DateTimePickerHighTradingTime_ValueChanged );
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label16.Location = new System.Drawing.Point( 12, 261 );
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size( 113, 12 );
            this.label16.TabIndex = 1;
            this.label16.Text = "随机文件产生的目录";
            // 
            // ButtonFolder
            // 
            this.ButtonFolder.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonFolder.Location = new System.Drawing.Point( 417, 258 );
            this.ButtonFolder.Name = "ButtonFolder";
            this.ButtonFolder.Size = new System.Drawing.Size( 75, 23 );
            this.ButtonFolder.TabIndex = 5;
            this.ButtonFolder.Text = "选择目录";
            this.ButtonFolder.UseVisualStyleBackColor = true;
            this.ButtonFolder.Click += new System.EventHandler( this.ButtonFolder_Click );
            // 
            // TextBoxFolder
            // 
            this.TextBoxFolder.Location = new System.Drawing.Point( 129, 258 );
            this.TextBoxFolder.Name = "TextBoxFolder";
            this.TextBoxFolder.Size = new System.Drawing.Size( 282, 21 );
            this.TextBoxFolder.TabIndex = 6;
            this.TextBoxFolder.Text = "C:\\";
            // 
            // FolderBrowserDialog
            // 
            this.FolderBrowserDialog.Description = "选择你需要存储的DStock的目录";
            this.FolderBrowserDialog.SelectedPath = "C:\\";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label17.Location = new System.Drawing.Point( 12, 157 );
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size( 101, 12 );
            this.label17.TabIndex = 1;
            this.label17.Text = "随机最低的最低价";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label18.Location = new System.Drawing.Point( 253, 157 );
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size( 101, 12 );
            this.label18.TabIndex = 1;
            this.label18.Text = "随机最高的最低价";
            // 
            // NumericUpDownHighMinimumPrice
            // 
            this.NumericUpDownHighMinimumPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumericUpDownHighMinimumPrice.Location = new System.Drawing.Point( 376, 151 );
            this.NumericUpDownHighMinimumPrice.Maximum = new decimal( new int[] {
            100000,
            0,
            0,
            0} );
            this.NumericUpDownHighMinimumPrice.Name = "NumericUpDownHighMinimumPrice";
            this.NumericUpDownHighMinimumPrice.Size = new System.Drawing.Size( 60, 21 );
            this.NumericUpDownHighMinimumPrice.TabIndex = 2;
            this.NumericUpDownHighMinimumPrice.ValueChanged += new System.EventHandler( this.NumericUpDownHighMinimumPrice_ValueChanged );
            // 
            // NumericUpDownLowMinimumPrice
            // 
            this.NumericUpDownLowMinimumPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumericUpDownLowMinimumPrice.Location = new System.Drawing.Point( 131, 151 );
            this.NumericUpDownLowMinimumPrice.Maximum = new decimal( new int[] {
            100000,
            0,
            0,
            0} );
            this.NumericUpDownLowMinimumPrice.Name = "NumericUpDownLowMinimumPrice";
            this.NumericUpDownLowMinimumPrice.Size = new System.Drawing.Size( 60, 21 );
            this.NumericUpDownLowMinimumPrice.TabIndex = 2;
            this.NumericUpDownLowMinimumPrice.ValueChanged += new System.EventHandler( this.NumericUpDownLowMinimumPrice_ValueChanged );
            // 
            // RandomDStockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 834, 538 );
            this.Controls.Add( this.TextBoxFolder );
            this.Controls.Add( this.ButtonFolder );
            this.Controls.Add( this.DateTimePickerHighTradingTime );
            this.Controls.Add( this.DateTimePickerLowTradingTime );
            this.Controls.Add( this.RichTextBoxName );
            this.Controls.Add( this.RichTextBoxCode );
            this.Controls.Add( this.NumericUpDownFileCount );
            this.Controls.Add( this.NumericUpDownLowDailyAmount );
            this.Controls.Add( this.NumericUpDownLowDailyTurnover );
            this.Controls.Add( this.NumericUpDownLowMinimumPrice );
            this.Controls.Add( this.NumericUpDownLowHighestPrice );
            this.Controls.Add( this.NumericUpDownLowClosePrice );
            this.Controls.Add( this.NumericUpDownHighDailyAmount );
            this.Controls.Add( this.NumericUpDown1HighDailyTurnover );
            this.Controls.Add( this.NumericUpDownHighMinimumPrice );
            this.Controls.Add( this.NumericUpDownHighHighestPrice );
            this.Controls.Add( this.NumericUpDownHighClosePrice );
            this.Controls.Add( this.NumericUpDownHighOpenPrice );
            this.Controls.Add( this.NumericUpDownLowOpenPrice );
            this.Controls.Add( this.label11 );
            this.Controls.Add( this.label16 );
            this.Controls.Add( this.label15 );
            this.Controls.Add( this.label14 );
            this.Controls.Add( this.label13 );
            this.Controls.Add( this.label6 );
            this.Controls.Add( this.label10 );
            this.Controls.Add( this.label5 );
            this.Controls.Add( this.label3 );
            this.Controls.Add( this.label18 );
            this.Controls.Add( this.label9 );
            this.Controls.Add( this.label17 );
            this.Controls.Add( this.label4 );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.label12 );
            this.Controls.Add( this.label7 );
            this.Controls.Add( this.label8 );
            this.Controls.Add( this.label1 );
            this.Controls.Add( this.ButtonFile );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RandomDStockForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "随机产生DStock文件";
            this.Load += new System.EventHandler( this.RandomDStockForm_Load );
            ( (System.ComponentModel.ISupportInitialize)( this.NumericUpDownLowOpenPrice ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.NumericUpDownLowClosePrice ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.NumericUpDownLowHighestPrice ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.NumericUpDownLowDailyTurnover ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.NumericUpDownLowDailyAmount ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.NumericUpDownHighOpenPrice ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.NumericUpDownHighClosePrice ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.NumericUpDownHighHighestPrice ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.NumericUpDown1HighDailyTurnover ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.NumericUpDownHighDailyAmount ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.NumericUpDownFileCount ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.NumericUpDownHighMinimumPrice ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.NumericUpDownLowMinimumPrice ) ).EndInit();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown NumericUpDownLowOpenPrice;
        private System.Windows.Forms.NumericUpDown NumericUpDownLowClosePrice;
        private System.Windows.Forms.NumericUpDown NumericUpDownLowHighestPrice;
        private System.Windows.Forms.NumericUpDown NumericUpDownLowDailyTurnover;
        private System.Windows.Forms.NumericUpDown NumericUpDownLowDailyAmount;
        private System.Windows.Forms.NumericUpDown NumericUpDownHighOpenPrice;
        private System.Windows.Forms.NumericUpDown NumericUpDownHighClosePrice;
        private System.Windows.Forms.NumericUpDown NumericUpDownHighHighestPrice;
        private System.Windows.Forms.NumericUpDown NumericUpDown1HighDailyTurnover;
        private System.Windows.Forms.NumericUpDown NumericUpDownHighDailyAmount;
        private System.Windows.Forms.NumericUpDown NumericUpDownFileCount;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RichTextBox RichTextBoxCode;
        private System.Windows.Forms.RichTextBox RichTextBoxName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker DateTimePickerLowTradingTime;
        private System.Windows.Forms.DateTimePicker DateTimePickerHighTradingTime;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button ButtonFolder;
        private System.Windows.Forms.TextBox TextBoxFolder;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown NumericUpDownHighMinimumPrice;
        private System.Windows.Forms.NumericUpDown NumericUpDownLowMinimumPrice;
    }
}