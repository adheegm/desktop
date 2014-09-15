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
    public partial class frmInfoLokasiSurat : Telerik.WinControls.UI.RadForm
    {
        string nomor_agenda;
        FrmDetailSurat frmDetailSurat;
        public frmInfoLokasiSurat(FrmDetailSurat _frmDetailSurat, string _nomor_agenda)
        {
            InitializeComponent();
            this.nomor_agenda = _nomor_agenda;
            this.frmDetailSurat = _frmDetailSurat;
        }

        private void frmInfoLokasiSurat_Load(object sender, EventArgs e)
        {
            DropDownLokasiFisikSurat();
            lblNomorAgenda.Text = this.nomor_agenda;
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

        private void radButton2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddLokasiFisikSurat.Text))
            {
                try
                {
                    SuratBusiness.InsertLokasiFisikSurat(this.nomor_agenda, GlobalFunction.SqlCharChecker(ddLokasiFisikSurat.Text), 
                        GlobalFunction.SqlCharChecker(txtKeteranganLokasi.Text), T8UserLoginInfo.Username);
                    MessageBox.Show(this, "Data lokasi surat sudah diubah.","Data disimpan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.frmDetailSurat.BindingLokasi();
                    this.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(this, ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(this, "\"Lokasi Surat\" tidak boleh kosong.", "Data Belum lengkap.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                ddLokasiFisikSurat.Focus();
                return;
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
