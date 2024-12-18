﻿using ProCuaHangLinhKienLaptop.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProCuaHangLinhKienLaptop.Quanly
{
    public partial class fKhuyenMai : Form
    {
        private DataProvider dataProvider;
        private UC_GiamGia userControl;
        public fKhuyenMai()
        {
            InitializeComponent();
            dataProvider = new DataProvider();
            dGV_GiamGia.SelectionChanged += dGV_GiamGia_SelectionChanged;
            userControl = new UC_GiamGia(); 
            pn_Chua.Controls.Add(userControl); 
        }

        private void fKhuyenMai_Load(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT * FROM vw_GiamGia";
                DataTable dataTable = dataProvider.ExecuteReader(CommandType.Text, query);
                dGV_GiamGia.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void dGV_GiamGia_SelectionChanged(object sender, EventArgs e)
        {
            if (dGV_GiamGia.CurrentRow != null)
            { 

                int maGiamGia = Convert.ToInt32(dGV_GiamGia.CurrentRow.Cells["MaGiamGia"].Value);
                string tenGiamGia = dGV_GiamGia.CurrentRow.Cells["TenGiamGia"].Value.ToString();
                DateTime ngayBatDau = Convert.ToDateTime(dGV_GiamGia.CurrentRow.Cells["NgayBatDau"].Value);
                DateTime ngayKetThuc = Convert.ToDateTime(dGV_GiamGia.CurrentRow.Cells["NgayKetThuc"].Value);
                decimal giaTri = Convert.ToDecimal(dGV_GiamGia.CurrentRow.Cells["GiaTri"].Value);

                userControl.UpdateDiscountInfo(maGiamGia, tenGiamGia, ngayBatDau, ngayKetThuc, giaTri);
            }

        }

        private void btnThemKhuyenMai_Click(object sender, EventArgs e)
        {
            fThemKM formThemKM = new fThemKM();
            formThemKM.KhuyenMaiAdded += FormThemKM_KhuyenMaiAdded;
            formThemKM.ShowDialog();
        }
        private void FormThemKM_KhuyenMaiAdded(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData() 
        {
            try
            {
                string query = "SELECT MaGiamGia, TenGiamGia, NgayBatDau, NgayKetThuc, GiaTri FROM GiamGia";
                DataTable dataTable = dataProvider.ExecuteReader(CommandType.Text, query);
                dGV_GiamGia.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void btnXoaKhuyenMai_Click(object sender, EventArgs e)
        {
            if (dGV_GiamGia.CurrentRow != null)
            {
                int maGiamGia = Convert.ToInt32(dGV_GiamGia.CurrentRow.Cells["MaGiamGia"].Value);
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa khuyến mãi này?",
                                                            "Xác nhận xóa",
                                                            MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        string query = "sp_XoaGiamGia";
                        SqlParameter param = new SqlParameter("@MaGiamGia", maGiamGia);
                        dataProvider.ExecuteNonQuery(CommandType.StoredProcedure, query, param);
                        LoadData();
                        MessageBox.Show("Khuyến mãi đã được xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting discount: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một khuyến mãi để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            DateTime tu = dtpTu.Value;
            DateTime den = dtpDen.Value;

            try
            {
                string query = "sp_TimKiemMaGiamGiaTheoThoiGian";
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@StartDate",tu),
                    new SqlParameter("@EndDate",den)
                };
                DataTable dataTable = dataProvider.ExecuteReader(CommandType.StoredProcedure, query, para);
                dGV_GiamGia.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            try
            {
                int maGiamGia = int.Parse(txtMaGiamGia.Text);
                string query = "SELECT dbo.fn_CheckGiamGiaHopLe(@MaGiamGia) AS Result";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaGiamGia", maGiamGia)
                };
                object result = dataProvider.ExecuteScalar(CommandType.Text, query, parameters);
                
                lblKetQua.Text = result.ToString();
                if (result.ToString() == "Mã giảm giá hợp lệ")
                {
                    string querySelect = "SELECT * FROM GiamGia WHERE MaGiamGia = @MaGiamGia";
                    DataTable dataTable = dataProvider.ExecuteReader(CommandType.Text, querySelect, parameters);
                    dGV_GiamGia.DataSource = dataTable;
                    lblKetQua.ForeColor = Color.Green;
                }
                else if (result.ToString() == "Mã giảm giá không tồn tại") {
                    lblKetQua.ForeColor = Color.Red;
                }
                lblKetQua.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra mã giảm giá: " + ex.Message);
            }
        }
    }
}
