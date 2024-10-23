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
using ProCuaHangLinhKienLaptop.DB;
using System.IO;

namespace ProCuaHangLinhKienLaptop.Quanly
{
    public partial class fThemLinhKien : Form
    {
        DataProvider dataProvider = new DataProvider();
        public fThemLinhKien()
        {
            InitializeComponent();
        }

        private void fThemLinhKien_Load(object sender, EventArgs e)
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
                txtHinhAnh.Text = fullPath;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string tenLinhKien = txtTenLinhKien.Text;
                string moTa = txtMoTa.Text;
                // string hinhAnh = txtHinhAnh.Text;

                // Lấy tên file hình ảnh
                string fileName = Path.GetFileName(txtHinhAnh.Text);

                // Lùi lên 2 cấp từ thư mục thực thi hiện tại để đến thư mục gốc của project
                string projectPath = Directory.GetParent(Application.StartupPath).Parent.FullName;

                // Tạo đường dẫn đến thư mục Resources trong project
                string resourcesPath = Path.Combine(projectPath, "Resources");

                // Kiểm tra nếu thư mục Resources không tồn tại thì tạo mới
                if (!Directory.Exists(resourcesPath))
                {
                    Directory.CreateDirectory(resourcesPath);
                }

                // Tạo đường dẫn đầy đủ cho file đích
                string destFilePath = Path.Combine(resourcesPath, fileName);

                // Copy file hình ảnh vào thư mục Resources
                File.Copy(txtHinhAnh.Text, destFilePath, true);


                decimal giaBan = decimal.Parse(txtGiaBan.Text);
                decimal giaNhap = decimal.Parse(txtGiaNhap.Text);
                int soLuongTonKho = int.Parse(txtSoLuongTonKho.Text);
                int maLoaiLinhKien = (int)cbMaLoaiLinhKien.SelectedValue;
                int maNhaCungCap = (int)cbMaNhaCungCap.SelectedValue;

                string query = "sp_ThemLinhKien";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@TenLinhKien", tenLinhKien),
                    new SqlParameter("@MoTaChiTiet", moTa),
                    new SqlParameter("@HinhAnh", fileName),
                    new SqlParameter("@GiaBan", giaBan),
                    new SqlParameter("@GiaNhap", giaNhap),
                    new SqlParameter("@SoLuongTonKho", soLuongTonKho),
                    new SqlParameter("@MaLoaiLinhKien", maLoaiLinhKien),
                    new SqlParameter("@MaNhaCungCap", maNhaCungCap)
                };

                dataProvider.ExecuteNonQuery(CommandType.StoredProcedure, query, parameters);
                MessageBox.Show("Thêm linh kiện thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
