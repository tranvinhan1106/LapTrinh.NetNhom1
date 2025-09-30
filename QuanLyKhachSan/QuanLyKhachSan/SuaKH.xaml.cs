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
    /// Interaction logic for SuaKH.xaml
    /// </summary>
    public partial class SuaKH : Window
    {
        private KhachHang kh;

        QuanLyKhachSanEntities1 db = new QuanLyKhachSanEntities1();

        public SuaKH(KhachHang khach)
        {
            InitializeComponent();
            kh = khach;

            txtMaKH.Text = kh.MaKH;
            txtHoTen.Text = kh.TenKH_;
            txtSoDienThoai.Text = kh.SoDienThoai;
            txtEmail.Text = kh.Email;
            txtDiaChi.Text = kh.DiaChi;

            rb_nam.IsChecked = kh.GioiTinh == true;
            rb_nu.IsChecked = kh.GioiTinh == false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Button_suakh(object sender, RoutedEventArgs e)
        {
            KhachHang suakh = db.KhachHangs.Find(kh.MaKH);
            suakh.TenKH_ = txtHoTen.Text;
            suakh.SoDienThoai = txtSoDienThoai.Text;
            suakh.Email = txtEmail.Text;
            suakh.DiaChi = txtDiaChi.Text;
            if (rb_nam.IsChecked == true)
            {
                suakh.GioiTinh = true;
            }
            else if (rb_nu.IsChecked == true)
            {
                suakh.GioiTinh = false;
            }
            db.SaveChanges();
            MessageBox.Show("Đã sửa thông tin khách hàng!");
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

    }
}
