using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TapHoaThanhPhu.GiaoDien;

namespace TapHoaThanhPhu.Forms
{
    public partial class frmQuanLy : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public frmQuanLy()
        {
            InitializeComponent();
        }

        private void mnDanhSachTaiKhoan_Click(object sender, EventArgs e)
        {
            fcShow.Controls.Clear();
            ucDanhSachTaiKhoan ucDanhSachTaiKhoan = new ucDanhSachTaiKhoan();
            fcShow.Controls.Add(ucDanhSachTaiKhoan);
        }

        private void mnTaoTaiKhoan_Click(object sender, EventArgs e)
        {
            fcShow.Controls.Clear();
            ucThemThaiKhoan ucThemThaiKhoan = new ucThemThaiKhoan();
            fcShow.Controls.Add(ucThemThaiKhoan);
        }

        private void mnThemMatHang_Click(object sender, EventArgs e)
        {
            fcShow.Controls.Clear();
            ucMatHang ucMatHang = new ucMatHang();
            fcShow.Controls.Add(ucMatHang);
        }

        private void mnDoanhThu_Click(object sender, EventArgs e)
        {
            fcShow.Controls.Clear();
            ucDoanhThu ucDoanhThu = new ucDoanhThu();
            fcShow.Controls.Add(ucDoanhThu);
        }
    }
}
