using Business;
using Data;
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
    public partial class FrmInfoPengiriman : Telerik.WinControls.UI.RadForm
    {
        string nomor_agenda;
        FrmDetailSurat frmDetailSurat;

        Surat.FrmInfoSuratKeluar frmDetailSuratKeluar;
        public FrmInfoPengiriman(FrmDetailSurat _frmDetailSurat, string _nomor_agenda)
        {
            InitializeComponent();
            this.nomor_agenda = _nomor_agenda;
            this.frmDetailSurat = _frmDetailSurat;
        }

        public FrmInfoPengiriman(Surat.FrmInfoSuratKeluar _frmDetailSurat, string _nomor_agenda)
        {
            InitializeComponent();
            this.nomor_agenda = _nomor_agenda;
            this.frmDetailSuratKeluar = _frmDetailSurat;
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddJenisPengiriman.Text))
            {
                try
                {
                    if (this.frmDetailSurat != null)
                    {
                        SuratBusiness.InsertJenisPengiriman(nomor_agenda, GlobalFunction.SqlCharChecker(ddJenisPengiriman.Text), GlobalFunction.SqlCharChecker(txtInfoPengiriman.Text));
                        MessageBox.Show(this, "Data pengiriman sudah diubah.", "Data disimpan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.frmDetailSurat.BindingJenis();
                        this.Close();
                    }
                    else
                    {
                        SuratBusiness.InsertJenisPengiriman(nomor_agenda, GlobalFunction.SqlCharChecker(ddJenisPengiriman.Text), GlobalFunction.SqlCharChecker(txtInfoPengiriman.Text));
                        MessageBox.Show(this, "Data pengiriman sudah diubah.", "Data disimpan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.frmDetailSuratKeluar.BindingJenis();
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(this, "\"Jenis Pengiriman\" tidak boleh kosong.", "Data Belum lengkap.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                ddJenisPengiriman.Focus();
                return;
            }
        }

        private void FrmInfoPengiriman_Load(object sender, EventArgs e)
        {
            DropDownJenisPengiriman();
            lblNomorAgenda.Text = this.nomor_agenda;
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

        private void radButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
