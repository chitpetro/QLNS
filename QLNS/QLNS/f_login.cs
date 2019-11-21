using System;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using BUS;
//using ControlLocalizer;
using DAL;
//using Lotus;
using System.Xml;
using DevExpress.DataAccess.Native;
using System.ComponentModel;
using GUI;
using System.Diagnostics;
using System.Reflection;
using DevExpress.XtraSplashScreen;
using System.Runtime.InteropServices;
using System.IO;
using DevExpress.XtraEditors;
namespace QLNS
{
    public partial class f_login : Form
    {
        private readonly t_account ac = new t_account();
        private readonly KetNoiDBDataContext db = new KetNoiDBDataContext();
        private readonly t_history hs = new t_history();
        t_todatatable _tTodatatable = new t_todatatable();

        private object txtPassword;

        public f_login()
        {
            InitializeComponent();

            var lst = (from a in db.skins select a).Single(t => t.trangthai == true);
            Biencucbo.skin = lst.tenskin;
            defaultLookAndFeel1.LookAndFeel.SetSkinStyle(Biencucbo.skin);
            txtname.Focus();



        }



        private void button1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }



        private void txtpass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

            }
        }

        private void txtuser_Leave(object sender, EventArgs e)
        {
            //if (txtname.Text == "")
            //{
            //    txtname.Text = "Please Enter Name";
            //    txtname.ForeColor = Color.Gray;
            //}
        }

        private void txtuser_Enter(object sender, EventArgs e)
        {
            //if (txtname.Text == "Please Enter Name")
            //{
            //    txtname.Text = "";
            //    txtname.ForeColor = Color.Black;
            //}
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            //    if (txtpass1.Text == "")
            //    {
            //        txtpass1.Text = "*********";
            //        txtpass1.ForeColor = Color.Gray;
            //    }
        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
            //if (txtpass1.Text == "*********")
            //{
            //    txtpass1.Text = "";
            //    txtpass1.ForeColor = Color.Black;
            //}
        }

        //language



        private void f_login_Load(object sender, EventArgs e)
        {

           // capnhatonline();


            TransparencyKey = Color.Peru;
            BackColor = Color.Peru;
            lbldb.Text = "Data: " + Biencucbo.DbName;
            txtuser1.Focus();
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                try
                {
                    xmlDoc.Load("appconfig.xml");
                }
                catch
                {
                    try
                    {

                        string filepath = "appconfig.xml";
                        WebClient webClient = new WebClient();
                        webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                        webClient.DownloadFileAsync(new Uri("http://www.petrolao.com.la/config/CCS/appconfig.xml"),
                            filepath);
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.ToString());
                    }
                }
                int Remember = Convert.ToInt32(xmlDoc.DocumentElement["Remember"].InnerText);
                //gán giá trị cho biến Remmber từ file.xml
                if (Remember == 1) //xét xem nó bằng 0 hay bằng 1, như mình nói ở trên: 1 là ghi nhớ, 0 là không ghi nhớ
                {
                    checkremem.Checked = true;
                    txtuser1.Text = xmlDoc.DocumentElement["UserLogin"].InnerText;
                    txtpass1.Text = md5.Decrypt((xmlDoc.DocumentElement["PassLogin"].InnerText));
                    txtpass1.Focus();
                }
                else if (Remember == 0)
                {
                    checkremem.Checked = false;
                    txtuser1.Text = xmlDoc.DocumentElement["UserLogin"].InnerText;
                    txtuser1.Focus();
                }
            }
            catch
            {


            }
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Download completed!");
        }

        //class InternetConnection
        //{
        //    //[DllImport("wininet.dll")]
        //    private extern static bool InternetGetConnectedState(out int description, int reservedValuine);
        //    public static bool IsConnectedToInternet()
        //    {
        //        int desc;
        //        return InternetGetConnectedState(out desc, 0);
        //    }
        //}

        private void btnconnect_Click(object sender, EventArgs e)
        {
            //var frm = new f_connectDB();
            //frm.ShowDialog();

            //lbldb.Text = "Data: " + Biencucbo.DbName;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void txtidnv_TextChanged(object sender, EventArgs e)
        {
        }

        private void login()
        {
            //Kiểm tra Tên và Pass có tồn tại hay không 

            if (ac.dangnhap(txtuser1.Text, md5.Encrypt(txtpass1.Text)).Count == 0)
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng! Vui lòng kiểm tra lại!");
                txtpass1.Text = "";
            }
            else
            {
                //kiểm tra Tài khoản có đang hoạt động không 
                if (ac.dangnhap2(txtuser1.Text, md5.Encrypt(txtpass1.Text)).Count == 0)
                {
                    MessageBox.Show("Tài khoản của bạn đang bị khoá! Vui lòng liên hệ Admin!");
                }
                else
                {
                    var Lst =
                        (from a in db.accounts
                         where a.uname == txtuser1.Text && a.pass == md5.Encrypt(txtpass1.Text)
                         select a)
                            .Single();

                    dataGridView1.DataSource = Lst;

                    txtname.DataBindings.Clear();
                    txtphongban.DataBindings.Clear();
                    txtmadonvi.DataBindings.Clear();



                    // lấy thông tin máy
                    var hostname = "";
                    var ip = new IPHostEntry();
                    hostname = Dns.GetHostName();
                    ip = Dns.GetHostByName(hostname);
                    Biencucbo.hostname = ip.HostName;

                    foreach (var listip in ip.AddressList)
                    {
                        Biencucbo.IPaddress = listip.ToString();
                    }

                    Biencucbo.ten = Lst.name;
                    Biencucbo.dvten = Lst.madonvi;
                    Biencucbo.phongban = Lst.phongban;
                    Biencucbo.donvi = Lst.madonvi;
                    Biencucbo.idnv = Lst.id;
                    hs.add("Login", "Đăng nhập");
                    try
                    {
                        if (checkremem.Checked == true) //Nếu checkbox ghi nhớ được check
                        {
                            XmlDocument xmlDoc = new XmlDocument();
                            xmlDoc.Load("appconfig.xml"); //mở file.xml lên
                            xmlDoc.DocumentElement["UserLogin"].InnerText = txtuser1.Text.Trim(); //lưu username
                            xmlDoc.DocumentElement["PassLogin"].InnerText = md5.Encrypt(txtpass1.Text.Trim());
                            //lưu mật khẩu
                            xmlDoc.DocumentElement["Remember"].InnerText = "1"; //đánh dấu = 1 nghĩa là ghi nhớ
                            xmlDoc.Save("appconfig.xml"); //save file.xml lại
                        }
                        else
                        {
                            XmlDocument xmlDoc = new XmlDocument();
                            xmlDoc.Load("appconfig.xml");
                            xmlDoc.DocumentElement["UserLogin"].InnerText = txtuser1.Text.Trim();
                            xmlDoc.DocumentElement["PassLogin"].InnerText = "";
                            xmlDoc.DocumentElement["Remember"].InnerText = "0"; //đánh dấu = 0 nghĩa là không ghi nhớ
                            xmlDoc.Save("appconfig.xml");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());

                    }
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void btnlgin_Click(object sender, EventArgs e)
        {
            login();
        }

        private void txtpass1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login();
            }
        }

        private void f_login_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnmini_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn Có Muốn Thoát Chương Trình Không?", "Thông Báo", MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
                Application.Exit();
        }


        #region capnhatonline

        // kiểm tra kết nối internet

        string host = "http://www.petrolao.com.la/config/CCS_NS/infoupdate.xml";

        class InternetConnection
        {
            [DllImport("wininet.dll")]
            private extern static bool InternetGetConnectedState(out int description, int reservedValuine);

            public static bool IsConnectedToInternet()
            {
                int desc;
                return InternetGetConnectedState(out desc, 0);
            }
        }

        private void DownloadFile(string host, string filepath)
        {
            try
            {

                WebClient webClient = new WebClient();
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(CheckForUpdate);
                webClient.DownloadFileAsync(new Uri(host), filepath);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        private string docfilexml(string file, string obj)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(file);
            return xmlDoc.DocumentElement[obj].InnerText;

        }

        private void CheckForUpdate(object sender, AsyncCompletedEventArgs e)
        {


            string verstr = docfilexml("infoupdate.xml", "Version");
            //verstr = "1.0.9.5";
            string layver = "";
            for (int i = 0; i < verstr.Length; i++)
            {
                layver = layver + verstr.Substring(i, 1);
                i++;
            }
            int vernew = Convert.ToInt32(layver);

            layver = "";
            string curentver = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            //string curentver = "1.0.0.0";
            for (int i = 0; i < curentver.Length; i++)
            {
                layver = layver + curentver.Substring(i, 1);
                i++;
            }
            int verold = Convert.ToInt32(layver);

            if (verold < vernew)
            {
                if (
                    XtraMessageBox.Show("Bạn có muốn cập nhật phiên bản mới không", "Thông Báo", MessageBoxButtons.YesNo) ==
                    DialogResult.Yes)
                {
                    chaycapnhat();
                }
                else
                {
                    if (File.Exists("infoupdate.xml"))
                    {
                        File.Delete("infoupdate.xml");
                        //XtraMessageBox.Show("Đã xóa file");
                    }
                }

            }
            else
            {
                if (File.Exists("infoupdate.xml"))
                {
                    File.Delete("infoupdate.xml");
                    //XtraMessageBox.Show("Đã xóa file");
                }
            }


        }

        public void chaycapnhat()
        {
            var app = "Update.exe";
            if (!File.Exists(app))
            {
                return;
            }



            var info = new ProcessStartInfo();
            info.FileName = app;
            info.Arguments = string.Format("{0} {1} {2}",
                Assembly.GetExecutingAssembly().GetName().Name,
                Assembly.GetExecutingAssembly().GetName().Version, host);
            var process = Process.Start(info);
            Application.Exit(); //if (process != null) process.WaitForExit();
            //SplashScreenManager.CloseForm();
        }

        public void capnhatonline()
        {

            //var app = string.Format("{0}\\{1}", Application.StartupPath, "Lotus.AutoUpdate_eng.exe");

            if (InternetConnection.IsConnectedToInternet())
            {
                DownloadFile(host, "infoupdate.xml");

            }
            else
            {
                MessageBox.Show("Không thể kiểm tra bản cập nhật do chưa kết nối mạng");
            }

        }

        #endregion
    }
}