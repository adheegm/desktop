using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace GUI.UIForms.Surat
{
    public partial class FrmStartIndex : Telerik.WinControls.UI.RadForm
    {
        FrmSuratMasuk frm_surat_masuk;
        public FrmStartIndex(FrmSuratMasuk _frm_surat_masuk)
        {
            InitializeComponent();
            this.frm_surat_masuk = _frm_surat_masuk;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void radLabel1_Click(object sender, EventArgs e)
        {

        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.frm_surat_masuk.start_index = (int)nStartIndex.Value;
            this.Close();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            this.frm_surat_masuk.start_index = 0;
            this.Close();
        }

        private void FrmStartIndex_Load(object sender, EventArgs e)
        {

        }
    }
}
