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
    /// Interaction logic for WindowHoso.xaml
    /// </summary>
    public partial class WindowHoso : Window
    {
        QLNSDataContext data = new QLNSDataContext();
        public WindowHoso()
        {
            InitializeComponent();
            GetData();
            GetHd();
            GetCv();
            GetPhong();
            GetTd();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            if (tbxManv.Text == "" || tbxHodem.Text == "" || tbxTen.Text == "" || cbbMacv.Text == "" || cbbMahd.Text == "" || cbbMaphong.Text == "" || cbbMatd.Text == "")
            {
                MessageBox.Show("Vui lòng điền thông tin cần thêm!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
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
                        MessageBox.Show("Nhân viên đã tồn tại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
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
            if (tbxManv.Text == "")
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
                        MessageBox.Show("Nhân viên không tồn tại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
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
            if (tbxManv.Text == "" || tbxHodem.Text == "" || tbxTen.Text == "" || cbbMacv.Text == "" || cbbMahd.Text == "" || cbbMaphong.Text == "" || cbbMatd.Text == "")
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
                        MessageBox.Show("Nhân viên không tồn tại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Sửa thất bại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

            }
        }

        #region Chức năng
        private void Them()
        {
            tblHoso hs = new tblHoso();
            hs.Manv = tbxManv.Text;
            hs.Hodem = tbxHodem.Text;
            hs.Ten = tbxTen.Text;
            hs.Gioitinh = tbxGioitinh.Text;
            hs.Ngaysinh = DateTime.Parse(dpNgaysinh.Text);
            hs.Noisinh = tbxNoisinh.Text;
            hs.SoCMND = tbxCMND.Text;
            hs.Sodt = tbxSodienthoai.Text;
            hs.NgayvaoCT = DateTime.Parse(dpNgayvaoCT.Text);
            hs.Dantoc = tbxDantoc.Text;
            hs.BHXH = tbxBHXH.Text;
            hs.Mahd = cbbMahd.SelectedValue.ToString().Trim();
            hs.Macv = cbbMacv.SelectedValue.ToString().Trim();
            hs.Matd = cbbMatd.SelectedValue.ToString().Trim();
            hs.Maphong = cbbMaphong.SelectedValue.ToString().Trim();
            data.tblHosos.InsertOnSubmit(hs);
            data.SubmitChanges();
        }

        private void Xoa()
        {
            tblHoso hs = (tblHoso)data.tblHosos.Where(p => p.Manv == tbxManv.Text).Single();
            data.tblHosos.DeleteOnSubmit(hs);
            data.SubmitChanges();
        }

        private void Sua()
        {
            tblHoso hs = (tblHoso)data.tblHosos.Single(p => p.Manv == tbxManv.Text);
            //hs.Manv = tbxManv.Text;
            hs.Hodem = tbxHodem.Text;
            hs.Ten = tbxTen.Text;
            hs.Gioitinh = tbxGioitinh.Text;
            hs.Ngaysinh = DateTime.Parse(dpNgaysinh.Text);
            hs.Noisinh = tbxNoisinh.Text;
            hs.SoCMND = tbxCMND.Text;
            hs.Sodt = tbxSodienthoai.Text;
            hs.NgayvaoCT = DateTime.Parse(dpNgayvaoCT.Text);
            hs.Dantoc = tbxDantoc.Text;
            hs.BHXH = tbxBHXH.Text;
            hs.Mahd = cbbMahd.SelectedValue.ToString().Trim();
            hs.Macv = cbbMacv.SelectedValue.ToString().Trim();
            hs.Matd = cbbMatd.SelectedValue.ToString().Trim();
            hs.Maphong = cbbMaphong.SelectedValue.ToString().Trim();
            data.SubmitChanges();
        }

        private bool Check()
        {
            var q = from p in data.tblHosos
                    where p.Manv == tbxManv.Text
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
            var q = from p in data.GetTable<tblHoso>()
                    select p;
            ListViewHoso.ItemsSource = q;
        }

        private void GetHd()
        {
            var q = from p in data.GetTable<tblHopdong>()
                    select p;
            cbbMahd.ItemsSource = q;
            cbbMahd.DisplayMemberPath = "Tenhd";
            cbbMahd.SelectedValuePath = "Mahd";
        }

        private void GetCv()
        {
            var q = from p in data.GetTable<tblChucvu>()
                    select p;
            cbbMacv.ItemsSource = q;
            cbbMacv.DisplayMemberPath = "Tencv";
            cbbMacv.SelectedValuePath = "Macv";
        }

        private void GetTd()
        {
            var q = from p in data.GetTable<tblTrinhdo>()
                    select p;
            cbbMatd.ItemsSource = q;
            cbbMatd.DisplayMemberPath = "Tentd";
            cbbMatd.SelectedValuePath = "Matd";
        }

        private void GetPhong()
        {
            var q = from p in data.GetTable<tblPhong>()
                    select p;
            cbbMaphong.ItemsSource = q;
            cbbMaphong.DisplayMemberPath = "Tenphong";
            cbbMaphong.SelectedValuePath = "Maphong";
        }
        #endregion
        #region binding
        private void Listviewhs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int rowindex = ListViewHoso.SelectedIndex;
            if (rowindex == -1)
            {
                tbxManv.Text = "";
                tbxHodem.Text = "";
                tbxTen.Text = "";
                tbxGioitinh.Text = "";
                dpNgaysinh.Text = "";
                tbxNoisinh.Text = "";
                tbxCMND.Text = "";
                tbxSodienthoai.Text = "";
                dpNgayvaoCT.Text = "";
                tbxDantoc.Text = "";
                tbxBHXH.Text = "";
                cbbMahd.Text = "";
                cbbMacv.Text = "";
                cbbMatd.Text = "";
                cbbMaphong.Text = "";
            }
            else
            {
                tblHoso hs = (tblHoso)ListViewHoso.SelectedItem;
                tbxManv.Text = hs.Manv;
                tbxHodem.Text = hs.Hodem;
                tbxTen.Text = hs.Ten;
                tbxGioitinh.Text = hs.Gioitinh;
                dpNgaysinh.Text = hs.Ngaysinh.ToString();
                tbxNoisinh.Text = hs.Noisinh;
                tbxCMND.Text = hs.SoCMND;
                tbxSodienthoai.Text = hs.Sodt;
                dpNgayvaoCT.Text = hs.NgayvaoCT.ToString();
                tbxDantoc.Text = hs.Dantoc;
                tbxBHXH.Text = hs.BHXH;
                cbbMahd.SelectedValue = hs.Mahd;
                cbbMacv.SelectedValue = hs.Macv;
                cbbMatd.SelectedValue = hs.Matd;
                cbbMaphong.SelectedValue = hs.Maphong;
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
                ListViewHoso.ItemsSource = data.tblHosos.Where(item => item.Manv.Contains(tbxTimkiem.Text) 
                || item.Hodem.Contains(tbxTimkiem.Text)
                || item.Ten.Contains(tbxTimkiem.Text)
                || item.Macv.Contains(tbxTimkiem.Text)
                || item.Mahd.Contains(tbxTimkiem.Text)
                || item.Maphong.Contains(tbxTimkiem.Text)
                || item.Matd.Contains(tbxTimkiem.Text));
            }
        }
    }
}
