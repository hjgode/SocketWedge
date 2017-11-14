using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;

using System.Net.Sockets;
using System.Net;

namespace SocketSendWedge
{
    class SocketClient:IDisposable
    {
        Queue<String> mQueue;
        object lockQueue = new object();
        Thread myThreadSocket = null;
        Socket sendSocket = null;
        bool bStopSocketThread = false;

        IPAddress mIpAddress = IPAddress.Parse("192.168.56.1");//ActiveSync
        public SocketClient()
        {
            start();
        }

        public SocketClient(IPAddress ip)
        {
            mIpAddress = ip;
            start();
        }

        void start()
        {
            mQueue = new Queue<string>();
            myThreadSocket = new Thread(socketThread);
            myThreadSocket.Start();
        }

        public void Dispose()
        {
            //Stop thread
            bStopSocketThread = true;
            if (myThreadSocket != null)
            {
                myThreadSocket.Abort();
                Thread.Sleep(100);
                myThreadSocket = null;
            }
        }

        public void sendString(String s)
        {
            lock (lockQueue)
            {
                onStatusMessage(new StatusMessageArgs(Status.pending, s));
                mQueue.Enqueue(s);
            }
        }

        /// <summary>
        /// send enqueued objects via UDP broadcast
        /// </summary>
        void socketThread()
        {
            System.Diagnostics.Debug.WriteLine("Entering socketThread ...");
            String s="";
            try
            {
                const int ProtocolPort = 52401;
                sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //sendSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, 1000);
                //sendSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendBuffer, 8192);

                IPAddress sendTo = mIpAddress;// IPAddress.Broadcast;// IPAddress.Parse("192.168.128.255");  //local broadcast
                EndPoint sendEndPoint = new IPEndPoint(sendTo, ProtocolPort);
                System.Diagnostics.Debug.WriteLine("Socket ready to send");
                sendSocket.Connect(sendEndPoint);

                while (!bStopSocketThread)
                {
                    //block until released by capture
                    lock (lockQueue)
                    {
                        //if (procStatsQueue.Count > 0)
                        while (mQueue.Count > 0)
                        {
                            s = mQueue.Dequeue();
                            byte[] buf = System.Text.Encoding.GetEncoding(1252).GetBytes(s);
                            sendSocket.Send(buf);
                            onStatusMessage(new StatusMessageArgs(Status.success, s));
                            System.Diagnostics.Debug.WriteLine("Socket send " + buf.Length.ToString() + " bytes");
                            System.Threading.Thread.Sleep(2);
                        }
                    }
                    Thread.Sleep(1000);
                }

            }
            catch (ThreadAbortException ex)
            {
                System.Diagnostics.Debug.WriteLine("ThreadAbortException: socketThread(): " + ex.Message);
            }
                catch(SocketException ex){
                    System.Diagnostics.Debug.WriteLine("SocketException: socketThread(): " + ex.Message);
                    onStatusMessage(new StatusMessageArgs(Status.failed,s));
                }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: socketThread(): " + ex.Message);
            }
            System.Diagnostics.Debug.WriteLine("socketThread ENDED");
        }

        public delegate void StatusMessageEventHandler(object sender, StatusMessageArgs args);
        public event StatusMessageEventHandler StatusMessageEvent;
        void onStatusMessage(StatusMessageArgs args)
        {
            if (this.StatusMessageEvent != null)
            {
                StatusMessageArgs a = args;
                this.StatusMessageEvent(this, a);
            }
        }
    }
}
