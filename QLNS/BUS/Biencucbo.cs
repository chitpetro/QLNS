using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class Biencucbo
    {

        // nhansu
        public static string manhansu;
        public static string thoigian;

        //custom
        public static DataTable Table ;

        // Hoạt Động
        public static int hdong = 0;
        public static int obj = 0;

        // lấy mã
        public static string ma = "";

        // login
        public static string idnv = "";
        public static string donvi = "";
        public static string ten = "";
        public static string hostname = "";
        public static string IPaddress = "";
        public static string skin = "";
        public static string DbName ="";

        public static string dvten = "";
        public static string phongban = "";
        public static string ServerName = "";


        // phân quyền
        public static PhanQuyen2 QuyenDangChon { get; set; }

        // Hệ thống
        public static string tendvbc;
    }
}
