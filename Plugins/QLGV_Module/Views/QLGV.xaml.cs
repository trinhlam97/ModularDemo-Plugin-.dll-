
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

namespace QLGV_Module.Views
{
    /// <summary>
    /// Interaction logic for QLGV.xaml
    /// </summary>
    [ProcessorAttribute("View Giáo Viên", "trinh", "Quản lý Giáo Viên", "1.0.0")]
    public partial class QLGV : UserControl, IArrayProcessor
    {
        public QLGV()
        {
            InitializeComponent();
            ShowDataLop();
            ShowDataGV();

        }
        List<Lop> dsLop = new List<Lop>();
        List<GiaoVien> dsgv = new List<GiaoVien>();
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

        private void ShowDataGV()
        {

            dsgv.Add(new GiaoVien() { MaGV = "GV001", TenGV = "Giáo Viên A", Lop = dsLop[0] });
            dsgv.Add(new GiaoVien() { MaGV = "GV002", TenGV = "Giáo Viên B", Lop = dsLop[1] });
            dsgv.Add(new GiaoVien() { MaGV = "GV003", TenGV = "Giáo Viên C", Lop = dsLop[2] });
            dsgv.Add(new GiaoVien() { MaGV = "GV004", TenGV = "Giáo Viên D", Lop = dsLop[3] });
            dsgv.Add(new GiaoVien() { MaGV = "GV005", TenGV = "Giáo Viên E", Lop = dsLop[4] });
            datagrid.ItemsSource = dsgv;

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string magv, tengv;
            magv = txtMaGV.Text;
            tengv = txtTenGV.Text;
            if (!String.IsNullOrEmpty(tengv))
            {
                try
                {
                    GiaoVien gv = new GiaoVien();
                    magv = dsgv[dsgv.Count - 1].MaGV;
                    int ma = Int32.Parse(magv.Substring(2));
                    if (ma + 1 < 10)
                    {
                        magv = "GV00" + (ma + 1);
                    }
                    else if (ma + 1 < 100)
                    {
                        magv = "GV0" + (ma + 1);
                    }
                    else if (ma + 1 >= 100)
                    {
                        magv = "GV" + (ma + 1);
                    }

                    gv.MaGV = magv;
                    gv.TenGV = tengv;
                    gv.Lop = cbbLop.SelectedItem as Lop;
                    datagrid.ClearValue(ItemsControl.ItemsSourceProperty);
                    dsgv.Add(gv);
                    datagrid.ItemsSource = dsgv;
                    MessageBox.Show("Thêm thành công");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thêm bị lỗi");
                }
            }
            else
            {
                MessageBox.Show("Tên GV không được để trống");
            }

        }
        private GiaoVien findGV(string ma)
        {
            return null;
            foreach (GiaoVien gv in dsgv)
            {
                if (gv.MaGV == ma)
                {
                    return gv;
                }
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            string magv, tengv;
            magv = txtMaGV.Text;
            tengv = txtTenGV.Text;
            if (!String.IsNullOrEmpty(tengv))
            {
                try
                {
                    
                        GiaoVien gv = dsgv.Where(x => x.MaGV == magv).SingleOrDefault();
                        gv.TenGV = tengv;
                        gv.Lop = cbbLop.SelectedItem as Lop;
                    datagrid.ClearValue(ItemsControl.ItemsSourceProperty);
                    datagrid.ItemsSource = dsgv;
                    MessageBox.Show("Sửa thành công");
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thêm bị lỗi");
                }
            }
            else
            {
                MessageBox.Show("Tên GV không được để trống");
            }
        }

        private void datagrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (datagrid.SelectedItem != null)
            {
                try
                {
                    object item = datagrid.SelectedItem;
                    GiaoVien gv = item as GiaoVien;
                    txtMaGV.Text = gv.MaGV;
                    txtTenGV.Text = gv.TenGV;
                    cbbLop.SelectedItem = gv.Lop;
                }
                catch (Exception ex)
                { }
            }
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

        public UserControl Process()
        {
            throw new NotImplementedException();
        }

        public ProcessorAttribute Attributes
        {
            get { return mAttributes; }
            set { mAttributes = value; }
        }
    }
}
