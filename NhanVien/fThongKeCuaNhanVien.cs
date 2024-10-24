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
using System.Windows.Forms.DataVisualization.Charting;

namespace ProCuaHangLinhKienLaptop.NhanVien
{
    public partial class fThongKeCuaNhanVien : Form
    {
        public DataProvider provider = new DataProvider();
        public fThongKeCuaNhanVien()
        {
            InitializeComponent();

            //du lieu cbo
            for (int i = 1; i <= 12; i++)
            {
                cboThangBD.Items.Add(i.ToString("D2")); 
            }
            cboThangBD.SelectedIndex = 0; 

            int currentYear = DateTime.Now.Year;
            for (int i = currentYear - 5; i <= currentYear + 5; i++) 
            {
                cboNamBD.Items.Add(i.ToString());
            }
            cboNamBD.SelectedItem = currentYear.ToString();

            for (int i = 1; i <= 12; i++)
            {
                cboThangKT.Items.Add(i.ToString("D2")); 
            }
            cboThangKT.SelectedIndex = 11; 

            for (int i = currentYear - 5; i <= currentYear + 5; i++) 
            {
                cboNamKT.Items.Add(i.ToString());
            }
            cboNamKT.SelectedItem = currentYear.ToString();

        }

        private void fThongKeCuaNhanVien_Load(object sender, EventArgs e)
        {
            btnXem_Click(sender, e);
        }

        public void LoadChartCaLam(DateTime ngayBD, DateTime ngayKT)
        {
            chartCaLam.Series.Clear();
            chartCaLam.ChartAreas.Clear();

            // Tạo ChartArea để chứa biểu đồ đường
            ChartArea chartArea = new ChartArea("CaLamCaNghiArea");
            chartCaLam.ChartAreas.Add(chartArea);

            Series seriesCaLam = new Series("Ca Làm")
            {
                ChartType = SeriesChartType.Line, 
                Color = System.Drawing.Color.Blue,
                BorderWidth = 3, // Độ dày đường
                ChartArea = "CaLamCaNghiArea"
            };

            Series seriesCaNghi = new Series("Ca Nghỉ")
            {
                ChartType = SeriesChartType.Line, 
                Color = System.Drawing.Color.Red,
                BorderWidth = 3, // Độ dày đường
                ChartArea = "CaLamCaNghiArea"
            };

            // try van du lieu
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@MaNhanVien", 1),
                new SqlParameter("@NgayBD", ngayBD.ToString("yyyy-MM-dd")),
                new SqlParameter("@NgayKT", ngayKT.ToString("yyyy-MM-dd")),
            };
            DataTable table = provider.ExecuteReader(CommandType.Text, "Select * FROM fn_DemCaLamCaNghi(@MaNhanVien, @NgayBD, @NgayKT)", sqlParameters);

            //tinh tong ca lam, ca nghi
            int tongCaLam = 0;
            int tongCaNghi = 0;

            foreach(DataRow row in table.Rows)
            {
                string thoiGian = row["Thang"].ToString() + "-" + row["Nam"].ToString();

                int caLam = Convert.ToInt32(row["HoanThanh"].ToString());
                int caNghi = Convert.ToInt32(row["Chua"].ToString());

                tongCaLam += caLam;
                tongCaNghi += caNghi;

                seriesCaLam.Points.AddXY(thoiGian, caLam);
                seriesCaNghi.Points.AddXY(thoiGian, caNghi);
            }

            lblCaLam.Text = tongCaLam.ToString();
            lblCaNghi.Text = tongCaNghi.ToString();

            // Thêm các series vào biểu đồ
            chartCaLam.Series.Add(seriesCaLam);
            chartCaLam.Series.Add(seriesCaNghi);

            // Tùy chỉnh biểu đồ
            chartCaLam.ChartAreas["CaLamCaNghiArea"].AxisX.Title = "Tháng";
            chartCaLam.ChartAreas["CaLamCaNghiArea"].AxisY.Title = "Số Ca";
            chartCaLam.ChartAreas["CaLamCaNghiArea"].AxisX.LabelStyle.Angle = -45;
            chartCaLam.ChartAreas["CaLamCaNghiArea"].AxisX.Interval = 1; // Hiển thị tất cả các nhãn tháng
        }

        public void LoadChartLuongThuong(DateTime ngayBD, DateTime ngayKT)
        {
            // Xóa các series và ChartAreas trước nếu có
            chartLuongThuong.Series.Clear();
            chartLuongThuong.ChartAreas.Clear();

            // Tạo ChartArea để chứa biểu đồ cột
            ChartArea chartArea = new ChartArea("LuongThuongArea");
            chartLuongThuong.ChartAreas.Add(chartArea);

            // Tạo series cho Lương
            Series seriesLuong = new Series("Lương")
            {
                ChartType = SeriesChartType.Column, 
                Color = System.Drawing.Color.Blue,
                ChartArea = "LuongThuongArea"
            };

            // Tạo series cho Thưởng
            Series seriesThuong = new Series("Thưởng")
            {
                ChartType = SeriesChartType.Column,
                Color = System.Drawing.Color.Green,
                ChartArea = "LuongThuongArea"
            };

            Series seriesTong = new Series("Tổng")
            {
                ChartType = SeriesChartType.Column, 
                Color = System.Drawing.Color.Yellow,
                ChartArea = "LuongThuongArea"
            };

            //truy van sql
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@MaNhanVien", 1),
                new SqlParameter("@NgayBD",ngayBD.ToString("yyyy-MM-dd")),
                new SqlParameter("@NgayKT",ngayKT.ToString("yyyy-MM-dd"))

            };
            DataTable table = provider.ExecuteReader(CommandType.Text, "Select * FROM fn_XemLuongTheoNhanVien(@MaNhanVien, @NgayBD, @NgayKT) ORDER BY ThoiGian ", sqlParameters);
            double tongLuong = 0;
            double tongThuong = 0;
            
            foreach (DataRow row in table.Rows)
            {
                DateTime thangNam = DateTime.Parse(row["ThoiGian"].ToString());
                string thangLuong = thangNam.ToString("MM-yy");

                double luong = double.Parse(row["Luong"].ToString());
                double thuong = double.Parse(row["Thuong"].ToString());
                double tong = luong + thuong;

                tongLuong += luong;
                tongThuong += thuong;

                //dinh dang lai tien
                string luongFormatted = (luong / 1000).ToString("N0") + "K"; 
                string thuongFormatted = (thuong / 1000).ToString("N0") + "K"; 
                string tongFormatted = (tong / 1000).ToString("N0") + "K";

                // Thêm điểm vào series Lương và gán nhãn 
                seriesLuong.Points.AddXY(thangLuong, luong);
                seriesLuong.Points[seriesLuong.Points.Count - 1].Label = luongFormatted;

                // Thêm điểm vào series Thưởng và gán nhãn
                seriesThuong.Points.AddXY(thangLuong, thuong);
                seriesThuong.Points[seriesThuong.Points.Count - 1].Label = thuongFormatted;  

                seriesTong.Points.AddXY(thangLuong, tong);
                seriesTong.Points[seriesThuong.Points.Count - 1].Label = tongFormatted;
            }

            lblTongLuong.Text = tongLuong.ToString("#,0 VNĐ");
            lblTongThuong.Text = tongThuong.ToString("#,0 VNĐ");
            lblTongLuongThuong.Text = (tongLuong + tongThuong).ToString("#,0 VNĐ"); 

            // Thêm các series vào biểu đồ
            chartLuongThuong.Series.Add(seriesLuong);
            chartLuongThuong.Series.Add(seriesThuong);
            chartLuongThuong.Series.Add(seriesTong);

            // Tùy chỉnh biểu đồ
            chartLuongThuong.ChartAreas["LuongThuongArea"].AxisX.Title = "Tháng";
            chartLuongThuong.ChartAreas["LuongThuongArea"].AxisY.Title = "Giá Trị (VND)";
            chartLuongThuong.ChartAreas["LuongThuongArea"].AxisX.LabelStyle.Angle = -45;
            chartLuongThuong.ChartAreas["LuongThuongArea"].AxisX.Interval = 1;

        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            DateTime ngayBD = Convert.ToDateTime(cboNamBD.Text + "-" + cboThangBD.Text + "-01");
            DateTime ngayKT = Convert.ToDateTime(cboNamKT.Text + "-" + cboThangKT.Text + "-01");

            LoadChartLuongThuong(ngayBD, ngayKT);
            LoadChartCaLam(ngayBD,ngayKT);
        }

        private void btnThangTruoc_Click(object sender, EventArgs e)
        {
            DateTime thangTruoc = DateTime.Now.AddMonths(-1);

            string thangNam = thangTruoc.ToString("yyyy-MM");
            DateTime ngayBD = Convert.ToDateTime(thangNam + "-01");
            DateTime ngayKT = Convert.ToDateTime(thangNam + "-01");

            cboThangBD.SelectedItem = thangTruoc.ToString("MM");
            cboNamBD.SelectedItem = thangTruoc.ToString("yyyy");

            cboThangKT.SelectedItem = thangTruoc.ToString("MM");
            cboNamKT.SelectedItem = thangTruoc.ToString("yyyy");

            LoadChartLuongThuong(ngayBD, ngayKT);
            LoadChartCaLam(ngayBD, ngayKT);
        }

        private void btnThangHienTai_Click(object sender, EventArgs e)
        {
            DateTime homNay = DateTime.Now;
            string thangNam = homNay.ToString("yyyy-MM");
            DateTime ngayBD = Convert.ToDateTime(thangNam + "-01");
            DateTime ngayKT = Convert.ToDateTime(thangNam + "-01");

            cboThangBD.SelectedItem = homNay.ToString("MM");
            cboNamBD.SelectedItem = homNay.ToString("yyyy");

            cboThangKT.SelectedItem = homNay.ToString("MM");
            cboNamKT.SelectedItem = homNay.ToString("yyyy");

            LoadChartLuongThuong(ngayBD, ngayKT);
            LoadChartCaLam(ngayBD, ngayKT);
        }

        private void btnNamNay_Click(object sender, EventArgs e)
        {
            string nam = DateTime.Now.ToString("yyyy");
            DateTime ngayBD = Convert.ToDateTime(nam + "-01" + "-01");
            DateTime ngayKT = Convert.ToDateTime(nam + "-12" + "-01");

            cboThangBD.SelectedItem = "01";
            cboNamBD.SelectedItem = nam;

            cboThangKT.SelectedItem = "12";
            cboNamKT.SelectedItem = nam;

            LoadChartLuongThuong(ngayBD, ngayKT);
            LoadChartCaLam(ngayBD, ngayKT);
        }
    }
}
