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

namespace ProCuaHangLinhKienLaptop
{
    public partial class fTaoDonHang : Form
    {
        public fTaoDonHang()
        {
            InitializeComponent();
        }
        private void fTaoDonHang_Load(object sender, EventArgs e)
        {
            LoadLoaiLinhKien();
        }

        private void LoadLoaiLinhKien()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C8B20IS;Initial Catalog=LinhkienLaptop;Integrated Security=True"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM LoaiLinhKien", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string tenLoai = reader["TenLoaiLinhKien"].ToString();
                    int maLoai = (int)reader["MaLoaiLinhKien"];

                    TabPage tabPage = new TabPage(tenLoai);
                    tabPage.Tag = maLoai;
                    FlowLayoutPanel flowLayoutPanelTemp = new FlowLayoutPanel
                    {
                        Dock = DockStyle.Fill,
                        AutoScroll = true
                    };

                    tabPage.Controls.Add(flowLayoutPanelTemp);
                    tabControl1.TabPages.Add(tabPage);
                }
                FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    AutoScroll = true
                };
                TabPage allPage = new TabPage("All");
                allPage.Controls.Add(flowLayoutPanel);
                tabControl1.TabPages.Add(allPage);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage selectedTab = tabControl1.SelectedTab;

            if (selectedTab != null)
            {
                int? maLoaiLinhKien = selectedTab.Tag as int?;
                MessageBox.Show(maLoaiLinhKien.ToString(), selectedTab.Text);
                DisplayLinhKien(maLoaiLinhKien, selectedTab);
            }
        }
        private void DisplayLinhKien(int? maLoaiLinhKien = null, TabPage selectedTab = null)
        {
            TabPage targetTabPage = selectedTab;
            /*foreach (TabPage tab in tabControl1.TabPages)
            {
                if (maLoaiLinhKien == null || (int)tab.Tag == maLoaiLinhKien)
                {
                    targetTabPage = tab;
                    break;
                }
            }*/
            FlowLayoutPanel flowLayoutPanel = (FlowLayoutPanel)targetTabPage.Controls[0]; // Giả định FlowLayoutPanel luôn ở chỉ số 0
            flowLayoutPanel.Controls.Clear();

            using (SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=LinhkienLaptop;Integrated Security=True"))
            {
                conn.Open();
                SqlCommand cmd = maLoaiLinhKien == null
                    ? new SqlCommand("SELECT * FROM LinhKien", conn)
                    : new SqlCommand("SELECT * FROM LinhKien WHERE MaLoaiLinhKien = @MaLoai", conn);

                if (maLoaiLinhKien != null)
                    cmd.Parameters.AddWithValue("@MaLoai", maLoaiLinhKien);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    LinhKienUC userControl = new LinhKienUC((int)reader["MaLinhKien"], reader["TenLinhKien"].ToString(), (decimal)reader["GiaBan"]);
                    userControl.Height = 100; // Cài đặt chiều cao cho UserControl
                    flowLayoutPanel.Controls.Add(userControl);
                }
            }

            tabControl1.SelectedTab = targetTabPage;
        }

    }
}
