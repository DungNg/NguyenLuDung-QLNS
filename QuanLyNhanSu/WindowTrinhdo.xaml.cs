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
    /// Interaction logic for WindowTrinhdo.xaml
    /// </summary>
    public partial class WindowTrinhdo : Window
    {
        QLNSDataContext data = new QLNSDataContext();
        tblTrinhdo td = new tblTrinhdo();
        public WindowTrinhdo()
        {
            InitializeComponent();
            GetData();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            if (tbxMatd.Text == "" && tbxTentd.Text == "")
            {
                MessageBox.Show("Vui lòng điền hợp đồng cần thêm!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
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

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            if (tbxMatd.Text == "" && tbxTentd.Text == "")
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

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            if (tbxMatd.Text == "" && tbxTentd.Text == "")
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                try
                {
                    if (Check())
                    {
                        if(MessageBox.Show("Xác nhận xóa!", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Question)==MessageBoxResult.OK)
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

        #region Chức năng
        private void Them()
        {
            tblTrinhdo td = new tblTrinhdo();
            td.Matd = tbxMatd.Text;
            td.Tentd = tbxTentd.Text;
            data.tblTrinhdos.InsertOnSubmit(td);
            data.SubmitChanges();
        }

        private void Xoa()
        {
            tblTrinhdo td = (tblTrinhdo)data.tblTrinhdos.Where(p => p.Matd == tbxMatd.Text).Single();
            data.tblTrinhdos.DeleteOnSubmit(td);
            data.SubmitChanges();
        }

        private void Sua()
        {
            tblTrinhdo td = (tblTrinhdo)data.tblTrinhdos.Single(p => p.Matd == tbxMatd.Text);
            //td.Matd = tbxMatd.Text;
            td.Tentd = tbxTentd.Text;
            data.SubmitChanges();
        }

        private bool Check()
        {
            var q = from p in data.tblTrinhdos
                    where p.Matd == tbxMatd.Text
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
            var q = from p in data.GetTable<tblTrinhdo>()
                    select p;
            ListViewTrinhdo.ItemsSource = q;
        }


        #endregion
        #region Binding
        private void ListViewTrinhdo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int rowindex = ListViewTrinhdo.SelectedIndex;
            if (rowindex == -1)
            {
                tbxMatd.Text = "";
                tbxTentd.Text = "";
            }
            else
            {
                tblTrinhdo td = (tblTrinhdo)ListViewTrinhdo.SelectedItem;
                tbxMatd.Text = td.Matd;
                tbxTentd.Text = td.Tentd;
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
                ListViewTrinhdo.ItemsSource = data.tblTrinhdos.Where(item => item.Matd.Contains(tbxTimkiem.Text)
                || item.Tentd.Contains(tbxTimkiem.Text));
            }
        }
    }
}
