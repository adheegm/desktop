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
using System.Text.RegularExpressions;
using Data;

namespace GUI.UIForms
{
    public partial class FrmTambahUser : Telerik.WinControls.UI.RadForm
    {
        FrmUser frmPengguna;
        public FrmTambahUser(FrmUser _frmPengguna)
        {
            InitializeComponent();
            frmPengguna = _frmPengguna;
            this.ShowInTaskbar = false;
        }

        private void ClearHakAksesPegawai(bool _value)
        {
            chkInputSuratMasuk.Enabled = _value;
            chkEditSuratMasuk.Enabled = _value;
            chkDeleteSuratMasuk.Enabled = _value;
            chkEksportSuratMasuk.Enabled = _value;
            chkInputSuratKeluar.Enabled = _value;
            chkEditSuratKeluar.Enabled = _value;
            chkDeleteSuratKeluar.Enabled = _value;
            chkEksportSuratKeluar.Enabled = _value;
            chkDisposisi.Enabled = _value;
            chkPenyelesaian.Enabled = _value;
            chkCetakSuratKeluar.Enabled = _value;
            chkMaintenanceUser.Enabled = _value;
            chkCetakAgendaDisposisi.Enabled = _value;
            chkCetakAgndaPenyelesaian.Enabled = _value;
        }

        private void UncheckedRdoPegawai(bool _value)
        {
            chkInputSuratMasuk.Checked = _value;
            chkEditSuratMasuk.Checked = _value;
            chkDeleteSuratMasuk.Checked = _value;
            chkEksportSuratMasuk.Checked = _value;
            chkInputSuratKeluar.Checked = _value;
            chkEditSuratKeluar.Checked = _value;
            chkDeleteSuratKeluar.Checked = _value;
            chkEksportSuratKeluar.Checked = _value;
            chkDisposisi.Checked = _value;
            chkPenyelesaian.Checked = _value;
            chkCetakSuratKeluar.Checked = _value;
            chkMaintenanceUser.Checked = _value;
            chkCetakAgendaDisposisi.Checked = _value;
            chkCetakAgndaPenyelesaian.Checked = _value;
        }

        private void FrmTambahUser_Load(object sender, EventArgs e)
        {
            ClearRdoAdmin();
            GenerateLVKategori();
            GenerateLVTKKeamanan();
        }

        DataTable TKKeamanan;
        private void GenerateLVTKKeamanan()
        {
            TKKeamanan = TemplateQuery.GetTemplateAktif("tingkat_keamanan");
            for (int i = 0; i < TKKeamanan.Rows.Count; i++)
            {
                lvTkKeamanan.Items.Add(0, TKKeamanan.Rows[i][0].ToString());
            }
            lvTkKeamanan.SelectedIndex = 0;
        }


        DataTable dtKategori;
        private void GenerateLVKategori()
        {
            dtKategori = TemplateQuery.GetTemplateAktif("kategori_surat");
            for (int i = 0; i < dtKategori.Rows.Count; i++)
            {
                lvKategori.Items.Add(0, dtKategori.Rows[i][0].ToString());
            }
            lvKategori.SelectedIndex = 0;
        }

        private void ClearRdoAdmin()
        {
            rdoAdministrator.IsChecked = false;
            rdoPegawai.IsChecked = false;
        }

        private void rdoPegawai_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            //ClearHakAksesPegawai(rdoPegawai.IsChecked == true);
            UncheckedRdoPegawai(false);
            hakAksesUser.Clear();
            ClearRdoAdministrator();
            pnlPegawai.Enabled = rdoPegawai.IsChecked;
        }

        private void ClearRdoAdministrator()
        {
            rdoRoot.IsChecked = false;
            rdoSuratMasuk.IsChecked = false;
            rdoUserMaintenance.IsChecked = false;
        }

        private void ClearInput()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            ClearRdoAdmin();
            ClearRdoStatus();
            UncheckedRdoPegawai(false);
            txtUsername.Focus();
            ClearRdoAdministrator();
            radCheckBox1.Checked = false;
            radCheckBox2.Checked = false;
            ClearLVKategori();
            ClearLVTKKeamanan();
            lvKategori.Enabled = true;
            lvTkKeamanan.Enabled = true;
        }

        private void ClearLVTKKeamanan()
        {
            for (int i = 0; i < lvTkKeamanan.Items.Count; i++)
            {
                if (lvTkKeamanan.Items[i].CheckState == Telerik.WinControls.Enumerations.ToggleState.On)
                    lvTkKeamanan.Items[i].CheckState = Telerik.WinControls.Enumerations.ToggleState.Off;
            }
            lvTkKeamanan.SelectedItem = lvTkKeamanan.Items[0];
        }

        private void ClearLVKategori()
        {
            for (int i = 0; i < lvKategori.Items.Count; i++)
            {
                if (lvKategori.Items[i].CheckState == Telerik.WinControls.Enumerations.ToggleState.On)
                    lvKategori.Items[i].CheckState = Telerik.WinControls.Enumerations.ToggleState.Off;
            }
            lvKategori.SelectedItem = lvKategori.Items[0];
        }

        private void ClearRdoStatus()
        {
            rdoAktif.IsChecked = false;
            rdoNonAktif.IsChecked = false;
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Apakah Anda yakin akan menginputkan data user?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) 
                == System.Windows.Forms.DialogResult.Yes)
            {
                GenerateAkses();
                if (IsValidInput())
                {
                    CheckUsername();
                    try
                    {
                        InsertUser();
                        ClearInput();
                        MessageBox.Show(this, "Data user sudah disimpan di database.", "Input sukses", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    catch (Exception f)
                    {
                        if (f.Message.Contains("ERROR [23000]"))
                            MessageBox.Show(this, "Username sudah ada, coba dengan username lain.", "Duplicate Entri", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        T8Application.DBConnection.Close();
                        return;
                    }
                }
            }
        }
        


        private bool IsValidInput()
        {
            if (!T8GlobalFunc.isAlphaNumeric(txtUsername.Text))
            {
                MessageBox.Show(this, "Username hanya berlaku untuk abjad, angka, simbol underscore (_) dan simbol titik (.) saja.", "Null Input", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtUsername.Focus();
                txtUsername.SelectAll();
                return false;
            }

            if (!T8GlobalFunc.isAlphaNumeric(txtPassword.Text))
            {
                MessageBox.Show(this, "Password hanya berlaku untuk abjad dan angka saja.", "Null Input", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtPassword.Focus();
                txtPassword.SelectAll();
                return false;
            }

            if(string.IsNullOrEmpty(txtUsername.Text))
            {
                MessageBox.Show(this, "Username tidak boleh kosong.", "Null Input", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtUsername.Focus();
                txtUsername.SelectAll();
                return false;
            }

            if(string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show(this, "Password tidak boleh kosong", "Null Input", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtPassword.Focus();
                txtPassword.SelectAll();
                return false;
            }

            if(string.IsNullOrEmpty(hakAksesUser.ToString()))
            {
                MessageBox.Show(this, "Hak akses tidak boleh kosong.", "Null Input", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if(txtUsername.Text.Length < 4)
            {
                MessageBox.Show(this,"Panjang karakter username paling sedikit 4 karakter.", "Input Salah", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if(txtPassword.Text.Length < 4)
            {
                MessageBox.Show(this, "Panjang karakter password paling sedikit 4 karakter.", "Input Salah", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (!rdoAktif.IsChecked && !rdoNonAktif.IsChecked)
            {
                MessageBox.Show(this, "Status user belum dipilih.", "Input Salah", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if(lvKategori.CheckedItems.Count==0)
            {
                MessageBox.Show(this, "Kategori akses user harus dipilih minimal 1 item.", "Null Input", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (lvTkKeamanan.CheckedItems.Count == 0)
            {
                MessageBox.Show(this, "Tingkat keamanan akses user harus dipilih minimal 1 item.", "Null Input", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            return true;
        }

        public string status;
        private void InsertUser()
        {
            if (rdoAktif.IsChecked)
                status = rdoAktif.Text;
            else
                status = rdoNonAktif.Text;
            UserBusiness.Tambah(GlobalFunction.SqlCharChecker(txtUsername.Text), T8GlobalFunc.MD5Encrypt(txtPassword.Text), hakAksesUser.ToString(), 
                status, T8UserLoginInfo.Username);
            this.frmPengguna.InsertSingleData(this);
            if (lvKategori.CheckedItems.Count != 0)
            {
                InsertKategoriUser();
            }

            if (lvTkKeamanan.CheckedItems.Count != 0)
            {
                InsertTkKeamananUser();
            }
            //ClearInput();
        }

        private void InsertTkKeamananUser()
        {
            UserQuery.DeleteUserTKKeamanan(GlobalFunction.SqlCharChecker(txtUsername.Text));
            for(int i=0;i<lvTkKeamanan.Items.Count;i++)
            {
                if (lvTkKeamanan.Items[i].CheckState == Telerik.WinControls.Enumerations.ToggleState.On)
                    UserBusiness.InsertUserTKKeamanan(GlobalFunction.SqlCharChecker(txtUsername.Text), lvTkKeamanan.Items[i].Value.ToString());
            }
        }

        private void InsertKategoriUser()
        {
            UserQuery.DeleteUserKategori(GlobalFunction.SqlCharChecker(txtUsername.Text));
            for (int i = 0; i < lvKategori.Items.Count; i++)
            {
                if (lvKategori.Items[i].CheckState == Telerik.WinControls.Enumerations.ToggleState.On)
                    UserBusiness.InsertUserKategori(GlobalFunction.SqlCharChecker(txtUsername.Text), lvKategori.Items[i].Value.ToString());
            }
        }

        private void CheckUsername()
        {
            
        }

        public StringBuilder hakAksesUser = new StringBuilder();

        public  void GenerateAkses()
        {
            hakAksesUser.Clear();
            if(rdoAdministrator.IsChecked)
            {
                if (rdoRoot.IsChecked)
                    hakAksesUser.Append("Administrator: " + rdoRoot.Text);
                if (rdoUserMaintenance.IsChecked)
                    hakAksesUser.Append("Administrator: " + rdoUserMaintenance.Text);
                if (rdoSuratMasuk.IsChecked)
                    hakAksesUser.Append("Administrator: " + rdoSuratMasuk.Text);
            } 
            else if(rdoPegawai.IsChecked)
            {
                if (chkInputSuratMasuk.Checked)
                    hakAksesUser.Append("*" + chkInputSuratMasuk.Text + "*");
                if (chkEditSuratMasuk.Checked)
                    hakAksesUser.Append("*" + chkEditSuratMasuk.Text + "*");
                if (chkDeleteSuratMasuk.Checked)
                    hakAksesUser.Append("*" + chkDeleteSuratMasuk.Text + "*");
                if (chkEksportSuratMasuk.Checked)
                    hakAksesUser.Append("*" + chkEksportSuratMasuk.Text + "*");
                if (chkInputSuratKeluar.Checked)
                    hakAksesUser.Append("*" + chkInputSuratKeluar.Text + "*");
                if (chkEditSuratKeluar.Checked)
                    hakAksesUser.Append("*" + chkEditSuratKeluar.Text + "*");
                if (chkEksportSuratMasuk.Checked)
                    hakAksesUser.Append("*" + chkDeleteSuratKeluar.Text + "*");
                if (chkEksportSuratKeluar.Checked)
                    hakAksesUser.Append("*" + chkEksportSuratKeluar.Text + "*");
                if (chkDisposisi.Checked)
                    hakAksesUser.Append("*" + chkDisposisi.Text + "*");
                if (chkPenyelesaian.Checked)
                    hakAksesUser.Append("*" + chkPenyelesaian.Text + "*");
                if (chkCetakSuratKeluar.Checked)
                    hakAksesUser.Append("*" + chkCetakSuratKeluar.Text + "*");
                if (chkMaintenanceUser.Checked)
                    hakAksesUser.Append("*" + chkMaintenanceUser.Text + "*");
                if (chkCetakAgendaDisposisi.Checked)
                    hakAksesUser.Append("*" + chkCetakAgendaDisposisi.Text + "*");
                if (chkCetakAgndaPenyelesaian.Checked)
                    hakAksesUser.Append("*" + chkCetakAgndaPenyelesaian.Text + "*");
            }
        }

        private void btnBersihkan_Click(object sender, EventArgs e)
        {
            if (!IsKosong())
            {
                if (MessageBox.Show(this, "Apakah Anda yakin akan membersihkan inputan?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                    == System.Windows.Forms.DialogResult.Yes)
                    ClearInput();
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmTambahUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void FrmTambahUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!IsKosong())
            {
                if (MessageBox.Show(this, "Apakah Anda yakin akan membatalkan input data user?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != System.Windows.Forms.DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }

        private bool IsKosong()
        {
            return string.IsNullOrEmpty(txtUsername.Text) && string.IsNullOrEmpty(txtPassword.Text)
                && !rdoAdministrator.IsChecked && !rdoPegawai.IsChecked && !rdoAktif.IsChecked && !rdoNonAktif.IsChecked && !(lvKategori.CheckedItems.Count != 0) 
                && !(lvTkKeamanan.CheckedItems.Count != 0);
        }

        private void rdoAdministrator_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            hakAksesUser.Clear();
            pnlAdministrator.Enabled = rdoAdministrator.IsChecked;
            rdoRoot.Focus();
        }

        private void radCheckBox1_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            for (int i = 0; i < lvKategori.Items.Count; i++)
            {
                lvKategori.Items[i].CheckState = Telerik.WinControls.Enumerations.ToggleState.On;
            }
            lvKategori.Enabled = !radCheckBox1.Checked;
        }

        private void radCheckBox2_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            for (int i = 0; i < lvTkKeamanan.Items.Count; i++)
            {
                lvTkKeamanan.Items[i].CheckState = Telerik.WinControls.Enumerations.ToggleState.On;
            }
            lvTkKeamanan.Enabled = !radCheckBox2.Checked;
        }
    }
}
