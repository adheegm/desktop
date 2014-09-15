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
    public partial class FrmEditSuratKeluar : Telerik.WinControls.UI.RadForm
    {
        FrmMain frmMain;
        string nomor_agenda;
        DataRow drAsli;
        public FrmEditSuratKeluar(FrmMain _frmmain, string _nomor_agenda)
        {
            InitializeComponent();
            this.frmMain = _frmmain;
            this.nomor_agenda = _nomor_agenda;
        }

        private void FrmEditSuratKeluar_Load(object sender, EventArgs e)
        {
            lblNomorAgenda.AutoCompleteDataSource = Data.SuratQuery.GetNomorAgendaSK("", 0, 0);
            lblNomorAgenda.AutoCompleteDisplayMember = "nomor_surat";
            TxtAsalSuratAutoComplete();
            DropDownTingkatKeamananItems();
            BindingAgenda();
        }

        private void BindingAgenda()
        {
            lblNomorAgenda.Text = this.nomor_agenda;

            drAsli = SuratQuery.GetSingleDataSuratSK(this.nomor_agenda);

            dtTanggalKirim.Value = (DateTime)drAsli[3];
            txtTujuan.Text = drAsli[4].ToString();
            txtPerihalSurat.Text = drAsli[5].ToString();
            dropDownTingkatKeamanan.Text = drAsli[6].ToString();
            txtRingkasanIsi.Text = drAsli[7].ToString();
            txtLampiran.Text = drAsli[8].ToString();
        }

        private void TxtAsalSuratAutoComplete()
        {
            DataTable dt = TemplateQuery.GetTemplateAktif("asal_surat");
            txtTujuan.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtTujuan.AutoCompleteSource = AutoCompleteSource.CustomSource;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                txtTujuan.AutoCompleteCustomSource.Add(dt.Rows[i][0].ToString());
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

        private void lblNomorAgenda_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.nomor_agenda = GlobalFunction.SqlCharChecker(lblNomorAgenda.Text.Replace("\0", ""));
                BindingAgenda();
            }
            catch (Exception ex)
            {
                clearInputError();
            }
        }

        private void clearInputError()
        {
            dtTanggalKirim.Value = DateTime.Now;
            txtLampiran.Text = "";
            txtTujuan.Text = "";
            txtPerihalSurat.Text = "";
            txtRingkasanIsi.Text = "";
            dropDownTingkatKeamanan.Text = "";
        }

        private void btnBersihkan_Click(object sender, EventArgs e)
        {
            clearInput();
        }
        private void clearInput()
        {
            lblNomorAgenda.Text = "";
            lblNomorAgenda.Focus();

            dtTanggalKirim.Value = DateTime.Now;
            txtLampiran.Text = "";
            txtTujuan.Text = "";
            txtPerihalSurat.Text = "";
            txtRingkasanIsi.Text = "";
            dropDownTingkatKeamanan.Text = "";
            drAsli = null;
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblNomorAgenda.Text.Replace("\0", "")))
            {
                MessageBox.Show(this, "\"Nomor Agenda\" tidak boleh kosong.", "Input Kosong", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                lblNomorAgenda.Focus();
                return;
            }

            if (!SuratQuery.IsSuratKeluar(lblNomorAgenda.Text.Replace("\0", "")))
            {
                MessageBox.Show(this, "Data surat tidak ditemukan.", "Input Kosong", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                lblNomorAgenda.Focus();
                return;
            }

            string values = "";

            if (MessageBox.Show(this, "Anda yakin akan melakukan perubahan pada data surat ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                == System.Windows.Forms.DialogResult.No) return;

            if (string.Format("{0:yyyy-MM-dd}", dtTanggalKirim.Value) != string.Format("{0:yyyy-MM-dd}", (DateTime)drAsli[3]))
            {
                SuratBusiness.EditSuratKeluar(this.nomor_agenda.Replace("\0", ""), "tanggal_kirim", string.Format("{0:yyyy-MM-dd}", (DateTime)drAsli[3]),
                    string.Format("{0:yyyy-MM-dd}", dtTanggalKirim.Value), T8UserLoginInfo.Username);

                if (values != "") values = values + ",";
                values = values + " tanggal_kirim = '" + string.Format("{0:yyyy-MM-dd}", dtTanggalKirim.Value) + "' ";

            }

            if (txtTujuan.Text != drAsli[4].ToString())
            {
                SuratBusiness.EditSuratKeluar
                    (this.nomor_agenda, "tujuan", GlobalFunction.SqlCharChecker(drAsli[4].ToString()), GlobalFunction.SqlCharChecker(txtTujuan.Text),
                    T8UserLoginInfo.Username);

                if (values != "") values = values + ",";
                values = values + " tujuan = '" + GlobalFunction.SqlCharChecker(txtTujuan.Text) + "' ";
            }

            if (txtPerihalSurat.Text != drAsli[5].ToString())
            {
                SuratBusiness.EditSuratKeluar
                    (this.nomor_agenda, "perihal", GlobalFunction.SqlCharChecker(drAsli[5].ToString()), GlobalFunction.SqlCharChecker(txtPerihalSurat.Text),
                    T8UserLoginInfo.Username);

                if (values != "") values = values + ",";
                values = values + " perihal = '" + GlobalFunction.SqlCharChecker(txtPerihalSurat.Text) + "' ";
            }

            if (dropDownTingkatKeamanan.Text != drAsli[6].ToString())
            {
                SuratBusiness.EditSuratKeluar
                    (this.nomor_agenda, "tingkat_keamanan", GlobalFunction.SqlCharChecker(drAsli[6].ToString()), GlobalFunction.SqlCharChecker(dropDownTingkatKeamanan.Text),
                    T8UserLoginInfo.Username);


                if (values != "") values = values + ",";
                values = values + " tk_keamanan = '" + GlobalFunction.SqlCharChecker(dropDownTingkatKeamanan.Text) + "' ";
            }

            if (txtRingkasanIsi.Text != drAsli[7].ToString())
            {
                SuratBusiness.EditSuratKeluar
                    (this.nomor_agenda, "ringkasan_isi", GlobalFunction.SqlCharChecker(drAsli[7].ToString()), GlobalFunction.SqlCharChecker(txtRingkasanIsi.Text),
                    T8UserLoginInfo.Username);


                if (values != "") values = values + ",";
                values = values + " ringkasan_isi = '" + GlobalFunction.SqlCharChecker(txtRingkasanIsi.Text) + "' ";
            }
            
            if (txtLampiran.Text != drAsli[8].ToString())
            {
                SuratBusiness.EditSuratKeluar
                    (this.nomor_agenda, "lampiran", drAsli[8].ToString(), txtLampiran.Text, T8UserLoginInfo.Username);


                if (values != "") values = values + ",";
                values = values + " lampiran = '" + GlobalFunction.SqlCharChecker(txtLampiran.Text) + "' ";
            }

            if (values == "") return;
            SuratBusiness.UpdateKeluar(this.nomor_agenda, values);

            this.frmMain.UpdateSuratKeluar(this, this.nomor_agenda.Replace("\0", ""));
            MessageBox.Show(this, "Data surat sudah di ubah.", "Update Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            clearInput();//(); // this.Close();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool IsKosong()
        {
            if (drAsli == null) return false;
            return (string.Format("{0:yyyy-MM-dd}", dtTanggalKirim.Value) != string.Format("{0:yyyy-MM-dd}", (DateTime)drAsli[3]))
                || (txtTujuan.Text != drAsli[4].ToString()) || (txtPerihalSurat.Text != drAsli[5].ToString()) || (dropDownTingkatKeamanan.Text != drAsli[6].ToString())
                || (txtRingkasanIsi.Text != drAsli[7].ToString()) || (txtLampiran.Text != drAsli[8].ToString());
        }

        private void FrmEditSuratKeluar_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsKosong())
            {
                if (MessageBox.Show(this, "Anda yakin akan membatalkan edit data surat?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == 
                    System.Windows.Forms.DialogResult.No)
                    e.Cancel = true;
            }
        }
    }
}
