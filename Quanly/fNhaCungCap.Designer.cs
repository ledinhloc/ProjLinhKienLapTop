namespace ProCuaHangLinhKienLaptop.Quanly
{
    partial class fNhaCungCap
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
        /// Required method for Designer support - do not modify the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            // Cải tiến DataGridView
            this.dataGridView1.BackgroundColor = System.Drawing.Color.AliceBlue; // Màu nền tổng thể
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D; // Kiểu viền
            this.dataGridView1.GridColor = System.Drawing.Color.LightGray; // Màu của đường kẻ ô

            // Thiết lập phông chữ và căn chỉnh cho tiêu đề cột
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.LightSlateGray;
            this.dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            // Thiết lập hàng xen kẽ màu
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Lavender;
            this.dataGridView1.AlternatingRowsDefaultCellStyle.ForeColor = System.Drawing.Color.Black;

            // Thiết lập màu nền, chữ và căn chỉnh cho ô dữ liệu
            this.dataGridView1.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dataGridView1.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dataGridView1.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SteelBlue; // Nền khi chọn dòng
            this.dataGridView1.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White; // Chữ khi chọn dòng
            this.dataGridView1.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dataGridView1.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;

            // Hiệu ứng khi di chuột qua hàng
            this.dataGridView1.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dataGridView1.RowsDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dataGridView1.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            this.dataGridView1.RowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

            // Căn chỉnh kích thước DataGridView
            this.dataGridView1.Location = new System.Drawing.Point(56, 89);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(688, 250);
            this.dataGridView1.TabIndex = 0;

            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label1.Location = new System.Drawing.Point(300, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 41);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nhà Cung Cấp";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1 (Xóa NCC)
            // 
            this.button1.Location = new System.Drawing.Point(56, 373);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 40);
            this.button1.TabIndex = 2;
            this.button1.Text = "Xóa NCC";
            this.button1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.button1.BackColor = System.Drawing.Color.LightCoral;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2 (Sửa NCC)
            // 
            this.button2.Location = new System.Drawing.Point(338, 373);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 40);
            this.button2.TabIndex = 3;
            this.button2.Text = "Sửa NCC";
            this.button2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.button2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3 (Thêm NCC)
            // 
            this.button3.Location = new System.Drawing.Point(644, 373);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 40);
            this.button3.TabIndex = 4;
            this.button3.Text = "Thêm NCC";
            this.button3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.button3.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // fNhaCungCap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "fNhaCungCap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Nhà Cung Cấp";
            this.Load += new System.EventHandler(this.fNhaCungCap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}