using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessorSDK
{
    /// <summary>
    /// Quản lý thực thi của các Plug-in
    /// </summary>
    public interface IManagerProcess
    {
        void Report(string message);

        void Dispose();
    }
}
