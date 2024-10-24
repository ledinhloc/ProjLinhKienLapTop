﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProCuaHangLinhKienLaptop.Quanly
{
    public partial class LichLamViecUC : UserControl
    {
        public int maLichLamViec;
        public DateTime thang;
        public LichLamViecUC()
        {
            InitializeComponent();
        }

        public LichLamViecUC(int ma,string ngay, string tenCa, string gioBD, string gioKT)
        {
            InitializeComponent();

            maLichLamViec = ma;
            lblNgay.Text = ngay;
            lblTenCa.Text = tenCa;
            lblGioBD.Text = gioBD;
            lblGioKT.Text = gioKT;

            thang = DateTime.Parse(ngay);
        }

        private void LichLamViecUC_Load(object sender, EventArgs e)
        {

        }

        private void LichLamViecUC_Click(object sender, EventArgs e)
        {
            fThemCaLam fThemCa = new fThemCaLam(maLichLamViec, thang);
            fThemCa.ShowDialog();
        }
    }
}
