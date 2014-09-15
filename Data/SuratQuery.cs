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
    public static class SuratQuery
    {
        public static DataTable SelectSuratMasuk(string _filter, int _startFrom, int _count)
        {
            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();

            sb.Append("select SQL_NO_CACHE `nomor_agenda`, `datetime_input`, `tanggal_terima`, `kategori`, `nomor_surat`,`tanggal_surat`," + 
                " `asal_surat`,`perihal`,`tk_keamanan`, `ringkasan_isi`, `lampiran`, user as User ");
            sb.Append(" from surat_masuk ");
            if (!string.IsNullOrEmpty(_filter))
                sb.Append(_filter + " ");
            sb.Append("order by cast(substring_index(substring_index(nomor_agenda, '/', 2), '/', -1) as signed) desc ");

            if (_count != 0)
                sb.Append("limit " + _startFrom + ", " + _count);

            OdbcDataAdapter da = new OdbcDataAdapter(sb.ToString(), T8Application.DBConnection);

            da.Fill(dt);
            return dt;
        }

        public static int JumlahSurat(string _reset_id, string _reset_value)
        {
            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();

            if (_reset_id.ToLower() == "kategori".ToLower())
                sb.Append("SELECT SQL_NO_CACHE nomor_agenda from surat_masuk where kategori='" + _reset_value + "'");
            else if (_reset_id.ToLower() == "tkkeamanan".ToLower())
                sb.Append("SELECT SQL_NO_CACHE nomor_agenda from surat_masuk where tk_keamanan='" + _reset_value + "'");
            else if (_reset_id.ToLower() == "daily".ToLower())
                sb.Append("SELECT SQL_NO_CACHE nomor_agenda from surat_masuk where day('" + _reset_value + "')=day('" + _reset_value +
                    "') and month('" + _reset_value + "')=month('" + _reset_value + "') and year('" + _reset_value + "')=year('" + _reset_value + "')");
            else if (_reset_id.ToLower() == "monthly".ToLower())
                sb.Append("SELECT SQL_NO_CACHE nomor_agenda from surat_masuk where month('" + _reset_value + "')=month('" + _reset_value +
                    "') and year('" + _reset_value + "')=year('" + _reset_value + "')");
            else if (_reset_id.ToLower() == "yearly".ToLower())
                sb.Append("SELECT SQL_NO_CACHE nomor_agenda from surat_masuk where year('" + _reset_value + "')=year('" + _reset_value + "')");
            else
                sb.Append("SELECT SQL_NO_CACHE nomor_agenda from surat_masuk");

            OdbcDataAdapter da = new OdbcDataAdapter(sb.ToString(), T8Application.DBConnection);

            da.Fill(dt);
            return dt.Rows.Count;
        }

        public static int JumlahSuratKeluar(string _reset_id, string _reset_value)
        {
            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();

            if (_reset_id.ToLower() == "kategori".ToLower())
                sb.Append("SELECT SQL_NO_CACHE nomor_surat from surat_keluar where kategori='" + _reset_value + "'");
            else if (_reset_id.ToLower() == "tkkeamanan".ToLower())
                sb.Append("SELECT SQL_NO_CACHE nomor_surat from surat_keluar where tk_keamanan='" + _reset_value + "'");
            else if (_reset_id.ToLower() == "daily".ToLower())
                sb.Append("SELECT SQL_NO_CACHE nomor_surat from surat_keluar where day('" + _reset_value + "')=day('" + _reset_value +
                    "') and month('" + _reset_value + "')=month('" + _reset_value + "') and year('" + _reset_value + "')=year('" + _reset_value + "')");
            else if (_reset_id.ToLower() == "monthly".ToLower())
                sb.Append("SELECT SQL_NO_CACHE nomor_surat from surat_keluar where month('" + _reset_value + "')=month('" + _reset_value +
                    "') and year('" + _reset_value + "')=year('" + _reset_value + "')");
            else if (_reset_id.ToLower() == "yearly".ToLower())
                sb.Append("SELECT SQL_NO_CACHE nomor_surat from surat_keluar where year('" + _reset_value + "')=year('" + _reset_value + "')");
            else
                sb.Append("SELECT SQL_NO_CACHE nomor_surat from surat_keluar");

            OdbcDataAdapter da = new OdbcDataAdapter(sb.ToString(), T8Application.DBConnection);

            da.Fill(dt);
            return dt.Rows.Count;
        }

        public static DataTable SelectSuratKeluar(string _filter, int _startFrom, int _count)
        {
            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();

            sb.Append("select SQL_NO_CACHE `nomor_surat`, `datetime_input`, `kategori`, `tanggal_kirim`, `tujuan`,`perihal`," +
                " `tk_keamanan`,`ringkasan_isi`, `lampiran`,`user` ");
            sb.Append(" from surat_keluar ");
            if (!string.IsNullOrEmpty(_filter))
                sb.Append(_filter + " ");
            sb.Append("order by cast(substring_index(substring_index(nomor_surat, '/', 2), '/', -1) as signed) desc ");

            if (_count != 0)
                sb.Append("limit " + _startFrom + ", " + _count);

            OdbcDataAdapter da = new OdbcDataAdapter(sb.ToString(), T8Application.DBConnection);

            da.Fill(dt);
            return dt;
        }

        public static bool IsSuratMasuk(string _nomor_agenda)
        {
            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();
            sb.Append("select nomor_agenda from surat_masuk where nomor_agenda='" + _nomor_agenda + "'");

            OdbcDataAdapter da = new OdbcDataAdapter(sb.ToString(), T8Application.DBConnection);

            da.Fill(dt);

            return dt.Rows.Count > 0;
        }

        public static bool IsSuratKeluar(string _nomor_surat)
        {
            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();
            sb.Append("select nomor_surat from surat_keluar where nomor_surat='" + _nomor_surat + "'");

            OdbcDataAdapter da = new OdbcDataAdapter(sb.ToString(), T8Application.DBConnection);

            da.Fill(dt);

            return dt.Rows.Count > 0;
        }

        public static int CountNoLimit(string _filter)
        {
            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();

            sb.Append("select SQL_NO_CACHE count(`nomor_agenda`) ");
            sb.Append("from surat_masuk ");
            sb.Append(_filter);

            OdbcDataAdapter da = new OdbcDataAdapter(sb.ToString(), T8Application.DBConnection);

            da.Fill(dt);
            int count;
            int.TryParse(dt.Rows[0][0].ToString(), out count);
            return count;
        }
        public static int CountNoLimitSK(string _filter)
        {
            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();

            sb.Append("select SQL_NO_CACHE count(`nomor_surat`) ");
            sb.Append("from surat_keluar ");
            sb.Append(_filter);

            OdbcDataAdapter da = new OdbcDataAdapter(sb.ToString(), T8Application.DBConnection);

            da.Fill(dt);
            int count;
            int.TryParse(dt.Rows[0][0].ToString(), out count);
            return count;
        }

        public static string Insert(string _dayFormat, string _month_format, string _year_format, string _format_nomor_agenda, string _reset_id, string _resetValue,int _indexID, 
            char _concat_nomor_agenda, int _idLenght, string _tipe, DateTime _tanggal_masuk, string _nomor_surat, DateTime _tanggal_surat, string _asal_surat, 
            string _perihal, string _tk_keamanan, string _ringkasan_isi, string _lampiran, string _admin, int _idxStart, string _kategori_simbol, string _tkkeamanan_simbol)
        {
            OdbcCommand cmd = 
                new OdbcCommand("", T8Application.DBConnection);

            StringBuilder sb = new StringBuilder();

            sb.Append("{call insert_surat('" + _dayFormat + "','" + _month_format + "','" + _year_format + "','" + _format_nomor_agenda + "','" + _reset_id + "','" + _resetValue + "','" + _indexID + "','" + _idLenght + "','" + _concat_nomor_agenda + "','" + _tipe + "','" + string.Format("{0:yyyy-MM-dd}", _tanggal_masuk) + "','" + _nomor_surat + "','"
                    + string.Format("{0:yyyy-MM-dd}", _tanggal_surat) + "','" + _asal_surat + "','" + _perihal + "','" + _tk_keamanan + "','"
                    + _ringkasan_isi + "','" + _lampiran + "','" + _admin + "','" + _idxStart + "','" + _kategori_simbol + "','" + _tk_keamanan +  "')}");

            cmd.CommandText = sb.ToString();


            if (T8Application.DBConnection.State == ConnectionState.Open)
                T8Application.DBConnection.Close();

            cmd.Connection.Open();

            OdbcDataReader dr = cmd.ExecuteReader();
            
            string nmr_Agenda = "";
            if (dr.Read())
                nmr_Agenda = (string)dr[0];

            cmd.Connection.Close();

            return nmr_Agenda;
        }

        public static string InsertKeluar(string _dayFormat, string _month_format, string _year_format, string _format_nomor_surat, string _reset_id, string _resetValue,
            int _indexID, char _concat_nomor_agenda, int _idLenght, string _tipe, DateTime _tanggal_kirim, string _tujuan, string _perihal, string _tk_keamanan,
            string _ringkasan_isi, string _lampiran, string _admin, int _idxStart, string _kategori_simbol, string _tkkeamanan_simbol)
        {
            OdbcCommand cmd =
                new OdbcCommand("", T8Application.DBConnection);

            StringBuilder sb = new StringBuilder();

            sb.Append("{call insert_surat_keluar('" + _dayFormat + "','" + _month_format + "','" + _year_format + "','" + _format_nomor_surat + "','" + _reset_id + "','" +
                _resetValue + "','" + _indexID + "','" + _idLenght + "','" + _concat_nomor_agenda + "','" + _tipe + "','" + string.Format("{0:yyyy-MM-dd}", _tanggal_kirim)
                + "','" + _tujuan + "','" + _perihal + "','" + _tk_keamanan + "','" + _ringkasan_isi + "','" + _lampiran + "','" + _admin + "','" 
                + _idxStart + "','" + _kategori_simbol + "','" + _tk_keamanan + "')}");

            cmd.CommandText = sb.ToString();


            if (T8Application.DBConnection.State == ConnectionState.Open)
                T8Application.DBConnection.Close();

            cmd.Connection.Open();

            OdbcDataReader dr = cmd.ExecuteReader();

            string nmr_Agenda = "";
            if (dr.Read())
                nmr_Agenda = (string)dr[0];

            cmd.Connection.Close();

            return nmr_Agenda;
        }

        public static DataTable GetNomorAgenda(string _filter, int _startFrom, int _count)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select nomor_agenda ");
            sb.Append(" from surat_masuk ");
            if (!string.IsNullOrEmpty(_filter))
                sb.Append(" where nomor_agenda like '%" + _filter + "%' ");
            if(_count!=0)
                sb.Append(" limit " + _startFrom + "," + _count);

            OdbcDataAdapter da = new OdbcDataAdapter(sb.ToString(), T8Application.DBConnection);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public static DataTable GetNomorAgendaSK(string _filter, int _startFrom, int _count)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select nomor_surat ");
            sb.Append(" from surat_keluar ");
            if (!string.IsNullOrEmpty(_filter))
                sb.Append(" where nomor_surat like '%" + _filter + "%' ");
            if (_count != 0)
                sb.Append(" limit " + _startFrom + "," + _count);

            OdbcDataAdapter da = new OdbcDataAdapter(sb.ToString(), T8Application.DBConnection);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public static void Delete(string _nomor_agenda)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" delete from surat_masuk ");
            sb.Append(" where nomor_agenda='" + _nomor_agenda + "' ");

            OdbcCommand cmd = new OdbcCommand(sb.ToString(), T8Application.DBConnection);


            GlobalDBExecute.ExecuteQuery(cmd);
        }

        public static void UpdateSurat(string _nomor_agenda, string _values)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update surat_masuk ");
            sb.Append("set " + _values);
            sb.Append("where `nomor_agenda` = '" + _nomor_agenda + "'");

            OdbcCommand cmd = new OdbcCommand(sb.ToString(), T8Application.DBConnection);

            GlobalDBExecute.ExecuteQuery(cmd);
        }

        public static void UpdateSuratKeluar(string _nomor_surat, string _values)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update surat_keluar ");
            sb.Append("set " + _values);
            sb.Append("where `nomor_surat` = '" + _nomor_surat + "'");

            OdbcCommand cmd = new OdbcCommand(sb.ToString(), T8Application.DBConnection);

            GlobalDBExecute.ExecuteQuery(cmd);
        }

        public static DataTable HistoryTambahSurat(string _filter, string _sort_order)
        {
            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();
            sb.Append("select `nomor_agenda`, `datetime_input`, user ");
            sb.Append("from surat_masuk ");
            sb.Append(_filter);

            OdbcDataAdapter da = new OdbcDataAdapter(sb.ToString(), T8Application.DBConnection);

            da.Fill(dt);

            return dt;
        }

        public static DataRow GetSingleDataSurat(string _nomor_agenda)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select `nomor_agenda`, `datetime_input`, `tanggal_terima`, `nomor_surat`, `kategori`, `tanggal_surat`, `asal_surat`, `perihal`, `tk_keamanan`, `ringkasan_isi`, `lampiran`, `user` ");
            sb.Append("from surat_masuk ");
            sb.Append("where `nomor_agenda`='" + _nomor_agenda + "' ");

            OdbcDataAdapter da = new OdbcDataAdapter(sb.ToString(), T8Application.DBConnection);
            DataTable dt = new DataTable();

            da.Fill(dt);
            return dt.Rows[0];
        }

        public static DataRow GetSingleDataSuratSK(string _nomor_surat)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select `nomor_surat`, `datetime_input`, `kategori`, `tanggal_kirim`, `tujuan`, `perihal`, `tk_keamanan`, `ringkasan_isi`, `lampiran`, `user` ");
            sb.Append("from surat_keluar ");
            sb.Append("where `nomor_surat`='" + _nomor_surat + "' ");

            OdbcDataAdapter da = new OdbcDataAdapter(sb.ToString(), T8Application.DBConnection);
            DataTable dt = new DataTable();

            da.Fill(dt);
            return dt.Rows[0];
        }

        public static void EditSurat(string _nomor_agenda, string _kolom, string _data_lama, string _data_baru, string _user)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into ");
            sb.Append(" history_edit_surat (`nomor_agenda`,`datetime_input`,`kolom`,`data_lama`,`data_baru`,`user`) ");
            sb.Append(" values('" + _nomor_agenda + "',Now(),'" + _kolom + "','" + _data_lama + "','" + _data_baru + "','" + _user + "')");

            OdbcCommand cmd = new OdbcCommand(sb.ToString(), T8Application.DBConnection);


            GlobalDBExecute.ExecuteQuery(cmd);
        }

        public static void EditSuratKeluar(string _nomor_surat, string _kolom, string _data_lama, string _data_baru, string _user)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into ");
            sb.Append(" history_edit_surat_keluar (`nomor_surat`,`datetime_input`,`kolom`,`data_lama`,`data_baru`,`user`) ");
            sb.Append(" values('" + _nomor_surat + "',Now(),'" + _kolom + "','" + _data_lama + "','" + _data_baru + "','" + _user + "')");

            OdbcCommand cmd = new OdbcCommand(sb.ToString(), T8Application.DBConnection);


            GlobalDBExecute.ExecuteQuery(cmd);
        }


        public static void InsertHistoryDisposisi(string _nomor_agenda, DateTime _tglDisposisi, string _disposisi, string _isi_disposisi, string _user)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" insert into disposisi (`nomor_agenda`,`datetime_input`,`tanggal_disposisi`,`tujuan_disposisi`,`isi_disposisi`,`user`) ");
            sb.Append(" values  ");
            sb.Append(" ('" + _nomor_agenda + "', Now(),'" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", _tglDisposisi) + "','" + _disposisi + "','" + _isi_disposisi + "','" + _user + "') ");

            OdbcCommand cmd = new OdbcCommand(sb.ToString(), T8Application.DBConnection);


            GlobalDBExecute.ExecuteQuery(cmd);
        }

        public static void InsertHistoryPenyelesaian(string _nomor_agenda, DateTime _tglPenyelesaian, string _penyelesaian_oleh, string _penyelesaian, string _user)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" insert into penyelesaian (`nomor_agenda`,`datetime_input`,`tanggal_penyelesaian`, `penyelesaian_oleh`,`penyelesaian`,`user`) ");
            sb.Append(" values  ");
            sb.Append(" ('" + _nomor_agenda + "', Now(),'" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", _tglPenyelesaian) + "','" + _penyelesaian_oleh + "','" 
                + _penyelesaian + "','" + _user + "') ");

            OdbcCommand cmd = new OdbcCommand(sb.ToString(), T8Application.DBConnection);


            GlobalDBExecute.ExecuteQuery(cmd);
        }

        public static void InsertJenisPengirimanSurat(string _nomor_agenda, string _jenis_pengiriman, string _info_pengiriman)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into pengiriman (`nomor_agenda`,`jenis_pengiriman`,`info_pengiriman`) ");
            sb.Append(" values  ");
            sb.Append(" ('" + _nomor_agenda + "', '" + _jenis_pengiriman + "','" + _info_pengiriman + "')");

            OdbcCommand cmd = new OdbcCommand(sb.ToString(), T8Application.DBConnection);


            GlobalDBExecute.ExecuteQuery(cmd);
        }

        public static void InsertLokasiFisikSurat(string _nomor_agenda, string _lokasi_fisik, string _keterangan, string _user)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from lokasi_fisik_surat where `nomor_agenda`='" + _nomor_agenda + "'");
            OdbcCommand cmd = new OdbcCommand(sb.ToString(), T8Application.DBConnection);
            GlobalDBExecute.ExecuteQuery(cmd);

            sb = new StringBuilder();
            sb.Append("insert into lokasi_fisik_surat (`nomor_agenda`,`datetime_input`,`date`,`posisi`,`keterangan`,`user`) ");
            sb.Append(" values  ");
            sb.Append(" ('" + _nomor_agenda + "', now(), '" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now) + "','" + _lokasi_fisik + "','" + _keterangan
                + "','" + _user + "')");

            cmd = new OdbcCommand(sb.ToString(), T8Application.DBConnection);
            GlobalDBExecute.ExecuteQuery(cmd);

        }

        public static string GetPosisiSurat(string _nomor_agenda)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select tujuan_disposisi  from disposisi  ");
            sb.Append("where `nomor_agenda`='" + _nomor_agenda + "' and id in(select max(id) from disposisi group by nomor_agenda) ");

            DataTable dt = new DataTable();

            OdbcDataAdapter da = new OdbcDataAdapter(sb.ToString(), T8Application.DBConnection);
            da.Fill(dt);
          
            if (dt.Rows.Count == 0)
                return "";
            else
                return dt.Rows[0][0].ToString();
        }

        public static DataTable GetAllHistory(string _filter)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select `id`,`nomor_agenda`,`datetime_input`,`tanggal_disposisi`,`tujuan_disposisi`, `isi_disposisi`, `user` ");
            sb.Append("from disposisi ");
            sb.Append(_filter);
            sb.Append(" order by id desc ");

            DataTable dt = new DataTable();

            OdbcDataAdapter da = new OdbcDataAdapter(sb.ToString(), T8Application.DBConnection);
            da.Fill(dt);

            return dt;
        }

        public static DataTable GetAllHistoryPenyelesaian(string _filter)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select `id`,`nomor_agenda`,`datetime_input`,`tanggal_penyelesaian`,`penyelesaian_oleh`, `penyelesaian`, `user` ");
            sb.Append("from penyelesaian ");
            sb.Append(_filter);
            sb.Append(" order by id desc ");

            DataTable dt = new DataTable();

            OdbcDataAdapter da = new OdbcDataAdapter(sb.ToString(), T8Application.DBConnection);
            da.Fill(dt);

            return dt;
        }

        public static string GetPenyelesaianAkhirSurat(string _nomor_agenda)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select id, penyelesaian ");
            sb.Append(" from ");
            sb.Append(" penyelesaian ");
            sb.Append(" where nomor_agenda='" + _nomor_agenda + "'");
            sb.Append("  order by id desc limit 1 ");

            DataTable dt = new DataTable();

            OdbcDataAdapter da = new OdbcDataAdapter(sb.ToString(), T8Application.DBConnection);
            da.Fill(dt);

            if (dt.Rows.Count == 0)
                return "";
            else
                return dt.Rows[0][1].ToString();
        }

        public static DataTable GetLokasiFisik(string _nomor_agenda)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select posisi, keterangan ");
            sb.Append(" from ");
            sb.Append(" lokasi_fisik_surat ");
            sb.Append(" where nomor_agenda='" + _nomor_agenda + "' ");
            sb.Append("  order by id desc limit 1 ");

            DataTable dt = new DataTable();

            OdbcDataAdapter da = new OdbcDataAdapter(sb.ToString(), T8Application.DBConnection);
            da.Fill(dt);

            return dt;
        }

        public static DataTable GetJenisPengiriman(string _nomor_agenda)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select jenis_pengiriman, info_pengiriman ");
            sb.Append(" from ");
            sb.Append(" pengiriman ");
            sb.Append(" where nomor_agenda='" + _nomor_agenda + "' ");
            sb.Append("  order by id desc limit 1 ");

            DataTable dt = new DataTable();

            OdbcDataAdapter da = new OdbcDataAdapter(sb.ToString(), T8Application.DBConnection);
            da.Fill(dt);

            return dt;
        }

        public static void HapusSuratMasuk(string _nomor_agenda)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" delete from surat_masuk where `nomor_agenda`='" + _nomor_agenda + "'; ");
            OdbcCommand cmd = new OdbcCommand(sb.ToString(), T8Application.DBConnection);
            GlobalDBExecute.ExecuteQuery(cmd);

            sb = new StringBuilder();
            sb.Append(" delete from pengiriman where `nomor_agenda`='" + _nomor_agenda + "'; ");
            cmd = new OdbcCommand(sb.ToString(), T8Application.DBConnection);
            GlobalDBExecute.ExecuteQuery(cmd);

            sb = new StringBuilder();
            sb.Append(" delete from history_edit_surat where `nomor_agenda`='" + _nomor_agenda + "'; ");
            cmd = new OdbcCommand(sb.ToString(), T8Application.DBConnection);
            GlobalDBExecute.ExecuteQuery(cmd);

            sb = new StringBuilder();
            sb.Append(" delete from penyelesaian where `nomor_agenda`='" + _nomor_agenda + "'; ");
            cmd = new OdbcCommand(sb.ToString(), T8Application.DBConnection);
            GlobalDBExecute.ExecuteQuery(cmd);

            sb = new StringBuilder();
            sb.Append(" delete from referensi_surat where `nomor_agenda`='" + _nomor_agenda + "'; ");
            cmd = new OdbcCommand(sb.ToString(), T8Application.DBConnection);
            GlobalDBExecute.ExecuteQuery(cmd);

            sb = new StringBuilder();
            sb.Append(" delete from lokasi_fisik_surat where `nomor_agenda`='" + _nomor_agenda + "'; ");
            cmd = new OdbcCommand(sb.ToString(), T8Application.DBConnection);
            GlobalDBExecute.ExecuteQuery(cmd);

            sb = new StringBuilder();
            sb.Append(" delete from disposisi where `nomor_agenda`='" + _nomor_agenda + "'; ");
            cmd = new OdbcCommand(sb.ToString(), T8Application.DBConnection);
            GlobalDBExecute.ExecuteQuery(cmd);
        }

        public static void HapusSuratKeluar(string _nomor_surat)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" delete from surat_keluar where `nomor_surat`='" + _nomor_surat + "'; ");
            OdbcCommand cmd = new OdbcCommand(sb.ToString(), T8Application.DBConnection);
            GlobalDBExecute.ExecuteQuery(cmd);

            sb = new StringBuilder();
            sb.Append(" delete from history_edit_surat_keluar where `nomor_surat`='" + _nomor_surat + "'; ");
            cmd = new OdbcCommand(sb.ToString(), T8Application.DBConnection);
            GlobalDBExecute.ExecuteQuery(cmd);

            sb = new StringBuilder();
            sb.Append(" delete from pengiriman where `nomor_agenda`='" + _nomor_surat + "'; ");
            cmd = new OdbcCommand(sb.ToString(), T8Application.DBConnection);
            GlobalDBExecute.ExecuteQuery(cmd);

            sb = new StringBuilder();
            sb.Append(" delete from referensi_surat_keluar where `nomor_surat`='" + _nomor_surat + "'; ");
            cmd = new OdbcCommand(sb.ToString(), T8Application.DBConnection);
            GlobalDBExecute.ExecuteQuery(cmd);

        }

        public static void InsertReferensiSurat(string _surat_masuk, string _surat_keluar)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into referensi_surat (`nomor_agenda`,`referensi_surat_keluar`) ");
            sb.Append(" values  ");
            sb.Append(" ('" + _surat_masuk + "', '" + _surat_keluar + "')");

            OdbcCommand cmd = new OdbcCommand(sb.ToString(), T8Application.DBConnection);


            GlobalDBExecute.ExecuteQuery(cmd);
        }

        public static void InsertReferensiSuratKeluar(string _surat_keluar, string _surat_masuk)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into referensi_surat_keluar (`nomor_surat`,`referensi_surat_masuk`) ");
            sb.Append(" values  ");
            sb.Append(" ('" + _surat_keluar + "', '" + _surat_masuk + "')");

            OdbcCommand cmd = new OdbcCommand(sb.ToString(), T8Application.DBConnection);


            GlobalDBExecute.ExecuteQuery(cmd);
        }

        public static string GetSuratRefensiSuratMasuk(string _surat_masuk)
        {
            string str="";
            StringBuilder sb = new StringBuilder();
            sb.Append(" select referensi_surat_keluar ");
            sb.Append(" from ");
            sb.Append(" referensi_surat ");
            sb.Append(" where nomor_agenda='" + _surat_masuk + "' ");

            DataTable dt = new DataTable();

            OdbcDataAdapter da = new OdbcDataAdapter(sb.ToString(), T8Application.DBConnection);
            da.Fill(dt);

            if (dt.Rows.Count != 0)
                str = dt.Rows[0][0].ToString();
            else
                str = "";

            return str;
        }

        public static string GetSuratRefensiSuratKeluar(string _surat_keluar)
        {
            string str = "";
            StringBuilder sb = new StringBuilder();
            sb.Append(" select referensi_surat_masuk ");
            sb.Append(" from ");
            sb.Append(" referensi_surat_keluar ");
            sb.Append(" where nomor_surat='" + _surat_keluar + "' ");

            DataTable dt = new DataTable();

            OdbcDataAdapter da = new OdbcDataAdapter(sb.ToString(), T8Application.DBConnection);
            da.Fill(dt);

            if (dt.Rows.Count != 0)
                str = dt.Rows[0][0].ToString();
            else
                str = "";

            return str;
        }

        public static void ReferensiSuratMasuk(string _act, string _nomor_agenda, string _referensi_surat_keluar)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from referensi_surat where `nomor_agenda`='" + _nomor_agenda + "'");
            OdbcCommand cmd = new OdbcCommand(sb.ToString(), T8Application.DBConnection);
            GlobalDBExecute.ExecuteQuery(cmd);

            sb = new StringBuilder();
            sb.Append("insert into referensi_surat (`nomor_agenda`,`referensi_surat_keluar`) ");
            sb.Append(" values  ");
            sb.Append(" ('" + _nomor_agenda + "', '" + _referensi_surat_keluar + "')");

            cmd = new OdbcCommand(sb.ToString(), T8Application.DBConnection);
            GlobalDBExecute.ExecuteQuery(cmd);
        }

        public static void ReferensiSuratKeluar(string _act, string _nomor_surat, string _referensi_surat_masuk)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from referensi_surat_keluar where `nomor_surat`='" + _nomor_surat + "'");           
            OdbcCommand cmd = new OdbcCommand(sb.ToString(), T8Application.DBConnection);
            GlobalDBExecute.ExecuteQuery(cmd);

            sb = new StringBuilder();
            sb.Append("insert into referensi_surat_keluar (`nomor_surat`,`referensi_surat_masuk`) ");
            sb.Append(" values  ");
            sb.Append(" ('" + _nomor_surat + "', '" + _referensi_surat_masuk + "')");
            cmd = new OdbcCommand(sb.ToString(), T8Application.DBConnection);
            GlobalDBExecute.ExecuteQuery(cmd);
        }
    }
}




