using Business;
using Data;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using T8CoreEnginee;
using Telerik.WinControls;

namespace GUI.UIForms.Surat
{
    public partial class FrmSuratKeluar : Telerik.WinControls.UI.RadForm
    {
        FrmMain frmMain;
        public FrmSuratKeluar(FrmMain _frmMain)
        {
            InitializeComponent();
            this.frmMain = _frmMain;
        }

        private void FrmSuratKeluar_Load(object sender, EventArgs e)
        {
            DropDownKategori();
            TxtAsalSuratAutoComplete();
            AutoCompleteSuratMasuk();
            DropDownTingkatKeamananItems();
            DropDownJenisPengiriman();
            InitInput();
        }

        System.Data.DataTable dtTujuan;
        private void TxtAsalSuratAutoComplete()
        {
            dtTujuan = TemplateQuery.GetTemplateAktif("asal_surat");
            txtTujuan.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtTujuan.AutoCompleteSource = AutoCompleteSource.CustomSource;
            for (int i = 0; i < dtTujuan.Rows.Count; i++)
            {
                txtTujuan.AutoCompleteCustomSource.Add(dtTujuan.Rows[i][0].ToString());
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

        System.Data.DataTable dtTKKeamanan;
        private void DropDownTingkatKeamananItems()
        {
            if (T8UserLoginInfo.HakAkses.ToLower().Contains(("Administrator").ToLower()))
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


        private void InitInput()
        {
            dtTanggalKirim.Value = DateTime.Now;
            ddKategori.SelectedIndex = -1;
            txtTujuan.Text = "";
            txtInfoPengiriman.Text = "";
            txtLampiran.Text = "";
            txtPerihalSurat.Text = "";
            txtRingkasanIsi.Text = "";
            txtReferensiSurat.Text = "";
            ddJenisPengiriman.SelectedIndex = -1;
            dropDownTingkatKeamanan.SelectedIndex = -1;
            chkOtomatisCetakLembarDisposisi.Checked = false;
        }

        private void AutoCompleteSuratMasuk()
        {
            txtReferensiSurat.AutoCompleteDataSource = Data.SuratQuery.GetNomorAgenda("", 0, 0);
            txtReferensiSurat.AutoCompleteDisplayMember = "nomor_agenda";
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
                ddKategori.Items.Add(dtKategori.Rows[i][0].ToString());
            }
        }

        public string nomor_surat;
        public int start_index;
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ddKategori.Text))
            {
                MessageBox.Show(this, "\"Kategori surat\" tidak boleh kosong.", "Input Kosong", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                ddKategori.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtTujuan.Text))
            {
                MessageBox.Show(this, "\"Tujuan surat\" tidak boleh kosong.", "Input Kosong", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtTujuan.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtTujuan.Text))
            {
                MessageBox.Show(this, "\"Asal surat\" tidak boleh kosong.", "Input Kosong", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtTujuan.Focus();
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

            if (MessageBox.Show(this, "Anda yakin akan menginputkan data surat?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    string resetValue = "";
                    string reset_id = "";

                    if (AppDefaultSetting.surat_keluar_reset_role.ToLower() == "kategori".ToLower())
                        resetValue = ddKategori.Text;
                    else if (AppDefaultSetting.surat_keluar_reset_role.ToLower() == "tkkeamanan".ToLower())
                        resetValue = dropDownTingkatKeamanan.Text;

                    if (AppDefaultSetting.surat_keluar_reset_role.ToLower() == "kategori".ToLower())
                        reset_id = AppDefaultSetting.surat_keluar_reset_role;
                    else if (AppDefaultSetting.surat_keluar_reset_role.ToLower() == "tkkeamanan".ToLower())
                        reset_id = AppDefaultSetting.surat_keluar_reset_role;
                    else if (AppDefaultSetting.surat_keluar_reset_role.ToLower() == "daily".ToLower())
                        reset_id = string.Format("{0:yyyy-MM-dd}", dtTanggalKirim.Value);
                    else if (AppDefaultSetting.surat_keluar_reset_role.ToLower() == "monthly".ToLower())
                        reset_id = string.Format("{0:yyyy-MM-dd}", dtTanggalKirim.Value);
                    else if (AppDefaultSetting.surat_keluar_reset_role.ToLower() == "yearly".ToLower())
                        reset_id = string.Format("{0:yyyy-MM-dd}", dtTanggalKirim.Value);
                    else
                        reset_id = "";

                    start_index = 1;
                    if (JumlahSurat(reset_id, resetValue) == 0)
                    {
                        if (AppDefaultSetting.surat_keluar_index_start.ToString().ToLower() != "Flat (Value = 1)".ToLower())
                        {
                            Surat.FrmStartIndexSuratKeluar frmStartIndex = new Surat.FrmStartIndexSuratKeluar(this);
                            frmStartIndex.ShowDialog();
                        }
                    }

                    if (this.start_index == 0)
                        return;

                    if (AppDefaultSetting.surat_keluar_reset_role.ToLower() == "kategori".ToLower())
                        resetValue = ddKategori.Text;
                    else if (AppDefaultSetting.surat_keluar_reset_role.ToLower() == "tkkeamanan".ToLower())
                        resetValue = dropDownTingkatKeamanan.Text;

                    this.nomor_surat = InsertSurat(resetValue);

                    if (!string.IsNullOrEmpty(ddJenisPengiriman.Text))
                    {
                        SuratBusiness.InsertJenisPengiriman(nomor_surat, GlobalFunction.SqlCharChecker(ddJenisPengiriman.Text),
                            GlobalFunction.SqlCharChecker(txtInfoPengiriman.Text));
                    }

                    if (!string.IsNullOrEmpty(txtReferensiSurat.Text))
                    {
                        if (SuratQuery.IsSuratMasuk(GlobalFunction.SqlCharChecker(txtReferensiSurat.Text.Replace("\0", ""))))
                            SuratBusiness.InsertReferensiSuratKeluar(nomor_surat, GlobalFunction.SqlCharChecker(txtReferensiSurat.Text.Replace("\0", "")));
                    }

                    MessageBox.Show(this, "Nomor agenda surat: " + nomor_surat, "Data Disimpan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.frmMain.insertSingleSuratKeluar(this);
                    MessageBox.Show(this, "Data surat sudah disimpan di database.", "Input sukses", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    if (chkOtomatisCetakLembarDisposisi.Checked)
                        PrintAgenda();

                    clearInput();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private int JumlahSurat(string _resetID, string _reset_value)
        {
            return SuratQuery.JumlahSuratKeluar(_resetID, _reset_value);
        }

        private void clearInput()
        {
            ddKategori.SelectedIndex = -1;
            ddKategori.Text = "";
            dtTanggalKirim.Value = DateTime.Now;
            txtTujuan.Text = "";
            dropDownTingkatKeamanan.SelectedIndex = -1;
            dropDownTingkatKeamanan.Text = "";
            txtLampiran.Text = "";
            txtPerihalSurat.Text = "";
            ddKategori.Select();
            txtRingkasanIsi.Text = "";
            txtInfoPengiriman.Text = "";
            txtReferensiSurat.Text = "";
            ddJenisPengiriman.SelectedIndex = -1;
            if (GUI.GeneralSettings.OtomatisCetakAgenda)
                chkOtomatisCetakLembarDisposisi.Checked = true;
        }

        private void PrintAgenda()
        {
            object nullobject = Type.Missing;
            object missing = Type.Missing;

            object fileName = AppDefaultSetting.surat_keluar_template_path;
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
            FindAndReplace(wordApp, "[nomor_surat]", this.nomor_surat, false);
            FindAndReplace(wordApp, "[kategori]", ddKategori.Text, false);
            FindAndReplace(wordApp, "[tanggal_kirim]", string.Format("{0:" + AppDefaultSetting.surat_masuk_date_format + "}", dtTanggalKirim.Value), false);
            FindAndReplace(wordApp, "[tujuan]", txtTujuan.Text, false);
            FindAndReplace(wordApp, "[perihal]", txtPerihalSurat.Text, false);
            FindAndReplace(wordApp, "[tingkat_keamanan]", dropDownTingkatKeamanan.Text, false);
            FindAndReplace(wordApp, "[ringkasan_isi]", txtRingkasanIsi.Text, false);
            FindAndReplace(wordApp, "[lampiran]", txtLampiran.Text, false);

            FindAndReplace(wordApp, "[referensi_surat]", txtReferensiSurat.Text, false);
            FindAndReplace(wordApp, "[jenis_pengiriman]", ddJenisPengiriman.Text, false);
            FindAndReplace(wordApp, "[info_pengiriman]", txtInfoPengiriman.Text, false);

            FindAndReplace(wordApp, "[datetime_print]", string.Format("{0:" + AppDefaultSetting.surat_masuk_date_format + "}", DateTime.Now), false);
            FindAndReplace(wordApp, "[user]", T8UserLoginInfo.Username, false);

            for (int i = 0; i < dtKategori.Rows.Count; i++)
            {
                if (ddKategori.Text.ToLower() == dtKategori.Rows[i][0].ToString().ToLower())
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

            for (int k = 0; k < dtTujuan.Rows.Count; k++)
            {
                if (txtTujuan.Text.ToLower() == dtTujuan.Rows[k][0].ToString().ToLower())
                {
                    FindAndReplace(wordApp, "[o:" + dtTujuan.Rows[k][1].ToString() + "]", "<b>" + dtTujuan.Rows[k][1].ToString() + "</b>", false);
                    FindAndReplace(wordApp, "<b>" + dtTujuan.Rows[k][1].ToString() + "</b>", dtTujuan.Rows[k][1].ToString(), true);
                }
                else
                    FindAndReplace(wordApp, "[o:" + dtTujuan.Rows[k][1].ToString() + "]", dtTujuan.Rows[k][1].ToString(), false);
            }

            wordApp.ActiveDocument.SaveAs(ref TfileName,
                ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject,
                ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject,
                ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject);

            object copies = GUI.GeneralSettings.OtomatisCetakAgendaValueSK.ToString();
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

        private string InsertSurat(string _resetValue)
        {
            return SuratBusiness.Insertkeluar(AppDefaultSetting.surat_keluar_format_day, AppDefaultSetting.surat_keluar_format_month, AppDefaultSetting.surat_keluar_format_year,
                AppDefaultSetting.surat_keluar_format_nomor_agenda, AppDefaultSetting.surat_keluar_reset_role, _resetValue, AppDefaultSetting.surat_keluar_index_id,
                AppDefaultSetting.surat_keluar_concat_nomor_agenda, AppDefaultSetting.surat_keluar_minimum_id_lenght, GlobalFunction.SqlCharChecker(ddKategori.Text), 
                dtTanggalKirim.Value, GlobalFunction.SqlCharChecker(txtTujuan.Text), GlobalFunction.SqlCharChecker(txtPerihalSurat.Text), 
                GlobalFunction.SqlCharChecker(dropDownTingkatKeamanan.Text), GlobalFunction.SqlCharChecker(txtRingkasanIsi.Text),
                GlobalFunction.SqlCharChecker(txtLampiran.Text), T8UserLoginInfo.Username, this.start_index,
                SuratBusiness.GetSimbol(GlobalFunction.SqlCharChecker(ddKategori.Text), "kategori_surat"), 
                SuratBusiness.GetSimbol(GlobalFunction.SqlCharChecker(dropDownTingkatKeamanan.Text), "tingkat_keamanan"));
        }
    }
}
