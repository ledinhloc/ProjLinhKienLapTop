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
    public partial class fThongTinNhanVien : Form
    {
        DataProvider dataProvider = new DataProvider();
        int maNhanVien;
        public fThongTinNhanVien(int maNhanVien)
        {
            InitializeComponent();
            this.maNhanVien = maNhanVien;
        }

        private void fThongTinNhanVien_Load(object sender, EventArgs e)
        {
            LoadThongTinNV(maNhanVien);
        }

        public void LoadThongTinNV(int maNV)
        {
            try
            {
                DataTable rows = dataProvider.ExecuteReader(CommandType.Text, "SELECT * FROM fn_TimNhanVien(@MaNhanVien)", new SqlParameter("@MaNhanVien", maNV));

                DataRow row = rows.Rows[0];
                txtMaNhanVien.Text = row["MaNhanVien"].ToString();
                txtTen.Text = row["TenNhanVien"].ToString();
                txtDiaChi.Text = row["DiaChi"].ToString();
                txtSDT.Text = row["SDT"].ToString();
                txtEmail.Text = row["Email"].ToString();
                txtMatKhau.Text = row["MatKhau"].ToString();
                dtpNgaySinh.Value = DateTime.Parse(row["NgaySinh"].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@MaNhanVien", maNhanVien),
                new SqlParameter("@TenNhanVien", txtTen.Text),
                new SqlParameter("@DiaChi", txtDiaChi.Text),
                new SqlParameter("@SDT", txtSDT.Text),
                new SqlParameter("@Email", txtEmail.Text),
                new SqlParameter("@MatKhau", txtMatKhau.Text),
                new SqlParameter("@NgaySinh", dtpNgaySinh.Value.ToString("yyyy-MM-dd"))
            };

            try
            {
                int kq = dataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "sp_SuaNhanVien", sqlParameters);
                if (kq > 0)
                {
                    MessageBox.Show(kq+"Đã sửa thành công", "Thông Báo");
                }
                else
                {
                    MessageBox.Show("Sửa thất bại", "Thông Báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }

        private void chkMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if(chkMatKhau.Checked == true)
            {
                txtMatKhau.UseSystemPasswordChar = false;//hien mat khau
            }
            else
            {
                txtMatKhau.UseSystemPasswordChar = true;
            }
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            LoadThongTinNV(maNhanVien);

        }
    }
}
