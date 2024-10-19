namespace ProCuaHangLinhKienLaptop.NhanVien
{
    partial class CaLamUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblNgay = new System.Windows.Forms.Label();
            this.lblTenCa = new System.Windows.Forms.Label();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.lblDanhGia = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNgay
            // 
            this.lblNgay.AutoSize = true;
            this.lblNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgay.Location = new System.Drawing.Point(29, 11);
            this.lblNgay.Name = "lblNgay";
            this.lblNgay.Size = new System.Drawing.Size(91, 20);
            this.lblNgay.TabIndex = 0;
            this.lblNgay.Text = "11/12/2024";
            // 
            // lblTenCa
            // 
            this.lblTenCa.AutoSize = true;
            this.lblTenCa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenCa.Location = new System.Drawing.Point(32, 36);
            this.lblTenCa.Name = "lblTenCa";
            this.lblTenCa.Size = new System.Drawing.Size(47, 20);
            this.lblTenCa.TabIndex = 0;
            this.lblTenCa.Text = "Sáng";
            this.lblTenCa.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrangThai.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblTrangThai.Location = new System.Drawing.Point(116, 36);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(95, 20);
            this.lblTrangThai.TabIndex = 0;
            this.lblTrangThai.Text = "HoanThanh";
            this.lblTrangThai.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblDanhGia
            // 
            this.lblDanhGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDanhGia.Location = new System.Drawing.Point(32, 61);
            this.lblDanhGia.Name = "lblDanhGia";
            this.lblDanhGia.Size = new System.Drawing.Size(184, 43);
            this.lblDanhGia.TabIndex = 0;
            this.lblDanhGia.Text = "Rất tốt";
            this.lblDanhGia.Click += new System.EventHandler(this.label2_Click);
            // 
            // CaLamUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblDanhGia);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.lblTenCa);
            this.Controls.Add(this.lblNgay);
            this.Name = "CaLamUC";
            this.Size = new System.Drawing.Size(240, 117);
            this.Load += new System.EventHandler(this.CaLamUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNgay;
        private System.Windows.Forms.Label lblTenCa;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.Label lblDanhGia;
    }
}
