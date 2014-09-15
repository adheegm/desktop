using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using System.Data;

namespace Business
{
    public static class SuratBusiness
    {
        public static DataTable SelectMasuk(string _filter, int _startFrom, int _count)
        {
            return SuratQuery.SelectSuratMasuk(_filter, _startFrom, _count);
        }

        public static DataTable SelectKeluar(string _filter, int _startFrom, int _count)
        {
            return SuratQuery.SelectSuratKeluar(_filter, _startFrom, _count);
        }

        public static void ReferensiSuratMasuk(string _act, string _nomor_agenda, string _referensi_surat_keluar)
        {
            SuratQuery.ReferensiSuratMasuk(_act, _nomor_agenda, _referensi_surat_keluar);
        }

        public static void ReferensiSuratKeluar(string _act, string _nomor_surat, string _referensi_surat_masuk)
        {
            SuratQuery.ReferensiSuratKeluar(_act, _nomor_surat, _referensi_surat_masuk);
        }

        public static string Insert(string _dayFormat, string _month_format, string _year_format, string _format_nomor_agenda, string _resetID, string _resetValue, int _indexID, char _concat_nomor_agenda, int _idLenght, string _tipe, DateTime _tanggal_masuk, string _nomor_surat, DateTime _tanggal_surat, 
            string _asal_surat, string _perihal, string _tk_keamanan, string _ringkasan_isi, string _lampiran, string _admin, int _idxStart, string _kategori_simbol, string _tkkeamanan_simbol)
        {
            string nomor_agenda = SuratQuery.Insert(_dayFormat, _month_format, _year_format, _format_nomor_agenda, _resetID, _resetValue, _indexID, _concat_nomor_agenda, 
                _idLenght, _tipe, _tanggal_masuk, _nomor_surat, _tanggal_surat, _asal_surat, _perihal, _tk_keamanan, _ringkasan_isi, _lampiran, _admin, _idxStart, _kategori_simbol, _tkkeamanan_simbol);

            return nomor_agenda;
        }

        public static string Insertkeluar(string _dayFormat, string _month_format, string _year_format, string _format_nomor_surat, string _resetID, string _resetValue,
            int _indexID, char _concat_nomor_agenda, int _idLenght, string _tipe, DateTime _tanggal_kirim, string tujuan, string _perihal, string _tk_keamanan, 
            string _ringkasan_isi, string _lampiran, string _admin, int _idxStart, string _kategori_simbol, string _tkkeamanan_simbol)
        {
            string nomor_agenda = SuratQuery.InsertKeluar(_dayFormat, _month_format, _year_format, _format_nomor_surat, _resetID, _resetValue, _indexID, _concat_nomor_agenda,
                _idLenght, _tipe, _tanggal_kirim, tujuan, _perihal, _tk_keamanan, _ringkasan_isi, _lampiran, _admin, _idxStart, _kategori_simbol, _tkkeamanan_simbol);

            return nomor_agenda;
        }

        public static DataTable GetNomorAgenda(string _filter, int _startFrom, int _count)
        {
            return SuratQuery.GetNomorAgenda(_filter, _startFrom, _count);
        }

        public static void Delete(string _nomor_agenda)
        {
            SuratQuery.Delete(_nomor_agenda);
        }

        public static void EditSurat(string _nomor_agenda, string _kolom, string _data_lama, string _data_baru, string _user)
        {
            SuratQuery.EditSurat(_nomor_agenda, _kolom, _data_lama,_data_baru,_user);
        }

        public static void EditSuratKeluar(string _nomor_surat, string _kolom, string _data_lama, string _data_baru, string _user)
        {
            SuratQuery.EditSuratKeluar(_nomor_surat, _kolom, _data_lama, _data_baru, _user);
        }

        public static void Update(string _nomor_agenda, string _values)
        {
            SuratQuery.UpdateSurat(_nomor_agenda, _values);
        }

        public static void UpdateKeluar(string _nomor_agenda, string _values)
        {
            SuratQuery.UpdateSuratKeluar(_nomor_agenda, _values);
        }

        public static void InsertReferensiSurat(string _surat_masuk, string _surat_keluar)
        {
            SuratQuery.InsertReferensiSurat(_surat_masuk, _surat_keluar);
        }

        public static void HapusSuratMasuk(string _nomor_agenda)
        {
            SuratQuery.HapusSuratMasuk(_nomor_agenda);
        }
        public static void HapusSuratKeluar(string _nomor_surat)
        {
            SuratQuery.HapusSuratKeluar(_nomor_surat);
        }

        public static void InsertDisposisi(string _nomor_agenda, DateTime _tglDisposisi, string _tujuan_disposisi, string _isi_disposisi, string _user)
        {
            SuratQuery.InsertHistoryDisposisi(_nomor_agenda, _tglDisposisi, _tujuan_disposisi, _isi_disposisi, _user);
        }

        public static void InsertHistoryPenyelesaian(string _nomor_agenda, DateTime _tglPenyelesaian, string _penyelesaian_oleh, string _penyelesaian, string _user)
        {
            SuratQuery.InsertHistoryPenyelesaian(_nomor_agenda, _tglPenyelesaian, _penyelesaian_oleh, _penyelesaian, _user);
        }

        public static void InsertJenisPengiriman(string _nomor_agenda, string _jenis_pengiriman, string _info_pengiriman)
        {
            SuratQuery.InsertJenisPengirimanSurat(_nomor_agenda, _jenis_pengiriman, _info_pengiriman);
        }

        public static void InsertLokasiFisikSurat(string _nomor_agenda, string _lokasi_fisik, string _keterangan, string _user)
        {
            SuratQuery.InsertLokasiFisikSurat(_nomor_agenda, _lokasi_fisik, _keterangan, _user);
        }

        public static DataTable SelectHistoryDisposisi(string _filter)
        {
            return SuratQuery.GetAllHistory(_filter);
        }

        public static DataTable SelectTemplate(string _filter)
        {
            return TemplateQuery.GetTemplateAll(_filter);
        }

        public static DataTable SelectHistoryPenyelesaian(string _filter)
        {
            return SuratQuery.GetAllHistoryPenyelesaian(_filter);
        }

        public static DataTable GetLokasi(string _nomor_agenda)
        {
            return SuratQuery.GetLokasiFisik(_nomor_agenda);
        }

        public static DataTable getJenisPengiriman(string _nomor_agenda)
        {
            return SuratQuery.GetJenisPengiriman(_nomor_agenda);
        }
        public static string GetSimbol(string _nama, string _template)
        {
            return TemplateQuery.GetSimbol(_nama, _template);
        }

        public static void InsertReferensiSuratKeluar(string _nomor_surat, string nomor_agenda)
        {
            SuratQuery.InsertReferensiSuratKeluar(_nomor_surat, nomor_agenda);
        }
    }
}
