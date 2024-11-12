using System.Drawing;
using System.Windows.Forms;

namespace ProCuaHangLinhKienLaptop.Quanly
{
    partial class fLuong
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
            this.dgvLuong = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbNam = new System.Windows.Forms.ComboBox();
            this.cmbThang = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLuong
            // 
            this.dgvLuong.AllowUserToAddRows = false;
            this.dgvLuong.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.dgvLuong.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLuong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLuong.BackgroundColor = System.Drawing.Color.White;
            this.dgvLuong.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLuong.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvLuong.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(4);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLuong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(117)))), ((int)(((byte)(119)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(117)))), ((int)(((byte)(119)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLuong.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLuong.EnableHeadersVisualStyles = false;
            this.dgvLuong.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dgvLuong.Location = new System.Drawing.Point(29, 133);
            this.dgvLuong.Name = "dgvLuong";
            this.dgvLuong.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLuong.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvLuong.RowHeadersVisible = false;
            this.dgvLuong.RowHeadersWidth = 62;
            this.dgvLuong.RowTemplate.Height = 34;
            this.dgvLuong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLuong.Size = new System.Drawing.Size(1198, 483);
            this.dgvLuong.TabIndex = 0;
            this.dgvLuong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLuong_CellClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(453, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(347, 30);
            this.label3.TabIndex = 27;
            this.label3.Text = "BẢNG LƯƠNG NHÂN VIÊN";
            // 
            // cmbNam
            // 
            this.cmbNam.FormattingEnabled = true;
            this.cmbNam.Items.AddRange(new object[] {
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027"});
            this.cmbNam.Location = new System.Drawing.Point(232, 77);
            this.cmbNam.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbNam.Name = "cmbNam";
            this.cmbNam.Size = new System.Drawing.Size(98, 28);
            this.cmbNam.TabIndex = 28;
            this.cmbNam.SelectedIndexChanged += new System.EventHandler(this.cmbThang_SelectedIndexChanged);
            // 
            // cmbThang
            // 
            this.cmbThang.FormattingEnabled = true;
            this.cmbThang.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.cmbThang.Location = new System.Drawing.Point(95, 78);
            this.cmbThang.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbThang.Name = "cmbThang";
            this.cmbThang.Size = new System.Drawing.Size(62, 28);
            this.cmbThang.TabIndex = 29;
            this.cmbThang.SelectedIndexChanged += new System.EventHandler(this.cmbThang_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(32, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 19);
            this.label1.TabIndex = 30;
            this.label1.Text = "Tháng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label2.Location = new System.Drawing.Point(178, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 19);
            this.label2.TabIndex = 31;
            this.label2.Text = "Năm";
            // 
            // fLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 662);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbNam);
            this.Controls.Add(this.cmbThang);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvLuong);
            this.Name = "fLuong";
            this.Text = "fLuong";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLuong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLuong;
        private Label label3;
        private ComboBox cmbNam;
        private ComboBox cmbThang;
        private Label label1;
        private Label label2;
    }
}