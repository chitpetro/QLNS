using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class t_khuvuc
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();

        public void them(string key, string id, string khuvuc)
        {
            khuvuc kv = new khuvuc();
            kv.key = key;
            kv.id = id;
            kv.tenkhuvuc = khuvuc;
            dbData.khuvucs.InsertOnSubmit(kv);
            dbData.SubmitChanges();

        }
        public void sua(string key, string khuvuc)
        {
            khuvuc kv = (from a in dbData.khuvucs select a).Single(t => t.key == key);
            kv.key = key;
            kv.tenkhuvuc = khuvuc;
            dbData.SubmitChanges();

        }
        public void xoa(string key)
        {
            khuvuc kv = (from a in dbData.khuvucs select a).Single(t => t.key == key);
            kv.key = key;
            dbData.khuvucs.DeleteOnSubmit(kv);
            dbData.SubmitChanges();

        }
    }
}
