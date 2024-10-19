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
using System.Data.SqlClient;

namespace ProCuaHangLinhKienLaptop.Quanly
{
    public partial class ChiTietDonHang : Form
    {
        DataProvider dataProvider = new DataProvider();
        private int maDonHang;
        public ChiTietDonHang(int maDonHang)
        {
            InitializeComponent();
            this.maDonHang = maDonHang;
        }

        private void ChiTietDonHang_Load(object sender, EventArgs e)
        {
            dgvChiTietDonHang.DataSource = dataProvider.ExecuteReader(CommandType.StoredProcedure, "sp_ChiTietDonHang",
                new SqlParameter[] { new SqlParameter("@MaDonHang", maDonHang) });
        }
    }
}
