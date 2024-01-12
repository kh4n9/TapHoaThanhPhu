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

namespace TapHoaThanhPhu.Forms
{
    public partial class frmSuaTaiKhoanQuanLy : Form
    {
        private string email;
        private IMongoClient client = new MongoClient("mongodb://localhost:27017");
        private IMongoDatabase database;
        private IMongoCollection<QuanLy> collectionQuanLy;
        private IMongoCollection<NhanVien> collectionNhanVien;
        public frmSuaTaiKhoanQuanLy(string email)
        {
            InitializeComponent();
            database = client.GetDatabase("TapHoaThanhPhu");
            collectionNhanVien = database.GetCollection<NhanVien>("NhanVien");
            collectionQuanLy = database.GetCollection<QuanLy>("QuanLy");
            this.email = email;
            txtTaiKhoan.Text = email;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!txtTaiKhoan.Text.Contains("@") || !txtTaiKhoan.Text.Contains('.'))
            {
                MessageBox.Show("Email chưa đúng định dạng, kiểm tra lại!", "Thông báo!");
                return;
            }

            var accQuanLy = collectionQuanLy.Find(a => a.TaiKhoan == txtTaiKhoan.Text && a.TaiKhoan != email).ToList();
            var accNhanVien = collectionNhanVien.Find(a => a.TaiKhoan == txtTaiKhoan.Text && a.TaiKhoan != email).ToList();

            if (accQuanLy.Count > 0 || accNhanVien.Count > 0)
            {
                MessageBox.Show("Tài khoản email này đã tồn tại!");
                return;
            }

            if (txtMatKhau.Text != txtMatKhau2.Text)
            {
                MessageBox.Show("Mật khẩu nhập lại chưa khớp!");
                return;
            }

            accQuanLy = collectionQuanLy.Find(a => a.TaiKhoan == email).ToList();

            if (accQuanLy.Count > 0)
            {
                var fillter = Builders<QuanLy>.Filter.Eq("TaiKhoan", email);
                QuanLy quanLy = accQuanLy[0];
                quanLy.Ten = txtTen.Text;
                quanLy.TaiKhoan = txtTaiKhoan.Text;
                quanLy.MatKhau = txtMatKhau.Text;
                collectionQuanLy.ReplaceOne(fillter, quanLy);

                MessageBox.Show("Cập nhật tài khoản thành công!");
                this.Close();
            }
            else
            {
                accNhanVien = collectionNhanVien.Find(a => a.TaiKhoan == email).ToList();
                var fillter = Builders<NhanVien>.Filter.Eq("TaiKhoan", email);
                NhanVien nhanVien = accNhanVien[0];
                nhanVien.Ten = txtTen.Text;
                nhanVien.TaiKhoan = txtTaiKhoan.Text;
                nhanVien.MatKhau = txtMatKhau.Text;
                collectionNhanVien.ReplaceOne(fillter, nhanVien);

                MessageBox.Show("Cập nhật tài khoản thành công!");
                this.Close();
            }
        }

        private void txtMatKhau2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLuu_Click(sender, e);
            }

        }
    }
}
