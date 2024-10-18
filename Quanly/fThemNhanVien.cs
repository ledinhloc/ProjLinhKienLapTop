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
    public partial class fThemNhanVien : Form
    {
        private DataProvider dataProvider;
        public delegate void ThemNvEventHandler(object sender, EventArgs e);
        public event ThemNvEventHandler ThemNvAdded;
        public fThemNhanVien()
        {
            InitializeComponent();
            dataProvider = new DataProvider();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                string ten = txtTenNhanVien.Text;
                string sdt = txtSDT.Text;
                string diachi = txtDiaChi.Text;
                string email = txtEmail.Text;
                DateTime ngaysinh = dtpNgaySinh.Value;
                string mk = txtMatKhau.Text;

                SqlParameter[] sqlParameters = new SqlParameter[] {
                    new SqlParameter("@TenNhanVien",ten),
                    new SqlParameter("@SDT",sdt),
                    new SqlParameter("@Email",email),
                    new SqlParameter("@Ngaysinh",ngaysinh),
                    new SqlParameter("DiaChi",diachi),
                    new SqlParameter("MatKhau",mk)
                };
                int result = dataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "sp_ThemNhanVien", sqlParameters);
                if (result > 0)
                {
                    MessageBox.Show("Thêm nhân viên thành công!");
                    ThemNvAdded?.Invoke(this, EventArgs.Empty);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
