namespace SocketSend2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.mnuExit = new System.Windows.Forms.MenuItem();
            this.mnuOptions = new System.Windows.Forms.MenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTransmit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.txtConnect = new System.Windows.Forms.Label();
            this.txtIPlist = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.mnuExit);
            this.mainMenu1.MenuItems.Add(this.mnuOptions);
            // 
            // mnuExit
            // 
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mnuOptions
            // 
            this.mnuOptions.Text = "Options";
            this.mnuOptions.Click += new System.EventHandler(this.mnuOptions_Click);
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.AcceptsTab = true;
            this.textBox1.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);
            this.textBox1.Location = new System.Drawing.Point(3, 25);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(234, 38);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "00112233445566778899AABB";
            this.textBox1.WordWrap = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 17);
            this.label1.Text = "Data to transmit:";
            // 
            // btnTransmit
            // 
            this.btnTransmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnTransmit.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnTransmit.Location = new System.Drawing.Point(125, 120);
            this.btnTransmit.Name = "btnTransmit";
            this.btnTransmit.Size = new System.Drawing.Size(111, 41);
            this.btnTransmit.TabIndex = 2;
            this.btnTransmit.Text = "TRANSMIT";
            this.btnTransmit.Click += new System.EventHandler(this.btnTransmit_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnClear.Location = new System.Drawing.Point(6, 120);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(111, 41);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "CLEAR";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblError
            // 
            this.lblError.Location = new System.Drawing.Point(6, 76);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(230, 41);
            // 
            // txtConnect
            // 
            this.txtConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtConnect.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtConnect.Location = new System.Drawing.Point(48, 174);
            this.txtConnect.Name = "txtConnect";
            this.txtConnect.Size = new System.Drawing.Size(147, 20);
            this.txtConnect.Text = "not connected";
            this.txtConnect.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtIPlist
            // 
            this.txtIPlist.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.txtIPlist.Location = new System.Drawing.Point(125, 206);
            this.txtIPlist.Multiline = true;
            this.txtIPlist.Name = "txtIPlist";
            this.txtIPlist.ReadOnly = true;
            this.txtIPlist.Size = new System.Drawing.Size(112, 59);
            this.txtIPlist.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.ControlBox = false;
            this.Controls.Add(this.txtIPlist);
            this.Controls.Add(this.txtConnect);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnTransmit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.KeyPreview = true;
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "SocketSend2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem mnuExit;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTransmit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.MenuItem mnuOptions;
        private System.Windows.Forms.Label txtConnect;
        private System.Windows.Forms.TextBox txtIPlist;
    }
}

