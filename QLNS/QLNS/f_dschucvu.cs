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
using BUS;
using DAL;
using DevExpress.XtraBars;

namespace QLNS
{
    public partial class f_dschucvu : frm_ds
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        t_history hs = new t_history();
        t_chucvu cv = new t_chucvu();
        private bool dble;
        public f_dschucvu()
        {
            InitializeComponent();
        }

        protected override int load()
        {
            try
            {
                using (dbData = new KetNoiDBDataContext())
                {
                    gd.DataSource = dbData.dmchucvus;
                    gv.BestFitColumns();
                }
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

            Biencucbo.obj = 0;
            Biencucbo.hdong = 0;
            f_themchucvu frm = new f_themchucvu();
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
            f_themchucvu frm = new f_themchucvu();
            frm.ShowDialog();
            obj = Biencucbo.obj;
            return obj;
        }

        protected override int xoa()
        {
            int obj = 0;

            try
            {
                cv.xoa(gv.GetFocusedRowCellValue("key").ToString());
                hs.add(gv.GetFocusedRowCellValue("id").ToString(),"Xóa Chức Vụ");
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
            if (dble == true)
                try
                {
                    if(sua()==1)
                        load();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
        }
    }
}