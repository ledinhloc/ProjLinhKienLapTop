using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProCuaHangLinhKienLaptop.Quanly
{
    public partial class DieuKienThuongUC : UserControl
    {
        private List<Item> itemList;
        public string TenDK
        {
            get
            {
                var selectedItem = cmbTenDK.SelectedItem as Item;
                return selectedItem?.TenFunction ?? string.Empty;
            }
        }
        public string SoSanh
        {
            get { return cmbSoSanh.SelectedItem?.ToString() ?? string.Empty; }
        }
        public decimal Nguong
        {
            get
            {
                return decimal.TryParse(txtNguong.Text, out decimal result) ? result : 0;
            }
        }
        public decimal Thuong
        {
            get
            {
                return decimal.TryParse(txtThuong.Text, out decimal result) ? result : 0;
            }
        }

        public DieuKienThuongUC()
        {
            InitializeComponent();
            itemList = new List<Item>
            {
                new Item { Ten = "Tổng đơn hàng", TenFunction = "fn_TongSoDonHang", ThamSo = "start, end" },
                new Item { Ten = "Doanh Thu", TenFunction = "fn_DoanhThu", ThamSo = "start, end" },
                new Item { Ten = "Chi phí", TenFunction = "fn_ChiPhi", ThamSo = "start, end" },
                new Item { Ten = "Tổng lợi nhuận", TenFunction = "fn_TongLoiNhuan", ThamSo = "start, end" },
                new Item { Ten = "Số ca làm", TenFunction = "fn_DemCaLam", ThamSo = "start, end, MaNhanVien" },
                new Item { Ten = "Số ca nghỉ", TenFunction = "fn_DemCaNghi", ThamSo = "start, end, MaNhanVien" },
            };

            cmbTenDK.DataSource = itemList;
            cmbTenDK.DisplayMember = "Ten";
            cmbSoSanh.SelectedIndex = 0;
        }
        public string LayThamSo(string tenFunction)
        {
            return itemList.FirstOrDefault(item => item.TenFunction == tenFunction)?.ThamSo ?? string.Empty;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
    public class Item
    {
        public string Ten { get; set; }
        public string ThamSo { get; set; }
        public string TenFunction { get; set; }
    }
}
