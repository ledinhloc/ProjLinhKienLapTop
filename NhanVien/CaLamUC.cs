using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProCuaHangLinhKienLaptop.NhanVien
{
    public partial class CaLamUC : UserControl
    {
        public CaLamUC()
        {
            InitializeComponent();
            this.BackColor = Color.White; // Màu nền của UserControl
            this.ForeColor = Color.Black; // Màu viền
            this.ResizeRedraw = true;
        }

        public CaLamUC(string ngay, string tenCa, string trangThai, string danhGia)
        {
            InitializeComponent();
            this.BackColor = Color.White; // Màu nền của UserControl
            this.ForeColor = Color.Black; // Màu viền
            this.ResizeRedraw = true;

            lblNgay.Text = ngay;
            lblTenCa.Text = tenCa;
            lblDanhGia.Text = danhGia;
            lblTrangThai.Text = trangThai;
        }

        private void CaLamUC_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Kích thước và bán kính bo góc
            int cornerRadius = 20;  // Độ cong của các góc
            Graphics g = e.Graphics;

            // Chất lượng vẽ tốt nhất
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Tạo hình chữ nhật bo góc
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(new Rectangle(0, 0, cornerRadius, cornerRadius), 180, 90); // Góc trên-trái
                path.AddArc(new Rectangle(this.Width - cornerRadius - 1, 0, cornerRadius, cornerRadius), 270, 90); // Góc trên-phải
                path.AddArc(new Rectangle(this.Width - cornerRadius - 1, this.Height - cornerRadius - 1, cornerRadius, cornerRadius), 0, 90); // Góc dưới-phải
                path.AddArc(new Rectangle(0, this.Height - cornerRadius - 1, cornerRadius, cornerRadius), 90, 90); // Góc dưới-trái
                path.CloseFigure();

                // Vẽ màu nền với viền bo góc TRƯỚC
                using (SolidBrush brush = new SolidBrush(this.BackColor))
                {
                    g.FillPath(brush, path); // Vẽ nền
                }

                // Vẽ viền cho UserControl SAU
                using (Pen pen = new Pen(this.ForeColor, 2)) // Độ dày viền là 2px
                {
                    g.DrawPath(pen, path); // Vẽ viền
                }
            }
        }


    }
}
