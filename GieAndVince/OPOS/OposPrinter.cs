using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OposPOSPrinter_CCO;

namespace GieAndVince.OPOS
{
    public class OposPrinter
    {
        private OPOSPOSPrinterClass _OposPrinter;
        private string printerName;
        private bool _bIsOpened;

        private const string CRLF = "\r\n";
        private const string ESC = "\x1b";

        public OposPrinter(string PrinterName)
        {
            _OposPrinter = new OPOSPOSPrinterClass();
            printerName = PrinterName;
        }

        public bool OpenPosPrinter()
        {
            string strErr;
            int nRet = _OposPrinter.Open(printerName);
            if (nRet == OposConstant.OPOS_SUCCESS)
            {
                nRet = _OposPrinter.ClaimDevice(500);
                if (nRet == OposConstant.OPOS_SUCCESS)
                {
                    _OposPrinter.DeviceEnabled = true;
                    _OposPrinter.FlagWhenIdle = true;
                    _OposPrinter.CharacterSet = 437;
                    _bIsOpened = true;
                }
                else
                {
                    strErr = "OPOSPtrinter Claim Error : " + _OposPrinter.ErrorString;
                    return false;
                }
            }
            else
            {
                strErr = "OPOSPrinter Open Error : " + _OposPrinter.ErrorString;
                return false;
            }

            return true;
        }

        public void ClosePosPrinter()
        {
            if (_bIsOpened)
            {
                _OposPrinter.Close();
                _bIsOpened = false;
            }
        }

        public void CutPrinter()
        {
            string ESC = "\x1B";
            _OposPrinter.PrintNormal(OposConstant.PTR_S_RECEIPT, ESC + "|10P");
        }

        public void PrintLn(string line)
        {
            _OposPrinter.PrintNormal(OposConstant.PTR_S_RECEIPT, line + CRLF);
        }

        public void PrintBoldLn(string line)
        {
            line = ESC + "|cA" + ESC + "|2C" + ESC + "|bC" + line + CRLF;
            _OposPrinter.PrintNormal(OposConstant.PTR_S_RECEIPT, line);
        }
    }
}