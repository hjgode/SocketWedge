using System;
using System.Collections.Generic;
using System.Text;

namespace SocketSend2
{
    public class LoggerSimple
    {
        private string m_filename = "";
        private int m_iLogLevel = 1;
        public LoggerSimple()
        {
            myConfig mConfig = new myConfig();
            m_iLogLevel = mConfig.iLogging;
            string AppPath;
            AppPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            if (!AppPath.EndsWith(@"\"))
                AppPath += @"\";
            string sAppname = System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            m_filename = AppPath + sAppname + ".log.txt";
        }
        public LoggerSimple(string sFilename)
        {
            this.m_filename = sFilename;
        }
        public void log(string sMessage)
        {
            if (m_iLogLevel == 0)
                return;
            try
            {
                using (System.IO.StreamWriter w = System.IO.File.AppendText(m_filename))
                {
                    w.Write("{0}: ", DateTime.Now.ToShortTimeString());
                    w.WriteLine(sMessage);
                    // Close the writer and underlying file.
                    w.Flush();
                    w.Close();
                }
            }
            catch (System.IO.IOException iox)
            {
                System.Windows.Forms.MessageBox.Show("IOException in log(): " + iox.Message);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Exception in log(): " + ex.Message);
            }
        }
    }
}
