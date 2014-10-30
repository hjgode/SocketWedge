using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace SocketSend2
{
    static class itc50comm
    {
        public const uint ITC_NO_SELECT = 0x00;
        public const uint ITC_LABEL_SELECT = 0x01;
        public const uint ITC_KEYBOARD_SELECT = 0x02;
        public const uint ITC_SERIAL_SELECT = 0x04;
        public const uint ITC_IRDA_SELECT = 0x08;
        public const uint ITC_TCPIP_SELECT = 0x10;
        public const uint ITC_UDPPLUS_SELECT = 0x20;
        public const uint ITC_SMARTCARD_SELECT = 0x40;
        public const uint ITC_RFID_SELECT = 0x80;

        public const uint ITC_SUCCESS = 0x01910000;
        public const uint ITC_FAIL = 0xC1910001;
        public const uint ITC_INVALID_PARAM_2 = 0xC1910006;
        public const uint ITC_VW_UNABLE_TO_FIND_ADC_DEVICE = 0xC1910012;
        
        public const uint ITC_TO_MANY_DEVICES = 0xC1910016;
        public const uint ITC_UNKNOWN_DEVICE_TYPE = 0xC1910017;
        public const uint ITC_INVALID_SOCKET = 0xC1910018;
        public const uint ITC_SOCKET_ERROR = 0xC1910019;
        public const uint ITC_OBJ_INIT_ERROR = 0xC191001A;
        public const uint ITC_CREATE_INST_ERROR = 0xC191001B;
        public const uint ITC_STARTUP_ERROR = 0xC191001C;

        public const uint ITC_TIMEOUT = 0xC1910003;
        public const uint ITC_BUFFER_OVERWRITTEN = 0xC1910014;
        public const uint ITC_INSUFFICIENT_BUFFER = 0xC1910015;
        public const uint ITC_COM_ERROR = 0xC191001D;
        public const uint ITC_CONNRESET = 0xC191001E;

        [DllImport("itc50.dll", CharSet = CharSet.Unicode)]
        public static extern UInt32 ITCReceiveInput(IntPtr hWnd, int TotalDevices, string szDevicesNames, int uTimeOut, ref byte[] pOutputBuffer);

        [DllImport("itc50.dll", CharSet = CharSet.Unicode)]
        public static extern UInt32 ITCReceiveInputEx(IntPtr hWnd, uint ConnIDs, int uTimeOut, ref byte[] pOutputBuffer);

        [DllImport("itc50.dll", CharSet = CharSet.Unicode)]
        public static extern UInt32 ITCOpenConnection(uint dwOrigin, string lpszAddress, int uPortID, string irdaServerName);

        [DllImport("itc50.dll", CharSet = CharSet.Unicode)]
        public static extern UInt32 ITCOpenConnectionEx(uint dwOrigin, string lpszAddress, UInt16 uPortID, string irdaServerName, ref UInt32 lpdeHandle);

        [DllImport("itc50.dll", CharSet = CharSet.Unicode)]
        public static extern UInt32 ITCTransmitBuffer(string lpszUserAddress, string lpszDataBuffer, int uLength, int uTimeout);

        [DllImport("itc50.dll", CharSet = CharSet.Unicode)]
        public static extern UInt32 ITCTransmitBufferEx(UInt32 ConnID, string lpszDataBuffer, int uLength, int uTimeout);

        [DllImport("itc50.dll", CharSet = CharSet.Unicode)]
        public static extern UInt32 ITCSetEom(int nMethod, sbyte cEOM1, sbyte cEOM2);

        [DllImport("itc50.dll", CharSet = CharSet.Unicode)]
        public static extern UInt32 ITCSetEOMEx(int nMethod, sbyte cEOM1, sbyte cEOM2, uint ConnID);

        [DllImport("itc50.dll", CharSet = CharSet.Unicode)]
        public static extern void ITCCloseAllConnections();

        [DllImport("itc50.dll", CharSet = CharSet.Unicode)]
        public static extern void ITCCloseConnectionsEx(uint Handles);

        [DllImport("itc50.dll", CharSet = CharSet.Unicode)]
        public static extern void ITCCloseAllConnectionsEx();

        public static uint sendData(string sSend)
        {
            myConfig mConfig=new myConfig();

            string szAddr = mConfig.sIpAddr;// "169.254.2.2"; //with ActiveSync we should have 169.254.2.1 and the PC gets 169.254.2.2
            
            UInt16 uPort = mConfig.uPort;// 52401;
            UInt32 pHandle = 0;
            try
            {
                uint uRes = ITCOpenConnectionEx(ITC_TCPIP_SELECT, szAddr, uPort, string.Empty, ref pHandle);
                if (uRes != ITC_SUCCESS)
                    return uRes;
                int iTimeOut = 3000;
                uRes = ITCTransmitBufferEx(pHandle, sSend, sSend.Length, iTimeOut);
                if (uRes != ITC_SUCCESS)
                {
                    ITCCloseAllConnectionsEx();
                    return uRes;
                }
                ITCCloseAllConnectionsEx();
                return uRes; //should be ITC_SUCCESS
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Exception in sendData: " + ex.Message);
            }
            return ITC_FAIL; //we should not get here
        }
    }
}
