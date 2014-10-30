namespace SocketWedge
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtPostAmble = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPreAmble = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWindowsClass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtWindowTitle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.txtApplication = new System.Windows.Forms.TextBox();
            this.btnApplication = new System.Windows.Forms.Button();
            this.chkStartApp = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIPlist = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(213, 211);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "start TCP server";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtPostAmble
            // 
            this.txtPostAmble.Location = new System.Drawing.Point(171, 25);
            this.txtPostAmble.Name = "txtPostAmble";
            this.txtPostAmble.Size = new System.Drawing.Size(147, 20);
            this.txtPostAmble.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(170, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "PostAmble:";
            // 
            // txtPreAmble
            // 
            this.txtPreAmble.Location = new System.Drawing.Point(13, 25);
            this.txtPreAmble.Name = "txtPreAmble";
            this.txtPreAmble.Size = new System.Drawing.Size(147, 20);
            this.txtPreAmble.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "PreAmble:";
            // 
            // txtWindowsClass
            // 
            this.txtWindowsClass.Location = new System.Drawing.Point(13, 157);
            this.txtWindowsClass.Name = "txtWindowsClass";
            this.txtWindowsClass.Size = new System.Drawing.Size(147, 20);
            this.txtWindowsClass.TabIndex = 1;
            this.txtWindowsClass.Text = "Notepad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Window Class:";
            // 
            // txtWindowTitle
            // 
            this.txtWindowTitle.Location = new System.Drawing.Point(171, 157);
            this.txtWindowTitle.Name = "txtWindowTitle";
            this.txtWindowTitle.Size = new System.Drawing.Size(147, 20);
            this.txtWindowTitle.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(170, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Window Title:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(13, 214);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            65562,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(107, 20);
            this.numericUpDown1.TabIndex = 3;
            this.numericUpDown1.Value = new decimal(new int[] {
            52401,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Listen Port:";
            // 
            // txtApplication
            // 
            this.txtApplication.Enabled = false;
            this.txtApplication.Location = new System.Drawing.Point(13, 118);
            this.txtApplication.Name = "txtApplication";
            this.txtApplication.Size = new System.Drawing.Size(268, 20);
            this.txtApplication.TabIndex = 1;
            this.txtApplication.Text = "Notepad.exe";
            // 
            // btnApplication
            // 
            this.btnApplication.Enabled = false;
            this.btnApplication.Location = new System.Drawing.Point(287, 118);
            this.btnApplication.Name = "btnApplication";
            this.btnApplication.Size = new System.Drawing.Size(33, 19);
            this.btnApplication.TabIndex = 4;
            this.btnApplication.Text = "...";
            this.btnApplication.UseVisualStyleBackColor = true;
            this.btnApplication.Click += new System.EventHandler(this.btnApplication_Click);
            // 
            // chkStartApp
            // 
            this.chkStartApp.AutoSize = true;
            this.chkStartApp.Location = new System.Drawing.Point(13, 95);
            this.chkStartApp.Name = "chkStartApp";
            this.chkStartApp.Size = new System.Drawing.Size(106, 17);
            this.chkStartApp.TabIndex = 5;
            this.chkStartApp.Text = "Start Application:";
            this.chkStartApp.UseVisualStyleBackColor = true;
            this.chkStartApp.CheckedChanged += new System.EventHandler(this.chkStartApp_CheckedChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(12, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(303, 32);
            this.label6.TabIndex = 6;
            this.label6.Text = "Use \\xHH with HH being a hex to insert special chars like Return (\\x0d) or TABs (" +
                "\\x09)";
            // 
            // txtIPlist
            // 
            this.txtIPlist.Location = new System.Drawing.Point(171, 257);
            this.txtIPlist.Multiline = true;
            this.txtIPlist.Name = "txtIPlist";
            this.txtIPlist.ReadOnly = true;
            this.txtIPlist.Size = new System.Drawing.Size(147, 56);
            this.txtIPlist.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 328);
            this.Controls.Add(this.txtIPlist);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkStartApp);
            this.Controls.Add(this.btnApplication);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtWindowTitle);
            this.Controls.Add(this.txtPreAmble);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtApplication);
            this.Controls.Add(this.txtWindowsClass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPostAmble);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "SocketWedge 1.0";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtPostAmble;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPreAmble;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtWindowsClass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtWindowTitle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtApplication;
        private System.Windows.Forms.Button btnApplication;
        private System.Windows.Forms.CheckBox chkStartApp;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIPlist;
    }
}

