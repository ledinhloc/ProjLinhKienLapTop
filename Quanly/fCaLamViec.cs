using ProCuaHangLinhKienLaptop.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProCuaHangLinhKienLaptop.Quanly
{
    public partial class fCaLamViec : Form
    {
        DataProvider dataProvider = new DataProvider();
        public fCaLamViec()
        {
            InitializeComponent();
            for (int i = 0;i <24; i++)
            {
                cboGioBD.Items.Add(i.ToString());
                cboGioKT.Items.Add(i.ToString());
            }

            for(int i = 0; i < 60; i++)
            {
                cboPhutBD.Items.Add(i.ToString());
                cboPhutKT.Items.Add(i.ToString());
            }
            cboGioBD.SelectedIndex = 6;
            cboGioKT.SelectedIndex = 9;

            cboPhutBD.SelectedIndex = 0;
            cboPhutKT.SelectedIndex = 0;

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string thoiGianBD = cboGioBD.SelectedItem + ":" + cboPhutBD.SelectedItem + ":00";
            string thoiGianKT = cboGioKT.SelectedItem + ":" + cboPhutKT.SelectedItem + ":00";

            //MessageBox.Show(gioBD);
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@TenCa", txtTenCa.Text),
                new SqlParameter("@GioBatDau", thoiGianBD),
                new SqlParameter("@GioKetThuc", thoiGianKT)
            };

            try
            {
                dataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "sp_ThemCaLamViec", sqlParameters);
                fCaLamViec_Load(sender, e);

            }
            catch (Exception ex)
            {
                MessageBox.Show("co loi" + ex.Message);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string thoiGianBD = cboGioBD.SelectedItem + ":" + cboPhutBD.SelectedItem + ":00";
            string thoiGianKT = cboGioKT.SelectedItem + ":" + cboPhutKT.SelectedItem + ":00";

            //MessageBox.Show(gioBD);
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@MaCa", txtMaCa.Text),
                new SqlParameter("@TenCa", txtTenCa.Text),
                new SqlParameter("@GioBatDau", thoiGianBD),
                new SqlParameter("@GioKetThuc", thoiGianKT)
            };

            try
            {
                dataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "sp_SuaCaLamViec", sqlParameters);
                fCaLamViec_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("co loi" + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                dataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "sp_XoaCaLamViec", new SqlParameter("@MaCa", txtMaCa.Text));
                fCaLamViec_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("co loi" + ex.Message);
            }
        }

        private void fCaLamViec_Load(object sender, EventArgs e)
        {
            dgvCaLam.DataSource = dataProvider.ExecuteReader(CommandType.Text, "SELECT * FROM vw_XemCaLam");
        }

        private void dgvCaLam_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu hàng hợp lệ
            if (e.RowIndex >= 0 && e.RowIndex < dgvCaLam.Rows.Count - 1) 
            {
                DataGridViewRow selectedRow = dgvCaLam.Rows[e.RowIndex];

                txtMaCa.Text = selectedRow.Cells["MaCa"].Value.ToString();
                txtTenCa.Text = selectedRow.Cells["TenCa"].Value.ToString();

                TimeSpan thoiGianBD =TimeSpan.Parse(selectedRow.Cells["GioBatDau"].Value.ToString());
                cboGioBD.SelectedItem = thoiGianBD.Hours.ToString();
                cboPhutBD.SelectedItem = thoiGianBD.Minutes.ToString();

                TimeSpan thoiGianKT = TimeSpan.Parse(selectedRow.Cells["GioKetThuc"].Value.ToString());
                cboGioKT.SelectedItem = thoiGianKT.Hours.ToString();
                cboPhutKT.SelectedItem = thoiGianKT.Minutes.ToString();
                //cboNhanVien.SelectedValue = selectedRow.Cells["MaNhanVien"].Value.ToString();
                //cboTrangThai.SelectedItem = selectedRow.Cells["TrangThai"].Value.ToString();
                //txtDanhGia.Text = selectedRow.Cells["DanhGia"].Value.ToString();

            }
        }
    }
}
