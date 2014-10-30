using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SocketSend2
{
    public partial class MsgBox : Form
    {
        public string btnOKtext
        {
            set { this.btnOK.Text = value; }
        }
        public string btnCANCELtext
        {
            set { this.btnCancel.Text = value; }
        }
        public MsgBox(string sText)
        {
            this.KeyUp += new KeyEventHandler(MsgBox_KeyUp);
            InitializeComponent();
            lblMsg.Text = sText;
        }

        void MsgBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }
    }
}