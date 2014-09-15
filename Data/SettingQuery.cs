using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Odbc;
using T8CoreEnginee;

namespace Data
{
    public static class SettingQuery
    {
        public static void SimpanKategoriFormat(string _nama_variable, string _value)
        {
            OdbcCommand cmd = new OdbcCommand();
            StringBuilder sb = new StringBuilder();

            sb.Append("update sett_default_application ");
            sb.Append("set `value`='" + _value + "' where `name`='" + _nama_variable + "'");

            cmd.Connection = T8Application.DBConnection;
            cmd.CommandText = sb.ToString();


            GlobalDBExecute.ExecuteQuery(cmd);
        }
    }
}
