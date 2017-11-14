using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace SocketSendWedge
{
    class BarcodeReadEventArgs:EventArgs
    {
        string sData { get; set; }
        bool bSuccess { get; set; }
        public BarcodeReadEventArgs(string s, bool b)
        {
            sData = s;
            bSuccess = b;
        }
    }
}
