using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SocketSendWedge
{
    public partial class SocketWedge : Form
    {
        SocketClient sockClient = new SocketClient();

        hsmBarcodeReader barcodeReader = null;

        public SocketWedge()
        {
            InitializeComponent();
            sockClient.StatusMessageEvent += new SocketClient.StatusMessageEventHandler(sockClient_StatusMessageEvent);
            sockClient.sendString("Hallo");

            barcodeReader = new hsmBarcodeReader();
            barcodeReader.ScanReady += new BarcodeEventHandler(barcodeReader_ScanReady);
        }

        void barcodeReader_ScanReady(object sender, BarcodeEventArgs e)
        {
            setText(e.Text);
            sockClient.sendString(e.Text);
        }

        void sockClient_StatusMessageEvent(object sender, StatusMessageArgs args)
        {
            addLog(args.status.ToString() + ": " + args.msg);
            if (args.status == Status.success)
                setText("");
        }

        delegate void SetTextCallback2(string text);
        void setText(string t)
        {
            if (this.txtLog.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(addLog);
                this.Invoke(d, new object[] { t });
            }
            else
            {
                textBox1.Text= t;
            }
        }
        delegate void SetTextCallback(string text);
        public void addLog(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.txtLog.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(addLog);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                if (txtLog.Text.Length > 2000)
                    txtLog.Text = "";
                txtLog.Text += text + "\r\n";
                txtLog.SelectionLength = 0;
                txtLog.SelectionStart = txtLog.Text.Length - 1;
                txtLog.ScrollToCaret();
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //if (textBox1.Text.Length > 0)
            //    sockClient.sendString(textBox1.Text);
            barcodeReader.startScan();
        }

        private void SocketWedge_Closing(object sender, CancelEventArgs e)
        {
            sockClient.StatusMessageEvent -= sockClient_StatusMessageEvent;
            sockClient.Dispose();
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SocketWedge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == (Keys)193)
                barcodeReader.startScan();
        }
    }
}