/////////////////////////////////////////////////////////////////////
//
// Opos.h
//
//   General header file for OPOS Applications.
//
// Modification history
// ------------------------------------------------------------------
// 1995-12-08 OPOS Release 1.0                                   CRM
// 1997-06-04 OPOS Release 1.2                                   CRM
//   Add OPOS_FOREVER.
//   Add BinaryConversion public constants.
// 1998-03-06 OPOS Release 1.3                                   CRM
//   Add CapPowerReporting, PowerState, and PowerNotify public constants.
//   Add power reporting public constants for StatusUpdateEvent.
// 2000-09-24 OPOS Release 1.5                                   CRM
//   Add OpenResult status public constants.
// 2004-10-26 OPOS Release 1.8                                   CRM
//   Add "ResultCodeExtended" statistics public constant.
// 2005-04-29 OPOS Release 1.9                                   CRM
//   Add CompareFirmwareVersion's Result public constants.
//   Add StatusUpdateEvent and ResultCodeExtended public constants
//     for firmware update.
// 2006-03-15 OPOS Release 1.10                                  CRM
//   Add another public constant for firmware update.
// 2007-01-30 OPOS Release 1.11                                  CRM
//   Add ResultCode public constant for deprecation.
// 2008-08-30 OPOS Release 1.12                                  CRM
//   Comment updates.
//
/////////////////////////////////////////////////////////////////////


/////////////////////////////////////////////////////////////////////
// OPOS "State" Property public constants
/////////////////////////////////////////////////////////////////////

namespace GieAndVince.OPOS
{
    class OposConstant
    {
        public const int OPOS_S_CLOSED = 1;
        public const int OPOS_S_IDLE = 2;
        public const int OPOS_S_BUSY = 3;
        public const int OPOS_S_ERROR = 4;


        /////////////////////////////////////////////////////////////////////
        // OPOS "ResultCode" Property public constants
        /////////////////////////////////////////////////////////////////////

        public const int OPOS_SUCCESS = 0;
        public const int OPOS_E_CLOSED = 101;
        public const int OPOS_E_CLAIMED = 102;
        public const int OPOS_E_NOTCLAIMED = 103;
        public const int OPOS_E_NOSERVICE = 104;
        public const int OPOS_E_DISABLED = 105;
        public const int OPOS_E_ILLEGAL = 106;
        public const int OPOS_E_NOHARDWARE = 107;
        public const int OPOS_E_OFFLINE = 108;
        public const int OPOS_E_NOEXIST = 109;
        public const int OPOS_E_EXISTS = 110;
        public const int OPOS_E_FAILURE = 111;
        public const int OPOS_E_TIMEOUT = 112;
        public const int OPOS_E_BUSY = 113;
        public const int OPOS_E_EXTENDED = 114;
        public const int OPOS_E_DEPRECATED = 115; // (added in 1.11)

        public const int OPOSERR = 100; // Base for ResultCode errors.
        public const int OPOSERREXT = 200; // Base for ResultCodeExtendedErrors.


        /////////////////////////////////////////////////////////////////////
        // OPOS "ResultCodeExtended" Property public constants
        /////////////////////////////////////////////////////////////////////

        // The following applies to ResetStatistics and UpdateStatistics.
        public const int OPOS_ESTATS_ERROR = 280; // (added in 1.8)
        public const int OPOS_ESTATS_DEPENDENCY = 282; // (added in 1.10)
        // The following applies to CompareFirmwareVersion and UpdateFirmware.
        public const int OPOS_EFIRMWARE_BAD_FILE = 281; // (added in 1.9)


        /////////////////////////////////////////////////////////////////////
        // OPOS "OpenResult" Property public constants (added in 1.5)
        /////////////////////////////////////////////////////////////////////

        // The following can be set by the control object.
        //  - Control Object already open.
        public const int OPOS_OR_ALREADYOPEN = 301;
        //  - The registry does not contain a key for the specified device name.
        public const int OPOS_OR_REGBADNAME = 302;
        //  - Could not read the device name key's default value, or
        //     could not convert this Prog ID to a valid Class ID.
        public const int OPOS_OR_REGPROGID = 303;
        //  - Could not create a service object instance, or
        //     could not get its IDispatch interface.
        public const int OPOS_OR_CREATE = 304;
        //  - The service object does not support one or more of the
        //     method required by its release.
        public const int OPOS_OR_BADIF = 305;
        //  - The service object returned a failure status from its
        //     open call, but doesn't have a more specific failure code.
        public const int OPOS_OR_FAILEDOPEN = 306;
        //  - The service object major version number is not 1.
        public const int OPOS_OR_BADVERSION = 307;

        // The following can be returned by the service object if it
        // returns a failure status from its open call.
        //  - Port access required at open, but configured port
        //     is invalid or inaccessible.
        public const int OPOS_ORS_NOPORT = 401;
        //  - Service Object does not support the specified device.
        public const int OPOS_ORS_NOTSUPPORTED = 402;
        //  - Configuration information error.
        public const int OPOS_ORS_CONFIG = 403;
        //  - Errors greater than this value are SO-specific.
        public const int OPOS_ORS_SPECIFIC = 450;


        /////////////////////////////////////////////////////////////////////
        // OPOS "BinaryConversion" Property public constants (added in 1.2)
        /////////////////////////////////////////////////////////////////////

        public const int OPOS_BC_NONE = 0;
        public const int OPOS_BC_NIBBLE = 1;
        public const int OPOS_BC_DECIMAL = 2;


        /////////////////////////////////////////////////////////////////////
        // "CheckHealth" Method: "Level" Parameter public constants
        /////////////////////////////////////////////////////////////////////

        public const int OPOS_CH_INTERNAL = 1;
        public const int OPOS_CH_EXTERNAL = 2;
        public const int OPOS_CH_INTERACTIVE = 3;


        /////////////////////////////////////////////////////////////////////
        // OPOS "CapPowerReporting", "PowerState", "PowerNotify" Property
        //   public constants (added in 1.3)
        /////////////////////////////////////////////////////////////////////

        public const int OPOS_PR_NONE = 0;
        public const int OPOS_PR_STANDARD = 1;
        public const int OPOS_PR_ADVANCED = 2;

        public const int OPOS_PN_DISABLED = 0;
        public const int OPOS_PN_ENABLED = 1;

        public const int OPOS_PS_UNKNOWN = 2000;
        public const int OPOS_PS_ONLINE = 2001;
        public const int OPOS_PS_OFF = 2002;
        public const int OPOS_PS_OFFLINE = 2003;
        public const int OPOS_PS_OFF_OFFLINE = 2004;


        /////////////////////////////////////////////////////////////////////
        // "CompareFirmwareVersion" Method: "Result" Parameter public constants
        //   (added in 1.9)
        /////////////////////////////////////////////////////////////////////

        public const int OPOS_CFV_FIRMWARE_OLDER = 1;
        public const int OPOS_CFV_FIRMWARE_SAME = 2;
        public const int OPOS_CFV_FIRMWARE_NEWER = 3;
        public const int OPOS_CFV_FIRMWARE_DIFFERENT = 4;
        public const int OPOS_CFV_FIRMWARE_UNKNOWN = 5;


        /////////////////////////////////////////////////////////////////////
        // "ErrorEvent" Event: "ErrorLocus" Parameter public constants
        /////////////////////////////////////////////////////////////////////

        public const int OPOS_EL_OUTPUT = 1;
        public const int OPOS_EL_INPUT = 2;
        public const int OPOS_EL_INPUT_DATA = 3;


        /////////////////////////////////////////////////////////////////////
        // "ErrorEvent" Event: "ErrorResponse" public constants
        /////////////////////////////////////////////////////////////////////

        public const int OPOS_ER_RETRY = 11;
        public const int OPOS_ER_CLEAR = 12;
        public const int OPOS_ER_CONTINUEINPUT = 13;


        /////////////////////////////////////////////////////////////////////
        // "StatusUpdateEvent" Event: Common "Status" public constants
        /////////////////////////////////////////////////////////////////////

        public const int OPOS_SUE_POWER_ONLINE = 2001; // (added in 1.3)
        public const int OPOS_SUE_POWER_OFF = 2002; // (added in 1.3)
        public const int OPOS_SUE_POWER_OFFLINE = 2003; // (added in 1.3)
        public const int OPOS_SUE_POWER_OFF_OFFLINE = 2004; // (added in 1.3)

        public const int OPOS_SUE_UF_PROGRESS = 2100; // (added in 1.9)
        public const int OPOS_SUE_UF_COMPLETE = 2200; // (added in 1.9)
        public const int OPOS_SUE_UF_COMPLETE_DEV_NOT_RESTORED = 2205; // (added in 1.9)
        public const int OPOS_SUE_UF_FAILED_DEV_OK = 2201; // (added in 1.9)
        public const int OPOS_SUE_UF_FAILED_DEV_UNRECOVERABLE = 2202; // (added in 1.9)
        public const int OPOS_SUE_UF_FAILED_DEV_NEEDS_FIRMWARE = 2203; // (added in 1.9)
        public const int OPOS_SUE_UF_FAILED_DEV_UNKNOWN = 2204; // (added in 1.9)


        /////////////////////////////////////////////////////////////////////
        // General public constants
        /////////////////////////////////////////////////////////////////////

        public const int OPOS_FOREVER = -1; // (added in 1.2)

        public const int PTR_S_JOURNAL = 1;
        public const int PTR_S_RECEIPT = 2;
        public const int PTR_S_SLIP = 4;

        public const int PTR_TP_TRANSACTION = 11;
        public const int PTR_TP_NORMAL = 12;

        //** "Alignment" Parameter
        //     Either the distance from the left-most print column to the start
        //     of the bar code, or one of the following:

        public const int PTR_BC_LEFT = -1;
        public const int PTR_BC_CENTER = -2;
        public const int PTR_BC_RIGHT = -3;

        //** "TextPosition" Parameter

        public const int PTR_BC_TEXT_NONE = -11;
        public const int PTR_BC_TEXT_ABOVE = -12;
        public const int PTR_BC_TEXT_BELOW = -13;

        //** "Symbology" Parameter:

        //    - One dimensional symbologies
        public const int PTR_BCS_UPCA = 101;  // Digits
        public const int PTR_BCS_UPCE = 102;  // Digits
        public const int PTR_BCS_JAN8 = 103;  // = EAN 8
        public const int PTR_BCS_EAN8 = 103;  // = JAN 8 (added in 1.2)
        public const int PTR_BCS_JAN13 = 104;  // = EAN 13
        public const int PTR_BCS_EAN13 = 104;  // = JAN 13 (added in 1.2)
        public const int PTR_BCS_TF = 105;  // (Discrete 2 of 5) Digits
        public const int PTR_BCS_ITF = 106;  // (Interleaved 2 of 5) Digits
        public const int PTR_BCS_Codabar = 107;  // Digits, -, $, :, /, ., +;
        //   4 start/stop characters
        //   (a, b, c, d)
        public const int PTR_BCS_Code39 = 108;  // Alpha, Digits, Space, -, .,
        //   $, /, +, %; start/stop (*)
        // Also has Full ASCII feature
        public const int PTR_BCS_Code93 = 109;  // Same characters as Code 39
        public const int PTR_BCS_Code128 = 110;  // 128 data characters

        //    - One dimensional symbologies (added in 1.2)
        public const int PTR_BCS_UPCA_S = 111;  // UPC-A with supplemental
        //   barcode
        public const int PTR_BCS_UPCE_S = 112;  // UPC-E with supplemental
        //   barcode
        public const int PTR_BCS_UPCD1 = 113;  // UPC-D1
        public const int PTR_BCS_UPCD2 = 114;  // UPC-D2
        public const int PTR_BCS_UPCD3 = 115;  // UPC-D3
        public const int PTR_BCS_UPCD4 = 116;  // UPC-D4
        public const int PTR_BCS_UPCD5 = 117;  // UPC-D5
        public const int PTR_BCS_EAN8_S = 118;  // EAN 8 with supplemental
        //   barcode
        public const int PTR_BCS_EAN13_S = 119;  // EAN 13 with supplemental
        //   barcode
        public const int PTR_BCS_EAN128 = 120;  // EAN 128
        public const int PTR_BCS_OCRA = 121;  // OCR "A"
        public const int PTR_BCS_OCRB = 122;  // OCR "B"

        //    - One dimensional symbologies (added in 1.8)
        public const int PTR_BCS_Code128_Parsed = 123;  // Code 128 with parsing
        //        The following RSS constants deprecated in 1.12.
        //        Instead use the GS1DATABAR constants below.
        public const int PTR_BCS_RSS14 = 131;  // Reduced Space Symbology - 14 digit GTIN
        public const int PTR_BCS_RSS_EXPANDED = 132;  // RSS - 14 digit GTIN plus additional fields

        //    - One dimensional symbologies (added in 1.12)
        public const int PTR_BCS_GS1DATABAR = 131;  // GS1 DataBar Omnidirectional
        public const int PTR_BCS_GS1DATABAR_E = 132;  // GS1 DataBar Expanded
        public const int PTR_BCS_GS1DATABAR_S = 133;  // GS1 DataBar Stacked Omnidirectional
        public const int PTR_BCS_GS1DATABAR_E_S = 134;  // GS1 DataBar Expanded Stacked

        //    - Two dimensional symbologies
        public const int PTR_BCS_PDF417 = 201;
        public const int PTR_BCS_MAXICODE = 202;

        //    - Two dimensional symbologies (added in 1.13)
        public const int PTR_BCS_DATAMATRIX = 203;  // Data Matrix
        public const int PTR_BCS_QRCODE = 204;  // QR Code
        public const int PTR_BCS_UQRCODE = 205;  // Micro QR Code
        public const int PTR_BCS_AZTEC = 206;  // Aztec
        public const int PTR_BCS_UPDF417 = 207;  // Micro PDF 417

        //    - Start of Printer-Specific bar code symbologies
        public const int PTR_BCS_OTHER = 501;

        /////////////////////////////////////////////////////////////////////
        // "PrintBitmap" and "PrintMemoryBitmap" Method Constants:
        /////////////////////////////////////////////////////////////////////

        //** "Width" Parameter
        //     Either bitmap width or:

        public const int PTR_BM_ASIS = -11;  // One pixel per printer dot

        //** "Alignment" Parameter
        //     Either the distance from the left-most print column to the start
        //     of the bitmap, or one of the following:

        public const int PTR_BM_LEFT = -1;
        public const int PTR_BM_CENTER = -2;
        public const int PTR_BM_RIGHT = -3;

        //** "Type" Parameter ("PrintMemoryBitmap" only)
        public const int PTR_BMT_BMP = 1;
        public const int PTR_BMT_JPEG = 2;
        public const int PTR_BMT_GIF = 3;
    }
}