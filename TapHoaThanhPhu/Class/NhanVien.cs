using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TapHoaThanhPhu.Class
{
    public class NhanVien
    {
        public ObjectId _id = new ObjectId();
        public string Ten;
        public string TaiKhoan;
        public string MatKhau;
        public NhanVien() { }
        public NhanVien(string ten, string taiKhoan, string matKhau) 
        { 
            Ten = ten;
            TaiKhoan = taiKhoan;
            MatKhau = matKhau;
        }
    }
}
