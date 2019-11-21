using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using DevExpress.Skins;
using DevExpress.XtraEditors;
using BUS;
using CellValueChangedEventArgs = DevExpress.XtraTreeList.CellValueChangedEventArgs;
using GUI;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Columns;

namespace QLNS
{
    public partial class f_phanquyenchucnang : DevExpress.XtraEditors.XtraForm
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        public f_phanquyenchucnang()
        {
            InitializeComponent();
            gd.DataSource = (from a in dbData.phongbans where a.phanquyen == true select a);
            treeList1.ExpandAll();
            var skin = GridSkins.GetSkin(treeList1.LookAndFeel);
            skin.Properties[GridSkins.OptShowTreeLine] = true;
        }

        private void treeList1_CustomDrawNodeCell(object sender, DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs e)
        {
            if (e.Node.HasChildren)
            {
                e.Appearance.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
                e.Appearance.Options.UseTextOptions = true;
            }
        }
        private void NapChucNangNguoiDung()
        {
            dbData = new KetNoiDBDataContext();
            // lay user
            //var user = gridView1.GetFocusedRow() as account;
            //lay phong ban
            var phongban = gv.GetFocusedRow() as phongban;


            if (phongban == null) return;

            // lay danh sach quyen của user
            // var l = db.PhanQuyen2s.Where(t => t.TaiKhoan == user.id);
            var l = dbData.PhanQuyen2s.Where(t => t.TaiKhoan == phongban.id);


            var q = from c in dbData.ChucNangs
                    select new ObjPhanQuyen
                    {
                        MaChucNang = c.MaChucNang,
                        TenChucNang = c.TenChucNang,
                        ChucNangCha = c.ChucNangCha,
                        Xem = LayQuyen(0, l, c),
                        Them = LayQuyen(1, l, c),
                        Sua = LayQuyen(2, l, c),
                        Xoa = LayQuyen(3, l, c)
                    };

            treeList1.DataSource = q;
            treeList1.ExpandAll();
        }
        private bool LayQuyen(int index, IQueryable<PhanQuyen2> l, ChucNang c)
        {
            var b = false;
            if (index == 0)
            {
                var find = l.FirstOrDefault(q => q.ChucNang == c.MaChucNang);
                if (find == null) return false;

                return find.Xem == null ? false : Convert.ToBoolean(find.Xem);
            }
            if (index == 1)
            {
                var find = l.FirstOrDefault(q => q.ChucNang == c.MaChucNang);
                if (find == null) return false;

                return find.Them == null ? false : Convert.ToBoolean(find.Them);
            }
            if (index == 2)
            {
                var find = l.FirstOrDefault(q => q.ChucNang == c.MaChucNang);
                if (find == null) return false;

                return find.Sua == null ? false : Convert.ToBoolean(find.Sua);
            }
            if (index == 3)
            {
                var find = l.FirstOrDefault(q => q.ChucNang == c.MaChucNang);
                if (find == null) return false;

                return find.Xoa == null ? false : Convert.ToBoolean(find.Xoa);
            }
            return b;
        }

        private void gv_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            NapChucNangNguoiDung();
        }
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            // xu ly phan quyen
            var q = Biencucbo.QuyenDangChon;
            if (q == null) return;

            // vi du thoi
           treeList1.OptionsBehavior.Editable = Convert.ToBoolean(q.Sua);
        }
        private void SetCheckedChildNodes(TreeListNode node, TreeListColumn col, bool check)
        {
            var allowShow = (bool)node.GetValue(cxem);
            var allowAddNew = (bool)node.GetValue(cthem);
            var allowEdit = (bool)node.GetValue(csua);
            var allowDelete = (bool)node.GetValue(cxoa);


            // viet o day
            //var user = gridView1.GetFocusedRow() as account;
            var phongban = gv.GetFocusedRow() as phongban;

            var obj = treeList1.GetDataRecordByNode(node) as ObjPhanQuyen;

            //var find = db.PhanQuyen2s.FirstOrDefault(q => q.ChucNang == obj.MaChucNang && q.TaiKhoan == user.id);
            var find = dbData.PhanQuyen2s.FirstOrDefault(q => q.ChucNang == obj.MaChucNang && q.TaiKhoan == phongban.id);

            if (find == null)
            {
                find = new PhanQuyen2();
                //find.TaiKhoan = user.id;
                find.TaiKhoan = phongban.id;
                find.ChucNang = obj.MaChucNang;
                find.Xem = allowShow;
                find.Them = allowAddNew;
                find.Sua = allowEdit;
                find.Xoa = allowDelete;

                dbData.PhanQuyen2s.InsertOnSubmit(find);
                dbData.SubmitChanges();
            }
            else
            {
                find.Xem = allowShow;
                find.Them = allowAddNew;
                find.Sua = allowEdit;
                find.Xoa = allowDelete;
                dbData.SubmitChanges();
            }

            for (var i = 0; i < node.Nodes.Count; i++)
            {
                node.Nodes[i][col] = check;
                SetCheckedChildNodes(node.Nodes[i], col, check);
            }
        }

        private void SetCheckedParentNodes(TreeListNode node, TreeListColumn col, bool check)
        {
            if (node.ParentNode != null)
            {
                var b = false;
                bool state;
                for (var i = 0; i < node.ParentNode.Nodes.Count; i++)
                {
                    state = (bool)node.ParentNode.Nodes[i][col];
                    if (!check.Equals(state))
                    {
                        b = !b;
                        break;
                    }
                }
                var bb = b ? false : check;
                node.ParentNode[col] = bb;

                var allowShow = (bool)node.ParentNode.GetValue(cxem);
                var allowAddNew = (bool)node.ParentNode.GetValue(cthem);
                var allowEdit = (bool)node.ParentNode.GetValue(csua);
                var allowDelete = (bool)node.ParentNode.GetValue(cxoa);


                // viet o day
                //var user = gridView1.GetFocusedRow() as account;
                var phongban = gv.GetFocusedRow() as phongban;

                var obj = treeList1.GetDataRecordByNode(node.ParentNode) as ObjPhanQuyen;

                //var find = db.PhanQuyen2s.FirstOrDefault(q => q.ChucNang == obj.MaChucNang && q.TaiKhoan == user.id);
                var find = dbData.PhanQuyen2s.FirstOrDefault(q => q.ChucNang == obj.MaChucNang && q.TaiKhoan == phongban.id);

                if (find == null)
                {
                    find = new PhanQuyen2();
                    //find.TaiKhoan = user.id;
                    find.TaiKhoan = phongban.id;
                    find.ChucNang = obj.MaChucNang;
                    find.Xem = allowShow;
                    find.Them = allowAddNew;
                    find.Sua = allowEdit;
                    find.Xoa = allowDelete;

                    dbData.PhanQuyen2s.InsertOnSubmit(find);
                    dbData.SubmitChanges();
                }
                else
                {
                    find.Xem = allowShow;
                    find.Them = allowAddNew;
                    find.Sua = allowEdit;
                    find.Xoa = allowDelete;
                    dbData.SubmitChanges();
                }
                SetCheckedParentNodes(node.ParentNode, col, check);
            }
        }
        private void treeList1_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            //var user = gridView1.GetFocusedRow() as account;
            var phongban = gv.GetFocusedRow() as phongban;
            if (phongban == null) return;

            e.Node.SetValue(e.Column, e.Value);

            var obj = treeList1.GetDataRecordByNode(treeList1.FocusedNode) as ObjPhanQuyen;

            //var find = db.PhanQuyen2s.FirstOrDefault(q => q.ChucNang == obj.MaChucNang && q.TaiKhoan == user.id);
            var find = dbData.PhanQuyen2s.FirstOrDefault(q => q.ChucNang == obj.MaChucNang && q.TaiKhoan == phongban.id);

            if (find == null)
            {
                find = new PhanQuyen2();
                //find.TaiKhoan = user.id;
                find.TaiKhoan = phongban.id;
                find.ChucNang = obj.MaChucNang;
                find.Xem = obj.Xem;
                find.Them = obj.Them;
                find.Sua = obj.Sua;
                find.Xoa = obj.Xoa;

                dbData.PhanQuyen2s.InsertOnSubmit(find);
                dbData.SubmitChanges();
            }
            else
            {
                find.Xem = obj.Xem;
                find.Them = obj.Them;
                find.Sua = obj.Sua;
                find.Xoa = obj.Xoa;
                dbData.SubmitChanges();
            }

            SetCheckedChildNodes(e.Node, e.Column, (bool)e.Value);
            SetCheckedParentNodes(e.Node, e.Column, (bool)e.Value);
        }
    }
}