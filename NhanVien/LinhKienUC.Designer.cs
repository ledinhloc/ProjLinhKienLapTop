using System.Drawing;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace ProCuaHangLinhKienLaptop.NhanVien
{
    partial class LinhKienUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTenLinhKien = new System.Windows.Forms.Label();
            this.lblGiaBan = new System.Windows.Forms.Label();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.picAnhLK = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAnhLK)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ProCuaHangLinhKienLaptop.Properties.Resources.CARD;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(252, 299);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.LinhKienUC_Click);
            // 
            // lblTenLinhKien
            // 
            this.lblTenLinhKien.AutoEllipsis = true;
            this.lblTenLinhKien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenLinhKien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTenLinhKien.Location = new System.Drawing.Point(18, 177);
            this.lblTenLinhKien.Name = "lblTenLinhKien";
            this.lblTenLinhKien.Size = new System.Drawing.Size(221, 25);
            this.lblTenLinhKien.TabIndex = 1;
            this.lblTenLinhKien.Text = "label1";
            this.lblTenLinhKien.Click += new System.EventHandler(this.LinhKienUC_Click);
            // 
            // lblGiaBan
            // 
            this.lblGiaBan.AutoSize = true;
            this.lblGiaBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblGiaBan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblGiaBan.Location = new System.Drawing.Point(18, 259);
            this.lblGiaBan.Name = "lblGiaBan";
            this.lblGiaBan.Size = new System.Drawing.Size(41, 22);
            this.lblGiaBan.TabIndex = 2;
            this.lblGiaBan.Text = "Gia";
            this.lblGiaBan.Click += new System.EventHandler(this.LinhKienUC_Click);
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.BackColor = System.Drawing.Color.Transparent;
            this.lblSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblSoLuong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(133)))), ((int)(((byte)(133)))));
            this.lblSoLuong.Location = new System.Drawing.Point(89, 223);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(51, 20);
            this.lblSoLuong.TabIndex = 3;
            this.lblSoLuong.Text = "label1";
            this.lblSoLuong.Click += new System.EventHandler(this.LinhKienUC_Click);
            // 
            // picAnhLK
            // 
            this.picAnhLK.Location = new System.Drawing.Point(17, 19);
            this.picAnhLK.Name = "picAnhLK";
            this.picAnhLK.Size = new System.Drawing.Size(217, 145);
            this.picAnhLK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAnhLK.TabIndex = 4;
            this.picAnhLK.TabStop = false;
            this.picAnhLK.Click += new System.EventHandler(this.LinhKienUC_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            this.label1.Location = new System.Drawing.Point(18, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tồn kho: ";
            // 
            // LinhKienUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picAnhLK);
            this.Controls.Add(this.lblSoLuong);
            this.Controls.Add(this.lblGiaBan);
            this.Controls.Add(this.lblTenLinhKien);
            this.Controls.Add(this.pictureBox1);
            this.Name = "LinhKienUC";
            this.Size = new System.Drawing.Size(255, 302);
            this.Click += new System.EventHandler(this.LinhKienUC_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAnhLK)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTenLinhKien;
        private System.Windows.Forms.Label lblGiaBan;
        private System.Windows.Forms.Label lblSoLuong;
        private PictureBox picAnhLK;
        private System.Windows.Forms.Label label1;
    }
}
