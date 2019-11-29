using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MySql.Data.MySqlClient;
using System.Threading;
using System.IO.Ports;
using System.Media;

namespace ChildCar_Pro
{
    public partial class Form1 : Form
    {
        public string[] strArray;
        public int num = 0;
        public Boolean Shake_flag = false;
        public Boolean Awning_flag = false;
        public Boolean MusicPlay_flag = false;
        public Boolean Balance_flag = false;
        public Boolean ZdAwning_flag = false;
        public Boolean VoiceW_flag = false;
        public int wen = 1;
        public int shi = 1;

        /// <summary>
        /// 实例化类，方便调用类里面的数据库以及其他的方法
        /// </summary>
        Public_Class pc = new Public_Class();
        //实例化串口对象
        SerialPort serialPort1 = new SerialPort();
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 窗口初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("第二个窗口");
            b_CarShake.Text = "开启摇床模式";
            b_Awning.Text = "关闭遮光蓬";
            b_MusicPlay.Text = "播放音乐";
            b_Balance.Text = "开启平衡模式";
            b_Zd_Awning.Text = "自动开关遮光蓬";
            b_VoiceW.Text = "开启语音提示";
            string sql = "select * from tb_"+pc.Flag;
            DataTable dt = new DataTable();
            dt = pc.ExecuteQuery(sql);
            Chart_Init(dt);
            Control.CheckForIllegalCrossThreadCalls = false;
            //检查是否含有串口
            string[] str = SerialPort.GetPortNames();
            if (str == null)
            {
                MessageBox.Show("没有检测到串口，请先连接底板上的USB再打开软件！", "Error");
                return;
            }
            //添加串口项目 获取计算机上有多少个串口
            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
            {
                cb_SerialPort.Items.Add(s);
            }
            //串口设置默认选择项
            serialPort1.BaudRate = 115200;
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);//处理收到的数据
        }

        /// <summary>
        /// 打开串口按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_OpenSerialPort_Click(object sender, EventArgs e)
        {
            try
            {
                string SerName = cb_SerialPort.SelectedItem.ToString();//获取串口号的选择项   
                string SerBaudRate = "115200";//获取当前的波特率
                Int32 SBaudRate = Convert.ToInt32(SerBaudRate);
                serialPort1.PortName = SerName;     //设置串口号
                serialPort1.BaudRate = SBaudRate;   //设置波特率
                serialPort1.DataBits = 8;           //设置数据位
                serialPort1.StopBits = StopBits.One;//设置停止位
                serialPort1.Parity = Parity.None;   //设置校验位
                                                    //没有此行就不能实现文本转换
                serialPort1.Encoding = System.Text.Encoding.GetEncoding("GB2312");
                if (serialPort1.IsOpen == true)//如果串口打开则先关闭
                    serialPort1.Close();
                serialPort1.Open();//打开串口
                if (serialPort1.IsOpen == true)
                {
                    MessageBox.Show("打开串口成功");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("当前串口已被占用或其它错误，请选择其它串口或检查串口设置是否正确");
            }
        }

        /// <summary>
        /// 串口消息接收与处理（还未处理）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            
            try
            {
                string strData;//用于存取串口的数据
                //readLine()方法在进行读取一行时，只有遇到回车(\r)或者换行符(\n)才会返回读取结果
                strData = serialPort1.ReadExisting();//串口收到的数据
                strArray = strData.Split(':');//分割数据，分为四段t&h&l、25、78、100
                l_tem.Text = strArray[1] + "℃";//取出相应的值再放入框中
                l_hum.Text = strArray[2] + "%";
                tb_test.Text = strData;
                if (Convert.ToInt32(strArray[3]) < 100)
                {  
                    num++;
                    l_l.Text = "强光";
                }
                  
                if (Convert.ToInt32(strArray[3]) >= 100 && Convert.ToInt32(strArray[3]) < 400)
                {
                        l_l.Text = "中光"; num=0;
                }
                   
                if (Convert.ToInt32(strArray[3]) >= 400)
                {
                    l_l.Text = "弱光";num = 0;
                }
                    
                serialPort1.DiscardInBuffer();//清空缓冲区数据，等待下次接收
                if (Convert.ToInt32(strArray[1]) > 20 && VoiceW_flag)
                {
                        wen++;
                        wen %= 5;
                    if (wen == 2)
                    {
                        pc.Voices("温度过高");
                    }
                        
                }
                    
               
                if (Convert.ToInt32(strArray[2]) > 80 && VoiceW_flag )
                {
                    shi++;
                    shi %= 10;
                    if (shi == 2)
                    {
                pc.Voices("湿度过高，请注意是否尿床");
                    }
                   
                }
                   
                if(ZdAwning_flag&& Convert.ToInt32(strArray[3])<100)
                {

                    if (Shake_flag)
                        serialPort1.Write("011");
                    if (Balance_flag)
                        serialPort1.Write("101");
                    if (!Shake_flag && !Balance_flag&&num>3)
                    {
                            serialPort1.Write("001");
                    }
                        
                }
                if (ZdAwning_flag && Convert.ToInt32(strArray[3]) >= 100)
                {
                    if (Shake_flag)
                        serialPort1.Write("010");
                    if (Balance_flag)
                        serialPort1.Write("100");
                    if (!Shake_flag && !Balance_flag)
                        serialPort1.Write("000");
                }
            }
            catch (Exception) { }
        }

        /// <summary>
        /// 对Chart表进行初始化
        /// </summary>
        private void Chart_Init(DataTable dt)
        {
            int[] a,b;
            if (CT1.Series!=null)
                CT1.Series.Clear();
            int rows = dt.Rows.Count;
            if(rows==0)
            {
               //MessageBox.Show("数据为空");
                return;
            }
            if(rows>10)
            {
                 a = new int[10];
                 b = new int[10];
                for (int i = rows-10,k=0; i < rows; i++,k++)
                {
                    a[k] = Convert.ToInt32(dt.Rows[i][0].ToString());
                    b[k] = Convert.ToInt32(dt.Rows[i][1].ToString());
                }
            }
            else
            {
                a = new int[rows];
                b = new int[rows];
                for (int i = 0; i < rows; i++)
                {
                    a[i] = Convert.ToInt32(dt.Rows[i][0].ToString());
                    b[i] = Convert.ToInt32(dt.Rows[i][1].ToString());
                }
            } 
            var chart = CT1.ChartAreas[0];
            chart.AxisX.IntervalType = DateTimeIntervalType.Number;//指定主x轴的间距类型是数字类型
            chart.AxisX.LabelStyle.Format = "";
            chart.AxisY.LabelStyle.Format = "";
            chart.AxisY.LabelStyle.IsEndLabelVisible = true;
            chart.AxisX.Interval = 1;//每隔1个数显示一个
            chart.AxisX.MajorGrid.Enabled = false;//去掉x轴的网格
            chart.AxisY.MajorGrid.Enabled = false;
            chart.AxisX.Title = "/10分钟";
            chart.AxisY.Title = "温度℃/湿度%";
            //chart.AxisX. = ArrowStyle.DoubleArrow;
            this.CT1.Titles[0].ForeColor = Color.Red;//设置标题颜色
            chart.AxisX.Minimum = 0;
            chart.AxisX.Maximum = 10;
            chart.AxisY.Minimum = 0;
            chart.AxisY.Maximum = 100;
            //CT1.BackColor = Color.LightSkyBlue;//设置背景颜色，折线图外部
            CT1.Series.Add("温度");
            CT1.Series.Add("湿度");
            //绘制折线图
            CT1.Series["温度"].BorderWidth = 2;
            CT1.Series["温度"].IsValueShownAsLabel = true;//设置是否在Chart中显示坐标点值
            CT1.Series["温度"].ChartType = SeriesChartType.Spline;
            CT1.Series["温度"].Color = Color.Purple;
            CT1.Series["温度"].MarkerStyle = MarkerStyle.Circle;//数据点的形状是圆
            CT1.Series["温度"].MarkerSize = 5;//数据点大小
            CT1.Series["温度"].MarkerColor = Color.Green;
            CT1.Series["湿度"].BorderWidth = 2;
            CT1.Series["湿度"].IsValueShownAsLabel = true;//设置是否在Chart中显示坐标点值
            CT1.Series["湿度"].ChartType = SeriesChartType.Spline;
            CT1.Series["湿度"].Color = Color.Blue;
            CT1.Series["湿度"].MarkerStyle = MarkerStyle.Circle;//数据点的形状是圆
            CT1.Series["湿度"].MarkerSize = 5;//数据点大小
            CT1.Series["湿度"].MarkerColor = Color.Red;
            if(rows>10)
            {
                for (int j = 0; j < 10; j++)
                {
                    CT1.Series["温度"].Points.AddXY(j, a[j]);
                    CT1.Series["湿度"].Points.AddXY(j, b[j]);
                }
            }
            else
            {
                for (int j = 0; j < rows; j++)
                {
                    CT1.Series["温度"].Points.AddXY(j, a[j]);
                    CT1.Series["湿度"].Points.AddXY(j, b[j]);
                }
            }
        }

        /// <summary>
        /// 启用摇床模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_CarShake_Click(object sender, EventArgs e)
        {
            if(!serialPort1.IsOpen)
            {
                MessageBox.Show("请先打开串口");
                return;
            }
            if(Balance_flag)
            {
                MessageBox.Show("此模式下需先关闭平衡模式");
                return;
            }
            Shake_flag = !Shake_flag;
            if(Shake_flag)
            {
                serialPort1.Write(DataDel());
                b_CarShake.Text = "关闭摇床模式";
               // MessageBox.Show("摇篮模式已开启" + DataDel());
            }
            else
            {
                serialPort1.Write(DataDel());
                b_CarShake.Text = "开启摇床模式";
               // MessageBox.Show("摇篮模式已关闭" + DataDel());
            }
        }

        /// <summary>
        /// 启动遮光蓬
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_Awning_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                MessageBox.Show("请先打开串口");
                return;
            }
            if (ZdAwning_flag)
            {
                MessageBox.Show("请先关闭自动遮光");
                return;
            }
            Awning_flag = !Awning_flag;
            if(Awning_flag)
            {
                //MessageBox.Show(DataDel());
                serialPort1.Write(DataDel());
                b_Awning.Text = "打开遮光蓬";
               // MessageBox.Show("遮光蓬已关闭" + DataDel());
            }
            else
            {
                serialPort1.Write(DataDel());
                b_Awning.Text = "关闭遮光蓬";
                //MessageBox.Show("遮光蓬已打开" + DataDel());
            }
        }

        /// <summary>
        /// 播放音乐
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_MusicPlay_Click(object sender, EventArgs e)
        {
            try
            {
                MusicPlay_flag = !MusicPlay_flag;
                SoundPlayer music = new SoundPlayer();
                music.SoundLocation = @"C:\Users\yongk\Desktop\ChildCar_Pro\ChildCar_Pro\ChildCar_Pro\Resources\Free.wav";
                music.LoadAsync();
                if (MusicPlay_flag)
                {
                    music.Play();
                    b_MusicPlay.Text = "关闭音乐";
                  //  MessageBox.Show("音乐已开启");
                }
                else
                {
                    music.Stop();
                    b_MusicPlay.Text = "播放音乐";
                  //  MessageBox.Show("音乐已关闭");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 自动平衡模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_Balance_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                MessageBox.Show("请先打开串口");
                return;
            }
            if (Shake_flag)
            {
                MessageBox.Show("在此模式下需先关闭摇床模式");
                return;
            }
          
            Balance_flag = !Balance_flag;
            if(Balance_flag)
            {
                serialPort1.Write(DataDel());
                b_Balance.Text = "关闭平衡模式";
               // MessageBox.Show("平衡模式已开启"+DataDel());
            }
            else
            {
                serialPort1.Write(DataDel());
                b_Balance.Text = "开启平衡模式";
              //  MessageBox.Show("平衡模式已关闭" + DataDel());
            }
        }

        /// <summary>
        /// 自动开启遮光蓬按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_Zd_Awning_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                MessageBox.Show("请先打开串口");
                return;
            }
            ZdAwning_flag = !ZdAwning_flag;
            if(ZdAwning_flag)
            {
                b_Zd_Awning.Text = "关闭自动遮光蓬";
              //  MessageBox.Show("自动开关遮光蓬已开启");
            }
            else
            {
                b_Zd_Awning.Text = "自动开关遮光蓬";
               // MessageBox.Show("自动开关遮光蓬已关闭");
            }
        }

        /// <summary>
        /// 语音提示按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_VoiceW_Click(object sender, EventArgs e)
        {

            VoiceW_flag = !VoiceW_flag;
            if (VoiceW_flag)
            {
                b_VoiceW.Text = "关闭语音提示";
               // MessageBox.Show("语音提示已开启");   
            }
            else
            {
                b_VoiceW.Text = "开启语音提示";
               // MessageBox.Show("语音提示已关闭");
            }
        }

        /// <summary>
        /// 处理flag
        /// </summary>
        /// <returns></returns>
        private string DataDel()
        {
            char[] c = new char[5];
            if (Balance_flag)
                c[0] = '1';
            if (!Balance_flag)
                c[0] = '0';
            if (Shake_flag)
                c[1] = '1';
            if (!Shake_flag)
                c[1] = '0';
            if (Awning_flag)
                c[2] = '1';
            if (!Awning_flag)
                c[2] = '0';
            string str = new string(c);
            return str;
        }

        /// <summary>
        /// 早教按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_Teach_Click(object sender, EventArgs e)
        {

           
            this.DialogResult = DialogResult.Yes;
            this.Dispose();
            this.Close();
            
           // MessageBox.Show("我们正在努力开发早教系统中");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void gb_Car_Enter(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 
        /// 户外模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void outroom_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                MessageBox.Show("请先打开串口");
                return;
            }
            ZdAwning_flag = !ZdAwning_flag;
            Balance_flag = !Balance_flag;
            if (ZdAwning_flag)
            {
                outroom.Text = "户外模式已启用";
            }
            else
            {
                outroom.Text = "户外模式";
            }
            if (Balance_flag)
            {
                serialPort1.Write(DataDel());
            }
            else
            {
                serialPort1.Write(DataDel());
            }
        }
        /// <summary>
        /// 室内模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void inroom_Click(object sender, EventArgs e)
        {

        }

        private void sleeproom_Click(object sender, EventArgs e)
        {
            try
            {
                MusicPlay_flag = !MusicPlay_flag;
                SoundPlayer music = new SoundPlayer();
                music.SoundLocation = @"C:\Users\yongk\Desktop\ChildCar_Pro\ChildCar_Pro\ChildCar_Pro\Resources\Free.wav";
                music.LoadAsync();
                if (MusicPlay_flag)
                {
                    music.Play();
                  
                   
                }
                else
                {
                    music.Stop();
                 
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (!serialPort1.IsOpen)
            {
                MessageBox.Show("请先打开串口");
                return;
            }
            if (Balance_flag)
            {
                MessageBox.Show("此模式下需先关闭平衡模式");
                return;
            }
            Shake_flag = !Shake_flag;
            if (Shake_flag)
            {
                serialPort1.Write(DataDel());
                inroom.Text = "室内模式已开启";
               
            }
            else
            {
                serialPort1.Write(DataDel());
                b_CarShake.Text = "室内模式";
               
            }
        }
    }
}
