namespace ProCuaHangLinhKienLaptop
{
    partial class fNhanVien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.banHangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thongTinKhachToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.caLamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thongTinCaNhanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.luongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhSachDonHangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.banHangToolStripMenuItem,
            this.danhSachDonHangToolStripMenuItem,
            this.thongTinKhachToolStripMenuItem,
            this.caLamToolStripMenuItem,
            this.luongToolStripMenuItem,
            this.thongTinCaNhanToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(811, 31);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // banHangToolStripMenuItem
            // 
            this.banHangToolStripMenuItem.Name = "banHangToolStripMenuItem";
            this.banHangToolStripMenuItem.Size = new System.Drawing.Size(115, 24);
            this.banHangToolStripMenuItem.Text = "Tạo đơn hàng";
            this.banHangToolStripMenuItem.Click += new System.EventHandler(this.banHangToolStripMenuItem_Click);
            // 
            // thongTinKhachToolStripMenuItem
            // 
            this.thongTinKhachToolStripMenuItem.Name = "thongTinKhachToolStripMenuItem";
            this.thongTinKhachToolStripMenuItem.Size = new System.Drawing.Size(128, 24);
            this.thongTinKhachToolStripMenuItem.Text = "Thông tin khách";
            this.thongTinKhachToolStripMenuItem.Click += new System.EventHandler(this.thongTinKhachToolStripMenuItem_Click);
            // 
            // caLamToolStripMenuItem
            // 
            this.caLamToolStripMenuItem.Name = "caLamToolStripMenuItem";
            this.caLamToolStripMenuItem.Size = new System.Drawing.Size(69, 24);
            this.caLamToolStripMenuItem.Text = "Ca làm";
            this.caLamToolStripMenuItem.Click += new System.EventHandler(this.caLamToolStripMenuItem_Click);
            // 
            // thongTinCaNhanToolStripMenuItem
            // 
            this.thongTinCaNhanToolStripMenuItem.Name = "thongTinCaNhanToolStripMenuItem";
            this.thongTinCaNhanToolStripMenuItem.Size = new System.Drawing.Size(141, 24);
            this.thongTinCaNhanToolStripMenuItem.Text = "Thông tin cá nhân";
            this.thongTinCaNhanToolStripMenuItem.Click += new System.EventHandler(this.thongTinCaNhanToolStripMenuItem_Click);
            // 
            // luongToolStripMenuItem
            // 
            this.luongToolStripMenuItem.Name = "luongToolStripMenuItem";
            this.luongToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.luongToolStripMenuItem.Text = "Lương";
            this.luongToolStripMenuItem.Click += new System.EventHandler(this.luongToolStripMenuItem_Click);
            // 
            // danhSachDonHangToolStripMenuItem
            // 
            this.danhSachDonHangToolStripMenuItem.Name = "danhSachDonHangToolStripMenuItem";
            this.danhSachDonHangToolStripMenuItem.Size = new System.Drawing.Size(158, 24);
            this.danhSachDonHangToolStripMenuItem.Text = "Danh sách đơn hàng";
            this.danhSachDonHangToolStripMenuItem.Click += new System.EventHandler(this.danhSachDonHangToolStripMenuItem_Click);
            // 
            // fNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 571);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "fNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fNhanVien";
            this.Load += new System.EventHandler(this.fNhanVien_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem banHangToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thongTinKhachToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem caLamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem luongToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thongTinCaNhanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem danhSachDonHangToolStripMenuItem;
    }
}