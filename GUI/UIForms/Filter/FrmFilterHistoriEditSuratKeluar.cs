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
    public partial class FrmFilterHistoriEditSuratKeluar : Telerik.WinControls.UI.RadForm
    {
        History.FrmHistoryEditSuratKeluar frmEditSuratKeluar;
        public FrmFilterHistoriEditSuratKeluar(History.FrmHistoryEditSuratKeluar _frmEditSuratKeluar)
        {
            InitializeComponent();
            this.frmEditSuratKeluar = _frmEditSuratKeluar;
        }

        private void chkNomorAgenda_ToggleStateChanged_1(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            txtNomorAgenda.Enabled = chkNomorAgenda.Checked;
        }

        private void cbTglLogin_ToggleStateChanged_1(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            dtTglInput1.Enabled = chkTglInput.Checked;
            dtTglInput2.Enabled = chkTglInput.Checked;
        }

        private void cbJamLogin_ToggleStateChanged_1(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            dtJamInput1.Enabled = chkJamInput.Checked;
            dtJamInput2.Enabled = chkJamInput.Checked;
        }

        private void cbPcName_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            ddKolom.Enabled = chkKolom.Checked;
        }

        private void chkUserInput_ToggleStateChanged_1(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            txtUserInput.Enabled = chkUserInput.Checked;
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            string filt = GenerateFilter();
            if (filt == this.frmEditSuratKeluar.patent_filter) return;
            this.frmEditSuratKeluar.filter = filt;
            this.Close();
        }
        private string GenerateFilter()
        {
            string filter = this.frmEditSuratKeluar.patent_filter;

            if (chkNomorAgenda.Checked)
            {
                if (filter == "")
                {
                    filter = " where ";
                }
                else
                {
                    filter = filter + " and ";
                }
                filter = filter + " `nomor_surat` like '%" + GlobalFunction.SqlCharChecker(txtNomorAgenda.Text) + "%' ";
            }
            if (chkTglInput.Checked)
            {
                if (filter != "")
                    filter = filter + " and ";
                else
                    filter = " where ";
                filter = filter + " Date(`datetime_input`) between '" + string.Format("{0:yyyy-MM-dd}", dtTglInput1.Value) + "' and '"
                    + string.Format("{0:yyyy-MM-dd}", dtTglInput2.Value) + "' ";
            }

            if (chkJamInput.Checked)
            {
                if (filter != "")
                    filter = filter + " and ";
                else
                    filter = " where ";
                filter = filter + " Time(`datetime_input`) between '" + string.Format("{0:HH:mm:ss}", dtJamInput1.Value) + "' and '"
                    + string.Format("{0:HH:mm:ss}", dtJamInput2.Value) + "' ";
            }

            if (chkKolom.Checked)
            {
                if (filter != "")
                    filter = filter + " and ";
                else
                    filter = " where ";
                filter = filter + " `kolom`='" + GlobalFunction.SqlCharChecker(ddKolom.Text) + "' ";
            }

            if (chkUserInput.Checked)
            {
                if (filter == "")
                {
                    filter = " where ";
                }
                else
                {
                    filter = filter + " and ";
                }
                filter = filter + " `user` like '%" + GlobalFunction.SqlCharChecker(txtUserInput.Text) + "%' ";
            }

            return filter;
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmFilterHistoriEditSuratKeluar_Load(object sender, EventArgs e)
        {
            ClearInput();
        }

        private void ClearInput()
        {
            dtJamInput1.Value = DateTime.Now;
            dtJamInput2.Value = DateTime.Now;
            dtTglInput1.Value = DateTime.Now;
            dtTglInput2.Value = DateTime.Now;
            txtUserInput.Text = "";
            txtNomorAgenda.Text = "";
            ddKolom.SelectedIndex = -1;
        }
    }
}
