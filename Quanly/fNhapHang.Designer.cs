namespace ProCuaHangLinhKienLaptop.Quanly
{
    partial class fNhapHang
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dGV_PhieuNhap = new System.Windows.Forms.DataGridView();
            this.btnXoaPhieuNhap = new System.Windows.Forms.Button();
            this.btnThemPhieuNhap = new System.Windows.Forms.Button();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.txtGiaNhap = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSuaPhieuNhap = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMaLinhKien = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblMaPhieuNhap = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbTenLinhKien = new System.Windows.Forms.ComboBox();
            this.dtpNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_PhieuNhap)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dGV_PhieuNhap);
            this.groupBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 319);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(920, 331);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách nhập hàng";
            // 
            // dGV_PhieuNhap
            // 
            this.dGV_PhieuNhap.AllowUserToAddRows = false;
            this.dGV_PhieuNhap.AllowUserToResizeColumns = false;
            this.dGV_PhieuNhap.AllowUserToResizeRows = false;
            this.dGV_PhieuNhap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGV_PhieuNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV_PhieuNhap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dGV_PhieuNhap.Location = new System.Drawing.Point(19, 26);
            this.dGV_PhieuNhap.Name = "dGV_PhieuNhap";
            this.dGV_PhieuNhap.ReadOnly = true;
            this.dGV_PhieuNhap.RowHeadersVisible = false;
            this.dGV_PhieuNhap.RowHeadersWidth = 51;
            this.dGV_PhieuNhap.RowTemplate.Height = 24;
            this.dGV_PhieuNhap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGV_PhieuNhap.Size = new System.Drawing.Size(885, 289);
            this.dGV_PhieuNhap.TabIndex = 16;
            this.dGV_PhieuNhap.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGV_PhieuNhap_CellClick);
            // 
            // btnXoaPhieuNhap
            // 
            this.btnXoaPhieuNhap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaPhieuNhap.Location = new System.Drawing.Point(38, 123);
            this.btnXoaPhieuNhap.Name = "btnXoaPhieuNhap";
            this.btnXoaPhieuNhap.Size = new System.Drawing.Size(130, 37);
            this.btnXoaPhieuNhap.TabIndex = 20;
            this.btnXoaPhieuNhap.Text = "Xóa Phiếu Nhập";
            this.btnXoaPhieuNhap.UseVisualStyleBackColor = true;
            this.btnXoaPhieuNhap.Click += new System.EventHandler(this.btnXoaPhieuNhap_Click);
            // 
            // btnThemPhieuNhap
            // 
            this.btnThemPhieuNhap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemPhieuNhap.Location = new System.Drawing.Point(38, 18);
            this.btnThemPhieuNhap.Name = "btnThemPhieuNhap";
            this.btnThemPhieuNhap.Size = new System.Drawing.Size(130, 41);
            this.btnThemPhieuNhap.TabIndex = 19;
            this.btnThemPhieuNhap.Text = "Thêm Phiếu Nhập";
            this.btnThemPhieuNhap.UseVisualStyleBackColor = true;
            this.btnThemPhieuNhap.Click += new System.EventHandler(this.btnThemPhieuNhap_Click);
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(203, 72);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(160, 22);
            this.txtSoLuong.TabIndex = 33;
            // 
            // txtGiaNhap
            // 
            this.txtGiaNhap.Location = new System.Drawing.Point(403, 37);
            this.txtGiaNhap.Name = "txtGiaNhap";
            this.txtGiaNhap.Size = new System.Drawing.Size(160, 22);
            this.txtGiaNhap.TabIndex = 34;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnSuaPhieuNhap);
            this.panel1.Controls.Add(this.btnThemPhieuNhap);
            this.panel1.Controls.Add(this.btnXoaPhieuNhap);
            this.panel1.Location = new System.Drawing.Point(716, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 185);
            this.panel1.TabIndex = 36;
            // 
            // btnSuaPhieuNhap
            // 
            this.btnSuaPhieuNhap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSuaPhieuNhap.Location = new System.Drawing.Point(38, 71);
            this.btnSuaPhieuNhap.Name = "btnSuaPhieuNhap";
            this.btnSuaPhieuNhap.Size = new System.Drawing.Size(130, 37);
            this.btnSuaPhieuNhap.TabIndex = 21;
            this.btnSuaPhieuNhap.Text = "Sửa Phiếu Nhập";
            this.btnSuaPhieuNhap.UseVisualStyleBackColor = true;
            this.btnSuaPhieuNhap.Click += new System.EventHandler(this.btnSuaPhieuNhap_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtMaLinhKien);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.lblMaPhieuNhap);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.cbTenLinhKien);
            this.panel2.Controls.Add(this.dtpNgayNhap);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtSoLuong);
            this.panel2.Controls.Add(this.txtGiaNhap);
            this.panel2.Location = new System.Drawing.Point(31, 58);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(665, 255);
            this.panel2.TabIndex = 37;
            // 
            // label8
            // 
            this.label8.AutoEllipsis = true;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(143, 212);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(421, 22);
            this.label8.TabIndex = 45;
            this.label8.Text = "Chọn linh kiện từ danh sách hoặc nhập mã linh kiện";
            // 
            // txtMaLinhKien
            // 
            this.txtMaLinhKien.Location = new System.Drawing.Point(403, 177);
            this.txtMaLinhKien.Name = "txtMaLinhKien";
            this.txtMaLinhKien.Size = new System.Drawing.Size(160, 22);
            this.txtMaLinhKien.TabIndex = 35;
            // 
            // label7
            // 
            this.label7.AutoEllipsis = true;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(422, 152);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 22);
            this.label7.TabIndex = 44;
            this.label7.Text = "Mã Linh Kiện";
            // 
            // lblMaPhieuNhap
            // 
            this.lblMaPhieuNhap.AutoEllipsis = true;
            this.lblMaPhieuNhap.AutoSize = true;
            this.lblMaPhieuNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaPhieuNhap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMaPhieuNhap.Location = new System.Drawing.Point(78, 91);
            this.lblMaPhieuNhap.Name = "lblMaPhieuNhap";
            this.lblMaPhieuNhap.Size = new System.Drawing.Size(19, 20);
            this.lblMaPhieuNhap.TabIndex = 43;
            this.lblMaPhieuNhap.Text = "1";
            // 
            // label6
            // 
            this.label6.AutoEllipsis = true;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(46, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 22);
            this.label6.TabIndex = 42;
            this.label6.Text = "Mã Phiếu";
            // 
            // cbTenLinhKien
            // 
            this.cbTenLinhKien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbTenLinhKien.FormattingEnabled = true;
            this.cbTenLinhKien.Items.AddRange(new object[] {
            "Tìm theo tên",
            "Tìm theo email"});
            this.cbTenLinhKien.Location = new System.Drawing.Point(403, 106);
            this.cbTenLinhKien.Name = "cbTenLinhKien";
            this.cbTenLinhKien.Size = new System.Drawing.Size(160, 24);
            this.cbTenLinhKien.TabIndex = 41;
            this.cbTenLinhKien.SelectedIndexChanged += new System.EventHandler(this.cbTenLinhKien_SelectedIndexChanged);
            // 
            // dtpNgayNhap
            // 
            this.dtpNgayNhap.CustomFormat = "dd";
            this.dtpNgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayNhap.Location = new System.Drawing.Point(203, 158);
            this.dtpNgayNhap.Name = "dtpNgayNhap";
            this.dtpNgayNhap.Size = new System.Drawing.Size(160, 22);
            this.dtpNgayNhap.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.AutoEllipsis = true;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(230, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 22);
            this.label4.TabIndex = 39;
            this.label4.Text = "Số lượng";
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(431, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 22);
            this.label2.TabIndex = 38;
            this.label2.Text = "Giá nhập";
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(221, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 22);
            this.label1.TabIndex = 37;
            this.label1.Text = "Ngày nhập";
            // 
            // label3
            // 
            this.label3.AutoEllipsis = true;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(417, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 22);
            this.label3.TabIndex = 36;
            this.label3.Text = "Tên Linh Kiện";
            // 
            // label5
            // 
            this.label5.AutoEllipsis = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(331, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(240, 38);
            this.label5.TabIndex = 38;
            this.label5.Text = "Quản lý nhập hàng";
            // 
            // fNhapHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(947, 662);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "fNhapHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fNhapHang";
            this.Load += new System.EventHandler(this.fNhapHang_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGV_PhieuNhap)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dGV_PhieuNhap;
        private System.Windows.Forms.Button btnXoaPhieuNhap;
        private System.Windows.Forms.Button btnThemPhieuNhap;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.TextBox txtGiaNhap;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSuaPhieuNhap;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpNgayNhap;
        private System.Windows.Forms.ComboBox cbTenLinhKien;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblMaPhieuNhap;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMaLinhKien;
        private System.Windows.Forms.Label label7;
    }
}