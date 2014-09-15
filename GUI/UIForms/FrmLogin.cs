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

namespace GUI.UIForms
{
    public partial class FrmLogin : Telerik.WinControls.UI.RadForm
    {
        FrmMain frmMain;
        public FrmLogin(FrmMain _frmMain)
        {
            InitializeComponent();
            frmMain = _frmMain;
            this.ShowInTaskbar = false;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            InitForm();
            char ch = (char) 0x25CF;
            txtPassword.PasswordChar = ch;
        }

        private void InitForm()
        {
            clearInput();
        }


        private void clearInput()
        {
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtUsername.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UserLogin();
        }

        private void UserLogin()
        {
            if (!IsValidInput()) return;
            T8UserLoginInfo.UserLoginInit();
            string hakAkses = UserBusiness.Login(txtUsername.Text, T8GlobalFunc.MD5Encrypt(txtPassword.Text), T8UserLoginInfo.IdLogin);

            if (hakAkses != "")
            {
                T8UserLoginInfo.SetUserLogin(txtUsername.Text, T8GlobalFunc.MD5Encrypt(txtPassword.Text), hakAkses, true);
                AppInit.isLogin = true;
                this.Close();
            }
            else
            {
                MessageBox.Show(this, "Anda tidak memiliki hak akses untuk menggunakan aplikasi ini.", "User Tidak Ditemukan", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtUsername.Focus();
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

            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                MessageBox.Show(this, "Username tidak boleh kosong.", "Null Input", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtUsername.Focus();
                txtUsername.SelectAll();
                return false;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show(this, "Password tidak boleh kosong", "Null Input", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtPassword.Focus();
                txtPassword.SelectAll();
                return false;
            }

            if (txtUsername.Text.Length < 4)
            {
                MessageBox.Show(this, "Panjang karakter username paling sedikit 4 karakter.", "Input Salah", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtUsername.Focus();
                txtUsername.SelectAll();
                return false;
            }

            if (txtPassword.Text.Length < 4)
            {
                MessageBox.Show(this, "Panjang karakter password paling sedikit 4 karakter.", "Input Salah", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtPassword.Focus();
                txtPassword.SelectAll();
                return false;
            }

            return true;
        }

        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!T8UserLoginInfo.IsLogin)
            {
                if (MessageBox.Show(this, "Apakah Anda yakin akan menutup aplikasi?", "Konfirmasi", MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No)
                {
                    e.Cancel = true;
                }
                frmMain.exitType = FrmMain.ExitType.ExitFromLogin;// = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            txtUsername.SelectAll();
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            txtPassword.SelectAll();
        }      
    }
}
