using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BUS;

namespace BUS
{
    public class t_dieuchuyen
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();

        public void them(string key, string idnv, string mact_ht, string mact_dc, DateTime ngaydc, DateTime ngaylap,
            int so)
        {
            dieuchuyennhansu dc = new dieuchuyennhansu();
            dc.key = key;
            dc.idnv = idnv;
            dc.mact_ht = mact_ht;
            dc.mact_dc = mact_dc;
            dc.ngaydc = ngaydc;
            dc.ngaylap = ngaylap;
            dc.so = so;
            dbData.dieuchuyennhansus.InsertOnSubmit(dc);
            dbData.SubmitChanges();
        }

        public void sua(string key, string mact_dc, DateTime ngaydc)
        {
            var dc = (from a in dbData.dieuchuyennhansus select a).Single(t => t.key == key);
            dc.mact_dc = mact_dc;
            dc.ngaydc = ngaydc;
            dbData.SubmitChanges();
        }

        public void xoa(string key)
        {
            var dc = (from a in dbData.dieuchuyennhansus select a).Single(t => t.key == key);
            dbData.dieuchuyennhansus.DeleteOnSubmit(dc);
            dbData.SubmitChanges();
        }
    }
}
