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
    public partial class f_themnoict : frm_themds
    {
        //KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        t_noicongtac ct = new t_noicongtac();
        t_history hs = new t_history();
        private string _key = "";
        private int _hdong = 0;
        public f_themnoict()
        {
            InitializeComponent();
            txtkhuvuc.Properties.DataSource = new KetNoiDBDataContext().khuvucs;
        }

        private void laytenkv(string id, LabelControl kvControl)
        {
            try
            {
                kvControl.Text = (from a in new KetNoiDBDataContext().khuvucs select a).Single(t => t.id == id).tenkhuvuc;
            }
            catch (Exception ex)
            {
                kvControl.Text = "";
                MessageBox.Show(ex.ToString());
            }
        }
        private void f_themnoict_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                txtkhuvuc.Properties.DataSource = new KetNoiDBDataContext().khuvucs;
            }
        }

        private void txtkhuvuc_EditValueChanged(object sender, EventArgs e)
        {
            laytenkv(txtkhuvuc.Text, lblkhuvuc);
        }

        private void txtkhuvuc_Popup(object sender, EventArgs e)
        {
            custom.popupslu<f_dskhuvuc>(sender, e, txtkhuvuc);
        }

        protected override void load()
        {
            _hdong = Biencucbo.hdong;

            if (_hdong == 0)
            {
                _key = md5.Encrypt(md5.laykey());
                
            }
            else
            {
                _key = Biencucbo.ma;
                var lst = (from a in new KetNoiDBDataContext().noicts select a).Single(t => t.key == _key);
                txtid.Text = lst.id;
                txtnoicongtac.Text = lst.noicongtac;
                txtdiachi.Text = lst.diachi;
                txtkhuvuc.Text = lst.khuvuc;
                laytenkv(txtkhuvuc.Text, lblkhuvuc);
                txtghichu.Text = lst.ghichu;
                txtid.ReadOnly = true;
            }
        }

        protected override void luu()
        {
            if (txtid.Text == "" || txtnoicongtac.Text == "")
            {
                mes.thongtinchuadaydu();
                return;
            }
            if (_hdong == 0)
            {
                if ((from a in new KetNoiDBDataContext().noicts where a.id == txtid.Text select a).Count() > 0)
                {
                    mes.trunglap("Mã " + txtid.Text);
                    return;
                }

                try
                {
                    ct.them(_key, txtid.Text, txtnoicongtac.Text, txtghichu.Text, txtkhuvuc.Text, txtdiachi.Text);
                    hs.add(txtid.Text, "Thêm Nơi Công Tác");
                    mes.done();
                    Biencucbo.obj = 1;
                    huy();
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
                    ct.sua(_key, txtnoicongtac.Text, txtghichu.Text, txtkhuvuc.Text, txtdiachi.Text);
                    hs.add(txtid.Text, "Sửa Nơi Công Tác");
                    mes.done();
                    Biencucbo.obj = 1;
                    huy();
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
    }
}