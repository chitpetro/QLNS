using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using GUI;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System.IO;
using System.Xml;
using System.Net;
using System.Diagnostics;
using System.Reflection;
using Update;
using System.Runtime.InteropServices;

namespace QLNS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
     
            SplashScreenManager.ShowForm(typeof(SplashScreen1));
            CapNhatOnline();
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load("appconn.xml");
            }
            catch
            {
                try
                {

                    string filepath = "appconn.xml";
                    WebClient webClient = new WebClient();
                    //webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                    webClient.DownloadFileAsync(new Uri("http://www.petrolao.com.la/config/CCS/appconn.xml"), filepath);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
            }

            var fketnoi = new f_connectDB();
            var isconnected = fketnoi.KiemTraKetNoi();
            if (isconnected == false)
            {
                XtraMessageBox.Show("Connection failed!");
                SplashScreenManager.CloseForm();
                if (fketnoi.ShowDialog() == DialogResult.Cancel)
                    return;
            }
            else
            {
                SplashScreenManager.CloseForm();
            }
            try
            {
                var tmpPath = Application.StartupPath + "\\tmp";
                Directory.Delete(tmpPath, true);
            }
            catch (Exception ex)
            {
            }

            BonusSkins.Register();
            Application.Run(new f_main());}
        public static void CapNhatOnline()
        {
           

            //var app = String.Format("{0}\\{1}", Application.StartupPath, "Lotus.AutoUpdate.exe");
            var app = string.Format("{0}\\{1}", Application.StartupPath, "Lotus.AutoUpdate_eng.exe");
            if (!File.Exists(app)) return;

            var host = "http://www.petrolao.com.la/config/CCS_NS/info.xml";

            var info = new ProcessStartInfo();
            info.FileName = app;
            info.Arguments = string.Format("{0} {1} {2}",
                Assembly.GetExecutingAssembly().GetName().Name,
                Assembly.GetExecutingAssembly().GetName().Version,
                host);

            var process = Process.Start(info);
            if (process != null) process.WaitForExit();
           
        }






    }
}
