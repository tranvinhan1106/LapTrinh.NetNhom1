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
using System.Data.Entity;

namespace QuanLyKhachSan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        QuanLyKhachSanEntities1 db = new QuanLyKhachSanEntities1();

        public MainWindow()
        {
            InitializeComponent();
            LoadNhanVien();
        }

        private void Btn_them_Click(object sender, RoutedEventArgs e)
        {
            Them them = new Them(this);
            them.ShowDialog();
            this.Close();
        }

        private void Btn_qlnv_Click(object sender, RoutedEventArgs e)
        {
            gbNhanVien.Visibility = Visibility.Visible;
            gbKhachHang.Visibility = Visibility.Collapsed;
            gbPhong.Visibility = Visibility.Collapsed;
            gbThongKe.Visibility = Visibility.Collapsed;
            LoadNhanVien();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            gbNhanVien.Visibility = Visibility.Collapsed;
            gbKhachHang.Visibility = Visibility.Visible;
            gbPhong.Visibility = Visibility.Collapsed;
            gbThongKe.Visibility = Visibility.Collapsed;
            loadlkh();
        }

        private void Btn_qlp_Click(object sender, RoutedEventArgs e)
        {
            gbNhanVien.Visibility = Visibility.Collapsed;
            gbKhachHang.Visibility = Visibility.Collapsed;
            gbPhong.Visibility = Visibility.Visible;
            gbThongKe.Visibility = Visibility.Collapsed;
            loadPhong();

        }

        public void LoadNhanVien()
        {
            dg_QLNhanVien.ItemsSource = db.NhanViens.ToList();
        }

        private void Btn_qltk_Click(object sender, RoutedEventArgs e)
        {
            gbNhanVien.Visibility = Visibility.Collapsed;
            gbKhachHang.Visibility = Visibility.Collapsed;
            gbPhong.Visibility = Visibility.Collapsed;
            gbThongKe.Visibility = Visibility.Visible;
            countkhach();
            countphongtrong();
            countphongdadat();
            tongdoanhthu();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            gbPhong.Visibility = Visibility.Visible;
            gbChiTietPhong.Visibility = Visibility.Collapsed;
            loadPhong();
        }

        private void Btn_sua_Click(object sender, RoutedEventArgs e)
        {
            NhanVien suanv = dg_QLNhanVien.SelectedItem as NhanVien;
            if (suanv == null)
            {
                MessageBox.Show("Chọn nhân viên để sửa  !");
            }
            else
            {
                Sua sua = new Sua(suanv);
                sua.Show();
                this.Hide();
            }

        }

        private void Btn_themKH_Click(object sender, RoutedEventArgs e)
        {
            ThemKHxaml them = new ThemKHxaml();
            them.Show();
            this.Hide();
        }

        private void Btn_suaKH_Click(object sender, RoutedEventArgs e)
        {
            KhachHang suakh = dtg_kh.SelectedItem as KhachHang;
            if (suakh == null)
            {
                MessageBox.Show("Chọn khách hàng để sửa  !");
            }
            else
            {
                SuaKH sua = new SuaKH(suakh);
                sua.Show();
                this.Hide();
            }
        }

        private void loadlkh()
        {
            dtg_kh.ItemsSource = db.KhachHangs.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            gbPhong.Visibility = Visibility.Collapsed;
            gbChiTietPhong.Visibility = Visibility.Visible;
        }

        private void Bt_xoa_Click(object sender, RoutedEventArgs e)
        {
            KhachHang xoakh = dtg_kh.SelectedItem as KhachHang;
            if (xoakh == null)
            {
                MessageBox.Show("Hãy chọn khách hàng để xóa !");
                return;
            }
            bool dangThuePhong = db.Thues.Any(t => t.MaKH == xoakh.MaKH);
            if (dangThuePhong)
            {
                MessageBox.Show("Không thể xóa! Khách hàng đang thuê phòng.");
                return;
            }
            KhachHang kh = db.KhachHangs.Find(xoakh.MaKH);
            if (kh != null)
            {
                db.KhachHangs.Remove(kh);
                db.SaveChanges();
                MessageBox.Show("Xóa thành công");
                loadlkh();
            }
        }

        private void Btn_xoa_Click(object sender, RoutedEventArgs e)
        {
            NhanVien xoaNv = dg_QLNhanVien.SelectedItem as NhanVien;

            if (xoaNv == null)
            {
                MessageBox.Show("Hãy chọn nhân viên để xóa !");
                return;
            }
            bool dangQuanLyPhong = db.Phongs.Any(p => p.MaNV == xoaNv.MaNV);
            if (dangQuanLyPhong)
            {
                MessageBox.Show("Không thể xóa! Nhân viên đang quản lý phòng.");
                return;
            }
            NhanVien nv = db.NhanViens.Find(xoaNv.MaNV);
            if (nv != null)
            {
                db.NhanViens.Remove(nv);
                db.SaveChanges();
                MessageBox.Show("Xóa thành công");
                LoadNhanVien();
            }
            else
            {
                MessageBox.Show("Không tìm thấy nhân viên trong cơ sở dữ liệu.");
            }
        }

        private void timkiem(object sender, RoutedEventArgs e)
        {
            string tuKhoa = tb_timkiem.Text.Trim();

            if (string.IsNullOrEmpty(tuKhoa))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.");
                LoadNhanVien();
                return;
            }

            var ketQua = db.NhanViens
                           .Where(nv => nv.TenNV.Contains(tuKhoa))
                           .ToList();

            dg_QLNhanVien.ItemsSource = ketQua;

            if (ketQua.Count == 0)
            {
                MessageBox.Show("Không tìm thấy nhân viên nào.");
            }

        }

        private void timkiemkh(object sender, RoutedEventArgs e)
        {
            string tuKhoa = tb_timkiemkh.Text.Trim();

            if (string.IsNullOrEmpty(tuKhoa))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.");
                loadlkh();
                return;
            }

            var ketQua = db.KhachHangs
                           .Where(nv => nv.TenKH_.Contains(tuKhoa))
                           .ToList();

            dg_QLNhanVien.ItemsSource = ketQua;

            if (ketQua.Count == 0)
            {
                MessageBox.Show("Không tìm thấy khách hàng nào.");
            }

        }

        private void loadPhong()
        {
            icPhong.ItemsSource = db.Phongs.Include(p => p.DichVu).ToList();
        }

        private void Button_ChiTiet_Click(object sender, RoutedEventArgs e)
        {
            gbPhong.Visibility = Visibility.Collapsed;
            Button btn = sender as Button;
            string maPhong = btn.Tag.ToString();

            var phong = db.Phongs.Include(p => p.DichVu).FirstOrDefault(p => p.MaPhong == maPhong);

            if (phong != null)
            {
                tb_maphong.Text = phong.MaPhong;
                tb_sophong.Text = phong.SoPhong;
                tb_dichvu.Text = phong.DichVu?.TenDV ?? "Không có dịch vụ";
                tb_trangthai.Text = phong.TrangThai;
                tb_gia.Text = phong.Gia.ToString("N0") + " VNĐ";

                gbChiTietPhong.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Không tìm thấy phòng!");
            }
        }

        private void countkhach()
        {
            int count = db.KhachHangs.Count();
            txtTongKhach.Text = count.ToString();
        }
        private void countphongtrong()
        {
            int count = db.Phongs.Count(p => p.TrangThai == "Trống");
            txtPhongTrong.Text = count.ToString();
        }
        private void countphongdadat()
        {
            int count = db.Phongs.Count(p => p.TrangThai == "Đã đặt");
            txtPhongThue.Text = count.ToString();
        }
        private void tongdoanhthu()
        {
            double tong = db.Phongs
                            .Where(p => p.TrangThai == "Đã trả")
                            .Sum(p => p.Gia);

            txtDoanhThu.Text = tong.ToString("N0") + " VNĐ";
        }
    }
}
