﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using  DAL;
using BUS;

namespace QLNS
{
    public partial class f_themchucvu : frm_themds
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        t_chucvu cv = new t_chucvu();
        t_history hs = new t_history();
        private string _key = "";
        private int _hdong = 0;
        public f_themchucvu()
        {
            InitializeComponent();
        }

        protected override void load()
        {
            _hdong = Biencucbo.hdong;
            if (_hdong == 0)
            {
                _key = md5.Encrypt(md5.laykey());
            }
            else
            {
                _key = Biencucbo.ma;
                try
                {
                    var lst = (from a in dbData.dmchucvus select a).Single(t => t.key == _key);
                    txtid.Text = lst.id;
                    txtchucvu.Text = lst.chucvu;
                    txtid.ReadOnly = true;
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        protected override void huy()
        {
            Close();
        }
        protected override void luu()
        {
            if (txtid.Text == "" || txtchucvu.Text == "")
            {
                mes.thongtinchuadaydu();
                return;
            }
            
            if (_hdong == 0)
            {
                using (dbData = new KetNoiDBDataContext())
                {
                    if ((from a in dbData.dmchucvus where a.id == txtid.Text select a).Count() > 0)
                    {
                        mes.trunglap("Mã chức vụ " + txtid);
                        return;
                    }
                }
                try
                {
                    cv.them(_key, txtid.Text, txtchucvu.Text);
                    hs.add(txtid.Text,"Thêm chức vụ");
                    Biencucbo.obj = 1;
                    mes.done();
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                try
                {
                    cv.sua(_key,txtchucvu.Text);
                    hs.add(txtid.Text,"Sửa chức vụ");
                    Biencucbo.obj = 1;
                    mes.done();
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show(ex.ToString());
                }
            }
            Close();
        }
    }
}