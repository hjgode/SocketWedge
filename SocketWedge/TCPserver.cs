using System;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TCPServer
{
    class Server
    {
        private TcpListener tcpListener;
        private Thread listenThread;
        public bool bRunThread=true;
        private int m_iPort = 52401;
        //public Server()
        //{
        //    bRunThread = true;
        //    this.tcpListener = new TcpListener(IPAddress.Any, 52401);
        //    this.listenThread = new Thread(new ThreadStart(ListenForClients));
        //}
        public Server(int iPort)
        {
            m_iPort = iPort;
        }
        public void StopServer()
        {
            this.listenThread.Abort();
            this.tcpListener.Stop();
            this.tcpListener = null;
        }

        public void StartServer()
        {
            this.tcpListener = new TcpListener(IPAddress.Any, m_iPort);
            this.listenThread = new Thread(new ThreadStart(ListenForClients));
            this.listenThread.Start();
        }
        private void ListenForClients()
        {
            this.tcpListener.Start();

            while (bRunThread)
            {
                try
                {
                    //blocks until a client has connected to the server
                    if (tcpListener.Pending())
                    {
                        TcpClient client = this.tcpListener.AcceptTcpClient();

                        //create a thread to handle communication
                        //with connected client
                        Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                        clientThread.Start(client);
                    }
                    else
                        System.Threading.Thread.Sleep(1000);
                }
                catch (System.Threading.ThreadAbortException tax)
                {
                    System.Diagnostics.Debug.WriteLine("ListenForClients: ThreadAbortException: "+tax.Message );
                    bRunThread = false;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("ListenForClients: Exception: "+ ex.Message);
                }
            }
            this.tcpListener.Stop();
        }

        private void HandleClientComm(object client)
        {
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();
            ASCIIEncoding encoder = new ASCIIEncoding();

            byte[] message = new byte[4096];
            int bytesRead;

            while (bRunThread)
            {
                bytesRead = 0;

                try
                {
                    //blocks until a client sends a message
                    bytesRead = clientStream.Read(message, 0, 4096);
                    byte[] bytesMessage = new byte[bytesRead];
                    Array.Copy(message, bytesMessage, bytesRead);
                    System.Diagnostics.Debug.WriteLine(encoder.GetString(message, 0, bytesRead));
                    sendKeyData(encoder.GetString(message, 0, bytesRead));
                    //echo message
                    //NetworkStream clientStream = tcpClient.GetStream();
                    //ASCIIEncoding encoder = new ASCIIEncoding();
                    //byte[] buffer = encoder.GetBytes("Hello Client!");
                    clientStream.Write(bytesMessage, 0, bytesMessage.Length);
                    clientStream.Flush();
                    System.Diagnostics.Debug.WriteLine("echo send");

                }
                catch (System.Threading.ThreadAbortException tax)
                {
                    System.Diagnostics.Debug.WriteLine("HandleClientComm: ThreadAbortException: " + tax.Message);
                    bRunThread = false;
                }
                catch
                {
                    //a socket error has occured
                    break;
                }

                if (bytesRead == 0)
                {
                    //the client has disconnected from the server
                    break;
                }

                //message has successfully been received
                //System.Diagnostics.Debug.WriteLine(encoder.GetString(message, 0, bytesRead));
            }

            tcpClient.Close();
        }

        private string m_sWindowClass = "";
        public string sWindowClass
        {
            set { m_sWindowClass = value; }
        }
        private string m_sWindowTitle="";
        public string sWindowTitle
        {
            set { m_sWindowTitle = value; }
        }
        private string m_sPreAmble="";
        public string sPreAmble
        {
            set { m_sPreAmble = value; }
        }
        private string m_sPostAmble = "";
        public string sPostAmble
        {
            set { m_sPostAmble = value; }
        }

        // Send a series of key presses to the Calculator application.
        private void sendKeyData(string s)
        {
            // Get a handle to the Calculator application. The window class
            // and window name were obtained using the Spy++ tool.
            IntPtr windowHandle=IntPtr.Zero;
            if(m_sWindowClass.Length>0 && m_sWindowTitle.Length>0)
                windowHandle = utils1.FindWindow(m_sWindowClass, m_sWindowTitle);
            else if (m_sWindowClass.Length == 0 && m_sWindowTitle.Length > 0)
                windowHandle = utils1.FindWindow(IntPtr.Zero, m_sWindowTitle);
            else if(m_sWindowClass.Length > 0 && m_sWindowTitle.Length == 0)
                windowHandle = utils1.FindWindow(m_sWindowClass, IntPtr.Zero);

            // Verify that Calculator is a running process.
            if (windowHandle == IntPtr.Zero)
            {
                System.Diagnostics.Debug.WriteLine("Window not found: '" +m_sWindowClass+"', '"+m_sWindowTitle+"'");
                return;
            }

            // Make found window the foreground application and send it 
            // a set of Keys.
            utils1.SetForegroundWindow(windowHandle);

            if (m_sPreAmble.Length > 0)
            {
                Byte[] bPre = Utility.HexEncoding.FromHexedString(m_sPreAmble);
                Keybord.SendKeys(bPre);
            }
            Keybord.SendKeys(s);
            if (m_sPostAmble.Length > 0)
            {
                //Keybord.SendKeys(m_sPostAmble);
                Byte[] bPost = Utility.HexEncoding.FromHexedString(m_sPostAmble);
                Keybord.SendKeys(bPost);
            }
            //SendKeys.SendWait("=");
        }
        //============================================================================

    }

}