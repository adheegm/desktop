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
    public static class TemplateQuery
    {
        public static DataTable SelectTemplateData(string _template_name)
        {
            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();

            sb.Append("select `nama`,`simbol`, `keterangan`,`template` ");
            sb.Append(" from template_data where template='" + _template_name + "' and status='Aktif'");

            OdbcDataAdapter da = new OdbcDataAdapter(sb.ToString(), T8Application.DBConnection);

            da.Fill(dt);

            return dt;
        }

        public static void InsertTemplateData(string _nama, string _simbol, string _keterangan, string _template_name, string _status)
        {
            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();

            sb.Append("insert into template_data (`nama`, `simbol`, `keterangan`, `template`,`status`) ");
            sb.Append("values('" + _nama + "','" + _simbol + "','" + _keterangan + "','" + _template_name + "','" + _status + "')");

            OdbcCommand cmd = new OdbcCommand(sb.ToString(), T8Application.DBConnection);


            GlobalDBExecute.ExecuteQuery(cmd);
        }

        public static void UpdateTemplateData(int _id)
        {
            
        }

        public static void DeleteTemplateData(string _nama)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" delete from template_data where nama='" + _nama + "' ");

            OdbcCommand cmd = new OdbcCommand(sb.ToString(), T8Application.DBConnection);


            GlobalDBExecute.ExecuteQuery(cmd);
        }

        public static DataTable GetTemplateAll(string _template)
        {
            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();

            sb.Append("select `nama`, `simbol`, `keterangan`,`template`,`status` from template_data where template='" + _template + "' order by `nama` ");

            OdbcDataAdapter da = new OdbcDataAdapter(sb.ToString(), T8Application.DBConnection);

            da.Fill(dt);
            return dt;
        }

        public static DataTable GetTemplateAktif(string _template)
        {
            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();

            sb.Append("select `nama`, `simbol`, `keterangan`,`template`,`status` from template_data where status='Aktif' and template='" + _template + "' order by `nama` ");

            OdbcDataAdapter da = new OdbcDataAdapter(sb.ToString(), T8Application.DBConnection);

            da.Fill(dt);
            return dt;
        }

        public static DataTable GetTemplateAktifTKKeamanan(string _username, string _template)
        {
            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();

            sb.Append(" select tk_keamanan_name from user_tk_keamanan where `username` = '" + _username + "' and tk_keamanan_name in ");
            sb.Append(" (select `nama` from template_data where status='Aktif' and template='" + _template + "' order by `nama`) ");
            sb.Append(" order by tk_keamanan_name asc ");
            OdbcDataAdapter da = new OdbcDataAdapter(sb.ToString(), T8Application.DBConnection);

            da.Fill(dt);
            return dt;
        }

        public static DataTable GetTemplateAktifKategori(string _username, string _template)
        {
            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();

            sb.Append(" select kategori_name from user_kategori where `username` = '" + _username + "' and kategori_name in ");
            sb.Append(" (select `nama` from template_data where status='Aktif' and template='" + _template + "' order by `nama`) ");
            sb.Append(" order by kategori_name asc ");
            OdbcDataAdapter da = new OdbcDataAdapter(sb.ToString(), T8Application.DBConnection);

            da.Fill(dt);
            return dt;
        }

        public static string GetSimbol(string _nama, string _template)
        {
            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();

            sb.Append("select `simbol` from template_data where template='" + _template + "' and nama='" + _nama + "'");

            OdbcDataAdapter da = new OdbcDataAdapter(sb.ToString(), T8Application.DBConnection);

            da.Fill(dt);
            return dt.Rows[0][0].ToString();
        }

        //public static DataTable GetTemplate(string _filter)
        //{
        //    throw new NotImplementedException();
        //}

        public static void UpdatetTemplateData(string _nama, string _simbol, string _keterangan, string _template_name, string _status)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" update template_data ");
            sb.Append(" set simbol='" + _simbol + "', keterangan='" + _keterangan + "', status='" + _status + "' ");
            sb.Append(" where nama='" + _nama +"' and template='" + _template_name + "'");

            OdbcCommand cmd = new OdbcCommand(sb.ToString(), T8Application.DBConnection);

            GlobalDBExecute.ExecuteQuery(cmd);
        }
    }
}
