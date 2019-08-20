using DevExpress.Mvvm.POCO;
using ProcessorSDK;
using QLSV_Module.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace QLSV_Module.ViewModels
{
    [ProcessorAttribute("Sinh Viên", "trinh", "Quản lý Sinh Viên", "1.0.0")]
    public class QLSVModel: IArrayProcessor
    {
        public string Caption { get { return "Module Sinh Viên"; } }



        //Tạo Module
        public static QLSVModel Create()
        {
            return ViewModelSource.Create(() => new QLSVModel());
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
            return new SV();
        }

        public ProcessorAttribute Attributes
        {
            get { return mAttributes; }
            set { mAttributes = value; }
        }
        public QLSVModel() { }
    }
}
