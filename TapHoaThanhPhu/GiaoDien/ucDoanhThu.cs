using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TapHoaThanhPhu.Class;

namespace TapHoaThanhPhu.GiaoDien
{
    public partial class ucDoanhThu : UserControl
    {
        private IMongoClient client = new MongoClient("mongodb://localhost:27017");
        private IMongoDatabase database;
        private IMongoCollection<HoaDon> collectionHoaDon;
        private List<HoaDon> hoaDonNhap = new List<HoaDon>();
        private List<HoaDon> hoaDonBan = new List<HoaDon>();
        public ucDoanhThu()
        {
            InitializeComponent();
            database = client.GetDatabase("TapHoaThanhPhu");
            collectionHoaDon = database.GetCollection<HoaDon>("HoaDon");
            hoaDonNhap = collectionHoaDon.Find(a => a.Loai == "nhập").ToList();
            hoaDonBan = collectionHoaDon.Find(a => a.Loai == "bán").ToList();
        }

        private void loadDGVNhap(List<HoaDon> hoaDonList)
        {
            dgvHoaDonNhap.Rows.Clear();
            foreach(HoaDon item in hoaDonList)
            {
                int index = dgvHoaDonNhap.Rows.Add();
                dgvHoaDonNhap.Rows[index].Cells[0].Value = index + 1;
                dgvHoaDonNhap.Rows[index].Cells[1].Value = item._id;
                dgvHoaDonNhap.Rows[index].Cells[2].Value = item.NgayLapHoaDon;
                dgvHoaDonNhap.Rows[index].Cells[3].Value = "Hoàng Minh Khang";
                var listChiTiet = item.listMatHang;
                int tongTien = 0;
                foreach (var item1 in listChiTiet)
                {
                    tongTien += item1.GiaNhap * item1.soLuong;
                }
                dgvHoaDonNhap.Rows[index].Cells[4].Value = tongTien;
            }
            return;
        }
        private void loadDGVBan(List<HoaDon> hoaDonList)
        {
            dgvHoaDonBan.Rows.Clear();
            foreach (HoaDon item in hoaDonList)
            {
                int index = dgvHoaDonBan.Rows.Add();
                dgvHoaDonBan.Rows[index].Cells[0].Value = index + 1;
                dgvHoaDonBan.Rows[index].Cells[1].Value = item._id;
                dgvHoaDonBan.Rows[index].Cells[2].Value = item.NgayLapHoaDon;
                dgvHoaDonBan.Rows[index].Cells[3].Value = "Hoàng Minh Khang";
                var listChiTiet = item.listMatHang;
                int tongTien = 0;
                foreach (var item1 in listChiTiet)
                {
                    tongTien += item1.GiaBan * item1.soLuong;
                }
                dgvHoaDonBan.Rows[index].Cells[4].Value = tongTien;
            }
            return;
        }

        private void loadCBXThang()
        {
            for (int i = 1; i <= 12; i++)
            {
                cbxThang.Items.Add(i.ToString());
            }
            cbxThang.SelectedIndex = DateTime.Now.Month - 1;

            txtNam.Text = DateTime.Now.Year.ToString();
        }

        private void ucDoanhThu_Load(object sender, EventArgs e)
        {
            loadDGVNhap(hoaDonNhap);
            loadDGVBan(hoaDonBan);
            loadCBXThang();
            return;
        }

        private void ctbLoc_CheckedChanged(object sender, EventArgs e)
        {
            DateTime dauThang = new DateTime(int.Parse(txtNam.Text), int.Parse(cbxThang.Text), 1);
            DateTime dauThangSau = new DateTime(int.Parse(txtNam.Text), int.Parse(cbxThang.Text) == 12 ? 1 : int.Parse(cbxThang.Text) + 1, 1);
            var hoaDonNhapTheoThang = hoaDonNhap.FindAll(a => a.NgayLapHoaDon >= dauThang && a.NgayLapHoaDon < dauThangSau).ToList();
            var hoaDonBanTheoThang = hoaDonBan.FindAll(a => a.NgayLapHoaDon >= dauThang && a.NgayLapHoaDon < dauThangSau).ToList();
            if (ctbLoc.Checked == true)
            {
                
                
                loadDGVBan(hoaDonBanTheoThang);
                loadDGVNhap(hoaDonNhapTheoThang);
                
            }
            else
            {
                loadDGVNhap(hoaDonNhap);
                loadDGVBan(hoaDonBan);
                
            }
            int tongTienNhap = 0;
            foreach (var item in hoaDonNhapTheoThang)
            {
                foreach (var item1 in item.listMatHang)
                {
                    tongTienNhap += item1.GiaNhap * item1.soLuong;
                }
            }
            int tongTienBan = 0;
            foreach (var item in hoaDonBanTheoThang)
            {
                foreach (var item1 in item.listMatHang)
                {
                    tongTienBan += item1.GiaBan * item1.soLuong;
                }
            }

            int tongTienNhapSoHangDaBan = 0;
            foreach (var item in hoaDonBanTheoThang)
            {
                foreach (var item1 in item.listMatHang)
                {
                    tongTienNhapSoHangDaBan += item1.GiaNhap * item1.soLuong;
                }
            }

            txtTongTienNhap.Text = tongTienNhap.ToString();
            txtTongTienBan.Text = tongTienBan.ToString();
            txtLoiNhuan.Text = (tongTienBan - tongTienNhapSoHangDaBan).ToString();

        }

    }
}
