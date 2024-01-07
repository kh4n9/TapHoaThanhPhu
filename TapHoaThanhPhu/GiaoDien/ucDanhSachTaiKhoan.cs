using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TapHoaThanhPhu.Class;
using TapHoaThanhPhu.Forms;

namespace TapHoaThanhPhu.GiaoDien
{
    public partial class ucDanhSachTaiKhoan : UserControl
    {
        private IMongoClient client = new MongoClient("mongodb://localhost:27017");
        private IMongoDatabase database;
        private IMongoCollection<QuanLy> collectionQuanLy;
        private IMongoCollection<NhanVien> collectionNhanVien;
        public ucDanhSachTaiKhoan()
        {
            InitializeComponent();
        }

        private void ucDanhSachTaiKhoan_Load(object sender, EventArgs e)
        {
            database = client.GetDatabase("TapHoaThanhPhu");
            collectionNhanVien = database.GetCollection<NhanVien>("NhanVien");
            collectionQuanLy = database.GetCollection<QuanLy>("QuanLy");
            
            loadDGV();
        }

        private void loadDGV()
        {
            dgvQuanLy.Rows.Clear();
            dgvNhanVien.Rows.Clear();
            var dataQuanLy = collectionQuanLy.Find(a => true).ToList();
            var dataNhanVien = collectionNhanVien.Find(a => true).ToList();

            foreach ( var item in dataNhanVien )
            {
                var index = dgvNhanVien.Rows.Add();
                dgvNhanVien.Rows[index].Cells[0].Value = item.Ten;
                dgvNhanVien.Rows[index].Cells[1].Value = item.TaiKhoan;
                dgvNhanVien.Rows[index].Cells[2].Value = item.MatKhau;
            }
            foreach ( var item in dataQuanLy )
            {
                var index = dgvQuanLy.Rows.Add();
                dgvQuanLy.Rows[index].Cells[0].Value = item.Ten;
                dgvQuanLy.Rows[index].Cells[1].Value = item.TaiKhoan;
                dgvQuanLy.Rows[index].Cells[2].Value = item.MatKhau;
            }
        }

        private void btnXoaQuanLy_Click(object sender, EventArgs e)
        {
            if (dgvQuanLy.SelectedCells.Count > 0)
            {
                if (MessageBox.Show("Bạn có muốn xóa tài khoản này?","Cảnh báo!",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var fillter = Builders<QuanLy>.Filter.Eq("TaiKhoan", dgvQuanLy.SelectedRows[0].Cells[1].Value);
                    collectionQuanLy.DeleteOne(fillter);
                    loadDGV();
                    MessageBox.Show("Xóa tài khoản thành công!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tài khoản quản lý để xóa!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvQuanLy.SelectedCells.Count > 0)
            {
                frmSuaTaiKhoanQuanLy frmSuaTaiKhoanQuanLy = new frmSuaTaiKhoanQuanLy(dgvQuanLy.SelectedRows[0].Cells[1].Value.ToString());
                frmSuaTaiKhoanQuanLy.ShowDialog();
                loadDGV();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tài khoản quản lý để sửa!");
            }
        }

        private void btnXoaNhanVien_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.SelectedCells.Count > 0)
            {
                if (MessageBox.Show("Bạn có muốn xóa tài khoản này?", "Cảnh báo!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var fillter = Builders<NhanVien>.Filter.Eq("TaiKhoan", dgvNhanVien.SelectedRows[0].Cells[1].Value);
                    collectionNhanVien.DeleteOne(fillter);
                    loadDGV();
                    MessageBox.Show("Xóa tài khoản thành công!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tài khoản quản lý để xóa!");
            }
        }

        private void btnSuaNhanVien_Click(object sender, EventArgs e)
        {
            if (dgvQuanLy.SelectedCells.Count > 0)
            {
                frmSuaTaiKhoanQuanLy frmSuaTaiKhoanQuanLy = new frmSuaTaiKhoanQuanLy(dgvNhanVien.SelectedRows[0].Cells[1].Value.ToString());
                frmSuaTaiKhoanQuanLy.ShowDialog();
                loadDGV();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tài khoản quản lý để sửa!");
            }
        }
    }
}
