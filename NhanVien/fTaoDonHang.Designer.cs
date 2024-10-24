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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_DonHang = new System.Windows.Forms.DataGridView();
            this.MaLinhKien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLinhKien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.lblMaKH = new System.Windows.Forms.Label();
            this.btnKiemTraKhachHang = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.lblSDT = new System.Windows.Forms.Label();
            this.lblTenKhachHang = new System.Windows.Forms.Label();
            this.txtTimKhachHang = new System.Windows.Forms.TextBox();
            this.btnTimLK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DonHang)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_DonHang
            // 
            this.dgv_DonHang.AllowUserToAddRows = false;
            this.dgv_DonHang.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.dgv_DonHang.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_DonHang.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_DonHang.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_DonHang.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(4);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_DonHang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_DonHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DonHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaLinhKien,
            this.TenLinhKien,
            this.GiaBan,
            this.SoLuong});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(117)))), ((int)(((byte)(119)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(117)))), ((int)(((byte)(119)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_DonHang.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_DonHang.EnableHeadersVisualStyles = false;
            this.dgv_DonHang.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dgv_DonHang.Location = new System.Drawing.Point(763, 118);
            this.dgv_DonHang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgv_DonHang.Name = "dgv_DonHang";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_DonHang.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_DonHang.RowHeadersVisible = false;
            this.dgv_DonHang.RowHeadersWidth = 62;
            this.dgv_DonHang.RowTemplate.Height = 34;
            this.dgv_DonHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_DonHang.Size = new System.Drawing.Size(490, 352);
            this.dgv_DonHang.TabIndex = 16;
            this.dgv_DonHang.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_DonHang_CellValueChanged);
            this.dgv_DonHang.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgv_DonHang_UserDeletedRow);
            // 
            // MaLinhKien
            // 
            this.MaLinhKien.Frozen = true;
            this.MaLinhKien.HeaderText = "Mã LK";
            this.MaLinhKien.MinimumWidth = 8;
            this.MaLinhKien.Name = "MaLinhKien";
            this.MaLinhKien.ReadOnly = true;
            this.MaLinhKien.Width = 150;
            // 
            // TenLinhKien
            // 
            this.TenLinhKien.Frozen = true;
            this.TenLinhKien.HeaderText = "Tên";
            this.TenLinhKien.MinimumWidth = 8;
            this.TenLinhKien.Name = "TenLinhKien";
            this.TenLinhKien.ReadOnly = true;
            this.TenLinhKien.Width = 150;
            // 
            // GiaBan
            // 
            this.GiaBan.Frozen = true;
            this.GiaBan.HeaderText = "Giá";
            this.GiaBan.MinimumWidth = 8;
            this.GiaBan.Name = "GiaBan";
            this.GiaBan.ReadOnly = true;
            this.GiaBan.Width = 150;
            // 
            // SoLuong
            // 
            this.SoLuong.Frozen = true;
            this.SoLuong.HeaderText = "Số Lượng";
            this.SoLuong.MinimumWidth = 8;
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.Width = 150;
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(16, 47);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(741, 719);
            this.tabControl1.TabIndex = 15;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // btnCreateOrder
            // 
            this.btnCreateOrder.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnCreateOrder.Location = new System.Drawing.Point(842, 705);
            this.btnCreateOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCreateOrder.Name = "btnCreateOrder";
            this.btnCreateOrder.Size = new System.Drawing.Size(349, 34);
            this.btnCreateOrder.TabIndex = 14;
            this.btnCreateOrder.Text = "Create Order";
            this.btnCreateOrder.UseVisualStyleBackColor = true;
            this.btnCreateOrder.Click += new System.EventHandler(this.btnCreateOrder_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(464, 10);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(196, 22);
            this.txtSearch.TabIndex = 17;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(396, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "Tìm kiếm";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.Location = new System.Drawing.Point(836, 635);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(356, 2);
            this.panel3.TabIndex = 27;
            // 
            // lblAmountPaid
            // 
            this.lblAmountPaid.AutoSize = true;
            this.lblAmountPaid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblAmountPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountPaid.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblAmountPaid.Location = new System.Drawing.Point(1021, 646);
            this.lblAmountPaid.Name = "lblAmountPaid";
            this.lblAmountPaid.Size = new System.Drawing.Size(93, 25);
            this.lblAmountPaid.TabIndex = 19;
            this.lblAmountPaid.Text = "000VND";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(858, 646);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 24);
            this.label6.TabIndex = 20;
            this.label6.Text = "Total";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label5.Location = new System.Drawing.Point(855, 610);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 18);
            this.label5.TabIndex = 21;
            this.label5.Text = "Discount";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(1030, 580);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(51, 18);
            this.lblTotal.TabIndex = 23;
            this.lblTotal.Text = "0VND";
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblDiscount.Location = new System.Drawing.Point(1024, 610);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(57, 18);
            this.lblDiscount.TabIndex = 24;
            this.lblDiscount.Text = "-0VND";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label3.Location = new System.Drawing.Point(855, 580);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 18);
            this.label3.TabIndex = 26;
            this.label3.Text = "Sub total";
            // 
            // rbChuyenKhoan
            // 
            this.rbChuyenKhoan.AutoSize = true;
            this.rbChuyenKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbChuyenKhoan.ForeColor = System.Drawing.Color.MediumBlue;
            this.rbChuyenKhoan.Location = new System.Drawing.Point(1007, 522);
            this.rbChuyenKhoan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbChuyenKhoan.Name = "rbChuyenKhoan";
            this.rbChuyenKhoan.Size = new System.Drawing.Size(147, 24);
            this.rbChuyenKhoan.TabIndex = 28;
            this.rbChuyenKhoan.Text = "Chuyển khoản";
            this.rbChuyenKhoan.UseVisualStyleBackColor = true;
            // 
            // rbTienMat
            // 
            this.rbTienMat.AutoSize = true;
            this.rbTienMat.Checked = true;
            this.rbTienMat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTienMat.ForeColor = System.Drawing.Color.MediumBlue;
            this.rbTienMat.Location = new System.Drawing.Point(826, 522);
            this.rbTienMat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbTienMat.Name = "rbTienMat";
            this.rbTienMat.Size = new System.Drawing.Size(103, 24);
            this.rbTienMat.TabIndex = 29;
            this.rbTienMat.TabStop = true;
            this.rbTienMat.Text = "Tiền mặt";
            this.rbTienMat.UseVisualStyleBackColor = true;
            // 
            // txtMaGiamGia
            // 
            this.txtMaGiamGia.Location = new System.Drawing.Point(922, 487);
            this.txtMaGiamGia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaGiamGia.Name = "txtMaGiamGia";
            this.txtMaGiamGia.Size = new System.Drawing.Size(153, 22);
            this.txtMaGiamGia.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.MediumBlue;
            this.label1.Location = new System.Drawing.Point(794, 486);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 18);
            this.label1.TabIndex = 31;
            this.label1.Text = "Mã giảm giá";
            // 
            // btnKiemTraKhuyenMai
            // 
            this.btnKiemTraKhuyenMai.Location = new System.Drawing.Point(1105, 486);
            this.btnKiemTraKhuyenMai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnKiemTraKhuyenMai.Name = "btnKiemTraKhuyenMai";
            this.btnKiemTraKhuyenMai.Size = new System.Drawing.Size(67, 25);
            this.btnKiemTraKhuyenMai.TabIndex = 32;
            this.btnKiemTraKhuyenMai.Text = "Kiểm tra";
            this.btnKiemTraKhuyenMai.UseVisualStyleBackColor = true;
            this.btnKiemTraKhuyenMai.Click += new System.EventHandler(this.btnKiemTraKhuyenMai_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel1.Location = new System.Drawing.Point(826, 576);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(388, 111);
            this.panel1.TabIndex = 33;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel2.Controls.Add(this.lblMaKH);
            this.panel2.Controls.Add(this.btnKiemTraKhachHang);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.lblSDT);
            this.panel2.Controls.Add(this.lblTenKhachHang);
            this.panel2.Controls.Add(this.txtTimKhachHang);
            this.panel2.Location = new System.Drawing.Point(765, 10);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(477, 95);
            this.panel2.TabIndex = 34;
            // 
            // lblMaKH
            // 
            this.lblMaKH.AutoSize = true;
            this.lblMaKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaKH.Location = new System.Drawing.Point(3, 63);
            this.lblMaKH.Name = "lblMaKH";
            this.lblMaKH.Size = new System.Drawing.Size(54, 18);
            this.lblMaKH.TabIndex = 39;
            this.lblMaKH.Text = "Mã KH";
            // 
            // btnKiemTraKhachHang
            // 
            this.btnKiemTraKhachHang.Location = new System.Drawing.Point(382, 16);
            this.btnKiemTraKhachHang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnKiemTraKhachHang.Name = "btnKiemTraKhachHang";
            this.btnKiemTraKhachHang.Size = new System.Drawing.Size(67, 26);
            this.btnKiemTraKhachHang.TabIndex = 38;
            this.btnKiemTraKhachHang.Text = "Kiểm tra";
            this.btnKiemTraKhachHang.UseVisualStyleBackColor = true;
            this.btnKiemTraKhachHang.Click += new System.EventHandler(this.btnKiemTraKhachHang_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(9, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 18);
            this.label8.TabIndex = 37;
            this.label8.Text = "SĐT Khách hàng:";
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSDT.Location = new System.Drawing.Point(323, 63);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(38, 18);
            this.lblSDT.TabIndex = 36;
            this.lblSDT.Text = "SĐT";
            // 
            // lblTenKhachHang
            // 
            this.lblTenKhachHang.AutoSize = true;
            this.lblTenKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTenKhachHang.Location = new System.Drawing.Point(90, 58);
            this.lblTenKhachHang.Name = "lblTenKhachHang";
            this.lblTenKhachHang.Size = new System.Drawing.Size(50, 25);
            this.lblTenKhachHang.TabIndex = 35;
            this.lblTenKhachHang.Text = "Tên";
            // 
            // txtTimKhachHang
            // 
            this.txtTimKhachHang.Location = new System.Drawing.Point(165, 18);
            this.txtTimKhachHang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTimKhachHang.Name = "txtTimKhachHang";
            this.txtTimKhachHang.Size = new System.Drawing.Size(181, 22);
            this.txtTimKhachHang.TabIndex = 17;
            // 
            // btnTimLK
            // 
            this.btnTimLK.Location = new System.Drawing.Point(674, 8);
            this.btnTimLK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTimLK.Name = "btnTimLK";
            this.btnTimLK.Size = new System.Drawing.Size(84, 26);
            this.btnTimLK.TabIndex = 40;
            this.btnTimLK.Text = "Tìm";
            this.btnTimLK.UseVisualStyleBackColor = true;
            this.btnTimLK.Click += new System.EventHandler(this.btnTimLK_Click);
            // 
            // fTaoDonHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1259, 803);
            this.Controls.Add(this.btnTimLK);
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
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "fTaoDonHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.Label lblMaKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLinhKien;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLinhKien;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.Button btnTimLK;
    }
}