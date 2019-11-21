using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using DevExpress.Utils.Win;
using QLNS.Properties;
using DevExpress.XtraEditors.Controls;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.DataAccess.Native.Data;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraGrid.Views.Grid;
using BUS;
using DevExpress.Office.PInvoke;
using DAL;

namespace QLNS
{
    sealed class custom
    {
        public static void showdate(DateEdit a, string b)
        {
            try
            {
                a.DateTime = DateTime.Parse(b);
                if (a.Text == "01/01/0001")
                    a.Text = "";
            }
            catch (Exception ex)
            {
                a.Text = "";
            }
        }

        public static string laytenns(string id)
        {
            try
            {
                return (from a in new KetNoiDBDataContext().nhansus select a).Single(t => t.id == id).hovaten;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public static void popupslu<C>(object sender, EventArgs e, SearchLookUpEdit slUpEdit)
        {

            try
            {
                var popupControl = sender as IPopupControl;
                var button = new SimpleButton
                {
                    Image = Resources.add_16x16,
                    Text = "Edit",
                    BorderStyle = BorderStyles.NoBorder
                };

                button.Click += btnclick<C>;
                button.Location = new Point(5, popupControl.PopupWindow.Height - button.Height - 5);
                popupControl.PopupWindow.Controls.Add(button);
                button.BringToFront();

                var edit = sender as SearchLookUpEdit;
                var popupForm = edit.GetPopupEditForm();
                popupForm.KeyPreview = true;
                popupForm.KeyUp -= txt_KeyUp;
                popupForm.KeyUp += txt_KeyUp;
                //slUpEdit.Properties.DataSource = Biencucbo.Table;
                //Biencucbo.Table = null;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }


        private static void btnclick<C>(object sender, EventArgs e)
        {
            var fm = Activator.CreateInstance<C>() as Form;// tao đối tượng T thôi
            fm.ShowDialog();
            
        }
        private static void txt_KeyUp(object sender, KeyEventArgs e)
        {
            PopupSearchLookUpEditForm popupForm = sender as PopupSearchLookUpEditForm;
            if (e.KeyData == System.Windows.Forms.Keys.Enter)
            {
                GridView view = popupForm.OwnerEdit.Properties.View;
                view.FocusedRowHandle = 0;
                popupForm.OwnerEdit.ClosePopup();
            }
        }



    }
}
