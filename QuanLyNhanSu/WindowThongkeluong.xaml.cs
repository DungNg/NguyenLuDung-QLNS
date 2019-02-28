using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QuanLyNhanSu
{
    /// <summary>
    /// Interaction logic for WindowThongke.xaml
    /// </summary>
    public partial class WindowThongke : Window
    {
        QLNSDataContext data = new QLNSDataContext();
        tblLuong lg = new tblLuong();
        public WindowThongke()
        {
            InitializeComponent();
            GetAll();
        }

        private void chbxTheothoigian_Click(object sender, RoutedEventArgs e)
        {
            if (chbxTheothoigian.IsChecked == true)
            {
                panel1.IsEnabled = true;
            }
            else
            {
                panel1.IsEnabled = false;
            }
        }

        private void chbxTheonhanvienvaphong_Click(object sender, RoutedEventArgs e)
        {
            if (chbxTheonhanvienvaphong.IsChecked == true)
            {
                if (chbxPhong.IsChecked == true)
                {
                    chbxPhong.IsChecked = false;
                    panel3.IsEnabled = false;
                }
                GetPhong(cbbPhong);
                panel2.IsEnabled = true;
            }
            else
            {
                panel2.IsEnabled = false;
            }
        }

        private void chbxPhong_Click(object sender, RoutedEventArgs e)
        {
            if (chbxPhong.IsChecked==true)
            {                
                if (chbxTheonhanvienvaphong.IsChecked == true)
                {
                    chbxTheonhanvienvaphong.IsChecked = false;
                    panel2.IsEnabled = false;
                }
                GetPhong(cbbPhong2);
                panel3.IsEnabled = true;
            }
            else
            {
                panel3.IsEnabled = false;
            }
        }

        private void btnTim_Click(object sender, RoutedEventArgs e)
        {
            GetAll();
            try
            {
                if (chbxTheothoigian.IsChecked == true && chbxTheonhanvienvaphong.IsChecked == true)
                {
                    GetTheophongvanhanvien_ngay(cbbPhong.SelectedValue.ToString(), cbbNhanvien.SelectedValue.ToString(), dpBatdau.DisplayDate, dpKetthuc.DisplayDate);
                }
                else
                {
                    if (chbxPhong.IsChecked == true && chbxTheothoigian.IsChecked == true)
                    {
                        GetTheophong_ngay(cbbPhong2.SelectedValue.ToString(), dpBatdau.DisplayDate, dpKetthuc.DisplayDate);
                    }
                    else
                    {
                        if (chbxTheothoigian.IsChecked == true)
                        {
                            GetTheothoigian(dpBatdau.DisplayDate, dpKetthuc.DisplayDate);
                        }
                        else
                        {
                            if (chbxTheonhanvienvaphong.IsChecked == true)
                            {
                                GetTheophongvanhanvien(cbbPhong.SelectedValue.ToString(), cbbNhanvien.SelectedValue.ToString());
                            }
                            else
                            {
                                if (chbxPhong.IsChecked == true)
                                {
                                    GetTheophong(cbbPhong2.SelectedValue.ToString());
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                GetAll();
                MessageBox.Show("Chọn và điền đầy đủ thông tin cần tìm!", "Thông báo!", MessageBoxButton.OK, MessageBoxImage.Asterisk);

            }


        }

        private void cbbPhong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetNhanvien(cbbPhong.SelectedValue.ToString());
        }

        #region Lấy dữ liệu
        private void GetAll()
        {
            var q = (from p in data.tblLuongs
                     select new
                     {
                         ngay = p.Ngay,
                         manv = p.Manv,
                         songaylv = p.Songaylv,
                         tiencong1ngay = p.Tiencong1ngay,
                         sogiotangca = p.Sogiotangca,
                         luong1giotangca = p.Luong1giotangca,
                         bhxh = p.BHXH,
                         thuong = p.Thuong,
                         tongluong = p.Tongluong
                     }).ToList();
            ListViewThongke.ItemsSource = q;
        }

        private void GetTheothoigian(DateTime batdau, DateTime ketthuc)
        {
            var q = (from p in data.tblLuongs
                     where p.Ngay >= batdau && p.Ngay <= ketthuc
                     select new
                     {
                         ngay = p.Ngay,
                         manv = p.Manv,
                         songaylv = p.Songaylv,
                         tiencong1ngay = p.Tiencong1ngay,
                         sogiotangca = p.Sogiotangca,
                         luong1giotangca = p.Luong1giotangca,
                         bhxh = p.BHXH,
                         thuong = p.Thuong,
                         tongluong = p.Tongluong
                     }).ToList();
            ListViewThongke.ItemsSource = q;

        }

        private void GetTheophongvanhanvien(string phong, string nhanvien)
        {
            var q = (from l in data.tblLuongs
                     join hs in data.tblHosos on l.Manv equals hs.Manv
                     where hs.Maphong == phong && hs.Manv == nhanvien
                     select new
                     {
                         ngay = l.Ngay,
                         manv = l.Manv,
                         songaylv = l.Songaylv,
                         tiencong1ngay = l.Tiencong1ngay,
                         sogiotangca = l.Sogiotangca,
                         luong1giotangca = l.Luong1giotangca,
                         bhxh = l.BHXH,
                         thuong = l.Thuong,
                         tongluong = l.Tongluong
                     }).ToList();
            ListViewThongke.ItemsSource = q;

        }

        private void GetTheophong(string phong)
        {
            var q = (from l in data.tblLuongs
                     join hs in data.tblHosos on l.Manv equals hs.Manv
                     where hs.Maphong == phong
                     select new
                     {
                         ngay = l.Ngay,
                         manv = l.Manv,
                         songaylv = l.Songaylv,
                         tiencong1ngay = l.Tiencong1ngay,
                         sogiotangca = l.Sogiotangca,
                         luong1giotangca = l.Luong1giotangca,
                         bhxh = l.BHXH,
                         thuong = l.Thuong,
                         tongluong = l.Tongluong
                     }).ToList();
            ListViewThongke.ItemsSource = q;

        }

        private void GetTheophongvanhanvien_ngay(string phong, string nhanvien, DateTime batdau, DateTime ketthuc)
        {
            var q = (from l in data.tblLuongs
                     join hs in data.tblHosos on l.Manv equals hs.Manv
                     where hs.Maphong == phong && hs.Manv == nhanvien && l.Ngay >= batdau && l.Ngay <= ketthuc
                     select new
                     {
                         ngay = l.Ngay,
                         manv = l.Manv,
                         songaylv = l.Songaylv,
                         tiencong1ngay = l.Tiencong1ngay,
                         sogiotangca = l.Sogiotangca,
                         luong1giotangca = l.Luong1giotangca,
                         bhxh = l.BHXH,
                         thuong = l.Thuong,
                         tongluong = l.Tongluong
                     }).ToList();
            ListViewThongke.ItemsSource = q;

        }

        private void GetTheophong_ngay(string phong, DateTime batdau, DateTime ketthuc)
        {
            var q = (from l in data.tblLuongs
                     join hs in data.tblHosos on l.Manv equals hs.Manv
                     where hs.Maphong == phong && l.Ngay >= batdau && l.Ngay <= ketthuc
                     select new
                     {
                         ngay = l.Ngay,
                         manv = l.Manv,
                         songaylv = l.Songaylv,
                         tiencong1ngay = l.Tiencong1ngay,
                         sogiotangca = l.Sogiotangca,
                         luong1giotangca = l.Luong1giotangca,
                         bhxh = l.BHXH,
                         thuong = l.Thuong,
                         tongluong = l.Tongluong
                     }).ToList();
            ListViewThongke.ItemsSource = q;

        }

        private void GetPhong(ComboBox phong)
        {
            var q = from p in data.tblPhongs
                    select p;
            phong.ItemsSource = q;
            phong.DisplayMemberPath = "Tenphong";
            phong.SelectedValuePath = "Maphong";
        }

        private void GetNhanvien(string maphong)
        {
            var q = from p in data.tblHosos
                    where p.Maphong == maphong
                    select p;
            cbbNhanvien.ItemsSource = q;
            cbbNhanvien.DisplayMemberPath = "Manv";
            cbbNhanvien.SelectedValuePath = "Manv";
        }

        #endregion

        private void btnXuat_Click(object sender, RoutedEventArgs e)
        {
            ExportToExcelAndCsv();
        }

        private void ExportToExcelAndCsv()
        {
            DataGrid dg = ListViewThongke;
            dg.SelectAllCells();
            dg.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, dg);
            dg.UnselectAllCells();
            String Clipboardresult = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
            StreamWriter swObj = new StreamWriter("report.csv");
            swObj.WriteLine(Clipboardresult);
            swObj.Close();
            Process.Start("report.csv");
        }
    }
}
