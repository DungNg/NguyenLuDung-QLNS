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
    /// Interaction logic for WindowTaikhoan.xaml
    /// </summary>
    public partial class WindowTaikhoan : Window
    {
        QLNSDataContext data = new QLNSDataContext();
        private string tendangnhap;
        public string taikhoan
        {
            get { return tendangnhap; }
            set { tendangnhap = value; }
        }
        public WindowTaikhoan()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {            
            //MessageBox.Show(tendangnhap);
        }

        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            if(Check())
            {
                if (tbxMatkhaumoi.Password == "")
                {
                    MessageBox.Show("Vui lòng điền mật khẩu mới!", "Thông báo!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
                else
                {
                    if(tbxNhaplaimatkhau.Password=="")
                    {
                        MessageBox.Show("Nhập lại mật khẩu mới!", "Thông báo!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    }
                    else
                    {
                        if (tbxMatkhaumoi.Password != tbxNhaplaimatkhau.Password)
                        {
                            MessageBox.Show("Mật khẩu không khớp!", "Thông báo!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        }
                        else
                        {
                            try
                            {
                                Sua();
                                MessageBox.Show("Đổi thành công!", "Thông báo!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Lỗi CSDL!", "Thông báo!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                            }
                        }
                    }                  
                }
            }
            else
            {
                MessageBox.Show(txtTendangnhap.Text, "Thông báo!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }       
        }

        private void Sua()
        {
            tblTaikhoan tk = (tblTaikhoan)data.tblTaikhoans.Single(p => p.Tendangnhap == tendangnhap);
            tk.Matkhau = tbxMatkhaumoi.Password;
            data.SubmitChanges();
        }

        private bool Check()
        {
            var q = from p in data.tblTaikhoans
                    where p.Matkhau == tbxMatkhaucu.Password && p.Tendangnhap == tendangnhap
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
    }
}
