using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Data;
using Business;
using System.Windows.Forms;
using Telerik.WinControls;
using T8CoreEnginee;

namespace GUI.UIForms
{
    public partial class FrmEditSuratMasuk : Telerik.WinControls.UI.RadForm
    {
        string nomor_agenda;
        FrmMain frmMain;

        DataRow drAsli;
        public FrmEditSuratMasuk(FrmMain _frmMain, string _nomor_agenda)
        {
            InitializeComponent();
            this.nomor_agenda = _nomor_agenda;
            this.frmMain = _frmMain;
        }

        private void FrmEditSuratMasuk_Load(object sender, EventArgs e)
        {
            lblNomorAgenda.AutoCompleteDataSource = Data.SuratQuery.GetNomorAgenda("",0,0);
            lblNomorAgenda.AutoCompleteDisplayMember = "nomor_agenda";
            TxtAsalSuratAutoComplete();
            DropDownTingkatKeamananItems();
            BindingAgenda();
        }

        private void TxtAsalSuratAutoComplete()
        {
            DataTable dt = TemplateQuery.GetTemplateAktif("asal_surat");
            txtAsalSurat.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtAsalSurat.AutoCompleteSource = AutoCompleteSource.CustomSource;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                txtAsalSurat.AutoCompleteCustomSource.Add(dt.Rows[i][0].ToString());
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

        private void btnBersihkan_Click(object sender, EventArgs e)
        {
            clearInput();
        }

        private void BindingAgenda()
        {
            lblNomorAgenda.Text = this.nomor_agenda;

            drAsli = SuratQuery.GetSingleDataSurat(this.nomor_agenda);

            lblTanggalMasuk.Text = string.Format("{0:dd MMM yyyy}", drAsli[2]);

            txtNomorSurat.Text = drAsli[3].ToString();
            dtTanggalSurat.Value = (DateTime)drAsli[5];
            txtAsalSurat.Text = drAsli[6].ToString();
            txtPerihalSurat.Text = drAsli[7].ToString();
            dropDownTingkatKeamanan.Text = drAsli[8].ToString();
            txtRingkasanIsi.Text = drAsli[9].ToString();
            txtLampiran.Text = drAsli[10].ToString();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblNomorAgenda.Text.Replace("\0","")))
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

            string values = "";

            if (MessageBox.Show(this, "Anda yakin akan melakukan perubahan pada data surat ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) 
                == System.Windows.Forms.DialogResult.No) return;

            if (txtNomorSurat.Text != drAsli[3].ToString())
            {
                SuratBusiness.EditSurat(this.nomor_agenda.Replace("\0", ""), "nomor_surat", GlobalFunction.SqlCharChecker(drAsli[3].ToString()),
                    GlobalFunction.SqlCharChecker(txtNomorSurat.Text.Replace("\0", "")), T8UserLoginInfo.Username);
                values = values + " nomor_surat = '" + GlobalFunction.SqlCharChecker(txtNomorSurat.Text) + "' ";
            }
            if(string.Format("{0:yyyy-MM-dd}",dtTanggalSurat.Value) != string.Format("{0:yyyy-MM-dd}",(DateTime)drAsli[5]))
            {
                SuratBusiness.EditSurat(this.nomor_agenda.Replace("\0", ""), "tanggal_surat", string.Format("{0:yyyy-MM-dd}", (DateTime)drAsli[5]),
                    string.Format("{0:yyyy-MM-dd}", dtTanggalSurat.Value), T8UserLoginInfo.Username);

                if (values != "") values = values + ",";
                values = values + " tanggal_surat = '" + string.Format("{0:yyyy-MM-dd}", dtTanggalSurat.Value) + "' ";
            }
            
            if(txtAsalSurat.Text != drAsli[6].ToString())
            {
                SuratBusiness.EditSurat
                    (this.nomor_agenda, "asal_surat", GlobalFunction.SqlCharChecker(drAsli[6].ToString()), GlobalFunction.SqlCharChecker(txtAsalSurat.Text), 
                    T8UserLoginInfo.Username);


                if (values != "") values = values + ",";
                values = values + " asal_surat = '" + GlobalFunction.SqlCharChecker(txtAsalSurat.Text) + "' ";
            }

            if(txtPerihalSurat.Text != drAsli[7].ToString())
            {
                SuratBusiness.EditSurat
                    (this.nomor_agenda, "perihal", GlobalFunction.SqlCharChecker(drAsli[7].ToString()), GlobalFunction.SqlCharChecker(txtPerihalSurat.Text), 
                    T8UserLoginInfo.Username);


                if (values != "") values = values + ",";
                values = values + " perihal = '" + GlobalFunction.SqlCharChecker(txtPerihalSurat.Text) + "' ";
            }

            if(dropDownTingkatKeamanan.Text != drAsli[8].ToString())
            {
                SuratBusiness.EditSurat
                    (this.nomor_agenda, "tingkat_keamanan", drAsli[8].ToString(), dropDownTingkatKeamanan.Text, T8UserLoginInfo.Username);


                if (values != "") values = values + ",";
                values = values + " tk_keamanan = '" + dropDownTingkatKeamanan.Text.Replace("'", "''") + "' ";
            }

            if (txtRingkasanIsi.Text != drAsli[9].ToString())
            {
                SuratBusiness.EditSurat
                    (this.nomor_agenda, "ringkasan_isi", GlobalFunction.SqlCharChecker(drAsli[9].ToString()), GlobalFunction.SqlCharChecker(txtRingkasanIsi.Text), 
                    T8UserLoginInfo.Username);


                if (values != "") values = values + ",";
                values = values + " ringkasan_isi = '" + GlobalFunction.SqlCharChecker(txtRingkasanIsi.Text) + "' ";
            }

            if(txtLampiran.Text != drAsli[10].ToString())
            {
                SuratBusiness.EditSurat
                    (this.nomor_agenda, "lampiran", GlobalFunction.SqlCharChecker(drAsli[10].ToString()), GlobalFunction.SqlCharChecker(txtLampiran.Text), 
                    T8UserLoginInfo.Username);


                if (values != "") values = values + ",";
                values = values + " lampiran = '" + GlobalFunction.SqlCharChecker(txtLampiran.Text) + "' ";
            }

            if (values == "") return;
            SuratBusiness.Update(this.nomor_agenda, values);

            this.frmMain.UpdateSurat(this, this.nomor_agenda.Replace("\0", ""));
            MessageBox.Show(this,"Data surat sudah di ubah.","Update Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            clearInput();
        }

        private void clearInput()
        {
            lblNomorAgenda.Text = "";
            lblNomorAgenda.Focus();

            lblTanggalMasuk.Text = "";

            txtNomorSurat.Text = "";
            dtTanggalSurat.Value = DateTime.Now; 
            txtAsalSurat.Text = "";
            txtPerihalSurat.Text = "";
            dropDownTingkatKeamanan.Text = "";
            txtRingkasanIsi.Text = "";
            txtLampiran.Text = "";
            drAsli = null;
        }

        private void lblNomorAgenda_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.nomor_agenda = GlobalFunction.SqlCharChecker(lblNomorAgenda.Text.Replace("\0", ""));
                BindingAgenda();
            }
            catch(Exception ex)
            {
                clearInputError();
            }
        }

        private void clearInputError()
        {
            lblTanggalMasuk.Text = "";
            txtNomorSurat.Text = "";
            dtTanggalSurat.Value = DateTime.Now; 
            txtAsalSurat.Text = "";
            txtPerihalSurat.Text = "";
            dropDownTingkatKeamanan.Text = "";
            txtRingkasanIsi.Text = "";
            txtLampiran.Text = "";
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool IsKosong()
        {
            if (drAsli == null) return false;
            return (txtNomorSurat.Text != drAsli[3].ToString()) ||
                (string.Format("{0:yyyy-MM-dd}", dtTanggalSurat.Value) != string.Format("{0:yyyy-MM-dd}", (DateTime)drAsli[5])) || (txtAsalSurat.Text != drAsli[6].ToString()) ||
                (txtPerihalSurat.Text != drAsli[7].ToString()) || (dropDownTingkatKeamanan.Text != drAsli[8].ToString()) || (txtRingkasanIsi.Text != drAsli[9].ToString()) ||
                (txtLampiran.Text != drAsli[10].ToString());
        }

        private void FrmEditSuratMasuk_FormClosing(object sender, FormClosingEventArgs e)
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
