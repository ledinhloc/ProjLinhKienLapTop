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
    public partial class fLinhKien : Form
    {
        DataProvider dataProvider = new DataProvider();
        public fLinhKien()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void fLinhKien_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM vw_XemLinhKien";
            try
            {

                DataTable linhKienTable = dataProvider.ExecuteReader(CommandType.Text, query);
                dataGridView1.DataSource = linhKienTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Lấy mã linh kiện từ hàng được chọn
                string maLinhKien = dataGridView1.SelectedRows[0].Cells["Mã Linh Kiện"].Value.ToString();

                // Hỏi người dùng có chắc chắn muốn xóa không
                DialogResult dialogResult = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa linh kiện này?",
                    "Xác Nhận Xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        string query = "sp_XoaLinhKien";  
                        SqlParameter[] parameters = new SqlParameter[]
                        {
                            new SqlParameter("@MaLinhKien", maLinhKien)  
                        };

                        dataProvider.ExecuteNonQuery(CommandType.StoredProcedure, query, parameters);

                        MessageBox.Show("Xóa linh kiện thành công!");
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa linh kiện: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một linh kiện để xóa.");
            }

            
        }
        private void LoadData()
        {
            DataTable linhKienTable = dataProvider.ExecuteReader(CommandType.Text, "SELECT * FROM vw_XemLinhKien");
            dataGridView1.DataSource = linhKienTable;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fThemLinhKien formThem = new fThemLinhKien();
            formThem.ShowDialog();
            LoadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0) {
                int maLinhKien = (int)dataGridView1.SelectedRows[0].Cells["Mã Linh Kiện"].Value;
                fCapNhatLinhKien formSua = new fCapNhatLinhKien(maLinhKien);
                formSua.ShowDialog();

            } 
            LoadData();
        }
    }
}
