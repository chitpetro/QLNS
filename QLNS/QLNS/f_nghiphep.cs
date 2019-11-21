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

namespace QLNS
{
    public partial class f_nghiphep : frm_themds
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        t_history hs = new t_history();
        t_nghiphep np = new t_nghiphep();
        private string _key;
        private string _idnv;
        private int _hdong;
        public f_nghiphep()
        {
            InitializeComponent();
        }

        protected override void load()
        {
            _hdong = Biencucbo.hdong;
            _idnv = Biencucbo.manhansu;

            if (_hdong == 0)
            {
                _key = md5.Encrypt(md5.laykey());
                dtungay.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                ddenngay.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                cbohoso.Text = "Có đơn xin phep";
                cboloai.Text = "Nghỉ phép";
            }
            else
            {
                _key = Biencucbo.ma;
                var lst = (from a in dbData.nghipheps select a).Single(t => t.key == _key);
                dtungay.DateTime = lst.tungay.Value;
                ddenngay.DateTime = lst.denngay.Value;
                cbohoso.Text = lst.hoso;
                cboloai.Text = lst.loai;

            }
        }

        protected override void luu()
        {
            try
            {
                if (dtungay.Text == string.Empty || ddenngay.Text == string.Empty)
                {
                    mes.thongtinchuadaydu();
                    return;
                }
                if (ddenngay.DateTime < dtungay.DateTime)
                {
                    XtraMessageBox.Show("Thoi gian nghỉ phép chưa đúng, vui lòng kiểm tra lại");
                    return;
                }
                if (_hdong == 0)
                {
                    np.them(_key,dtungay.DateTime,ddenngay.DateTime,"",cboloai.Text,_idnv,cbohoso.Text);
                    hs.add(_idnv,"Thêm Nghỉ Phép");
                    Biencucbo.obj = 1;
                    mes.done();
                    Close();
                }
                else
                {
                    np.sua(_key,dtungay.DateTime,ddenngay.DateTime,"",cboloai.Text,cbohoso.Text);
                    hs.add(_idnv,"Sửa Nghỉ Phép");
                    Biencucbo.obj = 1;
                    mes.done();
                    Close();
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString());
            }
        }

        protected override void huy()
        {
            Biencucbo.obj = 0;
            Close();

        }
    }
}