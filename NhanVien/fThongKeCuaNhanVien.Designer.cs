namespace ProCuaHangLinhKienLaptop.NhanVien
{
    partial class fThongKeCuaNhanVien
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnXem = new System.Windows.Forms.Button();
            this.chartLuongThuong = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartCaLam = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboThangBD = new System.Windows.Forms.ComboBox();
            this.cboNamBD = new System.Windows.Forms.ComboBox();
            this.abc = new System.Windows.Forms.Label();
            this.cboThangKT = new System.Windows.Forms.ComboBox();
            this.cboNamKT = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblCaLam = new System.Windows.Forms.Label();
            this.lblTongThuong = new System.Windows.Forms.Label();
            this.lblCaNghi = new System.Windows.Forms.Label();
            this.lblTongLuong = new System.Windows.Forms.Label();
            this.lblTongLuongThuong = new System.Windows.Forms.Label();
            this.btnThangHienTai = new System.Windows.Forms.Button();
            this.btnNamNay = new System.Windows.Forms.Button();
            this.btnThangTruoc = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartLuongThuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCaLam)).BeginInit();
            this.SuspendLayout();
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(359, 26);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(138, 53);
            this.btnXem.TabIndex = 1;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // chartLuongThuong
            // 
            chartArea5.Name = "ChartArea1";
            this.chartLuongThuong.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.chartLuongThuong.Legends.Add(legend5);
            this.chartLuongThuong.Location = new System.Drawing.Point(44, 101);
            this.chartLuongThuong.Name = "chartLuongThuong";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.chartLuongThuong.Series.Add(series5);
            this.chartLuongThuong.Size = new System.Drawing.Size(506, 325);
            this.chartLuongThuong.TabIndex = 2;
            this.chartLuongThuong.Text = "chart1";
            // 
            // chartCaLam
            // 
            chartArea6.Name = "ChartArea1";
            this.chartCaLam.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.chartCaLam.Legends.Add(legend6);
            this.chartCaLam.Location = new System.Drawing.Point(575, 101);
            this.chartCaLam.Name = "chartCaLam";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.chartCaLam.Series.Add(series6);
            this.chartCaLam.Size = new System.Drawing.Size(477, 325);
            this.chartCaLam.TabIndex = 2;
            this.chartCaLam.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(85, 457);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(85, 441);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Lương: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(640, 457);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ca đã làm:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(85, 473);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Thưởng:";
            // 
            // cboThangBD
            // 
            this.cboThangBD.FormattingEnabled = true;
            this.cboThangBD.Location = new System.Drawing.Point(141, 26);
            this.cboThangBD.Name = "cboThangBD";
            this.cboThangBD.Size = new System.Drawing.Size(56, 24);
            this.cboThangBD.TabIndex = 4;
            // 
            // cboNamBD
            // 
            this.cboNamBD.FormattingEnabled = true;
            this.cboNamBD.Location = new System.Drawing.Point(223, 26);
            this.cboNamBD.Name = "cboNamBD";
            this.cboNamBD.Size = new System.Drawing.Size(88, 24);
            this.cboNamBD.TabIndex = 4;
            // 
            // abc
            // 
            this.abc.AutoSize = true;
            this.abc.Location = new System.Drawing.Point(41, 29);
            this.abc.Name = "abc";
            this.abc.Size = new System.Drawing.Size(59, 16);
            this.abc.TabIndex = 5;
            this.abc.Text = "Từ tháng";
            // 
            // cboThangKT
            // 
            this.cboThangKT.FormattingEnabled = true;
            this.cboThangKT.Location = new System.Drawing.Point(141, 56);
            this.cboThangKT.Name = "cboThangKT";
            this.cboThangKT.Size = new System.Drawing.Size(56, 24);
            this.cboThangKT.TabIndex = 4;
            // 
            // cboNamKT
            // 
            this.cboNamKT.FormattingEnabled = true;
            this.cboNamKT.Location = new System.Drawing.Point(223, 56);
            this.cboNamKT.Name = "cboNamKT";
            this.cboNamKT.Size = new System.Drawing.Size(88, 24);
            this.cboNamKT.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Đến tháng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(85, 506);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "Tổng:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(640, 492);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 20);
            this.label7.TabIndex = 3;
            this.label7.Text = "Ca nghỉ:";
            // 
            // lblCaLam
            // 
            this.lblCaLam.AutoSize = true;
            this.lblCaLam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaLam.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblCaLam.Location = new System.Drawing.Point(736, 457);
            this.lblCaLam.Name = "lblCaLam";
            this.lblCaLam.Size = new System.Drawing.Size(29, 20);
            this.lblCaLam.TabIndex = 6;
            this.lblCaLam.Text = "20";
            // 
            // lblTongThuong
            // 
            this.lblTongThuong.AutoSize = true;
            this.lblTongThuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongThuong.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblTongThuong.Location = new System.Drawing.Point(174, 473);
            this.lblTongThuong.Name = "lblTongThuong";
            this.lblTongThuong.Size = new System.Drawing.Size(59, 20);
            this.lblTongThuong.TabIndex = 6;
            this.lblTongThuong.Text = "10000";
            // 
            // lblCaNghi
            // 
            this.lblCaNghi.AutoSize = true;
            this.lblCaNghi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaNghi.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblCaNghi.Location = new System.Drawing.Point(736, 492);
            this.lblCaNghi.Name = "lblCaNghi";
            this.lblCaNghi.Size = new System.Drawing.Size(19, 20);
            this.lblCaNghi.TabIndex = 6;
            this.lblCaNghi.Text = "5";
            // 
            // lblTongLuong
            // 
            this.lblTongLuong.AutoSize = true;
            this.lblTongLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongLuong.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblTongLuong.Location = new System.Drawing.Point(174, 441);
            this.lblTongLuong.Name = "lblTongLuong";
            this.lblTongLuong.Size = new System.Drawing.Size(59, 20);
            this.lblTongLuong.TabIndex = 6;
            this.lblTongLuong.Text = "10000";
            // 
            // lblTongLuongThuong
            // 
            this.lblTongLuongThuong.AutoSize = true;
            this.lblTongLuongThuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongLuongThuong.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblTongLuongThuong.Location = new System.Drawing.Point(174, 506);
            this.lblTongLuongThuong.Name = "lblTongLuongThuong";
            this.lblTongLuongThuong.Size = new System.Drawing.Size(59, 20);
            this.lblTongLuongThuong.TabIndex = 6;
            this.lblTongLuongThuong.Text = "20000";
            // 
            // btnThangHienTai
            // 
            this.btnThangHienTai.Location = new System.Drawing.Point(770, 29);
            this.btnThangHienTai.Name = "btnThangHienTai";
            this.btnThangHienTai.Size = new System.Drawing.Size(138, 53);
            this.btnThangHienTai.TabIndex = 1;
            this.btnThangHienTai.Text = "Tháng hiện tại";
            this.btnThangHienTai.UseVisualStyleBackColor = true;
            this.btnThangHienTai.Click += new System.EventHandler(this.btnThangHienTai_Click);
            // 
            // btnNamNay
            // 
            this.btnNamNay.Location = new System.Drawing.Point(914, 29);
            this.btnNamNay.Name = "btnNamNay";
            this.btnNamNay.Size = new System.Drawing.Size(138, 53);
            this.btnNamNay.TabIndex = 1;
            this.btnNamNay.Text = "Năm hiện tại";
            this.btnNamNay.UseVisualStyleBackColor = true;
            this.btnNamNay.Click += new System.EventHandler(this.btnNamNay_Click);
            // 
            // btnThangTruoc
            // 
            this.btnThangTruoc.Location = new System.Drawing.Point(617, 29);
            this.btnThangTruoc.Name = "btnThangTruoc";
            this.btnThangTruoc.Size = new System.Drawing.Size(138, 53);
            this.btnThangTruoc.TabIndex = 1;
            this.btnThangTruoc.Text = "Tháng trước";
            this.btnThangTruoc.UseVisualStyleBackColor = true;
            this.btnThangTruoc.Click += new System.EventHandler(this.btnThangTruoc_Click);
            // 
            // fThongKeCuaNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 547);
            this.Controls.Add(this.lblCaNghi);
            this.Controls.Add(this.lblTongLuongThuong);
            this.Controls.Add(this.lblTongLuong);
            this.Controls.Add(this.lblTongThuong);
            this.Controls.Add(this.lblCaLam);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.abc);
            this.Controls.Add(this.cboNamKT);
            this.Controls.Add(this.cboThangKT);
            this.Controls.Add(this.cboNamBD);
            this.Controls.Add(this.cboThangBD);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chartCaLam);
            this.Controls.Add(this.chartLuongThuong);
            this.Controls.Add(this.btnNamNay);
            this.Controls.Add(this.btnThangTruoc);
            this.Controls.Add(this.btnThangHienTai);
            this.Controls.Add(this.btnXem);
            this.Name = "fThongKeCuaNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê";
            this.Load += new System.EventHandler(this.fThongKeCuaNhanVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartLuongThuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCaLam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartLuongThuong;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCaLam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboThangBD;
        private System.Windows.Forms.ComboBox cboNamBD;
        private System.Windows.Forms.Label abc;
        private System.Windows.Forms.ComboBox cboThangKT;
        private System.Windows.Forms.ComboBox cboNamKT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblCaLam;
        private System.Windows.Forms.Label lblTongThuong;
        private System.Windows.Forms.Label lblCaNghi;
        private System.Windows.Forms.Label lblTongLuong;
        private System.Windows.Forms.Label lblTongLuongThuong;
        private System.Windows.Forms.Button btnThangHienTai;
        private System.Windows.Forms.Button btnNamNay;
        private System.Windows.Forms.Button btnThangTruoc;
    }
}