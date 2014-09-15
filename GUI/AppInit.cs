using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T8CoreEnginee;
using System.Windows.Forms;

namespace GUI
{
    public static class AppInit
    {

        public static bool isLogin;

        public static void Init()
        {
            isLogin = false;
            T8Application newApp = new T8Application(Application.StartupPath + "\\appsett.ets");
            GeneralSettings.GetSetting();
            AppDefaultSetting.InitSetting();
        }        
    }
}
