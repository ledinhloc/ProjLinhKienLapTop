namespace ProCuaHangLinhKienLaptop.Quanly
{
    partial class DieuKienThuongUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DieuKienThuongUC));
            this.cmbTenDK = new System.Windows.Forms.ComboBox();
            this.cmbSoSanh = new System.Windows.Forms.ComboBox();
            this.txtNguong = new System.Windows.Forms.TextBox();
            this.txtThuong = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbTenDK
            // 
            this.cmbTenDK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.cmbTenDK.FormattingEnabled = true;
            this.cmbTenDK.Location = new System.Drawing.Point(64, 17);
            this.cmbTenDK.Name = "cmbTenDK";
            this.cmbTenDK.Size = new System.Drawing.Size(165, 30);
            this.cmbTenDK.TabIndex = 0;
            // 
            // cmbSoSanh
            // 
            this.cmbSoSanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.cmbSoSanh.FormattingEnabled = true;
            this.cmbSoSanh.Items.AddRange(new object[] {
            ">",
            "<",
            ">=",
            "<=",
            "="});
            this.cmbSoSanh.Location = new System.Drawing.Point(248, 17);
            this.cmbSoSanh.Name = "cmbSoSanh";
            this.cmbSoSanh.Size = new System.Drawing.Size(79, 30);
            this.cmbSoSanh.TabIndex = 1;
            // 
            // txtNguong
            // 
            this.txtNguong.Location = new System.Drawing.Point(347, 19);
            this.txtNguong.Name = "txtNguong";
            this.txtNguong.Size = new System.Drawing.Size(134, 26);
            this.txtNguong.TabIndex = 2;
            // 
            // txtThuong
            // 
            this.txtThuong.Location = new System.Drawing.Point(537, 19);
            this.txtThuong.Name = "txtThuong";
            this.txtThuong.Size = new System.Drawing.Size(133, 26);
            this.txtThuong.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(686, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(11, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 28);
            this.label1.TabIndex = 20;
            this.label1.Text = "Nếu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Poppins", 8F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(493, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 28);
            this.label3.TabIndex = 22;
            this.label3.Text = "thì";
            // 
            // DieuKienThuongUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Khaki;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtThuong);
            this.Controls.Add(this.txtNguong);
            this.Controls.Add(this.cmbSoSanh);
            this.Controls.Add(this.cmbTenDK);
            this.Name = "DieuKienThuongUC";
            this.Size = new System.Drawing.Size(763, 59);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTenDK;
        private System.Windows.Forms.ComboBox cmbSoSanh;
        private System.Windows.Forms.TextBox txtNguong;
        private System.Windows.Forms.TextBox txtThuong;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}
