using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using T8CoreEnginee;

namespace GUI
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
            AppInit.Init();
            Application.Run(new UIForms.FrmMain());
        }
    }
}
