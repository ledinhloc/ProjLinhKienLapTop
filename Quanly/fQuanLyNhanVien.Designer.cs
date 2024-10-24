namespace ProCuaHangLinhKienLaptop.Quanly
{
    partial class fQuanLyNhanVien
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
            this.btnXoaKhuyenMai = new System.Windows.Forms.Button();
            this.btnThemNhanVien = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dGV_NhanVien = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pn_Chua = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTongNhanVien = new System.Windows.Forms.Label();
            this.txtTuKhoa = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_NhanVien)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnXoaKhuyenMai
            // 
            this.btnXoaKhuyenMai.AutoSize = true;
            this.btnXoaKhuyenMai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaKhuyenMai.Location = new System.Drawing.Point(1046, 136);
            this.btnXoaKhuyenMai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnXoaKhuyenMai.Name = "btnXoaKhuyenMai";
            this.btnXoaKhuyenMai.Size = new System.Drawing.Size(187, 44);
            this.btnXoaKhuyenMai.TabIndex = 20;
            this.btnXoaKhuyenMai.Text = "Xóa Nhân Viên";
            this.btnXoaKhuyenMai.UseVisualStyleBackColor = true;
            this.btnXoaKhuyenMai.Click += new System.EventHandler(this.btnXoaKhuyenMai_Click);
            // 
            // btnThemNhanVien
            // 
            this.btnThemNhanVien.AutoSize = true;
            this.btnThemNhanVien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemNhanVien.Location = new System.Drawing.Point(1046, 58);
            this.btnThemNhanVien.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnThemNhanVien.Name = "btnThemNhanVien";
<<<<<<< HEAD
            this.btnThemNhanVien.Size = new System.Drawing.Size(157, 31);
=======
            this.btnThemNhanVien.Size = new System.Drawing.Size(205, 44);
>>>>>>> 1d603164d4b385973c41d3b05b0844871c3896b1
            this.btnThemNhanVien.TabIndex = 19;
            this.btnThemNhanVien.Text = "Thêm Nhân Viên";
            this.btnThemNhanVien.UseVisualStyleBackColor = true;
            this.btnThemNhanVien.Click += new System.EventHandler(this.btnThemNhanVien_Click);
            // 
            // label4
            // 
            this.label4.AutoEllipsis = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(458, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(288, 48);
            this.label4.TabIndex = 17;
            this.label4.Text = "Quản Lý Nhân Viên";
            // 
            // dGV_NhanVien
            // 
            this.dGV_NhanVien.AllowUserToAddRows = false;
            this.dGV_NhanVien.AllowUserToResizeColumns = false;
            this.dGV_NhanVien.AllowUserToResizeRows = false;
            this.dGV_NhanVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGV_NhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV_NhanVien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dGV_NhanVien.Location = new System.Drawing.Point(29, 32);
            this.dGV_NhanVien.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dGV_NhanVien.Name = "dGV_NhanVien";
            this.dGV_NhanVien.ReadOnly = true;
            this.dGV_NhanVien.RowHeadersVisible = false;
            this.dGV_NhanVien.RowHeadersWidth = 51;
            this.dGV_NhanVien.RowTemplate.Height = 24;
            this.dGV_NhanVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGV_NhanVien.Size = new System.Drawing.Size(996, 361);
            this.dGV_NhanVien.TabIndex = 16;
            this.dGV_NhanVien.SelectionChanged += new System.EventHandler(this.dGV_NhanVien_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dGV_NhanVien);
            this.groupBox1.Controls.Add(this.btnXoaKhuyenMai);
            this.groupBox1.Controls.Add(this.btnThemNhanVien);
            this.groupBox1.Cursor = System.Windows.Forms.Cursors.Default;
<<<<<<< HEAD
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(11, 122);
=======
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 152);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
>>>>>>> 1d603164d4b385973c41d3b05b0844871c3896b1
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(1239, 414);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách nhân viên";
            // 
            // pn_Chua
            // 
            this.pn_Chua.AutoSize = true;
            this.pn_Chua.Location = new System.Drawing.Point(42, 621);
            this.pn_Chua.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pn_Chua.Name = "pn_Chua";
            this.pn_Chua.Size = new System.Drawing.Size(996, 459);
            this.pn_Chua.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(444, 584);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 34);
            this.label1.TabIndex = 12;
            this.label1.Text = "Thông tin chi tiết";
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(853, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 25);
            this.label2.TabIndex = 26;
            this.label2.Text = "Tổng Nhân Viên :";
            // 
            // lblTongNhanVien
            // 
            this.lblTongNhanVien.AutoEllipsis = true;
            this.lblTongNhanVien.AutoSize = true;
            this.lblTongNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongNhanVien.ForeColor = System.Drawing.Color.Black;
            this.lblTongNhanVien.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblTongNhanVien.Location = new System.Drawing.Point(1004, 120);
            this.lblTongNhanVien.Name = "lblTongNhanVien";
            this.lblTongNhanVien.Size = new System.Drawing.Size(36, 26);
            this.lblTongNhanVien.TabIndex = 27;
            this.lblTongNhanVien.Text = "10";
            // 
            // txtTuKhoa
            // 
            this.txtTuKhoa.Location = new System.Drawing.Point(188, 65);
            this.txtTuKhoa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTuKhoa.Name = "txtTuKhoa";
            this.txtTuKhoa.Size = new System.Drawing.Size(260, 26);
            this.txtTuKhoa.TabIndex = 30;
            this.txtTuKhoa.TextChanged += new System.EventHandler(this.txtTenNhanVien_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoEllipsis = true;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(37, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 25);
            this.label3.TabIndex = 31;
            this.label3.Text = "Nhập từ khóa :";
            // 
            // comboBox1
            // 
            this.comboBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Tìm theo tên",
            "Tìm theo email"});
            this.comboBox1.Location = new System.Drawing.Point(464, 65);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(167, 28);
            this.comboBox1.TabIndex = 33;
            // 
            // fQuanLyNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.PowderBlue;
<<<<<<< HEAD
            this.ClientSize = new System.Drawing.Size(1162, 891);
=======
            this.ClientSize = new System.Drawing.Size(1307, 1050);
>>>>>>> 1d603164d4b385973c41d3b05b0844871c3896b1
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTuKhoa);
            this.Controls.Add(this.lblTongNhanVien);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pn_Chua);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "fQuanLyNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fQuanLyNhanVien";
            this.Load += new System.EventHandler(this.fQuanLyNhanVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGV_NhanVien)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnXoaKhuyenMai;
        private System.Windows.Forms.Button btnThemNhanVien;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dGV_NhanVien;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel pn_Chua;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTongNhanVien;
        private System.Windows.Forms.TextBox txtTuKhoa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}