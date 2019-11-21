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
using DevExpress.XtraLayout.Utils;

namespace QLNS
{
    public partial class f_themaccount : frm_themds
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        t_account ac = new t_account();
        t_history hs = new t_history();
        private string _key;
        private int _hdong;
        public f_themaccount()
        {
            InitializeComponent();
            sluphong.Properties.DataSource = (from a in dbData.phongbans where a.phanquyen == true select a);
            
        }

        private void layphong()
        {
            try
            {
                lblphong.Text = (from a in dbData.phongbans select a).Single(t => t.id == sluphong.Text).phong;
            }
            catch (Exception ex)
            {
                lblphong.Text = "";
            }
        }

        protected override void load()
        {
            _hdong = Biencucbo.hdong;
            if (_hdong == 1)
            {
                try
                {
                    _key = Biencucbo.ma;
                    var lst = (from a in dbData.accounts select a).Single(t => t.id == _key);
                    txtid.ReadOnly = true;
                    txtuname.ReadOnly = true;
                    txtid.Text = lst.id;
                    txtname.Text = lst.name;
                    txtuname.Text = lst.uname;
                    sluphong.Text = lst.phongban;
                    layphong();
                    checkactive.Checked = Convert.ToBoolean(lst.IsActived);
                    if (Biencucbo.idnv == "admin")
                    {
                        txtpassold.Enabled = false;
                        txtpassold.Text = md5.Decrypt(lst.pass);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                txtpassold.Visible = false;
                layoutControlItem5.Visibility = LayoutVisibility.Never;
            }
        }

        protected override void huy()
        {
            Biencucbo.obj = 0;
            Close();

        }

        protected override void luu()
        {
            try
            {
                if (txtid.Text == "" || txtname.Text == "" || txtuname.Text == "" || sluphong.Text == "")
                {
                    mes.thongtinchuadaydu();
                    return;
                }
                if (txtpassnew.Text != txtpassrenew.Text)
                {
                    XtraMessageBox.Show("Mật khẩu xác Nhận Không đúng, vui lòng kiểm tra lại");
                    return;
                }
                if (_hdong == 0)
                {
                    if ((from a in dbData.accounts where a.id == txtid.Text || a.uname == txtuname.Text select a).Count() > 0)
                    {
                        XtraMessageBox.Show("Tài khoản này đã tồn tại, Không thể tạo mới", "Thông Báo");
                        return;
                    }
                    ac.moi(txtid.Text, txtuname.Text, txtname.Text, md5.Encrypt(txtpassnew.Text), sluphong.Text, "00", checkactive.Checked);
                    hs.add(txtid.Text, "Thêm tài Khoản");
                    mes.done();
                    Biencucbo.obj = 1;
                    Close();
                }
                else
                {
                    if ((from a in dbData.accounts where a.pass == md5.Encrypt(txtpassold.Text) select a).Count() == 0)
                    {
                        XtraMessageBox.Show("mật khẩu cũ không đúng, vui lòng kiểm tra lại", "Thông báo");
                        return;
                    }
                    string passnew;
                    if (txtpassnew.Text == "")
                    {
                        passnew = txtpassold.Text;
                    }
                    else
                    {
                        passnew = txtpassnew.Text;
                    }
                    ac.sua(txtid.Text,txtname.Text,md5.Encrypt(passnew),sluphong.Text,"00",checkactive.Checked);
                    hs.add(txtid.Text,"Sửa Tài Khoản");
                    mes.done();
                    Biencucbo.obj = 1;
                    Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void sluphong_Popup(object sender, EventArgs e)
        {
            custom.popupslu<f_dsphongban>(sender, e, sluphong);
        }

        private void f_themaccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                sluphong.Properties.DataSource = (from a in new KetNoiDBDataContext().phongbans where a.phanquyen == true select a);
        }

        private void sluphong_EditValueChanged(object sender, EventArgs e)
        {
            layphong();

        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtname.Text = (from a in dbData.nhansus select a).Single(t => t.id == txtid.Text).hovaten;
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}