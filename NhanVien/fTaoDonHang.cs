using ProCuaHangLinhKienLaptop.DB;
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

namespace ProCuaHangLinhKienLaptop.NhanVien
{
    public partial class fTaoDonHang : Form
    {
        DataProvider provider = new DataProvider();
        private List<DonHangItem> donHangItems = new List<DonHangItem>();

        public fTaoDonHang()
        {
            InitializeComponent();
        }

        private void fTaoDonHang_Load(object sender, EventArgs e)
        {
            LoadLoaiLinhKien();
            dgv_DonHang.Columns.Add("MaLinhKien", "Mã Linh Kiện");
            dgv_DonHang.Columns.Add("TenLinhKien", "Tên Linh Kiện");
            dgv_DonHang.Columns.Add("GiaBan", "Giá Bán");
            dgv_DonHang.Columns.Add("SoLuong", "Số Lượng");
        }

        private void LoadLoaiLinhKien()
        {
            DataTable loaiLinhKienTable = provider.ExecuteReader( CommandType.Text, "SELECT * FROM vw_ThongTinLoaiLinhKien");

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

            DataTable linhKienTable = provider.ExecuteReader(CommandType.Text, cmdText,  parameters);

            foreach (DataRow row in linhKienTable.Rows)
            {
                LinhKienUC linhKienUC = new LinhKienUC((int)row["MaLinhKien"], row["TenLinhKien"].ToString(), (decimal)row["GiaBan"]);
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
            foreach (var item in donHangItems)
            {
                dgv_DonHang.Rows.Add(item.MaLinhKien, item.TenLinhKien, item.GiaBan.ToString("N0") + " VND", item.SoLuong);
            }
            decimal total = donHangItems.Sum(item => item.GiaBan * item.SoLuong);
            lblTotal.Text = total.ToString("N0") + " VND";
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime ngayDatHang = DateTime.Now; 
                int maKhachHang = 1; 
                int maNhanVien = 1;
                int maGiamGia = 1; 
                decimal tongGiaTri = donHangItems.Sum(item => item.GiaBan * item.SoLuong); 
                string phuongThuc = "Cash"; 

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@NgayDatHang", ngayDatHang),
                    new SqlParameter("@MaKhachHang", maKhachHang),
                    new SqlParameter("@MaNhanVien", maNhanVien),
                    new SqlParameter("@MaGiamGia", maGiamGia),
                    new SqlParameter("@TongGiaTri", tongGiaTri),
                    new SqlParameter("@PhuongThuc", phuongThuc)
                };

                int rowsAffected = provider.ExecuteNonQuery(CommandType.StoredProcedure, "sp_ThemDonHang", parameters);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Đơn hàng đã được thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    donHangItems.Clear(); 
                    UpdateDataGridView(); 
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
    }
    public class DonHangItem
    {
        public int MaLinhKien { get; set; }
        public string TenLinhKien { get; set; }
        public decimal GiaBan { get; set; }
        public int SoLuong { get; set; }
    }

}
