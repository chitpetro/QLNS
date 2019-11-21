using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraBars.Ribbon.Drawing;
using DevExpress.XtraEditors;

namespace QLNS
{
    sealed class mes
    {
        public static void thongtinchuadaydu()
        {
            XtraMessageBox.Show("Thông Tin Chưa Đầy Đủ Vui lòng Kiểm Tra Lại", "Thông Báo");
        }

        public static void trunglap(string obj)
        {
            XtraMessageBox.Show(obj + " bị trùng vui lòng kiểm tra lại", "Thông Báo");
        }

        public static void done()
        {
            XtraMessageBox.Show("Done!");
        }
    }
}
