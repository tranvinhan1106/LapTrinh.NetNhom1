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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuanLyKhachSan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_them_Click(object sender, RoutedEventArgs e)
        {
            Them them = new Them();
            them.Show();
            this.Hide();
        }

        private void Btn_qlnv_Click(object sender, RoutedEventArgs e)
        {
            gbNhanVien.Visibility = Visibility.Visible;
            gbKhachHang.Visibility = Visibility.Collapsed;
            gbPhong.Visibility = Visibility.Collapsed;
            gbThongKe.Visibility = Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            gbNhanVien.Visibility = Visibility.Collapsed;
            gbKhachHang.Visibility = Visibility.Visible;
            gbPhong.Visibility = Visibility.Collapsed;
            gbThongKe.Visibility = Visibility.Collapsed;
        }

        private void Btn_qlp_Click(object sender, RoutedEventArgs e)
        {
            gbNhanVien.Visibility = Visibility.Collapsed;
            gbKhachHang.Visibility = Visibility.Collapsed;
            gbPhong.Visibility = Visibility.Visible;
            gbThongKe.Visibility = Visibility.Collapsed;
        }

        private void Btn_qltk_Click(object sender, RoutedEventArgs e)
        {
            gbNhanVien.Visibility = Visibility.Collapsed;
            gbKhachHang.Visibility = Visibility.Collapsed;
            gbPhong.Visibility = Visibility.Collapsed;
            gbThongKe.Visibility = Visibility.Visible;
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            gbPhong.Visibility = Visibility.Visible;
            gbChiTietPhong.Visibility = Visibility.Collapsed;
        }

        private void Btn_sua_Click(object sender, RoutedEventArgs e)
        {
            Sua sua = new Sua();
            sua.Show();
            this.Hide();
        }

        private void Btn_themKH_Click(object sender, RoutedEventArgs e)
        {
            ThemKHxaml them = new ThemKHxaml();
            them.Show();
            this.Hide();
        }

        private void Btn_suaKH_Click(object sender, RoutedEventArgs e)
        {
            SuaKH suaKH = new SuaKH();
            suaKH.Show();
            this.Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            gbPhong.Visibility = Visibility.Collapsed;
            gbChiTietPhong.Visibility = Visibility.Visible;
        }
    }
}
