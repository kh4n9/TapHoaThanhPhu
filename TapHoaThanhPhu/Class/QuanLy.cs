using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TapHoaThanhPhu.Class
{
    internal class QuanLy
    {
        public ObjectId _id = new ObjectId();
        public string Ten;
        public string TaiKhoan { get ; set; }
        public string MatKhau { get ; set; }

        public QuanLy() { }
        public QuanLy(string ten, string taiKhoan, string matKhau)
        {
            Ten = ten;
            TaiKhoan = taiKhoan;
            MatKhau = matKhau;
        }
    }
}
