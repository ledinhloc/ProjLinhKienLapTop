namespace ProCuaHangLinhKienLaptop.Quanly
{
    partial class fCaLamViec
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.cboGioBD = new System.Windows.Forms.ComboBox();
            this.dgvCaLam = new System.Windows.Forms.DataGridView();
            this.txtTenCa = new System.Windows.Forms.TextBox();
            this.cboPhutBD = new System.Windows.Forms.ComboBox();
            this.cboGioKT = new System.Windows.Forms.ComboBox();
            this.cboPhutKT = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMaCa = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaLam)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 168);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Đến";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 116);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "Từ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 60);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "Tên ca";
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(504, 130);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(139, 39);
            this.btnXoa.TabIndex = 11;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(504, 72);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(139, 39);
            this.btnCapNhat.TabIndex = 12;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(504, 12);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(139, 39);
            this.btnThem.TabIndex = 13;
            this.btnThem.Text = "Thêm ";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // cboGioBD
            // 
            this.cboGioBD.FormattingEnabled = true;
            this.cboGioBD.Location = new System.Drawing.Point(145, 110);
            this.cboGioBD.Name = "cboGioBD";
            this.cboGioBD.Size = new System.Drawing.Size(62, 24);
            this.cboGioBD.TabIndex = 9;
            // 
            // dgvCaLam
            // 
            this.dgvCaLam.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCaLam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCaLam.Location = new System.Drawing.Point(52, 214);
            this.dgvCaLam.Name = "dgvCaLam";
            this.dgvCaLam.ReadOnly = true;
            this.dgvCaLam.RowHeadersWidth = 51;
            this.dgvCaLam.RowTemplate.Height = 24;
            this.dgvCaLam.Size = new System.Drawing.Size(591, 275);
            this.dgvCaLam.TabIndex = 8;
            this.dgvCaLam.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCaLam_CellClick);
            // 
            // txtTenCa
            // 
            this.txtTenCa.Location = new System.Drawing.Point(145, 60);
            this.txtTenCa.Name = "txtTenCa";
            this.txtTenCa.Size = new System.Drawing.Size(199, 22);
            this.txtTenCa.TabIndex = 17;
            // 
            // cboPhutBD
            // 
            this.cboPhutBD.FormattingEnabled = true;
            this.cboPhutBD.Location = new System.Drawing.Point(229, 110);
            this.cboPhutBD.Name = "cboPhutBD";
            this.cboPhutBD.Size = new System.Drawing.Size(63, 24);
            this.cboPhutBD.TabIndex = 9;
            // 
            // cboGioKT
            // 
            this.cboGioKT.FormattingEnabled = true;
            this.cboGioKT.Location = new System.Drawing.Point(145, 162);
            this.cboGioKT.Name = "cboGioKT";
            this.cboGioKT.Size = new System.Drawing.Size(62, 24);
            this.cboGioKT.TabIndex = 9;
            // 
            // cboPhutKT
            // 
            this.cboPhutKT.FormattingEnabled = true;
            this.cboPhutKT.Location = new System.Drawing.Point(229, 162);
            this.cboPhutKT.Name = "cboPhutKT";
            this.cboPhutKT.Size = new System.Drawing.Size(63, 24);
            this.cboPhutKT.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(212, 113);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = ":";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(212, 166);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = ":";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(59, 20);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 16);
            this.label6.TabIndex = 16;
            this.label6.Text = "Mã ca";
            // 
            // txtMaCa
            // 
            this.txtMaCa.Location = new System.Drawing.Point(145, 20);
            this.txtMaCa.Name = "txtMaCa";
            this.txtMaCa.ReadOnly = true;
            this.txtMaCa.Size = new System.Drawing.Size(199, 22);
            this.txtMaCa.TabIndex = 17;
            // 
            // fCaLamViec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 522);
            this.Controls.Add(this.txtMaCa);
            this.Controls.Add(this.txtTenCa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.cboPhutKT);
            this.Controls.Add(this.cboGioKT);
            this.Controls.Add(this.cboPhutBD);
            this.Controls.Add(this.cboGioBD);
            this.Controls.Add(this.dgvCaLam);
            this.Name = "fCaLamViec";
            this.Text = "fCaLamViec";
            this.Load += new System.EventHandler(this.fCaLamViec_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaLam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.ComboBox cboGioBD;
        private System.Windows.Forms.DataGridView dgvCaLam;
        private System.Windows.Forms.TextBox txtTenCa;
        private System.Windows.Forms.ComboBox cboPhutBD;
        private System.Windows.Forms.ComboBox cboGioKT;
        private System.Windows.Forms.ComboBox cboPhutKT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMaCa;
    }
}