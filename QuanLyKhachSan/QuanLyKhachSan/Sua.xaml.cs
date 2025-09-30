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
    /// Interaction logic for Sua.xaml
    /// </summary>
    public partial class Sua : Window
    {
        private NhanVien nvchon;
        public Sua(NhanVien nv)
        {
            InitializeComponent();
            nvchon = nv;

            txtMaNV.Text = nv.MaNV;
            txtHoTen.Text = nv.TenNV;
            txtDiaChi.Text = nv.DiaChi;
            txtSoDienThoai.Text = nv.SoDienThoai;
            txtEmail.Text = nv.Email;
            txtHinhThuc.Text = nv.HinhThuc;
            txtBoPhan.Text = nv.BoPhan;
            rdb_nam.IsChecked = nv.GioiTinh == true;
            rdb_nu.IsChecked = nv.GioiTinh == false;
        }

        QuanLyKhachSanEntities1 db = new QuanLyKhachSanEntities1();


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void SuaNV(object sender, RoutedEventArgs e)
        {
            NhanVien nvsua = db.NhanViens.Find(nvchon.MaNV);

            nvsua.TenNV = txtHoTen.Text;
            nvsua.DiaChi = txtDiaChi.Text;
            nvsua.SoDienThoai = txtSoDienThoai.Text;
            nvsua.Email = txtEmail.Text;
            nvsua.HinhThuc = txtHinhThuc.Text;
            nvsua.BoPhan = txtBoPhan.Text;
            if (rdb_nam.IsChecked == true)
            {
                nvsua.GioiTinh = true;
            }
            else if (rdb_nu.IsChecked == true)
            {
                nvsua.GioiTinh = false;
            }
            db.SaveChanges();
            MessageBox.Show("Đã sửa thông tin khách hàng!");
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
