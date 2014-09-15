using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Business;
using T8CoreEnginee;
using System.Data.Odbc;
using Data;
using System.Diagnostics;
using Microsoft.Office.Interop.Word;

namespace GUI.UIForms
{
    public partial class FrmSuratMasuk : Telerik.WinControls.UI.RadForm
    {
        FrmMain frmMain;
        public FrmSuratMasuk(FrmMain _frmMain)
        {
            InitializeComponent();
            frmMain = _frmMain;
            this.ShowInTaskbar = false;
        }                

        private void FrmSuratMasuk_Load(object sender, EventArgs e)
        {
            txtReferensiSurat.AutoCompleteDataSource = Data.SuratQuery.GetNomorAgendaSK("", 0, 0);
            txtReferensiSurat.AutoCompleteDisplayMember = "nomor_surat";

            TxtAsalSuratAutoComplete();
            TxtDiteruskanKepadaAutoComplete();
            DropDownKategori();
            DropDownTingkatKeamananItems(); 
            DropDownJenisPengiriman();
            DropDownLokasiFisikSurat();
            DropDownSelectedIndex();
            clearInput();
        }

        System.Data.DataTable dtLokasiFisik;
        private void DropDownLokasiFisikSurat()
        {
            dtLokasiFisik = TemplateQuery.GetTemplateAktif("lokasi_fisik");
            for (int i = 0; i < dtLokasiFisik.Rows.Count; i++)
            {
                ddLokasiFisikSurat.Items.Add(dtLokasiFisik.Rows[i][0].ToString());
            }
        }


        System.Data.DataTable dtJenisPengiriman;
        private void DropDownJenisPengiriman()
        {
            dtJenisPengiriman = TemplateQuery.GetTemplateAktif("jenis_pengiriman");
            for (int i = 0; i < dtJenisPengiriman.Rows.Count; i++)
            {
                ddJenisPengiriman.Items.Add(dtJenisPengiriman.Rows[i][0].ToString());
            }
        }

        System.Data.DataTable dtKategori;
        private void DropDownKategori()
        {
            if (T8UserLoginInfo.HakAkses.ToLower().Contains(("Administrator").ToLower()))
            {
                dtKategori = TemplateQuery.GetTemplateAktif("kategori_surat");
            }
            else
                dtKategori = TemplateQuery.GetTemplateAktifKategori(T8UserLoginInfo.Username, "kategori_surat");
            for (int i = 0; i < dtKategori.Rows.Count; i++)
            {
                dropDownTipe.Items.Add(dtKategori.Rows[i][0].ToString());
            }
        }

        System.Data.DataTable dtPosisiSurat;
        private void TxtDiteruskanKepadaAutoComplete()
        {
            dtPosisiSurat = TemplateQuery.GetTemplateAktif("posisi_surat");
            txtTujuanDisposisi.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtTujuanDisposisi.AutoCompleteSource = AutoCompleteSource.CustomSource;
            for (int i = 0; i < dtPosisiSurat.Rows.Count; i++)
            {
                txtTujuanDisposisi.AutoCompleteCustomSource.Add(dtPosisiSurat.Rows[i][0].ToString());
            }
        }

        System.Data.DataTable dtAsalSurat;
        private void TxtAsalSuratAutoComplete()
        {
            dtAsalSurat = TemplateQuery.GetTemplateAktif("asal_surat");
            txtAsalSurat.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtAsalSurat.AutoCompleteSource = AutoCompleteSource.CustomSource;
            for (int i = 0; i < dtAsalSurat.Rows.Count; i++)
            {
                txtAsalSurat.AutoCompleteCustomSource.Add(dtAsalSurat.Rows[i][0].ToString());
            }
        }

        private void clearInput()
        {
            dropDownTipe.SelectedIndex = -1;
            dropDownTipe.Text = "";
            dtTanggalMasuk.Value = DateTime.Now;
            dtTanggalSurat.Value = DateTime.Now;
            dtTanggalDisposisi.Value = DateTime.Now;
            txtAsalSurat.Text = "";
            txtIsisDisposisi.Text = "";
            txtTujuanDisposisi.Text = "";
            txtNomorSurat.Text = "";
            dropDownTingkatKeamanan.SelectedIndex = -1;
            dropDownTingkatKeamanan.Text = "";
            txtLampiran.Text = "";
            txtPerihalSurat.Text = "";
            dropDownTipe.Select();
            txtRingkasanIsi.Text = "";
            txtInfoPengiriman.Text = "";
            txtKeteranganLokasi.Text = "";
            txtReferensiSurat.Text = "";

            ddJenisPengiriman.SelectedIndex = -1;
            ddLokasiFisikSurat.SelectedIndex = -1;
            if (GUI.GeneralSettings.OtomatisCetakAgenda)
                chkOtomatisCetakLembarDisposisi.Checked = true;
            //lblNomorAgenda.Text = AppDefaultSetting.format_nomor_agenda;
        }

        System.Data.DataTable dtTKKeamanan;
        private void DropDownTingkatKeamananItems()
        {
            if(T8UserLoginInfo.HakAkses.ToLower().Contains(("Administrator").ToLower()))
            {
                dtTKKeamanan = TemplateQuery.GetTemplateAktif("tingkat_keamanan");
            }
            else
                dtTKKeamanan = TemplateQuery.GetTemplateAktifTKKeamanan(T8UserLoginInfo.Username, "tingkat_keamanan");
            for (int i = 0; i < dtTKKeamanan.Rows.Count; i++)
            {
                dropDownTingkatKeamanan.Items.Add(dtTKKeamanan.Rows[i][0].ToString());
            }
        }

        private void DropDownSelectedIndex()
        {
            dropDownTingkatKeamanan.SelectedIndex = -1;
        }

        private void btnBersihkan_Click(object sender, EventArgs e)
        {
            clearInput();
        }
        public string nomor_agenda;

        public int start_index;

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(dropDownTipe.Text))
            {
                MessageBox.Show(this, "\"Kategori surat\" tidak boleh kosong.", "Input Kosong", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                dropDownTipe.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtNomorSurat.Text))
            {
                MessageBox.Show(this, "\"Nomor surat\" tidak boleh kosong.", "Input Kosong", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtNomorSurat.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtAsalSurat.Text))
            {
                MessageBox.Show(this, "\"Asal surat\" tidak boleh kosong.", "Input Kosong", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtAsalSurat.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtPerihalSurat.Text))
            {
                MessageBox.Show(this, "\"Perihal surat\" tidak boleh kosong.", "Input Kosong", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtPerihalSurat.Focus();
                return;
            }

            if (string.IsNullOrEmpty(dropDownTingkatKeamanan.Text))
            {
                MessageBox.Show(this, "\"Tingkat Keamanan\" tidak boleh kosong.", "Input Kosong", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                dropDownTingkatKeamanan.Focus();
                return;
            }

            if (chkOtomatisCetakLembarDisposisi.Checked)
            {
                if (string.IsNullOrEmpty(txtTujuanDisposisi.Text))
                {
                    MessageBox.Show(this, "\"Tujuan Disposisi\" tidak boleh kosong.", "Input Kosong", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }

            if (MessageBox.Show(this, "Anda yakin akan menginputkan data surat?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    string resetValue = "";                    
                    string reset_id = "";     

                    if (AppDefaultSetting.surat_masuk_reset_role.ToLower() == "kategori".ToLower())
                        resetValue = dropDownTipe.Text;
                    else if (AppDefaultSetting.surat_masuk_reset_role.ToLower() == "tkkeamanan".ToLower())
                        resetValue = dropDownTingkatKeamanan.Text;

                    if (AppDefaultSetting.surat_masuk_reset_role.ToLower() == "kategori".ToLower())
                        reset_id = AppDefaultSetting.surat_masuk_reset_role;
                    else if (AppDefaultSetting.surat_masuk_reset_role.ToLower() == "tkkeamanan".ToLower())
                        reset_id = AppDefaultSetting.surat_masuk_reset_role;
                    else if (AppDefaultSetting.surat_masuk_reset_role.ToLower() == "daily".ToLower())
                        reset_id = string.Format("{0:yyyy-MM-dd}", dtTanggalMasuk.Value);
                    else if (AppDefaultSetting.surat_masuk_reset_role.ToLower() == "monthly".ToLower())
                        reset_id = string.Format("{0:yyyy-MM-dd}", dtTanggalMasuk.Value);
                    else if (AppDefaultSetting.surat_masuk_reset_role.ToLower() == "yearly".ToLower())
                        reset_id = string.Format("{0:yyyy-MM-dd}", dtTanggalMasuk.Value);
                    else
                        reset_id = "";

                    start_index = 1;
                    if (JumlahSurat(reset_id, resetValue) == 0)
                    {
                        if (AppDefaultSetting.surat_masuk_index_start.ToString().ToLower() != "Flat (Value = 1)".ToLower())
                        {
                            Surat.FrmStartIndex frmStartIndex = new Surat.FrmStartIndex(this);
                            frmStartIndex.ShowDialog();
                        }    
                    }

                    if (this.start_index == 0)
                        return;
                    nomor_agenda = InsertSurat(resetValue);

                    if (!string.IsNullOrEmpty(txtReferensiSurat.Text))
                    {
                        if (SuratQuery.IsSuratKeluar(GlobalFunction.SqlCharChecker(txtReferensiSurat.Text.Replace("\0", ""))))
                            SuratBusiness.InsertReferensiSurat(nomor_agenda, GlobalFunction.SqlCharChecker(txtReferensiSurat.Text.Replace("\0", "")));
                    }
                    
                    if(!string.IsNullOrEmpty(txtTujuanDisposisi.Text))
                    {
                        SuratBusiness.InsertDisposisi(nomor_agenda, dtTanggalDisposisi.Value, GlobalFunction.SqlCharChecker(txtTujuanDisposisi.Text), 
                            GlobalFunction.SqlCharChecker(txtIsisDisposisi.Text), T8UserLoginInfo.Username);
                    }

                    if (!string.IsNullOrEmpty(ddJenisPengiriman.Text))
                    {
                        SuratBusiness.InsertJenisPengiriman(nomor_agenda, GlobalFunction.SqlCharChecker(ddJenisPengiriman.Text), 
                            GlobalFunction.SqlCharChecker(txtInfoPengiriman.Text));
                    }

                    if (!string.IsNullOrEmpty(ddLokasiFisikSurat.Text))
                    {
                        SuratBusiness.InsertLokasiFisikSurat(nomor_agenda, GlobalFunction.SqlCharChecker(ddLokasiFisikSurat.Text), 
                            GlobalFunction.SqlCharChecker(txtKeteranganLokasi.Text), T8UserLoginInfo.Username);
                    }
                       
                    MessageBox.Show(this, "Nomor agenda surat: " + nomor_agenda, "Data Disimpan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.frmMain.insertSingleSurat(this);
                    MessageBox.Show(this, "Data surat sudah disimpan di database.","Input sukses", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    if (chkOtomatisCetakLembarDisposisi.Checked)
                        PrintAgenda();            

                    clearInput();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    T8CoreEnginee.T8Application.DBConnection.Close();
                }
            }
        }

        private int JumlahSurat(string _resetID, string _reset_value)
        {
            return SuratQuery.JumlahSurat(_resetID, _reset_value);
        }

        private void FindAndReplace(Microsoft.Office.Interop.Word.Application doc, object findText, object replaceWithText, bool isHightlight)
        {
            object matchCase = false;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundsLike = false;
            object matchAllWordForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiacritics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;
            object missing = Type.Missing;

            if (doc.Selection.Find.Execute(ref findText, ref matchCase, ref matchWholeWord,
               ref matchWildCards, ref matchSoundsLike, ref matchAllWordForms, ref forward, ref wrap, ref format, ref missing, ref missing,
               ref matchKashida, ref matchDiacritics, ref matchAlefHamza, ref matchControl))
            {
                if (isHightlight)
                {
                    string[] option_highlight = AppDefaultSetting.surat_masuk_option_highlight.Split(';');
                    for (int i = 0; i < option_highlight.Length; i++)
                    {
                        if (option_highlight[i] == "bold")
                            doc.Application.Selection.Font.Bold = 1;
                        if (option_highlight[i] == "underline")
                            doc.Application.Selection.Font.Underline = WdUnderline.wdUnderlineSingle;
                    }
                }

                doc.Application.Selection.Font.Italic = 0;
                doc.Application.Selection.Font.Color = WdColor.wdColorBlack;

                doc.Application.Selection.Text = (string)replaceWithText;
            }
        }

        private void PrintAgenda()
        {
            object nullobject = Type.Missing;
            object missing = Type.Missing;

            object fileName = AppDefaultSetting.surat_masuk_disposisi_template_path;
            object TfileName = System.Windows.Forms.Application.StartupPath + @"\agenda_printout_template.docx";

            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application { Visible = true };
            if (!System.IO.File.Exists((string)fileName))
            {
                MessageBox.Show(this, "Template tidak ditemukan, mohon periksa kembali atau hubungi administrator.",
                    "Template Tidak Ditemukan", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                return; 
            }

            Microsoft.Office.Interop.Word.Document aDoc = wordApp.Documents.Open(ref fileName, ref missing, ref missing, ref missing, ref missing, ref missing, 
                ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);

            aDoc.Activate();

            FindAndReplace(wordApp, "[nomor_agenda]", nomor_agenda, false);
            FindAndReplace(wordApp, "[kategori]", dropDownTipe.Text, false);
            FindAndReplace(wordApp, "[tanggal_terima]", string.Format("{0:" + AppDefaultSetting.surat_masuk_date_format + "}", dtTanggalMasuk.Value), false);
            FindAndReplace(wordApp, "[nomor_surat]", txtNomorSurat.Text, false);
            FindAndReplace(wordApp, "[tanggal_surat]", string.Format("{0:" + AppDefaultSetting.surat_masuk_date_format + "}", dtTanggalSurat.Value), false);
            FindAndReplace(wordApp, "[asal_surat]", txtAsalSurat.Text, false);
            FindAndReplace(wordApp, "[perihal]", txtPerihalSurat.Text, false);
            FindAndReplace(wordApp, "[tingkat_keamanan]", dropDownTingkatKeamanan.Text, false);
            FindAndReplace(wordApp, "[ringkasan_isi]", txtRingkasanIsi.Text, false);
            FindAndReplace(wordApp, "[lampiran]", txtLampiran.Text, false);


            FindAndReplace(wordApp, "[tanggal_disposisi]", string.Format("{0:" + AppDefaultSetting.surat_masuk_date_format + "}", dtTanggalDisposisi.Value), false);
            FindAndReplace(wordApp, "[tujuan_disposisi]", txtTujuanDisposisi.Text, false);
            FindAndReplace(wordApp, "[isi_disposisi]", txtIsisDisposisi.Text, false);

            FindAndReplace(wordApp, "[referensi_surat]", txtReferensiSurat.Text, false);
            FindAndReplace(wordApp, "[lokasi_fisik]", ddLokasiFisikSurat.Text, false);
            FindAndReplace(wordApp, "[info_lokasi]", txtKeteranganLokasi.Text, false); 
            FindAndReplace(wordApp, "[jenis_pengiriman]", ddJenisPengiriman.Text, false);
            FindAndReplace(wordApp, "[info_pengiriman]", txtInfoPengiriman.Text, false);

            FindAndReplace(wordApp, "[datetime_print]", string.Format("{0:" + AppDefaultSetting.surat_masuk_date_format + "}", DateTime.Now), false);
            FindAndReplace(wordApp, "[user]", T8UserLoginInfo.Username, false);

            for (int i = 0; i < dtKategori.Rows.Count;i++ )
            {
                if (dropDownTipe.Text.ToLower() == dtKategori.Rows[i][0].ToString().ToLower())
                {
                    FindAndReplace(wordApp, "[o:" + dtKategori.Rows[i][1].ToString() + "]", "<b>" + dtKategori.Rows[i][1].ToString() + "</b>", false);
                    FindAndReplace(wordApp, "<b>" + dtKategori.Rows[i][1].ToString() + "</b>", dtKategori.Rows[i][1].ToString(), true);
                }
                else
                    FindAndReplace(wordApp, "[o:" + dtKategori.Rows[i][1].ToString() + "]", dtKategori.Rows[i][1].ToString(), false);
            }

            for (int j = 0; j < dtTKKeamanan.Rows.Count; j++)
            {
                if (dropDownTingkatKeamanan.Text.ToLower() == dtTKKeamanan.Rows[j][0].ToString().ToLower())
                {
                    FindAndReplace(wordApp, "[o:" + dtTKKeamanan.Rows[j][1].ToString() + "]", "<b>" + dtTKKeamanan.Rows[j][1].ToString() + "</b>", false);
                    FindAndReplace(wordApp, "<b>" + dtTKKeamanan.Rows[j][1].ToString() + "</b>", dtTKKeamanan.Rows[j][1].ToString(), true);
                }
                else
                    FindAndReplace(wordApp, "[o:" + dtTKKeamanan.Rows[j][1].ToString() + "]", dtTKKeamanan.Rows[j][1].ToString(), false);
            }

            for (int k = 0; k < dtAsalSurat.Rows.Count; k++)
            {
                if (txtAsalSurat.Text.ToLower() == dtAsalSurat.Rows[k][0].ToString().ToLower())
                {
                    FindAndReplace(wordApp, "[o:" + dtAsalSurat.Rows[k][1].ToString() + "]", "<b>" + dtAsalSurat.Rows[k][1].ToString() + "</b>", false);
                    FindAndReplace(wordApp, "<b>" + dtAsalSurat.Rows[k][1].ToString() + "</b>", dtAsalSurat.Rows[k][1].ToString(), true);
                }
                else
                    FindAndReplace(wordApp, "[o:" + dtAsalSurat.Rows[k][1].ToString() + "]", dtAsalSurat.Rows[k][1].ToString(), false);
            }

            for (int l = 0; l < dtPosisiSurat.Rows.Count; l++)
            {
                if (txtTujuanDisposisi.Text.ToLower() == dtPosisiSurat.Rows[l][0].ToString().ToLower())
                {
                    FindAndReplace(wordApp, "[o:" + dtPosisiSurat.Rows[l][1].ToString() + "]", "<b>" + dtPosisiSurat.Rows[l][1].ToString() + "</b>", false);
                    FindAndReplace(wordApp, "<b>" + dtPosisiSurat.Rows[l][1].ToString() + "</b>", dtPosisiSurat.Rows[l][1].ToString(), true);
                }
                else
                    FindAndReplace(wordApp, "[o:" + dtPosisiSurat.Rows[l][1].ToString() + "]", dtPosisiSurat.Rows[l][1].ToString(), false);
            }

            wordApp.ActiveDocument.SaveAs(ref TfileName,
                ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject,
                ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject,
                ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject);

            object copies = GUI.GeneralSettings.OtomatisCetakAgendaValue.ToString();
            object pages = "1";
            object range = Microsoft.Office.Interop.Word.WdPrintOutRange.wdPrintCurrentPage;
            object items = Microsoft.Office.Interop.Word.WdPrintOutItem.wdPrintDocumentContent;
            object pageType = Microsoft.Office.Interop.Word.WdPrintOutPages.wdPrintAllPages;
            object oTrue = true;
            object oFalse = false;

            Microsoft.Office.Interop.Word.Document TaDoc = wordApp.Documents.Open(ref TfileName, ReadOnly: false, Visible: true);

            TaDoc.PrintOut(
                ref oTrue, ref oFalse, ref range, ref nullobject, ref nullobject, ref nullobject,
                ref items, ref copies, ref pages, ref pageType, ref oFalse, ref oTrue,
                ref nullobject, ref oFalse, ref nullobject, ref nullobject, ref nullobject, ref nullobject);

            object doNotSaved = Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges;

            ((Microsoft.Office.Interop.Word._Application)wordApp).Quit(ref nullobject, ref nullobject, ref nullobject);
        }

        private string InsertSurat(string _resetValue)
        {
            return SuratBusiness.Insert(AppDefaultSetting.surat_masuk_format_day, AppDefaultSetting.surat_masuk_format_month, AppDefaultSetting.surat_masuk_format_year, AppDefaultSetting.surat_masuk_format_nomor_agenda,
                AppDefaultSetting.surat_masuk_reset_role, _resetValue, AppDefaultSetting.surat_masuk_index_id, AppDefaultSetting.surat_masuk_concat_nomor_agenda, AppDefaultSetting.surat_masuk_minimum_id_lenght, 
                GlobalFunction.SqlCharChecker(dropDownTipe.Text), dtTanggalMasuk.Value, GlobalFunction.SqlCharChecker(txtNomorSurat.Text), dtTanggalSurat.Value, 
                GlobalFunction.SqlCharChecker(txtAsalSurat.Text), GlobalFunction.SqlCharChecker(txtPerihalSurat.Text), 
                GlobalFunction.SqlCharChecker(dropDownTingkatKeamanan.Text), GlobalFunction.SqlCharChecker(txtRingkasanIsi.Text),
                GlobalFunction.SqlCharChecker(txtLampiran.Text), T8UserLoginInfo.Username, this.start_index,
                SuratBusiness.GetSimbol(GlobalFunction.SqlCharChecker(dropDownTipe.Text), "kategori_surat"), 
                SuratBusiness.GetSimbol(GlobalFunction.SqlCharChecker(dropDownTingkatKeamanan.Text), "tingkat_keamanan"));
        }

        private void dropDownTipe_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            //lblNomorAgenda.Text = lblNomorAgenda.Text.Replace("{kategori}", dropDownTipe.Text);
        }

        private void chkOtomatisCetakLembarDisposisi_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chkOtomatisCetakLembarDisposisi.Checked)
                lblTujuanDisposisi.Text = "Tujuan Disposisi *";
            else
                lblTujuanDisposisi.Text = "Tujuan Disposisi";

        }

        private void radTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
