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
using TapHoaThanhPhu.FunctionClass;

namespace TapHoaThanhPhu.GiaoDien
{
    public partial class ucThemThaiKhoan : UserControl
    {
        private IMongoClient client = new MongoClient("mongodb://localhost:27017");
        private IMongoDatabase database;
        private IMongoCollection<QuanLy> collectionQuanLy;
        private IMongoCollection<NhanVien> collectionNhanVien;
        public ucThemThaiKhoan()
        {
            InitializeComponent();
            database = client.GetDatabase("TapHoaThanhPhu");
            collectionQuanLy = database.GetCollection<QuanLy>("QuanLy");
            collectionNhanVien = database.GetCollection<NhanVien>("NhanVien");
        }

        private void ucThemThaiKhoan_Load(object sender, EventArgs e)
        {
            cbbLoai.SelectedIndex = 0;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // kiểm tra văn bản
            if (!txtTaiKhoan.Text.Contains("@") || !txtTaiKhoan.Text.Contains('.'))
            {
                MessageBox.Show("Email chưa đúng định dạng, kiểm tra lại!", "Thông báo!");
                return;
            }

            var accQuanLy = collectionQuanLy.Find(a => a.TaiKhoan == txtTaiKhoan.Text).ToList();
            var accNhanVien = collectionNhanVien.Find(a => a.TaiKhoan == txtTaiKhoan.Text).ToList();

            if (accQuanLy.Count > 0 || accNhanVien.Count > 0)
            {
                MessageBox.Show("Tài khoản email này đã tồn tại!");
                return;
            }

            if (txtMatKhau.Text != txtNhapLaiMatKhau.Text)
            {
                MessageBox.Show("Mật khẩu nhập lại chưa khớp!");
                return;
            }

            if (cbbLoai.SelectedIndex == 0)
            {
                NhanVien nhanVien = new NhanVien();
                nhanVien.Ten = txtTen.Text;
                nhanVien.TaiKhoan = txtTaiKhoan.Text;
                GetMD5String getMD5String = new GetMD5String();
                nhanVien.MatKhau = getMD5String.HashPassword(txtMatKhau.Text);

                collectionNhanVien.InsertOne(nhanVien);
                MessageBox.Show("Thêm thành công một nhân viên!");
                return;
            }
            else
            {
                QuanLy quanLy = new QuanLy();
                quanLy.Ten = txtTen.Text;
                quanLy.TaiKhoan = txtTaiKhoan.Text;
                GetMD5String getMD5String = new GetMD5String();
                quanLy.MatKhau = getMD5String.HashPassword(txtMatKhau.Text);

                collectionQuanLy.InsertOne(quanLy);
                MessageBox.Show("Thêm thành công một quản lý!");
                return;
            }
        }
    }
}
