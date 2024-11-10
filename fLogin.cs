using ProCuaHangLinhKienLaptop.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProCuaHangLinhKienLaptop
{
    public partial class fLogin : Form
    {
        
        public fLogin()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            
            string chucVu = "";
            Program.Email = txtEmail.Text;
            Program.MatKhau = txtPass.Text;
            if (rdbNhanVien.Checked)
            {
                chucVu = "nv";
            }
            else
            {
                chucVu = "ql";
            }

            DataProvider provider = new DataProvider();
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@email", txtEmail.Text),
                new SqlParameter("@matKhau", txtPass.Text),
                new SqlParameter("@chucVu", chucVu)
            };

            string maNhanVien = "";
            try
            {
                object kq = provider.ExecuteScalar(CommandType.Text, "SELECT MaNhanVien FROM NhanVien nv WHERE nv.Email = @email AND nv.MatKhau = @matKhau AND nv.ChucVu = @chucVu", sqlParameters);
                maNhanVien = Convert.ToString(kq);
                //MessageBox.Show(maNhanVien);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                return;
            }

            if (rdbNhanVien.Checked)
            {
                fNhanVien fNhanVien = new fNhanVien(maNhanVien);
                this.Hide();
                fNhanVien.ShowDialog();
            }
            else
            {
                fAdmin fAdmin = new fAdmin();
                this.Hide();
                fAdmin.ShowDialog();
            }            
        }

        private void fLogin_Load(object sender, EventArgs e)
        {

        }

        private void rdbNhanVien_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbNhanVien.Checked)
            {
                txtEmail.Text = "tranthilan@company.com";
                txtPass.Text = "matkhau2";
            }
            else
            {
                txtEmail.Text = "nguyenvantam@company.com";
                txtPass.Text = "matkhau1";
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
