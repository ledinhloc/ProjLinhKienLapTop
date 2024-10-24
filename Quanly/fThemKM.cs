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
    public partial class fThemKM : Form
    {
        private DataProvider dataProvider;
        public delegate void KhuyenMaiAddedEventHandler(object sender, EventArgs e);
        public event KhuyenMaiAddedEventHandler KhuyenMaiAdded;
        public fThemKM()
        {
            InitializeComponent();
            dataProvider = new DataProvider();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                string tenGiamGia = txtTenGiamGia.Text;
                DateTime ngayBatDau = dtpNgayBatDau.Value;
                DateTime ngayKetThuc = dtpNgayHetHan.Value;
                decimal giaTri = decimal.Parse(txtGiaTri.Text);

                if (string.IsNullOrWhiteSpace(tenGiamGia) || giaTri < 0 || giaTri > 100)
                {
                    MessageBox.Show("Vui lòng nhập thông tin hợp lệ.");
                    return;
                }

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@TenGiamGia", tenGiamGia),
                    new SqlParameter("@NgayBatDau", ngayBatDau),
                    new SqlParameter("@NgayKetThuc", ngayKetThuc),
                    new SqlParameter("@GiaTri", giaTri)
                };

                int result = dataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "sp_ThemGiamGia", parameters);

                if (result > 0)
                {
                    MessageBox.Show("Thêm mã giảm giá thành công!");
                    KhuyenMaiAdded?.Invoke(this, EventArgs.Empty);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm mã giảm giá không thành công!");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Giá trị không hợp lệ cho Gia Tri.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
