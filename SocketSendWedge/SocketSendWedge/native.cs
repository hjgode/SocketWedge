using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace SocketSendWedge
{
    class native
    {
        [DllImport("coredll.dll", SetLastError = true)]
        static extern bool MessageBeep(MessageBeepTypes u);

        public static void goodBeep(){
            MessageBeep(MessageBeepTypes.MB_OK);
        }

        enum MessageBeepTypes
        {
            MB_OK=0,
            MB_ICONEXCLAMATION=0x30,
        }
    }
}
