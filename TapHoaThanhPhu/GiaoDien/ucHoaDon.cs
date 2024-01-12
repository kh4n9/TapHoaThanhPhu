using Amazon.Runtime.Internal.Transform;
using DevExpress.XtraReports.UI;
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
using System.Xml.Serialization;
using TapHoaThanhPhu.Class;

namespace TapHoaThanhPhu.GiaoDien
{
    public partial class ucHoaDon : UserControl
    {
        private string tenNhanVien;
        private IMongoClient client = new MongoClient("mongodb://localhost:27017");
        private IMongoDatabase database;
        private IMongoCollection<HoaDon> collectionHoaDon;
        private IMongoCollection<MatHang> collectionMatHang;
        private List<CTHoaDon> listCTHoaDon = new List<CTHoaDon>();

        public ucHoaDon(string tenNhanVien)
        {
            InitializeComponent();
            database = client.GetDatabase("TapHoaThanhPhu");
            collectionHoaDon = database.GetCollection<HoaDon>("HoaDon");
            collectionMatHang = database.GetCollection<MatHang>("MatHang");
            this.tenNhanVien = tenNhanVien;
        }

        private void loadDGVMatHang(List<MatHang> matHangList)
        {
            dgvMatHang.Rows.Clear();
            foreach (MatHang item in matHangList)
            {
                int index = dgvMatHang.Rows.Add();
                dgvMatHang.Rows[index].Cells[0].Value = item.Ten;
                dgvMatHang.Rows[index].Cells[1].Value = item.DonVi;
                dgvMatHang.Rows[index].Cells[2].Value = item.GiaBan;
            }
            return;
        }

        private void ucHoaDon_Load(object sender, EventArgs e)
        {
            List<MatHang> listMatHang = collectionMatHang.Find(a => true).ToList();
            loadDGVMatHang(listMatHang);
        }

        private void loadDGVHoaDon(List<CTHoaDon> listHoaDon)
        {
            dgvHoaDon.Rows.Clear();
            int tongTien = 0;
            foreach (CTHoaDon item in listHoaDon)
            {
                int index = dgvHoaDon.Rows.Add();
                dgvHoaDon.Rows[index].Cells[0].Value = item.Ten;
                dgvHoaDon.Rows[index].Cells[1].Value = item.soLuong;
                dgvHoaDon.Rows[index].Cells[2].Value = item.DonVi;
                dgvHoaDon.Rows[index].Cells[3].Value = item.GiaBan;
                dgvHoaDon.Rows[index].Cells[4].Value = item.GiaBan * item.soLuong;
                tongTien += item.GiaBan * item.soLuong;
            }
            txtTongTien.Text = tongTien.ToString();
            return;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (dgvMatHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn mặt hàng!");
                return;
            }
            if (txtSoLuong.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập số lượng!");
                return;
            }

            MatHang matHang = collectionMatHang.Find(a => a.Ten == dgvMatHang.SelectedRows[0].Cells[0].Value.ToString()).First();
            CTHoaDon cTHoaDon = new CTHoaDon();
            cTHoaDon.Ten = matHang.Ten;
            cTHoaDon.DonVi = matHang.DonVi;
            cTHoaDon.GiaNhap = matHang.GiaNhap;
            cTHoaDon.GiaBan = matHang.GiaBan;
            cTHoaDon.GhiChu = matHang.GhiChu;
            cTHoaDon.soLuong = int.Parse(txtSoLuong.Text);
            if (cTHoaDon.soLuong > collectionMatHang.Find(a => a.Ten == cTHoaDon.Ten).First().SoLuong)
            {
                MessageBox.Show("Số lượng mặt hàng này còn tỏng kho chỉ còn " + collectionMatHang.Find(a => a.Ten == cTHoaDon.Ten).First().SoLuong.ToString());
                return;
            }
            listCTHoaDon.Add(cTHoaDon);
            loadDGVHoaDon(listCTHoaDon);
            return;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn mặt hàng cần xóa!");
                return;
            }
            CTHoaDon cTHoaDon = listCTHoaDon.Find(a => a.Ten == dgvHoaDon.SelectedRows[0].Cells[0].Value.ToString());
            listCTHoaDon.Remove(cTHoaDon);
            loadDGVHoaDon(listCTHoaDon);
            MessageBox.Show("Xóa thành công mặt hàng!");
            return;
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            HoaDon hoaDon = new HoaDon(listCTHoaDon,"bán",tenNhanVien);
            foreach(var item in listCTHoaDon)
            {
                MatHang matHang = collectionMatHang.Find(a => a.Ten == item.Ten).First();
                matHang.SoLuong -= item.soLuong;
                var fillter = Builders<MatHang>.Filter.Eq("Ten", matHang.Ten);
                collectionMatHang.ReplaceOne(fillter, matHang);
            }
            collectionHoaDon.InsertOne(hoaDon);
            MessageBox.Show("Thanh toán thành công!\nHóa đơn đã được lưu!");
            listCTHoaDon.Clear();
            loadDGVHoaDon(listCTHoaDon );
            return;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKiem.Text.Length == 0)
            {
                var listMatHang = collectionMatHang.Find(a => true).ToList();
                loadDGVMatHang(listMatHang);
                return;
            }
            else
            {
                var listMatHang = collectionMatHang.Find(a => a.Ten.Contains(txtTimKiem.Text)).ToList();
                loadDGVMatHang(listMatHang);
                return;
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
