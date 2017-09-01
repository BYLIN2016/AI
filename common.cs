using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace mumu
{
    static class common
    {
        //移动鼠标 
        public const int MOUSEEVENTF_MOVE = 0x0001;
        //模拟鼠标左键按下 
        public const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        //模拟鼠标左键抬起 
        public const int MOUSEEVENTF_LEFTUP = 0x0004;
        //模拟鼠标右键按下 
        public const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        //模拟鼠标右键抬起 
        public const int MOUSEEVENTF_RIGHTUP = 0x0010;
        //模拟鼠标中键按下 
        public const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        //模拟鼠标中键抬起 
        public const int MOUSEEVENTF_MIDDLEUP = 0x0040;
        //标示是否采用绝对坐标 
        public const int MOUSEEVENTF_ABSOLUTE = 0x8000;

        /*模拟键盘*/
        public const int WM_KEYDOWN = 0x100;
        public const int WM_KEYUP = 0X101;
        /*模拟发送文本*/
        public const int WM_SETTEXT = 0x0C;
        public const int WM_CHAR = 0x102;


        //设置激活窗体
        [DllImport("user32.dll")]
        public static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);
        //寻找目标进程窗口       
        [DllImport("user32.DLL")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        //寻找目标进程子窗口
        [DllImport("user32.DLL", EntryPoint = "FindWindowEx", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        //设置进程窗口到最前       
        [DllImport("user32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        //模拟键盘事件         
        [DllImport("user32.DLL")]
        public static extern void keybd_event(Byte bVk, Byte bScan, Int32 dwFlags, Int32 dwExtraInfo);
        //给CheckBox发送信息
        [DllImport("user32.DLL", EntryPoint = "SendMessage", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hwnd, UInt32 wMsg, int wParam, int lParam);
        //给Text发送信息
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, string lParam);
        [DllImport("user32.DLL")]
        public static extern IntPtr GetWindow(IntPtr hWnd, int wCmd);
        [DllImport("user32.dll ", EntryPoint = "GetDlgItem")]
        public static extern IntPtr GetDlgItem(IntPtr hParent, int nIDParentItem);
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="Msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "PostMessage")]
        public static extern bool PostMessage(IntPtr hWnd, UInt32 Msg, int wParam, int lParam);
        /// <summary>
        /// 获取文本内容
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lpString"></param>
        /// <param name="nMaxCount"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowText(HandleRef hWnd, StringBuilder lpString, int nMaxCount);
        /// <summary>
        /// 获取文本长度
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowTextLength(HandleRef hWnd);
        /// <summary>
        /// 获取句柄或者窗体
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="extraData"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool EnumWindows(EnumThreadWindowsCallback callback, IntPtr extraData);
        /// <summary>
        /// 获取子窗体以及子控件
        /// </summary>
        /// <param name="hwndParent"></param>
        /// <param name="lpEnumFunc"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll", ExactSpelling = true)]
        public static extern bool EnumChildWindows(HandleRef hwndParent, EnumChildrenCallback lpEnumFunc, HandleRef lParam);
        public delegate bool EnumThreadWindowsCallback(IntPtr hWnd, IntPtr lParam);
        public delegate bool EnumChildrenCallback(IntPtr hwnd, IntPtr lParam);
        /// <summary>
        /// 获取类名
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lpClassName"></param>
        /// <param name="nMaxCount"></param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
        /// <summary>
        /// 发送文本
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="Msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("User32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
        public static extern int SendTextMessage(IntPtr hWnd,int Msg,int wParam,string lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int Width, int Height, int flags);
        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        public static extern int SetCursorPos(int x, int y);

        [System.Runtime.InteropServices.DllImport("user32")]
        public static extern int mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);


        /*加载speech处理类*/

        /*加载opencv处理类*/

        /*加载caffe处理类*/

        /*封装第三方api接口*/
    }
}
