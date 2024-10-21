namespace ProCuaHangLinhKienLaptop.Quanly
{
    partial class fKhuyenMai
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
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label5;
            this.pn_Chua = new System.Windows.Forms.FlowLayoutPanel();
            this.dGV_GiamGia = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnThemKhuyenMai = new System.Windows.Forms.Button();
            this.btnXoaKhuyenMai = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.dtpDen = new System.Windows.Forms.DateTimePicker();
            this.dtpTu = new System.Windows.Forms.DateTimePicker();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMaGiamGia = new System.Windows.Forms.TextBox();
            this.btnTraCuu = new System.Windows.Forms.Button();
            this.lblKetQua = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_GiamGia)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.AutoEllipsis = true;
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            label2.Location = new System.Drawing.Point(91, 17);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(28, 20);
            label2.TabIndex = 14;
            label2.Text = "Từ";
            // 
            // label3
            // 
            label3.AutoEllipsis = true;
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            label3.Location = new System.Drawing.Point(250, 17);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(39, 20);
            label3.TabIndex = 15;
            label3.Text = "Đến";
            // 
            // label5
            // 
            label5.AutoEllipsis = true;
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            label5.Location = new System.Drawing.Point(157, 17);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(69, 20);
            label5.TabIndex = 16;
            label5.Text = "----------";
            // 
            // pn_Chua
            // 
            this.pn_Chua.AutoSize = true;
            this.pn_Chua.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.pn_Chua.Location = new System.Drawing.Point(634, 247);
            this.pn_Chua.Name = "pn_Chua";
            this.pn_Chua.Size = new System.Drawing.Size(557, 286);
            this.pn_Chua.TabIndex = 0;
            // 
            // dGV_GiamGia
            // 
            this.dGV_GiamGia.AllowUserToAddRows = false;
            this.dGV_GiamGia.AllowUserToResizeColumns = false;
            this.dGV_GiamGia.AllowUserToResizeRows = false;
            this.dGV_GiamGia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGV_GiamGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV_GiamGia.Location = new System.Drawing.Point(24, 251);
            this.dGV_GiamGia.Name = "dGV_GiamGia";
            this.dGV_GiamGia.ReadOnly = true;
            this.dGV_GiamGia.RowHeadersVisible = false;
            this.dGV_GiamGia.RowHeadersWidth = 51;
            this.dGV_GiamGia.RowTemplate.Height = 24;
            this.dGV_GiamGia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGV_GiamGia.Size = new System.Drawing.Size(583, 289);
            this.dGV_GiamGia.TabIndex = 1;
            this.dGV_GiamGia.SelectionChanged += new System.EventHandler(this.dGV_GiamGia_SelectionChanged);
            // 
            // label4
            // 
            this.label4.AutoEllipsis = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(381, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(380, 47);
            this.label4.TabIndex = 11;
            this.label4.Text = "Chương Trình Khuyến Mãi";
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(25, 223);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(372, 22);
            this.label1.TabIndex = 12;
            this.label1.Text = "Click chọn vào từng mã để xem chi tiết";
            // 
            // btnThemKhuyenMai
            // 
            this.btnThemKhuyenMai.AutoSize = true;
            this.btnThemKhuyenMai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemKhuyenMai.Location = new System.Drawing.Point(24, 556);
            this.btnThemKhuyenMai.Name = "btnThemKhuyenMai";
            this.btnThemKhuyenMai.Size = new System.Drawing.Size(89, 31);
            this.btnThemKhuyenMai.TabIndex = 13;
            this.btnThemKhuyenMai.Text = "Thêm";
            this.btnThemKhuyenMai.UseVisualStyleBackColor = true;
            this.btnThemKhuyenMai.Click += new System.EventHandler(this.btnThemKhuyenMai_Click);
            // 
            // btnXoaKhuyenMai
            // 
            this.btnXoaKhuyenMai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaKhuyenMai.Location = new System.Drawing.Point(525, 556);
            this.btnXoaKhuyenMai.Name = "btnXoaKhuyenMai";
            this.btnXoaKhuyenMai.Size = new System.Drawing.Size(82, 31);
            this.btnXoaKhuyenMai.TabIndex = 14;
            this.btnXoaKhuyenMai.Text = "Xóa";
            this.btnXoaKhuyenMai.UseVisualStyleBackColor = true;
            this.btnXoaKhuyenMai.Click += new System.EventHandler(this.btnXoaKhuyenMai_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnXacNhan);
            this.panel1.Controls.Add(label5);
            this.panel1.Controls.Add(label3);
            this.panel1.Controls.Add(label2);
            this.panel1.Controls.Add(this.dtpDen);
            this.panel1.Controls.Add(this.dtpTu);
            this.panel1.Location = new System.Drawing.Point(429, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(403, 136);
            this.panel1.TabIndex = 17;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.AutoSize = true;
            this.btnXacNhan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXacNhan.Location = new System.Drawing.Point(154, 91);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(72, 29);
            this.btnXacNhan.TabIndex = 17;
            this.btnXacNhan.Text = "Tìm kiếm";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // dtpDen
            // 
            this.dtpDen.CustomFormat = "dd";
            this.dtpDen.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDen.Location = new System.Drawing.Point(203, 45);
            this.dtpDen.Name = "dtpDen";
            this.dtpDen.Size = new System.Drawing.Size(150, 22);
            this.dtpDen.TabIndex = 12;
            // 
            // dtpTu
            // 
            this.dtpTu.CustomFormat = "dd";
            this.dtpTu.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTu.Location = new System.Drawing.Point(43, 45);
            this.dtpTu.Name = "dtpTu";
            this.dtpTu.Size = new System.Drawing.Size(132, 22);
            this.dtpTu.TabIndex = 11;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.AutoSize = true;
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.Location = new System.Drawing.Point(24, 188);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(72, 29);
            this.btnLamMoi.TabIndex = 18;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // label6
            // 
            this.label6.AutoEllipsis = true;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(63, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(224, 20);
            this.label6.TabIndex = 20;
            this.label6.Text = "Nhập mã giảm giá để tra cứu";
            // 
            // txtMaGiamGia
            // 
            this.txtMaGiamGia.Location = new System.Drawing.Point(56, 82);
            this.txtMaGiamGia.Name = "txtMaGiamGia";
            this.txtMaGiamGia.Size = new System.Drawing.Size(232, 22);
            this.txtMaGiamGia.TabIndex = 19;
            // 
            // btnTraCuu
            // 
            this.btnTraCuu.AutoSize = true;
            this.btnTraCuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTraCuu.Location = new System.Drawing.Point(307, 75);
            this.btnTraCuu.Name = "btnTraCuu";
            this.btnTraCuu.Size = new System.Drawing.Size(72, 29);
            this.btnTraCuu.TabIndex = 21;
            this.btnTraCuu.Text = "Tra cứu";
            this.btnTraCuu.UseVisualStyleBackColor = true;
            this.btnTraCuu.Click += new System.EventHandler(this.btnTraCuu_Click);
            // 
            // lblKetQua
            // 
            this.lblKetQua.AutoEllipsis = true;
            this.lblKetQua.AutoSize = true;
            this.lblKetQua.CausesValidation = false;
            this.lblKetQua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKetQua.ForeColor = System.Drawing.Color.Black;
            this.lblKetQua.Location = new System.Drawing.Point(61, 117);
            this.lblKetQua.Name = "lblKetQua";
            this.lblKetQua.Size = new System.Drawing.Size(123, 20);
            this.lblKetQua.TabIndex = 22;
            this.lblKetQua.Text = "Kết quả tra cứu";
            // 
            // fKhuyenMai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(1212, 611);
            this.Controls.Add(this.lblKetQua);
            this.Controls.Add(this.btnTraCuu);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtMaGiamGia);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnXoaKhuyenMai);
            this.Controls.Add(this.btnThemKhuyenMai);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dGV_GiamGia);
            this.Controls.Add(this.pn_Chua);
            this.Name = "fKhuyenMai";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fKhuyenMai";
            this.Load += new System.EventHandler(this.fKhuyenMai_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGV_GiamGia)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pn_Chua;
        private System.Windows.Forms.DataGridView dGV_GiamGia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnThemKhuyenMai;
        private System.Windows.Forms.Button btnXoaKhuyenMai;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpDen;
        private System.Windows.Forms.DateTimePicker dtpTu;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMaGiamGia;
        private System.Windows.Forms.Button btnTraCuu;
        private System.Windows.Forms.Label lblKetQua;
    }
}