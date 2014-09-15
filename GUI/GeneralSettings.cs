using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using T8CoreEnginee;
using System.IO;

namespace GUI
{
    public static class GeneralSettings
    {
        public static bool KonfirmasiAksesPassword;
        public static bool IsIdleTime;
        public static int IdleTimeValue;
        public static bool OtomatisSimpanHistoriLocal;
        public static bool IzinkanUserLain;

        public static bool OtomatisCetakAgenda;
        public static int OtomatisCetakAgendaValue;

        public static bool OtomatisCetakAgendaSK;
        public static int OtomatisCetakAgendaValueSK;

        public static bool OtomatisCetakAgendaPenyelesaian;
        public static int OtomatisCetakAgendaValuePenyelesaian;

        public static string general_setting_file_path = Application.StartupPath + @"\settings\general.ets";

        public static void SetSetting()
        {
            T8GlobalFunc.WriteFileSetting(general_setting_file_path, T8GlobalFunc.Decrypt(T8GlobalFunc.ReadSettingFile(general_setting_file_path),"t8"));
            GetSetting();
        }

        public static void SetSettings(string _general_setting_file_path, string _values)
        {
            T8GlobalFunc.WriteFileSetting(_general_setting_file_path, _values);
            GetSetting();
        }

        public static void GetSetting()
        {
            if(File.Exists(general_setting_file_path))
            {
                string[] strSett = T8GlobalFunc.Decrypt(T8GlobalFunc.ReadSettingFile(general_setting_file_path),"t8").Split(';');
                bool.TryParse(strSett[0], out KonfirmasiAksesPassword);
                bool.TryParse(strSett[1], out IsIdleTime);
                int.TryParse(strSett[2], out IdleTimeValue);
                bool.TryParse(strSett[3], out OtomatisSimpanHistoriLocal);
                bool.TryParse(strSett[4], out IzinkanUserLain);
                bool.TryParse(strSett[5], out OtomatisCetakAgenda);
                int.TryParse(strSett[6], out OtomatisCetakAgendaValue);

                bool.TryParse(strSett[7], out OtomatisCetakAgendaSK);
                int.TryParse(strSett[8], out OtomatisCetakAgendaValueSK);

                bool.TryParse(strSett[9], out OtomatisCetakAgendaPenyelesaian);
                int.TryParse(strSett[10], out OtomatisCetakAgendaValuePenyelesaian);
            }
        }

    }
}
