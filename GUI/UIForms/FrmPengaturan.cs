using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using T8CoreEnginee;
using System.Data.Odbc;
using Telerik.WinControls.UI;
using IWshRuntimeLibrary;
using Data;
using System.IO;
using Business;

namespace GUI.UIForms
{
    public partial class FrmPengaturan : Telerik.WinControls.UI.RadForm
    {
        string database_setting_file_path = Application.StartupPath + @"\settings\sett.ets";
        string suratmasuk_setting_file_path = Application.StartupPath + @"\settings\suratmasuk.ets";
        public FrmPengaturan()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
        }

        private void FrmPengaturan_Load(object sender, EventArgs e)
        {
            InitCurrentSetting();

        }

        private void InitCurrentSetting()
        {
            GeneralSettings();
            GetODBCDriverList();
            DatabaseSettings();
        }

        private void GetODBCDriverList()
        {
            DevToolShed.OdbcDataSourceManager dsnManager = new DevToolShed.OdbcDataSourceManager();
            System.Collections.SortedList dsnList = dsnManager.GetAllDataSourceNames();
            for (int i = 0; i < dsnList.Count; i++)
            {
                string sName = (string)dsnList.GetKey(i);
                DevToolShed.DataSourceType type = (DevToolShed.DataSourceType)dsnList.GetByIndex(i);
                dropDownDriverList.Items.Add(sName);
            }
        }

        private void DatabaseSettings()
        {
            dropDownDriverList.Text = T8Application.DatabaseDriver;
            txtHost.Text = T8Application.DatabaseHost;
            txtPort.Text = T8Application.DatabasePort;
            drDbName.Text = T8Application.DatabaseDatabaseName;
            txtUsername.Text = T8Application.DatabaseUID;
            txtPassword.Text = T8Application.DatabasePassword;
        }

        private void GeneralSettings()
        {
            chkStartUp.Checked = System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + @"\" + Application.ProductName + @".lnk");
            chkIdleTime.Checked = GUI.GeneralSettings.IsIdleTime;
            chkKonfirmasiPassword.Checked = GUI.GeneralSettings.KonfirmasiAksesPassword;
            chkSimpanHistorySettingLocalUser.Checked = GUI.GeneralSettings.OtomatisSimpanHistoriLocal;
            chkUserSpesifik.Checked = GUI.GeneralSettings.IzinkanUserLain;
            nIdleTime.Value = GUI.GeneralSettings.IdleTimeValue;
            chkOtomatisCetakAgendaDisposisi.Checked = GUI.GeneralSettings.OtomatisCetakAgenda;
            nRangkapCetakDisposisi.Value = GUI.GeneralSettings.OtomatisCetakAgendaValue;

            chkOtomatisCetakAgendaDisposisi.Checked = GUI.GeneralSettings.OtomatisCetakAgenda;
            nRangkapCetakDisposisi.Value = GUI.GeneralSettings.OtomatisCetakAgendaValue;

            chkOtomatisCetakSuratKeluar.Checked = GUI.GeneralSettings.OtomatisCetakAgendaSK;
            nRangkapCetakSuratKeluar.Value = GUI.GeneralSettings.OtomatisCetakAgendaValueSK;

            chkOtomatisCetakAgendaPenyelesaian.Checked = GUI.GeneralSettings.OtomatisCetakAgendaPenyelesaian;
            nRangkapCetakPenyelesaian.Value = GUI.GeneralSettings.OtomatisCetakAgendaValuePenyelesaian;
        }

        private bool ConnectionFound()
        {
            OdbcConnection cn = new OdbcConnection();
            try
            {
                string ConnectionString =
                        "Driver={" + dropDownDriverList.Text + "};server=" + txtHost.Text + ";uid=" + txtUsername.Text + ";password=" + txtPassword.Text + ";database="
                        + drDbName.Text + ";port=" + txtPort.Text;

                cn.ConnectionString = ConnectionString;
                cn.ConnectionTimeout = 5;
                cn.Open();

                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(this, "Database server tidak ditemukan, mohon periksa kembali.", "Server Tidak Ditemukan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(this, ex.Message, "Server Tidak Ditemukan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                cn.Close();
            }
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            if (!IsValid()) return;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if(ConnectionFound())
                    MessageBox.Show(this, "Database server ditemukan", "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information);  

            }
            catch (Exception f)
            {
                MessageBox.Show(this, "Database server tidak ditemukan, mohon periksa kembali.", "Server Tidak Ditemukan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(this, f.Message, "Server Tidak Ditemukan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private bool IsValid()
        {
            if (dropDownDriverList.Text == "")
            {
                MessageBox.Show(this, "Driver database belum dipilih", "Data tidak lengkap", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                dropDownDriverList.Focus();
                return false;
            }
            if (txtHost.Text == "")
            {
                MessageBox.Show(this, "Host database tidak boleh kosong", "Data tidak lengkap", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtHost.Focus();
                return false;
            }
            if (txtPort.Text == "")
            {
                MessageBox.Show(this, "Port database tidak boleh kosong", "Data tidak lengkap", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtPort.Focus();
                return false;
            }
            if (txtUsername.Text == "")
            {
                MessageBox.Show(this, "Username database tidak boleh kosong", "Data tidak lengkap", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtUsername.Focus();
                return false;
            }
            if (drDbName.Text == "")
            {
                MessageBox.Show(this, "Nama database belum dipilih", "Data tidak lengkap", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                drDbName.Focus();
                return false;
            }
            return true;
        }

        private void BindingTable()
        {
            OdbcConnection cn = new OdbcConnection();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                drDbName.Items.Clear();
                if (dropDownDriverList.Text != "" && txtHost.Text != "" && txtUsername.Text != "" && txtPort.Text != "")
                {
                    string ConnectionString =
                           "Driver={" + dropDownDriverList.Text + "};server=" + txtHost.Text + ";uid=" + txtUsername.Text + ";password=" + txtPassword.Text + ";port="
                           + txtPort.Text;
                    cn.ConnectionString = ConnectionString;
                    cn.ConnectionTimeout = 5;
                    cn.Open();
                    if (cn.State == ConnectionState.Open)
                    {
                        OdbcDataAdapter da;
                        DataTable dt = new DataTable();
                        da = new OdbcDataAdapter("SELECT TABLE_SCHEMA FROM Information_Schema.Tables where Table_Type = 'BASE TABLE' group by TABLE_SCHEMA ", cn);
                        da.Fill(dt);
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            drDbName.Items.Add(dt.Rows[i][0].ToString());
                        }
                    }
                    cn.Close();
                }
            }
            catch { }
            finally 
            {
                cn.Close();
                this.Cursor = Cursors.Default; 
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            if (!IsValid()) return;
            if (ConnectionFound())
            {
                T8GlobalFunc.WriteFileSetting(T8Application.SettingFilePath, GenerateSettings());
                MessageBox.Show(this, "Pengaturan database sudah disimpan.", "Simpan sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                radButton1.Enabled = false;
            }
        }

        StringBuilder sb;
        private string GenerateSettings()
        {
            sb = new StringBuilder();

            sb.Append(dropDownDriverList.Text + ";");
            sb.Append(txtHost.Text + ";");
            sb.Append(txtPort.Text + ";");
            sb.Append(drDbName.Text + ";");
            sb.Append(txtUsername.Text + ";");
            sb.Append(txtPassword.Text + ";");
            return T8GlobalFunc.Encrypt(sb.ToString(),"t8");
        }

        private void dropDownDriverList_Leave(object sender, EventArgs e)
        {
            BindingTable();
        }

        private void drDbName_Click(object sender, EventArgs e)
        {
            BindingTable();
        }

        private void txtHost_TextChanged(object sender, EventArgs e)
        {
            radButton1.Enabled = true;
        }

        private void txtPort_TextChanged(object sender, EventArgs e)
        {
            radButton1.Enabled = true;
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            radButton1.Enabled = true;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            radButton1.Enabled = true;
        }

        private void drDbName_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            radButton1.Enabled = true;
        }

        private void dropDownDriverList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            radButton1.Enabled = true;
        }
        
        private void chkStartUp_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (!chkStartUp.Checked)
                System.IO.File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + @"\" + Application.ProductName + @".lnk");
            else
                CreateStartupShortcut();

        }
        void CreateStartupShortcut()
        {
            WshShell shell = new WshShell();
            string shortcutAddress = Environment.GetFolderPath(Environment.SpecialFolder.Startup) + @"\" + Application.ProductName + @".lnk";
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
            shortcut.Description = "Shortcut aplikasi Database Surat Masuk."; 
            shortcut.WorkingDirectory = Application.StartupPath; 
            shortcut.Save();
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            SaveGeneralSetting();
            MessageBox.Show(this, "General setting sudah disimpan.", "Setting disimpan", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnSimpangeneral.Enabled = false;
        }

        private void SaveGeneralSetting() 
        {
            GUI.GeneralSettings.SetSettings(GUI.GeneralSettings.general_setting_file_path, GenerateGeneralSetting());
        }

        private string GenerateGeneralSetting()
        {
            StringBuilder generalSettingText = new StringBuilder();

            generalSettingText.Append(chkKonfirmasiPassword.Checked.ToString() + ";");
            generalSettingText.Append(chkIdleTime.Checked.ToString() + ";");
            generalSettingText.Append(nIdleTime.Value.ToString() + ";");
            generalSettingText.Append(chkSimpanHistorySettingLocalUser.Checked.ToString() + ";");
            generalSettingText.Append(chkUserSpesifik.Checked.ToString() + ";");

            generalSettingText.Append(chkOtomatisCetakAgendaDisposisi.Checked.ToString() + ";");
            generalSettingText.Append(nRangkapCetakDisposisi.Value.ToString() + ";");

            generalSettingText.Append(chkOtomatisCetakSuratKeluar.Checked.ToString() + ";");
            generalSettingText.Append(nRangkapCetakSuratKeluar.Value.ToString() + ";");

            generalSettingText.Append(chkOtomatisCetakAgendaPenyelesaian.Checked.ToString() + ";");
            generalSettingText.Append(nRangkapCetakPenyelesaian.Value.ToString() + ";");

            return T8GlobalFunc.Encrypt(generalSettingText.ToString(), "t8");
        }

        private void gvTplPosisiSurat_ViewCellFormatting_1(object sender, CellFormattingEventArgs e)
        {
            Padding pads = new System.Windows.Forms.Padding(3);
            e.CellElement.Padding = pads;
            if (e.CellElement is GridHeaderCellElement)
            {
                Padding pad = new System.Windows.Forms.Padding(2);
                e.CellElement.Font = new Font("Segoe UI", (float)9, FontStyle.Bold);
                e.CellElement.Padding = pad;
                e.CellElement.TextAlignment = ContentAlignment.MiddleLeft;
            }
        }

        private void chkPass_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            btnSimpangeneral.Enabled = true;
        }

        private void chkIdle_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            btnSimpangeneral.Enabled = true;
            nIdleTime.Enabled = chkIdleTime.Checked;
        }

        private void chkSaveLocal_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            btnSimpangeneral.Enabled = true;
        }

        private void chkUserAccess_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            btnSimpangeneral.Enabled = true;
            //lvKategori.Enabled = chkUserAccess.Checked;
        }

        private void radButton8_Click(object sender, EventArgs e)
        {
            FrmSettingNomorAgenda frmSetNmrAgenda = new FrmSettingNomorAgenda();
            frmSetNmrAgenda.ShowInTaskbar = false;
            frmSetNmrAgenda.ShowDialog();
        }

        private void radButton7_Click(object sender, EventArgs e)
        {
            FrmPrintoutFile frmPrintoutFile = new FrmPrintoutFile();
            frmPrintoutFile.ShowInTaskbar = false;
            frmPrintoutFile.ShowDialog();
        }

        private void radButton4_Click(object sender, EventArgs e)
        {
            FrmInputTpl frmInputTpl = new FrmInputTpl(this);
            FrmInputTpl.tplName = FrmInputTpl.TemplateName.Asal;
            FrmInputTpl.act = FrmInputTpl.Action.Tambah;
            frmInputTpl.ShowDialog();
        }

        private void radButton5_Click(object sender, EventArgs e)
        {
            FrmInputTpl frmInputTpl = new FrmInputTpl(this);
            FrmInputTpl.tplName = FrmInputTpl.TemplateName.TkKeamanan;
            FrmInputTpl.act = FrmInputTpl.Action.Tambah;
            frmInputTpl.ShowDialog();
        }

        private void radButton11_Click(object sender, EventArgs e)
        {
            FrmInputTpl frmInputTpl = new FrmInputTpl(this);
            FrmInputTpl.tplName = FrmInputTpl.TemplateName.Posisi;
            FrmInputTpl.act = FrmInputTpl.Action.Tambah;
            frmInputTpl.ShowDialog();
        }

        private void radButton14_Click(object sender, EventArgs e)
        {
            FrmInputTpl frmInputTpl = new FrmInputTpl(this);
            FrmInputTpl.tplName = FrmInputTpl.TemplateName.Kategori;
            FrmInputTpl.act = FrmInputTpl.Action.Tambah;
            frmInputTpl.ShowDialog();
        }

        private void radButton6_Click_1(object sender, EventArgs e)
        {
            FrmInputTpl frmInputTpl = new FrmInputTpl(this);
            FrmInputTpl.tplName = FrmInputTpl.TemplateName.Pengiriman;
            FrmInputTpl.act = FrmInputTpl.Action.Tambah;
            frmInputTpl.ShowDialog();
        }

        private void radButton9_Click(object sender, EventArgs e)
        {
            FrmInputTpl frmInputTpl = new FrmInputTpl(this);
            FrmInputTpl.tplName = FrmInputTpl.TemplateName.Lokasi;
            FrmInputTpl.act = FrmInputTpl.Action.Tambah;
            frmInputTpl.ShowDialog();
        }

        private void chkOtomatisCetakAgendaDisposisi_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            btnSimpangeneral.Enabled = true;
            nRangkapCetakDisposisi.Enabled = chkOtomatisCetakAgendaDisposisi.Checked;
        }

        private void nRangkapCetakDisposisi_ValueChanged(object sender, EventArgs e)
        {
            btnSimpangeneral.Enabled = true;
        }

        private void nRangkapCetakPenyelesaian_ValueChanged(object sender, EventArgs e)
        {
            btnSimpangeneral.Enabled = true;
        }

        private void chkOtomatisCetakAgendaPenyelesaian_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            btnSimpangeneral.Enabled = true;
            nRangkapCetakPenyelesaian.Enabled = chkOtomatisCetakAgendaPenyelesaian.Checked;
        }

        private void chkOtomatisCetakSuratKeluar_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            btnSimpangeneral.Enabled = true;
            nRangkapCetakSuratKeluar.Enabled = chkOtomatisCetakSuratKeluar.Checked;
        }

        private void nRangkapCetakSuratKeluar_ValueChanged(object sender, EventArgs e)
        {
            btnSimpangeneral.Enabled = true;
        }

        private void nIdleTime_EnabledChanged(object sender, EventArgs e)
        {
            nIdleTime.Value = 1;
        }

        private void nRangkapCetakDisposisi_EnabledChanged(object sender, EventArgs e)
        {
            nRangkapCetakDisposisi.Value = 1;
        }

        private void nRangkapCetakPenyelesaian_EnabledChanged(object sender, EventArgs e)
        {
            nRangkapCetakPenyelesaian.Value = 1;
        }

        private void nRangkapCetakSuratKeluar_EnabledChanged(object sender, EventArgs e)
        {
            nRangkapCetakSuratKeluar.Value = 1;
        }
    }
}
