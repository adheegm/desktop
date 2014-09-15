using Business;
using Data;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using T8CoreEnginee;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace GUI.UIForms
{
    public partial class FrmHistoryPenyelesaian : Telerik.WinControls.UI.RadForm
    {
        string nomor_agenda, filter;
        FrmLoading frmLoading;
        System.Data.DataTable dt;
        public delegate void addRowDelegate(GridViewDataRowInfo row);
        private delegate void frmLoadingDelegate(bool _val);

        public FrmHistoryPenyelesaian(string _nomor_agenda)
        {
            InitializeComponent();
            this.nomor_agenda = _nomor_agenda;
        }

        private void FrmHistoryPenyelesaian_Load(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;
            GridHeaderGenerate();
            this.filter = "where nomor_agenda='" + this.nomor_agenda + "'";
            BindingDataGrid();
            lblNomorAgenda.Text = this.nomor_agenda;

            dr = SuratQuery.GetSingleDataSurat(this.nomor_agenda);

            string posisiSurat = SuratQuery.GetPenyelesaianAkhirSurat(this.nomor_agenda);
            if (posisiSurat == "")
            {
                lblPenyelesaian.Text = "{surat belum memiliki penyelesaian}";
                lblPenyelesaian.Font = new System.Drawing.Font("MS Reference Sans Serif", (float)9.75, FontStyle.Italic);
            }
            else
            {
                lblPenyelesaian.Text = posisiSurat;
                lblPenyelesaian.Font = new System.Drawing.Font("MS Reference Sans Serif", (float)9.75, FontStyle.Regular);
            }
            InitUserMenu();
        }

        private void GenerateDataHistory(object obj)
        {
            dt = SuratBusiness.SelectHistoryPenyelesaian(this.filter);//...SelectHistoryLoginUser(this.filter);

            Thread.Sleep(50);

            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                if (this.gvPenyelesaian.InvokeRequired)
                {
                    this.gvPenyelesaian.Invoke(new addRowDelegate(this.addRow), GetDataRow(dt, i));
                }
                else
                {
                    this.gvPenyelesaian.Rows.Insert(0, GetDataRow(dt, i));
                }

                Thread.Sleep(50);
            }

            Thread.Sleep(50);

            if (frmLoading.InvokeRequired)
            {
                this.frmLoading.Invoke(new frmLoadingDelegate(this.closeFrmLoading), true);
            }
            else
            {
                closeFrmLoading(true);
            }
        }

        private GridViewDataRowInfo GetDataRow(System.Data.DataTable dt, int i)
        {
            GridViewDataRowInfo dataRowInfo = new GridViewDataRowInfo(this.gvPenyelesaian.MasterView);
            dataRowInfo.Cells[0].Value = dt.Rows[i][0];
            dataRowInfo.Cells[1].Value = dt.Rows[i][1];
            dataRowInfo.Cells[2].Value = string.Format("{0:dd MMM yyyy}", dt.Rows[i][2]);
            dataRowInfo.Cells[3].Value = string.Format("{0:HH:mm:ss}", dt.Rows[i][2]);
            dataRowInfo.Cells[4].Value = string.Format("{0:dd MMM yyyy}", dt.Rows[i][3]);
            dataRowInfo.Cells[5].Value = dt.Rows[i][4];
            dataRowInfo.Cells[6].Value = dt.Rows[i][5];
            dataRowInfo.Cells[7].Value = dt.Rows[i][6];
            return dataRowInfo;
        }

        private void closeFrmLoading(bool _val)
        {
            frmLoading.Close();
        }

        private void addRow(GridViewDataRowInfo row)
        {
            this.gvPenyelesaian.Rows.Insert(0, row);
        }

        private void BindingDataGrid()
        {
            gvPenyelesaian.Rows.Clear();

            Thread bindingDataSurat;
            bindingDataSurat = new Thread(GenerateDataHistory);
            bindingDataSurat.IsBackground = true;
            bindingDataSurat.Start();

            frmLoading = new FrmLoading();
            frmLoading.ShowDialog();
        }

        private void InitUserMenu()
        {
            if (!T8UserLoginInfo.HakAkses.ToLower().Contains(("Administrator").ToLower()))
            {
                radCheckBox2.Dispose();
            }
            if (GeneralSettings.OtomatisSimpanHistoriLocal)
            {
                radCheckBox1.Checked = LocalSettings.AutoSizeHistoryPenyelesaian;
                radCheckBox2.Checked = LocalSettings.AdministratorTableHistoryPenyelesaian;
            }
        }

        private void GridHeaderGenerate()
        {
            ColumnSejarahDisposisi();
            ColumnSejarahDisposisiStyle();
        }

        private void ColumnSejarahDisposisiStyle()
        {
            gvPenyelesaian.Columns[0].Width = 40;
            gvPenyelesaian.Columns[0].IsVisible = false;
            gvPenyelesaian.Columns[0].WrapText = true;
            gvPenyelesaian.Columns[0].Width = 50;
            gvPenyelesaian.Columns[1].Width = 160;
            gvPenyelesaian.Columns[1].WrapText = true;
            gvPenyelesaian.Columns[2].Width = 100;
            gvPenyelesaian.Columns[2].IsVisible = false;
            gvPenyelesaian.Columns[2].WrapText = true;
            gvPenyelesaian.Columns[3].Width = 90;
            gvPenyelesaian.Columns[3].IsVisible = false;
            gvPenyelesaian.Columns[3].WrapText = true;
            gvPenyelesaian.Columns[4].Width = 150;
            gvPenyelesaian.Columns[4].WrapText = true;
            gvPenyelesaian.Columns[5].Width = 190;
            gvPenyelesaian.Columns[5].WrapText = true;
            gvPenyelesaian.Columns[6].Width = 240;
            gvPenyelesaian.Columns[6].WrapText = true;
            gvPenyelesaian.Columns[7].Width = 100;
            gvPenyelesaian.Columns[7].IsVisible = false;
            gvPenyelesaian.Columns[7].WrapText = true;
        }

        private void ColumnSejarahDisposisi()
        {
            gvPenyelesaian.Columns.Add("clmnID", "ID");
            gvPenyelesaian.Columns.Add("clmnNomorAgenda", "Nomor Agenda");
            gvPenyelesaian.Columns.Add("clmnTanggalInput", "Tanggal Input");
            gvPenyelesaian.Columns.Add("clmnJamInput", "Jam Input");
            gvPenyelesaian.Columns.Add("clmnTanggalDisposisi", "Tanggal Penyelesaian");
            gvPenyelesaian.Columns.Add("clmnTujuanDisposisi", "Penyelesaian Oleh");
            gvPenyelesaian.Columns.Add("clmnKeterangan", "Penyelesaian");
            gvPenyelesaian.Columns.Add("clmnAdmin", "User");
        }

        private void gvPenyelesaian_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            Padding pad = new System.Windows.Forms.Padding(3);
            e.CellElement.Padding = pad;
        }

        private void gvPenyelesaian_ViewCellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement is GridHeaderCellElement)
            {
                Padding pad = new System.Windows.Forms.Padding(2);
                e.CellElement.Font = new System.Drawing.Font("Segoe UI", (float)9, FontStyle.Bold);
                e.CellElement.Padding = pad;
                e.CellElement.TextAlignment = ContentAlignment.MiddleLeft;
            }
        }

        private void radCheckBox1_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            gvPenyelesaian.AutoSizeRows = radCheckBox1.Checked;
            if (GeneralSettings.OtomatisSimpanHistoriLocal)
            {
                LocalSettings.SetSettings("AutoSizeHistoryPenyelesaian", radCheckBox1.Checked);
            }
        }

        private void radCheckBox2_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            gvPenyelesaian.Columns[0].IsVisible = radCheckBox2.Checked;
            gvPenyelesaian.Columns[2].IsVisible = radCheckBox2.Checked;
            gvPenyelesaian.Columns[3].IsVisible = radCheckBox2.Checked;
            gvPenyelesaian.Columns[7].IsVisible = radCheckBox2.Checked;
            if (GeneralSettings.OtomatisSimpanHistoriLocal)
            {
                LocalSettings.SetSettings("AdministratorTableHistoryPenyelesaian", radCheckBox2.Checked);
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Anda yakin akan mencetak history penyelesaian surat ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                == System.Windows.Forms.DialogResult.No) return;
            if (gvPenyelesaian.SelectedRows.Count != 0)
            {
                PrintAgenda();
            }
        }

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

            string keterangan, penyelesaian_oleh, tanggal_penyelesaian;

            penyelesaian_oleh = gvPenyelesaian.MasterView.Rows[gvPenyelesaian.SelectedRows[0].Index].Cells[5].Value.ToString();
            keterangan = gvPenyelesaian.MasterView.Rows[gvPenyelesaian.SelectedRows[0].Index].Cells[6].Value.ToString();
            tanggal_penyelesaian = gvPenyelesaian.MasterView.Rows[gvPenyelesaian.SelectedRows[0].Index].Cells[4].Value.ToString();

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

            FindAndReplace(wordApp, "[tanggal_penyelesaian]", string.Format("{0:" + AppDefaultSetting.surat_masuk_date_format + "}", tanggal_penyelesaian), false);
            FindAndReplace(wordApp, "[penyelesaian_oleh]", penyelesaian_oleh, false);
            FindAndReplace(wordApp, "[penyelesaian]", keterangan, false);

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
                if (penyelesaian_oleh.ToLower() == dtPosisiSurat.Rows[l][0].ToString().ToLower())
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

        DataRow dr;
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

    }
}
