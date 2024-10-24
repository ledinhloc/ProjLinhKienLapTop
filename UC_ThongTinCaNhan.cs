using ProCuaHangLinhKienLaptop.NhanVien;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProCuaHangLinhKienLaptop
{
    public partial class UC_ThongTinCaNhan : UserControl
    {
        private string maNhanVien;
        public UC_ThongTinCaNhan()
        {
            InitializeComponent();
        }
        public UC_ThongTinCaNhan(int manv, string tennv, DateTime ngaysinh, string sdt, string email, string diachi) : this()
        {
            UpdateDiscountInfo(manv,tennv,ngaysinh,sdt,email,diachi);
        }

        public void UpdateDiscountInfo(int manv, string tennv, DateTime ngaysinh, string sdt,string email,string diachi)
        {
            // Cập nhật các trường trên UserControl
            txtMaNhanVien.Text = manv.ToString();
            this.maNhanVien = manv.ToString();
            txtTenNhanVien.Text = tennv;
            dtpNgaySinh.Value = ngaysinh;
            txtSDT.Text = sdt;
            txtEmail.Text = email;
            txtDiaChi.Text = diachi;
        }

        private void btnXoaThongKe_Click(object sender, EventArgs e)
        {
            fThongKeCuaNhanVien f = new fThongKeCuaNhanVien(maNhanVien);
            f.ShowDialog();
        }
    }
}
