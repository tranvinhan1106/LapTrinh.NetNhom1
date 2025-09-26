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
       
        public SuaKH(KhachHang khach)
        {
            InitializeComponent();
            kh = khach;
            
            txtMaKH.Text = kh.MaKH;
            txtHoTen.Text = kh.TenKH_;
            txtSoDienThoai.Text = kh.SoDienThoai;
            txtEmail.Text = kh.Email;
            txtDiaChi.Text = kh.DiaChi;
            if (kh.GioiTinh == true)
            {
                rb_nam.IsChecked = true;
            }
            else
            {
                rb_nu.IsChecked = true;
            }           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
        QuanLyKhachSanEntities db = new QuanLyKhachSanEntities();
        private void Button_suakh(object sender, RoutedEventArgs e)
        {
            KhachHang suakh = db.KhachHang.Find(kh.MaKH);      
            suakh.MaKH = txtMaKH.Text;
            suakh.TenKH_ = txtHoTen.Text;
            suakh.SoDienThoai = txtSoDienThoai.Text;
            suakh.Email = txtEmail.Text ;
            suakh.DiaChi = txtDiaChi.Text ;
            if (suakh.GioiTinh == true)
            {
                rb_nam.IsChecked = true;
            }
            else
            {
                rb_nu.IsChecked = true;
            }
            db.SaveChanges();
            MessageBox.Show("Đã sửa thông tin khách hàng!");
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    
    }
}
