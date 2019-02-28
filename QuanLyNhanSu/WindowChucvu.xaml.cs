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
    /// Interaction logic for WindowChucvu.xaml
    /// </summary>
    public partial class WindowChucvu : Window
    {
        QLNSDataContext data = new QLNSDataContext();
        public WindowChucvu()
        {
            InitializeComponent();
            GetData();           
        }


        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            if (tbxMacv.Text == "" && tbxTencv.Text == "")
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
                        MessageBox.Show("Chức vụ đã tồn tại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Thêm thất bại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            if (tbxMacv.Text == "" && tbxTencv.Text == "")
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
                        MessageBox.Show("Chức vụ không tồn tại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Sửa thất bại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

            }

        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            if (tbxMacv.Text == "" && tbxTencv.Text == "")
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
                        MessageBox.Show("Chức vụ không tồn tại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Xóa thất bại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }


        #region Chức năng
        private void Them()
        {
            tblChucvu cv = new tblChucvu();
            cv.Macv = tbxMacv.Text;
            cv.Tencv = tbxTencv.Text;
            data.tblChucvus.InsertOnSubmit(cv);
            data.SubmitChanges();
        }

        private void Xoa()
        {
            tblChucvu cv = (tblChucvu)data.tblChucvus.Where(p => p.Macv == tbxMacv.Text).Single();
            data.tblChucvus.DeleteOnSubmit(cv);
            data.SubmitChanges();
        }

        private void Sua()
        {
            tblChucvu cv = (tblChucvu)data.tblChucvus.Single(p => p.Macv == tbxMacv.Text);
            //cv.Macv = tbxMacv.Text;
            cv.Tencv = tbxTencv.Text;
            data.SubmitChanges();
        }

        private bool Check()
        {
            var q = from p in data.tblChucvus
                    where p.Macv == tbxMacv.Text
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
            var q = from p in data.GetTable<tblChucvu>()
                    select p;
            ListViewChucvu.ItemsSource = q;
        }
        
        private void tbxTimkiem_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if(tbxTimkiem.Text=="")
            {
                GetData();
            }
            else
            {
                ListViewChucvu.ItemsSource = data.tblChucvus.Where(item => item.Macv.Contains(tbxTimkiem.Text) || item.Tencv.Contains(tbxTimkiem.Text));
            }
        }

        #endregion
        #region Binding
        private void ListViewChucvu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int rowindex = ListViewChucvu.SelectedIndex;
            if (rowindex == -1)
            {
                tbxMacv.Text = "";
                tbxTencv.Text = "";
            }
            else
            {
                tblChucvu cv = (tblChucvu)ListViewChucvu.SelectedItem;
                tbxMacv.Text = cv.Macv;
                tbxTencv.Text = cv.Tencv;
            }
        }
        #endregion       
    }
}
