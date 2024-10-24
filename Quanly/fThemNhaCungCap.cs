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
namespace ProCuaHangLinhKienLaptop.Quanly
{
    public partial class fThemNhaCungCap : Form
    {
        DataProvider dataProvider = new DataProvider();
        public fThemNhaCungCap()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string TenNCC = textBox1.Text;
                string DiaChi = textBox2.Text;
                string SDT = textBox3.Text;
                string Email = textBox4.Text;
                string query = "sp_ThemNhaCungCap";
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@TenNhaCungCap", TenNCC),
                    new SqlParameter("@DiaChi", DiaChi),
                    new SqlParameter("@SDT", SDT),
                    new SqlParameter("@EMAIL", Email)
                };
                dataProvider.ExecuteNonQuery(CommandType.StoredProcedure, query, parameters);
                MessageBox.Show("Thêm nhà cung cấp thành công!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void fThemNhaCungCap_Load(object sender, EventArgs e)
        {

        }

        private void fThemNhaCungCap_Load_1(object sender, EventArgs e)
        {

        }
    }
}
