namespace ProCuaHangLinhKienLaptop.NhanVien
{
    partial class fXemCaLam
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
            this.flpCaLam = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // dtpNgay
            // 
            this.dtpNgay.Location = new System.Drawing.Point(525, 33);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(255, 22);
            this.dtpNgay.TabIndex = 0;
            this.dtpNgay.ValueChanged += new System.EventHandler(this.dtpNgay_ValueChanged);
            // 
            // flpCaLam
            // 
            this.flpCaLam.AutoScroll = true;
            this.flpCaLam.Location = new System.Drawing.Point(31, 90);
            this.flpCaLam.Name = "flpCaLam";
            this.flpCaLam.Size = new System.Drawing.Size(769, 411);
            this.flpCaLam.TabIndex = 1;
            this.flpCaLam.Paint += new System.Windows.Forms.PaintEventHandler(this.flpCaLam_Paint);
            // 
            // fXemCaLam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 563);
            this.Controls.Add(this.flpCaLam);
            this.Controls.Add(this.dtpNgay);
            this.Name = "fXemCaLam";
            this.Text = "fXemCaLam";
            this.Load += new System.EventHandler(this.fXemCaLam_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpNgay;
        private System.Windows.Forms.FlowLayoutPanel flpCaLam;
    }
}