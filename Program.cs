﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 语音控制登录
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。bylin20170901github
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new 控制台());
        }
    }
}
