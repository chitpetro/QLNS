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
using BUS;
using DAL;


namespace QLNS
{
    public partial class f_dsnghiphep : frm_btnmo
    {

        t_history hs = new t_history();
        t_nghiphep np = new t_nghiphep();
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        private bool dble;
        private string _idnv;
        public f_dsnghiphep()
        {
            InitializeComponent();

        }

        protected override void search()
        {
            gd.DataSource = dbData.LayDsNghiPhep(DateTime.Parse(tungay.EditValue.ToString()), _idnv, DateTime.Parse(denngay.EditValue.ToString()));
            gv.Columns["loai"].GroupIndex = 1;
            gv.ExpandAllGroups();


        }

        protected override void searchall()
        {
            gd.DataSource = dbData.LayDsNghiPhepall(_idnv);
            gv.Columns["loai"].GroupIndex = 1;
            gv.ExpandAllGroups();
        }

        protected override void load()
        {
            btnsearchall.Visibility = BarItemVisibility.Never;
            thoigian.EditValue = "Cả Năm";
            _idnv = Biencucbo.manhansu;
            gd.DataSource = dbData.LayDsNghiPhep(DateTime.Parse(tungay.EditValue.ToString()), _idnv, DateTime.Parse(denngay.EditValue.ToString()));
            gv.Columns["loai"].GroupIndex = 1;
            gv.ExpandAllGroups();
        }


        private void f_dsnghiphep_Load(object sender, EventArgs e)
        {

        }

        private int them()
        {
            int obj = 0;
            Biencucbo.manhansu = _idnv;
            Biencucbo.obj = 0;
            Biencucbo.hdong = 0;
            f_nghiphep frm = new f_nghiphep();
            frm.ShowDialog();
            obj = Biencucbo.obj;
            return obj;
        }
        private int sua()
        {
            try
            {
                int obj = 0;
                Biencucbo.manhansu = _idnv;
                Biencucbo.ma = gv.GetFocusedRowCellValue("key").ToString();
                Biencucbo.obj = 0;
                Biencucbo.hdong = 1;
                f_nghiphep frm = new f_nghiphep();
                frm.ShowDialog();
                obj = Biencucbo.obj;
                return obj;
            }
            catch (Exception ex)
            {

                return 0;
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {

            if(them() == 1)
                search();

        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if(sua() == 1)
                search();

        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn Có Muốn Xóa?", "Thông Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                np.xoa(gv.GetFocusedRowCellValue("key").ToString());
                hs.add(_idnv,"Xóa Nghỉ Phép");
                mes.done();
                search();}
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
            if (dble)
            {
                if(sua() == 1)
                    search();
            }
        }
    }
}