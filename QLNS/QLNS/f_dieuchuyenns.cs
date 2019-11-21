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
    public partial class f_dieuchuyenns : frm_themds
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        t_dieuchuyen dc = new t_dieuchuyen();
        t_history hs = new t_history();
        private int _hdong;
        private string _key;
        private string _idnv;
        private DateTime _ngay;
        private int _so;
        public f_dieuchuyenns()
        {
            InitializeComponent();
            txtnoidc.Properties.DataSource = dbData.noicts;
        }

        private void layct(string txt, LabelControl lbl)
        {
            try
            {
                var lst = (from a in dbData.noicts select a).Single(t => t.id == txt);
                lbl.Text = lst.noicongtac;
            }
            catch (Exception ex)
            {
                lbl.Text = "";
            }
        }

        private void layten()
        {
            try
            {
                var lst2 = (from a in dbData.nhansus select a).Single(t => t.id == _idnv);
                lblinfo.Text = "Mã Nhân Viên: " + lst2.id + " - Họ Và Tên: " + lst2.hovaten;
            }
            catch
            {
                lblinfo.Text = "";
            }
        }
        protected override void load()
        {
            _hdong = Biencucbo.hdong;
            if (_hdong == 0)
            {
                _key = md5.Encrypt(md5.laykey());
                _idnv = Biencucbo.manhansu;
                try
                {
                    var lst = (from a in dbData.dieuchuyennhansus where a.idnv == _idnv select a.so).Max();
                    var lst2 = (from a in dbData.dieuchuyennhansus where a.so == lst select a).Single();
                    _so = int.Parse(lst.ToString());
                    txtnoict.Text = lst2.mact_dc;
                    layct(txtnoict.Text, lblnoict);
                }
                catch
                {
                    _so = 0;
                    lblnoict.Text = "";
                    txtnoict.Text = "N/A";
                }
                _ngay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                txtngaydc.DateTime = _ngay;
                layten();
            }
            else
            {
                _key = Biencucbo.ma;
                try
                {
                    var lst = (from a in dbData.dieuchuyennhansus select a).Single(t => t.key == _key);
                    txtnoict.Text = lst.mact_ht;
                    layct(txtnoict.Text, lblnoict);
                    txtnoidc.Text = lst.mact_dc;
                    layct(txtnoidc.Text,lblnoidc);
                    txtngaydc.DateTime = DateTime.Parse(lst.ngaydc.ToString());

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
              if (txtnoidc.Text == "" || txtngaydc.Text == "")
                {
                    mes.thongtinchuadaydu();
                    return;
                }
            if (_hdong == 0)
            {

                try
                {

                    dc.them(_key, _idnv, txtnoict.Text, txtnoidc.Text, txtngaydc.DateTime, _ngay, _so + 1);
                    hs.add(_idnv, "Thêm Điều Chuyển Nhân Sự");
                    Biencucbo.obj = 1;
                    mes.done();
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

                    dc.sua(_key,  txtnoidc.Text, txtngaydc.DateTime);
                    hs.add(_idnv, "Sửa Điều Chuyển Nhân Sự");
                    Biencucbo.obj = 1;
                    mes.done();
                    huy();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void txtnoidc_EditValueChanged(object sender, EventArgs e)
        {
            layct(txtnoidc.Text, lblnoidc);
        }

        private void txtnoidc_Popup(object sender, EventArgs e)
        {
            custom.popupslu<f_dsnoict>(sender, e, txtnoidc);
        }

        private void f_dieuchuyenns_Load(object sender, EventArgs e)
        {
            Text = "Điều Chuyển Nhân Sự " + custom.laytenns(Biencucbo.manhansu);
        }
    }



}