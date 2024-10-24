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

namespace ProCuaHangLinhKienLaptop
{
    public partial class fAdmin : Form
    {
        public fAdmin()
        {
            InitializeComponent();
        }

        private void fAdmin_Load(object sender, EventArgs e)
        {

        }

        private void addNewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fLinhKien fLinhKien = new fLinhKien();
            fLinhKien.ShowDialog();
        }

        private void NhaCungCapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fNhaCungCap fNhaCungCap = new fNhaCungCap();
            fNhaCungCap.ShowDialog();
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

        private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
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
    }
}
