namespace ProCuaHangLinhKienLaptop.NhanVien
{
    partial class fTaoDonHang
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
            this.dgv_DonHang = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.btnCreateOrder = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblAmountPaid = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rbChuyenKhoan = new System.Windows.Forms.RadioButton();
            this.rbTienMat = new System.Windows.Forms.RadioButton();
            this.txtMaGiamGia = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnKiemTraKhuyenMai = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblSDT = new System.Windows.Forms.Label();
            this.lblTenKhachHang = new System.Windows.Forms.Label();
            this.txtTimKhachHang = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnKiemTraKhachHang = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DonHang)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_DonHang
            // 
            this.dgv_DonHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DonHang.Location = new System.Drawing.Point(858, 147);
            this.dgv_DonHang.Name = "dgv_DonHang";
            this.dgv_DonHang.RowHeadersWidth = 62;
            this.dgv_DonHang.RowTemplate.Height = 28;
            this.dgv_DonHang.Size = new System.Drawing.Size(511, 440);
            this.dgv_DonHang.TabIndex = 16;
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(18, 59);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(834, 899);
            this.tabControl1.TabIndex = 15;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // btnCreateOrder
            // 
            this.btnCreateOrder.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnCreateOrder.Location = new System.Drawing.Point(947, 881);
            this.btnCreateOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCreateOrder.Name = "btnCreateOrder";
            this.btnCreateOrder.Size = new System.Drawing.Size(393, 43);
            this.btnCreateOrder.TabIndex = 14;
            this.btnCreateOrder.Text = "Create Order";
            this.btnCreateOrder.UseVisualStyleBackColor = true;
            this.btnCreateOrder.Click += new System.EventHandler(this.btnCreateOrder_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(620, 24);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(232, 26);
            this.txtSearch.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(543, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Tìm kiếm";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.Location = new System.Drawing.Point(940, 794);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(400, 2);
            this.panel3.TabIndex = 27;
            // 
            // lblAmountPaid
            // 
            this.lblAmountPaid.AutoSize = true;
            this.lblAmountPaid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblAmountPaid.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountPaid.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblAmountPaid.Location = new System.Drawing.Point(1176, 807);
            this.lblAmountPaid.Name = "lblAmountPaid";
            this.lblAmountPaid.Size = new System.Drawing.Size(71, 42);
            this.lblAmountPaid.TabIndex = 19;
            this.lblAmountPaid.Text = "$122";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label6.Font = new System.Drawing.Font("Poppins", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(965, 807);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 39);
            this.label6.TabIndex = 20;
            this.label6.Text = "Total";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label5.Font = new System.Drawing.Font("Poppins", 9F);
            this.label5.Location = new System.Drawing.Point(962, 763);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 31);
            this.label5.TabIndex = 21;
            this.label5.Text = "Discount";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblTotal.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(1186, 725);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(53, 31);
            this.lblTotal.TabIndex = 23;
            this.lblTotal.Text = "$122";
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblDiscount.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold);
            this.lblDiscount.Location = new System.Drawing.Point(1186, 763);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(48, 31);
            this.lblDiscount.TabIndex = 24;
            this.lblDiscount.Text = "-0$";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label3.Font = new System.Drawing.Font("Poppins", 9F);
            this.label3.Location = new System.Drawing.Point(962, 725);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 31);
            this.label3.TabIndex = 26;
            this.label3.Text = "Sub total";
            // 
            // rbChuyenKhoan
            // 
            this.rbChuyenKhoan.AutoSize = true;
            this.rbChuyenKhoan.Font = new System.Drawing.Font("Poppins Medium", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbChuyenKhoan.ForeColor = System.Drawing.Color.MediumBlue;
            this.rbChuyenKhoan.Location = new System.Drawing.Point(1133, 653);
            this.rbChuyenKhoan.Name = "rbChuyenKhoan";
            this.rbChuyenKhoan.Size = new System.Drawing.Size(200, 40);
            this.rbChuyenKhoan.TabIndex = 28;
            this.rbChuyenKhoan.Text = "Chuyển khoản";
            this.rbChuyenKhoan.UseVisualStyleBackColor = true;
            // 
            // rbTienMat
            // 
            this.rbTienMat.AutoSize = true;
            this.rbTienMat.Checked = true;
            this.rbTienMat.Font = new System.Drawing.Font("Poppins Medium", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTienMat.ForeColor = System.Drawing.Color.MediumBlue;
            this.rbTienMat.Location = new System.Drawing.Point(929, 653);
            this.rbTienMat.Name = "rbTienMat";
            this.rbTienMat.Size = new System.Drawing.Size(137, 40);
            this.rbTienMat.TabIndex = 29;
            this.rbTienMat.TabStop = true;
            this.rbTienMat.Text = "Tiền mặt";
            this.rbTienMat.UseVisualStyleBackColor = true;
            // 
            // txtMaGiamGia
            // 
            this.txtMaGiamGia.Location = new System.Drawing.Point(1037, 609);
            this.txtMaGiamGia.Name = "txtMaGiamGia";
            this.txtMaGiamGia.Size = new System.Drawing.Size(172, 26);
            this.txtMaGiamGia.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.MediumBlue;
            this.label1.Location = new System.Drawing.Point(893, 608);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 31);
            this.label1.TabIndex = 31;
            this.label1.Text = "Mã giảm giá";
            // 
            // btnKiemTraKhuyenMai
            // 
            this.btnKiemTraKhuyenMai.Location = new System.Drawing.Point(1243, 608);
            this.btnKiemTraKhuyenMai.Name = "btnKiemTraKhuyenMai";
            this.btnKiemTraKhuyenMai.Size = new System.Drawing.Size(75, 31);
            this.btnKiemTraKhuyenMai.TabIndex = 32;
            this.btnKiemTraKhuyenMai.Text = "Kiểm tra";
            this.btnKiemTraKhuyenMai.UseVisualStyleBackColor = true;
            this.btnKiemTraKhuyenMai.Click += new System.EventHandler(this.btnKiemTraKhuyenMai_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel1.Location = new System.Drawing.Point(940, 720);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 139);
            this.panel1.TabIndex = 33;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel2.Controls.Add(this.btnKiemTraKhachHang);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.lblSDT);
            this.panel2.Controls.Add(this.lblTenKhachHang);
            this.panel2.Controls.Add(this.txtTimKhachHang);
            this.panel2.Location = new System.Drawing.Point(861, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(511, 119);
            this.panel2.TabIndex = 34;
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSDT.Location = new System.Drawing.Point(300, 79);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(48, 31);
            this.lblSDT.TabIndex = 36;
            this.lblSDT.Text = "SĐT";
            // 
            // lblTenKhachHang
            // 
            this.lblTenKhachHang.AutoSize = true;
            this.lblTenKhachHang.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold);
            this.lblTenKhachHang.Location = new System.Drawing.Point(8, 74);
            this.lblTenKhachHang.Name = "lblTenKhachHang";
            this.lblTenKhachHang.Size = new System.Drawing.Size(63, 42);
            this.lblTenKhachHang.TabIndex = 35;
            this.lblTenKhachHang.Text = "Tên";
            // 
            // txtTimKhachHang
            // 
            this.txtTimKhachHang.Location = new System.Drawing.Point(186, 22);
            this.txtTimKhachHang.Name = "txtTimKhachHang";
            this.txtTimKhachHang.Size = new System.Drawing.Size(203, 26);
            this.txtTimKhachHang.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(10, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(168, 31);
            this.label8.TabIndex = 37;
            this.label8.Text = "SĐT Khách hàng:";
            // 
            // btnKiemTraKhachHang
            // 
            this.btnKiemTraKhachHang.Location = new System.Drawing.Point(414, 20);
            this.btnKiemTraKhachHang.Name = "btnKiemTraKhachHang";
            this.btnKiemTraKhachHang.Size = new System.Drawing.Size(75, 32);
            this.btnKiemTraKhachHang.TabIndex = 38;
            this.btnKiemTraKhachHang.Text = "Kiểm tra";
            this.btnKiemTraKhachHang.UseVisualStyleBackColor = true;
            this.btnKiemTraKhachHang.Click += new System.EventHandler(this.btnKiemTraKhachHang_Click);
            // 
            // fTaoDonHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1387, 1004);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnKiemTraKhuyenMai);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMaGiamGia);
            this.Controls.Add(this.rbChuyenKhoan);
            this.Controls.Add(this.rbTienMat);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lblAmountPaid);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgv_DonHang);
            this.Controls.Add(this.btnCreateOrder);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Name = "fTaoDonHang";
            this.Text = "fTaoDonHang";
            this.Load += new System.EventHandler(this.fTaoDonHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DonHang)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_DonHang;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button btnCreateOrder;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblAmountPaid;
        private System.Windows.Forms.RadioButton rbChuyenKhoan;
        private System.Windows.Forms.RadioButton rbTienMat;
        private System.Windows.Forms.TextBox txtMaGiamGia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnKiemTraKhuyenMai;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.Label lblTenKhachHang;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTimKhachHang;
        private System.Windows.Forms.Button btnKiemTraKhachHang;
    }
}