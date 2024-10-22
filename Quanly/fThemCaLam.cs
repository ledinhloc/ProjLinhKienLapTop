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
    public partial class fThemCaLam : Form
    {
        DataProvider dataProvider = new DataProvider();
        public int maLichLamViec;
        public fThemCaLam(int ma)
        {
            InitializeComponent();
            maLichLamViec = ma;

            DataTable data = dataProvider.ExecuteReader(CommandType.Text, "SELECT MaNhanVien, TenNhanVien FROM NhanVien");

            cboNhanVien.DataSource = data;
            cboNhanVien.DisplayMember = "TenNhanVien";
            cboNhanVien.ValueMember = "MaNhanVien";

            cboTrangThai.Items.Add("HoanThanh");
            cboTrangThai.Items.Add("Chua");
            cboTrangThai.SelectedIndex = 1;

        }

        private void fThemCaLam_Load(object sender, EventArgs e)
        {


            dgvNhanVien.DataSource = dataProvider.ExecuteReader(CommandType.Text, "SELECT * FROM fn_XemNhanVienTrongLichLamViec (@MaLichLamViec)", new SqlParameter("@MaLichLamViec", maLichLamViec));
            dgvNhanVien.Columns["MaNhanVien"].Visible = false;


        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@MaNhanVien", cboNhanVien.SelectedValue),
                new SqlParameter("@MaLichLamViec", maLichLamViec),
                new SqlParameter("@DanhGia", txtDanhGia.Text),
                new SqlParameter("@TrangThai", cboTrangThai.SelectedItem)

            };

            try
            {
                dataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "sp_ThemCoLichLam", sqlParameters);
                fThemCaLam_Load(sender, e);

            }
            catch (Exception ex)
            {
                MessageBox.Show("co loi" + ex.Message);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
                {
                new SqlParameter("@MaNhanVien", cboNhanVien.SelectedValue),
                new SqlParameter("@MaLichLamViec", maLichLamViec),
                new SqlParameter("@DanhGia", txtDanhGia.Text),
                new SqlParameter("@TrangThai", cboTrangThai.SelectedItem)
                };

            try
            {
                dataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "sp_SuaCoLichLam", sqlParameters);
                fThemCaLam_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("co loi" + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@MaNhanVien", cboNhanVien.SelectedValue),
                new SqlParameter("@MaLichLamViec", maLichLamViec),
             };

            try
            {
                dataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "sp_XoaCoLichLam", sqlParameters);
                fThemCaLam_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("co loi" + ex.Message);
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvNhanVien.Rows.Count-1) // Kiểm tra nếu hàng hợp lệ
            {
                DataGridViewRow selectedRow = dgvNhanVien.Rows[e.RowIndex];

                cboNhanVien.SelectedValue = selectedRow.Cells["MaNhanVien"].Value.ToString();
                cboTrangThai.SelectedItem = selectedRow.Cells["TrangThai"].Value.ToString();
                txtDanhGia.Text = selectedRow.Cells["DanhGia"].Value.ToString();

            }
        }
    }
}

