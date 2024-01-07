using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TapHoaThanhPhu.Class
{
    public class MatHang
    {
        public ObjectId _id = new ObjectId();
        public string Ten;
        public string DonVi;
        public int SoLuong;
        public int GiaNhap;
        public int GiaBan;
        public string GhiChu;
    }
}
