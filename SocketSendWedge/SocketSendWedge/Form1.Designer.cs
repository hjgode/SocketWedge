namespace SocketSendWedge
{
    partial class SocketWedge
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.mainMenu2 = new System.Windows.Forms.MainMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(24, 33);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(185, 23);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Hello World";
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(10, 132);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(215, 128);
            this.txtLog.TabIndex = 1;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(68, 75);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(101, 33);
            this.btnTest.TabIndex = 2;
            this.btnTest.Text = "Test";
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // mainMenu2
            // 
            this.mainMenu2.MenuItems.Add(this.menuItem1);
            // 
            // menuItem1
            // 
            this.menuItem1.MenuItems.Add(this.menuItem2);
            this.menuItem1.Text = "File";
            // 
            // menuItem2
            // 
            this.menuItem2.Text = "Exit";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // SocketWedge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 275);
            this.ControlBox = false;
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.textBox1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Menu = this.mainMenu2;
            this.MinimizeBox = false;
            this.Name = "SocketWedge";
            this.Text = "SocketWedge";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SocketWedge_Closing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SocketWedge_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.MainMenu mainMenu2;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
    }
}

