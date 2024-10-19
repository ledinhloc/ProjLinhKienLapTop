namespace ProCuaHangLinhKienLaptop.Quanly
{
    partial class ChiTietDonHang
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
            this.dgvChiTietDonHang = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietDonHang)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvChiTietDonHang
            // 
            this.dgvChiTietDonHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietDonHang.Location = new System.Drawing.Point(24, 12);
            this.dgvChiTietDonHang.Name = "dgvChiTietDonHang";
            this.dgvChiTietDonHang.RowHeadersWidth = 62;
            this.dgvChiTietDonHang.RowTemplate.Height = 28;
            this.dgvChiTietDonHang.Size = new System.Drawing.Size(1035, 457);
            this.dgvChiTietDonHang.TabIndex = 0;
            // 
            // ChiTietDonHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 495);
            this.Controls.Add(this.dgvChiTietDonHang);
            this.Name = "ChiTietDonHang";
            this.Text = "ChiTietDonHang";
            this.Load += new System.EventHandler(this.ChiTietDonHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietDonHang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvChiTietDonHang;
    }
}