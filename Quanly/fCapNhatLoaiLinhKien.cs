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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace ProCuaHangLinhKienLaptop.Quanly
{
    public partial class fCapNhatLoaiLinhKien : Form
    {
        int id;
        DataProvider dataProvider = new DataProvider();
        public fCapNhatLoaiLinhKien(int maLLK)
        {
            this.id = maLLK;
            InitializeComponent();
            string query = "sp_TimKiemLoaiLinhKienTheoID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaLLK", maLLK)
            };

            DataTable dt = dataProvider.ExecuteReader(CommandType.StoredProcedure, query, parameters);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                textBox1.Text = row["TenLoaiLinhKien"].ToString();
            }
            else
            {
                MessageBox.Show("Không tìm thấy loại linh kiện.");
            }
        }

        private void fCapNhatLoaiLinhKien_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string TenLLK = textBox1.Text;
                string query = "sp_SuaLoaiLinhKien";
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@MaLoaiLinhKien", this.id),
                    new SqlParameter("@TenLoaiLinhKien", TenLLK),
                };
                dataProvider.ExecuteNonQuery(CommandType.StoredProcedure, query, parameters);
                MessageBox.Show("Sửa loại linh kiện thành công!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
