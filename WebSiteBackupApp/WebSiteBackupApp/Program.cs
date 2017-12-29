using System;
using System.Collections.Generic;
//using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Timers;

namespace WebSiteBackupApp
{
    static class Program
    {       
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            Form1 frm = new Form1() { Height = 0, Width = 0, ShowInTaskbar = false, Visible = false ,ShowIcon= false};
            System.Windows.Forms.Application.Run(frm);       
        }      
    }
}
