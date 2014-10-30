using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace SocketWedge
{
    public partial class Form1 : Form
    {
        private TCPServer.Server myTCPserver;
        private string m_sApplication = "c:\\windows\\notepad.exe";
        public Form1()
        {
            InitializeComponent();
            fillIPlist();
        }
        void fillIPlist()
        {
            List<String> sList = utils1.getLocalIPaddresses();
            foreach (string s in sList)
                txtIPlist.Text += s + "\r\n";
        }
        private bool bServerStarted = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if (bServerStarted)
            {
                //stop server
                myTCPserver.bRunThread = false;
                myTCPserver.StopServer();
                enableControls(true);
            }
            else
            {
                //start server
                myTCPserver = new TCPServer.Server((int)numericUpDown1.Value);
                myTCPserver.sPostAmble = txtPostAmble.Text;
                myTCPserver.sPreAmble = txtPreAmble.Text;
                myTCPserver.sWindowClass = txtWindowsClass.Text;
                myTCPserver.sWindowTitle = txtWindowTitle.Text;
                myTCPserver.StartServer();
                enableControls(false);

                //start App?
                if (chkStartApp.Checked)
                {
                    //look if app is already running
                    IntPtr windowHandle = IntPtr.Zero;
                    if (txtWindowsClass.Text.Length > 0 && txtWindowTitle.Text.Length > 0)
                        windowHandle = utils1.FindWindow(txtWindowsClass.Text, txtWindowTitle.Text);
                    else if (txtWindowsClass.Text.Length == 0 && txtWindowTitle.Text.Length > 0)
                        windowHandle = utils1.FindWindow(IntPtr.Zero, txtWindowTitle.Text);
                    else if (txtWindowsClass.Text.Length > 0 && txtWindowTitle.Text.Length == 0)
                        windowHandle = utils1.FindWindow(txtWindowsClass.Text, IntPtr.Zero);

                    // Verify that xx is a running process.
                    if (windowHandle == IntPtr.Zero)
                    {
                        //Start the app
                        System.Diagnostics.Process.Start(m_sApplication);
                    }
                }
            }
        }

        private void enableControls(bool bEnable)
        {
            txtPostAmble.Enabled = bEnable;
            txtPreAmble.Enabled = bEnable;
            txtWindowsClass.Enabled = bEnable;
            txtWindowTitle.Enabled = bEnable;
            numericUpDown1.Enabled = bEnable;
            txtApplication.Enabled = bEnable;
            btnApplication.Enabled = bEnable;
            chkStartApp.Enabled = bEnable;
            if (bEnable)
                button1.Text = "Start Server";
            else
                button1.Text = "Stop Server";
            bServerStarted = !bEnable;
            chkStartApp_CheckedChanged(null, null);
        }
        private void btnApplication_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            ofd.Filter = "Executable files (*.exe)|*.exe|All files (*.*)|*.*";
            ofd.FilterIndex = 0;
            ofd.InitialDirectory = utils1.getWindowsDir();// "C:\\Windows";
            ofd.Multiselect = false;
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string sPath = ofd.FileName;
                m_sApplication = ofd.FileName;
                txtApplication.Text = m_sApplication;
            }
        }

        private void chkStartApp_CheckedChanged(object sender, EventArgs e)
        {
            txtApplication.Enabled = chkStartApp.Checked;
            btnApplication.Enabled = chkStartApp.Checked;
        }
    }
}