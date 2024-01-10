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
        private IMongoClient client = new MongoClient("mongodb://localhost:27017");
        private IMongoDatabase database;
        private IMongoCollection<MatHang> collectionMatHang;

        public ucNhapHang()
        {
            InitializeComponent();
            database = client.GetDatabase("TapHoaThanhPhu");
            collectionMatHang = database.GetCollection<MatHang>("MatHang");
        }

        private void ucNhapHang_Load(object sender, EventArgs e)
        {

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
        }
    }
}
