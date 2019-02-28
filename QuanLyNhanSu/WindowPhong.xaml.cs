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
    /// Interaction logic for WindowPhong.xaml
    /// </summary>
    public partial class WindowPhong : Window
    {
        QLNSDataContext data = new QLNSDataContext();
        public WindowPhong()
        {
            InitializeComponent();
            GetData();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            if (tbxMaphong.Text == "" && tbxTenphong.Text == "")
            {
                MessageBox.Show("Vui lòng điền chức vụ cần thêm!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
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
                        MessageBox.Show("Phòng đã tồn tại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
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
            if (tbxMaphong.Text == "" && tbxTenphong.Text == "")
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
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
                        MessageBox.Show("Phòng không tồn tại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
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
            if (tbxMaphong.Text == "" && tbxTenphong.Text == "")
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
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
                        MessageBox.Show("Phòng không tồn tại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Sửa thất bại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

            }
        }

        
        #region Chứcnăng
        private void Them()
        {
            tblPhong ph = new tblPhong();
            ph.Maphong = tbxMaphong.Text;
            ph.Tenphong = tbxTenphong.Text;
            data.tblPhongs.InsertOnSubmit(ph);
            data.SubmitChanges();
        }

        private void Xoa()
        {
            tblPhong ph = (tblPhong)data.tblPhongs.Where(p => p.Maphong == tbxMaphong.Text).Single();
            data.tblPhongs.DeleteOnSubmit(ph);
            data.SubmitChanges();
        }

        private void Sua()
        {
            tblPhong ph = (tblPhong)data.tblPhongs.Single(p => p.Maphong == tbxMaphong.Text);
            //ph.Maphong = tbxMaphong.Text;
            ph.Tenphong = tbxTenphong.Text;
            data.SubmitChanges();
        }

        private bool Check()
        {
            var q = from p in data.tblPhongs
                    where p.Maphong == tbxMaphong.Text
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

        private void GetData()
        {
            var q = from p in data.GetTable<tblPhong>()
                    select p;
            ListviewPhong.ItemsSource = q;
        }


        #endregion
        #region binding
        private void ListviewPhong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int rowindex = ListviewPhong.SelectedIndex;
            if (rowindex == -1)
            {
                tbxMaphong.Text = "";
                tbxTenphong.Text = "";
            }
            else
            {
                tblPhong ph = (tblPhong)ListviewPhong.SelectedItem;
                tbxMaphong.Text = ph.Maphong;
                tbxTenphong.Text = ph.Tenphong;
            }
        }
        #endregion

        private void tbxTimkiem_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxTimkiem.Text == "")
            {
                GetData();
            }
            else
            {
                ListviewPhong.ItemsSource = data.tblPhongs.Where(item => item.Maphong.Contains(tbxTimkiem.Text)
                || item.Tenphong.Contains(tbxTimkiem.Text));
            }
        }
    }
}
