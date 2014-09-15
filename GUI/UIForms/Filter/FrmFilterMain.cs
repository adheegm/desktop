using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Data;
using System.Threading;
using T8CoreEnginee;

namespace GUI.UIForms.Filter
{
    public partial class FrmFilterMain : Telerik.WinControls.UI.RadForm
    {
        FrmLoading frmLoading;
        FrmMain frmMain;
        private delegate void frmLoadingDelegate(bool _val);
        private delegate void txtAsalSuratDelegate(bool _val, string _str);
        private delegate void txtPosisiSuratSuratDelegate(bool _val, string _str);
        public FrmFilterMain(FrmMain _frmMain)
        {
            InitializeComponent();
            this.frmMain = _frmMain;
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            this.frmMain.filter = GenerateFilter();
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

        private string GenerateFilter()
        {
            string filter = this.frmMain.filter;
            
            if(chkNomorAgenda.Checked)
            {
                if(filter=="")
                {
                    filter = " where "; 
                }
                else
                {
                    filter = filter + " and ";
                }
                filter = filter + " `nomor_agenda` like '%" + GlobalFunction.SqlCharChecker(txtNomorAgenda.Text) + "%' ";
            }

            if(chkTanggalInput.Checked)
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

            if(chkJamInput.Checked)
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

            if(chkKategori.Checked)
            {
                if(filter == "")
                {
                    filter = " where "; 
                }
                else
                {
                    filter = filter + " and ";
                }
                filter = filter + " `kategori` ='" + dropDownKategori.Text + "' ";
            }

            if(chkTglTerima.Checked)
            {
                if(filter == "")
                {
                    filter = " where "; 
                }
                else
                {
                    filter = filter + " and ";
                }
                filter = filter + " `tanggal_terima` between '" + string.Format("{0:yyyy-MM-dd}", dtTglTerima1.Value) + "' and '"
                    + string.Format("{0:yyyy-MM-dd}", dtTglTerima2.Value) + "' ";
            }

            if (chkNomorSurat.Checked)
            {
                if (filter == "")
                {
                    filter = " where ";
                }
                else
                {
                    filter = filter + " and ";
                }
                filter = filter + " `nomor_agenda` like '%" + GlobalFunction.SqlCharChecker(txtNomorSurat.Text) + "%' ";
            }

            if (chkTglSurat.Checked)
            {
                if (filter == "")
                {
                    filter = " where ";
                }
                else
                {
                    filter = filter + " and ";
                }
                filter = filter + " `tanggal_terima` between '" + string.Format("{0:yyyy-MM-dd}", dtTglSurat1.Value) + "' and '"
                    + string.Format("{0:yyyy-MM-dd}", dtTglSurat2.Value) + "' ";
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
                filter = filter + " `asal_surat` like '%" + GlobalFunction.SqlCharChecker(txtAsalSurat.Text) + "%' ";
            }

            if(chkPerihal.Checked)
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

            if(chkTkKeamanan.Checked)
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
                        if (i != arrRingkasanIsi.Length-1)
                        {
                            filter = filter + " or ";
                        }
                    }
                }
                filter = filter + ") ";
            }

            if(chkPosisiSurat.Checked)
            {
                if (filter == "")
                {
                    filter = " where ";
                }
                else
                {
                    filter = filter + " and ";
                }

                filter = filter + " `nomor_agenda` in (select nomor_agenda  from disposisi where `tujuan_disposisi`='" + txtPosisiSurat.Text + 
                    "' and id in(select max(id) from disposisi group by nomor_agenda)) ";
            }

            if(chkPenyelesaian.Checked)
            {
                if (filter == "")
                {
                    filter = " where ";
                }
                else
                {
                    filter = filter + " and ";
                }

                filter = filter + " `nomor_agenda` in (select nomor_agenda  from penyelesaian where `penyelesaian` like '%" + txtPenyelesaian.Text +
                   "%' and id in(select max(id) from penyelesaian group by nomor_agenda)) ";
            }

            if(chkUserInput.Checked)
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

        private void FrmFilterMain_Load(object sender, EventArgs e)
        {
            InitControl();
            Thread t = new Thread(Init);
            t.IsBackground = true;
            t.Start();

            frmLoading = new FrmLoading();
            frmLoading.ShowDialog();
        }

        private void Init(object obj)
        {
            DropDownTingkatKeamananItems();
            DropDownKategori();
            TxtAsalSuratAutoComplete();
            TxtPosisiAutoComplete();

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
            if (txtAsalSurat.InvokeRequired)
            {
                this.txtAsalSurat.Invoke(new txtAsalSuratDelegate(this.txtAsalDelegate), true, "");
            }
            else
            {
                txtAsalSurat.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtAsalSurat.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (txtAsalSurat.InvokeRequired)
                {
                    this.txtAsalSurat.Invoke(new txtAsalSuratDelegate(this.txtAsalDelegate), false, dt.Rows[i][0].ToString());
                }
                else
                {
                    txtAsalSurat.AutoCompleteCustomSource.Add(dt.Rows[i][0].ToString());
                }
                
                Thread.Sleep(10);
            }
        }

        private void txtAsalDelegate(bool _val, string _item)
        {
            if (_val)
            {
                txtAsalSurat.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtAsalSurat.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            else
            {
                txtAsalSurat.AutoCompleteCustomSource.Add(_item);
            }
        }

        private void TxtPosisiAutoComplete()
        {
            DataTable dt = TemplateQuery.GetTemplateAktif("posisi_surat");
            if (txtPosisiSurat.InvokeRequired)
            {
                this.txtPosisiSurat.Invoke(new txtPosisiSuratSuratDelegate(this.txtPosisiDelegate), true, "");
            }
            else
            {
                txtPosisiSurat.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtPosisiSurat.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (txtPosisiSurat.InvokeRequired)
                {
                    this.txtPosisiSurat.Invoke(new txtAsalSuratDelegate(this.txtPosisiDelegate), false, dt.Rows[i][0].ToString());
                }
                else
                {
                    txtPosisiSurat.AutoCompleteCustomSource.Add(dt.Rows[i][0].ToString());
                }

                Thread.Sleep(10);
            }
        }

        private void txtPosisiDelegate(bool _val, string _str)
        {
            if (_val)
            {
                txtPosisiSurat.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtPosisiSurat.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            else
            {
                txtPosisiSurat.AutoCompleteCustomSource.Add(_str);
            }
        }

        private void InitControl()
        {
            dtJamLoginTerakhir1.Value = DateTime.Now;
            dtJamLoginTerakhir2.Value = DateTime.Now;
            dtTglLoginTerakhir1.Value = DateTime.Now;
            dtTglLoginTerakhir2.Value = DateTime.Now;
            dtTglSurat1.Value = DateTime.Now;
            dtTglSurat2.Value = DateTime.Now;
            dtTglTerima1.Value = DateTime.Now;
            dtTglTerima2.Value = DateTime.Now;
        }

        private void chkNomorAgenda_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            txtNomorAgenda.Enabled = chkNomorAgenda.Checked;
        }

        private void chkNomorSurat_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {

            txtNomorSurat.Enabled = chkNomorSurat.Checked;
        }

        private void chkAsalSurat_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {

            txtAsalSurat.Enabled = chkAsalSurat.Checked;
        }

        private void chkPosisiSurat_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {

            txtPosisiSurat.Enabled = chkPosisiSurat.Checked;
        }

        private void chkPerihal_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {

            txtPerihalSurat.Enabled = chkPerihal.Checked;
        }

        private void chkPenyelesaian_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {

            txtPenyelesaian.Enabled = chkPenyelesaian.Checked;
        }

        private void chkTglTerima_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            dtTglTerima1.Enabled = chkTglTerima.Checked;
            dtTglTerima2.Enabled = chkTglTerima.Checked;
        }

        private void chkTglSurat_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            dtTglSurat1.Enabled = chkTglSurat.Checked;
            dtTglSurat2.Enabled = chkTglSurat.Checked;
        }

        private void chkTkKeamanan_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            dropDownTingkatKeamanan.Enabled = chkTkKeamanan.Checked;
        }

        private void chkKategori_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            dropDownKategori.Enabled = chkKategori.Checked;
        }

        private void radCheckBox1_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            txtRingkasanIsi.Enabled = chkRingkasanIsi.Checked;
        }

        private void chkLoginTerakhir_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            dtTglLoginTerakhir1.Enabled = chkTanggalInput.Checked;
            dtTglLoginTerakhir2.Enabled = chkTanggalInput.Checked;
        }

        private void chkJamLoginTerakhir_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            dtJamLoginTerakhir1.Enabled = chkJamInput.Checked;
            dtJamLoginTerakhir2.Enabled = chkJamInput.Checked;
        }

        private void chkUserInput_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            txtUserInput.Enabled = chkUserInput.Enabled;
        }
    }
}
