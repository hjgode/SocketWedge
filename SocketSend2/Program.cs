using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SocketSend2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            try
            {
                Application.Run(new Form1());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry, got an exception: " + ex.Message + "\r\nPlease contact author");
            }
        }
    }
}