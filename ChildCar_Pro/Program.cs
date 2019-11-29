using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChildCar_Pro
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form2 f2 = new Form2();
            f2.ShowDialog();
            if(f2.DialogResult==DialogResult.OK)
            {
                Application.Run(new Form1());
            }
            Form3 f3 = new Form3();
            f3.ShowDialog();
            if (f3.DialogResult == DialogResult.Yes)
            {
                Application.Run(new Form1());
            }
            Form1 f1 = new Form1();
            f1.ShowDialog();
            if (f1.DialogResult == DialogResult.OK)
            {
                Application.Run(new Form3());
            }
        }
    }
}
