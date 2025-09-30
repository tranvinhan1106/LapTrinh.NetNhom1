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
    /// Interaction logic for Them.xaml
    /// </summary>
    public partial class Them : Window
    {
        MainWindow themnv;
        public Them(MainWindow _themnv)
        {
            InitializeComponent();
            themnv = _themnv;
        }

        QuanLyKhachSanEntities1 db = new QuanLyKhachSanEntities1();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            bool? gt = null;
            if (rdb_nam.IsChecked == true)
                gt = true;
            else if (rdb_nu.IsChecked == true)
                gt = false;
            NhanVien nv = new NhanVien
            {
                MaNV = txtMaNV.Text.Trim(),
                TenNV = txtHoTen.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim(),
                SoDienThoai = txtSoDienThoai.Text.Trim(),
                HinhThuc = txtHinhThuc.Text.Trim(),
                BoPhan = txtBoPhan.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                GioiTinh = gt
            };

            db.NhanViens.Add(nv);
            db.SaveChanges();
            MessageBox.Show("Thêm nhân viên thành công!");
            themnv.LoadNhanVien();
            MainWindow main = new MainWindow();
            main.Show();
        }
        public void ClearBangNV()
        {
            txtMaNV.Clear();
            txtHoTen.Clear();
            txtSoDienThoai.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            txtHinhThuc.SelectedIndex = -1;
            txtBoPhan.SelectedIndex = -1;
            rdb_nam.IsChecked = false;
            rdb_nu.IsChecked = false;
        }
    }

}
