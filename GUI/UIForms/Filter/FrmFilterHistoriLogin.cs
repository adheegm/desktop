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
    public partial class FrmFilterHistoriLogin : Telerik.WinControls.UI.RadForm
    {
        string username;
        FrmHistoryLoginUser frmHistoryLoginUser;
        public FrmFilterHistoriLogin(FrmHistoryLoginUser _frmHistoryLoginUser, string _username)
        {
            InitializeComponent();
            this.frmHistoryLoginUser = _frmHistoryLoginUser;
            this.username = _username;
        }

        private void cbTglLogin_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            dtTglLogin1.Enabled = cbTglLogin.Checked;
            dtTglLogin2.Enabled = cbTglLogin.Checked;
            dtTglLogin1.Value = DateTime.Now;
            dtTglLogin2.Value = DateTime.Now;
        }

        private void cbJamLogin_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            dtJamLogin1.Enabled = cbJamLogin.Checked;
            dtJamLogin2.Enabled = cbJamLogin.Checked;
            dtJamLogin1.Value = DateTime.Now;
            dtJamLogin2.Value = DateTime.Now;
        }

        private void cbTglLogout_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            dtTglLogout1.Enabled = cbTglLogout.Checked;
            dtTglLogout2.Enabled = cbTglLogout.Checked;
            dtTglLogout1.Value = DateTime.Now;
            dtTglLogout2.Value = DateTime.Now;
        }

        private void cbJamLogout_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            dtJamLogout1.Enabled = cbJamLogout.Checked;
            dtJamLogout2.Enabled = cbJamLogout.Checked;
            dtJamLogout1.Value = DateTime.Now;
            dtJamLogout2.Value = DateTime.Now;
        }

        private void cbPcName_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            ddPcName.Enabled = cbPcName.Checked;
        }

        private void FrmFilterHistoriLogin_Load(object sender, EventArgs e)
        {
            this.frmHistoryLoginUser.filter = "where username='" + this.username + "' "; ;
            dtTglLogin1.Value = DateTime.Now;
            dtTglLogin2.Value = DateTime.Now;
            dtJamLogin1.Value = DateTime.Now;
            dtJamLogin2.Value = DateTime.Now;
            dtTglLogout1.Value = DateTime.Now;
            dtTglLogout2.Value = DateTime.Now;
            dtJamLogout1.Value = DateTime.Now;
            dtJamLogout2.Value = DateTime.Now;
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            if (GenerateFilter() == "") return;
            this.frmHistoryLoginUser.filter = this.frmHistoryLoginUser.filter + " and "  + GenerateFilter();
            this.Close();
        }

        private string GenerateFilter()
        {
            string filter = "";
            if (cbTglLogin.Checked)
            {
                if (filter != "")
                    filter = filter + " and ";
                filter = filter + " Date(`datetime_login`) between '" + string.Format("{0:yyyy-MM-dd}", dtTglLogin1.Value) + "' and '"
                    + string.Format("{0:yyyy-MM-dd}", dtTglLogin2.Value) + "' ";
            }

            if (cbJamLogin.Checked)
            {
                if (filter != "")
                    filter = filter + " and ";
                filter = filter + " Time(`datetime_login`) between '" + string.Format("{0:HH:mm:ss}", dtJamLogin1.Value) + "' and '"
                    + string.Format("{0:HH:mm:ss}", dtJamLogin2.Value) + "' ";
            }

            if (cbTglLogout.Checked)
            {
                if (filter != "")
                    filter = filter + " and ";
                filter = filter + " Date(`datetime_logout`) between '" + string.Format("{0:yyyy-MM-dd}", dtJamLogout1.Value) + "' and '"
                    + string.Format("{0:yyyy-MM-dd}", dtJamLogout2.Value) + "' ";
            }

            if (cbJamLogout.Checked)
            {
                if (filter != "")
                    filter = filter + " and ";
                filter = filter + " Time(`datetime_logout`) between '" + string.Format("{0:HH:mm:ss}", dtJamLogout1.Value) + "' and '"
                    + string.Format("{0:HH:mm:ss}", dtJamLogout2.Value) + "' ";
            }

            if (cbPcName.Checked)
            {
                if (filter != "")
                    filter = filter + " and ";
                filter = filter + " `pc`='" + GlobalFunction.SqlCharChecker(ddPcName.Text) + "' ";
            }

            return filter;
        }
    }
}
