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
            ((System.ComponentModel.ISupportInitialize)(this.dGV_NhanVien)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnXoaKhuyenMai
            // 
            this.btnXoaKhuyenMai.AutoSize = true;
            this.btnXoaKhuyenMai.Location = new System.Drawing.Point(930, 109);
            this.btnXoaKhuyenMai.Name = "btnXoaKhuyenMai";
            this.btnXoaKhuyenMai.Size = new System.Drawing.Size(143, 31);
            this.btnXoaKhuyenMai.TabIndex = 20;
            this.btnXoaKhuyenMai.Text = "Xóa Nhân Viên";
            this.btnXoaKhuyenMai.UseVisualStyleBackColor = true;
            this.btnXoaKhuyenMai.Click += new System.EventHandler(this.btnXoaKhuyenMai_Click);
            // 
            // btnThemNhanVien
            // 
            this.btnThemNhanVien.AutoSize = true;
            this.btnThemNhanVien.Location = new System.Drawing.Point(930, 46);
            this.btnThemNhanVien.Name = "btnThemNhanVien";
            this.btnThemNhanVien.Size = new System.Drawing.Size(143, 31);
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
            this.label4.Location = new System.Drawing.Point(390, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(317, 38);
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
            this.dGV_NhanVien.Location = new System.Drawing.Point(26, 27);
            this.dGV_NhanVien.Name = "dGV_NhanVien";
            this.dGV_NhanVien.ReadOnly = true;
            this.dGV_NhanVien.RowHeadersVisible = false;
            this.dGV_NhanVien.RowHeadersWidth = 51;
            this.dGV_NhanVien.RowTemplate.Height = 24;
            this.dGV_NhanVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGV_NhanVien.Size = new System.Drawing.Size(885, 289);
            this.dGV_NhanVien.TabIndex = 16;
            this.dGV_NhanVien.SelectionChanged += new System.EventHandler(this.dGV_NhanVien_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dGV_NhanVien);
            this.groupBox1.Controls.Add(this.btnXoaKhuyenMai);
            this.groupBox1.Controls.Add(this.btnThemNhanVien);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1138, 331);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách nhân viên";
            // 
            // pn_Chua
            // 
            this.pn_Chua.AutoSize = true;
            this.pn_Chua.Location = new System.Drawing.Point(38, 447);
            this.pn_Chua.Name = "pn_Chua";
            this.pn_Chua.Size = new System.Drawing.Size(885, 367);
            this.pn_Chua.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(396, 417);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 27);
            this.label1.TabIndex = 12;
            this.label1.Text = "Thông tin chi tiết";
            // 
            // fQuanLyNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1162, 841);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pn_Chua);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
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
    }
}