using ProCuaHangLinhKienLaptop.DB;
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
using System.Data.SqlClient;
namespace ProCuaHangLinhKienLaptop.Quanly
{
    public partial class fLoaiLinhKien : Form
    {
        DataProvider dataProvider = new DataProvider();
        public fLoaiLinhKien()
        {
            InitializeComponent();
        }

        private void fLoaiLinhKien_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM vw_ThongTinLoaiLinhKien";
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

        private void LoadData()
        {
            DataTable linhKienTable = dataProvider.ExecuteReader(CommandType.Text, "SELECT * FROM vw_ThongTinLoaiLinhKien");
            dataGridView1.DataSource = linhKienTable;
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Lấy mã linh kiện từ hàng được chọn
                string maLLK = dataGridView1.SelectedRows[0].Cells["MaLoaiLinhKien"].Value.ToString();

                // Hỏi người dùng có chắc chắn muốn xóa không
                DialogResult dialogResult = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa loại linh kiện này?",
                    "Xác Nhận Xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        string query = "sp_XoaLoaiLinhKien";
                        SqlParameter[] parameters = new SqlParameter[]
                        {
                            new SqlParameter("@MaLoaiLinhKien", maLLK)
                        };

                        dataProvider.ExecuteNonQuery(CommandType.StoredProcedure, query, parameters);

                        MessageBox.Show("Xóa loại linh kiện thành công!");
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa loại linh kiện: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một loại linh kiện để xóa.");
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            fThemLoaiLinhKien formThem = new fThemLoaiLinhKien();
            formThem.ShowDialog();
            LoadData();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int maLLK = (int)dataGridView1.SelectedRows[0].Cells["MaLoaiLinhKien"].Value;
                fCapNhatLoaiLinhKien formSua = new fCapNhatLoaiLinhKien(maLLK);
                formSua.ShowDialog();

            }
            LoadData();
        }
    }
}
