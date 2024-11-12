using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProCuaHangLinhKienLaptop.DB;
using System.Data.SqlClient;
using ProCuaHangLinhKienLaptop.NhanVien;

namespace ProCuaHangLinhKienLaptop.Quanly
{
    public partial class fLuong : Form
    {
        DataProvider dataProvider = new DataProvider();
        bool isFirst = true;
        public fLuong()
        {
            InitializeComponent();
            cmbThang.SelectedIndex = 10;
            cmbNam.SelectedIndex = 2;
            dgvLuong.DataSource = dataProvider.ExecuteReader(CommandType.Text, "SELECT * FROM fn_XemTatCaLuongTheoThangNam(@Thang, @Nam)",
                new SqlParameter[]
                {
                    new SqlParameter("Thang", DateTime.Now.Month),
                    new SqlParameter("Nam", DateTime.Now.Year)
                });
        }

        private void cmbThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(isFirst) { isFirst = false; return; }
                dgvLuong.DataSource = dataProvider.ExecuteReader(CommandType.Text, "SELECT * FROM fn_XemTatCaLuongTheoThangNam(@Thang, @Nam)",
                    new SqlParameter[]
                    {
                        new SqlParameter("Thang", cmbThang.SelectedItem),
                        new SqlParameter("Nam", cmbNam.SelectedItem)
                    });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvLuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    String maNhanVien = dgvLuong.Rows[e.RowIndex].Cells["MaNhanVien"].Value.ToString();
                    fThongKeCuaNhanVien formThongTin = new fThongKeCuaNhanVien(maNhanVien);
                    formThongTin.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
    }
}
