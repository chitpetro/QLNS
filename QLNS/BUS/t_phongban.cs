using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class t_phongban
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        public void them(string key, string id, string phong, bool phanquyen)
        {
            phongban p = new phongban();
            {
                p.key = key;
                p.id = id;
                p.phong = phong;
                p.phanquyen = phanquyen;
            }
            dbData.phongbans.InsertOnSubmit(p);
            dbData.SubmitChanges();
        }

        public void sua(string key, string phong, bool phanquyen)
        {
            phongban p = (from a in dbData.phongbans select a).Single(t => t.key == key);
            {
                p.phong = phong;
                p.phanquyen = phanquyen;
            }
            dbData.SubmitChanges();
        }

        public void xoa(string key)
        {
            phongban p = (from a in dbData.phongbans select a).Single(t => t.key == key);
            dbData.phongbans.DeleteOnSubmit(p);
            dbData.SubmitChanges();
        }

    }
}
