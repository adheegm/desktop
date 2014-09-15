using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using T8CoreEnginee;

namespace GUI.UIForms
{
    public partial class FrmInputPassword : Telerik.WinControls.UI.RadForm
    {
        public bool open;
        public FrmInputPassword()
        {
            InitializeComponent();
        }
        
        private void FrmInputPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (T8GlobalFunc.MD5Encrypt(txtPassword.Text) == T8UserLoginInfo.Password)
                {
                    this.open = true;
                    this.Close();
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void FrmInputPassword_Load(object sender, EventArgs e)
        {
            char ch = (char)0x25CF;
            txtPassword.PasswordChar = ch;
        }
    }
}
