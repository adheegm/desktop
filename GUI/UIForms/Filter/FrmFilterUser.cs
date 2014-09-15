using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace GUI.UIForms.Filter
{
    public partial class FrmFilterUser : Telerik.WinControls.UI.RadForm
    {
        FrmUser frmUser;
        public FrmFilterUser(FrmUser _frmUser)
        {
            InitializeComponent();
            this.frmUser = _frmUser;
        }

        private void FrmFilterUser_Load(object sender, EventArgs e)
        {
            this.frmUser.filter = "";
            dtTglLoginTerakhir1.Value = DateTime.Now;
            dtTglLoginTerakhir2.Value = DateTime.Now;
            dtJamLoginTerakhir1.Value = DateTime.Now;
            dtJamLoginTerakhir2.Value = DateTime.Now;
            dtTglLogoutTerakhir1.Value = DateTime.Now;
            dtTglLogoutTerakhir2.Value = DateTime.Now;
            dtJamLogoutTerakhir1.Value = DateTime.Now;
            dtJamLogoutTerakhir2.Value = DateTime.Now;
            dtTglInput1.Value = DateTime.Now;
            dtTglInput2.Value = DateTime.Now;
            dtJamInput1.Value = DateTime.Now;
            dtJamInput2.Value = DateTime.Now;
        }

        private void chkNomorAgenda_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            
        }

        private string GenerateFilter()
        {
            string filter = "";
            string filterPeg = "", filterStat = "", filterdate = "";

            if (rdoPegawai.IsChecked)
            {
                if (chkAdministratorRoot.Checked)
                {
                    if (filterPeg != "")
                        filterPeg = filterPeg + " or ";
                    filterPeg = filterPeg + " hak_akses like '%" + chkAdministratorRoot.Text + "%' ";
                }
                if (chkAdministratorSuratMasuk.Checked)
                {
                    if (filterPeg != "")
                        filterPeg = filterPeg + " or ";
                    filterPeg = filterPeg + " hak_akses like '%" + chkAdministratorSuratMasuk.Text + "%' ";
                }
                if (chkAdministratorMaintenanceUser.Checked)
                {
                    if (filterPeg != "")
                        filterPeg = filterPeg + " or ";
                    filterPeg = filterPeg + " hak_akses like '%" + chkAdministratorMaintenanceUser.Text + "%' ";
                }

                if (chkCetakAgendaDisposisi.Checked)
                {
                    if (filterPeg != "")
                        filterPeg = filterPeg + " or ";
                    filterPeg = filterPeg + " hak_akses like '%" + chkCetakAgendaDisposisi.Text + "%' ";
                }
                if (chkCetakAgndaPenyelesaian.Checked)
                {
                    if (filterPeg != "")
                        filterPeg = filterPeg + " or ";
                    filterPeg = filterPeg + " hak_akses like '%" + chkCetakAgndaPenyelesaian.Text + "%' ";
                }
                if (chkCetakSuratKeluar.Checked)
                {
                    if (filterPeg != "")
                        filterPeg = filterPeg + " or ";
                    filterPeg = filterPeg + " hak_akses like '%" + chkCetakSuratKeluar.Text + "%' ";
                }
                if (chkDeleteSuratKeluar.Checked)
                {
                    if (filterPeg != "")
                        filterPeg = filterPeg + " or ";
                    filterPeg = filterPeg + " hak_akses like '%" + chkDeleteSuratKeluar.Text + "%' ";
                }
                if (chkDeleteSuratMasuk.Checked)
                {
                    if (filterPeg != "")
                        filterPeg = filterPeg + " or ";
                    filterPeg = filterPeg + " hak_akses like '%" + chkDeleteSuratMasuk.Text + "%' ";
                }

                if (chkDisposisi.Checked)
                {
                    if (filterPeg != "")
                        filterPeg = filterPeg + " or ";
                    filterPeg = filterPeg + " hak_akses like '%" + chkDisposisi.Text + "%' ";
                }
                if (chkEditSuratKeluar.Checked)
                {
                    if (filterPeg != "")
                        filterPeg = filterPeg + " or ";
                    filterPeg = filterPeg + " hak_akses like '%" + chkEditSuratKeluar.Text + "%' ";
                }
                if (chkEditSuratMasuk.Checked)
                {
                    if (filterPeg != "")
                        filterPeg = filterPeg + " or ";
                    filterPeg = filterPeg + " hak_akses like '%" + chkEditSuratMasuk.Text + "%' ";
                }
                if (chkEksportSuratKeluar.Checked)
                {
                    if (filterPeg != "")
                        filterPeg = filterPeg + " or ";
                    filterPeg = filterPeg + " hak_akses like '%" + chkEksportSuratKeluar.Text + "%' ";
                }
                if (chkEksportSuratMasuk.Checked)
                {
                    if (filterPeg != "")
                        filterPeg = filterPeg + " or ";
                    filterPeg = filterPeg + " hak_akses like '%" + chkEksportSuratMasuk.Text + "%' ";
                }
                if (chkInputSuratKeluar.Checked)
                {
                    if (filterPeg != "")
                        filterPeg = filterPeg + " or ";
                    filterPeg = filterPeg + " hak_akses like '%" + chkInputSuratKeluar.Text + "%' ";
                }
                if (chkInputSuratMasuk.Checked)
                {
                    if (filterPeg != "")
                        filterPeg = filterPeg + " or ";
                    filterPeg = filterPeg + " hak_akses like '%" + chkInputSuratMasuk.Text + "%' ";
                }
                if (chkMaintenanceUser.Checked)
                {
                    if (filterPeg != "")
                        filterPeg = filterPeg + " or ";
                    filterPeg = filterPeg + " hak_akses like '%" + chkMaintenanceUser.Text + "%' ";
                }
                if (chkPenyelesaian.Checked)
                {
                    if (filterPeg != "")
                        filterPeg = filterPeg + " or ";
                    filterPeg = filterPeg + " hak_akses like '%" + chkPenyelesaian.Text + "%' ";
                }
            }

            if (filterPeg != "")
                filterPeg = "(" + filterPeg + ")";

            if (chkDateTime.Checked)
            {
                if (chkLoginTerakhir.Checked)
                {
                    if (filter != "")
                        filterdate = filterdate + " or ";
                    filterdate = filterdate + " Date(`datetime_login_terakhir`) between '" + string.Format("{0:yyyy-MM-dd}", dtTglLoginTerakhir1.Value) + "' and '"
                        + string.Format("{0:yyyy-MM-dd}", dtTglLoginTerakhir2.Value) + "' ";
                }

                if (chkJamLoginTerakhir.Checked)
                {
                    if (filter != "")
                        filterdate = filterdate + " or ";
                    filterdate = filterdate + " Time(`datetime_login_terakhir`) between '" + string.Format("{0:HH:mm:ss}", dtJamLoginTerakhir1.Value) + "' and '"
                        + string.Format("{0:HH:mm:ss}", dtJamLoginTerakhir2.Value) + "' ";
                }

                if (chkLogoutTerakhir.Checked)
                {
                    if (filter != "")
                        filterdate = filterdate + " or ";
                    filterdate = filterdate + " Date(`datetime_logout_terakhir`) between '" + string.Format("{0:yyyy-MM-dd}", dtJamLogoutTerakhir1.Value) + "' and '"
                        + string.Format("{0:yyyy-MM-dd}", dtJamLogoutTerakhir2.Value) + "' ";
                }

                if (chkJamLogoutTerakhir.Checked)
                {
                    if (filter != "")
                        filterdate = filterdate + " or ";
                    filterdate = filterdate + " Time(`datetime_logout_terakhir`) between '" + string.Format("{0:HH:mm:ss}", dtJamLogoutTerakhir1.Value) + "' and '"
                        + string.Format("{0:HH:mm:ss}", dtJamLogoutTerakhir2.Value) + "' ";
                }

                if (chkTanggalInput.Checked)
                {
                    if (filter != "")
                        filterdate = filterdate + " or ";
                    filterdate = filterdate + " Date(`datetime_input`) between '" + string.Format("{0:yyyy-MM-dd}", dtTglInput1.Value) + "' and '"
                         + string.Format("{0:yyyy-MM-dd}", dtTglInput2.Value) + "' ";
                }

                if (chkJamInput.Checked)
                {
                    if (filter != "")
                        filterdate = filterdate + " or ";
                    filterdate = filterdate + " Time(`datetime_input`) between '" + string.Format("{0:HH:mm:ss}", dtJamInput1.Value) + "' and '"
                         + string.Format("{0:HH:mm:ss}", dtJamInput2.Value) + "' ";
                }
            }

            if (filterdate != "")
                filterdate = "(" + filterdate + ")";

            if (chkStatus.Checked)
            {
                string status = "";

                if (rdoAktif.IsChecked)
                    status = rdoAktif.Text;
                else
                    status = rdoNonAktif.Text;

                filterStat = filterStat + " `status` = '" + status + "' ";
            }

            if (filterStat != "")
                filterStat = "(" + filterStat + ")";

            if (filterPeg != "")
            {
                if (filter == "")
                    filter = " where " + filterPeg;
                else
                    filter = filter + " and " + filterPeg;
            }

            if (filterdate != "")
            {
                if (filter == "")
                    filter = " where " + filterdate;
                else
                    filter = filter + " and " + filterdate;
            }

            if (filterStat != "")
            {
                if (filter == "")
                    filter = " where " + filterStat;
                else
                    filter = filter + " and " + filterStat;
            }

            return filter;
        }

        private void chkPegawai_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            
        }

        private void chkStatus_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            grpStatus.Enabled = chkStatus.Checked;
        }

        private void chkLoginTerakhir_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            dtTglLoginTerakhir1.Enabled = chkLoginTerakhir.Checked;
            dtTglLoginTerakhir2.Enabled = chkLoginTerakhir.Checked;
            dtTglLoginTerakhir1.Value = DateTime.Now;
            dtTglLoginTerakhir2.Value = DateTime.Now;
        }

        private void chkJamLoginTerakhir_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            dtJamLoginTerakhir1.Enabled = chkJamLoginTerakhir.Checked;
            dtJamLoginTerakhir2.Enabled = chkJamLoginTerakhir.Checked;
            dtJamLoginTerakhir1.Value = DateTime.Now;
            dtJamLoginTerakhir2.Value = DateTime.Now;
        }

        private void chkLogoutTerakhir_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            dtTglLogoutTerakhir1.Enabled = chkLogoutTerakhir.Checked;
            dtTglLogoutTerakhir2.Enabled = chkLogoutTerakhir.Checked;
            dtTglLogoutTerakhir1.Value = DateTime.Now;
            dtTglLogoutTerakhir2.Value = DateTime.Now;
        }

        private void chkJamLogoutTerakhir_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            dtJamLogoutTerakhir1.Enabled = chkJamLogoutTerakhir.Checked;
            dtJamLogoutTerakhir2.Enabled = chkJamLogoutTerakhir.Checked;
            dtJamLogoutTerakhir1.Value = DateTime.Now;
            dtJamLogoutTerakhir2.Value = DateTime.Now;
        }

        private void chkTanggalInput_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            dtTglInput1.Enabled = chkTanggalInput.Checked;
            dtTglInput2.Enabled = chkTanggalInput.Checked;
            dtTglInput1.Value = DateTime.Now;
            dtTglInput2.Value = DateTime.Now;
        }

        private void chkJamInput_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            dtJamInput1.Enabled = chkJamInput.Checked;
            dtJamInput2.Enabled = chkJamInput.Checked;
            dtJamInput1.Value = DateTime.Now;
            dtJamInput2.Value = DateTime.Now;
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            this.frmUser.filter = GenerateFilter();
            this.Close();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radCheckBox1_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            grpDate.Enabled = chkDateTime.Checked;
        }

        private void radRadioButton1_ThemeNameChanged(object source, ThemeNameChangedEventArgs args)
        {

        }

        private void radRadioButton1_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            //grpAdministrator.Enabled = rdoAdministrator.IsChecked;
        }

        private void radRadioButton2_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            grpPegawai.Enabled = rdoPegawai.IsChecked;
        }

        private void radCheckBox2_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            //grpAdministrator.Enabled = rdoAdministrator.Checked;
        }

        private void radCheckBox1_ToggleStateChanged_1(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            grpPegawai.Enabled = rdoPegawai.Checked;
        }
    }
}
