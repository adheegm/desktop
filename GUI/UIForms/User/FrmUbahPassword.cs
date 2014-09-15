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

namespace GUI.UIForms
{
    public partial class FrmUbahPassword : Telerik.WinControls.UI.RadForm
    {
        public FrmUbahPassword()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
        }

        private void FrmUbahPassword_Load(object sender, EventArgs e)
        {
            this.Text = "Ubah password user: " + T8UserLoginInfo.Username;
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Anda yakin akan mengubah password?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) 
                == System.Windows.Forms.DialogResult.Yes)
            {
                if (T8GlobalFunc.MD5Encrypt(txtPasswordLama.Text) == T8UserLoginInfo.Password)
                {
                    try
                    {
                        UserBusiness.UbahPassword(T8UserLoginInfo.Username, T8GlobalFunc.MD5Encrypt(txtPasswordBaru.Text));
                        T8UserLoginInfo.Password = T8GlobalFunc.MD5Encrypt(txtPasswordBaru.Text);
                        MessageBox.Show(this, "Passwod anda sudah dirubah.", "Data disimpan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        T8Application.DBConnection.Close();
                    }
                }
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radButton3_Click(object sender, EventArgs e)
        {

        }
    }
}
