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
    public partial class f_dsnoict : frm_ds
    {
        t_noicongtac ct = new t_noicongtac();
        t_history hs = new t_history();
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        private bool dble = false;
        public f_dsnoict()
        {
            InitializeComponent();
        }

        protected override int load()
        {
            dbData = new KetNoiDBDataContext();

            try
            {

                gd.DataSource = dbData.r_noicongtacs;
                gv.ClearGrouping();
                gv.Columns["khuvuc"].GroupIndex = 1;
                gv.ExpandAllGroups();
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
            Biencucbo.hdong = 0;
            Biencucbo.obj = 0;
            f_themnoict frm = new f_themnoict();
            frm.ShowDialog();
            obj = Biencucbo.obj;
            return obj;
        }

        protected override int sua()
        {
            int obj = 0;

            Biencucbo.obj = 0;
            Biencucbo.hdong = 1;
            Biencucbo.ma = gv.GetFocusedRowCellValue("key").ToString();
            f_themnoict frm = new f_themnoict();
            frm.ShowDialog();
            obj = Biencucbo.obj;
            return obj;
        }

        protected override int xoa()
        {
            int obj = 0;
            try
            {
                ct.xoa(gv.GetFocusedRowCellValue("id").ToString());
                hs.add(gv.GetFocusedRowCellValue("id").ToString(),"Xóa Nơi Công Tác");
                mes.done();
                obj = 1;
            }
            catch (Exception ex)
            {
               
                MessageBox.Show(ex.ToString());
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
            if (btnsua.Visibility == BarItemVisibility.Never)
                return;
            if (dble)
                if (sua() == 1)
                    load();
        }
    }
}