using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WebSiteBackupApp
{
    public partial class Form1 : Form
    {
        static string SourceDirectory = ConfigurationManager.AppSettings["SourceDirectory"];

        static string TargetDirectory = ConfigurationManager.AppSettings["TargetDirectory"];

        static int week = Convert.ToInt32(ConfigurationManager.AppSettings["week"]);

        static long interval = Convert.ToInt32(ConfigurationManager.AppSettings["interval"]) * 1000;

        static System.Timers.Timer timer = new System.Timers.Timer();

        static string adds = string.Empty;

        public Form1()
        {
            InitializeComponent();

            timer.Elapsed += timer_Tick;
            timer.Interval = interval;

            timer.Start();
        }

        static void timer_Tick(object sender, EventArgs e)
        {
            DateTime datetime = DateTime.Now;
            DayOfWeek _week = datetime.DayOfWeek;

            adds = @"\" + datetime.ToString("yyyy-MM-dd");
            if (_week == (DayOfWeek)week)
            {
                string dcs = TargetDirectory + adds;

                if (!Directory.Exists(dcs))
                {
                    CopyDirectoryWorker cdw = new CopyDirectoryWorker();
                    //拷贝文件夹                
                    cdw.OnCopyFile += cdw_OnCopyFile;
                    cdw.WorkOvered += cdw_WorkOvered;
                    cdw.SourceDirectory = SourceDirectory;
                    cdw.AimDirectory = dcs;

                    System.Threading.ThreadPool.QueueUserWorkItem((o) =>
                    {
                        cdw.CopyFiles();
                    });
                }
            }
        }

        static void cdw_WorkOvered()
        {

        }

        static void cdw_OnCopyFile(long lngHad, long lngCount, string strShow)
        {

        }
    }
}
