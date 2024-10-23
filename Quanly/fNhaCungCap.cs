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
    public partial class fNhaCungCap : Form
    {
        DataProvider dataProvider = new DataProvider();
        public fNhaCungCap()
        {
            InitializeComponent();
        }

        private void fNhaCungCap_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM vw_ThongTinNhaCungCap";
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
            DataTable linhKienTable = dataProvider.ExecuteReader(CommandType.Text, "SELECT * FROM vw_XemNhaCungCap");
            dataGridView1.DataSource = linhKienTable;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Lấy mã linh kiện từ hàng được chọn
                string maNCC = dataGridView1.SelectedRows[0].Cells["MaNhaCungCap"].Value.ToString();

                // Hỏi người dùng có chắc chắn muốn xóa không
                DialogResult dialogResult = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa nhà cung cấp này?",
                    "Xác Nhận Xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        string query = "sp_XoaNhaCungCap";
                        SqlParameter[] parameters = new SqlParameter[]
                        {
                            new SqlParameter("@MaNhaCungCap", maNCC)
                        };

                        dataProvider.ExecuteNonQuery(CommandType.StoredProcedure, query, parameters);

                        MessageBox.Show("Xóa nhà cung cấp thành công!");
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa nhà cung cấp: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhà cung cấp để xóa.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fThemNhaCungCap formThem = new fThemNhaCungCap();
            formThem.ShowDialog();
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int maNCC = (int)dataGridView1.SelectedRows[0].Cells["MaNhaCungCap"].Value;
                fCapNhatNhaCungCap formSua = new fCapNhatNhaCungCap(maNCC);
                formSua.ShowDialog();

            }
            LoadData();
        }
    }
}
