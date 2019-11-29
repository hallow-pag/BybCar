using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Management;
using System.Threading;

namespace ChildCar_Pro
{
    public partial class Form2 : Form
    {
        Public_Class pc = new Public_Class();
        public Form2()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 窗口初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form2_Load(object sender, EventArgs e)
        {
            gb_gesture.Visible = false;
            try
            {
                pc.Execute(pc.connect);
                //MessageBox.Show("数据库连接成功");
            }
            catch(MySqlException me)
            {
                MessageBox.Show(me.Message);
                MessageBox.Show("数据库连接问题，请与管理员联系");
            }
            string str_TF = "select phone from Flag_info where Flag=" + pc.Flag;
            DataTable dt1 = new DataTable();
            dt1 = pc.ExecuteQuery(str_TF);//检测是否已经注册过
            String Phone = dt1.Rows[0][0].ToString();
            //MessageBox.Show(Phone);
            if(Phone=="")
            {
                gb_gesture.Visible = true;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }
        /// <summary>
        /// 注册按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_Login_Click(object sender, EventArgs e)
        {
            string Phone = tb_Phone.Text;
            string Age = cb_Age.Text;
            string Sex = cb_Sex.Text;
            string Weight = tb_Weight.Text;
            if(Phone.Length!=11||Age==""|| Sex==""||Weight.ToString()=="")
            {
                MessageBox.Show("请输入完整的信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                string sql = "update Flag_info set Phone=" + Phone + 
                            ",ChildAge=" + Age + 
                            ",ChildWeight=" + Weight + 
                            ",ChildSex='" + Sex + "'" + 
                            " where Flag=" + pc.Flag;
                //MessageBox.Show(sql);
                try
                {
                    int result = pc.ExecuteUpdate(sql);
                   // MessageBox.Show("修改表数据："+result);
                    if (result == 1)
                    {
                        string tname = "tb_" + pc.Flag;
                        string sqltable = "create table " + tname + 
                            " (tmp char(5) null," +
                            "hum char(5) null," +
                            "light char(5) null," +
                            "count int null);";
                        //MessageBox.Show(sqltable);
                        int tb = pc.ExecuteUpdate(sqltable);
                        //MessageBox.Show("创建表：" + tb);
                            tb_Phone.Text = "";
                            cb_Age.Text = "" ;
                            cb_Sex.Text = "";
                            tb_Weight.Text = "";
                            this.DialogResult = DialogResult.OK;
                    }
                    else
                        MessageBox.Show("注册失败");
                }
                catch (Exception)
                {
                   // MessageBox.Show("注册过程出问题");
                }
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
