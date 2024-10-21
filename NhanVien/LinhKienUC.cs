using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProCuaHangLinhKienLaptop.NhanVien
{
    public partial class LinhKienUC : UserControl
    {
        public int MaLinhKien { get; set; }
        public string TenLinhKien { get; set; }
        public string MoTaChiTiet { get; set; }
        public decimal GiaBan { get; set; }
        public decimal GiaNhap { get; set; }
        public int SoLuongTonKho { get; set; }
        public Image HinhLK {  get; set; }
        public LinhKienUC()
        {
            InitializeComponent();
        }

        public LinhKienUC(int maLinhKien, string tenLinhKien, string moTaChiTiet, decimal giaBan, decimal giaNhap, int soLuongTonKho, Image hinhLK)
        {
            InitializeComponent();
            MaLinhKien = maLinhKien;
            TenLinhKien = tenLinhKien;
            MoTaChiTiet = moTaChiTiet;
            GiaBan = giaBan;
            GiaNhap = giaNhap;
            SoLuongTonKho = soLuongTonKho;
            HinhLK = hinhLK;
            lblTenLinhKien.Text = TenLinhKien;
            lblGiaBan.Text = GiaBan.ToString("N0") + "VND";
            lblSoLuong.Text = SoLuongTonKho.ToString();
            picAnhLK.Image = HinhLK;
            this.Click += (s, e) => OnLinhKienClicked();
        }
        // TEST
        public LinhKienUC(int maLinhKien, string tenLinhKien, decimal giaBan)
        {
            InitializeComponent();
            MaLinhKien = maLinhKien;
            TenLinhKien = tenLinhKien;
            GiaBan = giaBan;
            lblTenLinhKien.Text = TenLinhKien;
            lblGiaBan.Text = GiaBan.ToString("N0") + "VND";
            this.Click += (s, e) => OnLinhKienClicked();
        }

        public event EventHandler LinhKienClicked;

        public void OnLinhKienClicked()
        {
            LinhKienClicked?.Invoke(this, EventArgs.Empty);
        }

        private void LinhKienUC_Click(object sender, EventArgs e)
        {
            OnLinhKienClicked();
        }
    }
}
