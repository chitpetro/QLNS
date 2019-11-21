using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data.Linq;
using System.Transactions;
using System.Windows.Forms;



namespace BUS
{
    public class t_nhansu
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        public void themns(string key, string id, string hovaten, DateTime ngaysinh, string quequan, string quoctich, string cmnd, string idphong, string chucvu, byte[] hinhanh, DateTime ngayvaolam, DateTime ngaynghiviec, string sohd, string sodienthoai, string gioitinh, string email, string tinhtrang, string tieusu, string bangcap, string mota)
        {

            nhansu ns = new nhansu();
            ns.key = key;
            ns.id = id;
            ns.hovaten = hovaten;
            ns.ngaysinh = ngaysinh;
            ns.quequan = quequan;
            ns.quoctich = quoctich;
            ns.cmnd = cmnd;
            ns.idphong = idphong;
            ns.chucvu = chucvu;
            ns.hinhanh = hinhanh;
            ns.ngayvaolam = ngayvaolam;
            ns.ngaynghiviec = ngaynghiviec;
            ns.sohdld = sohd;
            ns.sodienthoai = sodienthoai;
            ns.gioitinh = gioitinh;
            ns.email = email;
            ns.bangcap = bangcap;
            ns.mota = mota;
            ns.tinhtrang = tinhtrang;
            ns.tieusu = tieusu;
            dbData.nhansus.InsertOnSubmit(ns);
            dbData.SubmitChanges();
    }
        public void sua(string key, string hovaten, DateTime ngaysinh, string quequan, string quoctich, string cmnd, string idphong, string chucvu, byte[] hinhanh, DateTime ngayvaolam, DateTime ngaynghiviec, string sohd, string sodienthoai, string gioitinh, string email, string tinhtrang, string tieusu, string bangcap, string mota)
        {
            dbData = new KetNoiDBDataContext();
            nhansu ns = (from a in dbData.nhansus select a).Single(t => t.key == key);
            ns.hovaten = hovaten;
            ns.ngaysinh = ngaysinh;
            ns.quequan = quequan;
            ns.quoctich = quoctich;
            ns.cmnd = cmnd;
            ns.idphong = idphong;
            ns.chucvu = chucvu;
            ns.hinhanh = hinhanh;
            ns.ngayvaolam = ngayvaolam;
            ns.ngaynghiviec = ngaynghiviec;
            ns.sohdld = sohd;
            ns.sodienthoai = sodienthoai;
            ns.gioitinh = gioitinh;
            ns.mota = mota;
            ns.bangcap = bangcap;
            ns.email = email;
            ns.tinhtrang = tinhtrang;
            ns.tieusu = tieusu;
            dbData.SubmitChanges();
        }
        public void xoa(string key)
        {
            using (var trans = new TransactionScope())
            {

                dbData = new KetNoiDBDataContext();
                nhansu ns = (from a in dbData.nhansus select a).Single(t => t.key == key);
                dbData.nhansus.DeleteOnSubmit(ns);

                var f = (from a in dbData.filens where a.keyns == key select a);
                foreach(var fa in f)
                {
                    filen file = fa;
                    dbData.filens.DeleteOnSubmit(fa);
                }
                dbData.SubmitChanges();
                trans.Complete();
            }
        }

        //public void themfile(string id, string idns, string name, Binary data, string type, string size)
        //{
        //    filen ns = new filen();
        //    ns.id = id;
        //    ns.idns = idns;
        //    ns.name = name;
        //    ns.data = data;
        //    ns.type = type;
        //    ns.size = size;
        //    dbData.filens.InsertOnSubmit(ns);
        //    dbData.SubmitChanges();
        //}
    }
}
