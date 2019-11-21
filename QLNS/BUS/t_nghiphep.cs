using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BUS;

namespace BUS
{
    public class t_nghiphep
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();

        public void them(string key, DateTime tungay, DateTime denngay, string ghichu, string loai, string idnv, string hoso)
        {
            var np = new nghiphep();
            np.key = key;
            np.tungay = tungay;
            np.denngay = denngay;
            np.ghichu = ghichu;
            np.loai = loai;
            np.hoso = hoso;
            np.idnv = idnv;
            dbData.nghipheps.InsertOnSubmit(np);
            dbData.SubmitChanges();
        }
        public void sua(string key, DateTime tungay, DateTime denngay, string ghichu, string loai, string hoso)
        {
            var np = (from a in dbData.nghipheps select a).Single(t => t.key == key);
            np.tungay = tungay;
            np.denngay = denngay;
            np.ghichu = ghichu;
            np.loai = loai;
            np.hoso = hoso;
           dbData.SubmitChanges();
        }
        public void xoa(string key)
        {
            var np = (from a in dbData.nghipheps select a).Single(t => t.key == key);
            dbData.nghipheps.DeleteOnSubmit(np);
            dbData.SubmitChanges();
        }
    }
}
