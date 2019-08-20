using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace ProcessorSDK
{
    public interface IArrayProcessor
    {
        UserControl Process();
        void Initialize(IManagerProcess host);
        void Dispose();
        ProcessorAttribute Attributes
        {
            get;
            set;
        }
    }
}
