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

        }

        private void luongToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thongTinCaNhanToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fNhanVien_Load(object sender, EventArgs e)
        {

        }
    }
}
