using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DAL;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;

namespace QLNS
{
    public partial class f_dsphongban : frm_ds
    {
        t_history hs = new t_history();
        t_phongban p = new t_phongban();
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        public f_dsphongban()
        {
            InitializeComponent();
            
        }

        protected override int load()
        {
            using (dbData = new KetNoiDBDataContext())

            {
                gd.DataSource = dbData.phongbans;
                gv.BestFitColumns();
            }
            return 1;
        }

        protected override int them()
        {
            int obj = 0;
            try
            {
                Biencucbo.obj = 0;
                Biencucbo.hdong = 0;
                f_themphongban frm = new f_themphongban();
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
                Biencucbo.hdong = 1;
                Biencucbo.ma = gv.GetFocusedRowCellValue("key").ToString();
                f_themphongban frm = new f_themphongban();
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
                p.xoa(gv.GetFocusedRowCellValue("key").ToString());
                hs.add(gv.GetFocusedRowCellValue("id").ToString(),"Xóa Phòng ban");
                obj = 1;
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString());
            }

            return obj;
        }

        private bool dble;
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
            if(dble== true)
                if(sua() ==1)
                    load();
        }
    }
}