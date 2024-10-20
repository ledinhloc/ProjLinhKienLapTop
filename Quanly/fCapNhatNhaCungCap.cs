using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProCuaHangLinhKienLaptop.DB;
namespace ProCuaHangLinhKienLaptop.Quanly
{
    public partial class fCapNhatNhaCungCap : Form
    {
        int id;
        DataProvider dataProvider = new DataProvider();
        public fCapNhatNhaCungCap(int maNCC)
        {
            this.id = maNCC;
            InitializeComponent();
            string query = "sp_TimKiemNCCTheoID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaNCC", maNCC)
            };

            DataTable dt = dataProvider.ExecuteReader(CommandType.StoredProcedure, query, parameters);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                textBox1.Text = row["TenNhaCungCap"].ToString();
                textBox2.Text = row["DiaChi"].ToString();
                textBox3.Text = row["SDT"].ToString();
                textBox4.Text = row["Email"].ToString();
            }
            else
            {
                MessageBox.Show("Không tìm thấy nhà cung cấp.");
            }
        }

        private void fCapNhatNhaCungCap_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string TenNCC = textBox1.Text;
                string DiaChi = textBox2.Text;
                string SDT = textBox3.Text;
                string Email = textBox4.Text;
                string query = "sp_SuaNhaCungCap";
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@MaNhaCungCap", this.id),
                    new SqlParameter("@TenNhaCungCap", TenNCC),
                    new SqlParameter("@DiaChi", DiaChi),
                    new SqlParameter("@SDT", SDT),
                    new SqlParameter("@EMAIL", Email)
                };
                dataProvider.ExecuteNonQuery(CommandType.StoredProcedure, query, parameters);
                MessageBox.Show("Sửa NCC thành công!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
