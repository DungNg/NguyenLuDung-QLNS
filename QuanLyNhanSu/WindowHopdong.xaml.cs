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
    /// Interaction logic for WindowHopdong.xaml
    /// </summary>
    public partial class WindowHopdong : Window
    {
        QLNSDataContext data = new QLNSDataContext();
        public WindowHopdong()
        {
            InitializeComponent();
            GetData();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            if (tbxMahd.Text == "" && tbxTenhd.Text == "")
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
                        MessageBox.Show("Hợp đồng đã tồn tại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
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
            if (tbxMahd.Text == "" && tbxTenhd.Text == "")
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
                        MessageBox.Show("Hợp đồng không tồn tại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
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
            if (tbxMahd.Text == "" && tbxTenhd.Text == "")
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
                        MessageBox.Show("Hợp đồng không tồn tại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
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
            tblHopdong hd = new tblHopdong();
            hd.Mahd = tbxMahd.Text;
            hd.Tenhd = tbxTenhd.Text;
            hd.Ghichu = tbxGhichu.Text;
            data.tblHopdongs.InsertOnSubmit(hd);
            data.SubmitChanges();
        }

        private void Xoa()
        {
            tblHopdong hd = (tblHopdong)data.tblHopdongs.Where(p => p.Mahd == tbxMahd.Text).Single();
            data.tblHopdongs.DeleteOnSubmit(hd);
            data.SubmitChanges();
        }

        private void Sua()
        {
            tblHopdong hd = (tblHopdong)data.tblHopdongs.Single(p => p.Mahd == tbxMahd.Text);
            //hd.Mahd = tbxMahd.Text;
            hd.Tenhd = tbxTenhd.Text;
            hd.Ghichu = tbxGhichu.Text;
            data.SubmitChanges();
        }

        private bool Check()
        {
            var q = from p in data.tblHopdongs
                    where p.Mahd == tbxMahd.Text
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
            var q = from p in data.GetTable<tblHopdong>()
                    select p;
            Listviewhd.ItemsSource = q;
        }


        #endregion
        #region binding
        private void Listviewhd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int rowindex = Listviewhd.SelectedIndex;
            if (rowindex == -1)
            {
                tbxMahd.Text = "";
                tbxTenhd.Text = "";
                tbxGhichu.Text = "";
            }
            else
            {
                tblHopdong hd = (tblHopdong)Listviewhd.SelectedItem;
                tbxMahd.Text = hd.Mahd;
                tbxTenhd.Text = hd.Tenhd;
                tbxGhichu.Text = hd.Ghichu;
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
                Listviewhd.ItemsSource = data.tblHopdongs.Where(item => item.Mahd.Contains(tbxTimkiem.Text) 
                || item.Tenhd.Contains(tbxTimkiem.Text) 
                || item.Ghichu.Contains(tbxTimkiem.Text));
            }
        }
    }
}
