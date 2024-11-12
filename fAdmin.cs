using ProCuaHangLinhKienLaptop.NhanVien;
using ProCuaHangLinhKienLaptop.Quanly;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace ProCuaHangLinhKienLaptop
{
    public partial class fAdmin : Form
    {
        public fAdmin()
        {
            InitializeComponent();
        }
        DataProvider dataProvider = new DataProvider();
        private void fAdmin_Load(object sender, EventArgs e)
        {
            DateTime start = new DateTime(2024, 01, 01); 
            DateTime end = new DateTime(2024, 12, 31);
            viewData(start, end);

        }
        private void okBtn_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePicker1.Value.Date;
            DateTime endDate = dateTimePicker2.Value.Date;
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
            viewData(startDate, endDate);
        }

        private void todayBtn_Click(object sender, EventArgs e)
        {
            DateTime startDate = DateTime.Today;
            DateTime endDate = DateTime.Today;
            viewData(startDate, endDate);
        }

        private void weekBtn_Click(object sender, EventArgs e)
        {
            DateTime startDate = DateTime.Today.AddDays(-6);
            DateTime endDate = DateTime.Today;
            viewData(startDate, endDate);
        }

        private void monthBtn_Click(object sender, EventArgs e)
        {
            DateTime startDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime endDate = startDate.AddMonths(1).AddDays(-1);
            viewData(startDate, endDate);
        }
        private void yearBtn_Click(object sender, EventArgs e)
        {
            DateTime startDate = new DateTime(DateTime.Today.Year, 1, 1);
            DateTime endDate = DateTime.Today;
            viewData(startDate, endDate);
        }
        private void viewData(DateTime startDate, DateTime endDate)
        {
            SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@start", startDate),
                new SqlParameter("@end", endDate)
            };

            DataTable data= dataProvider.ExecuteReader(CommandType.StoredProcedure, "sp_ThongTinChiPhiTheoNgay", sqlParams); ;
            dataGridView1.DataSource = data;
            VeBieuDo(startDate, endDate, data); 
            decimal soDonHang = GetDecimalValue("SELECT dbo.fn_TongSoDonHang(@start, @end)", sqlParams);
            decimal doanhThu = GetDecimalValue("SELECT dbo.fn_DoanhThu(@start, @end)", sqlParams);
            decimal chiPhi = GetDecimalValue("SELECT dbo.fn_ChiPhi(@start, @end)", sqlParams);
            lblSoDonHang.Text = soDonHang.ToString("N0");
            lblDoanhThu.Text = doanhThu.ToString("N0");
            lblChiPhi.Text = chiPhi.ToString("N0");
            lblLoiNhuan.Text = (doanhThu - chiPhi).ToString("N0");
        }
        private void VeBieuDo(DateTime startDate, DateTime endDate, DataTable dataTable)
        {
            chart1.Series.Clear();

            Series seriesDoanhThu = new Series("Doanh thu");
            seriesDoanhThu.ChartType = SeriesChartType.Column;
            seriesDoanhThu.Color = System.Drawing.Color.Blue;

            Series seriesLoiNhuan = new Series("Lợi nhuận");
            seriesLoiNhuan.ChartType = SeriesChartType.Line;
            seriesLoiNhuan.Color = System.Drawing.Color.Green;

            foreach (DataRow row in dataTable.Rows)
            {
                DateTime ngay = Convert.ToDateTime(row["Ngay"]);
                double doanhThu = Convert.ToDouble(row["TongDoanhThu"]);
                double loiNhuan = Convert.ToDouble(row["LoiNhuan"]);

                seriesDoanhThu.Points.AddXY(ngay.ToString("dd/MM/yyyy"), doanhThu);
                seriesLoiNhuan.Points.AddXY(ngay.ToString("dd/MM/yyyy"), loiNhuan);
            }

            chart1.Series.Add(seriesDoanhThu);
            chart1.Series.Add(seriesLoiNhuan);
            chart1.ChartAreas[0].AxisX.Title = "Ngày";
            chart1.ChartAreas[0].AxisY.Title = "Giá trị (VND)";
            chart1.Titles.Clear();
            chart1.Titles.Add("Biểu đồ Doanh thu và Lợi nhuận theo Ngày");

        }

        // Sao chép parameter cũ thành một param mới giống hệt,
        // Do dataprovider cần param riêng cho mỗi lần thực thi, không dùng chung đư
        private SqlParameter[] CloneParameters(SqlParameter[] originalParameters)
        {
            SqlParameter[] clonedParameters = new SqlParameter[originalParameters.Length];
            for (int i = 0; i < originalParameters.Length; i++)
            {
                clonedParameters[i] = new SqlParameter(originalParameters[i].ParameterName, originalParameters[i].Value);
            }
            return clonedParameters;
        }
        private decimal GetDecimalValue(string query, SqlParameter[] sqlParams)
        {
            string result = dataProvider.ExecuteScalar(CommandType.Text, query, CloneParameters(sqlParams)).ToString();
            return decimal.TryParse(result, out decimal value) ? value : 0;
        }

        private void addNewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fLinhKien fLinhKien = new fLinhKien();
            fLinhKien.ShowDialog();
        }

        private void addScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fQuanLyNhanVien fQuanlyNhanVien = new fQuanLyNhanVien();
            fQuanlyNhanVien.ShowDialog();
        }

        private void caLamViecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fCaLamViec fCaLamViec = new fCaLamViec();
            fCaLamViec.ShowDialog();
        }

        private void lichLamViecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fLichLamViec fLich = new fLichLamViec();
            fLich.ShowDialog();
        }

        private void thongKeDonHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fDonHang fDonHang = new fDonHang();
            fDonHang.ShowDialog();
        }

        private void thongKeLinhKienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fThongKeLinhKien fThongKeLinhKien = new fThongKeLinhKien();
            fThongKeLinhKien.ShowDialog();
        }
        private void rToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fLoaiLinhKien f = new fLoaiLinhKien();
            f.ShowDialog();
        }

        private void danhSáchKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fKhachHang f = new fKhachHang();
            f.ShowDialog();
        }

        private void chươngTrìnhGiảmGiáToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fKhuyenMai f =new fKhuyenMai();
            f.ShowDialog();
        }

        private void nhaCungCaptoolStripMenuItem14_Click(object sender, EventArgs e)
        {
            fNhaCungCap fNhaCungCap = new fNhaCungCap();
            fNhaCungCap.ShowDialog();
        }

        private void NhaCungCapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fNhapHang fNhapHang = new fNhapHang();
            fNhapHang.ShowDialog(); 
        }
        private void tinhLuongStripMenuItem_Click(object sender, EventArgs e)
        {
            fLuong fLuong = new fLuong();
            fLuong.ShowDialog();    
        }

        private void tinhThuongStripMenuItem_Click_1(object sender, EventArgs e)
        {
            fTinhThuong fTinhThuong = new fTinhThuong();
            fTinhThuong.ShowDialog();
        }
    }
}
