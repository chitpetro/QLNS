using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DevExpress.XtraEditors;
using DAL;

//using Settings = QLNS.Properties.Settings;
using System.Xml;
using System.Net;
using GUI;

namespace QLNS
{
    public partial class f_connectDB : DevExpress.XtraEditors.XtraForm
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        public f_connectDB()
        {
            InitializeComponent();
        }

        private void f_connectDB_Load(object sender, EventArgs e)
        {
            
        }
        public bool KiemTraKetNoi()
        {

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("appconn.xml");//mở file.xml lên
            var s = xmlDoc.DocumentElement["conn"].InnerText;
            if (s == string.Empty) return false;

            // giải mã
            var conn = md5.Decrypt(s);
            var b = new SqlConnectionStringBuilder();
            b.ConnectionString = conn;
            Biencucbo.DbName = b.InitialCatalog;
            Biencucbo.ServerName = b.DataSource;
            var sqlCon = new SqlConnection(conn);

            // gán cho DAL tren bo nhớ 
            DAL.Settings.Default.CCS_NSConnectionString = conn;
            try
            {
                sqlCon.Open();
                db = new KetNoiDBDataContext(sqlCon);
                return true;
            }
            catch (Exception ex)
            {
            }
            return false;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtdataname.Text == "")
            {
                XtraMessageBox.Show("Database name is not be empty", "Warning");
                return;
            }
            var thatluangplazaConnectionString_new = "";

            thatluangplazaConnectionString_new = "Data Source = " + txtservername.Text + "; Initial Catalog = " +
                                                 txtdataname.Text + "; Persist Security Info = True; User ID = " +
                                                 txtuser.Text + "; Password = " + txtpass.Text + "";

            var sqlCon = new SqlConnection(thatluangplazaConnectionString_new);
            try
            {
                sqlCon.Open();

                db = new KetNoiDBDataContext(sqlCon);

                XtraMessageBox.Show("Connection succeeded");
                Biencucbo.DbName = txtdataname.Text;
                Biencucbo.ServerName = txtservername.Text;
                thoat_luon = true;
                // luu connstring mã hóa vào setting
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("appconn.xml");//mở file.xml lên
                xmlDoc.DocumentElement["conn"].InnerText = md5.Encrypt(thatluangplazaConnectionString_new);
                xmlDoc.Save("appconn.xml");
                DAL.Settings.Default.CCS_NSConnectionString = thatluangplazaConnectionString_new;

                //Settings.Default.Save();

                DialogResult = DialogResult.OK;
            }
            catch
            {
                XtraMessageBox.Show("Connection failed, please check again or contact Admin");
                sqlCon.Close();
            }
        }
        private bool thoat_luon;

        private void btntest_Click(object sender, EventArgs e)
        {
            if (txtdataname.Text == "")
            {
                XtraMessageBox.Show("Database name is not be empty", "Warning");
                return;
            }
            var thatluangplazaConnectionString_new = "";

            thatluangplazaConnectionString_new = "Data Source = " + txtservername.Text + "; Initial Catalog = " +
                                                 txtdataname.Text + "; Persist Security Info = True; User ID = " +
                                                 txtuser.Text + "; Password = " + txtpass.Text + "";

            var sqlCon = new SqlConnection(thatluangplazaConnectionString_new);
            try
            {
                sqlCon.Open();
                //db = new KetNoiDBDataContext(sqlCon);

                XtraMessageBox.Show("Connection succeeded");
                //Settings.Default.Save();
            }
            catch
            {
                XtraMessageBox.Show("Connection failed, please check again or contact Admin");
                sqlCon.Close();
            }
        }
    }
}