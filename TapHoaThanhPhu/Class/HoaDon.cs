using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TapHoaThanhPhu.Class
{
    public class HoaDon
    {
        public ObjectId _id = new ObjectId();
        public DateTime NgayLapHoaDon;
        public String Loai;
        public List<CTHoaDon> listMatHang;
        public string tenNhanVien;
        public HoaDon(List<CTHoaDon> listMatHang, string loai, string tenNhanVien)
        {
            NgayLapHoaDon = DateTime.Now;
            this.listMatHang = listMatHang;
            Loai = loai;
            this.tenNhanVien = tenNhanVien;
        }
    }
}
