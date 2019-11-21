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

namespace QLNS
{
    public partial class frm_form : DevExpress.XtraEditors.XtraForm
    {
        public frm_form()
        {
            InitializeComponent();

            this.btnmo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnmo_ItemClick);
            this.btnthem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnthem_ItemClick);
            this.btnluu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnluu_ItemClick);
            this.btnsua.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnsua_ItemClick);
            this.btnxoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnxoa_ItemClick);
            this.btnreload.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnreload_ItemClick);
            

        }

        protected virtual void loadthem()
        {
            
        }
        protected virtual void loadluu()
        {

        }

        protected virtual void loadxoa()
        {
            
        }

        private void nthem()
        {
            btnmo.Enabled = false;
            btnthem.Enabled = false;
            btnluu.Enabled = true;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnreload.Enabled = true;
            btnin.Enabled = false;
            loadthem();
        }
        private void nload()
        {
            btnmo.Enabled = true;
            btnthem.Enabled = true;
            btnluu.Enabled = false;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnreload.Enabled = false;
            btnin.Enabled = true;
            loadluu();

        }

        private void nxoa()
        {
            btnmo.Enabled = true;
            btnthem.Enabled = true;
            btnluu.Enabled = false;
            btnsua.Enabled = false;
            btnxoa.Enabled = true;
            btnreload.Enabled = false;
            btnin.Enabled = true;
            loadluu();
            loadxoa();
        }
        protected virtual bool mo()
        {
            return false;
            
        }
        protected virtual bool them()
        {
            return false;
        }
        protected virtual bool luu()
        {
            return false;
        }
        protected virtual bool sua()
        {
            return false;
        }
        protected virtual bool xoa()
        {
            return true;
        }
        protected virtual bool reload()
        {
            return false;
        }


        protected virtual bool print()
        {
            return true;
        }

        private void btnxoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (XtraMessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (xoa())
                    nxoa();
            }
        }
        private void btnmo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (mo())
                nload();
        }
        private void btnthem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (them())
                nthem();
        }
        private void btnluu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (luu())
                nload();
        }
        private void btnsua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (sua())
                nthem();
        }
        private void btnreload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (reload())
                nload();
        }

        
    }
}