//#define USES_EVENT_PUBLISHING
//use the above if you can fix the exception in Form1^, when setting the textbox1.text
//See project properties if there is already a conditional symbol USES_EVENT_PUBLISHING in the
//build settings
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Net;
using System.Windows.Forms;
using System.ComponentModel;

namespace SocketSend2
{
#region EventHandling    
    public delegate void StatusReadEventHandler(object sender, StatusReadEventArgs bre);
    public class StatusReadEventArgs : EventArgs
    {

#region Fields
        public bool bStatusConnected;
        public string strMessage;
#endregion

#region Constructors
        public StatusReadEventArgs(bool bStatus, string sMessage)
        {
            this.bStatusConnected = bStatus;
            this.strMessage = sMessage;
        }
        #endregion
#region Methods
        ~StatusReadEventArgs()
        {
        }
#endregion
    }
#endregion
    public class pingutil:Component
    {
        //threading stuff
        private bool m_bRunThread = false;
        private System.Threading.Thread t2;
        private bool m_safeToCloseGUI = true;
#if USES_EVENT_PUBLISHING
#region EventHandling
        /// <summary>
        /// this is the event that will be fired for status updates
        /// </summary>
        public event StatusReadEventHandler StatusRead;
        private void SendStatusUpdate(bool status, string msg)
        {
            StatusReadEventArgs statusReadEventArgs1;
            //test, if anyone is listening
            if (this.StatusRead == null)
            {
                return;
            }
            statusReadEventArgs1 = new StatusReadEventArgs(status, msg);
            this.StatusRead(this, statusReadEventArgs1);
        }
        //########################## usage:
        /*
            //in Form1() init
           ...
            InitializeComponent();
            //start the ping thread
            mThread = new pingutil(this);
            //ad the event handler to get notifications of the thread
            mThread.StatusRead += new StatusReadEventHandler(mThread_StatusRead);
           ...
        
        //anywhere in your UI Form code
        void mThread_StatusRead(object sender, StatusReadEventArgs sre)
        {
            this.txtConnect.Text = sre.strMessage;
            if (sre.strMessage.StartsWith("not"))
                txtConnect.BackColor = Color.LightPink;
            else
                txtConnect.BackColor = Color.LightGreen;
        }
        */
#endregion
#endif
#region ICMP helper stuff
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private struct ICMP_OPTIONS
        {
            public Byte Ttl;
            public Byte Tos;
            public Byte Flags;
            public Byte OptionsSize;
            public IntPtr OptionsData;
        };

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private struct ICMP_ECHO_REPLY
        {
            public int Address;
            public int Status;
            public int RoundTripTime;
            public Int16 DataSize;
            public Int16 Reserved;
            public IntPtr DataPtr;
            public ICMP_OPTIONS Options;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 250)]
            public String Data;
        }

        [DllImport("iphlpapi.dll", SetLastError = true)]
        private static extern IntPtr IcmpCreateFile();
        [DllImport("iphlpapi.dll", SetLastError = true)]
        private static extern bool IcmpCloseHandle(IntPtr handle);
        [DllImport("iphlpapi.dll", SetLastError = true)]
        private static extern Int32 IcmpSendEcho(IntPtr icmpHandle, Int32 destinationAddress, String requestData, Int32 requestSize, ref ICMP_OPTIONS requestOptions, ref ICMP_ECHO_REPLY replyBuffer, Int32 replySize, Int32 timeout);
#endregion
        private Form1 m_Form=null;
        private myConfig mConfig;
        private bool m_bLastStatus =false;
        public bool bLastStatus 
        {
            get{return m_bLastStatus;}
        }
#if USES_EVENT_PUBLISHING
        public pingutil()
        {
            mConfig = new myConfig();
            t2 = new System.Threading.Thread(new System.Threading.ThreadStart(threadProc2));
            t2.Priority = System.Threading.ThreadPriority.BelowNormal;
            t2.Start();
        }
#else
        public pingutil(Form1 theForm)
        {
            m_Form = theForm;
            mConfig = m_Form.mConfig; //get a ref to config
            t2 = new System.Threading.Thread(new System.Threading.ThreadStart(threadProc2));
            t2.Priority = System.Threading.ThreadPriority.BelowNormal;
            t2.Start();
        }
#endif
        private void threadProc2()
        {
            //myConfig mConfig=new myConfig();
            string sIP;
            bRunThread = true;
            m_safeToCloseGUI = false;
            updateGUI("ping started");
            int iReply = 0;
            m_safeToCloseGUI = false;
            while (bRunThread){
                try
                {
                    sIP = mConfig.sIpAddr;
                    IPAddress ip = IPAddress.Parse(sIP);
                    iReply = Ping(ip);
                    m_bLastStatus = (iReply > 0);
                    if (iReply > 0)
                    {
#if USES_EVENT_PUBLISHING
                        SendStatusUpdate(m_bLastStatus, "connected");
#else
                        if (m_Form!=null)
                            m_Form.Invoke(m_Form.myUpdateTextBox, new object[] { "connected" });
#endif
                    }
                    else
                    {
#if USES_EVENT_PUBLISHING
                        SendStatusUpdate(m_bLastStatus, "not connected");
#else
                        if (m_Form != null)
                            m_Form.Invoke(m_Form.myUpdateTextBox, new object[] { "not connected" });
#endif
                    }
                    System.Threading.Thread.Sleep(1000);

                }
                catch (System.Threading.ThreadAbortException tx)
                {
                    System.Diagnostics.Debug.WriteLine("PingUtils: ThreadAbortException: " + tx.Message);
                    bRunThread = false;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("PingUtils: Exception: " + ex.Message);
                }
            }
            m_safeToCloseGUI = true;
        }

        public int Ping(IPAddress IP)
        {
            IntPtr ICMPHandle;
            Int32 iIP;
            String sData;
            ICMP_OPTIONS oICMPOptions = new ICMP_OPTIONS();
            ICMP_ECHO_REPLY ICMPReply = new ICMP_ECHO_REPLY();
            Int32 iReplies;

            ICMPHandle = IcmpCreateFile();
            iIP = BitConverter.ToInt32(IP.GetAddressBytes(), 0);
            sData = "x";
            oICMPOptions.Ttl = 255;

            iReplies = IcmpSendEcho(ICMPHandle, iIP,
                sData, sData.Length, ref oICMPOptions, ref ICMPReply,
                Marshal.SizeOf(ICMPReply), 30);

            IcmpCloseHandle(ICMPHandle);
            return iReplies;
        }
        public bool _safeToCloseGUI
        {
            get { lock (this) { return m_safeToCloseGUI; } }
        }

        public bool bRunThread
        {

            get { lock (this) { return m_bRunThread; } }
            set { lock (this) { m_bRunThread = value; } }
        }
        public void AbortThread(string s)
        {
            if (s == string.Empty)
                s = "Thread abort requested!";
            t2.Abort(s);
        }
        private void updateGUI(string s)
        {
            
            if (bRunThread && m_Form!=null)
                m_Form.Invoke(m_Form.myUpdateTextBox, new object[] { s });
        }

    }
}
