using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using BUS;

using DAL;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using QLNS.Properties;
using Lotus;


namespace QLNS
{
    public partial class f_main : RibbonForm
    {
        private KetNoiDBDataContext db = new KetNoiDBDataContext();
        t_todatatable _tTodatatable = new t_todatatable();
        readonly t_chucnang t_cn = new t_chucnang();


        public f_main()
        {
            InitializeComponent();
            defaultLookAndFeel1.LookAndFeel.SetSkinStyle(Biencucbo.skin);
        }

        private void OpenForm<T>()
        {
            var fm = MdiChildren.FirstOrDefault(f => f is T);
            if (fm == null)
            {
                fm = Activator.CreateInstance<T>() as Form; // tao đối tượng T thôi
                fm.MdiParent = this;
                fm.Show();
            }
            else
                fm.Activate();
        }

        private void f_main_Load(object sender, EventArgs e)
        {
            DangNhap();
            try
            {
                Show();
                OpenForm<f_dsnhanvien>();
            }
            catch
            {
                Application.Exit();
            }
        }


        private void DangNhap()
        {
            // dang xuat
            foreach (var form in MdiChildren)
                form.Close();
            db.Dispose();
            db = new KetNoiDBDataContext();

            // dang nhap
            var f = new f_login();

            try
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    WindowState = FormWindowState.Maximized;
                    if (Biencucbo.idnv.Trim() != "AD")
                    {
                        btnskinht.Visibility = BarItemVisibility.Never;
                    }

                    var lst = (from a in db.skins select a).Single(t => t.trangthai == true);
                    Biencucbo.skin = lst.tenskin;
                    defaultLookAndFeel1.LookAndFeel.SetSkinStyle(Biencucbo.skin);



                    var lst2 = (from a in db.donvis where a.id == Biencucbo.donvi select a.tendonvi).FirstOrDefault();
                    Biencucbo.tendvbc = lst2;

                    //btninfo_account.Caption =
                    //    LanguageHelper.TranslateMsgString("." + Name + "_btn_Wellcome", "Wellcome ") + Biencucbo.ten;
                    //btninfo_donvi.Caption = LanguageHelper.TranslateMsgString("." + Name + "_btn_DonVi", "Đơn vị ") +
                    //                        Biencucbo.donvi + "-" + Biencucbo.tendvbc;
                    //btninfo_phong.Caption = LanguageHelper.TranslateMsgString("." + Name + "_btn_BoPhan", "Bộ phận ") +
                    //                        Biencucbo.phongban;
                    //btnDb.Caption = Biencucbo.DbName;
                    //btnVersion.Caption = LanguageHelper.TranslateMsgString("." + Name + "_btn_Version", "Version ") +
                    //                     Assembly.GetExecutingAssembly().GetName().Version;

                    // duyet ribbon
                    duyetRibbon(ribbon);


                }
                else
                    Application.ExitThread();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }


        public void duyetRibbon(RibbonControl ribbonControl)
        {
            {
                foreach (RibbonPage page in ribbonControl.Pages)
                {
                    t_cn.moi(page.Name, page.Text, string.Empty);
                    foreach (RibbonPageGroup g in page.Groups)
                    {
                        t_cn.moi(g.Name, g.Text, page.Name);
                        bool showgrpage = false;
                        foreach (BarItemLink i in g.ItemLinks)
                        {
                            if (i.Item == btndxuat)
                            {
                                showquyen(i, true);
                                showgrpage = true;
                                continue;
                            }

                            t_cn.moi(i.Item.Name, i.Item.Caption, g.Name);

                            var quyen = db.PhanQuyen2s
                                    .FirstOrDefault(p => p.TaiKhoan == Biencucbo.phongban && p.ChucNang == i.Item.Name);

                            if (Biencucbo.phongban == "admin")
                            {
                                if (quyen == null)
                                {
                                    quyen = new PhanQuyen2();
                                    quyen.TaiKhoan = Biencucbo.phongban;
                                    quyen.ChucNang = i.Item.Name;

                                    quyen.Xem = quyen.Them = quyen.Sua = quyen.Xoa = true;

                                    db.PhanQuyen2s.InsertOnSubmit(quyen);
                                    db.SubmitChanges();
                                }
                            }



                            if (showquyen(i, quyen == null ? false : Convert.ToBoolean(quyen.Xem)))
                                showgrpage = true;
                            // luu vào tag của nút tren ribbon de xu ly sau
                            i.Item.Tag = quyen;


                            if (i.Item is BarSubItem)
                            {
                                var sub = i.Item as BarSubItem;
                                sub.Enabled = true;
                                foreach (BarItemLink y in sub.ItemLinks)
                                {
                                    t_cn.moi(y.Item.Name, y.Item.Caption, i.Item.Name);
                                    // lay quyen
                                    //quyen = db.PhanQuyen2s
                                    //    .FirstOrDefault(p => p.TaiKhoan == Biencucbo.idnv && p.ChucNang == y.Item.Name);
                                    quyen = db.PhanQuyen2s
                                        .FirstOrDefault(
                                            p => p.TaiKhoan == Biencucbo.phongban && p.ChucNang == y.Item.Name);

                                    // cheat tài khoản quan tri
                                    //if (Biencucbo.idnv == "AD")
                                    if (Biencucbo.phongban == "admin")
                                    {
                                        if (quyen == null)
                                        {
                                            quyen = new PhanQuyen2();
                                            //quyen.TaiKhoan = Biencucbo.idnv;
                                            quyen.TaiKhoan = Biencucbo.phongban;
                                            quyen.ChucNang = y.Item.Name;

                                            quyen.Xem = quyen.Them = quyen.Sua = quyen.Xoa = true;

                                            db.PhanQuyen2s.InsertOnSubmit(quyen);
                                            db.SubmitChanges();
                                        }
                                    }

                                    if (showquyen(y, quyen == null ? false : Convert.ToBoolean(quyen.Xem)))
                                        showgrpage = true;
                                    // luu vào tag của nút tren ribbon de xu ly sau
                                    y.Item.Tag = quyen;
                                }
                            }

                        }
                        g.Visible = showgrpage;
                    }
                }
            }
        }

        private bool showquyen(BarItemLink i, bool quyen)
        {
            if (quyen)
            {
                i.Item.Visibility = BarItemVisibility.Always;
                return true;
            }
            else
            {
                i.Item.Visibility = BarItemVisibility.Never;
                return false;
            }
        }

        private void btnmize_ItemClick(object sender, ItemClickEventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnnoicongtac_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            f_dsnoict frm = new f_dsnoict();
            frm.ShowDialog();
        }

        private void btnkhuvuc_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            f_dskhuvuc frm = new f_dskhuvuc();
            frm.ShowDialog();
        }

        private void btnphongban_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            f_dsphongban frm = new f_dsphongban();
            frm.ShowDialog();
        }

        private void btnchucvu_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            f_dschucvu frm = new f_dschucvu();
            frm.ShowDialog();
        }

        private void btnclose_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có muốn thoát chương trình không?", "Thông Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Application.Exit();
        }

        private void btnpquyen_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            f_phanquyenchucnang frm = new f_phanquyenchucnang();
            frm.ShowDialog();
        }

        private void btndxuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có muốn đăng xuất?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Hide();
                DangNhap();
                try
                {
                    Show();
                    OpenForm<f_dsnhanvien>();
                }
                catch
                {
                    Application.Exit();
                }
            }
        }

        private void btntaikhoan_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            f_account frm = new f_account();
            frm.ShowDialog();
        }

        private void btnhs_ItemClick(object sender, ItemClickEventArgs e)
        {
            f_history frm = new f_history();
            frm.ShowDialog();
        }

        private void btndsdieuchuyen_ItemClick(object sender, ItemClickEventArgs e)
        {
            f_dsdieuchuyen frm = new f_dsdieuchuyen();
            frm.ShowDialog();
        }
    }
}