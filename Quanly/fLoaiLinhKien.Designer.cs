namespace ProCuaHangLinhKienLaptop.Quanly
{
    partial class fLoaiLinhKien
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

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
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(240, 240, 240); // Light modern gray
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.EnableHeadersVisualStyles = false; // Disable default styling
            this.dataGridView1.GridColor = System.Drawing.Color.Gainsboro;
            this.dataGridView1.Location = new System.Drawing.Point(50, 70);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false; // Hide row headers for a cleaner look
            this.dataGridView1.Size = new System.Drawing.Size(580, 250);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.AllowUserToAddRows = false; // Optional: Disable row adding
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            // Header Styling
            this.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(63, 81, 181); // Indigo header
            this.dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            // Cell Styling
            this.dataGridView1.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dataGridView1.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dataGridView1.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dataGridView1.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(197, 225, 165); // Light green highlight
            this.dataGridView1.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(260, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Loại Linh Kiện";
            // 
            // button1
            // 
            // 
            // button1 (Xóa)
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.BackColor = System.Drawing.Color.FromArgb(255, 77, 77); // Soft Red
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(150, 350);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "Xóa";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);

            // 
            // button2 (Sửa)
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button2.BackColor = System.Drawing.Color.FromArgb(255, 206, 84); // Warm Yellow
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(300, 350);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 35);
            this.button2.TabIndex = 3;
            this.button2.Text = "Sửa";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);

            // 
            // button3 (Thêm)
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button3.BackColor = System.Drawing.Color.FromArgb(85, 170, 85); // Modern Green
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(450, 350);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(90, 35);
            this.button3.TabIndex = 4;
            this.button3.Text = "Thêm";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);

            // 
            // fLoaiLinhKien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(680, 420);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "fLoaiLinhKien";
            this.Text = "Quản Lý Loại Linh Kiện";
            this.Load += new System.EventHandler(this.fLoaiLinhKien_Load);
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
