using ProCuaHangLinhKienLaptop.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProCuaHangLinhKienLaptop.Quanly
{
    public partial class fTinhThuong : Form
    {
        DataProvider dataProvider = new DataProvider();
        public fTinhThuong()
        {
            InitializeComponent();
        }

        private void fTinhThuong_Load(object sender, EventArgs e)
        {
            
        }

        private void btnThemDK_Click(object sender, EventArgs e)
        {
            DieuKienThuongUC dieuKienThuongUC = new DieuKienThuongUC();
            flowLayoutPanel1.Controls.Add(dieuKienThuongUC);
        }

        private void LuuTamDieuKienVaoDB(string tenDk, string soSanh, decimal nguong, decimal thuong)
        {
            //dataProvider.ExecuteNonQuery("INSERT INTO")
        }

        private void btnTinhThuong_Click(object sender, EventArgs e)
        {
            dataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "sp_TaoTableTamDieuKienThuong");
            try
            {
                // Duyệt qua từng DieuKienThuongUC trong flowlayoutpanel1
                foreach (DieuKienThuongUC dieuKien in flowLayoutPanel1.Controls)
                {
                    string tenFunction = dieuKien.TenDK;
                    string thamSo = dieuKien.LayThamSo(tenFunction); 
                    decimal nguong = dieuKien.Nguong;
                    string soSanh = dieuKien.SoSanh;
                    string giaTriThuong = dieuKien.Thuong.ToString();

                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@TenFunction", tenFunction),
                        new SqlParameter("@ThamSo", thamSo),
                        new SqlParameter("@Nguong", nguong),
                        new SqlParameter("@SoSanh", soSanh),
                        new SqlParameter("@GiaTriThuong", giaTriThuong)
                    };

                    dataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "sp_ThemDieuKienThuong", parameters);
                }

                DateTime startDate = dtpStartDate.Value.Date;
                DateTime endDate = dtpEndDate.Value.Date;
                if (endDate < startDate)
                {
                    MessageBox.Show("Ngày kết thúc không được nhỏ hơn ngày bắt đầu. Vui lòng chọn lại.");
                    return;
                }

                if (endDate > DateTime.Today)
                {
                    MessageBox.Show("Ngày kết thúc không được lớn hơn ngày hiện tại. Vui lòng chọn lại.");
                    return;
                }
                dgvThuongPreview.DataSource = dataProvider.ExecuteReader(CommandType.StoredProcedure, "sp_TinhThuongDuaTrenDieuKien", new SqlParameter[] {
                    new SqlParameter("@start", startDate),
                    new SqlParameter("@end", endDate)
                });
            }
            finally
            {
                string dropTempTableQuery = "DROP TABLE [dbo].[DieuKienThuong];";
                dataProvider.ExecuteNonQuery(CommandType.Text, dropTempTableQuery);
            }
        }

    }

}
