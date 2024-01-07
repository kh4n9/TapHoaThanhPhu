using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TapHoaThanhPhu.Class;
using TapHoaThanhPhu.FunctionClass;

namespace TapHoaThanhPhu.Forms
{
    public partial class frmQuenMatKhau : Form
    {
        private int otp;
        private bool isQuanLy;
        private IMongoClient client = new MongoClient("mongodb://localhost:27017");
        private IMongoDatabase database;
        private IMongoCollection<QuanLy> collectionQuanLy;
        private IMongoCollection<NhanVien> collectionNhanVien;
        public frmQuenMatKhau()
        {
            InitializeComponent();
            database = client.GetDatabase("TapHoaThanhPhu");
            collectionQuanLy = database.GetCollection<QuanLy>("QuanLy");
            collectionNhanVien = database.GetCollection<NhanVien>("NhanVien");
        }

        private void btnLayMa_Click(object sender, EventArgs e)
        {

            // kiểm tra văn bản
            if (!txtTaiKhoan.Text.Contains("@") || !txtTaiKhoan.Text.Contains('.'))
            {
                MessageBox.Show("Email chưa đúng định dạng, kiểm tra lại!", "Thông báo!");
                return;
            }

            var accQuanLy = collectionQuanLy.Find(a => a.TaiKhoan == txtTaiKhoan.Text).ToList();
            var accNhanVien = collectionNhanVien.Find(a => a.TaiKhoan == txtTaiKhoan.Text).ToList();

            if (accQuanLy.Count > 0)
            {
                isQuanLy = true;
                Random rd = new Random();
                otp = rd.Next(1, 10000);
                SendMail mail = new SendMail();
                mail.Send(txtTaiKhoan.Text, "OTP", "Mã opt: " + otp.ToString());
                MessageBox.Show("Mã OPT đã được gửi đến email của bạn vui lòng kiểm tra hộp thư!", "Thông báo!");
                txtTaiKhoan.Enabled = false;
                return;
            }
            else if (accNhanVien.Count > 0)
            {
                isQuanLy = false;
                Random rd = new Random();
                otp = rd.Next(1, 10000);
                SendMail mail = new SendMail();
                mail.Send(txtTaiKhoan.Text, "OTP", "Mã opt: " + otp.ToString());
                MessageBox.Show("Mã OPT đã được gửi đến email của bạn vui lòng kiểm tra hộp thư!", "Thông báo!");
                txtTaiKhoan.Enabled = false;
                return;
            }
            else
            {
                MessageBox.Show("Tài khoản không tồn tại!");
                return;
            }
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (otp.ToString() == txtMa.Text && isQuanLy == true)
            {
                var fillter = Builders<QuanLy>.Filter.Eq("TaiKhoan", txtTaiKhoan.Text);
                var update = Builders<QuanLy>.Update.Set("MatKhau", txtMatKhau.Text);
                collectionQuanLy.UpdateOne(fillter, update);
                MessageBox.Show("Cập nhật mật khẩu thành công!");
                this.Close();
                return;
            }
            else if (otp.ToString() == txtMa.Text && isQuanLy == false)
            {
                var fillter = Builders<NhanVien>.Filter.Eq("TaiKhoan", txtTaiKhoan.Text);
                var update = Builders<NhanVien>.Update.Set("MatKhau", txtMatKhau.Text);
                collectionNhanVien.UpdateOne(fillter, update);
                MessageBox.Show("Cập nhật mật khẩu thành công!");
                this.Close();
                return;
            }
            else
            {
                MessageBox.Show("Kiểm tra lại mã OTP!");
                return;
            }
        }
    }
}
