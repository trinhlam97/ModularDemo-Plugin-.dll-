using ProcessorSDK;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QLSV_Module.Views
{
    /// <summary>
    /// Interaction logic for SV.xaml
    /// </summary>
    [ProcessorAttribute("View Sinh Viên", "trinh", "Quản lý Sinh Viên", "1.0.0")]
    public partial class SV : UserControl, IArrayProcessor
    {
        public SV()
        {
            InitializeComponent();
            ShowDataLop();
            ShowDataSV();

        }
        List<Lop> dsLop = new List<Lop>();
        List<SinhVien> dsSV = new List<SinhVien>();
       

        private void ShowDataLop()
        {
            dsLop = DataLop();
            cbbLop.ItemsSource = dsLop;

        }
        public List<Lop> DataLop()
        {
            List<Lop> dsLop = new List<Lop>();
            dsLop.Add(new Lop() { Ma = "L1", Ten = "Lớp 1" });
            dsLop.Add(new Lop() { Ma = "L2", Ten = "Lớp 2" });
            dsLop.Add(new Lop() { Ma = "L3", Ten = "Lớp 3" });
            dsLop.Add(new Lop() { Ma = "L4", Ten = "Lớp 4" });
            dsLop.Add(new Lop() { Ma = "L5", Ten = "Lớp 5" });
            return dsLop;
        }

        private void ShowDataSV()
        {

            dsSV.Add(new SinhVien() { MaSV = "SV001", TenSV = "Sinh Viên A", Lop = dsLop[0] });
            dsSV.Add(new SinhVien() { MaSV = "SV002", TenSV = "Sinh Viên B", Lop = dsLop[1] });
            dsSV.Add(new SinhVien() { MaSV = "SV003", TenSV = "Sinh Viên C", Lop = dsLop[2] });
            dsSV.Add(new SinhVien() { MaSV = "SV004", TenSV = "Sinh Viên D", Lop = dsLop[3] });
            dsSV.Add(new SinhVien() { MaSV = "SV005", TenSV = "Sinh Viên E", Lop = dsLop[4] });
            datagrid.ItemsSource = dsSV;
        }

        private void Datagrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (datagrid.SelectedItem != null)
            {
                try
                {
                    object item = datagrid.SelectedItem;
                    SinhVien SV = item as SinhVien;
                    txtMaSV.Text = SV.MaSV;
                    txtTenSV.Text = SV.TenSV;
                    cbbLop.SelectedItem = SV.Lop;
                }
                catch (Exception ex)
                { }
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            string maSV, tenSV;
            maSV = txtMaSV.Text;
            tenSV = txtTenSV.Text;
            if (!String.IsNullOrEmpty(tenSV))
            {
                try
                {

                    SinhVien SV = dsSV.Where(x => x.MaSV == maSV).SingleOrDefault();
                    SV.TenSV = tenSV;
                    SV.Lop = cbbLop.SelectedItem as Lop;
                    datagrid.ClearValue(ItemsControl.ItemsSourceProperty);
                    datagrid.ItemsSource = dsSV;
                    MessageBox.Show("Sửa thành công");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thêm bị lỗi");
                }
            }
            else
            {
                MessageBox.Show("Tên SV không được để trống");
            }
        }
        private SinhVien findSV(string ma)
        {
            return null;
            foreach (SinhVien SV in dsSV)
            {
                if (SV.MaSV == ma)
                {
                    return SV;
                }
            }
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            string maSV, tenSV;
            maSV = txtMaSV.Text;
            tenSV = txtTenSV.Text;
            if (!String.IsNullOrEmpty(tenSV))
            {
                try
                {
                    SinhVien SV = new SinhVien();
                    maSV = dsSV[dsSV.Count - 1].MaSV;
                    int ma = Int32.Parse(maSV.Substring(2));
                    if (ma + 1 < 10)
                    {
                        maSV = "SV00" + (ma + 1);
                    }
                    else if (ma + 1 < 100)
                    {
                        maSV = "SV0" + (ma + 1);
                    }
                    else if (ma + 1 >= 100)
                    {
                        maSV = "SV" + (ma + 1);
                    }

                    SV.MaSV = maSV;
                    SV.TenSV = tenSV;
                    SV.Lop = cbbLop.SelectedItem as Lop;
                    datagrid.ClearValue(ItemsControl.ItemsSourceProperty);
                    dsSV.Add(SV);
                    datagrid.ItemsSource = dsSV;
                    MessageBox.Show("Thêm thành công");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thêm bị lỗi");
                }
            }
            else
            {
                MessageBox.Show("Tên SV không được để trống");
            }
        }

        public UserControl Process()
        {
            throw new NotImplementedException();
        }

        private IManagerProcess mHostViewer;

        private ProcessorAttribute mAttributes;

        public void Initialize(IManagerProcess host)
        {
            mHostViewer = host;
        }

        public void Dispose()
        {
            mAttributes = null;
        }

        public ProcessorAttribute Attributes
        {
            get { return mAttributes; }
            set { mAttributes = value; }
        }
    }
}
