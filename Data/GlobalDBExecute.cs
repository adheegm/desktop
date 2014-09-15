using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T8CoreEnginee;
using System.Data.Odbc;
	
		

namespace Data
{
    public static class GlobalDBExecute
    {
        public static void ExecuteQuery(OdbcCommand cmd)
        {
            if (T8Application.DBConnection.State == ConnectionState.Open)
                T8Application.DBConnection.Close();
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
    }
}
