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
    public partial class fThongKeLinhKien : Form
    {
        DataProvider dataProvider = new DataProvider();
        public fThongKeLinhKien()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void fThongKeLinhKien_Load(object sender, EventArgs e)
        {
            string query1 = "SELECT * FROM fn_ThongKeDoanhThuLoaiLinhKien()";
            string query2 = "SELECT * FROM fn_ThongKeDoanhThuLinhKien()";
            string query3 = "SELECT * FROM fn_ThongKeHTKTheoLoaiLinhKien()";
            string query4 = "SELECT * FROM fn_ThongKeHTKTheoLinhKien()";
            string query5 = "sp_ThongTinTopKLinhKien";
            SqlParameter[] parameters = new SqlParameter[]
            {
                            new SqlParameter("@K", 5),
                            new SqlParameter("@N", 365)
            };
            try
            {

                DataTable linhKienTable1 = dataProvider.ExecuteReader(CommandType.Text, query1);
                DataTable linhKienTable2 = dataProvider. ExecuteReader(CommandType.Text, query2);
                DataTable linhKienTable3 = dataProvider.ExecuteReader(CommandType.Text, query3);
                DataTable linhKienTable4 = dataProvider.ExecuteReader(CommandType.Text, query4);
                DataTable linhKienTable5 = dataProvider.ExecuteReader(CommandType.StoredProcedure, query5, parameters);
                dataGridView1.DataSource = linhKienTable1;
                dataGridView2.DataSource = linhKienTable2;
                dataGridView3.DataSource = linhKienTable4;
                dataGridView4.DataSource = linhKienTable3;
                dataGridView5.DataSource = linhKienTable5;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
