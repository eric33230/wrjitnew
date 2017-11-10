using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFrom

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
            FrmLogin frm = new FrmLogin();
            //MessageBox.Show(frm.DialogResult.ToString()+"    aaaa"); none
            if(frm.ShowDialog()==DialogResult.Yes)
            {
                frm.Dispose();
                Application.Run(new FrmMain());
            }
        }
    }
}
