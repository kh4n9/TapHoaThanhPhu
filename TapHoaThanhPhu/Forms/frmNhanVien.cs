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
    public partial class frmNhanVien : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }
        private void mnHoaDon_Click(object sender, EventArgs e)
        {
            fcShow.Controls.Clear();
            ucHoaDon ucHoaDon = new ucHoaDon();
            fcShow.Controls.Add(ucHoaDon);
        }
        private void mnNhapHang_Click(object sender, EventArgs e)
        {
            fcShow.Controls.Clear();
            ucNhapHang ucNhapHang = new ucNhapHang();
            fcShow.Controls.Add(ucNhapHang);
        }
        private void mnDangXuat_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đăng xuất thành công!");
            this.Close();
        }
    }
}
