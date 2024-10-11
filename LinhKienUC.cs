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
    public partial class LinhKienUC : UserControl
    {
        public int MaLinhKien { get; set; }
        public string TenLinhKien { get; set; }
        public string MoTaChiTiet { get; set; }
        public decimal GiaBan { get; set; }
        public decimal GiaNhap { get; set; }
        public int SoLuongTonKho { get; set; }
        public LinhKienUC()
        {
            InitializeComponent();
        }

        public LinhKienUC(int maLinhKien, string tenLinhKien, string moTaChiTiet, decimal giaBan, decimal giaNhap, int soLuongTonKho)
        {
            InitializeComponent();
            MaLinhKien = maLinhKien;
            TenLinhKien = tenLinhKien;
            MoTaChiTiet = moTaChiTiet;
            GiaBan = giaBan;
            GiaNhap = giaNhap;
            SoLuongTonKho = soLuongTonKho;
            lblProductName.Text = TenLinhKien;
            lblProductPrice.Text = GiaBan.ToString() + "VND";
        }
        public LinhKienUC(int maLinhKien, string tenLinhKien, decimal giaBan)
        {
            InitializeComponent();
            MaLinhKien = maLinhKien;
            TenLinhKien = tenLinhKien;
            GiaBan = giaBan;
            lblProductName.Text = TenLinhKien;
            lblProductPrice.Text = GiaBan.ToString() + "VND";
        }
    }
}
