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
    public partial class frm_themds : DevExpress.XtraEditors.XtraForm
    {
        public frm_themds()
        {
            InitializeComponent();
        }

        protected virtual void load()
        {

        }

        protected virtual void luu()
        {

        }

        protected virtual void huy()
        {

        }
        private void btnluu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            luu();
        }

        private void frmbtnthemds_Load(object sender, EventArgs e)
        {
            load();
        }

        private void btnhuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            huy();
        }

        private void frmbtnthemds_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control)
            {
                if(e.KeyCode == Keys.S)
                    luu();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                huy();
            }
        }
    }
}