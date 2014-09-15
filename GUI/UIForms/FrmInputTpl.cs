using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Data;
using Telerik.WinControls.UI;
using System.Threading;
using Business;

namespace GUI.UIForms
{
    public partial class FrmInputTpl : Telerik.WinControls.UI.RadForm
    {
        string filter;
        FrmLoading frmLoading;
        DataTable dt;
        public delegate void addRowDelegate(GridViewDataRowInfo row);
        private delegate void frmLoadingDelegate(bool _val);

        public enum Action
        {
            None,
            Edit,
            Tambah
        }
        public enum TemplateName
        {
            None,
            Kategori,
            Asal,
            Posisi,
            TkKeamanan,
            Lokasi,
            Pengiriman
        }

        public static TemplateName tplName = TemplateName.None;
        public static Action act = Action.None;
        FrmPengaturan frmPengaturan;
        public FrmInputTpl(FrmPengaturan _frmPengaturan)
        {
            InitializeComponent();
            this.frmPengaturan = _frmPengaturan;
        }

        private void radButton4_Click(object sender, EventArgs e)
        {
            if (valid())
            {
                MessageBox.Show(this, "Nama dan simbol tidak boleh kosong.", "Empty Value", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (tplName == TemplateName.Asal)
            {
                if (act == Action.Tambah)
                    InsertTemplate("asal_surat");
                else if (act == Action.Edit)
                    UpdateTemplateData("asal_surat");
            }
            else if (tplName == TemplateName.Kategori)
            {
                if (act == Action.Tambah)
                    InsertTemplate("kategori_surat");
                else if (act == Action.Edit)
                    UpdateTemplateData("kategori_surat");
            }
            else if (tplName == TemplateName.Posisi)
            {
                if (act == Action.Tambah)
                    InsertTemplate("posisi_surat");
                else if (act == Action.Edit)
                    UpdateTemplateData("posisi_surat");
            }
            else if(tplName == TemplateName.TkKeamanan)
            {
                if (act == Action.Tambah)
                    InsertTemplate("tingkat_keamanan");
                else if (act == Action.Edit)
                    UpdateTemplateData("tingkat_keamanan");
            }
            else if (tplName == TemplateName.Pengiriman)
            {
                if (act == Action.Tambah)
                    InsertTemplate("jenis_pengiriman");
                else if (act == Action.Edit)
                    UpdateTemplateData("jenis_pengiriman");
            }
            else if (tplName == TemplateName.Lokasi)
            {
                if (act == Action.Tambah)
                    InsertTemplate("lokasi_fisik");
                else if (act == Action.Edit)
                    UpdateTemplateData("lokasi_fisik");
            }
        }

        private void InsertSingleData(string _template, string _status)
        {
            GridViewDataRowInfo dataRowInfo = new GridViewDataRowInfo(this.gvTemplateKategori.MasterView);
            dataRowInfo.Cells[0].Value = txtNama.Text;
            dataRowInfo.Cells[1].Value = txtSimbol.Text;
            dataRowInfo.Cells[2].Value = txtKeterangan.Text;
            dataRowInfo.Cells[3].Value = _template;
            dataRowInfo.Cells[4].Value = _status;
            this.gvTemplateKategori.Rows.Insert(0, dataRowInfo);
        }

        private void InsertTemplate(string _template)
        {
            try
            {
                string status;

                if (rdoAktif.IsChecked)
                    status = "Aktif";
                else
                    status = "Non Aktif";

                TemplateQuery.InsertTemplateData(GlobalFunction.SqlCharChecker(txtNama.Text), GlobalFunction.SqlCharChecker(txtSimbol.Text),
                    GlobalFunction.SqlCharChecker(txtKeterangan.Text), _template, status);

                InsertSingleData(_template, status);

                if (act == Action.Tambah || act == Action.Edit)
                {
                    MessageBox.Show(this, "Data template sudah disimpan.", "Template disimpan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnTambah.Enabled = true;
                    btnUbah.Enabled = true;
                    btnHapus.Enabled = true;
                    gvTemplateKategori.Enabled = true;
                    ClearInput();
                }
            }
            catch(Exception ex)
            {
                if(ex.Message.Contains("PRIMARY"))
                {
                    MessageBox.Show(this, "Data sudah ada, mohon periksa kembali","Duplicate Data", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void UpdateTemplateData(string _template)
        {
            try
            {
                string status;

                if (rdoAktif.IsChecked)
                    status = "Aktif";
                else
                    status = "Non Aktif";

                TemplateQuery.UpdatetTemplateData(GlobalFunction.SqlCharChecker(txtNama.Text), GlobalFunction.SqlCharChecker(txtSimbol.Text),
                    GlobalFunction.SqlCharChecker(txtKeterangan.Text), _template, status);

                UpdateSingleData(gvTemplateKategori.SelectedRows[0].Index, _template, status);


                if (act == Action.Tambah || act == Action.Edit)
                {
                    MessageBox.Show(this, "Data template sudah disimpan.", "Template disimpan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnTambah.Enabled = true;
                    btnUbah.Enabled = true;
                    btnHapus.Enabled = true;
                    gvTemplateKategori.Enabled = true;
                    ClearInput();
                }
            }
            catch(Exception ex)
            {
                if (ex.Message.Contains("PRIMARY"))
                {
                    MessageBox.Show(this, "Data sudah ada, mohon periksa kembali", "Duplicate Data", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void UpdateSingleData(int _index, string _template, string _status)
        {
            gvTemplateKategori.MasterView.Rows[_index].Cells[1].Value = txtSimbol.Text;
            gvTemplateKategori.MasterView.Rows[_index].Cells[2].Value = txtKeterangan.Text;
            gvTemplateKategori.MasterView.Rows[_index].Cells[4].Value = _status;
        }

        private bool valid()
        {
            return string.IsNullOrEmpty(txtNama.Text) || string.IsNullOrEmpty(txtSimbol.Text);
        }

        private void ClearInput()
        {
            txtKeterangan.Text = "";
            txtNama.Text = "";
            txtSimbol.Text = "";
            rdoAktif.IsChecked = false;
            txtNama.Enabled = true;
            rdoNonAktif.IsChecked = false; 
            groupBox1.Enabled = false;
        }

        private void FrmTplKategori_Load(object sender, EventArgs e)
        {
            GridHeaderGenerate();
            if (tplName == TemplateName.Asal)
            {
                if(act == Action.Tambah)
                    this.Text = "Tambah Template Asal Surat";
                else if(act == Action.Edit)
                    this.Text = "Edit Template Asal Surat";
                tbTemplate.SelectedPage = radPageViewPage1;
            }
            else if (tplName == TemplateName.Kategori)
            {
                if (act == Action.Tambah)
                    this.Text = "Tambah Template Kategori Surat";
                else if (act == Action.Edit)
                    this.Text = "Edit Template Kategori Surat";
                tbTemplate.SelectedPage = radPageViewPage2;
            }
            else if (tplName == TemplateName.Posisi)
            {
                if (act == Action.Tambah)
                    this.Text = "Tambah Template Posisi Surat";
                else if (act == Action.Edit)
                    this.Text = "Edit Template Posisi Surat";
                tbTemplate.SelectedPage = radPageViewPage3;
            }
            else if (tplName == TemplateName.TkKeamanan)
            {
                if (act == Action.Tambah)
                    this.Text = "Tambah Template Tk. Keamanan Surat";
                else if (act == Action.Edit)
                    this.Text = "Edit Template Tk. Keamanan Surat";
                tbTemplate.SelectedPage = radPageViewPage4;
            }
            else if (tplName == TemplateName.Lokasi)
            {
                if (act == Action.Tambah)
                    this.Text = "Tambah Template Lokasi Fisik Surat";
                else if (act == Action.Edit)
                    this.Text = "Edit Template Lokasi Fisik Surat";
                tbTemplate.SelectedPage = radPageViewPage5;
            }
            else if (tplName == TemplateName.Pengiriman)
            {
                if (act == Action.Tambah)
                    this.Text = "Tambah Template Jenis Pengiriman Surat";
                else if (act == Action.Edit)
                    this.Text = "Edit Template Jenis Pengiriman Surat";
                tbTemplate.SelectedPage = radPageViewPage6;
            }
            else
            { }
            BindingSelectedPage();
        }

        private void GridHeaderGenerate()
        {
            GridHeader();
            GridStyle();
        }

        private void GridStyle()
        {
            gvTemplateKategori.Columns[0].Width = 110;
            gvTemplateKategori.Columns[0].WrapText = true;
            gvTemplateKategori.Columns[1].Width = 60;
            gvTemplateKategori.Columns[1].WrapText = true;
            gvTemplateKategori.Columns[2].Width = 190;
            gvTemplateKategori.Columns[2].WrapText = true;
            gvTemplateKategori.Columns[3].Width = 110;
            gvTemplateKategori.Columns[3].WrapText = true;
            gvTemplateKategori.Columns[3].IsVisible = false;
            gvTemplateKategori.Columns[4].Width = 49;
            gvTemplateKategori.Columns[4].WrapText = true;
            gvTemplateKategori.AutoSizeRows = true;

            gvAsalSurat.Columns[0].Width = 110;
            gvAsalSurat.Columns[0].WrapText = true;
            gvAsalSurat.Columns[1].Width = 60;
            gvAsalSurat.Columns[1].WrapText = true;
            gvAsalSurat.Columns[2].Width = 190;
            gvAsalSurat.Columns[2].WrapText = true;
            gvAsalSurat.Columns[3].Width = 110;
            gvAsalSurat.Columns[3].WrapText = true;
            gvAsalSurat.Columns[3].IsVisible = false;
            gvAsalSurat.Columns[4].Width = 49;
            gvAsalSurat.Columns[4].WrapText = true;
            gvAsalSurat.AutoSizeRows = true;

            gvPenerima.Columns[0].Width = 110;
            gvPenerima.Columns[0].WrapText = true;
            gvPenerima.Columns[1].Width = 60;
            gvPenerima.Columns[1].WrapText = true;
            gvPenerima.Columns[2].Width = 190;
            gvPenerima.Columns[2].WrapText = true;
            gvPenerima.Columns[3].Width = 110;
            gvPenerima.Columns[3].WrapText = true;
            gvPenerima.Columns[3].IsVisible = false;
            gvPenerima.Columns[4].Width = 49;
            gvPenerima.Columns[4].WrapText = true;
            gvPenerima.AutoSizeRows = true;

            gvTkKeamanan.Columns[0].Width = 110;
            gvTkKeamanan.Columns[0].WrapText = true;
            gvTkKeamanan.Columns[1].Width = 60;
            gvTkKeamanan.Columns[1].WrapText = true;
            gvTkKeamanan.Columns[2].Width = 190;
            gvTkKeamanan.Columns[2].WrapText = true;
            gvTkKeamanan.Columns[3].Width = 110;
            gvTkKeamanan.Columns[3].WrapText = true;
            gvTkKeamanan.Columns[3].IsVisible = false;
            gvTkKeamanan.Columns[4].Width = 49;
            gvTkKeamanan.Columns[4].WrapText = true;
            gvTkKeamanan.AutoSizeRows = true;

            gvLokasi.Columns[0].Width = 110;
            gvLokasi.Columns[0].WrapText = true;
            gvLokasi.Columns[1].Width = 60;
            gvLokasi.Columns[1].WrapText = true;
            gvLokasi.Columns[2].Width = 190;
            gvLokasi.Columns[2].WrapText = true;
            gvLokasi.Columns[3].Width = 110;
            gvLokasi.Columns[3].WrapText = true;
            gvLokasi.Columns[3].IsVisible = false;
            gvLokasi.Columns[4].Width = 49;
            gvLokasi.Columns[4].WrapText = true;
            gvLokasi.AutoSizeRows = true;

            gvJenisPengiriman.Columns[0].Width = 110;
            gvJenisPengiriman.Columns[0].WrapText = true;
            gvJenisPengiriman.Columns[1].Width = 60;
            gvJenisPengiriman.Columns[1].WrapText = true;
            gvJenisPengiriman.Columns[2].Width = 190;
            gvJenisPengiriman.Columns[2].WrapText = true;
            gvJenisPengiriman.Columns[3].Width = 110;
            gvJenisPengiriman.Columns[3].WrapText = true;
            gvJenisPengiriman.Columns[3].IsVisible = false;
            gvJenisPengiriman.Columns[4].Width = 49;
            gvJenisPengiriman.Columns[4].WrapText = true;
            gvJenisPengiriman.AutoSizeRows = true;
        }

        private void GridHeader()
        {
            gvTemplateKategori.Columns.Add("clmnNama", "Nama");
            gvTemplateKategori.Columns.Add("clmnSimbol", "Simbol");
            gvTemplateKategori.Columns.Add("clmnKeterangan", "Keterangan");
            gvTemplateKategori.Columns.Add("clmnTemplate", "Template");
            gvTemplateKategori.Columns.Add("clmnStatus", "Status");

            gvAsalSurat.Columns.Add("clmnNama", "Nama");
            gvAsalSurat.Columns.Add("clmnSimbol", "Simbol");
            gvAsalSurat.Columns.Add("clmnKeterangan", "Keterangan");
            gvAsalSurat.Columns.Add("clmnTemplate", "Template");
            gvAsalSurat.Columns.Add("clmnStatus", "Status");

            gvPenerima.Columns.Add("clmnNama", "Nama");
            gvPenerima.Columns.Add("clmnSimbol", "Simbol");
            gvPenerima.Columns.Add("clmnKeterangan", "Keterangan");
            gvPenerima.Columns.Add("clmnTemplate", "Template");
            gvPenerima.Columns.Add("clmnStatus", "Status");

            gvTkKeamanan.Columns.Add("clmnNama", "Nama");
            gvTkKeamanan.Columns.Add("clmnSimbol", "Simbol");
            gvTkKeamanan.Columns.Add("clmnKeterangan", "Keterangan");
            gvTkKeamanan.Columns.Add("clmnTemplate", "Template");
            gvTkKeamanan.Columns.Add("clmnStatus", "Status");

            gvLokasi.Columns.Add("clmnNama", "Nama");
            gvLokasi.Columns.Add("clmnSimbol", "Simbol");
            gvLokasi.Columns.Add("clmnKeterangan", "Keterangan");
            gvLokasi.Columns.Add("clmnTemplate", "Template");
            gvLokasi.Columns.Add("clmnStatus", "Status");

            gvJenisPengiriman.Columns.Add("clmnNama", "Nama");
            gvJenisPengiriman.Columns.Add("clmnSimbol", "Simbol");
            gvJenisPengiriman.Columns.Add("clmnKeterangan", "Keterangan");
            gvJenisPengiriman.Columns.Add("clmnTemplate", "Template");
            gvJenisPengiriman.Columns.Add("clmnStatus", "Status");
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        private void radButton5_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        private void BindingDataGrid(string _template)
        {
            //gvTemplateKategori.Rows.Clear();

            Thread.Sleep(50);

            Thread bindingDataSurat;
            this.filter = _template;
            bindingDataSurat = new Thread(GenerateData);
            bindingDataSurat.IsBackground = true;
            bindingDataSurat.Start();

            frmLoading = new FrmLoading();
            frmLoading.ShowDialog();
        }

        private void GenerateData(object obj)
        {
            dt = SuratBusiness.SelectTemplate(this.filter);

            Thread.Sleep(50);

            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                if (tbTemplate.SelectedPage == radPageViewPage1)
                {
                    if (this.gvTemplateKategori.InvokeRequired)
                    {
                        this.gvTemplateKategori.Invoke(new addRowDelegate(this.addRow), GetDataRow(dt, i));
                    }
                    else
                    {
                        this.gvTemplateKategori.Rows.Insert(0, GetDataRow(dt, i));
                    }
                } 
                
                if (tbTemplate.SelectedPage == radPageViewPage2)
                {
                    if (this.gvAsalSurat.InvokeRequired)
                    {
                        this.gvAsalSurat.Invoke(new addRowDelegate(this.addRow), GetDataRow(dt, i));
                    }
                    else
                    {
                        this.gvAsalSurat.Rows.Insert(0, GetDataRow(dt, i));
                    }
                }

                if (tbTemplate.SelectedPage == radPageViewPage3)
                {
                    if (this.gvPenerima.InvokeRequired)
                    {
                        this.gvPenerima.Invoke(new addRowDelegate(this.addRow), GetDataRow(dt, i));
                    }
                    else
                    {
                        this.gvPenerima.Rows.Insert(0, GetDataRow(dt, i));
                    }
                }

                if (tbTemplate.SelectedPage == radPageViewPage4)
                {
                    if (this.gvTkKeamanan.InvokeRequired)
                    {
                        this.gvTkKeamanan.Invoke(new addRowDelegate(this.addRow), GetDataRow(dt, i));
                    }
                    else
                    {
                        this.gvTkKeamanan.Rows.Insert(0, GetDataRow(dt, i));
                    }
                }

                if (tbTemplate.SelectedPage == radPageViewPage5)
                {
                    if (this.gvLokasi.InvokeRequired)
                    {
                        this.gvLokasi.Invoke(new addRowDelegate(this.addRow), GetDataRow(dt, i));
                    }
                    else
                    {
                        this.gvLokasi.Rows.Insert(0, GetDataRow(dt, i));
                    }
                }

                if (tbTemplate.SelectedPage == radPageViewPage6)
                {
                    if (this.gvJenisPengiriman.InvokeRequired)
                    {
                        this.gvJenisPengiriman.Invoke(new addRowDelegate(this.addRow), GetDataRow(dt, i));
                    }
                    else
                    {
                        this.gvJenisPengiriman.Rows.Insert(0, GetDataRow(dt, i));
                    }
                }


                Thread.Sleep(50);
            }

            Thread.Sleep(50);

            if (frmLoading.InvokeRequired)
            {
                this.frmLoading.Invoke(new frmLoadingDelegate(this.closeFrmLoading), true);
            }
            else
            {
                closeFrmLoading(true);
            }
        }

        private GridViewDataRowInfo GetDataRow(DataTable dt, int i)
        {
            GridViewDataRowInfo dataRowInfo = null;
            if (tbTemplate.SelectedPage == radPageViewPage1)
            {
                dataRowInfo = new GridViewDataRowInfo(this.gvTemplateKategori.MasterView);
            }

            if (tbTemplate.SelectedPage == radPageViewPage2)
            {
                dataRowInfo = new GridViewDataRowInfo(this.gvAsalSurat.MasterView);
            }

            if (tbTemplate.SelectedPage == radPageViewPage3)
            {
                dataRowInfo = new GridViewDataRowInfo(this.gvPenerima.MasterView);
            }

            if (tbTemplate.SelectedPage == radPageViewPage4)
            {
                dataRowInfo = new GridViewDataRowInfo(this.gvTkKeamanan.MasterView);
            }

            if (tbTemplate.SelectedPage == radPageViewPage5)
            {
                dataRowInfo = new GridViewDataRowInfo(this.gvLokasi.MasterView);
            }

            if (tbTemplate.SelectedPage == radPageViewPage6)
            {
                dataRowInfo = new GridViewDataRowInfo(this.gvJenisPengiriman.MasterView);
            }
            dataRowInfo.Cells[0].Value = dt.Rows[i][0];
            dataRowInfo.Cells[1].Value = dt.Rows[i][1];
            dataRowInfo.Cells[2].Value = dt.Rows[i][2];
            dataRowInfo.Cells[3].Value = dt.Rows[i][3];
            dataRowInfo.Cells[4].Value = dt.Rows[i][4];
            return dataRowInfo;
        }

        private void closeFrmLoading(bool _val)
        {
            frmLoading.Close();
        }

        private void addRow(GridViewDataRowInfo row)
        {
            if (tbTemplate.SelectedPage == radPageViewPage1)
            {
                this.gvTemplateKategori.Rows.Insert(0, row); 
            }

            if (tbTemplate.SelectedPage == radPageViewPage2)
            {
                this.gvAsalSurat.Rows.Insert(0, row); 
            }

            if (tbTemplate.SelectedPage == radPageViewPage3)
            {
                this.gvPenerima.Rows.Insert(0, row); 
            }

            if (tbTemplate.SelectedPage == radPageViewPage4)
            {
                this.gvTkKeamanan.Rows.Insert(0, row); 
            }

            if (tbTemplate.SelectedPage == radPageViewPage5)
            {
                this.gvLokasi.Rows.Insert(0, row); 
            }

            if (tbTemplate.SelectedPage == radPageViewPage6)
            {
                this.gvJenisPengiriman.Rows.Insert(0, row); 
            }
        }

        private void gvTemplate_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            Padding pad = new System.Windows.Forms.Padding(3);
            e.CellElement.Padding = pad;
        }

        private void gvTemplate_ViewCellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement is GridHeaderCellElement)
            {
                Padding pad = new System.Windows.Forms.Padding(2);
                e.CellElement.Font = new Font("Segoe UI", (float)9, FontStyle.Bold);
                e.CellElement.Padding = pad;
                e.CellElement.TextAlignment = ContentAlignment.MiddleLeft;
            }
        }

        private void radButton1_Click_1(object sender, EventArgs e)
        {
            tbTemplate.Enabled = false;
            btnHapus.Enabled = false;
            btnUbah.Enabled = false;
            ClearInput();
            act = Action.Tambah;
            groupBox1.Enabled = true;
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNama.Text)) return;

            btnHapus.Enabled = false;
            btnTambah.Enabled = false;
            tbTemplate.Enabled = false;
            act = Action.Edit;
            groupBox1.Enabled = true;
            txtNama.Enabled = false;
        }

        private void radButton4_Click_1(object sender, EventArgs e)
        {
            ClearInput();
        }

        private void radButton6_Click(object sender, EventArgs e)
        {
            btnTambah.Enabled = true;
            btnUbah.Enabled = true;
            btnHapus.Enabled = true;
            tbTemplate.Enabled = true;
            ClearInput();
        }

        private void gvTemplate_Click(object sender, EventArgs e)
        {
            if (gvTemplateKategori.Rows.Count > 0)
            {
                string status;
                txtNama.Text = gvTemplateKategori.MasterView.Rows[gvTemplateKategori.SelectedRows[0].Index].Cells[0].Value.ToString();
                txtSimbol.Text = gvTemplateKategori.MasterView.Rows[gvTemplateKategori.SelectedRows[0].Index].Cells[1].Value.ToString();
                txtKeterangan.Text = gvTemplateKategori.MasterView.Rows[gvTemplateKategori.SelectedRows[0].Index].Cells[2].Value.ToString();

                status = gvTemplateKategori.MasterView.Rows[gvTemplateKategori.SelectedRows[0].Index].Cells[4].Value.ToString();

                if (status == "Aktif")
                    rdoAktif.IsChecked = true;
                else
                    rdoNonAktif.IsChecked = true;
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Anda yakin akan menghapus data template ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No) return;
            TemplateQuery.DeleteTemplateData(txtNama.Text);
            MessageBox.Show(this, "Data template sudah dihapus.", "Data dihapus", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        bool kategori = false, asal = false, penerima = false, tk_keamanan = false, lokasi = false, jenis_pengiriman = false;
        private void radPageView1_SelectedPageChanged(object sender, EventArgs e)
        {
            BindingSelectedPage();
        }

        private void BindingSelectedPage()
        {
            if (tbTemplate.SelectedPage == radPageViewPage1)
            {
                ClearInput();
                groupBox1.Text = "Tambah Data Kategori";
                this.Text = "Kategori Surat";

                tplName = TemplateName.Kategori;
                if (kategori == true) return;
                kategori = true;
                BindingDataGrid("kategori_surat");
            }

            if (tbTemplate.SelectedPage == radPageViewPage2)
            {
                ClearInput();
                groupBox1.Text = "Tambah Data Asal/Tujuan";
                this.Text = "Asal/Tujuan Surat";

                tplName = TemplateName.Kategori;
                if (asal == true) return;
                asal = true;
                BindingDataGrid("asal_surat");
            }

            if (tbTemplate.SelectedPage == radPageViewPage3)
            {
                ClearInput();
                groupBox1.Text = "Tambah Data Penerima";
                this.Text = "Penerima";

                tplName = TemplateName.Kategori;
                if (penerima == true) return;
                penerima = true;
                BindingDataGrid("posisi_surat");
            }

            if (tbTemplate.SelectedPage == radPageViewPage4)
            {
                ClearInput();
                groupBox1.Text = "Tambah Data Tingkat Keamanan";
                this.Text = "Tingkat Keamanan";

                tplName = TemplateName.Kategori;
                if (tk_keamanan == true) return;
                tk_keamanan = true;
                BindingDataGrid("tingkat_keamanan");
            }

            if (tbTemplate.SelectedPage == radPageViewPage5)
            {
                ClearInput();
                groupBox1.Text = "Tambah Data Lokasi Fisik";
                this.Text = "Lokasi Fisik";

                tplName = TemplateName.Kategori;
                if (lokasi == true) return;
                lokasi = true;
                BindingDataGrid("lokasi_fisik");
            }

            if (tbTemplate.SelectedPage == radPageViewPage6)
            {
                ClearInput();
                groupBox1.Text = "Tambah Data Jenis Pengiriman";
                this.Text = "Jenis Pengiriman";

                tplName = TemplateName.Kategori;
                if (jenis_pengiriman == true) return;
                jenis_pengiriman = true;
                BindingDataGrid("jenis_pengiriman");
            }
        }

        private void gvAsalSurat_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            Padding pad = new System.Windows.Forms.Padding(3);
            e.CellElement.Padding = pad;
        }

        private void gvPenerima_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            Padding pad = new System.Windows.Forms.Padding(3);
            e.CellElement.Padding = pad;
        }

        private void gvTkKeamanan_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            Padding pad = new System.Windows.Forms.Padding(3);
            e.CellElement.Padding = pad;
        }

        private void gvLokasi_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            Padding pad = new System.Windows.Forms.Padding(3);
            e.CellElement.Padding = pad;
        }

        private void gvJenisPengiriman_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            Padding pad = new System.Windows.Forms.Padding(3);
            e.CellElement.Padding = pad;
        }

        private void gvAsalSurat_Click(object sender, EventArgs e)
        {
            if (gvAsalSurat.Rows.Count > 0)
            {
                string status;
                txtNama.Text = gvAsalSurat.MasterView.Rows[gvAsalSurat.SelectedRows[0].Index].Cells[0].Value.ToString();
                txtSimbol.Text = gvAsalSurat.MasterView.Rows[gvAsalSurat.SelectedRows[0].Index].Cells[1].Value.ToString();
                txtKeterangan.Text = gvAsalSurat.MasterView.Rows[gvAsalSurat.SelectedRows[0].Index].Cells[2].Value.ToString();

                status = gvAsalSurat.MasterView.Rows[gvAsalSurat.SelectedRows[0].Index].Cells[4].Value.ToString();

                if (status == "Aktif")
                    rdoAktif.IsChecked = true;
                else
                    rdoNonAktif.IsChecked = true;
            }
        }

        private void gvPenerima_Click(object sender, EventArgs e)
        {
            if (gvPenerima.Rows.Count > 0)
            {
                string status;
                txtNama.Text = gvPenerima.MasterView.Rows[gvPenerima.SelectedRows[0].Index].Cells[0].Value.ToString();
                txtSimbol.Text = gvPenerima.MasterView.Rows[gvPenerima.SelectedRows[0].Index].Cells[1].Value.ToString();
                txtKeterangan.Text = gvPenerima.MasterView.Rows[gvPenerima.SelectedRows[0].Index].Cells[2].Value.ToString();

                status = gvPenerima.MasterView.Rows[gvPenerima.SelectedRows[0].Index].Cells[4].Value.ToString();

                if (status == "Aktif")
                    rdoAktif.IsChecked = true;
                else
                    rdoNonAktif.IsChecked = true;
            }
        }

        private void gvTkKeamanan_Click(object sender, EventArgs e)
        {
            if (gvTkKeamanan.Rows.Count > 0)
            {
                string status;
                txtNama.Text = gvTkKeamanan.MasterView.Rows[gvTkKeamanan.SelectedRows[0].Index].Cells[0].Value.ToString();
                txtSimbol.Text = gvTkKeamanan.MasterView.Rows[gvTkKeamanan.SelectedRows[0].Index].Cells[1].Value.ToString();
                txtKeterangan.Text = gvTkKeamanan.MasterView.Rows[gvTkKeamanan.SelectedRows[0].Index].Cells[2].Value.ToString();

                status = gvTkKeamanan.MasterView.Rows[gvTkKeamanan.SelectedRows[0].Index].Cells[4].Value.ToString();

                if (status == "Aktif")
                    rdoAktif.IsChecked = true;
                else
                    rdoNonAktif.IsChecked = true;
            }
        }

        private void gvLokasi_Click(object sender, EventArgs e)
        {
            if (gvLokasi.Rows.Count > 0)
            {
                string status;
                txtNama.Text = gvLokasi.MasterView.Rows[gvLokasi.SelectedRows[0].Index].Cells[0].Value.ToString();
                txtSimbol.Text = gvLokasi.MasterView.Rows[gvLokasi.SelectedRows[0].Index].Cells[1].Value.ToString();
                txtKeterangan.Text = gvLokasi.MasterView.Rows[gvLokasi.SelectedRows[0].Index].Cells[2].Value.ToString();

                status = gvLokasi.MasterView.Rows[gvLokasi.SelectedRows[0].Index].Cells[4].Value.ToString();

                if (status == "Aktif")
                    rdoAktif.IsChecked = true;
                else
                    rdoNonAktif.IsChecked = true;
            }
        }

        private void gvJenisPengiriman_Click(object sender, EventArgs e)
        {
            if (gvJenisPengiriman.Rows.Count > 0)
            {
                string status;
                txtNama.Text = gvJenisPengiriman.MasterView.Rows[gvJenisPengiriman.SelectedRows[0].Index].Cells[0].Value.ToString();
                txtSimbol.Text = gvJenisPengiriman.MasterView.Rows[gvJenisPengiriman.SelectedRows[0].Index].Cells[1].Value.ToString();
                txtKeterangan.Text = gvJenisPengiriman.MasterView.Rows[gvJenisPengiriman.SelectedRows[0].Index].Cells[2].Value.ToString();

                status = gvJenisPengiriman.MasterView.Rows[gvJenisPengiriman.SelectedRows[0].Index].Cells[4].Value.ToString();

                if (status == "Aktif")
                    rdoAktif.IsChecked = true;
                else
                    rdoNonAktif.IsChecked = true;
            }
        }

        private void gvAsalSurat_ViewCellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement is GridHeaderCellElement)
            {
                Padding pad = new System.Windows.Forms.Padding(2);
                e.CellElement.Font = new Font("Segoe UI", (float)9, FontStyle.Bold);
                e.CellElement.Padding = pad;
                e.CellElement.TextAlignment = ContentAlignment.MiddleLeft;
            }
        }

        private void gvPenerima_ViewCellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement is GridHeaderCellElement)
            {
                Padding pad = new System.Windows.Forms.Padding(2);
                e.CellElement.Font = new Font("Segoe UI", (float)9, FontStyle.Bold);
                e.CellElement.Padding = pad;
                e.CellElement.TextAlignment = ContentAlignment.MiddleLeft;
            }
        }

        private void gvTkKeamanan_ViewCellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement is GridHeaderCellElement)
            {
                Padding pad = new System.Windows.Forms.Padding(2);
                e.CellElement.Font = new Font("Segoe UI", (float)9, FontStyle.Bold);
                e.CellElement.Padding = pad;
                e.CellElement.TextAlignment = ContentAlignment.MiddleLeft;
            }
        }

        private void gvLokasi_ViewCellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement is GridHeaderCellElement)
            {
                Padding pad = new System.Windows.Forms.Padding(2);
                e.CellElement.Font = new Font("Segoe UI", (float)9, FontStyle.Bold);
                e.CellElement.Padding = pad;
                e.CellElement.TextAlignment = ContentAlignment.MiddleLeft;
            }
        }

        private void gvJenisPengiriman_ViewCellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement is GridHeaderCellElement)
            {
                Padding pad = new System.Windows.Forms.Padding(2);
                e.CellElement.Font = new Font("Segoe UI", (float)9, FontStyle.Bold);
                e.CellElement.Padding = pad;
                e.CellElement.TextAlignment = ContentAlignment.MiddleLeft;
            }
        }
    }
}
