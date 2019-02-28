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

namespace QuanLyNhanSu
{
    /// <summary>
    /// Interaction logic for Manhinhchinh.xaml
    /// </summary>
    public partial class Manhinhchinh : Window
    {
        private string tendangnhap;
        public string taikhoan
        {
            get { return tendangnhap; }
            set { tendangnhap = value; }
        }
        public Manhinhchinh()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(layloaitaikhoan());
            laytenhienthi();
            if(layloaitaikhoan()=="1")
            {
                Quanlytaikhoan.Visibility = Visibility.Visible;
            }
            else
            {               
                Quanlytaikhoan.Visibility = Visibility.Collapsed;                
            }
        }

        QLNSDataContext data = new QLNSDataContext();
        #region nút nhấn
        private void btnHoso_Click(object sender, RoutedEventArgs e)
        {
            WindowHoso hs = new WindowHoso();
            hs.ShowDialog();
        }

        private void btnChucvu_Click(object sender, RoutedEventArgs e)
        {
            WindowChucvu cv = new WindowChucvu();
            cv.ShowDialog();
        }

        private void btnHopdong_Click(object sender, RoutedEventArgs e)
        {
            WindowHopdong hd = new WindowHopdong();
            hd.ShowDialog();
        }

        private void btnTrinhdo_Click(object sender, RoutedEventArgs e)
        {
            WindowTrinhdo td = new WindowTrinhdo();
            td.ShowDialog();
        }

        private void btnPhong_Click(object sender, RoutedEventArgs e)
        {
            WindowPhong p = new WindowPhong();
            p.ShowDialog();
        }

        private void btnLuong_Click(object sender, RoutedEventArgs e)
        {
            WindowLuong l = new WindowLuong();
            l.ShowDialog();
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion
        #region itemPreviewMouseDown
        private void DoimatkhauItem_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowTaikhoan tk = new WindowTaikhoan();
            tk.taikhoan = tendangnhap;
            tk.ShowDialog();
        }

        private void DangxuatItem_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            tendangnhap = "";
            WindowDangnhap dn = new WindowDangnhap();
            dn.Show();
            this.Close();
        }
        
        private void ThongkeItem_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowThongke tk = new WindowThongke();
            tk.ShowDialog();
        }

        private void QuanlyluongItem_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowLuong lg = new WindowLuong();
            lg.ShowDialog();
        }

        private void QuanlyhosoItem_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowHoso hs = new WindowHoso();
            hs.ShowDialog();
        }

        private void Quanlytaikhoan_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowTaikhoans tks = new WindowTaikhoans();
            tks.ShowDialog();
        }
        #endregion

        private void laytenhienthi()
        {
            var q = (from p in data.tblTaikhoans
                     where p.Tendangnhap == tendangnhap
                     select p).FirstOrDefault();
            string tenhienthi = q.Tenhienthi;
            txtTenhienthi.Text = tenhienthi;
        }

        private string layloaitaikhoan()
        {
            var q = (from p in data.tblTaikhoans
                     where p.Tendangnhap == tendangnhap
                     select p).FirstOrDefault();
            string loaitk = q.Maloai;
            return loaitk;
        }
        
        
    }
}
