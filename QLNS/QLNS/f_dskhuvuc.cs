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
    public partial class f_dskhuvuc : frm_ds
    {
        t_khuvuc kv = new t_khuvuc();
        t_history hs = new t_history();
        t_todatatable _tTodatatable = new t_todatatable();
        private bool dble = false;
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        public f_dskhuvuc()
        {
            InitializeComponent();
        }

        protected override int load()
        {
            int obj = 1;
            try
            {
                using (dbData = new KetNoiDBDataContext())
                {
                    gd.DataSource = _tTodatatable.addlst((from a in dbData.khuvucs select a).ToList());
                    gv.BestFitColumns();
             
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return obj;
        }

        protected override int them()
        {
            int obj = 0;
            try
            {
                Biencucbo.hdong = 0;
                Biencucbo.obj = 0;
                f_themkhuvuc frm  =new f_themkhuvuc();
                frm.ShowDialog();
                obj = Biencucbo.obj;
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
                Biencucbo.hdong = 1;
                Biencucbo.obj = 0;
                Biencucbo.ma = gv.GetFocusedRowCellValue("key").ToString();
                f_themkhuvuc frm = new f_themkhuvuc();
                frm.ShowDialog();
                obj = Biencucbo.obj;
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString());
            }
            return obj;
        }

        protected override int xoa()
        {
            int obj = 0;
            try
            {
                kv.xoa(gv.GetFocusedRowCellValue("key").ToString());
                hs.add(gv.GetFocusedRowCellValue("id").ToString(),"Xóa Khu Vực");
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