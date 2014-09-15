using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using T8CoreEnginee;

namespace GUI
{
    public static class LocalSettings
    {
        public static bool AutoSizeMain;
        public static bool AdministratorTableMain;

        public static bool AutoSizeMainSK;
        public static bool AdministratorTableMainSK;

        public static bool AutoSizeHistoryDisposisi;
        public static bool AdministratorTableHistoryDisposisi;

        public static bool AutoSizeHistoryPenyelesaian;
        public static bool AdministratorTableHistoryPenyelesaian;

        public static bool AutoSizeUser;
        public static bool ShowPasswordUser;
        public static bool AdministratorTableUser;

        public static bool AutoSizeHistoryLoginUser;
        public static bool AdministratorTableHistoryLoginUser;

        public static bool AutoSizeHistoryEditSuratMasuk;
        public static bool AdministratorTableHistoryEditSuratMasuk;

        public static bool AutoSizeHistoryEditSuratKeluar;
        public static bool AdministratorTableHistoryEditSuratKeluar;

        public static string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\TemplateAgenda";

        public static string local_setting_file_path = Application.StartupPath + @"\settings\" + T8UserLoginInfo.Username + ".ets";

        public static void GetSetting()
        {
            if (File.Exists(local_setting_file_path))
            {
                string[] strSett = T8GlobalFunc.Decrypt(T8GlobalFunc.ReadSettingFile(local_setting_file_path), "t8").Split(';');
                bool.TryParse(strSett[0], out AutoSizeMain);
                bool.TryParse(strSett[1], out AdministratorTableMain);
                bool.TryParse(strSett[2], out AutoSizeUser);
                bool.TryParse(strSett[3], out ShowPasswordUser);
                bool.TryParse(strSett[4], out AdministratorTableUser);
                bool.TryParse(strSett[5], out AutoSizeHistoryLoginUser);
                bool.TryParse(strSett[6], out AdministratorTableHistoryLoginUser);
                bool.TryParse(strSett[7], out AutoSizeHistoryDisposisi);
                bool.TryParse(strSett[8], out AdministratorTableHistoryDisposisi);
                bool.TryParse(strSett[9], out AutoSizeHistoryPenyelesaian);
                bool.TryParse(strSett[10], out AdministratorTableHistoryPenyelesaian);
                bool.TryParse(strSett[11], out AdministratorTableHistoryEditSuratMasuk);
                bool.TryParse(strSett[12], out AutoSizeHistoryEditSuratMasuk);
                bool.TryParse(strSett[13], out AdministratorTableHistoryEditSuratKeluar);
                bool.TryParse(strSett[14], out AutoSizeHistoryEditSuratKeluar);
                bool.TryParse(strSett[15], out AutoSizeMainSK);
                bool.TryParse(strSett[16], out AdministratorTableMainSK);
            }
        }

        public static void SetSettings(string _var, bool _val)
        {
            if (_var == "AutoSizeMain")   AutoSizeMain = _val;
            if (_var == "AdministratorTableMain") AdministratorTableMain = _val;
            if (_var == "AutoSizeUser") AutoSizeUser = _val;
            if (_var == "ShowPasswordUser") ShowPasswordUser = _val;
            if (_var == "AdministratorTableUser") AdministratorTableUser = _val;
            if (_var == "AutoSizeHistoryLoginUser") AutoSizeHistoryLoginUser = _val;
            if (_var == "AdministratorTableHistoryLoginUser") AdministratorTableHistoryLoginUser = _val;
            if (_var == "AutoSizeHistoryDisposisi") AutoSizeHistoryDisposisi = _val;
            if (_var == "AdministratorTableHistoryDisposisi") AdministratorTableHistoryDisposisi = _val;
            if (_var == "AutoSizeHistoryPenyelesaian") AutoSizeHistoryPenyelesaian = _val;
            if (_var == "AdministratorTableHistoryPenyelesaian") AdministratorTableHistoryPenyelesaian = _val;
            if (_var == "AdministratorTableHistoryEditSuratMasuk") AdministratorTableHistoryEditSuratMasuk = _val;
            if (_var == "AutoSizeHistoryEditSuratMasuk") AutoSizeHistoryEditSuratMasuk = _val;
            if (_var == "AdministratorTableHistoryEditSuratKeluar") AdministratorTableHistoryEditSuratKeluar = _val;
            if (_var == "AutoSizeHistoryEditSuratKeluar") AutoSizeHistoryEditSuratKeluar = _val;
            if (_var == "AutoSizeMainSK") AutoSizeMainSK = _val;
            if (_var == "AdministratorTableMainSK") AdministratorTableMainSK = _val;
              
            StringBuilder _values = new StringBuilder();

            //public static bool AutoSizeMainSK;
            //public static bool AdministratorTableMainSK;
            _values.Append(AutoSizeMain + ";" + AdministratorTableMain + ";" + AutoSizeUser + ";" + ShowPasswordUser + ";" + AdministratorTableUser
                + ";" + AutoSizeHistoryLoginUser + ";" + AdministratorTableHistoryLoginUser + ";" + AutoSizeHistoryDisposisi + ";"
                + AdministratorTableHistoryDisposisi + ";" + AutoSizeHistoryPenyelesaian + ";" + AdministratorTableHistoryPenyelesaian + ";" + AdministratorTableHistoryEditSuratMasuk + ";"
                + AutoSizeHistoryEditSuratMasuk + ";" + AdministratorTableHistoryEditSuratKeluar + ";" + AutoSizeHistoryEditSuratKeluar
                + ";" + AutoSizeMainSK + ";" + AdministratorTableMainSK);

            T8GlobalFunc.WriteFileSetting(local_setting_file_path, T8GlobalFunc.Encrypt(_values.ToString(), "t8"));
            GetSetting();
        }

    }
}
