using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProCuaHangLinhKienLaptop.Quanly
{
    public partial class UC_GiamGia : UserControl
    {
        public UC_GiamGia()
        {
            InitializeComponent();
        }
        public UC_GiamGia(int maGiamGia, string tenGiamGia, DateTime ngayBatDau, DateTime ngayKetThuc, decimal giaTri) : this()
        {
            UpdateDiscountInfo(maGiamGia, tenGiamGia, ngayBatDau, ngayKetThuc, giaTri);
        }
        public void UpdateDiscountInfo(int maGiamGia, string tenGiamGia, DateTime ngayBatDau, DateTime ngayKetThuc, decimal giaTri)
        {
            // Cập nhật các trường trên UserControl
            lblMaGiamGia.Text = maGiamGia.ToString();
            lblTenGiamGia.Text = tenGiamGia;
            dtpNgayBatDau.Value = ngayBatDau;
            dtpNgayHetHan.Value = ngayKetThuc;
            lblGiaTri.Text = giaTri.ToString("F2"); // Định dạng số với 2 chữ số thập phân
        }
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblGiaBan_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
