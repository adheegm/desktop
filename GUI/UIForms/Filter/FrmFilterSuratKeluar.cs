using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using T8CoreEnginee;
using Telerik.WinControls;

namespace GUI.UIForms.Filter
{
    public partial class FrmFilterSuratKeluar : Telerik.WinControls.UI.RadForm
    {
        FrmLoading frmLoading;
        FrmMain frmMain;
        private delegate void frmLoadingDelegate(bool _val);
        private delegate void txtAsalSuratDelegate(bool _val, string _str);
        private delegate void txtPosisiSuratSuratDelegate(bool _val, string _str);
        public FrmFilterSuratKeluar(FrmMain _frmMain)
        {
            InitializeComponent();
            this.frmMain = _frmMain;
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            this.frmMain.filterSK = GenerateFilter();
            this.Close();
        }

        private void DropDownKategori()
        {
            DataTable dt;
            if (T8UserLoginInfo.HakAkses.ToLower().Contains(("Administrator").ToLower()))
            {
                dt = TemplateQuery.GetTemplateAktif("kategori_surat");
            }
            else
                dt = TemplateQuery.GetTemplateAktifKategori(T8UserLoginInfo.Username, "kategori_surat");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dropDownKategori.Items.Add(dt.Rows[i][0].ToString());
            }
        }


        System.Data.DataTable dtTKKeamanan;
        private void DropDownTingkatKeamananItems()
        {
            if (T8UserLoginInfo.HakAkses.ToLower().Contains(("Administrator").ToLower()))
            {
                dtTKKeamanan = TemplateQuery.GetTemplateAktif("tingkat_keamanan");
            }
            else
                dtTKKeamanan = TemplateQuery.GetTemplateAktifTKKeamanan(T8UserLoginInfo.Username, "tingkat_keamanan");
            for (int i = 0; i < dtTKKeamanan.Rows.Count; i++)
            {
                dropDownTingkatKeamanan.Items.Add(dtTKKeamanan.Rows[i][0].ToString());
            }
        }

        private void FrmFilterSuratKeluar_Load(object sender, EventArgs e)
        {
            InitControl();
            Thread t = new Thread(Init);
            t.IsBackground = true;
            t.Start();

            frmLoading = new FrmLoading();
            frmLoading.ShowDialog();
        }
        private string GenerateFilter()
        {
            string filter = this.frmMain.filter;

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

            if (chkTanggalInput.Checked)
            {
                if (filter == "")
                {
                    filter = " where ";
                }
                else
                {
                    filter = filter + " and ";
                }
                filter = filter + " Date(`datetime_input`) between '" + string.Format("{0:yyyy-MM-dd}", dtTglLoginTerakhir1.Value) + "' and '"
                    + string.Format("{0:yyyy-MM-dd}", dtTglLoginTerakhir2.Value) + "' ";
            }

            if (chkJamInput.Checked)
            {
                if (filter == "")
                {
                    filter = " where ";
                }
                else
                {
                    filter = filter + " and ";
                }
                filter = filter + " Time(`datetime_input`) between '" + string.Format("{0:HH:mm:ss}", dtJamLoginTerakhir1.Value) + "' and '"
                    + string.Format("{0:HH:mm:ss}", dtJamLoginTerakhir2.Value) + "' ";
            }

            if (chkKategori.Checked)
            {
                if (filter == "")
                {
                    filter = " where ";
                }
                else
                {
                    filter = filter + " and ";
                }
                filter = filter + " `kategori` = '" + dropDownKategori.Text + "' ";//";// in (SELECT `nomor_agenda` from surat_masuk where substring_index(substring_index(nomor_agenda, '/', 3), '/', -1)='" +
                    
            }

            if (chkTglTerima.Checked)
            {
                if (filter == "")
                {
                    filter = " where ";
                }
                else
                {
                    filter = filter + " and ";
                }
                filter = filter + " `tanggal_kirim` between '" + string.Format("{0:yyyy-MM-dd}", dtTglTerima1.Value) + "' and '"
                    + string.Format("{0:yyyy-MM-dd}", dtTglTerima2.Value) + "' ";
            }

            if (chkAsalSurat.Checked)
            {
                if (filter == "")
                {
                    filter = " where ";
                }
                else
                {
                    filter = filter + " and ";
                }
                filter = filter + " `tujuan` like '%" + GlobalFunction.SqlCharChecker(txtPenerima.Text) + "%' ";
            }

            if (chkPerihal.Checked)
            {
                if (filter == "")
                {
                    filter = " where ";
                }
                else
                {
                    filter = filter + " and ";
                }
                filter = filter + " `perihal` like '%" + GlobalFunction.SqlCharChecker(txtPerihalSurat.Text) + "%' ";
            }

            if (chkTkKeamanan.Checked)
            {
                if (filter == "")
                {
                    filter = " where ";
                }
                else
                {
                    filter = filter + " and ";
                }
                filter = filter + " `tk_keamanan` like '%" + GlobalFunction.SqlCharChecker(dropDownTingkatKeamanan.Text) + "%' ";
            }

            if (chkRingkasanIsi.Checked)
            {
                if (filter == "")
                {
                    filter = " where ";
                }
                else
                {
                    filter = filter + " and ";
                }

                string[] arrRingkasanIsi = txtRingkasanIsi.Text.Split(' ');

                filter = filter + " (";
                for (int i = 0; i < arrRingkasanIsi.Length; i++)
                {
                    if (arrRingkasanIsi[i] != "")
                    {
                        filter = filter + "`ringkasan_isi` like '%" + GlobalFunction.SqlCharChecker(arrRingkasanIsi[i]) + "%'";
                        if (i != arrRingkasanIsi.Length - 1)
                        {
                            filter = filter + " or ";
                        }
                    }
                }
                filter = filter + ") ";
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

        private void Init(object obj)
        {
            DropDownTingkatKeamananItems();
            DropDownKategori();
            TxtAsalSuratAutoComplete();

            if (frmLoading.InvokeRequired)
            {
                this.frmLoading.Invoke(new frmLoadingDelegate(this.closeFrmLoading), true);
            }
            else
            {
                closeFrmLoading(true);
            }
        }

        private void closeFrmLoading(bool p)
        {
            frmLoading.Close();
        }

        private void TxtAsalSuratAutoComplete()
        {
            DataTable dt = TemplateQuery.GetTemplateAktif("asal_surat");
            if (txtPenerima.InvokeRequired)
            {
                this.txtPenerima.Invoke(new txtAsalSuratDelegate(this.txtAsalDelegate), true, "");
            }
            else
            {
                txtPenerima.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtPenerima.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (txtPenerima.InvokeRequired)
                {
                    this.txtPenerima.Invoke(new txtAsalSuratDelegate(this.txtAsalDelegate), false, dt.Rows[i][0].ToString());
                }
                else
                {
                    txtPenerima.AutoCompleteCustomSource.Add(dt.Rows[i][0].ToString());
                }

                Thread.Sleep(10);
            }
        }

        private void txtAsalDelegate(bool _val, string _item)
        {
            if (_val)
            {
                txtPenerima.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtPenerima.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            else
            {
                txtPenerima.AutoCompleteCustomSource.Add(_item);
            }
        }

        private void InitControl()
        {
            dtJamLoginTerakhir1.Value = DateTime.Now;
            dtJamLoginTerakhir2.Value = DateTime.Now;
            dtTglLoginTerakhir1.Value = DateTime.Now;
            dtTglLoginTerakhir2.Value = DateTime.Now;
            dtTglTerima1.Value = DateTime.Now;
            dtTglTerima2.Value = DateTime.Now;
        }

        private void chkNomorAgenda_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            txtNomorAgenda.Enabled = chkNomorAgenda.Checked;
        }

        private void chkTanggalInput_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            dtTglLoginTerakhir1.Enabled = chkTanggalInput.Checked;
            dtTglLoginTerakhir2.Enabled = chkTanggalInput.Checked;
        }

        private void chkJamInput_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            dtJamLoginTerakhir1.Enabled = chkJamInput.Checked;
            dtJamLoginTerakhir2.Enabled = chkJamInput.Checked;
        }

        private void chkKategori_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            dropDownKategori.Enabled = chkKategori.Checked;
        }

        private void chkTglTerima_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            dtTglTerima1.Enabled = chkTglTerima.Checked;
            dtTglTerima2.Enabled = chkTglTerima.Checked;
        }

        private void chkAsalSurat_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            txtPenerima.Enabled = chkAsalSurat.Checked;
        }

        private void chkPerihal_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            txtPerihalSurat.Enabled = chkPerihal.Checked;
        }

        private void chkTkKeamanan_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            dropDownTingkatKeamanan.Enabled = chkTkKeamanan.Checked;
        }

        private void chkRingkasanIsi_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            txtRingkasanIsi.Enabled = chkRingkasanIsi.Checked;
        }

        private void chkUserInput_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            txtUserInput.Enabled = chkUserInput.Checked;
        }
        
    }
}
