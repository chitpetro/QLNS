using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Utils.OAuth.Provider;
using DAL;
using DevExpress.XtraSplashScreen;
using GUI;
using System.Data.OleDb;

namespace QLNS
{
    public partial class XtraForm1 : DevExpress.XtraEditors.XtraForm
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        public XtraForm1()
        {
            InitializeComponent();

            
        }

        private void load()
        {
            
            gd.DataSource = dbData.nhansus;
        }
        private void XtraForm1_Load(object sender, EventArgs e)
        {
            load();
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            try
            {
                var c1 = dbData.nhansus.Context.GetChangeSet();
                dbData.nhansus.Context.SubmitChanges();
                mes.done();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString());
            }
        }

        private void btngiaima_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(SplashScreen1));
            for (int i = 0; i < gv.DataRowCount; i++)
            {
                gv.SetRowCellValue(i, "key", md5.Decrypt(gv.GetRowCellValue(i, "key").ToString()));
            }
            mes.done();
            SplashScreenManager.CloseForm();
        }

        private void btnmahoa_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(SplashScreen1));
            for (int i = 0; i < gv.DataRowCount; i++)
            {
                gv.SetRowCellValue(i, "key", md5.Encrypt(gv.GetRowCellValue(i, "key").ToString()));
            }
            mes.done();
            SplashScreenManager.CloseForm();
        }

       


    }
}