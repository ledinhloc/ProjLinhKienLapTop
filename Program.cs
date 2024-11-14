using ProCuaHangLinhKienLaptop.NhanVien;
using ProCuaHangLinhKienLaptop.Quanly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProCuaHangLinhKienLaptop
{
    internal static class Program
    {
        //public static string Email { get; set; } = "nguyenvantam@company.com";
        //public static string MatKhau { get; set; } = "matkhau1";
        public static string Email { get; set; }
        public static string MatKhau { get; set; } 
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                SetProcessDPIAware();
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new fLogin());
            //Application.Run(new fAdmin());
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}
