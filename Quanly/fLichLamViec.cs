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

namespace ProCuaHangLinhKienLaptop.Quanly
{
    public partial class fLichLamViec : Form
    {
        DataProvider dataProvider = new DataProvider();
        public fLichLamViec()
        {
            InitializeComponent();
        }

        private void fLichLamViec_Load(object sender, EventArgs e)
        {
            LoadDuLieu();

        }
        public void LoadDuLieu()
        {
            try
            {
                DateTime ngay = dtpNgay.Value;
                DataTable data = dataProvider.ExecuteReader(CommandType.Text, "SELECT * FROM fn_XemLichLamTrongNgay(@ngay)", new SqlParameter("@ngay", ngay.ToString("yyyy-MM-dd") ));

                flpLichLam.Controls.Clear();
                foreach (DataRow row in data.Rows)
                {
                    int maLichLamViec = int.Parse(row["MaLichLamViec"].ToString());
                    string ngayLam = DateTime.Parse(row["NgayLam"].ToString()).ToString("yyyy-MM-dd");
                    string tenCa = row["TenCa"].ToString();
                    string gioBD = row["GioBatDau"].ToString();
                    string gioKT = row["GioKetThuc"].ToString();
                    LichLamViecUC lichLamViecUC = new LichLamViecUC(maLichLamViec, ngayLam, tenCa, gioBD, gioKT);

                    flpLichLam.Controls.Add(lichLamViecUC);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Da co loi " + ex.Message);
            }
        }
        
        private void dtpNgay_ValueChanged(object sender, EventArgs e)
        {
            LoadDuLieu();
            
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                new SqlParameter("@NgayLam", dtpNgay.Value.ToString("yyyy-MM-dd")),
                };
                int a = dataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "sp_ThemLichLamViec", sqlParameters);                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Da co loi " + ex.Message);
            }

            LoadDuLieu();
        }
    }
}
