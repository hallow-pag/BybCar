using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Speech.Synthesis;

namespace ChildCar_Pro
{
    class Public_Class
    {
        /// <summary>
        /// 每个设备的唯一标识符
        /// </summary>
        public int Flag = 0;
        /// <summary>
        /// 语音播报
        /// </summary>
        /// <param name="str"></param>
        public void Voices(String str)
        {
            SpeechSynthesizer voice = new SpeechSynthesizer();   //创建语音实例
            voice.Rate = 1; //设置语速,[-10,10]
            voice.Volume = 100; //设置音量,[0,100]
            voice.SpeakAsync(str);
        }
        /// <summary>
        /// 数据库连接地址
        /// </summary>
        //public string connect = "server=119.23.106.150;port=3306;User=admain;password=123456;Database=idear";
        public string connect = "server=hunya.fun;port=3306;User=bbc;password=123456;Database=class1";
        /// <summary>
        /// 连接数据库测试
        /// </summary>
        /// <param name="sqlStr"></param>
        /// <returns></returns>
        public void Execute(string cn)
        {

            MySqlConnection mycon = new MySqlConnection(cn);
            mycon.Open();
            mycon.Close();
        }
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="sqlStr"></param>
        /// <returns></returns>
        public DataTable ExecuteQuery(string sqlStr)
        {
            MySqlConnection mycon = new MySqlConnection(connect);
            mycon.Open();
            MySqlCommand mycmd = new MySqlCommand(sqlStr, mycon);
            MySqlDataAdapter msda = new MySqlDataAdapter(mycmd);
            DataTable dt = new DataTable();
            msda.Fill(dt);
            mycon.Close();
            return dt;
        }
        /// <summary>
        /// 数据库增删改，返回被修改过的行数
        /// </summary>
        /// <param name="sqlStr"></param>
        /// <returns></returns>
        public int ExecuteUpdate(string sqlStr)
        {
            MySqlConnection mycon = new MySqlConnection(connect);
            mycon.Open();
            MySqlCommand mycmd = new MySqlCommand(sqlStr, mycon);
            int ChangeRows = 0;
            ChangeRows = mycmd.ExecuteNonQuery();
            mycon.Close();
            return ChangeRows;
        }
    }
}
