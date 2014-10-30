using System;

using System.Collections.Generic;
using System.Text;
using System.Net;

namespace SocketSend2
{
    public static class utils1
    {
        public static List<String> getLocalIPaddresses()
        {
            List<String> sList = new List<string>();
            // Get host name
            String strHostName = Dns.GetHostName();

            // Find host by name
            IPHostEntry iphostentry = Dns.GetHostByName(strHostName);

            // Enumerate IP addresses
            int nIP = 0;
            foreach(IPAddress ipaddress in iphostentry.AddressList)
            {
                sList.Add(ipaddress.ToString());
            }
            return sList;
        }
    }
}
