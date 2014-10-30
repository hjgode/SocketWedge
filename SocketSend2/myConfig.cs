using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace SocketSend2
{
    public class myConfig
    {
        private int m_minLength;
        public int minLength
        {
            get { return m_minLength; }
            set { m_minLength = value; }
        }
        private string m_sIPaddr;
        public string sIpAddr
        {
            get { return m_sIPaddr; }
            set { m_sIPaddr = value; }
        }

        private UInt16 m_uPort;
        public UInt16 uPort
        {
            get { return m_uPort; }
            set { m_uPort = value; }
        }
        private int m_iLogging;
        public int iLogging
        {
            get { return m_iLogging; }
            set { m_iLogging = value; }
        }

        public myConfig()
        {
            this.readReg();
        }

        //~myConfig()
        //{
        //    writeReg();
        //}
        private void readReg()
        {
            RegistryKey rk = Registry.LocalMachine.OpenSubKey("Software\\SocketSend");
            if (rk != null)
            {
                int iValue;
                try
                {
                    iValue = (int)rk.GetValue("minLength", 24);
                }
                catch (Exception)
                {
                    iValue = 24;
                }
                m_minLength = iValue;

                try
                {
                    iValue = (int)rk.GetValue("loglevel", 1);
                }
                catch (Exception)
                {
                    iValue = 1;
                }
                m_iLogging = iValue;

                string sValue;
                try
                {
                    sValue = (string)rk.GetValue("IPaddr", "169.254.2.2");

                }
                catch (Exception)
                {
                    sValue = "169.254.2.2";
                }
                m_sIPaddr = sValue;

                UInt16 uValue;
                try
                {
                    uValue = Convert.ToUInt16(rk.GetValue("port", 52401U));
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exception in readReg(port): " + ex.Message);
                    uValue = 52401;
                }
                m_uPort = uValue;
                rk.Close();
            }
            else
            {
                // default values
                m_iLogging = 1;
                m_minLength = 24;
                m_sIPaddr = "192.168.0.1";
                m_uPort = 52401;
                this.writeReg();
            }
        }
        public void writeReg(){
            RegistryKey rk = Registry.LocalMachine.CreateSubKey("Software\\SocketSend");
            if (rk != null)
            {
                int iValue=m_minLength;
                try{
                    rk.SetValue("minLength", iValue,RegistryValueKind.DWord);
                }
                catch(Exception){
                    System.Diagnostics.Debug.WriteLine("Exception in SetValue(minLength)");
                }

                iValue = m_iLogging;
                try{
                    rk.SetValue("loglevel", iValue,RegistryValueKind.DWord);
                }
                catch(Exception){
                    System.Diagnostics.Debug.WriteLine("Exception in SetValue(loglevel)");
                }

                string sValue=m_sIPaddr;
                try 
	            {
                    rk.SetValue("IPaddr", sValue, RegistryValueKind.String);           		
	            }
	            catch (Exception)
	            {
                    System.Diagnostics.Debug.WriteLine("Exception in SetValue(IPaddr)");
	            }

                UInt16 uValue = m_uPort;
                try{
                    rk.SetValue("port", uValue, RegistryValueKind.DWord);
                }
                catch(Exception){
                    System.Diagnostics.Debug.WriteLine("Exception in SetValue(IPaddr)");
                }
                rk.Close();
            }
        }
    }
}
