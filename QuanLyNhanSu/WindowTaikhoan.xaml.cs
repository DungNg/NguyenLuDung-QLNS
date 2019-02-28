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
    /// Interaction logic for WindowTaikhoans.xaml
    /// </summary>
    public partial class WindowTaikhoans : Window
    {
        QLNSDataContext data = new QLNSDataContext();
        public WindowTaikhoans()
        {
            InitializeComponent();
            GetData();
            GetMaloai();
        }       

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            if (tbxTendangnhap.Text=="" || tbxMatkhau.Text=="")
            {
                MessageBox.Show("Vui lòng điền tài khoản cần thêm!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                try
                {
                    if (!Check())
                    {
                        if (MessageBox.Show("Xác nhận thêm!", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
                        {
                            Them();
                            GetData();
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản đã tồn tại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Thêm thất bại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            if (tbxTendangnhap.Text == "" || tbxMatkhau.Text == "")
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xóa!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                try
                {
                    if (Check())
                    {
                        if (MessageBox.Show("Xác nhận xóa!", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
                        {
                            Xoa();
                            GetData();
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản không tồn tại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Xóa thất bại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            if (tbxTendangnhap.Text == "" || tbxMatkhau.Text == "")
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần sửa!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                try
                {
                    if (Check())
                    {
                        if (MessageBox.Show("Xác nhận sửa!", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
                        {
                            Sua();
                            GetData();
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản không tồn tại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Sửa thất bại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
        #region chức năng

        private void GetMaloai()
        {
            var q = from p in data.tblLoaitaikhoans
                    select p;
            tbxLoaitk.ItemsSource = q;
            tbxLoaitk.DisplayMemberPath = "Maloai";
            tbxLoaitk.SelectedValuePath = "Maloai";
        }

        private void GetData()
        {
            var q = from p in data.tblTaikhoans
                    select p;
            ListViewTaikhoan.ItemsSource = q;
        }

        private void Them()
        {
            tblTaikhoan tk = new tblTaikhoan();
            tk.Tendangnhap = tbxTendangnhap.Text;
            tk.Matkhau = tbxMatkhau.Text;
            tk.Tenhienthi = tbxTenhienthi.Text;
            tk.Maloai = tbxLoaitk.SelectedValue.ToString().Trim();
            data.tblTaikhoans.InsertOnSubmit(tk);
            data.SubmitChanges();
        }

        private void Xoa()
        {
            tblTaikhoan tk = (tblTaikhoan)data.tblTaikhoans.Where(p => p.Tendangnhap == tbxTendangnhap.Text).Single();
            data.tblTaikhoans.DeleteOnSubmit(tk);
            data.SubmitChanges();
        }

        private void Sua()
        {
            tblTaikhoan tk = (tblTaikhoan)data.tblTaikhoans.Single(p => p.Tendangnhap == tbxTendangnhap.Text);
            //tk.Tendangnhap = tbxTendangnhap.Text;
            tk.Matkhau = tbxMatkhau.Text;
            tk.Tenhienthi = tbxTenhienthi.Text;
            //tk.Maloai = tbxLoaitk.Text.Trim();
            tk.Maloai = tbxLoaitk.SelectedValue.ToString().Trim();
            data.SubmitChanges();
        }

        private bool Check()
        {
            var q = from p in data.tblTaikhoans
                    where p.Tendangnhap == tbxTendangnhap.Text
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
        #endregion
        private void ListViewTaikhoan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int rowindex = ListViewTaikhoan.SelectedIndex;
            if (rowindex == -1)
            {
                tbxTendangnhap.Text = "";
                tbxMatkhau.Text = "";
                tbxTenhienthi.Text = "";
                tbxLoaitk.Text = "";
            }
            else
            {
                tblTaikhoan tk = (tblTaikhoan)ListViewTaikhoan.SelectedItem;
                tbxTendangnhap.Text = tk.Tendangnhap;
                tbxMatkhau.Text = tk.Matkhau;
                tbxTenhienthi.Text = tk.Tenhienthi;
                tbxLoaitk.SelectedValue = tk.Maloai;
            }
        }

        private void tbxTimkiem_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxTimkiem.Text == "")
            {
                GetData();
            }
            else
            {
                ListViewTaikhoan.ItemsSource = data.tblTaikhoans.Where(item => item.Tendangnhap.Contains(tbxTimkiem.Text)
                || item.Tenhienthi.Contains(tbxTimkiem.Text)
                || item.Maloai.Contains(tbxTimkiem.Text));
            }
        }
    }
}
