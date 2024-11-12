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
            cmbThang.SelectedIndex = 10;
            cmbNam.SelectedIndex = 2;
            dtpStartDate.Value = new DateTime(2024, 11, 1);
        }

        private void btnThemDK_Click(object sender, EventArgs e)
        {
            DieuKienThuongUC dieuKienThuongUC = new DieuKienThuongUC();
            flowLayoutPanel1.Controls.Add(dieuKienThuongUC);
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

        private void btnApDung_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvThuongPreview.Rows)
            {
                if (row.Cells["MaNhanVien"].Value != null && Convert.ToDecimal(row.Cells["ResultGiaTriThuong"].Value) != 0)
                {
                    int maNhanVien = Convert.ToInt32(row.Cells["MaNhanVien"].Value);
                    decimal thuong = Convert.ToDecimal(row.Cells["ResultGiaTriThuong"].Value);
                    dataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "sp_CapNhatThuongTongNhan",
                        new SqlParameter[]
                        {
                            new SqlParameter("@MaNhanVien", maNhanVien),
                            new SqlParameter("@Thuong", thuong),
                            new SqlParameter("@Thang", int.Parse(cmbThang.SelectedItem.ToString())),
                            new SqlParameter("@Nam", int.Parse(cmbNam.SelectedItem.ToString())),
                        });
                }
            }
            this.Close();
            fLuong fLuong = new fLuong();
            fLuong.ShowDialog();
        }
    }

}
