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
using DAL;

namespace QLNS
{
    public partial class f_history : frm_btnmo
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        public f_history()
        {
            InitializeComponent();
            bar2.Visible = false;
        }

        protected override void load()
        {
            gd.DataSource = dbData.layhistory(DateTime.Parse(tungay.EditValue.ToString()), DateTime.Parse(denngay.EditValue.ToString()));
            gv.BestFitColumns();
        }

        protected override void search()
        {
            load();
        }

        protected override void searchall()
        {
            gd.DataSource = dbData.histories;
            gv.BestFitColumns();
        }
    }
}