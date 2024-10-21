using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            try
            {

                DataTable linhKienTable1 = dataProvider.ExecuteReader(CommandType.Text, query1);
                DataTable linhKienTable2 = dataProvider. ExecuteReader(CommandType.Text, query2);
                DataTable linhKienTable3 = dataProvider.ExecuteReader(CommandType.Text, query3);
                DataTable linhKienTable4 = dataProvider.ExecuteReader(CommandType.Text, query4);
                dataGridView1.DataSource = linhKienTable1;
                dataGridView2.DataSource = linhKienTable2;
                dataGridView3.DataSource = linhKienTable4;
                dataGridView4.DataSource = linhKienTable3;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }
    }
}
