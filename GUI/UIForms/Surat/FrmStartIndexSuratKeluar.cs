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
    public partial class FrmStartIndexSuratKeluar : Telerik.WinControls.UI.RadForm
    {
        FrmSuratKeluar frmSurat_keluar;
        public FrmStartIndexSuratKeluar(FrmSuratKeluar _frmSuratKeluar)
        {
            InitializeComponent();
            this.frmSurat_keluar = _frmSuratKeluar;
        }

        private void FrmStartIndexSuratKeluar_Load(object sender, EventArgs e)
        {

        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.frmSurat_keluar.start_index = (int)nStartIndex.Value;
            this.Close();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            this.frmSurat_keluar.start_index = 0;
            this.Close();
        }
    }
}
