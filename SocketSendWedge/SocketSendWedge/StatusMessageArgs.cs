using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace SocketSendWedge
{
    public class StatusMessageArgs:EventArgs
    {
        public Status status { get; set; }
        public String msg { get; set; }
        public StatusMessageArgs(Status _status, String _string)
        {
            status = _status;
            msg = _string;
        }
    }
    public enum Status
    {
        failed = 0,
        success = 1,
        pending = 2,
    }
}
