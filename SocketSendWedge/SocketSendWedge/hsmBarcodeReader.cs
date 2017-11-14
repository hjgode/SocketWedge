using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Honeywell.DataCollection.WinCE.Decoding;

namespace SocketSendWedge
{
    class hsmBarcodeReader:UserControl, IBarcodeScanControl
    {
        public string _BarcodeText="";
        public bool _IsSuccess = false;
        private const string _sErrorText = "Barcode nicht anzeigbar";

        DecodeAssembly decodeAssembly=null;

        public hsmBarcodeReader()
        {
            decodeAssembly = new DecodeAssembly();
            decodeAssembly.DecodeEvent += new DecodeAssembly.DecodeEventHandler(decodeAssembly_DecodeEvent);
        }

        void decodeAssembly_DecodeEvent(object sender, DecodeAssembly.DecodeEventArgs e)
        {
            if (e.ResultCode == DecodeAssembly.ResultCodes.Success)
            {
                native.goodBeep();
                ScanIsReady(e.Message, true);
            }
        }

        public void startScan()
        {
            decodeAssembly.ScanBarcode();
        }

        public void Dispose()
        {
            decodeAssembly.Dispose();
            decodeAssembly = null;
        }
        public void Disposed()
        {
        }

        /// <summary>
        /// this text gives the barcode data
        /// </summary>
        public string BarcodeText
        {
            get
            {
                return _BarcodeText;
            }
        }
        /// <summary>
        /// return a bool for a good/bad scan
        /// </summary>
        public bool IsSuccess
        {
            get
            {
                return _IsSuccess;
            }
        }
        //Create an event, do not use directly!
        //public event EventHandler ScanReady;
        public event BarcodeEventHandler ScanReady;
        delegate void deleScanIsReady(string sData, bool bIsSuccess);
        /// <summary>
        /// this will be called for successful and faulty scans
        /// </summary>
        private void ScanIsReady(string sData, bool bIsSuccess)
        {
            if (this.InvokeRequired)
            {
                deleScanIsReady d = new deleScanIsReady(ScanIsReady);
                this.Invoke(d, new object[] { sData, bIsSuccess });
            }
            else
            {
                //OnScanReady(new EventArgs());
                _BarcodeText = sData;
                _IsSuccess = bIsSuccess;
                OnScanReady(new BarcodeEventArgs(sData, bIsSuccess)); //call event fire function
                //_bReadingBarcode = false;
            }
        }
        protected virtual void OnScanReady(BarcodeEventArgs e)
        {
            if (ScanReady != null) //check if there is any listener
            {
                //fire event
                ScanReady(this, new BarcodeEventArgs(_BarcodeText, _IsSuccess));
            }
        }
    }
}
