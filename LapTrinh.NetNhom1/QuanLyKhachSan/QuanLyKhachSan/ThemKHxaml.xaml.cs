using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QuanLyKhachSan
{
    /// <summary>
    /// Interaction logic for ThemKHxaml.xaml
    /// </summary>
    public partial class ThemKHxaml : Window
    {
        public ThemKHxaml()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        QuanLyKhachSanEntities db = new QuanLyKhachSanEntities();
        private void Bt_themKH_Click(object sender, RoutedEventArgs e)
        {
            bool? gt = null;
            if (rdb_nam.IsChecked == true)
                gt = true;
            else if (rdb_nu.IsChecked == true)
                gt = false;
            KhachHang kh = new KhachHang {
                MaKH = txtMaKH.Text.Trim(),
                TenKH_ = txtHoTen.Text.Trim(),
                SoDienThoai = txtSoDienThoai.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim(),
                GioiTinh = gt,
            };
            db.KhachHang.Add(kh);
            db.SaveChanges();
            MessageBox.Show("Thêm thành công");
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
