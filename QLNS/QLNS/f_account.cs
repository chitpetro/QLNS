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
using BUS;
using DevExpress.XtraBars;

namespace QLNS
{
    public partial class f_account : frm_ds
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        t_account ac = new t_account();
        t_history hs = new t_history();

        private bool dble = false;

        public f_account()
        {
            InitializeComponent();
            btnxoa.Visibility = BarItemVisibility.Never;

        }

        protected override int load()
        {
            dbData = new KetNoiDBDataContext();
            try
            {
                gd.DataSource = dbData.r_dsaccounts;
                gv.BestFitColumns();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            return 1;
        }

        protected override int them()
        {
            int obj = 0;
            try
            {
                Biencucbo.hdong = 0;
                Biencucbo.obj = 0;
                f_themaccount frm = new f_themaccount();
                frm.ShowDialog();
                obj = Biencucbo.obj;
            }
            catch (Exception ex)
            {

            }

            return obj;
        }

        protected override int xoa()
        {
            int obj = 0;
            try
            {
                ac.xoa(gv.GetFocusedRowCellValue("id").ToString());
                hs.add(gv.GetFocusedRowCellValue("id").ToString(), "Xóa Tài Khoản");
                mes.done();
                obj = 1;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

            return obj;
        }

        protected override int sua()
        {
            int obj = 0;
            try
            {
                if (Biencucbo.idnv != "admin")
                {
                    if (gv.GetFocusedRowCellValue("id").ToString() != Biencucbo.idnv)
                    {
                        return 0;
                    }
                }
                    Biencucbo.hdong = 1;
                Biencucbo.obj = 0;
                Biencucbo.ma = gv.GetFocusedRowCellValue("id").ToString();
                f_themaccount frm = new f_themaccount();
                frm.ShowDialog();
                obj = Biencucbo.obj;
            }
            catch (Exception ex)
            {

            }

            return obj;
        }

        private void gv_Click(object sender, EventArgs e)
        {
            dble = false;
        }

        private void gv_DoubleClick(object sender, EventArgs e)
        {
            dble = true;
        }

        private void gv_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (dble)
                if (sua() == 1)
                    load();
        }
    }
}