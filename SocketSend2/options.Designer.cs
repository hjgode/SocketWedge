namespace SocketSend2
{
    partial class options
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
            this.mnuCancel = new System.Windows.Forms.MenuItem();
            this.mnuOK = new System.Windows.Forms.MenuItem();
            this.iIP1 = new System.Windows.Forms.NumericUpDown();
            this.iIP2 = new System.Windows.Forms.NumericUpDown();
            this.iIP3 = new System.Windows.Forms.NumericUpDown();
            this.iIP4 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.iMinLen = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.iLogLevel = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.iPort = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.mnuCancel);
            this.mainMenu1.MenuItems.Add(this.mnuOK);
            // 
            // mnuCancel
            // 
            this.mnuCancel.Text = "Cancel";
            this.mnuCancel.Click += new System.EventHandler(this.mnuCancel_Click);
            // 
            // mnuOK
            // 
            this.mnuOK.Text = "OK";
            this.mnuOK.Click += new System.EventHandler(this.mnuOK_Click);
            // 
            // iIP1
            // 
            this.iIP1.Location = new System.Drawing.Point(1, 32);
            this.iIP1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.iIP1.Name = "iIP1";
            this.iIP1.Size = new System.Drawing.Size(58, 22);
            this.iIP1.TabIndex = 0;
            this.iIP1.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // iIP2
            // 
            this.iIP2.Location = new System.Drawing.Point(60, 32);
            this.iIP2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.iIP2.Name = "iIP2";
            this.iIP2.Size = new System.Drawing.Size(58, 22);
            this.iIP2.TabIndex = 0;
            // 
            // iIP3
            // 
            this.iIP3.Location = new System.Drawing.Point(120, 32);
            this.iIP3.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.iIP3.Name = "iIP3";
            this.iIP3.Size = new System.Drawing.Size(58, 22);
            this.iIP3.TabIndex = 0;
            // 
            // iIP4
            // 
            this.iIP4.Location = new System.Drawing.Point(180, 32);
            this.iIP4.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.iIP4.Name = "iIP4";
            this.iIP4.Size = new System.Drawing.Size(58, 22);
            this.iIP4.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 18);
            this.label1.Text = "Server IP:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 18);
            this.label2.Text = "Server Port:";
            // 
            // iMinLen
            // 
            this.iMinLen.Location = new System.Drawing.Point(12, 157);
            this.iMinLen.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.iMinLen.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.iMinLen.Name = "iMinLen";
            this.iMinLen.Size = new System.Drawing.Size(104, 22);
            this.iMinLen.TabIndex = 0;
            this.iMinLen.Value = new decimal(new int[] {
            24,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 18);
            this.label3.Text = "Minimal Data Length:";
            // 
            // iLogLevel
            // 
            this.iLogLevel.Location = new System.Drawing.Point(12, 220);
            this.iLogLevel.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.iLogLevel.Name = "iLogLevel";
            this.iLogLevel.Size = new System.Drawing.Size(104, 22);
            this.iLogLevel.TabIndex = 0;
            this.iLogLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 18);
            this.label4.Text = "Log Level:";
            // 
            // iPort
            // 
            this.iPort.Location = new System.Drawing.Point(12, 94);
            this.iPort.MaxLength = 5;
            this.iPort.Name = "iPort";
            this.iPort.Size = new System.Drawing.Size(103, 21);
            this.iPort.TabIndex = 5;
            this.iPort.Text = "52401";
            this.iPort.KeyDown += new System.Windows.Forms.KeyEventHandler(this.iPort_KeyDown);
            this.iPort.KeyUp += new System.Windows.Forms.KeyEventHandler(this.iPort_KeyUp);
            this.iPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.iPort_KeyPress);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(192, 246);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 21);
            this.label5.Text = "v1.1";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.ControlBox = false;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.iPort);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.iLogLevel);
            this.Controls.Add(this.iIP4);
            this.Controls.Add(this.iMinLen);
            this.Controls.Add(this.iIP3);
            this.Controls.Add(this.iIP2);
            this.Controls.Add(this.iIP1);
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "options";
            this.Text = "SocketSend Options";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem mnuCancel;
        private System.Windows.Forms.MenuItem mnuOK;
        private System.Windows.Forms.NumericUpDown iIP1;
        private System.Windows.Forms.NumericUpDown iIP2;
        private System.Windows.Forms.NumericUpDown iIP3;
        private System.Windows.Forms.NumericUpDown iIP4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown iMinLen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown iLogLevel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox iPort;
        private System.Windows.Forms.Label label5;
    }
}