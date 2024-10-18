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
            this.pn_Chua = new System.Windows.Forms.FlowLayoutPanel();
            this.dGV_GiamGia = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnThemKhuyenMai = new System.Windows.Forms.Button();
            this.btnXoaKhuyenMai = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_GiamGia)).BeginInit();
            this.SuspendLayout();
            // 
            // pn_Chua
            // 
            this.pn_Chua.AutoSize = true;
            this.pn_Chua.Location = new System.Drawing.Point(642, 86);
            this.pn_Chua.Name = "pn_Chua";
            this.pn_Chua.Size = new System.Drawing.Size(514, 288);
            this.pn_Chua.TabIndex = 0;
            // 
            // dGV_GiamGia
            // 
            this.dGV_GiamGia.AllowUserToAddRows = false;
            this.dGV_GiamGia.AllowUserToResizeColumns = false;
            this.dGV_GiamGia.AllowUserToResizeRows = false;
            this.dGV_GiamGia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGV_GiamGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV_GiamGia.Location = new System.Drawing.Point(32, 87);
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
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(136, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(317, 38);
            this.label4.TabIndex = 11;
            this.label4.Text = "Chương Trình Khuyến Mãi";
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(33, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(372, 22);
            this.label1.TabIndex = 12;
            this.label1.Text = "Click chọn vào từng mã để xem chi tiết";
            // 
            // btnThemKhuyenMai
            // 
            this.btnThemKhuyenMai.AutoSize = true;
            this.btnThemKhuyenMai.Location = new System.Drawing.Point(32, 395);
            this.btnThemKhuyenMai.Name = "btnThemKhuyenMai";
            this.btnThemKhuyenMai.Size = new System.Drawing.Size(125, 31);
            this.btnThemKhuyenMai.TabIndex = 13;
            this.btnThemKhuyenMai.Text = "Thêm khuyến mãi";
            this.btnThemKhuyenMai.UseVisualStyleBackColor = true;
            this.btnThemKhuyenMai.Click += new System.EventHandler(this.btnThemKhuyenMai_Click);
            // 
            // btnXoaKhuyenMai
            // 
            this.btnXoaKhuyenMai.Location = new System.Drawing.Point(550, 395);
            this.btnXoaKhuyenMai.Name = "btnXoaKhuyenMai";
            this.btnXoaKhuyenMai.Size = new System.Drawing.Size(65, 31);
            this.btnXoaKhuyenMai.TabIndex = 14;
            this.btnXoaKhuyenMai.Text = "Xóa";
            this.btnXoaKhuyenMai.UseVisualStyleBackColor = true;
            this.btnXoaKhuyenMai.Click += new System.EventHandler(this.btnXoaKhuyenMai_Click);
            // 
            // fKhuyenMai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1229, 453);
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
    }
}