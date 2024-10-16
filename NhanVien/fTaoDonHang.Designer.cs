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
            this.lblTotal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DonHang)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_DonHang
            // 
            this.dgv_DonHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DonHang.Location = new System.Drawing.Point(858, 136);
            this.dgv_DonHang.Name = "dgv_DonHang";
            this.dgv_DonHang.RowHeadersWidth = 62;
            this.dgv_DonHang.RowTemplate.Height = 28;
            this.dgv_DonHang.Size = new System.Drawing.Size(511, 532);
            this.dgv_DonHang.TabIndex = 16;
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(18, 136);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(834, 574);
            this.tabControl1.TabIndex = 15;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // btnCreateOrder
            // 
            this.btnCreateOrder.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnCreateOrder.Location = new System.Drawing.Point(917, 760);
            this.btnCreateOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCreateOrder.Name = "btnCreateOrder";
            this.btnCreateOrder.Size = new System.Drawing.Size(350, 43);
            this.btnCreateOrder.TabIndex = 14;
            this.btnCreateOrder.Text = "Create Order";
            this.btnCreateOrder.UseVisualStyleBackColor = true;
            this.btnCreateOrder.Click += new System.EventHandler(this.btnCreateOrder_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.Red;
            this.lblTotal.Location = new System.Drawing.Point(1134, 685);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(45, 36);
            this.lblTotal.TabIndex = 13;
            this.lblTotal.Text = "$0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.Location = new System.Drawing.Point(911, 689);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 32);
            this.label1.TabIndex = 12;
            this.label1.Text = "Total";
            // 
            // fTaoDonHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1387, 832);
            this.Controls.Add(this.dgv_DonHang);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCreateOrder);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label1);
            this.Name = "fTaoDonHang";
            this.Text = "fTaoDonHang";
            this.Load += new System.EventHandler(this.fTaoDonHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DonHang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_DonHang;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button btnCreateOrder;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label1;
    }
}