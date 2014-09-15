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
using Telerik.WinControls.UI;

namespace GUI.UIForms.Surat
{
    public partial class FrmInfoSuratKeluar : Telerik.WinControls.UI.RadForm
    {
        GridViewDataRowInfo dr;
        string filter;

        public FrmInfoSuratKeluar(GridViewDataRowInfo _dr)
        {
            InitializeComponent();
            dr = _dr;
        }

        private void FrmInfoSuratKeluar_Load(object sender, EventArgs e)
        {
            this.filter = "where nomor_agenda='" + (string)dr.Cells[0].Value + "'";
            lblNomorAgenda.Text = (string)dr.Cells[0].Value;
            lblTglMasuk.Text = (string)dr.Cells[1].Value;
            lblAsalSurat.Text = (string)dr.Cells[2].Value;
            lblPerihal.Text = (string)dr.Cells[3].Value;
            lblTkKeamanan.Text = (string)dr.Cells[4].Value;
            lblRingkasanIsi.Text = (string)dr.Cells[5].Value;
            lblLampiran.Text = (string)dr.Cells[6].Value;

            BindingInfo();
            string str = SuratQuery.GetSuratRefensiSuratKeluar(this.lblNomorAgenda.Text);
            if (str != "")
                lblReferensiSurat.Text = str;
            else
            {
                lblReferensiSurat.Text = "{surat tidak memiliki referensi}";
                lblReferensiSurat.Font = lblJenisPengiriman.Font = new Font("MS Reference Sans Serif", (float)9.75, FontStyle.Italic);
            }
        }

        private void BindingInfo()
        {
            BindingJenis();
        }

        public void BindingJenis()
        {
            DataTable dtJenisPengiriman = SuratBusiness.getJenisPengiriman(this.lblNomorAgenda.Text);

            if (dtJenisPengiriman.Rows.Count == 0)
            {
                lblJenisPengiriman.Text = "{data kosong}";
                lblJenisPengiriman.Font = new Font("MS Reference Sans Serif", (float)9.75, FontStyle.Italic);

                lblInfoPengiriman.Text = "{data kosong}";
                lblInfoPengiriman.Font = new Font("MS Reference Sans Serif", (float)9.75, FontStyle.Italic);
            }
            else
            {
                lblJenisPengiriman.Text = dtJenisPengiriman.Rows[0][0].ToString();
                lblJenisPengiriman.Font = new Font("MS Reference Sans Serif", (float)9.75, FontStyle.Regular);

                lblInfoPengiriman.Text = dtJenisPengiriman.Rows[0][1].ToString();
                lblInfoPengiriman.Font = new Font("MS Reference Sans Serif", (float)9.75, FontStyle.Regular);
            }
        }

        private void radButton5_Click(object sender, EventArgs e)
        {
            Surat.FrmInfoPengiriman frmInfoPengiriman = new Surat.FrmInfoPengiriman(this, lblNomorAgenda.Text);
            frmInfoPengiriman.ShowInTaskbar = false;
            frmInfoPengiriman.ShowDialog();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            string act;
            if (lblReferensiSurat.Text == "{surat tidak memiliki referensi}")
                act = "new";
            else
                act = "ubah";
            Surat.FrmInputReferensiSuratKeluar frmReferensi = new FrmInputReferensiSuratKeluar(this, act, lblNomorAgenda.Text);
            frmReferensi.ShowInTaskbar = false;
            frmReferensi.ShowDialog();
  
        }

    }
}
