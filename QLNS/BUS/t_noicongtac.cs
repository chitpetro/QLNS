using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class t_noicongtac
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();

        public void them(string key, string id, string noicongtac, string ghichu, string khuvuc, string diachi)
        {
            noict ct = new noict();
            ct.key = key;
            ct.id = id;
            ct.noicongtac = noicongtac;
            ct.diachi = diachi;
            ct.khuvuc = khuvuc;
            ct.ghichu = ghichu;
            dbData.noicts.InsertOnSubmit(ct);
            dbData.SubmitChanges();
        }

        public void sua(string key,  string noicongtac, string ghichu, string khuvuc, string diachi)
        {
            noict ct = (from a in dbData.noicts select a).Single(t => t.key == key);
            ct.noicongtac = noicongtac;
            ct.diachi = diachi;
            ct.khuvuc = khuvuc;
            ct.ghichu = ghichu;
            dbData.SubmitChanges();
        }

        public void xoa(string key)
        {
            noict ct = (from a in dbData.noicts select a).Single(t => t.key == key);
            dbData.noicts.DeleteOnSubmit(ct);
            dbData.SubmitChanges();
        }
    }
}
