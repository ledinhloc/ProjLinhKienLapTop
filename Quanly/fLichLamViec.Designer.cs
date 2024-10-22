namespace ProCuaHangLinhKienLaptop.Quanly
{
    partial class fLichLamViec
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
            this.dtpNgay = new System.Windows.Forms.DateTimePicker();
            this.flpLichLam = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTao = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtpNgay
            // 
            this.dtpNgay.Location = new System.Drawing.Point(36, 26);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(200, 22);
            this.dtpNgay.TabIndex = 0;
            this.dtpNgay.ValueChanged += new System.EventHandler(this.dtpNgay_ValueChanged);
            // 
            // flpLichLam
            // 
            this.flpLichLam.AutoScroll = true;
            this.flpLichLam.Location = new System.Drawing.Point(36, 72);
            this.flpLichLam.Name = "flpLichLam";
            this.flpLichLam.Size = new System.Drawing.Size(602, 365);
            this.flpLichLam.TabIndex = 1;
            // 
            // btnTao
            // 
            this.btnTao.Location = new System.Drawing.Point(499, 12);
            this.btnTao.Name = "btnTao";
            this.btnTao.Size = new System.Drawing.Size(139, 39);
            this.btnTao.TabIndex = 5;
            this.btnTao.Text = "Tạo ngày làm";
            this.btnTao.UseVisualStyleBackColor = true;
            this.btnTao.Click += new System.EventHandler(this.btnTao_Click);
            // 
            // fLichLamViec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 485);
            this.Controls.Add(this.btnTao);
            this.Controls.Add(this.flpLichLam);
            this.Controls.Add(this.dtpNgay);
            this.Name = "fLichLamViec";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fLichLamViec";
            this.Load += new System.EventHandler(this.fLichLamViec_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpNgay;
        private System.Windows.Forms.FlowLayoutPanel flpLichLam;
        private System.Windows.Forms.Button btnTao;
    }
}