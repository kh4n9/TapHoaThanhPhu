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
    public partial class ucNhapHang : UserControl
    {
        private string tenNhanVien;
        private IMongoClient client = new MongoClient("mongodb://localhost:27017");
        private IMongoDatabase database;
        private IMongoCollection<MatHang> collectionMatHang;
        private IMongoCollection<HoaDon> collectionHoaDon;
        private List<MatHang> dataMatHang;
        private List<CTHoaDon> listCTHoaDon = new List<CTHoaDon>();

        public ucNhapHang(string tenNhanVien)
        {
            InitializeComponent();
            database = client.GetDatabase("TapHoaThanhPhu");
            collectionMatHang = database.GetCollection<MatHang>("MatHang");
            collectionHoaDon = database.GetCollection<HoaDon>("HoaDon");
            this.tenNhanVien = tenNhanVien;
        }

        private void ucNhapHang_Load(object sender, EventArgs e)
        {
            dataMatHang = collectionMatHang.Find(a => true).ToList();
            loadDGVHangHoa(dataMatHang);
            return;
        }

        private void loadDGVHangHoa(List<MatHang> list)
        {
            dgvHangHoa.Rows.Clear();
            foreach (MatHang item in list)
            {
                int index = dgvHangHoa.Rows.Add();
                dgvHangHoa.Rows[index].Cells[0].Value = item.Ten;
                dgvHangHoa.Rows[index].Cells[1].Value = item.GiaNhap;
                dgvHangHoa.Rows[index].Cells[2].Value = item.DonVi;
            }
            return;
        }

        private void loadDGVHoaDon(List<CTHoaDon> listCTHD)
        {
            dgvHoaDon.Rows.Clear();
            foreach (CTHoaDon item in listCTHD)
            {
                int index = dgvHoaDon.Rows.Add();
                dgvHoaDon.Rows[index].Cells[0].Value = item.Ten;
                dgvHoaDon.Rows[index].Cells[1].Value = item.soLuong;
                dgvHoaDon.Rows[index].Cells[2].Value = item.DonVi;
            }
            return;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtSoLuong.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng ghi số lượng!");
                return;
            }
            if (dgvHangHoa.SelectedRows.Count == 0) 
            {
                MessageBox.Show("Vui lòng chọn mặt hàng cần thêm!");
                return; 
            }
            MatHang matHang = collectionMatHang.Find(a => a.Ten == dgvHangHoa.SelectedRows[0].Cells[0].Value.ToString()).First();

            CTHoaDon cTHoaDon = new CTHoaDon();
            cTHoaDon.Ten = matHang.Ten;
            cTHoaDon.DonVi = matHang.DonVi;
            cTHoaDon.soLuong = int.Parse(txtSoLuong.Text);
            cTHoaDon.GiaNhap = matHang.GiaNhap;
            cTHoaDon.GiaBan = matHang.GiaBan;
            cTHoaDon.GhiChu = matHang.GhiChu;
            listCTHoaDon.Add(cTHoaDon);
            loadDGVHoaDon(listCTHoaDon);
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có mặt hàng nào trong hóa đơn!");
                return;
            }
            if (MessageBox.Show("Kiểm tra kĩ số lượng trước khi nhập!\nBạn chắc chắn muốn nhập?","Cảnh báo",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                foreach (CTHoaDon item in listCTHoaDon)
                {
                    MatHang matHang = collectionMatHang.Find(a => a.Ten == item.Ten).First();
                    matHang.SoLuong += item.soLuong;
                    var fillter = Builders<MatHang>.Filter.Eq("Ten", matHang.Ten);
                    collectionMatHang.ReplaceOne(fillter, matHang);
                }
                HoaDon hoaDon = new HoaDon(listCTHoaDon, "nhập", tenNhanVien);
                collectionHoaDon.InsertOne(hoaDon);
                MessageBox.Show("Nhập thành công!");
                return;
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn món cần xóa!");
                return;
            }
            CTHoaDon cTHoaDon = listCTHoaDon.Find(a => a.Ten == dgvHoaDon.SelectedRows[0].Cells[0].Value.ToString());
            listCTHoaDon.Remove(cTHoaDon);
            loadDGVHoaDon(listCTHoaDon);
            return;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKiem.Text.Length == 0)
            {
                loadDGVHangHoa(dataMatHang);
                return;
            }
            else
            {
                var listTimKiem = dataMatHang.FindAll(a => a.Ten.Contains(txtTimKiem.Text));
                loadDGVHangHoa(listTimKiem);
                return;
            }
        }
    }
}
