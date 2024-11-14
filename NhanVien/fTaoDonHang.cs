using ProCuaHangLinhKienLaptop.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProCuaHangLinhKienLaptop.NhanVien
{
    public partial class fTaoDonHang : Form
    {
        DataProvider provider = new DataProvider();
        private List<DonHangItem> donHangItems = new List<DonHangItem>();
        private int maNhanVien;

        public fTaoDonHang(int maNhanVien)
        {
            InitializeComponent();
            this.maNhanVien = maNhanVien;
        }

        private void fTaoDonHang_Load(object sender, EventArgs e)
        {
            LoadLoaiLinhKien();
            dgv_DonHang.Columns[0].ReadOnly = true;
            dgv_DonHang.Columns[1].ReadOnly = true;
            dgv_DonHang.Columns[2].ReadOnly = true;
        }

        private void LoadLoaiLinhKien()
        {
            DataTable loaiLinhKienTable = provider.ExecuteReader(CommandType.Text, "SELECT * FROM vw_ThongTinLoaiLinhKien");

            foreach (DataRow row in loaiLinhKienTable.Rows)
            {
                string tenLoai = row["TenLoaiLinhKien"].ToString();
                int maLoai = (int)row["MaLoaiLinhKien"];

                TabPage tabPage = new TabPage(tenLoai);
                tabPage.Tag = maLoai;

                FlowLayoutPanel flowLayoutPanelTemp = new FlowLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    AutoScroll = true,
                    BackColor = Color.White,
                };

                tabPage.Controls.Add(flowLayoutPanelTemp);
                tabControl1.TabPages.Add(tabPage);
            }

            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = Color.White,
            };
            TabPage allPage = new TabPage("All");
            allPage.Controls.Add(flowLayoutPanel);
            tabControl1.TabPages.Add(allPage);
            tabControl1.SelectedTab = allPage;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage selectedTab = tabControl1.SelectedTab;

            if (selectedTab != null)
            {
                int? maLoaiLinhKien = selectedTab.Tag as int?;
                DisplayLinhKien(maLoaiLinhKien, selectedTab);
            }
        }
        private void DisplayLinhKien(int? maLoaiLinhKien = null, TabPage selectedTab = null)
        {
            TabPage targetTabPage = selectedTab;
            FlowLayoutPanel flowLayoutPanel = (FlowLayoutPanel)targetTabPage.Controls[0];
            flowLayoutPanel.Controls.Clear();

            string cmdText = maLoaiLinhKien == null
                ? "SELECT * FROM vw_ThongTinLinhKien"
                : "SELECT * FROM vw_ThongTinLinhKien WHERE MaLoaiLinhKien = @MaLoai";

            SqlParameter[] parameters = maLoaiLinhKien != null
                ? new SqlParameter[] { new SqlParameter("@MaLoai", maLoaiLinhKien) }
                : null;

            DataTable linhKienTable = provider.ExecuteReader(CommandType.Text, cmdText, parameters);

            foreach (DataRow row in linhKienTable.Rows)
            {
                LinhKienUC linhKienUC = new LinhKienUC((int)row["MaLinhKien"], row["TenLinhKien"].ToString(), row["MoTaChiTiet"].ToString(),
                    (decimal)row["GiaBan"], (decimal)row["GiaNhap"], (int)row["SoLuongTonKho"], (Image)ImageHelper.GetImageFromResources(row["HinhAnh"].ToString()));
                linhKienUC.LinhKienClicked += LinhKienUC_Clicked;
                flowLayoutPanel.Controls.Add(linhKienUC);
            }

            tabControl1.SelectedTab = targetTabPage;
        }
        private void LinhKienUC_Clicked(object sender, EventArgs e)
        {
            LinhKienUC linhKienUC = sender as LinhKienUC;
            if (linhKienUC != null)
            {
                DonHangItem donHangItem = new DonHangItem
                {
                    MaLinhKien = linhKienUC.MaLinhKien,
                    TenLinhKien = linhKienUC.TenLinhKien,
                    GiaBan = linhKienUC.GiaBan,
                    SoLuong = 1
                };

                var existingItem = donHangItems.FirstOrDefault(item => item.MaLinhKien == donHangItem.MaLinhKien);
                if (existingItem != null) existingItem.SoLuong++;
                else donHangItems.Add(donHangItem);

                UpdateDataGridView();
            }
        }

        private void UpdateDataGridView()
        {
            dgv_DonHang.Rows.Clear();

            // Thêm từng item vào DataGridView
            foreach (var item in donHangItems)
            {
                dgv_DonHang.Rows.Add(item.MaLinhKien, item.TenLinhKien, item.GiaBan.ToString("N0") + " VND", item.SoLuong);
            }

            // Tính tổng giá trị của các mặt hàng trong giỏ hàng
            decimal total = donHangItems.Sum(item => item.GiaBan * item.SoLuong);
            decimal discount = 0;
            if (lblDiscount.Text != "-0VND")
            {
                string discountText = lblDiscount.Text.Replace("VND", "").Replace("-", "");
                discount = decimal.Parse(discountText);
            }

            lblTotal.Text = total.ToString("N0") + " VND";
            lblDiscount.Text = "-" + discount.ToString("N0") + " VND";
            lblAmountPaid.Text = (total - discount).ToString("N0") + " VND";
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime ngayDatHang = DateTime.Now;
                int maKhachHang = -1;
                int maGiamGia = -1;
                if (!string.IsNullOrEmpty(txtMaGiamGia.Text) && lblDiscount.Text != "-0VND")
                {
                    maGiamGia = int.Parse(txtMaGiamGia.Text);
                }
                if (int.TryParse(lblMaKH.Text, out int IntmaKhachHang))
                {
                    maKhachHang = IntmaKhachHang;
                }

                string phuongThuc = rbTienMat.Checked ? rbTienMat.Text : rbChuyenKhoan.Text;
                string amountText = lblAmountPaid.Text.Replace("VND", "").Replace(",", "");
                decimal tongGiaTri = Convert.ToDecimal(amountText);

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@NgayDatHang", ngayDatHang),
                    new SqlParameter("@MaKhachHang", maKhachHang == -1 ? (object)DBNull.Value : lblMaKH.Text),
                    new SqlParameter("@MaNhanVien", maNhanVien),
                    new SqlParameter("@MaGiamGia", maGiamGia == -1 ? (object)DBNull.Value : maGiamGia),
                    new SqlParameter("@TongGiaTri", tongGiaTri),
                    new SqlParameter("@PhuongThuc", phuongThuc)
                };

                object result = provider.ExecuteScalar(CommandType.StoredProcedure, "sp_ThemDonHang", parameters);
                if (result == null || result == DBNull.Value)
                {
                    MessageBox.Show("Đơn hàng không được để trống!");
                    return;
                }
                int maDonHang = (int)result;

                if (maDonHang > 0)
                {
                    foreach (var item in donHangItems)
                    {
                        SqlParameter[] parameters2 = new SqlParameter[]
                        {
                            new SqlParameter("@MaDonHang", maDonHang),
                            new SqlParameter("@MaLinhKien", item.MaLinhKien),
                            new SqlParameter("@SoLuong", item.SoLuong),
                            new SqlParameter("@GiaBan", item.GiaBan)
                        };
                        provider.ExecuteNonQuery(CommandType.StoredProcedure, "sp_ThemChiTietDonHang", parameters2);
                    }

                    MessageBox.Show("Đơn hàng đã được thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    donHangItems.Clear();
                    UpdateDataGridView();
                    lblDiscount.Text = "-0VND";
                    txtTimKhachHang.Text = string.Empty;
                    txtMaGiamGia.Text = string.Empty;
                    TabPage allTab = tabControl1.TabPages[tabControl1.TabPages.Count - 1];
                    DisplayLinhKien(null, allTab);
                }
                else
                {
                    MessageBox.Show("Thêm đơn hàng thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    

        private void btnKiemTraKhuyenMai_Click(object sender, EventArgs e)
        {
            try
            {
                int maGiamGia;
                if (int.TryParse(txtMaGiamGia.Text, out maGiamGia))
                {
                    string result = (string)provider.ExecuteScalar(CommandType.Text, "SELECT dbo.fn_CheckGiamGiaHopLe(@MaGiamGia)", 
                            new SqlParameter[] { new SqlParameter("@MaGiamGia", maGiamGia) });
                    MessageBox.Show(result, "Kết quả kiểm tra", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (result.Trim().Equals("Mã giảm giá hợp lệ"))
                    {
                        decimal giaTriDonHang;
                        if (decimal.TryParse(lblTotal.Text.Replace(" VND", "").Trim(), out giaTriDonHang))
                        {
                            SqlParameter[] parameters2 = new SqlParameter[]
                            {
                                new SqlParameter("@GiaTriDonHang", giaTriDonHang),
                                new SqlParameter("@MaGiamGia", maGiamGia)
                            };

                            decimal finalPrice = (decimal)provider.ExecuteScalar(CommandType.Text, "SELECT dbo.fn_CalculateFinalPrice(@GiaTriDonHang, @MaGiamGia)", parameters2);
                            lblDiscount.Text = "-" + (giaTriDonHang - finalPrice).ToString("N0") + " VND";
                            lblAmountPaid.Text = finalPrice.ToString("N0") + " VND";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKiemTraKhachHang_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable rows = provider.ExecuteReader(CommandType.StoredProcedure, "sp_TimKiemKhachHang", new SqlParameter[] {
                        new SqlParameter("@SearchOption", "SDT"),
                        new SqlParameter("@SearchText", txtTimKhachHang.Text)
                });

                if (rows.Rows.Count > 0)
                {
                    lblTenKhachHang.Text = rows.Rows[0]["TenKhachHang"].ToString();
                    lblSDT.Text = rows.Rows[0]["SDT"].ToString();
                    lblMaKH.Text = rows.Rows[0]["MaKhachHang"].ToString();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng! Vui lòng thêm mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fKhachHang fKhachHang = new fKhachHang();
                    fKhachHang.Show();
                    lblTenKhachHang.Text = "-";
                    lblSDT.Text = "-";
                    lblMaKH.Text = "-";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Khi thay đổi số lượng linh kiện
        private void dgv_DonHang_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgv_DonHang.Rows.Count ||
                    e.ColumnIndex < 0 || e.ColumnIndex >= dgv_DonHang.Columns.Count)
            {
                return; 
            }


            if (e.ColumnIndex == 3)
            {
                int maLinhKien = Convert.ToInt32(dgv_DonHang.Rows[e.RowIndex].Cells[0].Value);
                var item = donHangItems.FirstOrDefault(d => d.MaLinhKien == maLinhKien);

                if (item != null)
                {
                    item.SoLuong = Convert.ToInt32(dgv_DonHang.Rows[e.RowIndex].Cells[3].Value);
                }
            }
            UpdateDataGridView();
        }

        // Khi xóa linh kiện
        private void dgv_DonHang_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            int maLinhKien = Convert.ToInt32(e.Row.Cells[0].Value);
            var itemToRemove = donHangItems.FirstOrDefault(d => d.MaLinhKien == maLinhKien);

            if (itemToRemove != null)
            {
                donHangItems.Remove(itemToRemove);
            }
            UpdateDataGridView();
        }

        // Tìm linh kiện theo từ khóa
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            TabPage allTab = tabControl1.TabPages[tabControl1.TabPages.Count - 1];
            tabControl1.SelectedTab = allTab;
            FlowLayoutPanel flowLayoutPanel = (FlowLayoutPanel)tabControl1.SelectedTab.Controls[0];
            flowLayoutPanel.Controls.Clear();
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                DisplayLinhKien(null, allTab);
                return;
            }

            DataTable linhKienSearch = provider.ExecuteReader(CommandType.StoredProcedure, "sp_TimKiemLinhKienTheoTuKhoa",
                new SqlParameter[] { new SqlParameter("@TuKhoa", txtSearch.Text) });

            foreach (DataRow row in linhKienSearch.Rows)
            {
                LinhKienUC linhKienUC = new LinhKienUC((int)row["MaLinhKien"], row["TenLinhKien"].ToString(), row["MoTaChiTiet"].ToString(),
                    (decimal)row["GiaBan"], (decimal)row["GiaNhap"], (int)row["SoLuongTonKho"], (Image)ImageHelper.GetImageFromResources(row["HinhAnh"].ToString()));
                linhKienUC.LinhKienClicked += LinhKienUC_Clicked;
                flowLayoutPanel.Controls.Add(linhKienUC);
            }
        }


    }
    public class DonHangItem
    {
        public int MaLinhKien { get; set; }
        public string TenLinhKien { get; set; }
        public decimal GiaBan { get; set; }
        public int SoLuong { get; set; }
    }
    public static class ImageHelper
    {
        public static Image GetImageFromResources(string imageName)
        {
            // Lùi lên 2 cấp từ thư mục thực thi hiện tại để đến thư mục gốc của project
            string projectPath = Directory.GetParent(Application.StartupPath).Parent.FullName;
            string resourcesPath = Path.Combine(projectPath, "Resources");
            string imagePath = Path.Combine(resourcesPath, imageName);

            // Kiểm tra xem file có tồn tại không
            if (File.Exists(imagePath))
            {
                return Image.FromFile(imagePath);
            }
            else
            {
                throw new ArgumentException($"Hình ảnh '{imageName}' không tìm thấy trong thư mục resources.");
            }

        }
    }
}
