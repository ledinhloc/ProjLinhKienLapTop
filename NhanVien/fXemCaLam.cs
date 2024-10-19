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

namespace ProCuaHangLinhKienLaptop.NhanVien
{
    public partial class fXemCaLam : Form
    {
        DataProvider provider = new DataProvider();
        public fXemCaLam()
        {
            InitializeComponent();
        }

        private void fXemCaLam_Load(object sender, EventArgs e)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@MaNhanVien", 1)
            };
            dataGridView1.DataSource = provider.ExecuteReader(CommandType.Text, "Select * FROM XemCaLamViecCuaNhanVien(@MaNhanVien)", sqlParameters);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
