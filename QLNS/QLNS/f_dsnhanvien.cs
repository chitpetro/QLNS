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
using DevExpress.XtraGrid.Views.Grid;
using DAL;
using DevExpress.DataAccess.Sql;
using BUS;
using GUI;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraReports.UI;

namespace QLNS
{
    public partial class f_dsnhanvien : frm_dsribbon
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        t_nhansu ns = new t_nhansu();
        t_history hs = new t_history();

        public f_dsnhanvien()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        protected override void print()
        {
           r_dsnhanvien xtraDsnhanvien = new r_dsnhanvien();
            Biencucbo.thoigian = cbothoigian.Text;
            xtraDsnhanvien.DataSource = db.LayDanhSachNhanSu(tungay,denngay);
            xtraDsnhanvien.ShowPreviewDialog();
        }

        protected override int xoa()
        {
            int obj = 0;
            try
            {
                db = new KetNoiDBDataContext();
                ns.xoa(gv.GetFocusedRowCellValue("key").ToString());
                hs.add(gv.GetFocusedRowCellValue("id").ToString(), "Xóa nhân sự");
                obj = 1;
                XtraMessageBox.Show("Done!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return obj;
        }


        protected override int dieuchuyen()
        {
            int obj = 0;
            try
            {
                Biencucbo.obj = 0;
                Biencucbo.manhansu = gv.GetFocusedRowCellValue("id").ToString();
                f_dsdieuchuyenct frm = new f_dsdieuchuyenct();
                frm.ShowDialog();
                obj = Biencucbo.obj;
             
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            return obj;
        }



        protected override int load()
        {
            laydsd();
            return 1;
        }

        protected override void nghiphep()
        {
            try
            {
                f_dsnghiphep frm = new f_dsnghiphep();
                Biencucbo.manhansu = gv.GetFocusedRowCellValue("id").ToString();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                
            }
        }
        protected override int them()
        {
            int obj = 0;
            try
            {

                Biencucbo.hdong = 0;
                Biencucbo.obj = 0;
                f_themnhansu frm = new f_themnhansu();
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

                Biencucbo.obj = 0;
                Biencucbo.ma = gv.GetFocusedRowCellValue("key").ToString();
                Biencucbo.hdong = 1;
                f_themnhansu frm = new f_themnhansu();
                frm.ShowDialog();
                obj = Biencucbo.obj;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());

            }
            return obj;
        }

        private bool dble = false;
        private void gv_Click(object sender, EventArgs e)
        {
            dble = false;
        }

        private void gv_DoubleClick(object sender, EventArgs e)
        {
            dble = true;
        }

        private void gv_RowClick(object sender, RowClickEventArgs e)
        {

            if (dble)
                if (sua() == 1)
                    load();
        }

        private void gv_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle == view.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.Green;
                e.Appearance.ForeColor = Color.White;
            }
        }

        private void gv_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            
        }

        private DateTime tungay;
        private DateTime denngay;
        private void laydsd()
        {
            tungay = cbothoigian.DateTime;
            denngay = new DateTime(cbothoigian.DateTime.Year,cbothoigian.DateTime.Month ,DateTime.DaysInMonth(cbothoigian.DateTime.Year, cbothoigian.DateTime.Month));
            db = new KetNoiDBDataContext();
            try
            {
                gd.DataSource = db.LayDanhSachNhanSu(tungay,denngay);
                gd1.DataSource = gd.DataSource;
                gv.ClearGrouping();
                gv.Columns["noicongtac"].GroupIndex = 1;
                gv.Columns["phong"].GroupIndex = 2;
                gv.ExpandAllGroups();
                gv.BestFitColumns();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private void cbthoigian_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbothoigian.DateTime = DateTime.Now;
            laydsd();
        }

        private void cbothoigian_EditValueChanged(object sender, EventArgs e)
        {
            laydsd();
        }

        private void f_dsnhanvien_Load(object sender, EventArgs e)
        {
            cbothoigian.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            
        }
    }
}