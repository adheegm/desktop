using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Odbc;
using T8CoreEnginee;

namespace GUI
{
    public static class AppDefaultSetting
    {

        public static char surat_keluar_concat_nomor_agenda;
        public static string surat_keluar_date_format;

        public static string surat_keluar_format_day;
        public static string surat_keluar_format_month;
        public static string surat_keluar_format_nomor_agenda;
        public static string surat_keluar_format_year;

        public static bool surat_keluar_include_day_nomor_agenda;
        public static bool surat_keluar_include_kategori_nomor_agenda;
        public static bool surat_keluar_include_month_nomor_agenda;
        public static bool surat_keluar_include_tingkat_keamanan_nomor_agenda;
        public static bool surat_keluar_include_year_nomor_agenda;

        public static int surat_keluar_index_id;
        public static int surat_keluar_index_day_nomor_agenda;
        public static int surat_keluar_index_kategori_nomor_agenda;
        public static int surat_keluar_index_month_nomor_agenda;

        public static string surat_keluar_index_start;

        public static int surat_keluar_index_tingkat_keamanan_nomor_agenda;
        public static int surat_keluar_index_year_nomor_agenda;

        public static int surat_keluar_minimum_id_lenght;

        public static string surat_keluar_option_highlight;

        public static string surat_keluar_reset_role;
        public static bool surat_keluar_reset_id_nomor_agenda;

        public static string surat_keluar_template_path;




        public static char surat_masuk_concat_nomor_agenda;
        public static string surat_masuk_date_format;
        public static string surat_masuk_disposisi_template_path;

        public static string surat_masuk_format_day;
        public static string surat_masuk_format_month;
        public static string surat_masuk_format_nomor_agenda;
        public static string surat_masuk_format_year;

        public static bool surat_masuk_include_day_nomor_agenda;
        public static bool surat_masuk_include_kategori_nomor_agenda;
        public static bool surat_masuk_include_month_nomor_agenda;
        public static bool surat_masuk_include_tingkat_keamanan_nomor_agenda;
        public static bool surat_masuk_include_year_nomor_agenda;

        public static int surat_masuk_index_id;
        public static int surat_masuk_index_day_nomor_agenda;
        public static int surat_masuk_index_kategori_nomor_agenda;
        public static int surat_masuk_index_month_nomor_agenda;

        public static string surat_masuk_index_start;

        public static int surat_masuk_index_tingkat_keamanan_nomor_agenda;
        public static int surat_masuk_index_year_nomor_agenda;

        public static int surat_masuk_minimum_id_lenght;

        public static string surat_masuk_option_highlight;

        public static string surat_masuk_penyelesaian_template_path;

        public static string surat_masuk_reset_role;
        public static bool surat_masuk_reset_id_nomor_agenda;

        private static void Set(DataTable _dt)
        {
            char.TryParse((string)_dt.Rows[0][1], out surat_keluar_concat_nomor_agenda);
            surat_keluar_date_format = (string)_dt.Rows[1][1];
            surat_keluar_format_day = (string)_dt.Rows[2][1];
            surat_keluar_format_month = (string)_dt.Rows[3][1];
            surat_keluar_format_nomor_agenda = (string)_dt.Rows[4][1];
            surat_keluar_format_year = (string)_dt.Rows[5][1];

            bool.TryParse((string)_dt.Rows[6][1], out surat_keluar_include_day_nomor_agenda);
            bool.TryParse((string)_dt.Rows[7][1], out surat_keluar_include_kategori_nomor_agenda);
            bool.TryParse((string)_dt.Rows[8][1], out surat_keluar_include_month_nomor_agenda);
            bool.TryParse((string)_dt.Rows[9][1], out surat_keluar_include_tingkat_keamanan_nomor_agenda);
            bool.TryParse((string)_dt.Rows[10][1], out surat_keluar_include_year_nomor_agenda);

            int.TryParse((string)_dt.Rows[11][1], out surat_keluar_index_day_nomor_agenda);
            int.TryParse((string)_dt.Rows[12][1], out surat_keluar_index_id);
            int.TryParse((string)_dt.Rows[13][1], out surat_keluar_index_kategori_nomor_agenda);
            int.TryParse((string)_dt.Rows[14][1], out surat_keluar_index_month_nomor_agenda);

            surat_keluar_index_start = (string)_dt.Rows[15][1];

            int.TryParse((string)_dt.Rows[16][1], out surat_keluar_index_tingkat_keamanan_nomor_agenda);
            int.TryParse((string)_dt.Rows[17][1], out surat_keluar_index_year_nomor_agenda);

            int.TryParse((string)_dt.Rows[18][1], out surat_keluar_minimum_id_lenght);

            surat_keluar_option_highlight = (string)_dt.Rows[19][1];

            bool.TryParse((string)_dt.Rows[20][1], out surat_keluar_reset_id_nomor_agenda);
            surat_keluar_reset_role = (string)_dt.Rows[21][1];
            surat_keluar_template_path = (string)_dt.Rows[22][1];



            char.TryParse((string)_dt.Rows[23][1], out surat_masuk_concat_nomor_agenda);
            surat_masuk_date_format = (string)_dt.Rows[24][1];
            surat_masuk_disposisi_template_path = (string)_dt.Rows[25][1];
            surat_masuk_format_day = (string)_dt.Rows[26][1];
            surat_masuk_format_month = (string)_dt.Rows[27][1];
            surat_masuk_format_nomor_agenda = (string)_dt.Rows[28][1];
            surat_masuk_format_year = (string)_dt.Rows[29][1];

            bool.TryParse((string)_dt.Rows[30][1], out surat_masuk_include_day_nomor_agenda);
            bool.TryParse((string)_dt.Rows[31][1], out surat_masuk_include_kategori_nomor_agenda);
            bool.TryParse((string)_dt.Rows[32][1], out surat_masuk_include_month_nomor_agenda);
            bool.TryParse((string)_dt.Rows[33][1], out surat_masuk_include_tingkat_keamanan_nomor_agenda);
            bool.TryParse((string)_dt.Rows[34][1], out surat_masuk_include_year_nomor_agenda);

            int.TryParse((string)_dt.Rows[35][1], out surat_masuk_index_day_nomor_agenda);
            int.TryParse((string)_dt.Rows[36][1], out surat_masuk_index_id);
            int.TryParse((string)_dt.Rows[37][1], out surat_masuk_index_kategori_nomor_agenda);
            int.TryParse((string)_dt.Rows[38][1], out surat_masuk_index_month_nomor_agenda);

            //int.TryParse((string)_dt.Rows[39][1], out surat_masuk_index_start);

            surat_masuk_index_start = (string)_dt.Rows[39][1];

            int.TryParse((string)_dt.Rows[40][1], out surat_masuk_index_tingkat_keamanan_nomor_agenda);
            int.TryParse((string)_dt.Rows[41][1], out surat_masuk_index_year_nomor_agenda);

            int.TryParse((string)_dt.Rows[42][1], out surat_masuk_minimum_id_lenght);

            surat_masuk_option_highlight = (string)_dt.Rows[43][1];
            surat_masuk_penyelesaian_template_path = (string)_dt.Rows[44][1];

            bool.TryParse((string)_dt.Rows[45][1], out surat_masuk_reset_id_nomor_agenda);
            surat_masuk_reset_role = (string)_dt.Rows[46][1];
        }

        public static void InitSetting()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select name, value from sett_default_application where 1=1 order by name ");
            OdbcDataAdapter da = new OdbcDataAdapter(sb.ToString(), T8Application.DBConnection);
            DataTable dt = new DataTable();

            da.Fill(dt);

           Set(dt);
        }

        public static void UpdateLayoutPrintoutSetting(string _disposisi_template_path, string _penyelesaian_template_file, string _date_format, string _option_highlight, string _surat_keluar_template_file)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" update sett_default_application ");
            sb.Append(" set value = case name ");
            sb.Append(" when 'surat_masuk_disposisi_template_path' then '" + _disposisi_template_path + "' ");
            sb.Append(" when 'surat_masuk_penyelesaian_template_path' then '" + _penyelesaian_template_file + "' ");
            sb.Append(" when 'surat_keluar_template_path' then '" + _surat_keluar_template_file + "' ");
            sb.Append(" when 'surat_masuk_date_format' then '" + _date_format + "' ");
            sb.Append(" when 'surat_masuk_option_highlight' then '" + _option_highlight + "' ");
            sb.Append(" end ");
            sb.Append(" where name IN('surat_masuk_disposisi_template_path', 'surat_masuk_penyelesaian_template_path', 'surat_masuk_date_format', 'surat_masuk_option_highlight', '_surat_keluar_template_path') ");

            OdbcCommand cmd = new OdbcCommand(sb.ToString(), T8Application.DBConnection);

            if (T8Application.DBConnection.State == ConnectionState.Open)
                T8Application.DBConnection.Close();

            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();

            InitSetting();
        }

        public static void UpdateSetting(char _concat_nomor_agenda, string _format_day, string _format_month, string _format_year, string _format_nomor_agenda, bool _include_day_nomor_agenda, bool _include_kategori_nomor_agenda,
            bool _include_month_nomor_agenda, bool _include_tingkat_keamanan_nomor_agenda, bool _include_year_nomor_agenda, int _index_id, int _index_day_nomor_agenda,
            int _index_kategori_nomor_agenda, int _index_month_nomor_agenda, int _index_tingkat_keamanan_nomor_agenda, int _index_year_nomor_agenda, int _minimum_id_lenght,
            string _reset_role, bool _reset_id_nomor_agenda, string _index_start, string _str_surat)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" update sett_default_application ");
            sb.Append(" set value = case name ");
            sb.Append(" when '" + _str_surat + "_concat_nomor_agenda' then '" + _concat_nomor_agenda + "' ");
            sb.Append(" when '" + _str_surat + "_format_day' then '" + _format_day + "' ");
            sb.Append(" when '" + _str_surat + "_format_month' then '" + _format_month + "' ");
            sb.Append(" when '" + _str_surat + "_format_nomor_agenda' then '" + _format_nomor_agenda + "' ");
            sb.Append(" when '" + _str_surat + "_format_year' then '" + _format_year + "' ");
            sb.Append(" when '" + _str_surat + "_include_day_nomor_agenda' then '" + _include_day_nomor_agenda + "' ");
            sb.Append(" when '" + _str_surat + "_include_kategori_nomor_agenda' then '" + _include_kategori_nomor_agenda + "' ");
            sb.Append(" when '" + _str_surat + "_include_month_nomor_agenda' then '" + _include_month_nomor_agenda + "' ");
            sb.Append(" when '" + _str_surat + "_include_tingkat_keamanan_nomor_agenda' then '" + _include_tingkat_keamanan_nomor_agenda + "' ");
            sb.Append(" when '" + _str_surat + "_include_year_nomor_agenda' then '" + _include_year_nomor_agenda + "' ");
            sb.Append(" when '" + _str_surat + "_index_id' then '" + _index_id + "' ");
            sb.Append(" when '" + _str_surat + "_index_day_nomor_agenda' then '" + _index_day_nomor_agenda + "' ");
            sb.Append(" when '" + _str_surat + "_index_kategori_nomor_agenda' then '" + _index_kategori_nomor_agenda + "' ");
            sb.Append(" when '" + _str_surat + "_index_month_nomor_agenda' then '" + _index_month_nomor_agenda + "' ");
            sb.Append(" when '" + _str_surat + "_index_start' then '" + _index_start + "' ");
            sb.Append(" when '" + _str_surat + "_index_tingkat_keamanan_nomor_agenda' then '" + _index_tingkat_keamanan_nomor_agenda + "' ");
            sb.Append(" when '" + _str_surat + "_index_year_nomor_agenda' then '" + _index_year_nomor_agenda + "' ");
            sb.Append(" when '" + _str_surat + "_minimum_id_lenght' then '" + _minimum_id_lenght + "' ");
            sb.Append(" when '" + _str_surat + "_reset_role' then '" + _reset_role + "' ");
            sb.Append(" when '" + _str_surat + "_reset_id_nomor_agenda' then '" + _reset_id_nomor_agenda + "' ");
            sb.Append(" end ");
            sb.Append(" where name IN('" + _str_surat + "_concat_nomor_agenda', '" + _str_surat + "_format_day', '" + _str_surat + "_format_month', '" + _str_surat +
                "_format_nomor_agenda', '" + _str_surat + "_format_year', '" + _str_surat + "_include_day_nomor_agenda','" + _str_surat +
                "_include_kategori_nomor_agenda','" + _str_surat + "_include_month_nomor_agenda','" + _str_surat + "_include_tingkat_keamanan_nomor_agenda','" + _str_surat +
                "_include_year_nomor_agenda','" + _str_surat + "_index_id','" + _str_surat + "_index_day_nomor_agenda','" + _str_surat +
                "_index_kategori_nomor_agenda','" + _str_surat + "_index_month_nomor_agenda','" + _str_surat + "_index_start','" + _str_surat +
                "_index_tingkat_keamanan_nomor_agenda','" + _str_surat + "_index_year_nomor_agenda','" + _str_surat + "_minimum_id_lenght','" + _str_surat +
                "_reset_role','" + _str_surat + "_reset_id_nomor_agenda') ");

            OdbcCommand cmd = new OdbcCommand(sb.ToString(), T8Application.DBConnection);

            if (T8Application.DBConnection.State == ConnectionState.Open)
                T8Application.DBConnection.Close();

            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();

            InitSetting();
        }

    }
}
