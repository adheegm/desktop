using Business;
using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace GUI.UIForms.Surat
{
    public partial class FrmInputReferensiSurat : Telerik.WinControls.UI.RadForm
    {
        string act;
        string nomor_agenda;
        FrmDetailSurat frmInfoSuratKeluar;
        public FrmInputReferensiSurat(FrmDetailSurat _frmInfoSuratKeluar, string _act, string _nomor_agenda)
        {
            InitializeComponent();
            this.act = _act;
            this.nomor_agenda = _nomor_agenda;
            this.frmInfoSuratKeluar = _frmInfoSuratKeluar;
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmInputReferensiSurat_Load(object sender, EventArgs e)
        {
            AutoCompleteSuratMasuk();
            lblNomorAgenda.Text = this.nomor_agenda;
        }

        private void AutoCompleteSuratMasuk()
        {
            txtReferensiSurat.AutoCompleteDataSource = Data.SuratQuery.GetNomorAgendaSK("", 0, 0);
            txtReferensiSurat.AutoCompleteDisplayMember = "nomor_surat";
        }


        //private void GenerateDataSuratkeluar()
        //{
        //    DataTable dt = Data.SuratQuery.GetNomorAgendaSK("", 0, 0);
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        txtReferensiSurat.Items.Add(dt.Rows[i][0].ToString());
        //    }
        //}

        private void radButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Anda yakin akan mengubah data referensi surat?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    if (!SuratQuery.IsSuratKeluar(GlobalFunction.SqlCharChecker(txtReferensiSurat.Text.Replace("\0", ""))))
                    {
                        MessageBox.Show(this, "Data surat referensi tidak ditemukan, silahkan cek kembali.", "Data Salah", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    SuratBusiness.ReferensiSuratMasuk(this.act, lblNomorAgenda.Text, GlobalFunction.SqlCharChecker(txtReferensiSurat.Text.Replace("\0", "")));
                    this.frmInfoSuratKeluar.lblReferensiSurat.Text = txtReferensiSurat.Text;
                    this.frmInfoSuratKeluar.lblReferensiSurat.Font = new Font("MS Reference Sans Serif", (float)9.75, FontStyle.Regular);
                    MessageBox.Show(this, "Data sudah disimpan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch(Exception ex)
                { }
            }
        }
    }
}
