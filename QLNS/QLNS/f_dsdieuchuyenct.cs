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
using DevExpress.XtraEditors;
using DAL;

namespace QLNS
{
    public partial class f_dsdieuchuyenct : frm_btnmo
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        t_dieuchuyen dc = new t_dieuchuyen();

        public f_dsdieuchuyenct()
        {
            InitializeComponent();
        }

        protected override void search()
        {
            load();
        }

        protected override void searchall()
        {
            gd.DataSource = from a in dbData.r_dieuchuyennhansus
                             where a.idnv == Biencucbo.manhansu
                             select a;
            gv.BestFitColumns();
        }

        protected override void load()
        {
            gd.DataSource = from a in dbData.r_dieuchuyennhansus
                            where
                                a.idnv == Biencucbo.manhansu && a.ngaydc >= DateTime.Parse(tungay.EditValue.ToString()) &&
                                a.ngaydc <= DateTime.Parse(denngay.EditValue.ToString())
                            select a;
            gv.BestFitColumns();
        }

        private void f_dsdieuchuyenct_Load(object sender, EventArgs e)
        {
            this.Text = "Danh Sách Điều Chuyển Nhân Sự " + custom.laytenns(Biencucbo.manhansu);
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            Biencucbo.hdong = 0;
            f_dieuchuyenns frm = new f_dieuchuyenns();
            frm.ShowDialog();
            load();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (XtraMessageBox.Show("Bạn Có Muốn Xóa?", "Thông Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    dc.xoa(gv.GetFocusedRowCellValue("key").ToString());
                    load();
                    Biencucbo.obj = 1;
                    mes.done();
                    
                }
            }
            catch (Exception ex)
            {
                
            }
        }
    }

}