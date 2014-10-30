using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace TCPServer
{
    public static class Keybord
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct KEYBOARD_INPUT
        {
            public uint type;
            public ushort vk;
            public ushort scanCode;
            public uint flags;
            public uint time;
            public uint extrainfo;
            public uint padding1;
            public uint padding2;
        }

        private const uint INPUT_KEYBOARD = 1;
        private const int KEY_EXTENDED = 0x0001;
        private const uint KEY_UP = 0x0002;
        //  private const uint KEY_SCANCODE = 0x0004;  //unicode 0x0008 Key_
        private const uint KEYEVENTF_UNICODE =    0x0004; //THIS WORKS AS DEFAULT FLAG
        private const uint KEYEVENTF_SCANCODE = 0x0008;   //IF I USE THIS IN THE FLAGS STRANGE RESULTS
        [DllImport("User32.dll")]
        private static extern uint SendInput(uint numberOfInputs,
        [MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] 
         KEYBOARD_INPUT[] input,
        int structSize);

        public static void SendKeyP(char cKey)
        {
            ushort iKey = (byte)cKey;
            SendKey(iKey,true);
        }
        /// <summary>
        /// Presses a Key
        /// </summary>
        /// 
        public static void SendKeyP(int scanCode)
        {
            SendKey(scanCode, true);
        }

        public static void SendKeyR(char cKey)
        {
            ushort iKey = (byte)cKey;
            SendKey(iKey,false);
        }
        /// <summary>
        /// Releases Key
        /// </summary>
        /// 
        ///
        public static void SendKeyR(int scanCode)
        {
        SendKey(scanCode, false);
        }
        /// <summary>
        /// single Char Key, Press and Release
        /// </summary>
        /// 
        /// 
        public static void SendKey(char cKey)
        {
            int iKey = (Byte)cKey;
            SendKey(iKey, true);
            SendKey(iKey, false);
        }
        /// <summary>
        /// Single Int KeyCode hex or ascii
        /// </summary>
        /// 
        /// 
        public static void SendKey(int scanCode, bool press)
        {
            KEYBOARD_INPUT[] input = new KEYBOARD_INPUT[1];
            input[0] = new KEYBOARD_INPUT();
            input[0].type = INPUT_KEYBOARD;
            input[0].flags = KEYEVENTF_UNICODE;

            if ((scanCode & 0xFF00) == 0xE000)
            { // extended key?
                input[0].flags |= KEY_EXTENDED;
            }

            if (press)
            { // press?
                input[0].scanCode = (ushort)(scanCode & 0xFF);
            }
            else
            { // release?
                input[0].scanCode = (ushort)scanCode;
                input[0].flags |= KEY_UP;
            }

            uint result = SendInput(1, input, Marshal.SizeOf(input[0]));

            if (result != 1)
            {
                throw new Exception("Could not send key: " + scanCode);
            }
        }


        /// <summary>
        /// String of 1 to many letters, words, etc example SendKeys("HelloWorld");
        /// this does a Press and Release
        /// </summary>
        /// 
        public static void SendKeys(string sKeys)
        {
            Byte[] aKeys = UTF8Encoding.ASCII.GetBytes(sKeys);
            int iLen = aKeys.Length;
            ushort scanCode = 0;
            uint result;
            for (int x = 0; x < iLen; x++)
            {
                //2 elements for each key, one for press one for Release
                scanCode = aKeys[x];
                KEYBOARD_INPUT[] input = new KEYBOARD_INPUT[2];
                input[0] = new KEYBOARD_INPUT();
                input[0].type = INPUT_KEYBOARD;
                input[0].flags = KEYEVENTF_UNICODE;

                input[1] = new KEYBOARD_INPUT();
                input[1].type = INPUT_KEYBOARD;
                input[1].flags = KEYEVENTF_UNICODE;
                if ((scanCode & 0xFF00) == 0xE000)
                { // extended key?
                    input[0].flags |= KEY_EXTENDED;
                    input[1].flags |= KEY_EXTENDED;
                }

                //input[0] for key press
                input[0].scanCode = (ushort)(scanCode & 0xFF);
                //input[1] for KeyReleasse
                input[1].scanCode = (ushort)scanCode;
                input[1].flags |= KEY_UP;
                //call sendinput once for both keys
                result = SendInput(2, input, Marshal.SizeOf(input[0]));
            }
        }
                    /// <summary>
        /// String of 1 to many letters, words, etc example SendKeys("HelloWorld");
        /// this does a Press and Release
        /// </summary>
        /// 
        public static void SendKeys(Byte[] aKeys)
        {
            //Byte[] aKeys = UTF8Encoding.ASCII.GetBytes(sKeys);
            int iLen = aKeys.Length;
            ushort scanCode = 0;
            uint result;
            for (int x = 0; x < iLen; x++)
            {
                //2 elements for each key, one for press one for Release
                scanCode = aKeys[x];
                KEYBOARD_INPUT[] input = new KEYBOARD_INPUT[2];
                input[0] = new KEYBOARD_INPUT();
                input[0].type = INPUT_KEYBOARD;
                input[0].flags = KEYEVENTF_UNICODE;

                input[1] = new KEYBOARD_INPUT();
                input[1].type = INPUT_KEYBOARD;
                input[1].flags = KEYEVENTF_UNICODE;
                if ((scanCode & 0xFF00) == 0xE000)
                { // extended key?
                    input[0].flags |= KEY_EXTENDED;
                    input[1].flags |= KEY_EXTENDED;
                }

                //input[0] for key press
                input[0].scanCode = (ushort)(scanCode & 0xFF);
                //input[1] for KeyReleasse
                input[1].scanCode = (ushort)scanCode;
                input[1].flags |= KEY_UP;
                //call sendinput once for both keys
                result = SendInput(2, input, Marshal.SizeOf(input[0]));
            }
        }
    }
}

//[DllImport("user32.dll", CharSet = CharSet.Auto)]
//static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

////[DllImport("user32.dll", SetLastError = true)]
////static extern uint SendInput(uint nInputs, ref INPUT pInputs, int cbSize);
////struct KEYBDINPUT
////{
////    public ushort wVk;
////    public ushort wScan;
////    public uint dwFlags;
////    public uint time;
////    public IntPtr dwExtraInfo;
////}

////struct HARDWAREINPUT
////{
////    public int uMsg;
////    public short wParamL;
////    public short wParamH;
////}
////struct HARDWAREINPUT
////{
////    public int uMsg;
////    public short wParamL;
////    public short wParamH;
////}

////[StructLayout(LayoutKind.Explicit)]
////struct MOUSEKEYBDHARDWAREINPUT
////{
////    [FieldOffset(0)]
////    public MOUSEINPUT mi;

////    [FieldOffset(0)]
////    public KEYBDINPUT ki;

////    [FieldOffset(0)]
////    public HARDWAREINPUT hi;
////}

////struct INPUT
////{
////    public int type;
////    public MOUSEKEYBDHARDWAREINPUT mkhi;
////}

////[DllImport("user32.dll")]
////static extern IntPtr GetMessageExtraInfo();

////const int INPUT_MOUSE = 0;
////const int INPUT_KEYBOARD = 1;
////const int INPUT_HARDWARE = 2;
////const uint KEYEVENTF_EXTENDEDKEY = 0x0001;
////const uint KEYEVENTF_KEYUP = 0x0002;
////const uint KEYEVENTF_UNICODE = 0x0004;
////const uint KEYEVENTF_SCANCODE = 0x0008;
////const uint XBUTTON1 = 0x0001;
////const uint XBUTTON2 = 0x0002;
////const uint MOUSEEVENTF_MOVE = 0x0001;
////const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
////const uint MOUSEEVENTF_LEFTUP = 0x0004;
////const uint MOUSEEVENTF_RIGHTDOWN = 0x0008;
////const uint MOUSEEVENTF_RIGHTUP = 0x0010;
////const uint MOUSEEVENTF_MIDDLEDOWN = 0x0020;
////const uint MOUSEEVENTF_MIDDLEUP = 0x0040;
////const uint MOUSEEVENTF_XDOWN = 0x0080;
////const uint MOUSEEVENTF_XUP = 0x0100;
////const uint MOUSEEVENTF_WHEEL = 0x0800;
////const uint MOUSEEVENTF_VIRTUALDESK = 0x4000;
////const uint MOUSEEVENTF_ABSOLUTE = 0x8000;

//public enum VK : ushort
//{
//    //
//    // Virtual Keys, Standard Set
//    //
//    VK_LBUTTON = 0x01,
//    VK_RBUTTON = 0x02,
//    VK_CANCEL = 0x03,
//    VK_MBUTTON = 0x04,    // NOT contiguous with L & RBUTTON

//    VK_XBUTTON1 = 0x05,    // NOT contiguous with L & RBUTTON
//    VK_XBUTTON2 = 0x06,    // NOT contiguous with L & RBUTTON

//    // 0x07 : unassigned

//    VK_BACK = 0x08,
//    VK_TAB = 0x09,

//    // 0x0A - 0x0B : reserved

//    VK_CLEAR = 0x0C,
//    VK_RETURN = 0x0D,

//    VK_SHIFT = 0x10,
//    VK_CONTROL = 0x11,
//    VK_MENU = 0x12,
//    VK_PAUSE = 0x13,
//    VK_CAPITAL = 0x14,

//    VK_KANA = 0x15,
//    VK_HANGEUL = 0x15,  // old name - should be here for compatibility
//    VK_HANGUL = 0x15,
//    VK_JUNJA = 0x17,
//    VK_FINAL = 0x18,
//    VK_HANJA = 0x19,
//    VK_KANJI = 0x19,

//    VK_ESCAPE = 0x1B,

//    VK_CONVERT = 0x1C,
//    VK_NONCONVERT = 0x1D,
//    VK_ACCEPT = 0x1E,
//    VK_MODECHANGE = 0x1F,

//    VK_SPACE = 0x20,
//    VK_PRIOR = 0x21,
//    VK_NEXT = 0x22,
//    VK_END = 0x23,
//    VK_HOME = 0x24,
//    VK_LEFT = 0x25,
//    VK_UP = 0x26,
//    VK_RIGHT = 0x27,
//    VK_DOWN = 0x28,
//    VK_SELECT = 0x29,
//    VK_PRINT = 0x2A,
//    VK_EXECUTE = 0x2B,
//    VK_SNAPSHOT = 0x2C,
//    VK_INSERT = 0x2D,
//    VK_DELETE = 0x2E,
//    VK_HELP = 0x2F,

//    //
//    // VK_0 - VK_9 are the same as ASCII '0' - '9' (0x30 - 0x39)
//    // 0x40 : unassigned
//    // VK_A - VK_Z are the same as ASCII 'A' - 'Z' (0x41 - 0x5A)
//    //

//    VK_LWIN = 0x5B,
//    VK_RWIN = 0x5C,
//    VK_APPS = 0x5D,

//    //
//    // 0x5E : reserved
//    //

//    VK_SLEEP = 0x5F,

//    VK_NUMPAD0 = 0x60,
//    VK_NUMPAD1 = 0x61,
//    VK_NUMPAD2 = 0x62,
//    VK_NUMPAD3 = 0x63,
//    VK_NUMPAD4 = 0x64,
//    VK_NUMPAD5 = 0x65,
//    VK_NUMPAD6 = 0x66,
//    VK_NUMPAD7 = 0x67,
//    VK_NUMPAD8 = 0x68,
//    VK_NUMPAD9 = 0x69,
//    VK_MULTIPLY = 0x6A,
//    VK_ADD = 0x6B,
//    VK_SEPARATOR = 0x6C,
//    VK_SUBTRACT = 0x6D,
//    VK_DECIMAL = 0x6E,
//    VK_DIVIDE = 0x6F,
//    VK_F1 = 0x70,
//    VK_F2 = 0x71,
//    VK_F3 = 0x72,
//    VK_F4 = 0x73,
//    VK_F5 = 0x74,
//    VK_F6 = 0x75,
//    VK_F7 = 0x76,
//    VK_F8 = 0x77,
//    VK_F9 = 0x78,
//    VK_F10 = 0x79,
//    VK_F11 = 0x7A,
//    VK_F12 = 0x7B,
//    VK_F13 = 0x7C,
//    VK_F14 = 0x7D,
//    VK_F15 = 0x7E,
//    VK_F16 = 0x7F,
//    VK_F17 = 0x80,
//    VK_F18 = 0x81,
//    VK_F19 = 0x82,
//    VK_F20 = 0x83,
//    VK_F21 = 0x84,
//    VK_F22 = 0x85,
//    VK_F23 = 0x86,
//    VK_F24 = 0x87,

//    //
//    // 0x88 - 0x8F : unassigned
//    //

//    VK_NUMLOCK = 0x90,
//    VK_SCROLL = 0x91,

//    //
//    // VK_L* & VK_R* - left and right Alt, Ctrl and Shift virtual keys.
//    // Used only as parameters to GetAsyncKeyState() and GetKeyState().
//    // No other API or message will distinguish left and right keys in this way.
//    //
//    VK_LSHIFT = 0xA0,
//    VK_RSHIFT = 0xA1,
//    VK_LCONTROL = 0xA2,
//    VK_RCONTROL = 0xA3,
//    VK_LMENU = 0xA4,
//    VK_RMENU = 0xA5,

//    VK_BROWSER_BACK = 0xA6,
//    VK_BROWSER_FORWARD = 0xA7,
//    VK_BROWSER_REFRESH = 0xA8,
//    VK_BROWSER_STOP = 0xA9,
//    VK_BROWSER_SEARCH = 0xAA,
//    VK_BROWSER_FAVORITES = 0xAB,
//    VK_BROWSER_HOME = 0xAC,

//    VK_VOLUME_MUTE = 0xAD,
//    VK_VOLUME_DOWN = 0xAE,
//    VK_VOLUME_UP = 0xAF,
//    VK_MEDIA_NEXT_TRACK = 0xB0,
//    VK_MEDIA_PREV_TRACK = 0xB1,
//    VK_MEDIA_STOP = 0xB2,
//    VK_MEDIA_PLAY_PAUSE = 0xB3,
//    VK_LAUNCH_MAIL = 0xB4,
//    VK_LAUNCH_MEDIA_SELECT = 0xB5,
//    VK_LAUNCH_APP1 = 0xB6,
//    VK_LAUNCH_APP2 = 0xB7,

//    //
//    // 0xB8 - 0xB9 : reserved
//    //

//    VK_OEM_1 = 0xBA,   // ';:' for US
//    VK_OEM_PLUS = 0xBB,   // '+' any country
//    VK_OEM_COMMA = 0xBC,   // ',' any country
//    VK_OEM_MINUS = 0xBD,   // '-' any country
//    VK_OEM_PERIOD = 0xBE,   // '.' any country
//    VK_OEM_2 = 0xBF,   // '/?' for US
//    VK_OEM_3 = 0xC0,   // '`~' for US

//    //
//    // 0xC1 - 0xD7 : reserved
//    //

//    //
//    // 0xD8 - 0xDA : unassigned
//    //

//    VK_OEM_4 = 0xDB,  //  '[{' for US
//    VK_OEM_5 = 0xDC,  //  '\|' for US
//    VK_OEM_6 = 0xDD,  //  ']}' for US
//    VK_OEM_7 = 0xDE,  //  ''"' for US
//    VK_OEM_8 = 0xDF

//    //
//    // 0xE0 : reserved
//    //
//}
