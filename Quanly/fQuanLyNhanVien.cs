using ProCuaHangLinhKienLaptop.DB;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProCuaHangLinhKienLaptop.NhanVien;

namespace ProCuaHangLinhKienLaptop.Quanly
{
    public partial class fQuanLyNhanVien : Form
    {
        private DataProvider dataProvider;
        private UC_ThongTinCaNhan ucthongtincanhan;
        public fQuanLyNhanVien()
        {
            dataProvider = new DataProvider();
            InitializeComponent();
            ucthongtincanhan = new UC_ThongTinCaNhan();
            dGV_NhanVien.SelectionChanged += dGV_NhanVien_SelectionChanged;
            ucthongtincanhan = new UC_ThongTinCaNhan();
            pn_Chua.Controls.Add(ucthongtincanhan);
            comboBox1.SelectedIndex = 0;
        }

        private void fQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT * FROM vw_NhanVienList";
                DataTable dataTable = dataProvider.ExecuteReader(CommandType.Text, query);
                dGV_NhanVien.DataSource = dataTable;
                string queri = "SELECT COUNT(*) FROM vw_NhanVienList";
                SqlParameter[] parameters = new SqlParameter[]
                {

                };
                object result = dataProvider.ExecuteScalar(CommandType.Text, queri, parameters);

                lblTongNhanVien.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void btnThemNhanVien_Click(object sender, EventArgs e)
        {
            fThemNhanVien nv = new fThemNhanVien();
            nv.ThemNvAdded += FormThemNvAdded;
            nv.ShowDialog();
        }
        private void FormThemNvAdded(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                string query = "SELECT * FROM vw_NhanVienList";
                DataTable dataTable = dataProvider.ExecuteReader(CommandType.Text, query);
                dGV_NhanVien.DataSource = dataTable;
                string queri = "SELECT COUNT(*) FROM vw_NhanVienList";
                SqlParameter[] parameters = new SqlParameter[]
                {

                };
                object result = dataProvider.ExecuteScalar(CommandType.Text, queri, parameters);

                lblTongNhanVien.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }

        }

        private void btnXoaKhuyenMai_Click(object sender, EventArgs e)
        {
            if (dGV_NhanVien.CurrentRow != null) // Kiểm tra có hàng được chọn
            {
                int maNhanVien = Convert.ToInt32(dGV_NhanVien.CurrentRow.Cells["MaNhanVien"].Value);


                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);


                if (result == DialogResult.Yes)
                {
                    try
                    {
                        SqlParameter[] parameters = new SqlParameter[]
                        {
                            new SqlParameter("@MaNV", maNhanVien)
                        };

                        dataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "proc_XoaNhanVien", parameters);
                        LoadData();
                        MessageBox.Show("Xóa nhân viên thành công!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting employee: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xóa.");
            }
        }

        private void dGV_NhanVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dGV_NhanVien.CurrentRow != null)
            {

                int manv = Convert.ToInt32(dGV_NhanVien.CurrentRow.Cells["MaNhanVien"].Value);
                string tennv = dGV_NhanVien.CurrentRow.Cells["TenNhanVien"].Value.ToString();
                DateTime ngaysinh = Convert.ToDateTime(dGV_NhanVien.CurrentRow.Cells["NgaySinh"].Value);
                string email = dGV_NhanVien.CurrentRow.Cells["Email"].Value.ToString();
                string sdt = dGV_NhanVien.CurrentRow.Cells["SDT"].Value.ToString();
                string diachi = dGV_NhanVien.CurrentRow.Cells["DiaChi"].Value.ToString();

                ucthongtincanhan.UpdateDiscountInfo(manv, tennv, ngaysinh, sdt, email,diachi);
            }
        }

        private void txtTenNhanVien_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchValue = txtTuKhoa.Text.Trim();
                DataTable datagrid;
                if (comboBox1.SelectedItem.ToString() == "Tìm theo email")
                {
                    datagrid = dataProvider.ExecuteReader(CommandType.Text,
                        "SELECT * FROM dbo.fn_SearchNhanVienByEmail(@Email)",
                        new SqlParameter("@Email", searchValue));
                }
                else if (comboBox1.SelectedItem.ToString() == "Tìm theo tên")
                {
                    // Gọi hàm tìm kiếm theo Tên
                    datagrid = dataProvider.ExecuteReader(CommandType.Text,
                        "SELECT * FROM dbo.fn_SearchNhanVienByName(@TenNhanVien)",
                        new SqlParameter("@TenNhanVien", searchValue));
                }
                else
                {
                    // Nếu không có lựa chọn nào
                    return;
                }

                // Đưa dữ liệu vào DataGridView
                dGV_NhanVien.DataSource = datagrid;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Da co loi khi tim " + ex.Message);
            }

            
        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            if (dGV_NhanVien.CurrentRow != null) // Kiểm tra có hàng được chọn
            {
                int maNhanVien = Convert.ToInt32(dGV_NhanVien.CurrentRow.Cells["MaNhanVien"].Value);
                fThongTinNhanVien fThongTinNV = new fThongTinNhanVien(maNhanVien);
                fThongTinNV.ShowDialog();
                LoadData();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để sửa.");
            }
        }
    }
}
