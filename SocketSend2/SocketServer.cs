using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace SocketSend2
{
    class SocketServer:IDisposable
    {
        private Form1 m_Form = null;
        //threading stuff
        private bool m_bRunThread = false;
        private System.Threading.Thread t2;
        private bool m_safeToCloseGUI = true;
        private string m_sIP = "192.168.128.51";

        public string sIP
        {
            get { return m_sIP; }
            set { m_sIP = value; }
        }
        private int m_iPort = 52401;
        public int iPort
        {
            get { return m_iPort; }
            set { m_iPort = value; }
        }
        private string m_sDataToSend;
        public string sDataToSend
        {
            set { m_sDataToSend = value; }
        }
        private bool m_bLastStatus = false;
        public bool bLastStatus
        {
            get { return m_bLastStatus; }
        }
        public SocketServer(Form1 theForm)
        {
            m_Form = theForm;
            startServer();
        }
        public SocketServer(Form1 theForm, string sIP)
        {
            m_Form = theForm;
            m_sIP = sIP;
            startServer();
        }
        public SocketServer(Form1 theForm, string sIP, int iPort)
        {
            m_Form = theForm;
            m_sIP = sIP;
            m_iPort = iPort;
            startServer();
        }
        public void Dispose()
        {
            stopServer();
        }

        void startServer()
        {
            bRunThread = true;
            t2 = new System.Threading.Thread(new System.Threading.ThreadStart(threadProc2));
            t2.Priority = System.Threading.ThreadPriority.BelowNormal;
            t2.Start();
        }
        void stopServer()
        {
            if (t2 != null)
            {
                bRunThread = false;
                System.Threading.Thread.Sleep(1000);
                if (t2 != null)
                {
                    AbortThread("restarting");
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }
        void restartServer()
        {
            stopServer();
            if (t2 == null)
                startServer();
        }

        private void threadProc2()
        {
            //myConfig mConfig = new myConfig();
            int iReply = 0;
            bRunThread = true;
            m_safeToCloseGUI = false;
            updateGUI("SocketServer thread started");
            while (bRunThread)
            {
                try
                {
                    System.Net.IPAddress localIPAddr = System.Net.IPAddress.Parse(m_sIP);
                    // Listen on the local IP address by creating an endpoint
                    System.Net.IPEndPoint localIpEndPoint = new System.Net.IPEndPoint(localIPAddr, m_iPort);
                    System.Net.Sockets.TcpListener tcpServer = new TcpListener(localIpEndPoint);
                    // Start listening synchronously
                    tcpServer.Start();

                    if (tcpServer.Pending())
                    {
                        // Get the client socket when a request comes in
                        Socket tcpClient = tcpServer.AcceptSocket();

                        // Make sure the client is connected
                        if (tcpClient.Connected)
                        {
                            // Create a network stream to send data to the client
                            NetworkStream clientStream = new NetworkStream(tcpClient);

                            // Write some data to the stream
                            if (m_sDataToSend.Length > 0)
                            {
                                byte[] serverBytes = System.Text.Encoding.ASCII.GetBytes(
                                   this.m_sDataToSend);
                                clientStream.Write(serverBytes, 0, serverBytes.Length);
                                iReply = m_sDataToSend.Length;
                                m_sDataToSend = "";
                            }
                            else
                                iReply = 0;
                            // Immediately disconnect the client
                            tcpClient.Shutdown(SocketShutdown.Both);
                            tcpClient.Close();
                        }
                    }
                    else
                    {
                        tcpServer.Stop();
                        System.Threading.Thread.Sleep(500);
                    }
                }
                catch (System.Threading.ThreadAbortException tx)
                {
                    System.Diagnostics.Debug.WriteLine("SocketServer: ThreadAbortException: " + tx.Message);
                    bRunThread = false;
                }
                catch (System.Net.Sockets.SocketException sx)
                {
                    System.Diagnostics.Debug.WriteLine("SocketException: " + sx.Message);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message);
                }
                m_bLastStatus = (iReply > 0);
                if (iReply > 0)
                {
                    if (m_Form != null)
                        m_Form.Invoke(m_Form.myUpdateTextBox, new object[] { "data sended" });
                }
                else
                {
                    if (m_Form != null)
                        m_Form.Invoke(m_Form.myUpdateTextBox, new object[] { "not sended" });
                }
                System.Threading.Thread.Sleep(10000);
            }
            m_safeToCloseGUI = true;
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

            if (bRunThread && m_Form != null)
                m_Form.Invoke(m_Form.myUpdateTextBox, new object[] { s });
        }
    }
}
