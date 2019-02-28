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
    /// Interaction logic for WindowDangnhap.xaml
    /// </summary>
    public partial class WindowDangnhap : Window
    {
        public WindowDangnhap()
        {
            InitializeComponent();
        }

        QLNSDataContext data = new QLNSDataContext();


        private void btnDangnhap_Click(object sender, RoutedEventArgs e)
        {
            Dangnhap();
        }
        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Dangnhap()
        {
            if (tbxTendangnhap.Text.Length == 0 && tbxMatkhau.Password.Length == 0 )
            {
                MessageBox.Show("Xin lỗi! Bạn phải nhập thông tin đăng nhập vào", "Thông báo!");
            }
            else if (tbxTendangnhap.Text.Length == 0 )
            {
                MessageBox.Show("Xin lỗi! Bạn phải nhập Tên đăng nhập vào", "Thông báo!");
            }
            else if (tbxMatkhau.Password.Length == 0)
            {
                MessageBox.Show("Xin lỗi! Bạn phải nhập Mật khẩu vào", "Thông báo!");
            }
            else if (kiemtra(tbxTendangnhap.Text,tbxMatkhau.Password))
            {                
                Manhinhchinh main = new Manhinhchinh();
                main.taikhoan = tbxTendangnhap.Text;
                main.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đúng Tài khoản và Mật khẩu!", "Thông báo!");
            }
        }
        private bool kiemtra(string tendangnhap, string matkhau)
        {
            try
            {
                var q = from p in data.tblTaikhoans
                        where p.Tendangnhap == tbxTendangnhap.Text
                        && p.Matkhau == tbxMatkhau.Password
                        select p;
                if (q.Any())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi CSDL!"+ex.Message,"Thông báo!",MessageBoxButton.OK,MessageBoxImage.Warning);
                return false;
            }
        }

        
    }
}
