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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HostViewer mHostAdapter = new HostViewer();
        public MainWindow()
        {
            InitializeComponent();
            LoadDLL();
        }

        private void LoadDLL()
        {
            string str = System.IO.Directory.GetCurrentDirectory();
            int pos = str.IndexOf("WpfApp1");
            string path = str.Substring(0, pos - 1);
            mHostAdapter.FindPlugIns(path + @"\plugins");
            foreach (Types.AvailableArrayProcessor plugin in mHostAdapter.PlugIns)
            {
                // disguising...
                MenuItem button = new MenuItem();
                button.Header = plugin.Instance.Attributes.Name;
                button.Tag = plugin;
                button.Click += new RoutedEventHandler(MenuItemClick); // registers a click event...

                //button.ToolTip(button, plugin.Instance.Attributes.Description);

                mnFile.Items.Add(button);
            }

            mHostAdapter.Report(mHostAdapter.PlugIns.Count + " Plug-In(s) Loaded."); // reports to clients...
        }
        private void MenuItemClick(object sender, RoutedEventArgs e)
        {

            Types.AvailableArrayProcessor processor = ((MenuItem)sender).Tag as Types.AvailableArrayProcessor;
            UserControl userControl = processor.Instance.Process();
            if(model.Children.Count>0)
            {
                model.Children.Clear();
            }
            model.Children.Add(userControl);

        }


        private void MnGiaoVien_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void MnSinhVien_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
