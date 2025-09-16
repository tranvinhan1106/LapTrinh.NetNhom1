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
    /// Interaction logic for dangnhap.xaml
    /// </summary>
    public partial class dangnhap : Window
    {
        public dangnhap()
        {
            InitializeComponent();
        }

        private void Bt_dn(object sender, RoutedEventArgs e)
        {
            if(txt_dn.Text== "Admin" && txt_pass.Password== "123")
            {
                MainWindow main = new MainWindow();
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Ten dang nhap hoac mat khau khong dung");
            }
        }

        private void Cb_ht_Click(object sender, RoutedEventArgs e)
        {
            if (cb_ht.IsChecked == true)
            {
                txt_show.Text = txt_pass.Password;
                txt_show.Visibility = Visibility.Visible;
                txt_pass.Visibility = Visibility.Collapsed;
            }
            else
            {
                txt_pass.Password = txt_show.Text;
                txt_pass.Visibility = Visibility.Visible;
                txt_show.Visibility = Visibility.Collapsed;
            }
        }
    }
}
