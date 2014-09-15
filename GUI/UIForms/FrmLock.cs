using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace GUI.UIForms
{
    public partial class FrmLock : Telerik.WinControls.UI.RadForm
    {
        FrmMain frmMain;
        public FrmLock(FrmMain _frmMain)
        {
            InitializeComponent();
            frmMain = _frmMain;
        }

        private void FrmLock_Load(object sender, EventArgs e)
        {
            char ch = (char)0x25CF;
            txtPassword.PasswordChar = ch;
        }
    }
}
