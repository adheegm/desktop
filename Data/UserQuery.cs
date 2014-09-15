using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Data;
using T8CoreEnginee;
using System.Net;

namespace Data
{
    public static class UserQuery
    {
        public static DataTable Select(string _filter, int _startFrom, int _count)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select SQL_NO_CACHE `username`, `password`, `hak_akses`, `datetime_login_terakhir`, `datetime_logout_terakhir`, `status`, `datetime_input`, `user` ");
            sb.Append(" from user ");
            if (!string.IsNullOrEmpty(_filter))
                sb.Append(_filter + " ");
            if(_count!=0)
                sb.Append(" limit " + _startFrom + "," + _count);
            
            OdbcDataAdapter da = new OdbcDataAdapter(sb.ToString(), T8Application.DBConnection);

            
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public static int CountNoLimit(string _filter)
        {
            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();

            sb.Append("select SQL_NO_CACHE count(`username`) ");
            sb.Append("from user ");
            sb.Append(_filter);

            OdbcDataAdapter da = new OdbcDataAdapter(sb.ToString(), T8Application.DBConnection);

            da.Fill(dt);
            int count;
            int.TryParse(dt.Rows[0][0].ToString(), out count);
            return count;
        }

        public static void Insert(string _username, string _password, string _hakAkses, string _status, string _user)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("insert into user (`username`,`password`,`hak_akses`,`status`,`datetime_input`,`user`) ");
            sb.Append("values ");
            sb.Append("('" + _username + "','" + _password + "','" + _hakAkses + "','" + _status + "',NOW(),'" + _user +  "')");

            OdbcCommand cmd = new OdbcCommand(sb.ToString(), T8Application.DBConnection);


            GlobalDBExecute.ExecuteQuery(cmd);
        }

        

        public static void UpdateHakAksesUser(string _username, string _hak_akses)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update user ");
            sb.Append("set hak_akses = '" + _hak_akses + "' ");
            sb.Append("where username = '" + _username + "'");

            OdbcCommand cmd = new OdbcCommand(sb.ToString(), T8Application.DBConnection);


            GlobalDBExecute.ExecuteQuery(cmd);
        }

        public static void UpdateStatusUser(string _username, string _status)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update user ");
            sb.Append("set status = '" + _status + "' ");
            sb.Append("where username = '" + _username + "'");

            OdbcCommand cmd = new OdbcCommand(sb.ToString(), T8Application.DBConnection);


            GlobalDBExecute.ExecuteQuery(cmd);
        }

        public static void DeleteHistoryLoginUser(string _username, string _filter)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from history_login_user ");
            if (!string.IsNullOrEmpty(_filter))
                sb.Append(_filter + " and username='" + _username + "'");
            else
                sb.Append("where username='" + _username + "'");
            OdbcCommand cmd = new OdbcCommand(sb.ToString(), T8Application.DBConnection);

            GlobalDBExecute.ExecuteQuery(cmd);
        }

        public static void DeleteHistoryEditSuratKeluar(string _filter)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from history_edit_surat_keluar " + _filter);
            OdbcCommand cmd = new OdbcCommand(sb.ToString(), T8Application.DBConnection);

            GlobalDBExecute.ExecuteQuery(cmd);
        }

        public static void DeleteHistoryEditSuratmasuk(string _filter)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from history_edit_surat " + _filter);
            OdbcCommand cmd = new OdbcCommand(sb.ToString(), T8Application.DBConnection);

            GlobalDBExecute.ExecuteQuery(cmd);
        }

        public static void DeleteUser(string _username)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from history_login_user where username='" + _username + "'");
            OdbcCommand cmd = new OdbcCommand(sb.ToString(), T8Application.DBConnection);

            GlobalDBExecute.ExecuteQuery(cmd);

            sb = new StringBuilder();
            sb.Append("delete from user where username='" + _username + "'");
            cmd = new OdbcCommand(sb.ToString(), T8Application.DBConnection);

            GlobalDBExecute.ExecuteQuery(cmd);
        }

        public static string GetUserHakAkses(string _username, string _password)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("select hak_akses from user ");
            sb.Append("where username = '" + _username + "' and password='" + _password +
                "' and status='Aktif' ");

            OdbcDataAdapter da = new OdbcDataAdapter(sb.ToString(), T8Application.DBConnection);

            DataTable dt = new DataTable();

            da.Fill(dt);
            if (dt.Rows.Count == 1)
                return dt.Rows[0][0].ToString();
            else
                return "";
        }
        public static DataTable HistoryTambahUser(string _filter, string _sort_order)
        {
            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();
            sb.Append("select `username`, `datetime_input`, user ");
            sb.Append("from user ");
            sb.Append(_filter);

            OdbcDataAdapter da = new OdbcDataAdapter(sb.ToString(), T8Application.DBConnection);

            da.Fill(dt);

            return dt;
        }

        public static void UpdateHitoryLoginUser(Guid _guid)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("update history_login_user ");
            sb.Append("set datetime_logout = NOW() ");
            sb.Append("where id_login='" + _guid + "'");

            OdbcCommand cmd = new OdbcCommand(sb.ToString(),T8Application.DBConnection);


            GlobalDBExecute.ExecuteQuery(cmd);
        }

        public static void UpdateLastLogin(string _username)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("update user ");
            sb.Append("set datetime_login_terakhir = NOW() ");
            sb.Append("where username='" + _username + "'");

            OdbcCommand cmd = new OdbcCommand(sb.ToString(), T8Application.DBConnection);


            GlobalDBExecute.ExecuteQuery(cmd);
        }

        public static void UpdateLastLogout(string _username)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("update user ");
            sb.Append("set datetime_logout_terakhir = NOW() ");
            sb.Append("where username='" + _username + "'");

            OdbcCommand cmd = new OdbcCommand(sb.ToString(), T8Application.DBConnection);


            GlobalDBExecute.ExecuteQuery(cmd);
        }

        public static void UpdatePassword(string _username, string _password)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update user set password='" + _password + "' where username='" + _username + "'");

            OdbcCommand cmd = new OdbcCommand(sb.ToString(),T8Application.DBConnection);


            GlobalDBExecute.ExecuteQuery(cmd);
        }

        public static DataTable SelectHistoryLoginUser(string _filter, int _startFrom, int _count)
        {
            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();

            sb.Append("select SQL_NO_CACHE `id_login`, `username`, `datetime_login`, `datetime_logout`, `pc_name` as \'PC Name\', `ip_address` as \'IP Address\' ");
            sb.Append("from history_login_user ");
            sb.Append(_filter);

            if (_count != 0)
                sb.Append("limit " + _startFrom + "," + _count);

            OdbcDataAdapter da = new OdbcDataAdapter(sb.ToString(), T8Application.DBConnection);

            da.Fill(dt);

            return dt;
        }
        public static DataTable SelectHistoryEditSuratMasuk(string _filter, int _startFrom, int _count)
        {
            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();

            sb.Append("select SQL_NO_CACHE `id`, `nomor_agenda`, `datetime_input`, `kolom`, `data_lama`, `data_baru`, `user` ");
            sb.Append("from history_edit_surat ");
            sb.Append(_filter);

            if (_count != 0)
                sb.Append("limit " + _startFrom + "," + _count);

            OdbcDataAdapter da = new OdbcDataAdapter(sb.ToString(), T8Application.DBConnection);

            da.Fill(dt);

            return dt;
        }
        public static DataTable SelectHistoryEditSuratKeluar(string _filter, int _startFrom, int _count)
        {
            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();

            sb.Append("select SQL_NO_CACHE `id`, `nomor_surat`, `datetime_input`, `kolom`, `data_lama`, `data_baru`, `user` ");
            sb.Append("from history_edit_surat_keluar ");
            sb.Append(_filter);

            if (_count != 0)
                sb.Append("limit " + _startFrom + "," + _count);

            OdbcDataAdapter da = new OdbcDataAdapter(sb.ToString(), T8Application.DBConnection);

            da.Fill(dt);

            return dt;
        }

        public static int CountNoLimitHistoryLoginUser(string _filter)
        {
            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();

            sb.Append("select SQL_NO_CACHE count(`username`) ");
            sb.Append("from history_login_user ");
            sb.Append(_filter);

            OdbcDataAdapter da = new OdbcDataAdapter(sb.ToString(), T8Application.DBConnection);

            da.Fill(dt);
            int count;
            int.TryParse(dt.Rows[0][0].ToString(), out count);
            return count;
        }

        public static int CountNoLimitHistoryEditSuratMasuk(string _filter)
        {
            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();

            sb.Append("select SQL_NO_CACHE count(`nomor_agenda`) ");
            sb.Append("from history_edit_surat ");
            sb.Append(_filter);

            OdbcDataAdapter da = new OdbcDataAdapter(sb.ToString(), T8Application.DBConnection);

            da.Fill(dt);
            int count;
            int.TryParse(dt.Rows[0][0].ToString(), out count);
            return count;
        }

        public static int CountNoLimitHistoryEditSuratKeluar(string _filter)
        {
            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();

            sb.Append("select SQL_NO_CACHE count(`nomor_surat`) ");
            sb.Append("from history_edit_surat_keluar ");
            sb.Append(_filter);

            OdbcDataAdapter da = new OdbcDataAdapter(sb.ToString(), T8Application.DBConnection);

            da.Fill(dt);
            int count;
            int.TryParse(dt.Rows[0][0].ToString(), out count);
            return count;
        }

        public static void InsertHistoryLoginUser(string _username, Guid guid)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("insert into history_login_user (`id_login`, `username`,`datetime_login`,`pc_name`,`ip_address`) ");
            sb.Append("values('" + guid + "','" + _username + "',NOW(),'" + System.Environment.MachineName + "','"
                + Dns.GetHostAddresses(Dns.GetHostName())[1].ToString() + "')");

            OdbcCommand cmd = new OdbcCommand(sb.ToString(), T8Application.DBConnection);


            GlobalDBExecute.ExecuteQuery(cmd);
        }

        public static void EditUser(string _username, string _kolom, string _data_lama, string _data_baru, string _user)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into ");
            sb.Append("history_edit_user (`username`,`datetime_input`,`kolom`,`data_lama`,`data_baru`,`user`) ");
            sb.Append("values('" + _username + "',Now(),'" + _kolom + "','" + _data_lama + "','" + _data_baru + "','" + _user + "')");

            OdbcCommand cmd = new OdbcCommand(sb.ToString(), T8Application.DBConnection);


            GlobalDBExecute.ExecuteQuery(cmd);
        }

        public static void DeleteUserKategori(string _username)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" delete from user_kategori where `username`='" + _username + "'");

            OdbcCommand cmd = new OdbcCommand(sb.ToString(), T8Application.DBConnection);

            GlobalDBExecute.ExecuteQuery(cmd);
        }

        public static void DeleteUserTKKeamanan(string _username)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" delete from user_tk_keamanan where `username`='" + _username + "'");

            OdbcCommand cmd = new OdbcCommand(sb.ToString(), T8Application.DBConnection);

            GlobalDBExecute.ExecuteQuery(cmd);
        }

        public static void InsertUserTKKeamanan(string _username, string _tkKeamanan)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" insert into user_tk_keamanan(`username`,`tk_keamanan_name`) values('" + _username + "','" + _tkKeamanan + "')");

            OdbcCommand cmd = new OdbcCommand(sb.ToString(), T8Application.DBConnection);

            GlobalDBExecute.ExecuteQuery(cmd);
        }

        public static void InsertUserKategori(string _username, string _kategori)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" insert into user_kategori(`username`,`kategori_name`) values('" + _username + "','" + _kategori + "')");

            OdbcCommand cmd = new OdbcCommand(sb.ToString(), T8Application.DBConnection);

            GlobalDBExecute.ExecuteQuery(cmd);
        }

        public static DataTable GetUserkategori(string _username)
        {
            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();

            sb.Append(" select kategori_name from user_kategori where `username`='" + _username + "'");

            OdbcDataAdapter da = new OdbcDataAdapter(sb.ToString(), T8Application.DBConnection);

            da.Fill(dt);

            return dt;
        }

        public static DataTable GetUserTKKeamanan(string _username)
        {
            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();

            sb.Append(" select tk_keamanan_name from user_tk_keamanan where `username`='" + _username + "'");

            OdbcDataAdapter da = new OdbcDataAdapter(sb.ToString(), T8Application.DBConnection);

            da.Fill(dt);

            return dt;
        }
    }
}
