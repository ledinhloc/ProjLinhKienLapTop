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
    public partial class fNhanVien : Form
    {
        private string maNhanVien;
        public fNhanVien(string maNhanVien)
        {
            InitializeComponent();
            this.maNhanVien = maNhanVien;
        }

        private void banHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fTaoDonHang fTaoDonHang = new fTaoDonHang();
            fTaoDonHang.ShowDialog();
        }

        private void thongTinKhachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fKhachHang fKhachHang = new fKhachHang();
            fKhachHang.ShowDialog();
        }

        private void caLamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fXemCaLam fXemCaLam = new fXemCaLam();
            fXemCaLam.ShowDialog();
        }

        private void luongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fThongKeCuaNhanVien fThongKeCuaNhanVien = new fThongKeCuaNhanVien(maNhanVien);
            fThongKeCuaNhanVien.ShowDialog();
        }

        private void thongTinCaNhanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fThongTinNhanVien fThongTinNhanVien = new fThongTinNhanVien();
            fThongTinNhanVien .ShowDialog();
        }

        private void fNhanVien_Load(object sender, EventArgs e)
        {

        }

        private void danhSachDonHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fDonHang f = new fDonHang();
            f.ShowDialog();
        }
    }
}
