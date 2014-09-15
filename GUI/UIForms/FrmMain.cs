
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Runtime.InteropServices;
using Telerik.WinControls.UI;
using Business;
using Data;
using System.Threading;
using T8CoreEnginee;
using System.Media;
using Telerik.WinControls.UI.Export;
using System.IO;

namespace GUI.UIForms
{
    public partial class FrmMain : Telerik.WinControls.UI.RadForm
    {        
        [DllImport("user32.dll")]

        public static extern Boolean GetLastInputInfo(ref tagLASTINPUTINFO plii);

        public string patent_filter="";

        private delegate void toolStripDelegate(bool _value);
        private delegate void addRowDelegate(GridViewDataRowInfo row);
        private delegate void addRowDelegateSK(GridViewDataRowInfo row);
        private delegate void menuDelegate(bool _value);
        private delegate void frmLoadingDelegate(bool _val);
        private delegate void frmThisDelegate(Int32 _val);
        
        private DataTable dt, dtSK;
        private FrmLoading frmLoading;

        private int page, count_per_page, pageSK, count_per_pageSK, count_no_limit, count_no_limitSK;
        public string filter, temp_filter, temp_filterSK, filterSK;

        tagLASTINPUTINFO LastInput = new tagLASTINPUTINFO();
        Int32 IdleTime;

        public enum ExitType
        {
            None,
            Exit,
            ExitFromLogin,
            Logout,
            Lock
        };

        public ExitType exitType;

        public struct tagLASTINPUTINFO
        {
            public uint cbSize;
            public Int32 dwTime;
        }

        public FrmMain()
        {
            InitializeComponent();
        }

        private void InputSurat()
        {
            FrmSuratMasuk frmSuratMasuk = new FrmSuratMasuk(this);
            frmSuratMasuk.ShowDialog();
        }

        private void radMenuItem4_Click(object sender, EventArgs e)
        {
            if(ValidasiWithNoCheckGrid("Administrator"))
                Pengaturan();
        }

        private void Pengaturan()
        {
            FrmPengaturan frmPengaturan = new FrmPengaturan();
            frmPengaturan.ShowDialog();
        }

        public void TApp()
        {
            while (true)
            {
                Thread.Sleep(1000);
                LastInput.cbSize = (uint)Marshal.SizeOf(LastInput);
                LastInput.dwTime = 0;

                if (GetLastInputInfo(ref LastInput))
                {
                    IdleTime = System.Environment.TickCount - LastInput.dwTime;
                }

                if (IdleTime > (GUI.GeneralSettings.IdleTimeValue * 60000))
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new frmThisDelegate(this.ThisText), IdleTime);
                    }
                    else
                    {
                        ThisText(IdleTime);
                    }
                    break;
                }
            }
        }

        private void ThisText(Int32 _val)
        {
            this.exitType = ExitType.Lock;
            this.Close();
        }
             
        private void FrmMain_Load(object sender, EventArgs e)
        {             
            GridHeaderGenerate();
            GridHeaderGenerateSuratKeluar();
            this.Hide(); 

            FrmLogin frmLogin = new FrmLogin(this);
            frmLogin.ShowDialog();
            if (AppInit.isLogin)
            {
                if (!T8UserLoginInfo.HakAkses.ToLower().Contains(("Administrator").ToLower()))
                {
                    DataTable dt = new DataTable();
                    dt = TemplateQuery.GetTemplateAktifKategori(T8UserLoginInfo.Username, "kategori_surat");
                    string tmp = "";
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (tmp == "")
                        {
                            tmp = tmp + "'" + dt.Rows[i][0].ToString() + "'";
                        }
                        else
                        {
                            tmp = tmp + ",'" + dt.Rows[i][0].ToString() + "'";
                        }
                    }

                    this.patent_filter = " where kategori in(" + tmp + ") ";

                    dt = new DataTable();
                    dt = TemplateQuery.GetTemplateAktifTKKeamanan(T8UserLoginInfo.Username, "tingkat_keamanan");
                    tmp = "";
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (tmp == "")
                        {
                            tmp = tmp + "'" + dt.Rows[i][0].ToString() + "'";
                        }
                        else
                        {
                            tmp = tmp + ",'" + dt.Rows[i][0].ToString() + "'";
                        }
                    }
                    this.patent_filter = this.patent_filter + " and tk_keamanan in (" + tmp + ") ";
                }
                else
                {
                    this.patent_filter = "";
                }
                this.filter = this.patent_filter;
                this.temp_filter = this.patent_filter;
                this.filterSK = this.patent_filter;
                this.temp_filterSK = this.patent_filter;

                InitUserMenu();
                appSettingInit();
                pagingInit();
                RunTimerLock();
                
                this.Show();
                this.WindowState = FormWindowState.Maximized;
            }
            else
                this.Close();
        }

        private void GridHeaderGenerateSuratKeluar()
        {
            GridColumnSuratKeluar();
            GridStyleSuratKeluar();
        }

        Thread app;
        public void RunTimerLock()
        {
            if (!GUI.GeneralSettings.IsIdleTime) return;
            app = new Thread(TApp);
            app.IsBackground = true;
            app.Start();
        }

        private void InitUserMenu()
        {
            LocalSettings.GetSetting();
            if(!T8UserLoginInfo.HakAkses.ToLower().Contains(("Administrator").ToLower()))
                chkAdministratorTable.Dispose();

            if(GeneralSettings.OtomatisSimpanHistoriLocal)
            {        
                chkAutosizeRow.Checked = LocalSettings.AutoSizeMain;
                chkAdministratorTable.Checked = LocalSettings.AdministratorTableMain;
                radCheckBox2.Checked = LocalSettings.AutoSizeMainSK;
                radCheckBox1.Checked = LocalSettings.AdministratorTableMainSK;
            }
        }

        private void appSettingInit()
        {
            this.exitType = ExitType.None;
            lblUsername.Text = T8UserLoginInfo.Username;
            lblTanggal.Text = string.Format("{0:dd MMM yyyy}", DateTime.Now);

            lblJam.Text = string.Format("{0: HH}", DateTime.Now);
            lblJam.AutoSize = false;
            lblJam.TextAlignment = ContentAlignment.MiddleLeft;
            lblJam.Size = new System.Drawing.Size(25, 23);
            //lblJam.BorderVisible = true;// = Color.Red;
            lblJam.Padding = new System.Windows.Forms.Padding(0);
            lblJam.Margin = new System.Windows.Forms.Padding(0);

            lblDetik.Text = ":";
            lblDetik.AutoSize = false;
            lblDetik.TextAlignment = ContentAlignment.MiddleCenter;
            lblDetik.Size = new System.Drawing.Size(13, 23);
            //lblDetik.BorderVisible = true;// = Color.Red;
            lblDetik.Padding = new System.Windows.Forms.Padding(0);
            lblDetik.Margin = new System.Windows.Forms.Padding(0);

            lblMenit.Text = string.Format("{0: mm}", DateTime.Now);
            lblMenit.AutoSize = false;
            lblMenit.TextAlignment = ContentAlignment.MiddleLeft;
            lblMenit.Size = new System.Drawing.Size(25, 23);
            //lblMenit.BorderVisible = true;// = Color.Red;
            lblMenit.Padding = new System.Windows.Forms.Padding(0);
            lblMenit.Margin = new System.Windows.Forms.Padding(0);

            timer1.Enabled = true;
            timer1.Interval = 500;
            timer1.Start();
        }

        private void pagingInit()
        {
            this.page = 0;
            this.count_no_limit = 0;
            dropDownLimit.SelectedIndex = 0;
        }

        private void GenerateDataSurat()
        {
            dt = SuratBusiness.SelectMasuk(this.filter, page * this.count_per_page, this.count_per_page);
           
            Thread.Sleep(50);

            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                if (this.gvSuratMasuk.InvokeRequired)
                {
                    this.gvSuratMasuk.Invoke(new addRowDelegate(this.addRow), GetDataRow(dt, i));
                }
                else
                {
                    this.gvSuratMasuk.Rows.Insert(0, GetDataRow(dt, i));
                }
                Thread.Sleep(50);
            }

            Thread.Sleep(50);

            if(frmLoading.InvokeRequired)
            {
                this.frmLoading.Invoke(new frmLoadingDelegate(this.closeFrmLoading), true);
            }
            else
            {
                closeFrmLoading(true);
            }
        }

        private string SetPaging()
        {
            string pageCount = "";

            if (this.count_per_page != 0)
            {
                if (this.count_no_limit % this.count_per_page > 0)
                    pageCount = ((this.count_no_limit / this.count_per_page) + 1).ToString();
                else
                    pageCount = (this.count_no_limit / this.count_per_page).ToString();
                return (this.page + 1).ToString() + "/" + pageCount;
            }
            else
                return "1/1";
        }

        private string SetPagingSK()
        {
            string pageCountSK = "";

            if (this.count_per_pageSK != 0)
            {
                if (this.count_no_limitSK % this.count_per_pageSK > 0)
                    pageCountSK = ((this.count_no_limitSK / this.count_per_pageSK) + 1).ToString();
                else
                    pageCountSK = (this.count_no_limitSK / this.count_per_pageSK).ToString();
                return (this.pageSK + 1).ToString() + "/" + pageCountSK;
            }
            else
                return "1/1";
        }

        private void closeFrmLoading(bool _val)
        {
            frmLoading.Close();
            if (this.dt.Rows.Count > 0)
                radLabel1.Text = SetPaging();
            else
                radLabel1.Text = "1/1";
            lblRecordCount.Text = this.count_no_limit.ToString() + " data";
        }

        private void closeFrmLoadingSK(bool _val)
        {
            frmLoading.Close();
            if (this.dt.Rows.Count > 0)
                radLabel6.Text = SetPagingSK();
            else
                radLabel6.Text = "1/1";

           lblRecordCount.Text = this.count_no_limitSK.ToString() + " data";
        }

        private void addRow(GridViewRowInfo row)
        {
            this.gvSuratMasuk.Rows.Insert(0, row);
        }
        private void addRowSK(GridViewRowInfo row)
        {
            this.gvSuratKeluar.Rows.Insert(0, row);
        }

        private GridViewDataRowInfo GetDataRow(DataTable dt, int i)
        {
            GridViewDataRowInfo dataRowInfo = new GridViewDataRowInfo(this.gvSuratMasuk.MasterView);
            dataRowInfo.Cells[0].Value = dt.Rows[i][0];
            dataRowInfo.Cells[1].Value = string.Format("{0:dd MMM yyyy}", dt.Rows[i][1]);
            dataRowInfo.Cells[2].Value = string.Format("{0:HH:mm:ss}", dt.Rows[i][1]);
            dataRowInfo.Cells[3].Value = string.Format("{0:dd MMM yyyy}", dt.Rows[i][2]);
            dataRowInfo.Cells[4].Value = dt.Rows[i][3];
            dataRowInfo.Cells[5].Value = dt.Rows[i][4];
            dataRowInfo.Cells[6].Value = string.Format("{0:dd MMM yyyy}", dt.Rows[i][5]);
            dataRowInfo.Cells[7].Value = dt.Rows[i][6];
            dataRowInfo.Cells[8].Value = dt.Rows[i][7];
            dataRowInfo.Cells[9].Value = dt.Rows[i][8];
            dataRowInfo.Cells[10].Value = dt.Rows[i][9];
            dataRowInfo.Cells[11].Value = dt.Rows[i][10];
            dataRowInfo.Cells[12].Value = dt.Rows[i][11];
            return dataRowInfo;
        }

        private GridViewDataRowInfo GetDataRowSk(DataTable dt, int i)
        {
            GridViewDataRowInfo dataRowInfo = new GridViewDataRowInfo(this.gvSuratKeluar.MasterView);
            dataRowInfo.Cells[0].Value = dtSK.Rows[i][0];
            dataRowInfo.Cells[1].Value = string.Format("{0:dd MMM yyyy}", dtSK.Rows[i][1]);
            dataRowInfo.Cells[2].Value = string.Format("{0:HH:mm:ss}", dtSK.Rows[i][1]);
            dataRowInfo.Cells[3].Value = dtSK.Rows[i][2];
            dataRowInfo.Cells[4].Value = string.Format("{0:dd MMM yyyy}", dtSK.Rows[i][3]);
            dataRowInfo.Cells[5].Value = dtSK.Rows[i][4];
            dataRowInfo.Cells[6].Value = dtSK.Rows[i][5];
            dataRowInfo.Cells[7].Value = dtSK.Rows[i][6];
            dataRowInfo.Cells[8].Value = dtSK.Rows[i][7];
            dataRowInfo.Cells[9].Value = dtSK.Rows[i][8];
            dataRowInfo.Cells[10].Value = dtSK.Rows[i][9];
            return dataRowInfo;
        }

        private void BindingDataGrid()
        {
            AdministratorViewer(chkAdministratorTable.Checked);
            gvSuratMasuk.Rows.Clear();
            Thread bindingDataSurat;
            bindingDataSurat = new Thread(GenerateDataSurat);
            bindingDataSurat.IsBackground = true;
            bindingDataSurat.Start();
            frmLoading = new FrmLoading();
            frmLoading.ShowDialog();
        }

        private void BindingDataGridSK()
        {
            AdministratorViewerSK(radCheckBox1.Checked);
            gvSuratKeluar.Rows.Clear();
            Thread bindingDataSurat;
            bindingDataSurat = new Thread(GenerateDataSuratKeluar);
            bindingDataSurat.IsBackground = true;
            bindingDataSurat.Start();
            frmLoading = new FrmLoading();
            frmLoading.ShowDialog();
        }

        private void radMenuItem5_Click(object sender, EventArgs e)
        {
            this.exitType = ExitType.Exit;
            this.Close();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (exitType == ExitType.Exit || exitType == ExitType.None)
            {
                if (MessageBox.Show(this, "Anda yakin akan menutup aplikasi?", "Konfirmasi", MessageBoxButtons.YesNo,  MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                    == System.Windows.Forms.DialogResult.No)
                {
                    e.Cancel = true;
                }
                UserBusiness.Logout(T8UserLoginInfo.IdLogin);
                UserBusiness.LastLogout(T8UserLoginInfo.Username);
            }

            else if (exitType == ExitType.Lock)
            {
                e.Cancel = true;
                FrmLock frmLogin = new FrmLock(this);
                frmLogin.ShowDialog();
                RunTimerLock();
            }

            else if (exitType == ExitType.Logout)
            {
                UserBusiness.Logout(T8UserLoginInfo.IdLogin);
                UserBusiness.LastLogout(T8UserLoginInfo.Username);
            }
            this.exitType = ExitType.None;
        }

        private void gvSuratMasuk_ViewCellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement is GridHeaderCellElement)
            {
                Padding pad = new System.Windows.Forms.Padding(2);
                e.CellElement.Font = new Font("Segoe UI", (float)9, FontStyle.Bold);
                e.CellElement.Padding = pad;
                e.CellElement.TextAlignment = ContentAlignment.MiddleLeft;
            }
        }

        private void radMenuItem8_Click(object sender, EventArgs e)
        {
            if (ValidasiWithNoCheckGrid("User Maintenance"))
            {
                FrmUser frmPengguna = new FrmUser();
                frmPengguna.ShowDialog();
            }
        }

        private bool ValidasiWithNoCheckGrid(string _hak_akses)
        {
            if (!T8UserLoginInfo.HakAkses.ToLower().Contains(_hak_akses.ToLower()) && !T8UserLoginInfo.HakAkses.ToLower().Contains(("Administrator: Root").ToLower()))
            {
                MessageBox.Show(this, "Anda tidak mempunyai hak untuk melakukan proses ini.", "Akses ditolak", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (!FillPassword())
                return false;

            return true;
        }

        private void radMenuItem10_Click(object sender, EventArgs e)
        {
            if (!ValidGrid()) return;
            FrmUbahPassword frmUbahPassword = new FrmUbahPassword();
            frmUbahPassword.ShowDialog();
        }

        private void radMenuItem12_Click(object sender, EventArgs e)
        {
            this.exitType = ExitType.Logout;
            if (MessageBox.Show(this, "Anda yakin akan keluar aplikasi?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                    == System.Windows.Forms.DialogResult.No) return;
            else
            {
                Application.Restart();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (ValidasiWithGridCheck("Disposisi"))
                DisposisiSurat();
        }

        private void DisposisiSurat()
        {
            FrmDisposisi frmDisposisi = new FrmDisposisi(gvSuratMasuk.MasterView.Rows[gvSuratMasuk.SelectedRows[0].Index].Cells[0].Value.ToString());
            frmDisposisi.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (ValidasiWithGridCheck("Disposisi"))
                HistoriDisposisiProcess();
        }

        private void HistoriDisposisiProcess()
        {
            FrmHistoriDisposisi frmSejarahDisposisi = new FrmHistoriDisposisi(gvSuratMasuk.MasterView.Rows[gvSuratMasuk.SelectedRows[0].Index].Cells[0].Value.ToString());
            frmSejarahDisposisi.ShowDialog();
        }


        private void gvSuratMasuk_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            Padding pad = new System.Windows.Forms.Padding(3);
            e.CellElement.Padding = pad;
        }
        
        private void radMenuItem3_Click(object sender, EventArgs e)
        {
           if(radPageView1.SelectedPage==radPageViewPage1)
           {
               this.count_no_limit = SuratQuery.CountNoLimit(this.filter);
               RefreshData();
           }
           else if (radPageView1.SelectedPage == radPageViewPage2)
           {
               this.count_no_limitSK = SuratQuery.CountNoLimitSK(this.filterSK);
               RefreshDataSK();
           }
        }

        private void radCheckBox1_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (chkAutosizeRow.Checked)
                gvSuratMasuk.AutoSizeRows = true;
            else
                gvSuratMasuk.AutoSizeRows = false;

            if (GeneralSettings.OtomatisSimpanHistoriLocal)
            {
                LocalSettings.SetSettings("AutoSizeMain", chkAutosizeRow.Checked);
            }
        }

        private void radCheckBox2_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            AdministratorViewer(chkAdministratorTable.Checked);
            if (GeneralSettings.OtomatisSimpanHistoriLocal)
            {

                LocalSettings.SetSettings("AdministratorTableMain", chkAdministratorTable.Checked);
            }
        }

        private void AdministratorViewer(bool _value)
        {
            gvSuratMasuk.Columns[1].IsVisible = _value;
            gvSuratMasuk.Columns[2].IsVisible = _value;
            gvSuratMasuk.Columns[12].IsVisible = _value;
        }

        private void dropDownLimit_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            this.page = 0;
            int.TryParse(dropDownLimit.Text, out this.count_per_page);
            this.count_no_limit = SuratQuery.CountNoLimit(this.filter);
            BindingDataGrid();
        }

        private void GridHeaderGenerate()
        {
            GridColumn();
            GridStyle();
        }

        private void GridStyle()
        {
            gvSuratMasuk.Columns[0].Width = 130;
            gvSuratMasuk.Columns[0].WrapText = true;
            gvSuratMasuk.Columns[1].Width = 110;
            gvSuratMasuk.Columns[1].WrapText = true;
            gvSuratMasuk.Columns[2].Width = 90;
            gvSuratMasuk.Columns[2].WrapText = true;
            gvSuratMasuk.Columns[3].Width = 110;
            gvSuratMasuk.Columns[3].WrapText = true;
            gvSuratMasuk.Columns[4].Width = 70;
            gvSuratMasuk.Columns[4].WrapText = true;
            gvSuratMasuk.Columns[5].Width = 140;
            gvSuratMasuk.Columns[5].WrapText = true;
            gvSuratMasuk.Columns[6].Width = 110;
            gvSuratMasuk.Columns[6].WrapText = true;
            gvSuratMasuk.Columns[7].Width = 120;
            gvSuratMasuk.Columns[7].WrapText = true;
            gvSuratMasuk.Columns[8].Width = 160;
            gvSuratMasuk.Columns[8].WrapText = true;
            gvSuratMasuk.Columns[9].Width = 100;
            gvSuratMasuk.Columns[9].WrapText = true;
            gvSuratMasuk.Columns[10].Width = 300;
            gvSuratMasuk.Columns[10].WrapText = true;
            gvSuratMasuk.Columns[11].Width = 70;
            gvSuratMasuk.Columns[11].WrapText = true;
            gvSuratMasuk.Columns[12].Width = 100;
            gvSuratMasuk.Columns[12].WrapText = true;
        }

        private void GridColumn()
        {
            gvSuratMasuk.Columns.Clear();
            gvSuratMasuk.Columns.Add("clmnNomorAgenda", "Nomor Agenda");
            gvSuratMasuk.Columns.Add("clmnTglInput", "Tanggal Input");
            gvSuratMasuk.Columns.Add("clmnJamInput", "Jam Input");
            gvSuratMasuk.Columns.Add("clmnTglTerima", "Tanggal Terima");
            gvSuratMasuk.Columns.Add("clmnKategori", "Kategori");
            gvSuratMasuk.Columns.Add("clmnNomorSurat", "Nomor Surat");
            gvSuratMasuk.Columns.Add("clmnTanggalSurat", "Tanggal Surat");
            gvSuratMasuk.Columns.Add("clmnAsalSurat", "Asal Surat");
            gvSuratMasuk.Columns.Add("clmnPerihal", "Perihal Surat");
            gvSuratMasuk.Columns.Add("clmnTKKeamanan", "TK. Keamanan");
            gvSuratMasuk.Columns.Add("clmnRingkasanIsi", "Ringkasan Isi");
            gvSuratMasuk.Columns.Add("clmnLampiran", "Lampiran");
            gvSuratMasuk.Columns.Add("clmnUser", "User");
        }

        private void GridStyleSuratKeluar()
        {
            gvSuratKeluar.Columns[0].Width = 130;
            gvSuratKeluar.Columns[0].WrapText = true;
            gvSuratKeluar.Columns[1].Width = 110;
            gvSuratKeluar.Columns[1].WrapText = true;
            gvSuratKeluar.Columns[2].Width = 90;
            gvSuratKeluar.Columns[2].WrapText = true;
            gvSuratKeluar.Columns[3].Width = 70;
            gvSuratKeluar.Columns[3].WrapText = true;
            gvSuratKeluar.Columns[4].Width = 110;
            gvSuratKeluar.Columns[4].WrapText = true;
            gvSuratKeluar.Columns[5].Width = 140;
            gvSuratKeluar.Columns[5].WrapText = true;
            gvSuratKeluar.Columns[6].Width = 160;
            gvSuratKeluar.Columns[6].WrapText = true;
            gvSuratKeluar.Columns[7].Width = 100;
            gvSuratKeluar.Columns[7].WrapText = true;
            gvSuratKeluar.Columns[8].Width = 300;
            gvSuratKeluar.Columns[8].WrapText = true;
            gvSuratKeluar.Columns[9].Width = 70;
            gvSuratKeluar.Columns[9].WrapText = true;
            gvSuratKeluar.Columns[10].Width = 100;
            gvSuratKeluar.Columns[10].WrapText = true;
            gvSuratKeluar.Columns[1].IsVisible = false;
            gvSuratKeluar.Columns[2].IsVisible = false;
            gvSuratKeluar.Columns[10].IsVisible = false;
        }

        private void GridColumnSuratKeluar()
        {
            gvSuratKeluar.Columns.Clear();
            gvSuratKeluar.Columns.Add("clmnNomorSurat", "Nomor Surat");
            gvSuratKeluar.Columns.Add("clmnTglInputSk", "Tanggal Input");
            gvSuratKeluar.Columns.Add("clmnJamInputSK", "Jam Input");
            gvSuratKeluar.Columns.Add("clmnKategoriSK", "Kategori");
            gvSuratKeluar.Columns.Add("clmnTglKirim", "Tanggal Kirim");
            gvSuratKeluar.Columns.Add("clmnTujuan", "Tujuan");
            gvSuratKeluar.Columns.Add("clmnPerihalSK", "Perihal Surat");
            gvSuratKeluar.Columns.Add("clmnTKKeamananSK", "TK. Keamanan");
            gvSuratKeluar.Columns.Add("clmnRingkasanIsiSK", "Ringkasan Isi");
            gvSuratKeluar.Columns.Add("clmnLampiranSK", "Lampiran");
            gvSuratKeluar.Columns.Add("clmnUserSK", "User");
        }

        private void MenuEnable(bool _value)
        {
            if (this.radMenu1.InvokeRequired)
            {
                this.radMenu1.Invoke(new menuDelegate(this.MenuEnable), _value);
            }
            else
                this.radMenu1.Enabled = _value;
        }

        private void ToolStripEnable(bool _value)
        {
            if (this.toolStrip1.InvokeRequired)
            {
                this.toolStrip1.Invoke(new toolStripDelegate(this.ToolStripEnable), _value);
            }
            else
                this.toolStrip1.Enabled = _value;
        }

        public void insertSingleSurat(FrmSuratMasuk frmSuratMasuk)
        {
            GridViewDataRowInfo dataRowInfo = new GridViewDataRowInfo(this.gvSuratMasuk.MasterView);
            dataRowInfo.Cells[0].Value = frmSuratMasuk.nomor_agenda;
            dataRowInfo.Cells[1].Value = string.Format("{0:dd MMM yyyy}", DateTime.Now);
            dataRowInfo.Cells[2].Value = string.Format("{0:HH:mm:ss}", DateTime.Now);
            dataRowInfo.Cells[3].Value = string.Format("{0:dd MMM yyyy}", frmSuratMasuk.dtTanggalMasuk.Value);
            dataRowInfo.Cells[4].Value = frmSuratMasuk.dropDownTipe.Text;
            dataRowInfo.Cells[5].Value = frmSuratMasuk.txtNomorSurat.Text;
            dataRowInfo.Cells[6].Value = string.Format("{0:dd MMM yyyy}", frmSuratMasuk.dtTanggalSurat.Value);
            dataRowInfo.Cells[7].Value = frmSuratMasuk.txtAsalSurat.Text;
            dataRowInfo.Cells[8].Value = frmSuratMasuk.txtPerihalSurat.Text;
            dataRowInfo.Cells[9].Value = frmSuratMasuk.dropDownTingkatKeamanan.Text;
            dataRowInfo.Cells[10].Value = frmSuratMasuk.txtRingkasanIsi.Text;
            dataRowInfo.Cells[11].Value = frmSuratMasuk.txtLampiran.Text;
            dataRowInfo.Cells[12].Value = T8UserLoginInfo.Username;
            this.gvSuratMasuk.Rows.Insert(0, dataRowInfo);

            object[] itmRow = new object[12];
            itmRow[0] = frmSuratMasuk.nomor_agenda;
            itmRow[1] = DateTime.Now;
            itmRow[2] = string.Format("{0:dd MMM yyyy}", frmSuratMasuk.dtTanggalMasuk.Value);
            itmRow[3] = frmSuratMasuk.dropDownTipe.Text;
            itmRow[4] = frmSuratMasuk.txtNomorSurat.Text;
            itmRow[5] = string.Format("{0:dd MMM yyyy}", frmSuratMasuk.dtTanggalSurat.Value);
            itmRow[6] = frmSuratMasuk.txtAsalSurat.Text;
            itmRow[7] = frmSuratMasuk.txtPerihalSurat.Text;
            itmRow[8] = frmSuratMasuk.dropDownTingkatKeamanan.Text;
            itmRow[9] = frmSuratMasuk.txtRingkasanIsi.Text;
            itmRow[10] = frmSuratMasuk.txtLampiran.Text;
            itmRow[11] = T8UserLoginInfo.Username;
            this.dt.Rows.Add(itmRow);
            this.count_no_limit++;
            lblRecordCount.Text = this.count_no_limit.ToString() + " data";
        }

        public void insertSingleSuratKeluar(Surat.FrmSuratKeluar frmSuratKeluar)
        {
            GridViewDataRowInfo dataRowInfo = new GridViewDataRowInfo(this.gvSuratKeluar.MasterView);
            dataRowInfo.Cells[0].Value = frmSuratKeluar.nomor_surat;
            dataRowInfo.Cells[1].Value = string.Format("{0:dd MMM yyyy}", DateTime.Now);
            dataRowInfo.Cells[2].Value = string.Format("{0:HH:mm:ss}", DateTime.Now);
            dataRowInfo.Cells[3].Value = frmSuratKeluar.ddKategori.Text;
            dataRowInfo.Cells[4].Value = string.Format("{0:dd MMM yyyy}", frmSuratKeluar.dtTanggalKirim.Value);
            dataRowInfo.Cells[5].Value = frmSuratKeluar.txtTujuan.Text;
            dataRowInfo.Cells[6].Value = frmSuratKeluar.txtPerihalSurat.Text;
            dataRowInfo.Cells[7].Value = frmSuratKeluar.dropDownTingkatKeamanan.Text;
            dataRowInfo.Cells[8].Value = frmSuratKeluar.txtRingkasanIsi.Text;
            dataRowInfo.Cells[9].Value = frmSuratKeluar.txtLampiran.Text;
            dataRowInfo.Cells[10].Value = T8UserLoginInfo.Username;
            this.gvSuratKeluar.Rows.Insert(0, dataRowInfo);

            object[] itmRow = new object[10];
            itmRow[0] = frmSuratKeluar.nomor_surat;
            itmRow[1] = DateTime.Now;
            itmRow[2] = frmSuratKeluar.ddKategori.Text;
            itmRow[3] = string.Format("{0:dd MMM yyyy}", frmSuratKeluar.dtTanggalKirim.Value);
            itmRow[4] = frmSuratKeluar.txtTujuan.Text;
            itmRow[5] = frmSuratKeluar.txtPerihalSurat.Text;
            itmRow[6] = frmSuratKeluar.dropDownTingkatKeamanan.Text;
            itmRow[7] = frmSuratKeluar.txtRingkasanIsi.Text;
            itmRow[8] = frmSuratKeluar.txtLampiran.Text;
            itmRow[9] = T8UserLoginInfo.Username;
            this.dtSK.Rows.Add(itmRow);
            this.count_no_limitSK++;
            lblRecordCount.Text = this.count_no_limitSK.ToString() + " data";
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (page > 0)
                page--;
            else
                return;
            int.TryParse(dropDownLimit.Text, out this.count_per_page);
            this.count_no_limit = SuratQuery.CountNoLimit(this.filter);
            BindingDataGrid();
        }

        private void bntNext_Click(object sender, EventArgs e)
        {
            int.TryParse(dropDownLimit.Text, out this.count_per_page);
            this.count_no_limit = SuratQuery.CountNoLimit(this.filter);
            int pageCount;
            if (this.count_no_limit % this.count_per_page > 0)
                pageCount = ((this.count_no_limit / this.count_per_page) + 1);
            else
                pageCount = (this.count_no_limit / this.count_per_page);
            if ((this.page + 1) < pageCount)
                page++;
            else
                return;
            BindingDataGrid();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (page == 0)
                return;
            page = 0;
            int.TryParse(dropDownLimit.Text, out this.count_per_page);
            this.count_no_limit = SuratQuery.CountNoLimit(this.filter);
            BindingDataGrid();            
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            int.TryParse(dropDownLimit.Text, out this.count_per_page);
            this.count_no_limit = SuratQuery.CountNoLimit(this.filter);
            int pageCount;

            if (this.count_no_limit % this.count_per_page > 0)
                pageCount = ((this.count_no_limit / this.count_per_page) + 1);
            else
                pageCount = (this.count_no_limit / this.count_per_page);

            if (this.page+1 < pageCount)
                page = pageCount-1;
            else
                return;
            BindingDataGrid();
        }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.F5)
            {
                RefreshData();
            }
            else if(e.KeyCode==Keys.Escape)
            {
                this.exitType = ExitType.Exit;
                this.Close();
            }
            else if(e.KeyCode == Keys.F1)
            {
                if (!FillPassword()) return;
                InputSurat();
            }
            else if(e.KeyCode==Keys.F11)
            {
                if (!FillPassword()) return;
                Pengaturan();
            }
        }

        private void RefreshData()
        {
            this.page = 0;
            if(dropDownLimit.SelectedIndex!=0)
                dropDownLimit.SelectedIndex = 0;
            else
                BindingDataGrid();
        }

        private void RefreshDataSK()
        {
            this.pageSK = 0;
            if (ddLimitSK.SelectedIndex != 0)
                ddLimitSK.SelectedIndex = 0;
            else
                BindingDataGridSK();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (ValidasiWithGridCheck("Delete Surat Masuk"))
            {
                if (MessageBox.Show(this, "Anda yakin akan menghapus data surat?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No) return;
                DeleteSuratFromGrid();
            }
        }

        private bool ValidasiWithGridCheck(string _hak_akses)
        {
            if (!ValidGrid()) 
                return false;

            if (!T8UserLoginInfo.HakAkses.ToLower().Contains(_hak_akses.ToLower()) && !T8UserLoginInfo.HakAkses.ToLower().Contains(("Administrator: Root").ToLower())
                && !T8UserLoginInfo.HakAkses.ToLower().Contains(("Administrator: Surat Masuk / Surat Keluar").ToLower()))
            {
                MessageBox.Show(this, "Anda tidak mempunyai hak untuk melakukan proses ini.", "Akses ditolak", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (!FillPassword()) 
                return false;

            return true;
        }

        private void DeleteSuratFromGrid()
        {
            SuratBusiness.HapusSuratMasuk(gvSuratMasuk.MasterView.Rows[gvSuratMasuk.SelectedRows[0].Index].Cells[0].Value.ToString());
            gvSuratMasuk.Rows.RemoveAt(gvSuratMasuk.SelectedRows[0].Index);
            MessageBox.Show(this, "Data surat sudah dihapus.", "Data dihapus", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (ValidasiWithGridCheck("Edit Surat Masuk"))
                EditSuratFromGrid();
        }

        private void EditSuratFromGrid()
        {
            FrmEditSuratMasuk frmEditSurat =
                new FrmEditSuratMasuk(this, gvSuratMasuk.MasterView.Rows[gvSuratMasuk.SelectedRows[0].Index].Cells[0].Value.ToString());
            frmEditSurat.ShowDialog();
        }

        private bool FillPassword()
        {
            if (GUI.GeneralSettings.KonfirmasiAksesPassword)
            {
                FrmInputPassword frmInput = new FrmInputPassword();
                frmInput.ShowDialog();
                return frmInput.open;
            }
            else
                return true;
        }

        public void UpdateSurat(FrmEditSuratMasuk _frmEditSurat, string _nomor_agenda)
        {
            for (int i = 0; i < gvSuratMasuk.RowCount;i++ )
            {
                if(_nomor_agenda==gvSuratMasuk.MasterView.Rows[i].Cells[0].Value.ToString())
                {
                    gvSuratMasuk.MasterView.Rows[i].Cells[5].Value = _frmEditSurat.txtNomorSurat.Text;
                    gvSuratMasuk.MasterView.Rows[i].Cells[6].Value = string.Format("{0:dd MMM yyyy}", _frmEditSurat.dtTanggalSurat.Value);
                    gvSuratMasuk.MasterView.Rows[i].Cells[7].Value = _frmEditSurat.txtAsalSurat.Text;
                    gvSuratMasuk.MasterView.Rows[i].Cells[8].Value = _frmEditSurat.txtPerihalSurat.Text;
                    gvSuratMasuk.MasterView.Rows[i].Cells[9].Value = _frmEditSurat.dropDownTingkatKeamanan.Text;
                    gvSuratMasuk.MasterView.Rows[i].Cells[10].Value = _frmEditSurat.txtRingkasanIsi.Text;
                    gvSuratMasuk.MasterView.Rows[i].Cells[11].Value = _frmEditSurat.txtLampiran.Text;
                    break;
                }
            }
        }

        public void UpdateSuratKeluar(Surat.FrmEditSuratKeluar _frmEditSurat, string _nomor_agenda)
        {
            for (int i = 0; i < gvSuratKeluar.RowCount; i++)
            {
                if (_nomor_agenda == gvSuratKeluar.MasterView.Rows[i].Cells[0].Value.ToString())
                {
                    gvSuratKeluar.MasterView.Rows[i].Cells[4].Value = string.Format("{0:dd MMM yyyy}", _frmEditSurat.dtTanggalKirim.Value); 
                    gvSuratKeluar.MasterView.Rows[i].Cells[5].Value = _frmEditSurat.txtTujuan.Text;
                    gvSuratKeluar.MasterView.Rows[i].Cells[6].Value = _frmEditSurat.txtPerihalSurat.Text;
                    gvSuratKeluar.MasterView.Rows[i].Cells[7].Value = _frmEditSurat.dropDownTingkatKeamanan.Text;
                    gvSuratKeluar.MasterView.Rows[i].Cells[8].Value = _frmEditSurat.txtRingkasanIsi.Text;
                    gvSuratKeluar.MasterView.Rows[i].Cells[9].Value = _frmEditSurat.txtLampiran.Text;
                    break;
                }
            }
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            if (ValidasiWithGridCheck("Delete Surat Masuk"))
            {
                DetailView();
            }
        }

        private void DetailView()
        {
            GridViewDataRowInfo dr = new GridViewDataRowInfo(this.gvSuratMasuk.MasterView);
            dr.Cells[0].Value = gvSuratMasuk.MasterView.Rows[gvSuratMasuk.SelectedRows[0].Index].Cells[0].Value;
            dr.Cells[1].Value = gvSuratMasuk.MasterView.Rows[gvSuratMasuk.SelectedRows[0].Index].Cells[1].Value;
            dr.Cells[2].Value = gvSuratMasuk.MasterView.Rows[gvSuratMasuk.SelectedRows[0].Index].Cells[2].Value;
            dr.Cells[3].Value = gvSuratMasuk.MasterView.Rows[gvSuratMasuk.SelectedRows[0].Index].Cells[3].Value;
            dr.Cells[4].Value = gvSuratMasuk.MasterView.Rows[gvSuratMasuk.SelectedRows[0].Index].Cells[4].Value;
            dr.Cells[5].Value = gvSuratMasuk.MasterView.Rows[gvSuratMasuk.SelectedRows[0].Index].Cells[5].Value;
            dr.Cells[6].Value = gvSuratMasuk.MasterView.Rows[gvSuratMasuk.SelectedRows[0].Index].Cells[6].Value;
            dr.Cells[7].Value = gvSuratMasuk.MasterView.Rows[gvSuratMasuk.SelectedRows[0].Index].Cells[7].Value;
            dr.Cells[8].Value = gvSuratMasuk.MasterView.Rows[gvSuratMasuk.SelectedRows[0].Index].Cells[8].Value;
            dr.Cells[9].Value = gvSuratMasuk.MasterView.Rows[gvSuratMasuk.SelectedRows[0].Index].Cells[9].Value;
            dr.Cells[10].Value = gvSuratMasuk.MasterView.Rows[gvSuratMasuk.SelectedRows[0].Index].Cells[10].Value;
            dr.Cells[11].Value = gvSuratMasuk.MasterView.Rows[gvSuratMasuk.SelectedRows[0].Index].Cells[11].Value;
            dr.Cells[12].Value = gvSuratMasuk.MasterView.Rows[gvSuratMasuk.SelectedRows[0].Index].Cells[12].Value;

            FrmDetailSurat frmDetailSurat = new FrmDetailSurat(dr);
            frmDetailSurat.ShowDialog();
        }

        private void radMenuItem9_Click(object sender, EventArgs e)
        {
            EditSuratFromGrid();
        }

        private void radMenuItem11_Click(object sender, EventArgs e)
        {
            DeleteSuratFromGrid();
        }

        private void radMenuItem6_Click(object sender, EventArgs e)
        {
            DisposisiSurat();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            if (ValidasiWithGridCheck("Penyelesaian"))
                PenyelesaianProcess();
        }

        private void PenyelesaianProcess()
        {
            FrmPenyelesaian frmPenyelesaian = new FrmPenyelesaian(gvSuratMasuk.MasterView.Rows[gvSuratMasuk.SelectedRows[0].Index].Cells[0].Value.ToString());
            frmPenyelesaian.ShowDialog();
        }

        private void radMenuItem15_Click(object sender, EventArgs e)
        {
            if (ValidasiWithGridCheck("Disposisi"))
                HistoriDisposisiProcess();
        }

        private void radMenuItem17_Click(object sender, EventArgs e)
        {
            if (ValidasiWithGridCheck("Delete Surat Masuk"))
            {
                DetailView();
            }
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            if(ValidasiWithGridCheck("Penyelesaian"))
                HistoryPenyelesaian();
        }

        private void HistoryPenyelesaian()
        {
            FrmHistoryPenyelesaian frmHistoryPenyelesaian = new FrmHistoryPenyelesaian(gvSuratMasuk.MasterView.Rows[gvSuratMasuk.SelectedRows[0].Index].Cells[0].Value.ToString());
            frmHistoryPenyelesaian.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (ValidasiWithGridCheck("Export Data Surat Masuk"))
                GlobalFunction.ExportExcelProcess(this.gvSuratMasuk);
        }   

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (FillPassword())
            {
                this.filter = this.patent_filter;
                radCheckBoxElement1.Checked = true;
                Filter.FrmFilterMain frmFilterMain = new Filter.FrmFilterMain(this);
                frmFilterMain.ShowInTaskbar = false;
                frmFilterMain.ShowDialog();

                if (this.filter == "")
                {
                    radCheckBoxElement1.Checked = false;
                    return;
                }
                this.count_no_limit = SuratQuery.CountNoLimit(this.filter);
                RefreshData();
            }
        }
         
        private bool ValidGrid()
        {
            if (gvSuratMasuk.Rows.Count < 1)
            {
                MessageBox.Show(this, "Data surat masih kosong.", "Data Kosong", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            return true;
        }

        private bool ValidGridSK()
        {
            if (gvSuratKeluar.Rows.Count < 1)
            {
                MessageBox.Show(this, "Data surat masih kosong.", "Data Kosong", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            return true;
        }

        private void radMenuItem7_Click(object sender, EventArgs e)
        {
            if(ValidasiWithGridCheck("Penyelesaian"))
                PenyelesaianProcess();
        }

        private void radMenuItem14_Click(object sender, EventArgs e)
        {
            if(ValidasiWithGridCheck("Penyelesaian"))
                HistoryPenyelesaian();
        }

        private void radCheckBoxElement1_Click(object sender, EventArgs e)
        {
            if (radPageView1.SelectedPage == radPageViewPage1)
            {
                if (radCheckBoxElement1.Checked)
                {
                    this.temp_filter = this.filter;
                    this.filter = this.patent_filter;
                }
                else
                {
                    this.filter = this.temp_filter;
                    this.temp_filter = this.patent_filter;
                }

                this.count_no_limit = SuratQuery.CountNoLimit(this.filter);
                lblRecordCount.Text = this.count_no_limit.ToString();
                RefreshData();
            }
            else if (radPageView1.SelectedPage == radPageViewPage2)
            {
                if (radCheckBoxElement1.Checked)
                {
                    this.temp_filterSK = this.filterSK;
                    this.filterSK = this.patent_filter;
                }
                else
                {
                    this.filterSK = this.temp_filterSK;
                    this.temp_filterSK = this.patent_filter;
                }

                this.count_no_limitSK = SuratQuery.CountNoLimitSK(this.filterSK);
                lblRecordCount.Text = this.count_no_limitSK.ToString();
                RefreshDataSK();
            }
        }

        private void toolStripButton4_Click_1(object sender, EventArgs e)
        {
            if (ValidasiWithNoCheckGrid("Input Surat Masuk"))
                InputSurat();
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            if (ValidasiWithNoCheckGrid("Input Surat Keluar"))
            {
                InputSuratKeluar();
            }
        }

        private void InputSuratKeluar()
        {
            Surat.FrmSuratKeluar frmSuratKeluar = new Surat.FrmSuratKeluar(this);
            frmSuratKeluar.ShowInTaskbar = false;
            frmSuratKeluar.ShowDialog();
        }

        private void gvSuratKeluar_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            Padding pad = new System.Windows.Forms.Padding(3);
            e.CellElement.Padding = pad;
        }

        private void gvSuratKeluar_ViewCellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement is GridHeaderCellElement)
            {
                Padding pad = new System.Windows.Forms.Padding(2);
                e.CellElement.Font = new Font("Segoe UI", (float)9, FontStyle.Bold);
                e.CellElement.Padding = pad;
                e.CellElement.TextAlignment = ContentAlignment.MiddleLeft;
            }
        }

        private void radCheckBox2_ToggleStateChanged_1(object sender, StateChangedEventArgs args)
        {
            gvSuratKeluar.AutoSizeRows = radCheckBox2.Checked;

            if (GeneralSettings.OtomatisSimpanHistoriLocal)
            {
                LocalSettings.SetSettings("AutoSizeMainSK", radCheckBox2.Checked);
            }
        }

        private void radCheckBox1_ToggleStateChanged_1(object sender, StateChangedEventArgs args)
        {
            AdministratorViewerSK(radCheckBox1.Checked);
            if (GeneralSettings.OtomatisSimpanHistoriLocal)
            {

                LocalSettings.SetSettings("AdministratorTableMainSK", radCheckBox1.Checked);
            }
        }

        private void AdministratorViewerSK(bool _value)
        {
            gvSuratKeluar.Columns[1].IsVisible = _value;
            gvSuratKeluar.Columns[2].IsVisible = _value;
            gvSuratKeluar.Columns[10].IsVisible = _value;
        }

        private void GenerateDataSuratKeluar()
        {
            dtSK = SuratBusiness.SelectKeluar(this.filterSK, pageSK * this.count_per_pageSK, this.count_per_pageSK);

            Thread.Sleep(50);

            for (int i = dtSK.Rows.Count - 1; i >= 0; i--)
            {
                if (this.gvSuratKeluar.InvokeRequired)
                {
                    this.gvSuratKeluar.Invoke(new addRowDelegateSK(this.addRowSK), GetDataRowSk(dt, i));
                }
                else
                {
                    this.gvSuratKeluar.Rows.Insert(0, GetDataRowSk(dt, i));
                }
                Thread.Sleep(50);
            }

            Thread.Sleep(50);

            if (frmLoading.InvokeRequired)
            {
                this.frmLoading.Invoke(new frmLoadingDelegate(this.closeFrmLoadingSK), true);
            }
            else
            {
                closeFrmLoadingSK(true);
            }
        }

        bool skOK = false;
        private void radPageView1_SelectedPageChanged(object sender, EventArgs e)
        {
            if (radPageView1.SelectedPage == radPageViewPage1)
                lblRecordCount.Text = this.count_no_limit.ToString() + " data";
            else
                lblRecordCount.Text = this.count_no_limitSK.ToString() + " data";

            if(radPageView1.SelectedPage == radPageViewPage2)
            {
                if (skOK) return;
                else
                    skOK = true;

                this.pageSK = 0;
                this.count_no_limitSK = 0;
                ddLimitSK.SelectedIndex = 0;
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            if (pageSK == 0)
                return;
            pageSK = 0;

            int.TryParse(ddLimitSK.Text, out this.count_per_pageSK);
            this.count_no_limitSK = SuratQuery.CountNoLimitSK(this.filterSK);
            BindingDataGridSK();     
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            if (pageSK > 0)
                pageSK--;
            else
                return;
            int.TryParse(ddLimitSK.Text, out this.count_per_pageSK);

            this.count_no_limitSK = SuratQuery.CountNoLimitSK(this.filterSK);
            BindingDataGridSK();
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            int.TryParse(ddLimitSK.Text, out this.count_per_pageSK);

            this.count_no_limitSK = SuratQuery.CountNoLimitSK(this.filterSK);

            int pageCountsk;
            if (this.count_no_limitSK % this.count_per_pageSK > 0)
                pageCountsk = ((this.count_no_limitSK / this.count_per_pageSK) + 1);
            else
                pageCountsk = (this.count_no_limitSK / this.count_per_pageSK);


            if ((this.pageSK + 1) < pageCountsk)
                pageSK++;
            else
                return;
            BindingDataGridSK();
        }

        private void radButton4_Click(object sender, EventArgs e)
        {
            int.TryParse(ddLimitSK.Text, out this.count_per_pageSK);
            this.count_no_limitSK = SuratQuery.CountNoLimitSK(this.filterSK);
            int pageCountsk;

            if (this.count_no_limitSK % this.count_per_pageSK > 0)
                pageCountsk = ((this.count_no_limitSK / this.count_per_pageSK) + 1);
            else
                pageCountsk = (this.count_no_limitSK / this.count_per_pageSK);

            if (this.pageSK + 1 < pageCountsk)
                pageSK = pageCountsk - 1;
            else
                return;
            BindingDataGridSK();
        }

        private void ddLimitSK_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            this.pageSK = 0;
            int.TryParse(ddLimitSK.Text, out this.count_per_pageSK);
            this.count_no_limitSK = SuratQuery.CountNoLimitSK(this.filterSK);
            BindingDataGridSK();
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            if (ValidasiWithGridCheckSK("Edit Surat Keluar"))
                EditSuratKeluar();
        }

        private bool ValidasiWithGridCheckSK(string _hak_akses)
        {
            if (!ValidGridSK())
                return false;
            
            if (!T8UserLoginInfo.HakAkses.ToLower().Contains(_hak_akses.ToLower()) && !T8UserLoginInfo.HakAkses.ToLower().Contains(("Administrator: Root").ToLower())
                && !T8UserLoginInfo.HakAkses.ToLower().Contains(("Administrator: Surat Masuk / Surat Keluar").ToLower()))
            {
                MessageBox.Show(this, "Anda tidak mempunyai hak untuk melakukan proses ini.", "Akses ditolak", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (!FillPassword())
                return false;

            return true;
        }

        private void EditSuratKeluar()
        {
            Surat.FrmEditSuratKeluar frmEditSuratKeluar = 
                new Surat.FrmEditSuratKeluar(this, gvSuratKeluar.MasterView.Rows[gvSuratKeluar.SelectedRows[0].Index].Cells[0].Value.ToString());
            frmEditSuratKeluar.ShowInTaskbar = false;
            frmEditSuratKeluar.ShowDialog(this);
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            if (ValidasiWithGridCheckSK("Hapus Surat Keluar"))
            {
                if (MessageBox.Show(this, "Anda yakin akan menghapus data surat?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                    == System.Windows.Forms.DialogResult.No) return;
                DeleteSuratKeluar();
            }
        }

        private void DeleteSuratKeluar()
        {
            SuratBusiness.HapusSuratKeluar(gvSuratKeluar.MasterView.Rows[gvSuratKeluar.SelectedRows[0].Index].Cells[0].Value.ToString());
            gvSuratKeluar.Rows.RemoveAt(gvSuratKeluar.SelectedRows[0].Index);
            MessageBox.Show(this, "Data surat sudah dihapus.", "Data dihapus", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void toolStripButton19_Click(object sender, EventArgs e)
        {
            if (ValidasiWithGridCheckSK("Hapus Surat Keluar"))
            {
                DetailViewSK();
            }
        }

        private void DetailViewSK()
        {
            GridViewDataRowInfo dr = new GridViewDataRowInfo(this.gvSuratKeluar.MasterView);
            dr.Cells[0].Value = gvSuratKeluar.MasterView.Rows[gvSuratKeluar.SelectedRows[0].Index].Cells[0].Value;
            dr.Cells[1].Value = gvSuratKeluar.MasterView.Rows[gvSuratKeluar.SelectedRows[0].Index].Cells[4].Value;
            dr.Cells[2].Value = gvSuratKeluar.MasterView.Rows[gvSuratKeluar.SelectedRows[0].Index].Cells[5].Value;
            dr.Cells[3].Value = gvSuratKeluar.MasterView.Rows[gvSuratKeluar.SelectedRows[0].Index].Cells[6].Value;
            dr.Cells[4].Value = gvSuratKeluar.MasterView.Rows[gvSuratKeluar.SelectedRows[0].Index].Cells[7].Value;
            dr.Cells[5].Value = gvSuratKeluar.MasterView.Rows[gvSuratKeluar.SelectedRows[0].Index].Cells[8].Value;
            dr.Cells[6].Value = gvSuratKeluar.MasterView.Rows[gvSuratKeluar.SelectedRows[0].Index].Cells[9].Value;

            Surat.FrmInfoSuratKeluar frmDetailSurat = new Surat.FrmInfoSuratKeluar(dr);
            frmDetailSurat.ShowDialog();
        }

        private void toolStripButton16_Click(object sender, EventArgs e)
        {
            if (!FillPassword()) return;
            this.filterSK = this.patent_filter; 
            radCheckBoxElement1.Checked = true;
            Filter.FrmFilterSuratKeluar frmFilterMain = new Filter.FrmFilterSuratKeluar(this);
            frmFilterMain.ShowInTaskbar = false;
            frmFilterMain.ShowDialog();

            if (this.filterSK == "")
            {
                radCheckBoxElement1.Checked = false;
                return;
            }
            this.count_no_limitSK = SuratQuery.CountNoLimitSK(this.filterSK);
            RefreshDataSK();
        }

        private void radMenuItem2_Click_1(object sender, EventArgs e)
        {
            if (ValidasiWithNoCheckGrid("Administrator: Surat Masuk"))
            {
                History.FrmHistoryEditSuratMasuk frmHistoryEditSuratMasuk = new History.FrmHistoryEditSuratMasuk();
                frmHistoryEditSuratMasuk.ShowInTaskbar = false;
                frmHistoryEditSuratMasuk.ShowDialog();
            }
        }

        private void radMenuItem16_Click(object sender, EventArgs e)
        {
            if (ValidasiWithNoCheckGrid("Administrator: Surat Keluar"))
            {
                History.FrmHistoryEditSuratKeluar frmHistoryEditSuratKeluar = new History.FrmHistoryEditSuratKeluar();
                frmHistoryEditSuratKeluar.ShowInTaskbar = false;
                frmHistoryEditSuratKeluar.ShowDialog();
            }
        }

        private void toolStripButton20_Click(object sender, EventArgs e)
        {
            if (ValidasiWithGridCheckSK("Export Data Surat Keluar"))
                GlobalFunction.ExportExcelProcess(this.gvSuratKeluar);
        }

        int counter = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (counter == 0)
            {
                this.lblDetik.Text = "";
                this.counter = 1;  
            }
            else
            {
                this.lblDetik.Text = ":";
                this.counter = 0;
                lblJam.Text = string.Format("{0: HH}", DateTime.Now);
                lblMenit.Text = string.Format("{0: mm}", DateTime.Now);
            }
        }
    }
}
