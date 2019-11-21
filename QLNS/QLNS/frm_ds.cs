using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using  BUS;
using DAL;


namespace QLNS
{
    public partial class frm_ds : DevExpress.XtraEditors.XtraForm
    {
        private PhanQuyen2 QuyenDangChon { get; set; }
        public frm_ds()
        {
            InitializeComponent();


        }
    protected override void OnActivated(EventArgs e)
        {
            QuyenDangChon = Biencucbo.QuyenDangChon;
            base.OnActivated(e);
            var q = QuyenDangChon;
            if (q == null) return;

            if ((bool)q.Them)
            {
                btnthem.Visibility = BarItemVisibility.Always;
            }
            else
            {
                btnthem.Visibility = BarItemVisibility.Never;
            }
            if ((bool)q.Sua)
            {
                btnsua.Visibility = BarItemVisibility.Always;
            }
            else
            {
                btnsua.Visibility = BarItemVisibility.Never;
            }
            if ((bool)q.Xoa)
            {
                btnxoa.Visibility = BarItemVisibility.Always;
            }
            else
            {
                btnxoa.Visibility = BarItemVisibility.Never;
            }
        }
        protected virtual int them()
        {
            return 0;
        }

        protected virtual int sua()
        {
            return 0;
        }

        protected virtual int xoa()
        {
            return 0;
        }

        protected virtual int load()
        {
            return 1;
        }

        private void btnthem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (them() == 1)
                load();
        }

        private void btnsua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            if (sua() == 1)
            {
                load();
            }
        }

        private void btnxoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có muốn xóa không?", "Thông Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                if (xoa() == 1)
                {
                    load();
                }
            }
        }

        private void frmbtnds_Load(object sender, EventArgs e)
        {
            // 1: ds nhân viên
            // 2: ds default
            if (load() == 1)
                btnin.Visibility = BarItemVisibility.Never;
        }

        private void frmbtnds_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                if(btnsua.Visibility == BarItemVisibility.Never)
                    return;
                if (sua() == 1)
                    load();
            }
            else if (e.KeyCode == Keys.F4)
            {
                if(btnthem.Visibility == BarItemVisibility.Never)
                    return;
                if (them() == 1)
                    load();
            }
            else if (e.KeyCode == Keys.F8)
            {
                if(btnxoa.Visibility == BarItemVisibility.Never)
                    return;
                if (xoa() == 1)
                    load();
            }
            else if (e.KeyCode == Keys.F5)
            {
                load();
            }

        }

        protected virtual int dieuchuyen()
        {
            return 1;
        }

        private void btndieuchuyen_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dieuchuyen() == 1)
                load();
        }
    }
}