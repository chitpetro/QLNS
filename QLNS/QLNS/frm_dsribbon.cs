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
using DevExpress.XtraBars.Ribbon;

namespace QLNS
{
    public partial class frm_dsribbon : RibbonForm
    {

        public frm_dsribbon()
        {
            InitializeComponent();


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
            load();
            // 1: ds nhân viên
            // 2: ds default
            //if (load() == 1)
            //    btnin.Visibility = BarItemVisibility.Never;
        }

        private void frmbtnds_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                if (sua() == 1)
                    load();
            }
            else if (e.KeyCode == Keys.F4)
            {
                if (them() == 1)
                    load();
            }
            else if (e.KeyCode == Keys.F8)
            {
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

        protected virtual void print()
        {
            
        }
        private void btnin_ItemClick(object sender, ItemClickEventArgs e)
        {
            print();
        }

        protected virtual void nghiphep()
        {
            
        }
        private void btnnghiphep_ItemClick(object sender, ItemClickEventArgs e)
        {
            nghiphep();
        }
    }
}