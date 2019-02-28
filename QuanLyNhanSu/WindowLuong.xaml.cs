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
    /// Interaction logic for WindowLuong.xaml
    /// </summary>
    public partial class WindowLuong : Window
    {
        QLNSDataContext data = new QLNSDataContext();
        public WindowLuong()
        {
            InitializeComponent();
            GetCbb();
            GetAllnhanvien();
            GetLuong();
            btnLuu.IsEnabled = false;
            Chophepxoasua(false);
        }
        private void btnChamcong_Click(object sender, RoutedEventArgs e)
        {
            if (tbxManv.Text == "" || dpNgay.Text=="" || tbxSongaylv.Text == "" || tbxLuong1ngay.Text == "" ||tbxSogiotangca.Text=="" ||tbxBHXH.Text==""||tbxThuong.Text=="")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin cần chấm công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                try
                {
                    if (!Check())
                    {
                        if (MessageBox.Show("Xác nhận!", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
                        {
                            Them();
                            GetLuong();
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        MessageBox.Show("Bảng lương đã chấm công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Chấm công thất bại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void btnTinhluong_Click(object sender, RoutedEventArgs e)
        {
            if (tbxManv.Text == "" || dpNgay.Text=="" || tbxSongaylv.Text == "" || tbxLuong1ngay.Text == "" || tbxSogiotangca.Text == "" || tbxBHXH.Text == "" || tbxThuong.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin cần tính lương!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                try
                {
                    if (Check() && tbxTongluong.Text == "")
                    {
                        if (MessageBox.Show("Xác nhận!", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
                        {
                            Tinhluong();
                            btnLuu.IsEnabled = true;
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        MessageBox.Show("Nhân viên đã tính lương!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Tính lương thất bại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            if (tbxManv.Text == "" ||dpNgay.Text=="" || tbxSongaylv.Text == "" || tbxLuong1ngay.Text == "" || tbxSogiotangca.Text == "" || tbxBHXH.Text == "" || tbxThuong.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin cần tính lương!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                try
                {
                    if (Check() && tbxTongluong.Text!="")
                    {
                        if (MessageBox.Show("Xác nhận!", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
                        {
                            Sua();
                            GetLuong();
                            btnLuu.IsEnabled = false;
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        MessageBox.Show("Nhân viên chưa tính lương!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                        btnLuu.IsEnabled = false;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Lưu thất bại thất bại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    btnLuu.IsEnabled = false;
                }
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            if (tbxManv.Text == "" || dpNgay.Text=="" )
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                try
                {
                    if (Check())
                    {
                        if (MessageBox.Show("Xác nhận!", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
                        {
                            Xoa();
                            GetLuong();
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        MessageBox.Show("Bảng lương không tồn tại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
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
            if (tbxManv.Text == "" || dpNgay.Text=="")
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                try
                {
                    if (Check())
                    {
                        if (MessageBox.Show("Xác nhận!", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
                        {
                            Sua();
                            Tinhluong();
                            Sua();
                            GetLuong();
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        MessageBox.Show("Bảng lương không tồn tại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("sửa thất bại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        #region Chức năng

        private void Tinhluong()
        {
            int tongluong, songaylv, tiencong1ngay, sogiotangca, luong1giotangca, thuong, bhxh;
            songaylv = int.Parse(tbxSongaylv.Text);
            tiencong1ngay = int.Parse(tbxLuong1ngay.Text);
            sogiotangca = int.Parse(tbxSogiotangca.Text);
            luong1giotangca = int.Parse(tbxLuong1giotangca.Text);
            thuong = int.Parse(tbxThuong.Text);
            bhxh = int.Parse(tbxBHXH.Text);
            tongluong = (songaylv * tiencong1ngay + sogiotangca * luong1giotangca + thuong) - bhxh;
            tbxTongluong.Text = tongluong.ToString();
            //btnLuu.IsEnabled = true;
        }

        private void Chophepxoasua(bool check)
        {
            if(check)
            {
                btnSua.IsEnabled = true;
                btnXoa.IsEnabled = true;
            }
            else
            {
                btnSua.IsEnabled = false;
                btnXoa.IsEnabled = false;
            }
        }

        private void Them()
        {
            tblLuong lg = new tblLuong();
            lg.Manv = tbxManv.Text;
            lg.Ngay = dpNgay.DisplayDate;
            lg.Songaylv = tbxSongaylv.Text;
            lg.Sogiotangca = tbxSogiotangca.Text;
            lg.Tiencong1ngay = tbxLuong1ngay.Text;
            lg.Luong1giotangca = tbxLuong1giotangca.Text;
            lg.BHXH = tbxBHXH.Text;
            lg.Thuong = tbxThuong.Text;
            data.tblLuongs.InsertOnSubmit(lg);
            data.SubmitChanges();
            //lg.Tongluong = int.Parse(tbxTongluong.Text);

        }

        private void Xoa()
        {
            tblLuong lg = (tblLuong)data.tblLuongs.Where(p => p.Manv == tbxManv.Text && p.Ngay == dpNgay.DisplayDate).Single();
            data.tblLuongs.DeleteOnSubmit(lg);
            data.SubmitChanges();
        }

        private void Sua()
        {
            tblLuong lg = (tblLuong)data.tblLuongs.Where(p => p.Manv == tbxManv.Text && p.Ngay == dpNgay.DisplayDate).Single();
            //tbxManv.Text
            //tbxHoten.Text
            //lg.Thang = tbxThang.Text;
            //lg.Nam =  tbxNam.Text;
            lg.Songaylv = tbxSongaylv.Text;
            lg.Sogiotangca = tbxSogiotangca.Text;
            lg.Tiencong1ngay = tbxLuong1ngay.Text;
            lg.Luong1giotangca = tbxLuong1giotangca.Text;
            lg.BHXH = tbxBHXH.Text;
            lg.Thuong = tbxThuong.Text;
            lg.Tongluong = tbxTongluong.Text;
            data.SubmitChanges();
        }

        private bool Check()
        {
            try
            {
                var q = from p in data.tblLuongs
                        where (p.Ngay==dpNgay.DisplayDate) && (p.Manv == tbxManv.Text)
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
            catch (Exception)
            {
                return false;
            }

        }
        #endregion
        #region Lấy dữ liệu
        //load combobox phòng
        private void GetCbb()
        {
            var q = from p in data.tblPhongs
                    select p;
            cbbPhong.ItemsSource = q;
            cbbPhong.DisplayMemberPath = "Tenphong";
            cbbPhong.SelectedValuePath = "Maphong";
        }
        //Lấy bảng lương
        private void GetLuong()
        {
            var q = from p in data.tblLuongs
                    select p;
            ListViewLuong.ItemsSource = q;
        }
        //Lấy nhân viên có phòng
        private void GetNhanvien(string cbb)
        {
            var q = from p in data.tblHosos
                    where p.Maphong == cbb
                    select p;
            ListViewNhanvien.ItemsSource = q;
        }
        //Lấy tất cả nhân viên
        private void GetAllnhanvien()
        {
            var q = from p in data.tblHosos
                    select p;
            ListViewNhanvien.ItemsSource = q;
        }

        private string laytennhanvien(string manv)
        {
            var q = (from p in data.tblHosos
                     where p.Manv == manv
                     select p).FirstOrDefault();
            string tendaydu;
            tendaydu = q.Hodem + " " + q.Ten;
            return tendaydu;
        }
        #endregion
        #region binding
        private void cbbPhong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetNhanvien(cbbPhong.SelectedValue.ToString());
        }

        private void ListViewNhanvien_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListViewLuong.SelectedIndex = -1;
            int rowindex = ListViewNhanvien.SelectedIndex;
            if (rowindex == -1)
            {
                //tbxManv.Text = "";
                //tbxHoten.Text = "";
            }
            else
            {
                Chophepxoasua(false);
                tblHoso hs = (tblHoso)ListViewNhanvien.SelectedItem;
                tbxManv.Text = hs.Manv;
                tbxHoten.Text = hs.Hodem + " " + hs.Ten;

            }
        }

        private void ListViewLuong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListViewNhanvien.SelectedIndex = -1;
            int rowindex = ListViewLuong.SelectedIndex;
            if (rowindex == -1)
            {
                Chophepxoasua(false);
                //tbxManv.Text = "";
                //tbxHoten.Text = "";

                dpNgay.Text ="";
                tbxSongaylv.Text = "";
                tbxSogiotangca.Text = "";
                tbxLuong1ngay.Text = "";
                tbxLuong1giotangca.Text = "";
                tbxBHXH.Text = "";
                tbxThuong.Text = "";
                tbxTongluong.Text = "";
            }
            else
            {
                Chophepxoasua(true);
                tblLuong lg = (tblLuong)ListViewLuong.SelectedItem;
                tbxManv.Text = lg.Manv;
                tbxHoten.Text = laytennhanvien(lg.Manv);
                dpNgay.Text=lg.Ngay.ToString();
                tbxSongaylv.Text = lg.Songaylv;
                tbxSogiotangca.Text = lg.Sogiotangca;
                tbxLuong1ngay.Text = lg.Tiencong1ngay;
                tbxLuong1giotangca.Text = lg.Luong1giotangca;
                tbxBHXH.Text = lg.BHXH;
                tbxThuong.Text = lg.Thuong;
                tbxTongluong.Text = lg.Tongluong;               
            }
        }



        #endregion

        private void tbxTimkiem_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxTimkiem.Text == "")
            {
                GetLuong();
            }
            else
            {
                ListViewLuong.ItemsSource = data.tblLuongs.Where(item =>
                item.Manv.Contains(tbxTimkiem.Text)||
                (item.Ngay.ToString()).Contains(tbxTimkiem.Text));
            }
        }
    }
}
