using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SocketSend2
{
    public partial class options : Form
    {
        myConfig mConfig;
        public options()
        {
            InitializeComponent();
            mConfig = new myConfig();
            string theIpAddr = mConfig.sIpAddr;
            uint thePort = mConfig.uPort;
            int theMinLen = mConfig.minLength;
            int theLogLevel = mConfig.iLogging;

            //
            try
            {
                char[] mySep = new char[1]; mySep[0]='.';
                string[] sSplit = theIpAddr.Split(mySep);
                if (sSplit.Length == 4)
                {
                    iIP1.Value = Convert.ToInt16(sSplit[0]);
                    iIP2.Value = Convert.ToInt16(sSplit[1]);
                    iIP3.Value = Convert.ToInt16(sSplit[2]);
                    iIP4.Value = Convert.ToInt16(sSplit[3]);
                }


                iPort.Text = thePort.ToString();
                iMinLen.Value = theMinLen;
                iLogLevel.Value = theLogLevel;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception in load options form: " + ex.Message);                
            }
        }

        private void mnuOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            mConfig.iLogging = (int)iLogLevel.Value;
            mConfig.minLength = (int)iMinLen.Value;
            mConfig.uPort = Convert.ToUInt16(iPort.Text);

            string sTemp = iIP1.Value.ToString() + "." + iIP2.Value.ToString() + "." + iIP3.Value.ToString() + "." + iIP4.Value.ToString();
            mConfig.sIpAddr = sTemp;

            mConfig.writeReg();
            this.Close();
        }

        private void mnuCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void iPort_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Back && e.KeyCode != Keys.Delete && e.KeyCode != Keys.Left && e.KeyCode != Keys.Right)
            {
                if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
                    e.Handled = true;
            }
            else
                e.Handled = false;
        }

        private void iPort_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Back && e.KeyCode != Keys.Delete && e.KeyCode != Keys.Left && e.KeyCode != Keys.Right)
            {
                if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
                    e.Handled = true;
            }
            else
                e.Handled = false;
        }

        private void iPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                if (e.KeyChar < '0' || e.KeyChar > '9')
                    e.Handled = true;
            }
            else
                e.Handled = false;
        }
    }
}