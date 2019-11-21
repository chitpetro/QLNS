using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using DevExpress.XtraEditors;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Core;

namespace Update
{
    public partial class f_update : DevExpress.XtraEditors.XtraForm
    {
        private string verstr = "";
        private string fileinfo = "infoupdate.xml";
        string[] args = Environment.GetCommandLineArgs();

        public f_update()
        {
            InitializeComponent();
            taicapnhat();
        }

        private void f_update_Load(object sender, EventArgs e)
        {
            process.EditValue = 0;
            lblper.Text = process.EditValue.ToString() + "%";
            //DownloadFile(args[3], fileinfo);

            //DownloadFile(host, fileinfo);
        }

        private string docfilexml(string file, string obj)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(file);
            return xmlDoc.DocumentElement[obj].InnerText;

        }

        private void CheckForUpdate(object sender, AsyncCompletedEventArgs e)
        {


            verstr = docfilexml(fileinfo, "Version");
            //verstr = "1.0.9.5";
            string layver = "";
            for (int i = 0; i < verstr.Length; i++)
            {
                layver = layver + verstr.Substring(i, 1);
                i++;
            }
            int vernew = Convert.ToInt32(layver);

            layver = "";
            string curentver = args[2];
            //string curentver = "1.0.0.0";
            for (int i = 0; i < curentver.Length; i++)
            {
                layver = layver + curentver.Substring(i, 1);
                i++;
            }
            int verold = Convert.ToInt32(layver);

            if (verold <= vernew)
            {
                if (
                    XtraMessageBox.Show("Bạn có muốn cập nhật phiên bản mới không", "Thông Báo", MessageBoxButtons.YesNo) ==
                    DialogResult.No)
                    exitapp();
                taicapnhat();
            }
            else
            {
                exitapp();
            }


        }

        private void taicapnhat()
        {

            lblpro.Text = "Đang tải về bản cập nhật";
            process.EditValue = 0;
            lblper.Text = process.EditValue.ToString() + "%";


            WebClient wc = new WebClient();
            wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(wc_DownloadProgressChanged);
            wc.DownloadFileCompleted += new AsyncCompletedEventHandler(appcom);
            Uri app = new Uri(docfilexml(fileinfo, "Link"));
            wc.DownloadFileAsync(app, "app.zip");
            


        }

        public void wc_DownloadProgressChanged(Object sender, DownloadProgressChangedEventArgs e)

        {
            process.EditValue = e.ProgressPercentage;
            lblper.Text = e.ProgressPercentage + "%";

        }

        private void appcom(object sender, AsyncCompletedEventArgs e)
        {
            //giai nen file.rar
           
            lblpro.Text = "Đang giải nén bản cài đặt";
            string file = "app.zip";
            ZipFile zf = null;
            try
            {
                FileStream fs = File.OpenRead(file);
                zf = new ZipFile(fs);

                foreach (ZipEntry zipEntry in zf)
                {
                    if (!zipEntry.IsFile)
                    {
                        continue; // Ignore directories
                    }
                    String entryFileName = zipEntry.Name;
                    // to remove the folder from the entry:- entryFileName = Path.GetFileName(entryFileName);
                    // Optionally match entrynames against a selection list here to skip as desired.
                    // The unpacked length is available in the zipEntry.Size property.

                    byte[] buffer = new byte[4096]; // 4K is optimum
                    Stream zipStream = zf.GetInputStream(zipEntry);

                    // Manipulate the output filename here as desired.
                    String fullZipToPath = System.IO.Path.Combine(entryFileName);
                    string directoryName = System.IO.Path.GetDirectoryName(fullZipToPath);
                    if (directoryName.Length > 0)
                        Directory.CreateDirectory(directoryName);

                    // Unzip file in buffered chunks. This is just as fast as unpacking to a buffer the full size
                    // of the file, but does not waste memory.
                    // The “using” will close the stream even if an exception occurs.
                    //MessageBox(fullZipToPath);
                    using (FileStream streamWriter = File.Create(fullZipToPath))
                    {
                        StreamUtils.Copy(zipStream, streamWriter, buffer);
                    }
                }
            }
            finally
            {
                if (zf != null)
                {
                    zf.IsStreamOwner = true; // Makes close also shut the underlying stream
                    zf.Close(); // Ensure we release resources
                }
            }
         
           

            //khoi dong
            exitapp();
            //timedongbo.Enabled = true;
        }

        private void exitapp()
        {
            delefile();
            //Process.Start("QLNS.exe");

            var app = "QLNS.exe";
            if (!File.Exists(app))
            {
                return;
            }



            var info = new ProcessStartInfo();
            info.FileName = app;
            Process.Start(info);
            Application.Exit();

        }

        private void delefile()
        {
            string authorsFile = fileinfo;

            try
            {
                //Check if file exists with its full path
                if (File.Exists(authorsFile))
                {
                    File.Delete((authorsFile));
                  
                }



            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        //private void DownloadFile(string host, string filepath)
        //{
        //    try
        //    {

        //        WebClient webClient = new WebClient();
        //        webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(CheckForUpdate);
        //        webClient.DownloadFileAsync(new Uri(host), filepath);

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());

        //    }
        //}

        //private void timedongbo_Tick(object sender, EventArgs e)
        //{
        //    timedongbo.Stop();


        //    XtraMessageBox.Show("dongbo");
        //    lblpro.Text = "đang đồng bộ bản cập nhật";


        //    //if (File.Exists("QLNS.exe"))
        //    //    File.Move("QLNS.exe", "doiten.exe");
        //    //progressBar1.Value = 100;//label3.Text = progressBar1.Value.ToString() + "%";
        //    //xoa file app.rar vua taiif (File.Exists("app.zip"))
        //    File.Delete("app.zip");


        //    if (Directory.Exists(thumuc))
        //    {

        //        string[] filelist = Directory.GetFiles(thumuc);
        //        foreach (string sourceFile in filelist)
        //        {
        //            using (FileStream stream = File.Open(sourceFile, FileMode.Open, FileAccess.Write, FileShare.ReadWrite))
        //            {
        //                //tách tên file ra khỏi đường dẫn (tên file sẽ dùng để tạo đường dẫn đích cần copy đè)
        //                string destinationFile = Path.GetFileName(sourceFile);

        //                //thực hiện copy đè
        //                File.Copy(sourceFile, destinationFile, true);

        //                XtraMessageBox.Show("Ghi đè thành công");
        //            }
        //        }
        //        XtraMessageBox.Show("Hoàn tất");

        //    }
        //    timekhoidong.Enabled = true;
        //    //xoa file zip.zip (winrar bên thứ 3 vừa tải)

        //}

        //private void timekhoidong_Tick(object sender, EventArgs e)
        //{
        //    timekhoidong.Stop();
        //    XtraMessageBox.Show("Khởi động");

        //    //dong dong phien ban moi
        //    exitapp();



        //}
    }


}
