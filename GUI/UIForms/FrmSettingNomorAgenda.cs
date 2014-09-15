using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace GUI.UIForms
{
    public partial class FrmSettingNomorAgenda : Telerik.WinControls.UI.RadForm
    {
        GridViewComboBoxColumn idxStatic = new GridViewComboBoxColumn();

        List<string> agenda_variable;
        List<int> idxStaticValueReal;
        List<int> idxStaticValue;

        BindingSource bDdIdxTKKeamanan = new BindingSource();
        BindingSource bDdIdxKategori = new BindingSource();
        BindingSource bDdIdxIncludeYear = new BindingSource();
        BindingSource bDdIdxIncludeMonth = new BindingSource();
        BindingSource bDdIdxId = new BindingSource();
        BindingSource bdIdxIncludeDay = new BindingSource();

        public FrmSettingNomorAgenda()
        {
            InitializeComponent();
        }

        private void FrmSettingNomorAgenda_Load(object sender, EventArgs e)
        {
            StaticGrid();

            GenerateDataSuratMasuk();
        }

        private void GenerateDataSuratMasuk()
        {
            ClearItem();

            InitIndex();
            this.agenda_variable = new List<string>();

            nIDLen.Value = (int)AppDefaultSetting.surat_masuk_minimum_id_lenght;

            if (AppDefaultSetting.surat_masuk_index_start.ToLower() == "Message Box Confirmation Before Input".ToLower())
                rdoMessage.IsChecked = true;
            else
                rdoFlat.IsChecked = true;

            lblNomorAgenda.Text = AppDefaultSetting.surat_masuk_format_nomor_agenda;

            string[] format_nomor_agenda = AppDefaultSetting.surat_masuk_format_nomor_agenda.Split(AppDefaultSetting.surat_masuk_concat_nomor_agenda);

            this.radGridView1.Rows.Clear();
            for(int i=0;i<format_nomor_agenda.Length;i++)
            {
                if (format_nomor_agenda[i].ToLower() == "{id}".ToLower())
                {
                    ddIdxId.SelectedIndex = i;
                    this.agenda_variable.Insert(i, format_nomor_agenda[i]);
                }
                else if (format_nomor_agenda[i].ToLower() == "{kategori}".ToLower())
                {
                    chkKategori.Checked = AppDefaultSetting.surat_keluar_include_kategori_nomor_agenda;
                }
                else if (format_nomor_agenda[i].ToLower() == "{day}".ToLower())
                {
                    chkIncludeDay.Checked = AppDefaultSetting.surat_keluar_include_day_nomor_agenda;
                }
                else if (format_nomor_agenda[i].ToLower() == "{month}".ToLower())
                { 
                    chkIncludeMonth.Checked = AppDefaultSetting.surat_keluar_include_month_nomor_agenda;
                }
                else if (format_nomor_agenda[i].ToLower() == "{year}".ToLower())
                { 
                    chkIncludeYear.Checked = AppDefaultSetting.surat_keluar_include_year_nomor_agenda;
                }
                else if (format_nomor_agenda[i].ToLower() == "{tkkeamanan}".ToLower())
                {
                    chkTkKeamanan.Checked = AppDefaultSetting.surat_keluar_include_tingkat_keamanan_nomor_agenda;
                }
                else
                {
                    GridViewDataRowInfo dataRowInfo = new GridViewDataRowInfo(this.radGridView1.MasterView);
                    dataRowInfo.Cells[0].Value = format_nomor_agenda[i];
                    dataRowInfo.Cells[1].Value = "";
                    this.radGridView1.Rows.Insert(0, dataRowInfo);
                    this.agenda_variable.Insert(i, format_nomor_agenda[i]);
                    this.idxStaticValue.Add(this.agenda_variable.Count - 1);
                }
            }

            ddFormatDay.Text = AppDefaultSetting.surat_masuk_format_day;
            ddFormatMonth.Text = AppDefaultSetting.surat_masuk_format_month;
            ddFormatYear.Text = AppDefaultSetting.surat_masuk_format_year;

            if (AppDefaultSetting.surat_masuk_reset_role.ToLower() != "")
            {
                chkReset.Checked = true;

                if (AppDefaultSetting.surat_masuk_reset_role.ToString().ToLower() == "Kategori".ToLower())
                    ddReset.SelectedIndex = 0;
                else if (AppDefaultSetting.surat_masuk_reset_role.ToString().ToLower() == "TkKeamanan".ToLower())
                    ddReset.SelectedIndex = 1;
                else if (AppDefaultSetting.surat_masuk_reset_role.ToString().ToLower() == "Daily".ToLower())
                    ddReset.SelectedIndex = 2;
                else if (AppDefaultSetting.surat_masuk_reset_role.ToString().ToLower() == "Monthly".ToLower())
                    ddReset.SelectedIndex = 3;
                else if (AppDefaultSetting.surat_masuk_reset_role.ToString().ToLower() == "Yearly".ToLower())
                    ddReset.SelectedIndex = 4;
            }

            if (AppDefaultSetting.surat_masuk_concat_nomor_agenda.ToString().ToLower() == "/")
                ddConcat.SelectedIndex = 0;
            else if (AppDefaultSetting.surat_masuk_concat_nomor_agenda.ToString().ToLower() == "-")
                ddConcat.SelectedIndex = 1;
            else if (AppDefaultSetting.surat_masuk_concat_nomor_agenda.ToString().ToLower() == ".")
                ddConcat.SelectedIndex = 2;
            else if (AppDefaultSetting.surat_masuk_concat_nomor_agenda.ToString().ToLower() == " ")
                ddConcat.SelectedIndex = 3;
            GenerateIDX();
            ChangeIndex(); 
        }

        private void InitIndex()
        {
            ddConcat.SelectedIndex = 0;
            this.agenda_variable = new List<string>();
            this.idxStaticValue = new List<int>();
            this.idxStaticValueReal = new List<int>();
            this.agenda_variable.Add("{id}");

            this.bDdIdxTKKeamanan.DataSource = this.idxStaticValueReal;
            this.bDdIdxKategori.DataSource = this.idxStaticValueReal;
            this.bDdIdxIncludeYear.DataSource = this.idxStaticValueReal;
            this.bDdIdxIncludeMonth.DataSource = this.idxStaticValueReal;
            this.bDdIdxId.DataSource = this.idxStaticValueReal;
            this.bdIdxIncludeDay.DataSource = this.idxStaticValueReal;

            ddIdxId.DataSource = this.bDdIdxId;
            ddIdxTKKeamanan.DataSource = this.bDdIdxTKKeamanan;
            ddIdxKategori.DataSource = this.bDdIdxKategori;
            ddIdxIncludeYear.DataSource = this.bDdIdxIncludeYear;
            ddIdxIncludeMonth.DataSource = this.bDdIdxIncludeMonth;
            ddIdxIncludeDay.DataSource = this.bdIdxIncludeDay;
        }

        private void GenerateDataSuratKeluar()
        {
            ClearItem();
            InitIndex();

            this.agenda_variable = new List<string>();

            nIDLen.Value = (int)AppDefaultSetting.surat_keluar_minimum_id_lenght;

            if (AppDefaultSetting.surat_keluar_index_start.ToLower() == "Message Box Confirmation Before Input".ToLower())
                rdoMessage.IsChecked = true;
            else
                rdoFlat.IsChecked = true;

            lblNomorAgenda.Text = AppDefaultSetting.surat_keluar_index_start;

            string[] format_nomor_agenda = AppDefaultSetting.surat_keluar_format_nomor_agenda.Split(AppDefaultSetting.surat_keluar_concat_nomor_agenda);

            for (int i = 0; i < format_nomor_agenda.Length; i++)
            {
                if (format_nomor_agenda[i].ToLower() == "{id}".ToLower())
                {
                    ddIdxId.SelectedIndex = i;
                    this.agenda_variable.Insert(i, format_nomor_agenda[i]);
                }
                else if (format_nomor_agenda[i].ToLower() == "{kategori}".ToLower())
                {
                    chkKategori.Checked = AppDefaultSetting.surat_keluar_include_kategori_nomor_agenda;
                }
                else if (format_nomor_agenda[i].ToLower() == "{day}".ToLower())
                {
                    chkIncludeDay.Checked = AppDefaultSetting.surat_keluar_include_day_nomor_agenda;
                }
                else if (format_nomor_agenda[i].ToLower() == "{month}".ToLower())
                { 
                    chkIncludeMonth.Checked = AppDefaultSetting.surat_keluar_include_month_nomor_agenda;
                }
                else if (format_nomor_agenda[i].ToLower() == "{year}".ToLower())
                { 
                    chkIncludeYear.Checked = AppDefaultSetting.surat_keluar_include_year_nomor_agenda;
                }
                else if (format_nomor_agenda[i].ToLower() == "{tkkeamanan}".ToLower())
                {
                    chkTkKeamanan.Checked = AppDefaultSetting.surat_keluar_include_tingkat_keamanan_nomor_agenda;
                }
                else
                {
                    GridViewDataRowInfo dataRowInfo = new GridViewDataRowInfo(this.radGridView1.MasterView);
                    dataRowInfo.Cells[0].Value = format_nomor_agenda[i];
                    dataRowInfo.Cells[1].Value = "";
                    this.radGridView1.Rows.Insert(0, dataRowInfo);
                    this.agenda_variable.Insert(i, format_nomor_agenda[i]);
                    this.idxStaticValue.Add(this.agenda_variable.Count - 1);
                }
            }

            ddFormatDay.Text = AppDefaultSetting.surat_keluar_format_day;
            ddFormatMonth.Text = AppDefaultSetting.surat_keluar_format_month;
            ddFormatYear.Text = AppDefaultSetting.surat_keluar_format_year;

            if (AppDefaultSetting.surat_keluar_reset_role != "")
            {
                chkReset.Checked = true;

                if (AppDefaultSetting.surat_keluar_reset_role.ToString().ToLower() == "Kategori".ToLower())
                    ddReset.SelectedIndex = 0;
                else if (AppDefaultSetting.surat_keluar_reset_role.ToString().ToLower() == "TkKeamanan".ToLower())
                    ddReset.SelectedIndex = 1;
                else if (AppDefaultSetting.surat_keluar_reset_role.ToString().ToLower() == "Daily".ToLower())
                    ddReset.SelectedIndex = 2;
                else if (AppDefaultSetting.surat_keluar_reset_role.ToString().ToLower() == "Monthly".ToLower())
                    ddReset.SelectedIndex = 3;
                else if (AppDefaultSetting.surat_keluar_reset_role.ToString().ToLower() == "Yearly".ToLower())
                    ddReset.SelectedIndex = 4;
            }

            if (AppDefaultSetting.surat_keluar_concat_nomor_agenda.ToString().ToLower() == "/")
                ddConcat.SelectedIndex = 0;
            else if (AppDefaultSetting.surat_keluar_concat_nomor_agenda.ToString().ToLower() == "-")
                ddConcat.SelectedIndex = 1;
            else if (AppDefaultSetting.surat_keluar_concat_nomor_agenda.ToString().ToLower() == ".")
                ddConcat.SelectedIndex = 2;
            else if (AppDefaultSetting.surat_keluar_concat_nomor_agenda.ToString().ToLower() == " ")
                ddConcat.SelectedIndex = 3;
            GenerateIDX();
            ChangeIndex(); 
        }

        private void ClearItem()
        {
            ddIdxId.Text = "0";
            ddReset.Text = "";
            chkReset.Checked = false;
            ddConcat.SelectedIndex = 0;
            nIDLen.Value = 1;
            chkKategori.Checked = false;
            chkTkKeamanan.Checked = false;
            chkIncludeDay.Checked = false;
            chkIncludeMonth.Checked = false;
            chkIncludeYear.Checked = false;
            this.radGridView1.Rows.Clear();
        }


        private void ChangeIndex()
        {
            int idx;

            this.changeMe = false;

            idx = this.agenda_variable.IndexOf("{id}");
            ddIdxId.SelectedIndex = idx;

            idx = this.agenda_variable.IndexOf("{day}");
            ddIdxIncludeDay.SelectedIndex = idx;

            idx = this.agenda_variable.IndexOf("{month}");
            ddIdxIncludeMonth.SelectedIndex = idx;

            idx = this.agenda_variable.IndexOf("{year}");
            ddIdxIncludeYear.SelectedIndex = idx;

            idx = this.agenda_variable.IndexOf("{kategori}");
            ddIdxKategori.SelectedIndex = idx;

            idx = this.agenda_variable.IndexOf("{tkkeamanan}");
            ddIdxTKKeamanan.SelectedIndex = idx;

            int idxGrid;
            for (int i = 0; i < this.radGridView1.Rows.Count; i++)
            {
                idxGrid = this.agenda_variable.IndexOf(this.radGridView1.Rows[i].Cells[0].Value.ToString());
                this.radGridView1.Rows[i].Cells[1].Value = idxGrid;
            }
            this.changeMe = true;

            generateNomorAgenda();
        }

        private void StaticGrid()
        {
            this.radGridView1.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;

            this.radGridView1.Columns.Add("clmnValue","Static Value");
            this.radGridView1.Columns[0].Width = 250;

            this.idxStatic.HeaderText = "Index";
            idxStatic.DataSource = this.idxStaticValue;
            this.radGridView1.Columns.Add(idxStatic);
            this.radGridView1.Columns[1].Width = 100;
        }

        bool fromChk = false;
        private void chkKategori_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            this.fromChk = true;
            if (this.resetValue.ToLower() == "Kategori".ToLower())
            {
                chkKategori.Checked = true;
                return;
            } 
            
            ddIdxKategori.Enabled = chkKategori.Checked;
            if (chkKategori.Checked)
                this.agenda_variable.Add("{kategori}");
            else
            {                
                int idx = this.agenda_variable.IndexOf("{kategori}");
                RemoveGridIdx(idx);
                this.agenda_variable.RemoveAt(idx);
                ddIdxKategori.SelectedIndex = -1;
            }
            GenerateIDX();
            ChangeIndex();
            this.fromChk = false; 
        }

        private void RemoveGridIdx(int idx)
        {
            for(int i=0;i<this.radGridView1.RowCount;i++)
            {
                int id;
                int.TryParse(this.radGridView1.Rows[i].Cells[1].Value.ToString(), out id);
                if (id > idx)
                    this.radGridView1.Rows[i].Cells[1].Value = id - 1;
            }
        }

        private void chkTkKeamanan_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            this.fromChk = true;
            if (this.resetValue.ToLower() == "TkKeamanan".ToLower())
            {
                chkTkKeamanan.Checked = true;
                return;
            }

            ddIdxTKKeamanan.Enabled = chkTkKeamanan.Checked;
            if (chkTkKeamanan.Checked)
                this.agenda_variable.Add("{tkkeamanan}");
            else
            {
                int idx = this.agenda_variable.IndexOf("{tkkeamanan}");
                this.agenda_variable.RemoveAt(idx);
                ddIdxTKKeamanan.SelectedIndex = -1;
            }
            GenerateIDX();
            ChangeIndex();
            this.fromChk = false;
        }

        private void chkIncludeDay_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            this.fromChk = true;
            if (this.resetValue.ToLower() == "Daily".ToLower())
            {
                chkIncludeDay.Checked = true;
                return;
            }

            ddIdxIncludeDay.Enabled = chkIncludeDay.Checked;
            //nLenDay.Enabled = chkIncludeDay.Checked;
            ddFormatDay.Enabled = chkIncludeDay.Checked;

            if (chkIncludeDay.Checked)
            {
                this.agenda_variable.Add("{day}");
                ddFormatDay.SelectedIndex = 0;
                //nLenDay.Value = 1;
            }
            else
            {
                int idx = this.agenda_variable.IndexOf("{day}");
                //nLenDay.Value = 1;
                RemoveGridIdx(idx);
                this.agenda_variable.RemoveAt(idx);
                ddFormatDay.SelectedIndex = -1;
                ddIdxIncludeDay.SelectedIndex = -1;
            }
            GenerateIDX();
            ChangeIndex();
            this.fromChk = false;
        }

        private void chkIncludeMonth_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            this.fromChk = true;
            if (this.resetValue.ToLower() == "Monthly".ToLower() || this.resetValue.ToLower() == "Daily".ToLower())
            {
                chkIncludeMonth.Checked = true;
                return;
            }

            ddFormatMonth.Enabled = chkIncludeMonth.Checked;
            ddIdxIncludeMonth.Enabled = chkIncludeMonth.Checked;
            //nLenMonth.Enabled = chkIncludeMonth.Checked;

            if (chkIncludeMonth.Checked)
            {
                this.agenda_variable.Add("{month}");
                ddFormatMonth.SelectedIndex = 0;
                //nLenMonth.Value = 1;
            }
            else
            {
                int idx = this.agenda_variable.IndexOf("{month}");
                ddFormatMonth.SelectedIndex = -1;
                //nLenMonth.Value = 1;
                RemoveGridIdx(idx);
                this.agenda_variable.RemoveAt(idx);
                ddIdxIncludeMonth.SelectedIndex = -1;
            }
            GenerateIDX();
            ChangeIndex();
            this.fromChk = false;
        }

        private void chkIncludeYear_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            this.fromChk = true;
            if (this.resetValue.ToLower() == "Yearly".ToLower() || this.resetValue.ToLower() == "Monthly".ToLower() || this.resetValue.ToLower() == "Daily".ToLower())
            {
                chkIncludeYear.Checked = true;
                return;
            }

            ddIdxIncludeYear.Enabled = chkIncludeYear.Checked;
            ddFormatYear.Enabled = chkIncludeYear.Checked;
            //nLenYear.Enabled = chkIncludeYear.Checked;
            ddFormatYear.SelectedIndex = 0;

            if (chkIncludeYear.Checked)
            {
                this.agenda_variable.Add("{year}");

                ddFormatYear.SelectedIndex = 0;
                //nLenYear.Value = 1;
            }
            else
            {
                int idx = this.agenda_variable.IndexOf("{year}");
                ddFormatYear.SelectedIndex = -1;
                //nLenYear.Value = 1;
                RemoveGridIdx(idx);
                this.agenda_variable.RemoveAt(idx);
                ddIdxIncludeYear.SelectedIndex = -1;
            }
            GenerateIDX();
            ChangeIndex();
            this.fromChk = false;
        }

        private void GenerateIDX()
        {
            this.idxStaticValueReal.Clear();
            this.idxStaticValue.Clear();
            for (int i = 0; i < this.agenda_variable.Count; i++)
            {
                this.idxStaticValue.Add(i);
                this.idxStaticValueReal.Add(i);
            }

            this.changeMe = false;
            ddIdxId.Rebind();
            ddIdxIncludeDay.Rebind();
            ddIdxIncludeMonth.Rebind();
            ddIdxIncludeYear.Rebind();
            ddIdxKategori.Rebind();
            ddIdxTKKeamanan.Rebind();
            this.changeMe = false;
        }

        string resetValue = "";

        private void chkReset_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            ddReset.Enabled = chkReset.Checked;
            ddReset.SelectedIndex = -1;
        }

        private void ddReset_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            this.resetValue = "";

            if (ddReset.SelectedIndex == 0)
            {
                chkKategori.Checked = true;
                this.resetValue = "Kategori";
            }

            if (ddReset.SelectedIndex == 1)
            {
                chkTkKeamanan.Checked = true;
                this.resetValue = "TkKeamanan";
            }

            if(ddReset.SelectedIndex==2)
            {
                chkIncludeDay.Checked = true;
                chkIncludeMonth.Checked = true;
                chkIncludeYear.Checked = true;
                this.resetValue = "Daily";
            }
            
            if (ddReset.SelectedIndex == 3)
            {
                chkIncludeMonth.Checked = true;
                chkIncludeYear.Checked = true;
                this.resetValue = "Monthly";
            }
            
            if (ddReset.SelectedIndex == 4)
            {
                chkIncludeYear.Checked = true;
                this.resetValue = "Yearly";
            } 

        }

        bool changeMe = true;
        
        private void ddIdxId_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (!this.changeMe || this.fromChk) return;

            int idxs;
            int.TryParse(ddIdxId.Text, out idxs);

            if (this.idxSebelum == -1) return;
            if (idxs == this.idxSebelum) return;

            string strAsal = this.agenda_variable[this.idxSebelum];

            this.agenda_variable[this.idxSebelum] = this.agenda_variable[idxs];
            this.agenda_variable[idxs] = strAsal;

            ChangeIndex();
            this.idxSebelum = -1;
        }

        private void ddIdxKategori_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (!this.changeMe || this.fromChk) return;

            int idxs;
            int.TryParse(ddIdxKategori.Text, out idxs);

            if (this.idxSebelum == -1) return;
            if (idxs == this.idxSebelum) return;

            string strAsal = this.agenda_variable[this.idxSebelum];

            this.agenda_variable[this.idxSebelum] = this.agenda_variable[idxs];
            this.agenda_variable[idxs] = strAsal;

            ChangeIndex();
            this.idxSebelum = -1;
        }

        private void ddIdxIncludeDay_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (!this.changeMe || this.fromChk) return;

            int idxs;
            int.TryParse(ddIdxIncludeDay.Text, out idxs);

            if (this.idxSebelum == -1) return;
            if (idxs == this.idxSebelum) return;

            string strAsal = this.agenda_variable[this.idxSebelum];

            this.agenda_variable[this.idxSebelum] = this.agenda_variable[idxs];
            this.agenda_variable[idxs] = strAsal;

            ChangeIndex();
            this.idxSebelum = -1;
        }

        private void ddIdxTKKeamanan_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (!this.changeMe || this.fromChk) return;

            int idxs;
            int.TryParse(ddIdxTKKeamanan.Text, out idxs);

            if (this.idxSebelum == -1) return;
            if (idxs == this.idxSebelum) return;

            string strAsal = this.agenda_variable[this.idxSebelum];

            this.agenda_variable[this.idxSebelum] = this.agenda_variable[idxs];
            this.agenda_variable[idxs] = strAsal;

            ChangeIndex();
            this.idxSebelum = -1;
        }

        private void ddIdxIncludeMonth_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (!this.changeMe || this.fromChk) return;

            int idxs;
            int.TryParse(ddIdxIncludeMonth.Text, out idxs);

            if (this.idxSebelum == -1) return;
            if (idxs == this.idxSebelum) return;

            string strAsal = this.agenda_variable[this.idxSebelum];

            this.agenda_variable[this.idxSebelum] = this.agenda_variable[idxs];
            this.agenda_variable[idxs] = strAsal;

            ChangeIndex();
            this.idxSebelum = -1;
        }

        private void ddIdxIncludeYear_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (!this.changeMe || this.fromChk) return;

            int idxs;
            int.TryParse(ddIdxIncludeYear.Text, out idxs);

            if (this.idxSebelum == -1) return;
            if (idxs == this.idxSebelum) return;

            string strAsal = this.agenda_variable[this.idxSebelum];

            this.agenda_variable[this.idxSebelum] = this.agenda_variable[idxs];
            this.agenda_variable[idxs] = strAsal;

            ChangeIndex();
            this.idxSebelum = -1;
        }

        int idxSebelum;

        private void ddIdxKategori_SelectedIndexChanging(object sender, Telerik.WinControls.UI.Data.PositionChangingCancelEventArgs e)
        {
            this.idxSebelum = ddIdxKategori.SelectedIndex;
        }

        private void ddIdxId_SelectedIndexChanging(object sender, Telerik.WinControls.UI.Data.PositionChangingCancelEventArgs e)
        {
            this.idxSebelum = ddIdxId.SelectedIndex;
        }

        private void ddIdxIncludeDay_SelectedIndexChanging(object sender, Telerik.WinControls.UI.Data.PositionChangingCancelEventArgs e)
        {
            this.idxSebelum = ddIdxIncludeDay.SelectedIndex;
        }

        private void ddIdxIncludeMonth_SelectedIndexChanging(object sender, Telerik.WinControls.UI.Data.PositionChangingCancelEventArgs e)
        {
            this.idxSebelum = ddIdxIncludeMonth.SelectedIndex;
        }

        private void ddIdxIncludeYear_SelectedIndexChanging(object sender, Telerik.WinControls.UI.Data.PositionChangingCancelEventArgs e)
        {
            this.idxSebelum = ddIdxIncludeYear.SelectedIndex;
        }

        private void ddIdxTKKeamanan_SelectedIndexChanging(object sender, Telerik.WinControls.UI.Data.PositionChangingCancelEventArgs e)
        {
            this.idxSebelum = ddIdxTKKeamanan.SelectedIndex;
        }       

        bool rowAdded = false;

        private void radGridView1_UserAddedRow(object sender, GridViewRowEventArgs e)
        {
            int idx;
            int.TryParse(e.Rows[0].Cells[1].Value.ToString(), out idx);
            this.agenda_variable.Insert(idx,e.Rows[0].Cells[0].Value.ToString()); 

            GenerateIDX();
            ChangeIndex();

            this.rowAdded = false;
        }


        char concat_nomor_agenda;
        private void generateNomorAgenda()
        {
            if (this.agenda_variable == null) return;
            string _nmr_agenda = "";
            for(int i=0;i<this.agenda_variable.Count;i++)
            {
                if(i==this.agenda_variable.Count-1)
                    _nmr_agenda = _nmr_agenda + this.agenda_variable[i];
                else
                    _nmr_agenda = _nmr_agenda + this.agenda_variable[i] + this.concat_nomor_agenda;
            }
            lblNomorAgenda.Text = _nmr_agenda;
        }

        private void radGridView1_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == 1)
                {                 
                    int idxs;
                    int.TryParse(this.radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out idxs);

                    if (this.idxGridAwal == -1) return;
                    if (idxs == this.idxGridAwal) return;

                    string strAsal = this.agenda_variable[idxs];

                    this.agenda_variable[this.idxGridAwal] = strAsal;
                    this.agenda_variable[idxs] = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                   
                    ChangeIndex();
                    idxs = -1;
                } 
                else if (e.ColumnIndex == 0)
                {
                    if (this.radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null || this.radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Contains(this.concat_nomor_agenda.ToString()))
                    {
                        this.radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = this._strAwal;
                        MessageBox.Show(this, "Inputan tidak boleh kosong/mengandung karakter concat.", "Invalid value", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    if (this._strAwal == this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()) return;
                    int idx;
                    int.TryParse(this.radGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(), out idx);
                    this.agenda_variable[idx] = e.Value.ToString();
                    generateNomorAgenda();
                }
            }
        }

        private void radGridView1_CellValidated(object sender, CellValidatedEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                if (!this.rowAdded)
                {
                    if (e.Value == null || e.Value.ToString() == string.Empty) return;
                    this.rowAdded = true;
                }
                else
                    return;
                this.idxStaticValue.Add(this.agenda_variable.Count);
            }
        }

        int idxGridAwal = -1;
        string _strAwal;
        private void radGridView1_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                this.idxStatic.DataSource = this.idxStaticValue;
                if (!this.rowAdded)
                    this.rowAdded = true;
                else
                    return;
                this.idxStaticValue.Add(this.agenda_variable.Count);
            }
            else
            {
                this.idxGridAwal = -1;
                if(e.ColumnIndex==1)
                {
                    int idxs;
                    int.TryParse(this.radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out idxs);
                    this.idxGridAwal = idxs;
                }
                else
                    this._strAwal = this.radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                this.idxStatic.DataSource = this.idxStaticValueReal;
            }
        }

        private void radGridView1_UserAddingRow(object sender, GridViewRowCancelEventArgs e)
        {
            if (e.Rows[0].Cells[0].Value == null || e.Rows[0].Cells[0].Value.ToString() == "" || e.Rows[0].Cells[1].Value == null 
                || e.Rows[0].Cells[0].Value.ToString().Contains(this.concat_nomor_agenda.ToString()))
            {
                e.Rows[0].Cells[1].Value = "";
                this.idxStaticValue.RemoveAt(this.idxStaticValue.Count - 1);
                e.Cancel = true; 
                this.rowAdded = false;
                MessageBox.Show(this, "Inputan tidak boleh kosong/mengandung karakter concat.","Invalid value", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void DeleteStatic(int _idx)
        {
            this.agenda_variable.RemoveAt(_idx);
        }

        private void radGridView1_UserDeletingRow(object sender, GridViewRowCancelEventArgs e)
        {
            int idx = this.agenda_variable.IndexOf(e.Rows[0].Cells[0].Value.ToString());
            DeleteStatic(idx);
            GenerateIDX();
            ChangeIndex();
        }

        private void ddConcat_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (ddConcat.SelectedIndex == 0)
                this.concat_nomor_agenda = '/';
            else if (ddConcat.SelectedIndex == 1)
                this.concat_nomor_agenda = '-';
            else if (ddConcat.SelectedIndex == 2)
                this.concat_nomor_agenda = '.';
            else
                this.concat_nomor_agenda = ' ';
            for (int i = 0; i < this.radGridView1.Rows.Count;i++ )
                this.radGridView1.MasterView.Rows[i].Cells[0].Value = this.radGridView1.Rows[i].Cells[0].Value.ToString().Replace(this.concat_nomor_agenda.ToString(),"");

            if (this.agenda_variable != null)
            {
                for (int i = 0; i < this.agenda_variable.Count; i++)
                    this.agenda_variable[i] = this.agenda_variable[i].Replace(this.concat_nomor_agenda.ToString(), "");
            }
            generateNomorAgenda();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            int index_id, index_day, index_kategori, index_month, index_tk_keamanan, index_year;
            string index_start;
            int.TryParse(ddIdxId.Text, out index_id);
            int.TryParse(ddIdxIncludeDay.Text, out index_day);
            int.TryParse(ddIdxKategori.Text, out index_kategori);
            int.TryParse(ddIdxIncludeMonth.Text, out index_month);
            int.TryParse(ddIdxTKKeamanan.Text, out index_tk_keamanan);
            int.TryParse(ddIdxIncludeYear.Text, out index_year);

            if (rdoFlat.IsChecked)
                index_start = rdoFlat.Text;
            else
                index_start = rdoMessage.Text;

            try
            {
                string str_surat="";
                if (rdoSuratMasuk.IsChecked)
                    str_surat = "surat_masuk";
                else
                    str_surat = "surat_keluar";
                AppDefaultSetting.UpdateSetting(this.concat_nomor_agenda, ddFormatDay.Text, ddFormatMonth.Text, ddFormatYear.Text, lblNomorAgenda.Text, chkIncludeDay.Checked, chkKategori.Checked, chkIncludeMonth.Checked,
                    chkTkKeamanan.Checked, chkIncludeYear.Checked, index_id, index_day, index_kategori, index_month, index_tk_keamanan, index_year, (int)nIDLen.Value,
                    ddReset.Text, chkReset.Checked, index_start, str_surat);
                MessageBox.Show(this, "Format:" + lblNomorAgenda.Text + " nomor agenda sudah digenerate.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radGridView1_Click(object sender, EventArgs e)
        {

        }

        private void rdoSuratMasuk_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if(rdoSuratMasuk.IsChecked)
                GenerateDataSuratMasuk();
        }

        private void rdoSuratKeluar_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if(rdoSuratKeluar.IsChecked)
                GenerateDataSuratKeluar();
        }
    }
}
