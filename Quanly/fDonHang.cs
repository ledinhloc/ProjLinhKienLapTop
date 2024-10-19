using ProCuaHangLinhKienLaptop.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProCuaHangLinhKienLaptop.Quanly
{
    public partial class fDonHang : Form
    {
        DataProvider dataProvider = new DataProvider();
        public fDonHang()
        {
            InitializeComponent();
        }

        private void fDonHang_Load(object sender, EventArgs e)
        {
            dgvDonHang.DataSource = dataProvider.ExecuteReader(CommandType.Text, "SELECT * FROM vw_DonHangList");
        }

        private void dgvDonHang_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int maDonHang = (int)dgvDonHang.Rows[e.RowIndex].Cells["MaDonHang"].Value;
                ChiTietDonHang chiTietDonHang = new ChiTietDonHang(maDonHang);
                chiTietDonHang.Show();
            }
        }
    }
}
