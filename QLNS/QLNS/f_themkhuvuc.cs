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
    public partial class f_themkhuvuc : frm_themds
    {
        t_khuvuc kv = new t_khuvuc();
        t_history hs = new t_history();
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        private string _key = "";
        private int _hdong = 0;
        public f_themkhuvuc()
        {
            InitializeComponent();
        }

        protected override void load()
        {
            _hdong = Biencucbo.hdong;
            if (Biencucbo.hdong == 0)
            {
                _key = md5.Encrypt(md5.laykey());
            }
            else
            {
                _key = Biencucbo.ma;
                try
                {
                    var lst = (from a in dbData.khuvucs select a).Single(t => t.key == _key);
                    txtid.Text = lst.id;
                    txtkhuvuc.Text = lst.tenkhuvuc;
                    txtid.ReadOnly = true;
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        protected override void huy()
        {
            Close();
            
        }

        protected override void luu()
        {
            if (txtid.Text == "" || txtkhuvuc.Text == "")
            {
                mes.thongtinchuadaydu();
                return;
            }
            if (_hdong == 0)
            {
                if ((from a in dbData.khuvucs where a.id == txtid.Text select a).Count() > 0)
                {
                    mes.trunglap("Mã Khu Vực " + txtid.Text);
                    return;
                }
                try
                {
                    kv.them(_key,txtid.Text,txtkhuvuc.Text);
                    hs.add(txtid.Text,"Thêm Khu Vực");
                    Biencucbo.obj = 1;
                    mes.done();
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                try
                {
                    kv.sua(_key,txtkhuvuc.Text);
                    hs.add(txtid.Text,"Sửa Khu Vực");
                    Biencucbo.obj = 1;
                    mes.done();
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show(ex.ToString());
                }
            }
            Close();
        }
        
    }
}