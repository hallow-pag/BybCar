namespace ChildCar_Pro
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.gb_SerialPort = new System.Windows.Forms.GroupBox();
            this.b_OpenSerialPort = new System.Windows.Forms.Button();
            this.cb_SerialPort = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gb_SerialPort_ResiveAndSend = new System.Windows.Forms.GroupBox();
            this.l_hum = new System.Windows.Forms.Label();
            this.l_tem = new System.Windows.Forms.Label();
            this.l_l = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gb_Mysql = new System.Windows.Forms.GroupBox();
            this.b_Teach = new System.Windows.Forms.Button();
            this.gb_Car = new System.Windows.Forms.GroupBox();
            this.tb_test = new System.Windows.Forms.TextBox();
            this.b_VoiceW = new System.Windows.Forms.Button();
            this.b_Zd_Awning = new System.Windows.Forms.Button();
            this.b_Balance = new System.Windows.Forms.Button();
            this.b_MusicPlay = new System.Windows.Forms.Button();
            this.b_Awning = new System.Windows.Forms.Button();
            this.b_CarShake = new System.Windows.Forms.Button();
            this.CT1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sleeproom = new System.Windows.Forms.Button();
            this.inroom = new System.Windows.Forms.Button();
            this.outroom = new System.Windows.Forms.Button();
            this.gb_SerialPort.SuspendLayout();
            this.gb_SerialPort_ResiveAndSend.SuspendLayout();
            this.gb_Mysql.SuspendLayout();
            this.gb_Car.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CT1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_SerialPort
            // 
            this.gb_SerialPort.BackColor = System.Drawing.Color.Transparent;
            this.gb_SerialPort.Controls.Add(this.b_OpenSerialPort);
            this.gb_SerialPort.Controls.Add(this.cb_SerialPort);
            this.gb_SerialPort.Controls.Add(this.label1);
            this.gb_SerialPort.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gb_SerialPort.Location = new System.Drawing.Point(12, 12);
            this.gb_SerialPort.Name = "gb_SerialPort";
            this.gb_SerialPort.Size = new System.Drawing.Size(512, 65);
            this.gb_SerialPort.TabIndex = 0;
            this.gb_SerialPort.TabStop = false;
            this.gb_SerialPort.Text = "串口";
            // 
            // b_OpenSerialPort
            // 
            this.b_OpenSerialPort.BackColor = System.Drawing.Color.Transparent;
            this.b_OpenSerialPort.FlatAppearance.BorderSize = 0;
            this.b_OpenSerialPort.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_OpenSerialPort.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.b_OpenSerialPort.Location = new System.Drawing.Point(349, 19);
            this.b_OpenSerialPort.Name = "b_OpenSerialPort";
            this.b_OpenSerialPort.Size = new System.Drawing.Size(121, 36);
            this.b_OpenSerialPort.TabIndex = 2;
            this.b_OpenSerialPort.Text = "打开串口";
            this.b_OpenSerialPort.UseVisualStyleBackColor = false;
            this.b_OpenSerialPort.Click += new System.EventHandler(this.B_OpenSerialPort_Click);
            // 
            // cb_SerialPort
            // 
            this.cb_SerialPort.FormattingEnabled = true;
            this.cb_SerialPort.Location = new System.Drawing.Point(179, 24);
            this.cb_SerialPort.Name = "cb_SerialPort";
            this.cb_SerialPort.Size = new System.Drawing.Size(121, 28);
            this.cb_SerialPort.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "串口号";
            // 
            // gb_SerialPort_ResiveAndSend
            // 
            this.gb_SerialPort_ResiveAndSend.BackColor = System.Drawing.Color.Transparent;
            this.gb_SerialPort_ResiveAndSend.Controls.Add(this.l_hum);
            this.gb_SerialPort_ResiveAndSend.Controls.Add(this.l_tem);
            this.gb_SerialPort_ResiveAndSend.Controls.Add(this.l_l);
            this.gb_SerialPort_ResiveAndSend.Controls.Add(this.label2);
            this.gb_SerialPort_ResiveAndSend.Controls.Add(this.label4);
            this.gb_SerialPort_ResiveAndSend.Controls.Add(this.label3);
            this.gb_SerialPort_ResiveAndSend.Font = new System.Drawing.Font("宋体", 12F);
            this.gb_SerialPort_ResiveAndSend.Location = new System.Drawing.Point(12, 83);
            this.gb_SerialPort_ResiveAndSend.Name = "gb_SerialPort_ResiveAndSend";
            this.gb_SerialPort_ResiveAndSend.Size = new System.Drawing.Size(512, 178);
            this.gb_SerialPort_ResiveAndSend.TabIndex = 3;
            this.gb_SerialPort_ResiveAndSend.TabStop = false;
            this.gb_SerialPort_ResiveAndSend.Text = "串口数据收发";
            // 
            // l_hum
            // 
            this.l_hum.AutoSize = true;
            this.l_hum.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_hum.Location = new System.Drawing.Point(242, 92);
            this.l_hum.Name = "l_hum";
            this.l_hum.Size = new System.Drawing.Size(34, 24);
            this.l_hum.TabIndex = 10;
            this.l_hum.Text = "无";
            // 
            // l_tem
            // 
            this.l_tem.AutoSize = true;
            this.l_tem.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_tem.Location = new System.Drawing.Point(100, 92);
            this.l_tem.Name = "l_tem";
            this.l_tem.Size = new System.Drawing.Size(34, 24);
            this.l_tem.TabIndex = 9;
            this.l_tem.Text = "无";
            // 
            // l_l
            // 
            this.l_l.AutoSize = true;
            this.l_l.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_l.Location = new System.Drawing.Point(397, 92);
            this.l_l.Name = "l_l";
            this.l_l.Size = new System.Drawing.Size(34, 24);
            this.l_l.TabIndex = 8;
            this.l_l.Text = "无";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(396, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "光照";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(242, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = "湿度";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(100, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "温度";
            // 
            // gb_Mysql
            // 
            this.gb_Mysql.BackColor = System.Drawing.Color.Transparent;
            this.gb_Mysql.Controls.Add(this.b_Teach);
            this.gb_Mysql.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gb_Mysql.Location = new System.Drawing.Point(12, 272);
            this.gb_Mysql.Name = "gb_Mysql";
            this.gb_Mysql.Size = new System.Drawing.Size(276, 85);
            this.gb_Mysql.TabIndex = 6;
            this.gb_Mysql.TabStop = false;
            this.gb_Mysql.Text = "早教系统";
            // 
            // b_Teach
            // 
            this.b_Teach.FlatAppearance.BorderSize = 0;
            this.b_Teach.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_Teach.Location = new System.Drawing.Point(93, 29);
            this.b_Teach.Name = "b_Teach";
            this.b_Teach.Size = new System.Drawing.Size(107, 37);
            this.b_Teach.TabIndex = 6;
            this.b_Teach.Text = "早教";
            this.b_Teach.UseVisualStyleBackColor = true;
            this.b_Teach.Click += new System.EventHandler(this.B_Teach_Click);
            // 
            // gb_Car
            // 
            this.gb_Car.BackColor = System.Drawing.Color.Transparent;
            this.gb_Car.Controls.Add(this.tb_test);
            this.gb_Car.Controls.Add(this.b_VoiceW);
            this.gb_Car.Controls.Add(this.b_Zd_Awning);
            this.gb_Car.Controls.Add(this.b_Balance);
            this.gb_Car.Controls.Add(this.b_MusicPlay);
            this.gb_Car.Controls.Add(this.b_Awning);
            this.gb_Car.Controls.Add(this.b_CarShake);
            this.gb_Car.Font = new System.Drawing.Font("宋体", 12F);
            this.gb_Car.Location = new System.Drawing.Point(539, 12);
            this.gb_Car.Name = "gb_Car";
            this.gb_Car.Size = new System.Drawing.Size(336, 249);
            this.gb_Car.TabIndex = 7;
            this.gb_Car.TabStop = false;
            this.gb_Car.Text = "用户操作";
            this.gb_Car.Enter += new System.EventHandler(this.gb_Car_Enter);
            // 
            // tb_test
            // 
            this.tb_test.Location = new System.Drawing.Point(36, 204);
            this.tb_test.Name = "tb_test";
            this.tb_test.Size = new System.Drawing.Size(253, 30);
            this.tb_test.TabIndex = 6;
            // 
            // b_VoiceW
            // 
            this.b_VoiceW.FlatAppearance.BorderSize = 0;
            this.b_VoiceW.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_VoiceW.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.b_VoiceW.Location = new System.Drawing.Point(181, 150);
            this.b_VoiceW.Name = "b_VoiceW";
            this.b_VoiceW.Size = new System.Drawing.Size(149, 34);
            this.b_VoiceW.TabIndex = 5;
            this.b_VoiceW.Text = "开启语音提示";
            this.b_VoiceW.UseVisualStyleBackColor = true;
            this.b_VoiceW.Click += new System.EventHandler(this.B_VoiceW_Click);
            // 
            // b_Zd_Awning
            // 
            this.b_Zd_Awning.FlatAppearance.BorderSize = 0;
            this.b_Zd_Awning.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_Zd_Awning.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.b_Zd_Awning.Location = new System.Drawing.Point(18, 89);
            this.b_Zd_Awning.Name = "b_Zd_Awning";
            this.b_Zd_Awning.Size = new System.Drawing.Size(157, 34);
            this.b_Zd_Awning.TabIndex = 4;
            this.b_Zd_Awning.Text = "自动开关遮光蓬";
            this.b_Zd_Awning.UseVisualStyleBackColor = true;
            this.b_Zd_Awning.Click += new System.EventHandler(this.B_Zd_Awning_Click);
            // 
            // b_Balance
            // 
            this.b_Balance.FlatAppearance.BorderSize = 0;
            this.b_Balance.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_Balance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.b_Balance.Location = new System.Drawing.Point(181, 31);
            this.b_Balance.Name = "b_Balance";
            this.b_Balance.Size = new System.Drawing.Size(149, 34);
            this.b_Balance.TabIndex = 3;
            this.b_Balance.Text = "开启平衡模式";
            this.b_Balance.UseVisualStyleBackColor = true;
            this.b_Balance.Click += new System.EventHandler(this.B_Balance_Click);
            // 
            // b_MusicPlay
            // 
            this.b_MusicPlay.FlatAppearance.BorderSize = 0;
            this.b_MusicPlay.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_MusicPlay.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.b_MusicPlay.Location = new System.Drawing.Point(18, 150);
            this.b_MusicPlay.Name = "b_MusicPlay";
            this.b_MusicPlay.Size = new System.Drawing.Size(157, 34);
            this.b_MusicPlay.TabIndex = 2;
            this.b_MusicPlay.Text = "播放音乐";
            this.b_MusicPlay.UseVisualStyleBackColor = true;
            this.b_MusicPlay.Click += new System.EventHandler(this.B_MusicPlay_Click);
            // 
            // b_Awning
            // 
            this.b_Awning.FlatAppearance.BorderSize = 0;
            this.b_Awning.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_Awning.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.b_Awning.Location = new System.Drawing.Point(181, 89);
            this.b_Awning.Name = "b_Awning";
            this.b_Awning.Size = new System.Drawing.Size(149, 34);
            this.b_Awning.TabIndex = 1;
            this.b_Awning.Text = "关闭遮光蓬";
            this.b_Awning.UseVisualStyleBackColor = true;
            this.b_Awning.Click += new System.EventHandler(this.B_Awning_Click);
            // 
            // b_CarShake
            // 
            this.b_CarShake.BackColor = System.Drawing.Color.Transparent;
            this.b_CarShake.FlatAppearance.BorderSize = 0;
            this.b_CarShake.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_CarShake.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.b_CarShake.Location = new System.Drawing.Point(18, 31);
            this.b_CarShake.Name = "b_CarShake";
            this.b_CarShake.Size = new System.Drawing.Size(157, 34);
            this.b_CarShake.TabIndex = 0;
            this.b_CarShake.Text = "开启摇床模式";
            this.b_CarShake.UseVisualStyleBackColor = false;
            this.b_CarShake.Click += new System.EventHandler(this.B_CarShake_Click);
            // 
            // CT1
            // 
            this.CT1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.CT1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.CT1.Legends.Add(legend1);
            this.CT1.Location = new System.Drawing.Point(12, 363);
            this.CT1.Name = "CT1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.Legend = "Legend1";
            series2.Name = "Series2";
            this.CT1.Series.Add(series1);
            this.CT1.Series.Add(series2);
            this.CT1.Size = new System.Drawing.Size(846, 341);
            this.CT1.TabIndex = 8;
            this.CT1.Text = "chart1";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "温湿度显示";
            this.CT1.Titles.Add(title1);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.sleeproom);
            this.groupBox1.Controls.Add(this.inroom);
            this.groupBox1.Controls.Add(this.outroom);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(361, 274);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(497, 83);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "情景模式";
            // 
            // sleeproom
            // 
            this.sleeproom.FlatAppearance.BorderSize = 0;
            this.sleeproom.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.sleeproom.Location = new System.Drawing.Point(332, 31);
            this.sleeproom.Name = "sleeproom";
            this.sleeproom.Size = new System.Drawing.Size(107, 37);
            this.sleeproom.TabIndex = 8;
            this.sleeproom.Text = "睡眠模式";
            this.sleeproom.UseVisualStyleBackColor = true;
            this.sleeproom.Click += new System.EventHandler(this.sleeproom_Click);
            // 
            // inroom
            // 
            this.inroom.FlatAppearance.BorderSize = 0;
            this.inroom.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.inroom.Location = new System.Drawing.Point(178, 29);
            this.inroom.Name = "inroom";
            this.inroom.Size = new System.Drawing.Size(107, 37);
            this.inroom.TabIndex = 7;
            this.inroom.Text = "室内模式";
            this.inroom.UseVisualStyleBackColor = true;
            this.inroom.Click += new System.EventHandler(this.inroom_Click);
            // 
            // outroom
            // 
            this.outroom.FlatAppearance.BorderSize = 0;
            this.outroom.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.outroom.Location = new System.Drawing.Point(29, 28);
            this.outroom.Name = "outroom";
            this.outroom.Size = new System.Drawing.Size(107, 37);
            this.outroom.TabIndex = 6;
            this.outroom.Text = "户外模式";
            this.outroom.UseVisualStyleBackColor = true;
            this.outroom.Click += new System.EventHandler(this.outroom_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ChildCar_Pro.Properties.Resources.g;
            this.ClientSize = new System.Drawing.Size(882, 759);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CT1);
            this.Controls.Add(this.gb_Car);
            this.Controls.Add(this.gb_Mysql);
            this.Controls.Add(this.gb_SerialPort_ResiveAndSend);
            this.Controls.Add(this.gb_SerialPort);
            this.Name = "Form1";
            this.Text = "用户页面";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gb_SerialPort.ResumeLayout(false);
            this.gb_SerialPort.PerformLayout();
            this.gb_SerialPort_ResiveAndSend.ResumeLayout(false);
            this.gb_SerialPort_ResiveAndSend.PerformLayout();
            this.gb_Mysql.ResumeLayout(false);
            this.gb_Car.ResumeLayout(false);
            this.gb_Car.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CT1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_SerialPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button b_OpenSerialPort;
        private System.Windows.Forms.ComboBox cb_SerialPort;
        private System.Windows.Forms.GroupBox gb_SerialPort_ResiveAndSend;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gb_Mysql;
        private System.Windows.Forms.GroupBox gb_Car;
        private System.Windows.Forms.Button b_CarShake;
        private System.Windows.Forms.Button b_Awning;
        private System.Windows.Forms.Button b_MusicPlay;
        private System.Windows.Forms.Button b_Balance;
        private System.Windows.Forms.DataVisualization.Charting.Chart CT1;
        private System.Windows.Forms.Button b_Zd_Awning;
        private System.Windows.Forms.Button b_VoiceW;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label l_l;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label l_hum;
        private System.Windows.Forms.Label l_tem;
        private System.Windows.Forms.Button b_Teach;
        private System.Windows.Forms.TextBox tb_test;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button outroom;
        private System.Windows.Forms.Button sleeproom;
        private System.Windows.Forms.Button inroom;
    }
}

