
using DevExpress.Mvvm.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcessorSDK;
using System.Windows.Controls;
using QLGV_Module.Views;

namespace QLGV_Module.ViewModels
{
    [ProcessorAttribute("Giáo Viên", "trinh", "Quản lý Giáo Viên", "1.0.0")]
    public class QLGVModel: IArrayProcessor
    {
        //Tiêu đề của Module
        public string Caption { get { return "Module Giáo Viên"; } }

       

        //Tạo Module
        public static QLGVModel Create()
        {
            return ViewModelSource.Create(() => new QLGVModel());
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
            return new QLGV();
        }

        public ProcessorAttribute Attributes
        {
            get { return mAttributes; }
            set { mAttributes = value; }
        }

        public QLGVModel() { }
    }
}
