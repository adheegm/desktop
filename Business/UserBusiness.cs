using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using System.Data;

namespace Business
{
    public static class UserBusiness
    {
        public static void Tambah(string _username, string _password, string _hakAkses, string _status, string _admin)
        {
            UserQuery.Insert(_username, _password, _hakAkses, _status, _admin);
        }

        public static DataTable ShowUserData(string _filter, int _startFrom, int _count)
        {
            return UserQuery.Select(_filter, _startFrom, _count);
        }

        public static string Login(string _username, string _password, Guid _guid)
        {
            string hakAKses = "";

            hakAKses = UserQuery.GetUserHakAkses(_username, _password);

            if (hakAKses != "")
            {
                UserQuery.UpdateLastLogin(_username);
                UserQuery.InsertHistoryLoginUser(_username, _guid);
            }
            return hakAKses;
        }

        public static void Logout(Guid _guid)
        {
            UserQuery.UpdateHitoryLoginUser(_guid);
        }

        public static void LastLogout(string _username)
        {

            UserQuery.UpdateLastLogout(_username);
        }

        public static void InsertUserKategori(string _username, string _kategori)
        {
            UserQuery.InsertUserKategori(_username, _kategori);
        }

        public static void InsertUserTKKeamanan(string _username, string tk_keamanan)
        {
            UserQuery.InsertUserTKKeamanan(_username, tk_keamanan);
        }

        public static void UbahHakAksesUser(string _username, string _hak_akses)
        {
            UserQuery.UpdateHakAksesUser(_username, _hak_akses);
        }

        public static void UbahStatus(string _username, string _status)
        {
            UserQuery.UpdateStatusUser(_username, _status);
        }

        public static void HapusUser(string _username)
        {
            UserQuery.DeleteUser(_username);
        }

        public static void UbahPassword(string _username, string _password)
        {
            UserQuery.UpdatePassword(_username, _password);
        }

        public static void InsertHistoryEditUser(string _username, string _kolom, string _data_lama, string _data_baru, string _user)
        {
            UserQuery.EditUser(_username, _kolom, _data_lama, _data_baru, _user);
        }

        public static DataTable SelectHistoryLoginUser(string _where, int _startFrom, int _count)
        {
            return UserQuery.SelectHistoryLoginUser(_where, _startFrom, _count);
        }

        public static DataTable SelectHistoryEditSuratMasuk(string _where, int _startFrom, int _count)
        {
            return UserQuery.SelectHistoryEditSuratMasuk(_where, _startFrom, _count);
        }
        public static DataTable SelectHistoryEditSuratKeluar(string _where, int _startFrom, int _count)
        {
            return UserQuery.SelectHistoryEditSuratKeluar(_where, _startFrom, _count);
        }


        public static void DeleteHistoryEditSuratMasuk(string _filter)
        {
            UserQuery.DeleteHistoryEditSuratmasuk(_filter);
        }

        public static void DeleteHistoryEditSuratKeluar(string _filter)
        {
            UserQuery.DeleteHistoryEditSuratKeluar(_filter);
        }

        public static void DeleteHistoryLoginUser(string _username, string _filter)
        {
            UserQuery.DeleteHistoryLoginUser(_username, _filter);
        }
    }
}
