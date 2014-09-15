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
    public partial class FrmPrintoutFile : Telerik.WinControls.UI.RadForm
    {
        public FrmPrintoutFile()
        {
            InitializeComponent();
        }

        private void radDropDownList1_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
               lblEg.Text = "eg: " + string.Format("{0:" + ddDateFormat.Text + "}",DateTime.Now);
        }

        private void FrmPrintoutFile_Load(object sender, EventArgs e)
        {
            InitSetting();
        }

        private void InitSetting()
        {
            txtDisposisiFile.Text = AppDefaultSetting.surat_masuk_disposisi_template_path;
            txtPenyelesaianFile.Text = AppDefaultSetting.surat_masuk_penyelesaian_template_path;
            txtSuratKeluar.Text = AppDefaultSetting.surat_keluar_template_path;
            ddDateFormat.Text = AppDefaultSetting.surat_masuk_date_format;

            string[] option_highlight = AppDefaultSetting.surat_masuk_option_highlight.Split(';');

            for (int i = 0; i < option_highlight.Length; i++)
            {
                if (option_highlight[i] == "bold")
                    chkBold.Checked = true;
                if (option_highlight[i] == "underline")
                    chkUnderline.Checked = true;
            }
        }

        private void radButton4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Anda yakin akan menyimpan data pengaturan?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
            SaveSetting();
        }

        private void SaveSetting()
        {
            try
            {
                string _disposisi_template_path = txtDisposisiFile.Text.Replace("\\", "\\\\");
                string _penyelesaian_template_file = txtPenyelesaianFile.Text.Replace("\\", "\\\\");
                string _surat_keluar_template_file = txtSuratKeluar.Text.Replace("\\", "\\\\");
                string _date_format = ddDateFormat.Text;
                string _option_highlight;

                _option_highlight = GetOptionHighlight();
                AppDefaultSetting.UpdateLayoutPrintoutSetting(_disposisi_template_path, _penyelesaian_template_file, _date_format, _option_highlight, _surat_keluar_template_file);

                MessageBox.Show(this, "Data sudah di simpan.", "Data disimpan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch(Exception ex)
            {        
                MessageBox.Show(this, "Terdapat kesalah, mohon periksa kembali.", "Duplicate Data", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                
            }
        }

        private string GetOptionHighlight()
        {
            string _strOpt = "";
            if (chkBold.Checked)
            {
                if (_strOpt == "")
                    _strOpt = _strOpt + "bold";
                else
                    _strOpt = _strOpt + ";bold";
            }
            if (chkUnderline.Checked)
            {
                if (_strOpt == "")
                    _strOpt = _strOpt + "underline";
                else
                    _strOpt = _strOpt + ";underline";
            }
            return _strOpt;
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Ms. Word Files (.docx)|*.docx";
            openFileDialog1.Title = "Template Disposisi";
            openFileDialog1.ShowDialog();
            if (!string.IsNullOrEmpty(openFileDialog1.FileName))
                txtDisposisiFile.Text = openFileDialog1.FileName;
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Ms. Word Files (.docx)|*.docx";
            openFileDialog1.Title = "Template Penyelesian";
            openFileDialog1.ShowDialog();
            if (!string.IsNullOrEmpty(openFileDialog1.FileName))
                txtPenyelesaianFile.Text = openFileDialog1.FileName;
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radButton5_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Ms. Word Files (.docx)|*.docx";
            openFileDialog1.Title = "Template Surat Keluar";
            openFileDialog1.ShowDialog();
            if (!string.IsNullOrEmpty(openFileDialog1.FileName))
                txtSuratKeluar.Text = openFileDialog1.FileName;
        }
    }
}
