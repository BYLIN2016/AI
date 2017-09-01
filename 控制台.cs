using mumu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 语音控制登录
{
    public partial class 控制台 : Form
    {
        //实例化语音识别引擎
        private SpeechRecognitionEngine sre = new SpeechRecognitionEngine();
        //全局变量
        List<IntPtr> list = new List<IntPtr>();
        public 控制台()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*初始化语音*/
            sre.SetInputToDefaultAudioDevice();
            GrammarBuilder GB = new GrammarBuilder();
            /*设置语音样本*/
            GB.Append(new Choices(new string[] { "开关" }));
            Grammar G = new Grammar(GB); G.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(G_SpeechRecognized);
            sre.LoadGrammar(G); sre.RecognizeAsync(RecognizeMode.Multiple);
        }
        void G_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Text.Equals("开关"))
            {
                /*获取应用程序名称*/
                string pName = "GSFramework";
                /*查找指定应用程序名称的进程*/
                Process[] temp = Process.GetProcessesByName(pName);//在所有已启动的进程中查找需要的进程；  
                                                                   /*获取父窗体句柄【外围大框】 WindowsForms10.Window.8.app.0.33ec00f_r9_ad1*/
                                                                   //IntPtr wcHandle = common.FindWindow("WindowsForms10.Window.8.app.0.33ec00f_r9_ad1", null);
                if (temp.Length > 0)//如果查找到  
                {
                    IntPtr handle = temp[0].MainWindowHandle;
                    //激活,显示在最前 
                    common.SwitchToThisWindow(handle, true);
                    /*获取窗体以及子窗体*/
                    common.EnumThreadWindowsCallback callback1 = new common.EnumThreadWindowsCallback(EnumWindowsCallback);
                    common.EnumWindows(callback1, IntPtr.Zero);
                    /*查找子窗体*/
                    //common.EnumChildWindows(new HandleRef(this, handle), new common.EnumChildrenCallback(EnumChildWindowsCallback), new HandleRef(null, IntPtr.Zero));
                    MessageBox.Show("ok");
                    /*登录系统*/
                    /*账号密码*/
                    common.SendTextMessage(list[2], common.WM_SETTEXT, 0, "linwf");
                    common.SendMessage(list[0], common.WM_CHAR, 'l', 0);
                    common.SendMessage(list[0], common.WM_CHAR, 'i', 0);
                    common.SendMessage(list[0], common.WM_CHAR, 'n', 0);
                    common.SendMessage(list[0], common.WM_CHAR, '_', 0);
                    common.SendMessage(list[0], common.WM_CHAR, '1', 0);
                    common.SendMessage(list[0], common.WM_CHAR, '2', 0);
                    common.SendMessage(list[0], common.WM_CHAR, '3', 0);

                    common.SetCursorPos(0, 0); //设置鼠标位置发送点击命令
                    common.mouse_event(common.MOUSEEVENTF_MOVE, 500, 280, 0, 0);
                    common.mouse_event(common.MOUSEEVENTF_LEFTDOWN, 500, 280, 0, 0);
                    common.mouse_event(common.MOUSEEVENTF_LEFTUP, 500, 280, 0, 0);

                }
                else
                {

                    Process.Start("C:\\Users\\linwf\\AppData\\Roaming\\Inspur\\GSPSetup\\" + pName + ".exe");
                }
            }


        }
        private bool EnumWindowsCallback(IntPtr handle, IntPtr extraParameter)
        {
            int num1 = common.GetWindowTextLength(new HandleRef(this, handle)) * 2;
            StringBuilder builder1 = new StringBuilder(num1);
            common.GetWindowText(new HandleRef(this, handle), builder1, builder1.Capacity);
            System.Console.WriteLine(string.Format("Wnd:{0} Title: {1}", handle, builder1.ToString()));
            Application.DoEvents();
            common.EnumChildWindows(new HandleRef(this, handle), new common.EnumChildrenCallback(EnumChildWindowsCallback), new HandleRef(null, IntPtr.Zero));
            return true;
        }
        private bool EnumChildWindowsCallback(IntPtr handle, IntPtr lparam)
        {

            StringBuilder s = new StringBuilder(2000);
            int i = common.GetClassName(handle, s, 255);
            if (s.ToString() == "WindowsForms10.EDIT.app.0.33ec00f_r9_ad1")
            {
                list.Add(handle);
            }
            return true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            /*登录客户端*/
   
        }

        private void 控制台_Load(object sender, EventArgs e)
        {

            /*初始化语音*/
            sre.SetInputToDefaultAudioDevice();
            GrammarBuilder GB = new GrammarBuilder();
            /*设置语音样本*/
            GB.Append(new Choices(new string[] { "登录浪潮" }));
            Grammar G = new Grammar(GB); G.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(G_SpeechRecognized);
            sre.LoadGrammar(G); sre.RecognizeAsync(RecognizeMode.Multiple);
            timer1.Interval = 1000;//毫秒为单位
        }
    }
}
