using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using T8CoreEnginee;
using Business;
using Data;
using Telerik.WinControls.UI;

namespace GUI.UIForms
{
    public partial class FrmUbahHakAkses : Telerik.WinControls.UI.RadForm
    {
        public string hak_akses, username;
        public bool is_update;
        public StringBuilder hakAksesUser = new StringBuilder();
        public FrmUser frmUser;
        public FrmUbahHakAkses(FrmUser _frmUser, string _usr, string _hakAkses)
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            this.username = _usr;
            this.hak_akses = _hakAkses;
            this.frmUser = _frmUser;
        }

        private void rdoAdministrator_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            hakAksesUser.Clear();
            pnlAdministrator.Enabled = rdoAdministrator.IsChecked;
            rdoRoot.Focus();
        }

        private void rdoPegawai_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            UncheckedRdoPegawai(false);
            hakAksesUser.Clear();
            ClearRdoAdministrator();
            pnlPegawai.Enabled = rdoPegawai.IsChecked;
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

        private void ClearRdoAdministrator()
        {
            rdoRoot.IsChecked = false;
            rdoSuratMasuk.IsChecked = false;
            rdoUserMaintenance.IsChecked = false;
        }

        private void ClearInput()
        {
            ClearRdoAdmin();
            UncheckedRdoPegawai(false);
            ClearRdoAdministrator();
            radCheckBox1.Checked = false;
            radCheckBox2.Checked = false;
            ClearLVKategori();
            ClearLVTKKeamanan();
            lvKategori.Enabled = true;
            lvTkKeamanan.Enabled = true;
        }

        private void ClearRdoAdmin()
        {
            rdoAdministrator.IsChecked = false;
            rdoPegawai.IsChecked = false;
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

        private void FrmUbahHakAkses_Load(object sender, EventArgs e)
        {
            ClearRdoAdmin();
            GenerateLVKategori();
            GenerateLVTKKeamanan();
            BindingHakAksesUser();
            BindingListView();
        }

        DataTable dtKategoriUser, dtTkKeamananUser;
        private void BindingListView()
        {
            dtKategoriUser = UserQuery.GetUserkategori(this.username);

            for (int i = 0; i < dtKategoriUser.Rows.Count;i++)
            {
                for (int j = 0; j < lvKategori.Items.Count; j++)
                {
                    if (dtKategori.Rows[i][0].ToString() == lvKategori.Items[j].Value.ToString())
                        lvKategori.Items[j].CheckState = Telerik.WinControls.Enumerations.ToggleState.On;
                }
            }

            dtTkKeamananUser = UserQuery.GetUserTKKeamanan(this.username);
            for (int i = 0; i < dtTkKeamananUser.Rows.Count; i++)
            {
                for (int j = 0; j < lvTkKeamanan.Items.Count; j++)
                {
                    if (dtTkKeamananUser.Rows[i][0].ToString() == lvTkKeamanan.Items[j].Value.ToString())
                        lvTkKeamanan.Items[j].CheckState = Telerik.WinControls.Enumerations.ToggleState.On;
                }
            }
        }

        private void BindingHakAksesUser()
        {
            if(this.hak_akses.ToLower().Contains("Administrator".ToLower()))
            {
                rdoAdministrator.IsChecked = true;
                if(this.hak_akses.ToLower().Contains(rdoAdministrator.Text.ToLower()))
                {
                    rdoAdministrator.IsChecked = true;
                }
                if (this.hak_akses.ToLower().Contains(rdoPegawai.Text.ToLower()))
                {
                    rdoPegawai.IsChecked = true;
                }
                if (this.hak_akses.ToLower().Contains(rdoRoot.Text.ToLower()))
                {
                    rdoRoot.IsChecked = true;
                }
            }
            else
            {
                rdoPegawai.IsChecked = true;
                if (this.hak_akses.ToLower().Contains(chkCetakAgendaDisposisi.Text.ToLower()))
                {
                    chkCetakAgendaDisposisi.Checked = true;
                }

                if (this.hak_akses.ToLower().Contains(chkCetakAgndaPenyelesaian.Text.ToLower()))
                {
                    chkCetakAgndaPenyelesaian.Checked = true;
                }

                if (this.hak_akses.ToLower().Contains(chkCetakSuratKeluar.Text.ToLower()))
                {
                    chkCetakSuratKeluar.Checked = true;
                }

                if (this.hak_akses.ToLower().Contains(chkDeleteSuratKeluar.Text.ToLower()))
                {
                    chkDeleteSuratKeluar.Checked = true;
                }

                if (this.hak_akses.ToLower().Contains(chkDeleteSuratMasuk.Text.ToLower()))
                {
                    chkDeleteSuratMasuk.Checked = true;
                }

                if (this.hak_akses.ToLower().Contains(chkDisposisi.Text.ToLower()))
                {
                    chkDisposisi.Checked = true;
                }

                if (this.hak_akses.ToLower().Contains(chkEditSuratKeluar.Text.ToLower()))
                {
                    chkEditSuratKeluar.Checked = true;
                }

                if (this.hak_akses.ToLower().Contains(chkEditSuratMasuk.Text.ToLower()))
                {
                    chkEditSuratMasuk.Checked = true;
                }

                if (this.hak_akses.ToLower().Contains(chkEksportSuratKeluar.Text.ToLower()))
                {
                    chkEksportSuratKeluar.Checked = true;
                }

                if (this.hak_akses.ToLower().Contains(chkEksportSuratMasuk.Text.ToLower()))
                {
                    chkEksportSuratMasuk.Checked = true;
                }

                if (this.hak_akses.ToLower().Contains(chkInputSuratKeluar.Text.ToLower()))
                {
                    chkInputSuratKeluar.Checked = true;
                }

                if (this.hak_akses.ToLower().Contains(chkInputSuratMasuk.Text.ToLower()))
                {
                    chkInputSuratMasuk.Checked = true;
                }

                if (this.hak_akses.ToLower().Contains(chkMaintenanceUser.Text.ToLower()))
                {
                    chkMaintenanceUser.Checked = true;
                }

                if (this.hak_akses.ToLower().Contains(chkPenyelesaian.Text.ToLower()))
                {
                    chkPenyelesaian.Checked = true;
                }
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
        private bool IsKosong()
        {
            return !rdoAdministrator.IsChecked && !rdoPegawai.IsChecked && !(lvKategori.CheckedItems.Count != 0) && !(lvTkKeamanan.CheckedItems.Count != 0);
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Apakah Anda yakin akan melakukan perubahan data user?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                == System.Windows.Forms.DialogResult.Yes)
            {
                GenerateAkses();
                if (IsValidInput())
                {
                    try
                    {
                        UpdateUser();
                        ClearInput();
                        MessageBox.Show(this, "Data user sudah diupdate di database.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
        }

        private void UpdateUser()
        {
            UserBusiness.UbahHakAksesUser(this.username, this.hak_akses);

            if (lvKategori.CheckedItems.Count != 0)
            {
                InsertKategoriUser();
            }

            if (lvTkKeamanan.CheckedItems.Count != 0)
            {
                InsertTkKeamananUser();
            }

            this.frmUser.UpdateSingleData(this, this.username);
        }

        private void InsertTkKeamananUser()
        {
            UserQuery.DeleteUserTKKeamanan(GlobalFunction.SqlCharChecker(this.username));
            for (int i = 0; i < lvTkKeamanan.Items.Count; i++)
            {
                if (lvTkKeamanan.Items[i].CheckState == Telerik.WinControls.Enumerations.ToggleState.On)
                    UserBusiness.InsertUserTKKeamanan(GlobalFunction.SqlCharChecker(this.username), lvTkKeamanan.Items[i].Value.ToString());
            }
        }

        private void InsertKategoriUser()
        {
            UserQuery.DeleteUserKategori(GlobalFunction.SqlCharChecker(this.username));
            for (int i = 0; i < lvKategori.Items.Count; i++)
            {
                if (lvKategori.Items[i].CheckState == Telerik.WinControls.Enumerations.ToggleState.On)
                    UserBusiness.InsertUserKategori(GlobalFunction.SqlCharChecker(this.username), lvKategori.Items[i].Value.ToString());
            }
        }

        private bool IsValidInput()
        {
            if (string.IsNullOrEmpty(hakAksesUser.ToString()))
            {
                MessageBox.Show(this, "Hak akses tidak boleh kosong.", "Null Input", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (lvKategori.CheckedItems.Count == 0)
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

        private void GenerateAkses()
        {
            hakAksesUser.Clear();
            if (rdoAdministrator.IsChecked)
            {
                if (rdoRoot.IsChecked)
                    hakAksesUser.Append("Administrator: " + rdoRoot.Text);
                if (rdoUserMaintenance.IsChecked)
                    hakAksesUser.Append("Administrator: " + rdoUserMaintenance.Text);
                if (rdoSuratMasuk.IsChecked)
                    hakAksesUser.Append("Administrator: " + rdoSuratMasuk.Text);
            }
            else if (rdoPegawai.IsChecked)
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
    }
}
