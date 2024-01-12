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
    public partial class ucMatHang : UserControl
    {
        private IMongoClient client = new MongoClient("mongodb://localhost:27017");
        private IMongoDatabase database;
        private IMongoCollection<MatHang> collectionMatHang;
        private List<MatHang> dataMatHang;
        public ucMatHang()
        {
            InitializeComponent();
            database = client.GetDatabase("TapHoaThanhPhu");
            collectionMatHang = database.GetCollection<MatHang>("MatHang");
        }
        private void ucMatHang_Load(object sender, EventArgs e)
        {
            dataMatHang = collectionMatHang.Find(a => true).ToList();
            loadDGV(dataMatHang);
        }

        private void loadDGV(List<MatHang> dataMatHang)
        {
            dgvShow.Rows.Clear();
            foreach (var item in dataMatHang)
            {
                int index = dgvShow.Rows.Add();
                dgvShow.Rows[index].Cells[0].Value = item.Ten;
                dgvShow.Rows[index].Cells[1].Value = item.DonVi;
                dgvShow.Rows[index].Cells[2].Value = item.SoLuong;
                dgvShow.Rows[index].Cells[3].Value = item.GiaNhap;
                dgvShow.Rows[index].Cells[4].Value = item.GiaBan;
            }
            return;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // nếu tên hàng đã tồn tại
            if (collectionMatHang.Find(a => a.Ten == txtTenHang.Text).Any())
            {
                MessageBox.Show("Mặt hàng này đã tồn tại!");
                return;
            }

            MatHang matHang = new MatHang();
            matHang.Ten = txtTenHang.Text;
            matHang.DonVi = txtDonVi.Text;
            matHang.SoLuong = int.Parse(txtSoLuong.Text);
            matHang.GiaBan = int.Parse(txtGiaBan.Text);
            matHang.GiaNhap = int.Parse(txtGiaNhap.Text);
            matHang.GhiChu = txtGhiChu.Text;
            collectionMatHang.InsertOne(matHang);

            MessageBox.Show("Thêm mặt hàng thành công!");
            dataMatHang = collectionMatHang.Find(a => true).ToList();

            loadDGV(dataMatHang);
            return;
        }

        private void dgvShow_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var matHang = collectionMatHang.Find(a => a.Ten == dgvShow.SelectedRows[0].Cells[0].Value.ToString()).First();
            txtTenHang.Text = matHang.Ten.ToString();
            txtGiaBan.Text = matHang.GiaBan.ToString();
            txtGiaNhap.Text = matHang.GiaNhap.ToString();
            txtSoLuong.Text = matHang.SoLuong.ToString();
            txtDonVi.Text = matHang.DonVi.ToString();
            txtGhiChu.Text = matHang.GhiChu.ToString();
            return;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvShow.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn mặt hàng cần xóa!");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa mặt hàng này?", "Thông báo!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                collectionMatHang.FindOneAndDelete(a => a.Ten == dgvShow.SelectedRows[0].Cells[0].Value.ToString());
                dataMatHang = collectionMatHang.Find(a => true).ToList();

                loadDGV(dataMatHang);
                MessageBox.Show("Xóa thành công mặt hàng!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvShow.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn mặt hàng cần sửa!");
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn sửa mặt hàng này?", "Thông báo!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MatHang matHang = collectionMatHang.Find(a => a.Ten == dgvShow.SelectedRows[0].Cells[0].Value.ToString()).First();
                matHang.Ten = txtTenHang.Text;
                matHang.DonVi = txtDonVi.Text;
                matHang.GhiChu = txtGhiChu.Text;
                matHang.SoLuong = int.Parse(txtSoLuong.Text);
                matHang.GiaNhap = int.Parse(txtGiaNhap.Text);
                matHang.GiaBan = int.Parse(txtGiaBan.Text);

                collectionMatHang.ReplaceOne(a => a.Ten == dgvShow.SelectedRows[0].Cells[0].Value.ToString(), matHang);
                dataMatHang = collectionMatHang.Find(a => true).ToList();

                MessageBox.Show("Sửa thành công mặt hàng!");
                loadDGV(dataMatHang);

                return;
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKiem.Text.Length == 0)
            {
                loadDGV(dataMatHang);
            }
            else
            {
                var dataTimKiem = collectionMatHang.Find(a => a.Ten.Contains(txtTimKiem.Text)).ToList();
                loadDGV(dataTimKiem);
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtGiaNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
