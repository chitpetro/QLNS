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
using System.IO;
using System.Diagnostics;
using System.Transactions;
using DevExpress.CodeParser;
using DevExpress.XtraBars.Ribbon.ViewInfo;
using DevExpress.Utils.Win;
using QLNS.Properties;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraGrid.Views.Grid;

namespace QLNS
{
    public partial class f_themnhansu : frm_themds
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();

        t_todatatable _tTodatatable = new t_todatatable();
        t_nhansu ns = new t_nhansu();
        t_history hs = new t_history();
        private string _key = "";
        private string _tempkey = "";
        private bool dble = false;

        private int _hdong = 0;
        private string _ma = "";
        public byte[] fileanh = null;
        public byte[] file = null;

        public f_themnhansu()
        {
            InitializeComponent();
            txtphongban.Properties.DataSource = dbData.phongbans;
            txtchucvu.Properties.DataSource = dbData.dmchucvus;
        }

        private void laychucvu(string id, LabelControl cv)
        {
          
            try
            {
                cv.Text = (from a in  new KetNoiDBDataContext().dmchucvus select a).Single(t => t.id == id).chucvu;
            }
            catch (Exception ex)
            {
                cv.Text = "";
            }

        }



        private void txtphongban_EditValueChanged(object sender, EventArgs e)
        {
            layphongban(txtphongban.Text, lblphongban);


        }
        private void layphongban(string id, LabelControl cb)
        {
            try
            {
                cb.Text = (from a in new KetNoiDBDataContext().phongbans select a).Single(t => t.id == id).phong;

            }
            catch (Exception ex)
            {

                cb.Text = "";
            }

        }

        private void txtchucvu_EditValueChanged(object sender, EventArgs e)
        {
            laychucvu(txtchucvu.Text, lblchucvu);
        }


        protected override void load()
        {
            try
            {
                _hdong = Biencucbo.hdong;
                if (_hdong == 0)
                {
                    _tempkey = Biencucbo.idnv + Biencucbo.hostname + Biencucbo.IPaddress + Biencucbo.donvi +
                               DateTime.Now;
                    _key = md5.Encrypt(_tempkey);
                    gd.DataSource = dbData.filens.Where(x => x.keyns == _key); //gd.DataSource = ;
                }
                else
                {
                    _ma = Biencucbo.ma;
                    _key = _ma;
                    _tempkey = md5.Decrypt(_ma);

                   
                    var lst = (from a in dbData.nhansus select a).Single(t => t.key == _ma);
                    txtid.Text = lst.id;
                    txthovaten.Text = lst.hovaten;
                    custom.showdate(txtngaysinh, lst.ngaysinh.ToString());
                    txtquequan.Text = lst.quequan;
                    txtquoctich.Text = lst.quoctich;
                    txtcmnd.Text = lst.cmnd;
                    txtphongban.Text = lst.idphong;
                    txtchucvu.Text = lst.chucvu;
                    try
                    {
                        ImageConverter objfile = new ImageConverter();
                        hinhanh.Image = (Image)objfile.ConvertFrom(lst.hinhanh.ToArray());
                        fileanh = lst.hinhanh.ToArray();
                    }
                    catch
                    {


                    }
                    custom.showdate(txtngayvaolam, lst.ngayvaolam.ToString());
                    custom.showdate(txtngaynghiviec, lst.ngaynghiviec.ToString());
                    txthopdong.Text = lst.sohdld;
                    txtsdt.Text = lst.sodienthoai;
                    txtgioitinh.Text = lst.gioitinh;
                    txtemail.Text = lst.email;
                    txttinhtrang.Text = lst.tinhtrang;
                    txttieusu.Text = lst.tieusu;
                    txtmota.Text = lst.mota;
                    txtbangcap.Text = lst.bangcap;
                    gd.DataSource = lst.filens;
                    txtid.ReadOnly = true;
                }

            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.ToString());
                Close();

            }


        }

        public static byte[] converterhinhanh(Image x)
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(x, typeof(byte[]));
            return xByte;
        }

        protected override void luu()
        {
            if (txtid.Text == "" || txthovaten.Text == null)
            {
                XtraMessageBox.Show("Thông tin chưa đầy đủ không thể lưu", "Thông Báo");

            }
            if (_hdong == 0)
            {


                var lst = (from a in new KetNoiDBDataContext().nhansus where a.id == txtid.Text select a).Count();

                if (lst > 0)
                {
                    MessageBox.Show("Mã nhân viên bị trùng, không thể lưu", "Thông Báo");

                }

                try
                {

                    ns.themns(_key, txtid.Text, txthovaten.Text, txtngaysinh.DateTime, txtquequan.Text,
                        txtquoctich.Text,
                        txtcmnd.Text, txtphongban.Text, txtchucvu.Text, converterhinhanh(hinhanh.Image),
                        txtngayvaolam.DateTime,
                        txtngaynghiviec.DateTime, txthopdong.Text, txtsdt.Text, txtgioitinh.Text, txtemail.Text,
                        txttinhtrang.Text, txttieusu.Text, txtbangcap.Text,txtmota.Text);

                    //layoutControl1.Validate();
                    gv.CloseEditor();
                    gv.UpdateCurrentRow();
                    var c1 = dbData.filens.Context.GetChangeSet();
                    dbData.filens.Context.SubmitChanges();
                    hs.add(txtid.Text, "Thêm mới nhân sự");
                    Biencucbo.obj = 1;
                }
                catch
                    (Exception
                        ex)
                {
                    MessageBox.Show(ex.ToString());

                }

            }
            else
            {
                try
                {
                    ns.sua(_key, txthovaten.Text, txtngaysinh.DateTime, txtquequan.Text,
                        txtquoctich.Text,
                        txtcmnd.Text, txtphongban.Text, txtchucvu.Text, converterhinhanh(hinhanh.Image),
                        txtngayvaolam.DateTime,
                        txtngaynghiviec.DateTime, txthopdong.Text, txtsdt.Text, txtgioitinh.Text, txtemail.Text,
                        txttinhtrang.Text, txttieusu.Text,txtbangcap.Text,txtmota.Text);
                    //layoutControl1.Validate();
                    gv.CloseEditor();
                    gv.UpdateCurrentRow();
                    var c1 = dbData.filens.Context.GetChangeSet();
                    dbData.filens.Context.SubmitChanges();
                    hs.add(txtid.Text, "Sửa nhân sự");
                    Biencucbo.obj = 1;
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());

                }
            }
            huy();
        }

        protected override void huy()
        {
            Close();

        }





        private void f_themnhansu_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;

        }

        private void btnchonfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Title = "Chọn File";

            openfile.FilterIndex = 1;//chúng ta có All files là 1,exe là 2
            openfile.RestoreDirectory = true;
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                byte[] file3 = null;

                if (!string.IsNullOrEmpty(openfile.FileName))
                {
                    using (var stream = new FileStream(openfile.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (var reader = new BinaryReader(stream))
                        {
                            file3 = reader.ReadBytes((int)stream.Length);
                        }
                    }
                }
                System.Data.Linq.Binary file2 = file3;

                var size = file3.Length / 1024;//kb

                gv.AddNewRow();

                var ct = gv.GetFocusedRow() as filen;

                ct.key = md5.Encrypt(_tempkey + DateTime.Now);
                ct.name = openfile.FileName.Substring(openfile.FileName.LastIndexOf('\\') + 1);
                ct.data = file2;
                ct.type = Path.GetExtension(openfile.FileName.Substring(openfile.FileName.LastIndexOf('\\') + 1));
                ct.size = size.ToString();
                ct.keyns = _key;
                gv.UpdateCurrentRow();
                gv.PostEditor();




            }
        }

        private void btntaifile_Click(object sender, EventArgs e)
        {
            try
            {
                var row = gv.GetFocusedRow() as filen;
                if (row == null) return;


                byte[] filedata = row.data.ToArray();

                savefile.FileName = row.name;
                string tmpPath = savefile.InitialDirectory;
                savefile.FilterIndex = 1;
                savefile.RestoreDirectory = true;
                string file3 = "";
                savefile.Filter = "Files|*" + row.type;
                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(savefile.FileName /*+ lst.diengiai*/, filedata);
                    file3 = savefile.FileName;
                }
                else
                    return;
                MessageBox.Show("Tải về Thành Công", "Thông Báo");
                if (MessageBox.Show("Bạn Có Muốn Mở File Không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                string tmpPath2 = Application.StartupPath + "\\tmp";
                if (!Directory.Exists(tmpPath2))
                    Directory.CreateDirectory(tmpPath2);

                Process.Start(file3);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error");
            }
        }
        SaveFileDialog savefile = new SaveFileDialog();

        private void btnxoafile_Click(object sender, EventArgs e)
        {
            try
            {
                gv.DeleteRow(gv.FocusedRowHandle);
            }
            catch
            {
                MessageBox.Show("Vui lòng chọn File chi tiết cần xóa", "Thông Báo!");

            }
        }

        private void gd_Click(object sender, EventArgs e)
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
                try
                {
                    var row = gv.GetFocusedRow() as filen;
                    if (row == null) return;
                    //string a1 = md5.Decrypt(row.key);
                    
                    byte[] filedata = row.data.ToArray();

                    string tmpPath = Application.StartupPath + "\\tmp";
                    if (!Directory.Exists(tmpPath))
                        Directory.CreateDirectory(tmpPath);

                    string tmpFile = tmpPath + "\\"/* + a1 */+ row.name;
                    File.WriteAllBytes(tmpFile, filedata);

                    Process.Start(tmpFile);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.ToString(), "Error");
                }
            }
        }

        private void gv_RowDeleting(object sender, DevExpress.Data.RowDeletingEventArgs e)
        {
            try
            {
                filen ct = (from c in dbData.filens select c).Single(x => x.key == gv.GetFocusedRowCellValue("key").ToString());
                dbData.filens.DeleteOnSubmit(ct);
            }
            catch
            {
            }
        }

        private void txtphongban_Popup(object sender, EventArgs e)
        {

            custom.popupslu<f_dsphongban>(sender, e, txtphongban);

            //var popupControl = sender as IPopupControl;
            //var button = new SimpleButton
            //{
            //    Image = Resources.add_16x16,
            //    Text = "Edit",
            //    BorderStyle = BorderStyles.NoBorder
            //};

            //button.Click += btnthemphong;

            //button.Location = new Point(5, popupControl.PopupWindow.Height - button.Height - 5);
            //popupControl.PopupWindow.Controls.Add(button);
            //button.BringToFront();

            //var edit = sender as SearchLookUpEdit;
            //var popupForm = edit.GetPopupEditForm();
            //popupForm.KeyPreview = true;
            //popupForm.KeyUp -= txtphongban_KeyUp;
            //popupForm.KeyUp += txtphongban_KeyUp;

        }
        public void btnthemphong(object sender, EventArgs e)
        {
            f_dsphongban frm = new f_dsphongban();
            frm.ShowDialog();
            var lst = (from a in new KetNoiDBDataContext().phongbans select a).ToList();
            var frm2 = new KetNoiDBDataContext().phongbans;
        }

        private void txtchucvu_Popup(object sender, EventArgs e)
        {
            custom.popupslu<f_dschucvu>(sender, e, txtchucvu);
        }


        private void f_themnhansu_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F5)
            {
                txtphongban.Properties.DataSource = new KetNoiDBDataContext().phongbans;
                txtchucvu.Properties.DataSource = new KetNoiDBDataContext().dmchucvus;

            }
        }
    }
}