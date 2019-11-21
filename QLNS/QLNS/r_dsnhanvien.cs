using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using BUS;

namespace QLNS
{
    public partial class r_dsnhanvien : DevExpress.XtraReports.UI.XtraReport
    {
        public r_dsnhanvien()
        {
            InitializeComponent();
            
        }

        private void r_dsnhanvien_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xtitle.Text = "BÁO CÁO DANH SÁCH NHÂN SỰ " + Biencucbo.thoigian;
        }
    }
}
