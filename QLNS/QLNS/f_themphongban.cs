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

namespace QLNS
{
    public partial class f_themphongban : frm_themds
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        t_phongban p = new t_phongban();
        private string _key = "";
        private int _hdong;
        t_history hs = new t_history();
        public f_themphongban()
        {
            InitializeComponent();
        }

        protected override void load()
        {
            _hdong = Biencucbo.hdong;
            if (_hdong == 0)
            { _key = md5.Encrypt(md5.laykey()); }
            if (_hdong == 1)
            {
                _key = Biencucbo.ma;
                var lst = (from a in dbData.phongbans select a).Single(t => t.key == _key);
                txtid.Text = lst.id;
                txtphong.Text = lst.phong;
                txtid.ReadOnly = true;
                checkpq.Checked = Convert.ToBoolean(lst.phanquyen);
            }
        }

        protected override void huy()
        {
            Close();
        }

        protected override void luu()
        {
            if (txtid.Text == "" || txtphong.Text == "")
            {
                mes.thongtinchuadaydu();
                return;
            }
            if (_hdong == 0)
            {
                using (dbData = new KetNoiDBDataContext())
                {
                    var lst = (from a in dbData.phongbans where a.id == txtid.Text select a).Count();
                    if (lst > 0)
                    {
                        mes.trunglap("Mã Phòng " + txtid);
                        return;
                    }

                    p.them(_key, txtid.Text, txtphong.Text,checkpq.Checked);
                    hs.add(txtid.Text,"Thêm Phòng Ban");
                    Biencucbo.obj = 1;
                }
            }
            else
            {
                using (dbData = new KetNoiDBDataContext())
                {
                    p.sua(_key, txtphong.Text, checkpq.Checked);
                    hs.add(txtid.Text,"Sửa Phòng Ban");
                    Biencucbo.obj = 1;
                }
            }
            huy();

        }
    }
}