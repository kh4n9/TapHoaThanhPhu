﻿using MongoDB.Driver;
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
using TapHoaThanhPhu.Forms;
using TapHoaThanhPhu.FunctionClass;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TapHoaThanhPhu
{
    public partial class frmDangNhap : Form
    {
        private IMongoClient client = new MongoClient("mongodb://localhost:27017");
        private IMongoDatabase database;
        private IMongoCollection<QuanLy> collectionQuanLy;
        private IMongoCollection<NhanVien> collectionNhanVien;

        public frmDangNhap()
        {
            InitializeComponent();
            database = client.GetDatabase("TapHoaThanhPhu");
            collectionQuanLy = database.GetCollection<QuanLy>("QuanLy");
            collectionNhanVien = database.GetCollection<NhanVien>("NhanVien");
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            // kiểm tra văn bản
            if (!(txtTaiKhoan.Text == "admin"))
            {
                if (!txtTaiKhoan.Text.Contains("@") || !txtTaiKhoan.Text.Contains('.'))
                {
                    MessageBox.Show("Email chưa đúng định dạng, kiểm tra lại!", "Thông báo!");
                    return;
                }
            }

            GetMD5String getMD5String = new GetMD5String();

            var accQuanLy = collectionQuanLy.Find(a => a.TaiKhoan == txtTaiKhoan.Text && a.MatKhau == getMD5String.HashPassword(txtMatKhau.Text)).ToList();
            var accNhanVien = collectionNhanVien.Find(a => a.TaiKhoan == txtTaiKhoan.Text && a.MatKhau == getMD5String.HashPassword(txtMatKhau.Text)).ToList();

            if (accQuanLy.Count > 0)
            {
                MessageBox.Show("Đăng nhập thành công!");
                this.Hide();
                frmQuanLy frmQuanLy = new frmQuanLy(accQuanLy[0].Ten);
                frmQuanLy.ShowDialog();
                this.Visible = true;
            }
            else if (accNhanVien.Count > 0)
            {
                MessageBox.Show("Đăng nhập thành công!");
                this.Hide();
                frmNhanVien frmNhanVien = new frmNhanVien(accNhanVien[0].Ten);
                frmNhanVien.ShowDialog();
                this.Visible = true;
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!");
            }
        }

        private void lblQuenMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Visible = false;
            frmQuenMatKhau frmQuenMatKhau = new frmQuenMatKhau();
            frmQuenMatKhau.ShowDialog();
            this.Visible = true;
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            // tạo mới tài khoản admin khi chưa có quản lý nào
            if (!collectionQuanLy.Find(a => true).Any())
            {
                QuanLy quanLy = new QuanLy();
                quanLy.TaiKhoan = "admin";
                GetMD5String getMD5String = new GetMD5String();
                quanLy.MatKhau = getMD5String.HashPassword("admin");
                quanLy.Ten = "admin";
                collectionQuanLy.InsertOne(quanLy);
                MessageBox.Show("Sử dụng tài khoản: admin và mật khẩu: admin để đăng nhập vào quản lý!");
            }
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap_Click(sender, e);
            }

        }
    }

}
