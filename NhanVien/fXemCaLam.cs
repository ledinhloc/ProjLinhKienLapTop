﻿using ProCuaHangLinhKienLaptop.DB;
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
using static System.Net.WebRequestMethods;

namespace ProCuaHangLinhKienLaptop.NhanVien
{
    public partial class fXemCaLam : Form
    {
        DataProvider provider = new DataProvider();
        public fXemCaLam()
        {
            InitializeComponent();
           
        }

        private void flpCaLam_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fXemCaLam_Load(object sender, EventArgs e)
        {
            dtpNgay.Value = DateTime.Parse("2024-01-01");
            dtpNgay_ValueChanged(sender, e);
        }

        private void dtpNgay_ValueChanged(object sender, EventArgs e)
        {
            DateTime ngayDau = dtpNgay.Value;
            DateTime ngayCuoi = ngayDau.AddDays(4);

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@MaNhanVien", 1),
                new SqlParameter("@NgayDau", ngayDau.ToString("yyyy-MM-dd")),
                new SqlParameter("@NgayCuoi", ngayCuoi.ToString("yyyy-MM-dd"))

            };
            DataTable table = provider.ExecuteReader(CommandType.Text, "Select * FROM fn_XemCaLamViecCuaNhanVien(@MaNhanVien,@NgayDau,@NgayCuoi)", sqlParameters);
            foreach (DataRow row in table.Rows)
            {
                //string ngay = row["NgayLam"].ToString();
                DateTime ngayLam = Convert.ToDateTime(row["NgayLam"]);
                string ngayVaThu = ngayLam.ToString("dddd, dd/MM/yy", new System.Globalization.CultureInfo("vi-VN"));
                string caLam = row["TenCa"].ToString();
                string trangThai = row["TrangThai"].ToString();
                string danhGia = row["DanhGia"].ToString();
                CaLamUC uc = new CaLamUC(ngayVaThu, caLam, trangThai, danhGia);

                flpCaLam.Controls.Add(uc);
            }
        }
    }
}
