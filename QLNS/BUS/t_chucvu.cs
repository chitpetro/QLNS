using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using DAL;

namespace BUS
{
    public class t_chucvu
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();

        public void them(string key, string id, string chucvu)
        {
            dmchucvu cv = new dmchucvu();
            cv.key = key;
            cv.id = id;
            cv.chucvu = chucvu;
            dbData.dmchucvus.InsertOnSubmit(cv);
            dbData.SubmitChanges();
        }

        public void sua(string key, string chucvu)
        {
            dmchucvu cv = (from a in dbData.dmchucvus select a).Single(t => t.key == key);
            cv.chucvu = chucvu;
            dbData.SubmitChanges();
        }

        public void xoa(string key)
        {
            dmchucvu cv = (from a in dbData.dmchucvus select a).Single(t => t.key == key);
            dbData.dmchucvus.DeleteOnSubmit(cv);
            dbData.SubmitChanges();
        }
    }
}
