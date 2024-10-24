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
    public partial class fNhapHang : Form
    {
        private DataProvider dataProvider = new DataProvider();
        public fNhapHang()
        {
            InitializeComponent();
        }
        private void LoadTenLinhKienToComboBox()
        {
            try
            {
                string query = "SELECT MaLinhKien, TenLinhKien FROM vw_ThongTinLinhKien";
                DataTable dataTable = dataProvider.ExecuteReader(CommandType.Text, query);

                cbTenLinhKien.DataSource = dataTable;
                cbTenLinhKien.DisplayMember = "TenLinhKien";
                cbTenLinhKien.ValueMember = "MaLinhKien";

                cbTenLinhKien.SelectedIndex = -1;
                txtMaLinhKien.Text = ""; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách tên linh kiện: " + ex.Message);
            }
        }
        private void LoadPhieuNhapHang()
        {
            try
            {
                string query = "SELECT * FROM vw_DanhSachPhieuNhap";
                DataTable dataTable = dataProvider.ExecuteReader(CommandType.Text, query);
                dGV_PhieuNhap.DataSource = dataTable;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }
        private void fNhapHang_Load(object sender, EventArgs e)
        {
            LoadTenLinhKienToComboBox();
            LoadPhieuNhapHang();
        }

        private void cbTenLinhKien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbTenLinhKien.SelectedItem is DataRowView rowView)
            {
                txtMaLinhKien.Text = rowView["MaLinhKien"].ToString();
            }
            else
            {
                txtMaLinhKien.Text = "";
            }
        }

        private void btnThemPhieuNhap_Click(object sender, EventArgs e)
        {
            try
            {

                DateTime ngayNhap = dtpNgayNhap.Value;
                decimal giaNhap = decimal.Parse(txtGiaNhap.Text);
                int soLuong = int.Parse(txtSoLuong.Text);
                int maLinhKien = int.Parse(txtMaLinhKien.Text);
                string procedureName = "sp_ThemPhieuNhapHang";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@NgayNhap", ngayNhap),
                    new SqlParameter("@GiaNhap", giaNhap),
                    new SqlParameter("@SoLuong", soLuong),
                    new SqlParameter("@MaLinhKien", maLinhKien)
                };

                int rowsAffected = dataProvider.ExecuteNonQuery(CommandType.StoredProcedure, procedureName, parameters);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Thêm phiếu nhập hàng thành công.");
                    LoadPhieuNhapHang();
                }
                else
                {
                    MessageBox.Show("Không thể thêm phiếu nhập hàng.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm phiếu nhập hàng: " + ex.Message);
            }
        }

        private void btnXoaPhieuNhap_Click(object sender, EventArgs e)
        {
            if (dGV_PhieuNhap.SelectedRows.Count > 0)
            {
                int maPhieuNhap = Convert.ToInt32(dGV_PhieuNhap.SelectedRows[0].Cells["MaPhieuNhap"].Value);
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu nhập hàng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        string query = "EXEC DeletePhieuNhapHang @MaPhieuNhap";
                        SqlParameter param = new SqlParameter("@MaPhieuNhap", maPhieuNhap);
                        dataProvider.ExecuteNonQuery(CommandType.Text, query, param);
                        MessageBox.Show("Xóa phiếu nhập hàng thành công.");
                        LoadPhieuNhapHang(); 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa phiếu nhập hàng: " + ex.Message);
                    }
                }
                else
                {
          
                    MessageBox.Show("Hủy xóa phiếu nhập hàng.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một phiếu nhập hàng để xóa.");
            }
        }

        private void dGV_PhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                DataGridViewRow row = dGV_PhieuNhap.Rows[e.RowIndex];
                lblMaPhieuNhap.Text = row.Cells["MaPhieuNhap"].Value.ToString();
                dtpNgayNhap.Value = Convert.ToDateTime(row.Cells["NgayNhap"].Value);
                txtGiaNhap.Text = row.Cells["GiaNhap"].Value.ToString();
                txtSoLuong.Text = row.Cells["SoLuong"].Value.ToString();
                int maLinhKien = Convert.ToInt32(row.Cells["MaLinhKien"].Value);
                cbTenLinhKien.SelectedValue = maLinhKien;
            }
        }

        private void btnSuaPhieuNhap_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblMaPhieuNhap.Text))
            {
                DialogResult dialogResult = MessageBox.Show(
                    "Bạn có chắc chắn muốn sửa phiếu nhập hàng này không?",
                    "Xác nhận sửa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    int maPhieuNhap = Convert.ToInt32(lblMaPhieuNhap.Text);
                    DateTime ngayNhap = dtpNgayNhap.Value;
                    decimal giaNhap = Convert.ToDecimal(txtGiaNhap.Text);
                    int soLuong = Convert.ToInt32(txtSoLuong.Text);
                    int maLinhKien = Convert.ToInt32(txtMaLinhKien.Text);

                    try
                    {
                        string query = "EXEC UpdatePhieuNhapHang @MaPhieuNhap, @NgayNhap, @GiaNhap, @SoLuong, @MaLinhKien";
                        SqlParameter[] parameters = new SqlParameter[]
                        {
                        new SqlParameter("@MaPhieuNhap", maPhieuNhap),
                        new SqlParameter("@NgayNhap", ngayNhap),
                        new SqlParameter("@GiaNhap", giaNhap),
                        new SqlParameter("@SoLuong", soLuong),
                        new SqlParameter("@MaLinhKien", maLinhKien)
                        };

                        dataProvider.ExecuteNonQuery(CommandType.Text, query, parameters);
                        MessageBox.Show("Cập nhật phiếu nhập hàng thành công.");
                        LoadPhieuNhapHang();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật phiếu nhập hàng: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một phiếu nhập hàng để sửa.");
            }
        }
    }
}
