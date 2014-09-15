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
using Data;
using Microsoft.Office.Interop.Word;

namespace GUI.UIForms
{
    public partial class FrmPenyelesaian : Telerik.WinControls.UI.RadForm
    {
        string nomor_agenda;
        public FrmPenyelesaian(string _nomor_agenda)
        {
            InitializeComponent();
            this.nomor_agenda = _nomor_agenda;
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblNomorAgenda.Text.Replace("\0", "")))
            {
                MessageBox.Show(this, "\"Nomor Agenda\" tidak boleh kosong.", "Input Kosong", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                lblNomorAgenda.Focus();
                return;
            }

            if (!SuratQuery.IsSuratMasuk(lblNomorAgenda.Text.Replace("\0", "")))
            {
                MessageBox.Show(this, "Data surat tidak ditemukan.", "Input Kosong", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                lblNomorAgenda.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtPenyelesaianOleh.Text))
            {
                MessageBox.Show(this, "Penyelesaian oleh tidak boleh kosong.", "Data tidak lengkap", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtPenyelesaianOleh.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtPenyelesaian.Text))
            {
                MessageBox.Show(this, "Penyelesaian tidak boleh kosong.", "Data tidak lengkap", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtPenyelesaian.Focus();
                return;
            }

            if (MessageBox.Show(this, "Apakah Anda yakin akan melakukan penyelesaian pada surat ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                == System.Windows.Forms.DialogResult.No) return;
            SuratBusiness.InsertHistoryPenyelesaian
                (lblNomorAgenda.Text.Replace("\0", ""), dtTanggalPenyelesaian.Value, GlobalFunction.SqlCharChecker(txtPenyelesaianOleh.Text),
                GlobalFunction.SqlCharChecker(txtPenyelesaian.Text), T8UserLoginInfo.Username);
            MessageBox.Show(this, "Data penyelesaian sudah disimpan.", "Simpan Disposisi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            if (chkOtomatisCetakLembarDisposisi.Checked)
            {
                PrintAgenda();
            }


            clearInput();//this.Close();
        }

        DataRow dr;

        private void PrintAgenda()
        {
            object nullobject = Type.Missing;
            object missing = Type.Missing;

            object fileName = AppDefaultSetting.surat_masuk_penyelesaian_template_path;
            object TfileName = System.Windows.Forms.Application.StartupPath + @"\lembar_penyelesaian.docx";

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




            //FindAndReplace(wordApp, "[nomor_agenda]", nomor_agenda, false);
            //FindAndReplace(wordApp, "[kategori]", dropDownTipe.Text, false);
            //FindAndReplace(wordApp, "[tanggal_terima]", string.Format("{0:" + AppDefaultSetting.surat_masuk_date_format + "}", dtTanggalMasuk.Value), false);
            //FindAndReplace(wordApp, "[nomor_surat]", txtNomorSurat.Text, false);
            //FindAndReplace(wordApp, "[tanggal_surat]", string.Format("{0:" + AppDefaultSetting.surat_masuk_date_format + "}", dtTanggalSurat.Value), false);
            //FindAndReplace(wordApp, "[asal_surat]", txtAsalSurat.Text, false);
            //FindAndReplace(wordApp, "[perihal]", txtPerihalSurat.Text, false);
            //FindAndReplace(wordApp, "[tingkat_keamanan]", dropDownTingkatKeamanan.Text, false);
            //FindAndReplace(wordApp, "[ringkasan_isi]", txtRingkasanIsi.Text, false);
            //FindAndReplace(wordApp, "[lampiran]", txtLampiran.Text, false);


            //FindAndReplace(wordApp, "[tanggal_disposisi]", string.Format("{0:" + AppDefaultSetting.surat_masuk_date_format + "}", dtTanggalDisposisi.Value), false);
            //FindAndReplace(wordApp, "[tujuan_disposisi]", txtTujuanDisposisi.Text, false);
            //FindAndReplace(wordApp, "[isi_disposisi]", txtIsisDisposisi.Text, false);

            //FindAndReplace(wordApp, "[referensi_surat]", txtReferensiSurat.Text, false);
            //FindAndReplace(wordApp, "[lokasi_fisik]", ddLokasiFisikSurat.Text, false);
            //FindAndReplace(wordApp, "[info_lokasi]", txtKeteranganLokasi.Text, false);
            //FindAndReplace(wordApp, "[jenis_pengiriman]", ddJenisPengiriman.Text, false);
            //FindAndReplace(wordApp, "[info_pengiriman]", txtInfoPengiriman.Text, false);

            //FindAndReplace(wordApp, "[datetime_print]", string.Format("{0:" + AppDefaultSetting.surat_masuk_date_format + "}", DateTime.Now), false);
            //FindAndReplace(wordApp, "[user]", T8UserLoginInfo.Username, false);





            FindAndReplace(wordApp, "[nomor_agenda]", nomor_agenda, false);
            FindAndReplace(wordApp, "[tanggal_terima]", string.Format("{0:" + AppDefaultSetting.surat_masuk_date_format + "}", this.dr[2]), false);
            FindAndReplace(wordApp, "[nomor_surat]", this.dr[3], false);
            FindAndReplace(wordApp, "[kategori]", this.dr[4], false);
            FindAndReplace(wordApp, "[tanggal_surat]", string.Format("{0:" + AppDefaultSetting.surat_masuk_date_format + "}", this.dr[5]), false);
            FindAndReplace(wordApp, "[asal_surat]", this.dr[6], false);
            FindAndReplace(wordApp, "[perihal]", this.dr[7], false);
            FindAndReplace(wordApp, "[tingkat_keamanan]", this.dr[8], false);
            FindAndReplace(wordApp, "[ringkasan_isi]", this.dr[9], false);
            FindAndReplace(wordApp, "[lampiran]", this.dr[10], false);
            FindAndReplace(wordApp, "[datetime_print]", string.Format("{0:" + AppDefaultSetting.surat_masuk_date_format + "}", DateTime.Now), false);
            FindAndReplace(wordApp, "[user]", T8UserLoginInfo.Username, false);

            FindAndReplace(wordApp, "[tanggal_penyelesaian]", string.Format("{0:" + AppDefaultSetting.surat_masuk_date_format + "}", dtTanggalPenyelesaian.Value), false);
            FindAndReplace(wordApp,"[penyelesaian_oleh]", txtPenyelesaianOleh.Text, false);
            FindAndReplace(wordApp, "[penyelesaian]", txtPenyelesaian.Text, false);

            System.Data.DataTable dtKategori = TemplateQuery.GetTemplateAktif("kategori_surat");
            for (int i = 0; i < dtKategori.Rows.Count; i++)
            {
                if (this.dr[4].ToString().ToLower() == dtKategori.Rows[i][0].ToString().ToLower())
                {
                    FindAndReplace(wordApp, "[o:" + dtKategori.Rows[i][1].ToString() + "]", "<b>" + dtKategori.Rows[i][1].ToString() + "</b>", false);
                    FindAndReplace(wordApp, "<b>" + dtKategori.Rows[i][1].ToString() + "</b>", dtKategori.Rows[i][1].ToString(), true);
                }
                else
                    FindAndReplace(wordApp, "[o:" + dtKategori.Rows[i][1].ToString() + "]", dtKategori.Rows[i][1].ToString(), false);
            }

            System.Data.DataTable dtTKKeamanan = TemplateQuery.GetTemplateAktif("tingkat_keamanan");
            for (int j = 0; j < dtTKKeamanan.Rows.Count; j++)
            {
                if (this.dr[8].ToString().ToLower() == dtTKKeamanan.Rows[j][0].ToString().ToLower())
                {
                    FindAndReplace(wordApp, "[o:" + dtTKKeamanan.Rows[j][1].ToString() + "]", "<b>" + dtTKKeamanan.Rows[j][1].ToString() + "</b>", false);
                    FindAndReplace(wordApp, "<b>" + dtTKKeamanan.Rows[j][1].ToString() + "</b>", dtTKKeamanan.Rows[j][1].ToString(), true);
                }
                else
                    FindAndReplace(wordApp, "[o:" + dtTKKeamanan.Rows[j][1].ToString() + "]", dtTKKeamanan.Rows[j][1].ToString(), false);
            }

            System.Data.DataTable dtAsalSurat = TemplateQuery.GetTemplateAktif("asal_surat");
            for (int k = 0; k < dtAsalSurat.Rows.Count; k++)
            {
                if (this.dr[6].ToString().ToLower() == dtAsalSurat.Rows[k][0].ToString().ToLower())
                {
                    FindAndReplace(wordApp, "[o:" + dtAsalSurat.Rows[k][1].ToString() + "]", "<b>" + dtAsalSurat.Rows[k][1].ToString() + "</b>", false);
                    FindAndReplace(wordApp, "<b>" + dtAsalSurat.Rows[k][1].ToString() + "</b>", dtAsalSurat.Rows[k][1].ToString(), true);
                }
                else
                    FindAndReplace(wordApp, "[o:" + dtAsalSurat.Rows[k][1].ToString() + "]", dtAsalSurat.Rows[k][1].ToString(), false);
            }

            System.Data.DataTable dtPosisiSurat = TemplateQuery.GetTemplateAktif("posisi_surat");
            for (int l = 0; l < dtPosisiSurat.Rows.Count; l++)
            {
                if (lblPosisiSaatIni.Text.ToLower() == dtPosisiSurat.Rows[l][0].ToString().ToLower())
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

            object copies = GUI.GeneralSettings.OtomatisCetakAgendaValuePenyelesaian.ToString();
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

        private void clearInput()
        {
            lblNomorAgenda.Text = "";
            lblNomorAgenda.Focus();
            txtPenyelesaian.Text = "";
            txtPenyelesaianOleh.Text = "";
            dtTanggalPenyelesaian.Value = DateTime.Now;
        }

        private void FrmPenyelesaian_Load(object sender, EventArgs e)
        {
            lblNomorAgenda.AutoCompleteDataSource = Data.SuratQuery.GetNomorAgenda("", 0, 0);
            lblNomorAgenda.AutoCompleteDisplayMember = "nomor_agenda";
            TxtPenyelesaianOlehAutoComplete();
            lblNomorAgenda.Text = this.nomor_agenda;
            BindingPosisiSurat();
        }

        private void BindingPosisiSurat()
        {
            string posisiSurat = SuratQuery.GetPosisiSurat(this.nomor_agenda);
            if (posisiSurat == "")
            {
                lblPosisiSaatIni.Text = "{surat belum didisposisi}";
                lblPosisiSaatIni.Font = new System.Drawing.Font("MS Reference Sans Serif", (float)9.75, FontStyle.Italic);
            }
            else
            {
                lblPosisiSaatIni.Text = posisiSurat;
                lblPosisiSaatIni.Font = new System.Drawing.Font("MS Reference Sans Serif", (float)9.75, FontStyle.Regular);
            }
            dr = SuratQuery.GetSingleDataSurat(this.nomor_agenda);
        }

        private void TxtPenyelesaianOlehAutoComplete()
        {
            System.Data.DataTable dt = TemplateQuery.GetTemplateAktif("posisi_surat");
            txtPenyelesaianOleh.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtPenyelesaianOleh.AutoCompleteSource = AutoCompleteSource.CustomSource;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                txtPenyelesaianOleh.AutoCompleteCustomSource.Add(dt.Rows[i][0].ToString());
            }
        }

        private void lblNomorAgenda_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.nomor_agenda = lblNomorAgenda.Text.Replace("\0", "");
                BindingPosisiSurat();
                //clearInput();
            }
            catch (Exception ex)
            { }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
