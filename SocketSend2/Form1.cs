//#define USES_EVENT_PUBLISHING
//use the above if you can fix the exception in Form1, when setting the textbox1.text
//See project properties if there is already a conditional symbol USES_EVENT_PUBLISHING in the
//build settings
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using Intermec.Device.Audio;

namespace SocketSend2
{
    public partial class Form1 : Form
    {
        public LoggerSimple theLogger;
        public myConfig mConfig;
        private iAudio mAudio;

        //multithreading stuff
        public delegate void UpdateTextBox(string str);
        public UpdateTextBox myUpdateTextBox;
        private pingutil mThread;
        private SocketServer mSocketServer;
        public Form1()
        {
            InitializeComponent();
            theLogger = new LoggerSimple();
            theLogger.log("Logging started " + DateTime.Now.ToShortDateString());
            mConfig = new myConfig();
            this.KeyUp += new KeyEventHandler(Form1_KeyUp);
            try
            {
                mAudio = new iAudio();
            }
            catch (Exception ex)
            {
                theLogger.log("could not init iAudio: " + ex.Message);
            }

            //new delegate for thread update via Invoke
            myUpdateTextBox = new UpdateTextBox(UpdateTextBoxMethod);
            
#if USES_EVENT_PUBLISHING
            //start the ping thread
            mThread = new pingutil();
            //ad the event handler to get notifications of the thread
            mThread.StatusRead += new StatusReadEventHandler(mThread_StatusRead);
#else
            //start the ping thread
            mThread = new pingutil(this);
            //mSocketServer = new SocketServer(this);
            mSocketServer = new SocketServer(this, mConfig.sIpAddr, mConfig.uPort);
#endif
            fillIPlist();
        }
        void fillIPlist()
        {
            List<String> sList = utils1.getLocalIPaddresses();
            foreach (string s in sList)
                txtIPlist.Text += s + "\r\n";
        }
        public void mThread_StatusRead(object sender, StatusReadEventArgs sre)
        {
            UpdateTextBoxMethod(sre.strMessage);
        }
        //delegate is UpdateTextBox
        public void UpdateTextBoxMethod(string str)
        {
            if (InvokeRequired)
                Invoke(new UpdateTextBox(UpdateTextBoxMethod), str);
            else
            {
                string s = str;
                this.txtConnect.Text = s;
                if (str.StartsWith("not"))
                    txtConnect.BackColor = Color.LightPink;
                else
                    txtConnect.BackColor = Color.LightGreen;
                //win32utils.showWindow(this.Handle);
            }
        }

        void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnTransmit_Click(sender, e);
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            MsgBox mMsgBox = new MsgBox("Would you really like to exit?");
            mMsgBox.ShowDialog();
            if (mMsgBox.DialogResult == DialogResult.Cancel)
            {
                mMsgBox.Dispose();
                return;
            }
            else
                mMsgBox.Dispose();

            Cursor.Current = Cursors.WaitCursor;
            //save config
            mConfig.writeReg();
            //let the thread stop
            mSocketServer.AbortThread("mnu_Exit clicked");
            Application.DoEvents();
            mSocketServer.bRunThread = false;
            System.Threading.Thread.Sleep(1000);
            if (mSocketServer._safeToCloseGUI)
                System.Diagnostics.Debug.WriteLine("mSocketServer._safeToCloseGUI is true");
            else
                System.Diagnostics.Debug.WriteLine("mSocketServer._safeToCloseGUI is FALSE");
            //let the thread stop
            mThread.AbortThread("mnu_Exit clicked");
            Application.DoEvents();
            mThread.bRunThread = false;
            System.Threading.Thread.Sleep(1000);
            if (mThread._safeToCloseGUI)
                System.Diagnostics.Debug.WriteLine("mThread._safeToCloseGUI is true");
            else
                System.Diagnostics.Debug.WriteLine("mThread._safeToCloseGUI is FALSE");

            Cursor.Current = Cursors.Default;
            this.Close();
            Application.Exit();
        }

        private void btnTransmit_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                theLogger.log("btnTransmit_Click: textlength==0");
                lblError.Text = "No text, no transmit";
                mAudio.playBad();
                textBox1.Focus();
                return;
            }
            if (textBox1.Text.Length < mConfig.minLength)
            {
                theLogger.log("btnTransmit_Click: textlength<=minLength("+mConfig.minLength.ToString()+")");
                lblError.Text="Text to short. Need at least "+mConfig.minLength+" characters";
                mAudio.playGood();
                textBox1.Focus();
                return;
            }
            lblError.Text = "Trying to transmit...";

            mSocketServer.sDataToSend = textBox1.Text;

            Cursor.Current = Cursors.WaitCursor;
            textBox1.Enabled = false;
            mnuExit.Enabled = false;
            btnClear.Enabled = false;
            btnTransmit.Enabled = false;
            uint uRes = itc50comm.sendData(textBox1.Text);
            Cursor.Current = Cursors.Default;
            mnuExit.Enabled = true;
            btnClear.Enabled = true;
            btnTransmit.Enabled = true;
            textBox1.Enabled = true;
            lblError.Text = "";
            if (uRes == itc50comm.ITC_SUCCESS)
            {
                mAudio.playGood();
                theLogger.log("Transmit OK for '" + textBox1.Text + "' return code=0x"+uRes.ToString("x"));
                MsgBox myMsgBox = new MsgBox("There was no communication error. Please verify the transmission and confirm the transmit.");
                myMsgBox.BackColor = Color.Green;
                myMsgBox.btnOKtext = "CONFIRM";
                myMsgBox.btnCANCELtext = "ReTransmit";
                myMsgBox.ShowDialog();
                if (myMsgBox.DialogResult == DialogResult.OK)
                {
                    theLogger.log("...Transmit has been confirmed by user");
                    textBox1.Text = "";
                    textBox1.Focus();
                }
                else
                    theLogger.log("...Transmit has NOT been confirmed by user");

                myMsgBox.Dispose();
            }
            else
            {
                mAudio.playBad();
                theLogger.log("Transmit failed for '" + textBox1.Text + "' with error code=0x" + uRes.ToString("x"));
                MsgBox myMsgBox = new MsgBox("There was a communication error. Would you like to try a transmit gain? Otherwise the data will be cleared.");
                myMsgBox.BackColor = Color.Red;
                myMsgBox.btnOKtext = "Try Again";
                myMsgBox.btnCANCELtext = "Discard";
                myMsgBox.ShowDialog();
                if (myMsgBox.DialogResult == DialogResult.Cancel)
                { 
                    theLogger.log("...user declined to transmit again");
                    textBox1.Text = "";
                    textBox1.Focus();
                }
                else
                    theLogger.log("...user decided to possibly transmit again");
                myMsgBox.Dispose();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            MsgBox mMsgBox = new MsgBox("Please confirm clearing the data field");
            mMsgBox.ShowDialog();
            if (mMsgBox.DialogResult == DialogResult.Cancel)
            {
                mMsgBox.Dispose();
                return;
            }
            else
                mMsgBox.Dispose();
            //clear the input etc
            textBox1.Text = "";
            lblError.Text = "";
            textBox1.Focus();
        }

        private void mnuOptions_Click(object sender, EventArgs e)
        {

            options optDialog = new options();
            DialogResult d = optDialog.ShowDialog();
            optDialog.Dispose();
            if (d == DialogResult.OK)
            {
                mSocketServer.Dispose();
                mSocketServer = new SocketServer(this, mConfig.sIpAddr, mConfig.uPort);

            }
        }

    }
}