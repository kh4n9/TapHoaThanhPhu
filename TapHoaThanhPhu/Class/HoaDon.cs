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
        public HoaDon(List<CTHoaDon> listMatHang, string loai)
        {
            NgayLapHoaDon = DateTime.Now;
            this.listMatHang = listMatHang;
            Loai = loai;
        }
    }
}
