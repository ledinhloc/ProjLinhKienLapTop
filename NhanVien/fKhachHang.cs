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

namespace ProCuaHangLinhKienLaptop.NhanVien
{
    public partial class fKhachHang : Form
    {
        DataProvider dataProvider = new DataProvider();
        public fKhachHang()
        {
            InitializeComponent();
            updateDgvKhachHang();
            cboSearchOptions.SelectedIndex = 0;
        }
        private void updateDgvKhachHang()
        {
            dgvKhachHang.DataSource = dataProvider.ExecuteReader(CommandType.Text, "SELECT * FROM vw_KhachHangList");
            lblSoKhachHang.Text = dataProvider.ExecuteScalar(CommandType.Text, "SELECT dbo.fn_TinhTongKhachHang()").ToString();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            dtpBirth.Value = DateTime.Now;
            txtAddress.Clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                MessageBox.Show("ID đã có nhấn Reset để tạo mới", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (txtName.Text == "" || txtEmail.Text == "" || txtPhone.Text == "" || txtAddress.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@TenKhachHang", txtName.Text),
                new SqlParameter("@DiaChi", txtAddress.Text),
                new SqlParameter("@SDT", txtPhone.Text),
                new SqlParameter("@Email", txtEmail.Text),
                new SqlParameter("@NgaySinh", dtpBirth.Value),
            };

            try
            {
                if (dataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "sp_ThemKhachHang", sqlParameters) > 0)
                {
                    updateDgvKhachHang();
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Vui lòng chọn khách hàng để xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@MaKhachHang", txtID.Text),  
                new SqlParameter("@TenKhachHang", txtName.Text),
                new SqlParameter("@DiaChi", txtAddress.Text),
                new SqlParameter("@SDT", txtPhone.Text),
                new SqlParameter("@Email", txtEmail.Text),
                new SqlParameter("@NgaySinh", dtpBirth.Value),
            };

            try
            {
                if (dataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "sp_SuaKhachHang", sqlParameters) > 0)
                {
                    updateDgvKhachHang();
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Vui lòng chọn khách hàng để xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                if (dataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "sp_XoaKhachHang", new SqlParameter[] { new SqlParameter("@MaKhachHang", txtID.Text) }) > 0)
                {
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            updateDgvKhachHang();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];

                txtID.Text = row.Cells["MaKhachHang"].Value.ToString();
                txtName.Text = row.Cells["TenKhachHang"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtPhone.Text = row.Cells["SDT"].Value.ToString();
                dtpBirth.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
                txtAddress.Text = row.Cells["DiaChi"].Value.ToString() ?? "";
            }

        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            if (txtTim.Text == "")
            {
                updateDgvKhachHang();
                return;
            }

            dgvKhachHang.DataSource = dataProvider.ExecuteReader(CommandType.StoredProcedure, "sp_TimKiemKhachHang", new SqlParameter[] {
                    new SqlParameter("@SearchOption", cboSearchOptions.SelectedItem),
                    new SqlParameter("@SearchText", txtTim.Text)
            });
        }

        private void fKhachHang_Load(object sender, EventArgs e)
        {

        }
    }
}
