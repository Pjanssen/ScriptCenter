﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ScriptCenterTestForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            Application.Run(new ScriptCenter.DevCenter.DevCenter());
            //Application.Run(new ScriptCenter.Test());
        }
    }
}
