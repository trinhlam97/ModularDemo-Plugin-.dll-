using ProcessorSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace QLSV_Module
{
    [ProcessorAttribute("Class SinhVien", "trinh", "Quản lý Sinh Viên", "1.0.0")]
    public class SinhVien : IArrayProcessor
    {
        public string MaSV { get; set; }
        public string TenSV { get; set; }
        public Lop Lop { get; set; }
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
    [ProcessorAttribute("Class SinhVien.Lop", "trinh", "Quản lý Sinh Viên", "1.0.0")]
    public class Lop : IArrayProcessor
    {
        public string Ma { get; set; }
        public string Ten { get; set; }
        

        public Lop() { }

        private IManagerProcess mHostViewer;

        private ProcessorAttribute mAttributes;
        public int[] Process(int[] array)
        {
            throw new NotImplementedException();
        }

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