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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ProCuaHangLinhKienLaptop.DB;
namespace ProCuaHangLinhKienLaptop.Quanly
{
    public partial class fThemLoaiLinhKien : Form
    {
        DataProvider dataProvider = new DataProvider();
        public fThemLoaiLinhKien()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void fThemLoaiLinhKien_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string TenLLK = textBox1.Text;
                string query = "sp_ThemLoaiLinhKien";
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@TenLoaiLinhKien", TenLLK),
                };
                dataProvider.ExecuteNonQuery(CommandType.StoredProcedure, query, parameters);
                MessageBox.Show("Thêm loại kiện thành công!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
