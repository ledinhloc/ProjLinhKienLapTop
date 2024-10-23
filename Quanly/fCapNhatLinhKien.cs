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
using ProCuaHangLinhKienLaptop.DB;
using System.Data.SqlClient;
using static System.Windows.Forms.LinkLabel;
namespace ProCuaHangLinhKienLaptop.Quanly
{
    
    public partial class fCapNhatLinhKien : Form
    {
        int id;
        DataProvider dataProvider = new DataProvider();
        public fCapNhatLinhKien(int maLinhKien)
        {
            this.id = maLinhKien;
            InitializeComponent();
            string query = "sp_TimKiemLinhKienTheoID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaLinhKien", maLinhKien)
            };

            DataTable dt = dataProvider.ExecuteReader(CommandType.StoredProcedure, query, parameters);

            if (dt.Rows.Count > 0)
            {
                // Đổ dữ liệu vào các ô
                DataRow row = dt.Rows[0];
                txtTenLinhKien.Text = row["TenLinhKien"].ToString();
                txtMoTa.Text = row["MoTaChiTiet"].ToString();
                txtHinhAnh.Text = row["HinhAnh"].ToString();
                txtGiaBan.Text = row["GiaBan"].ToString();
                txtGiaNhap.Text = row["GiaNhap"].ToString();
                txtSoLuongTonKho.Text = row["SoLuongTonKho"].ToString();
                cbMaLoaiLinhKien.SelectedValue = row["MaLoaiLinhKien"];
                cbMaNhaCungCap.SelectedValue = row["MaNhaCungCap"];
            }
            else
            {
                MessageBox.Show("Không tìm thấy linh kiện.");
            }
    }

        private void fCapNhatLinhKien_Load(object sender, EventArgs e)
        {
            DataTable loaiLinhKien = dataProvider.ExecuteReader(CommandType.Text, "SELECT * FROM LoaiLinhKien");
            cbMaLoaiLinhKien.DataSource = loaiLinhKien;
            cbMaLoaiLinhKien.DisplayMember = "TenLoaiLinhKien";
            cbMaLoaiLinhKien.ValueMember = "MaLoaiLinhKien";

            DataTable nhaCungCap = dataProvider.ExecuteReader(CommandType.Text, "SELECT * FROM NhaCungCap");
            cbMaNhaCungCap.DataSource = nhaCungCap;
            cbMaNhaCungCap.DisplayMember = "TenNhaCungCap";
            cbMaNhaCungCap.ValueMember = "MaNhaCungCap";
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fullPath = openFileDialog.FileName;

                int index = fullPath.IndexOf("Resources");

                if (index != -1)
                {
                    string relativePath = fullPath.Substring(index);
                    txtHinhAnh.Text = relativePath;
                }
                else
                {
                    txtHinhAnh.Text = fullPath;
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string tenLinhKien = txtTenLinhKien.Text;
                string moTa = txtMoTa.Text;
                string hinhAnh = txtHinhAnh.Text;
                decimal giaBan = decimal.Parse(txtGiaBan.Text);
                decimal giaNhap = decimal.Parse(txtGiaNhap.Text);
                int soLuongTonKho = int.Parse(txtSoLuongTonKho.Text);
                int maLoaiLinhKien = (int)cbMaLoaiLinhKien.SelectedValue;
                int maNhaCungCap = (int)cbMaNhaCungCap.SelectedValue;

                string query = "sp_SuaLinhKien";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaLinhKien", this.id),
                    new SqlParameter("@TenLinhKien", tenLinhKien),
                    new SqlParameter("@MoTaChiTiet", moTa),
                    new SqlParameter("@HinhAnh", hinhAnh),
                    new SqlParameter("@GiaBan", giaBan),
                    new SqlParameter("@GiaNhap", giaNhap),
                    new SqlParameter("@SoLuongTonKho", soLuongTonKho),
                    new SqlParameter("@MaLoaiLinhKien", maLoaiLinhKien),
                    new SqlParameter("@MaNhaCungCap", maNhaCungCap)
                };

                dataProvider.ExecuteNonQuery(CommandType.StoredProcedure, query, parameters);
                MessageBox.Show("Sửa linh kiện thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

    }
}
