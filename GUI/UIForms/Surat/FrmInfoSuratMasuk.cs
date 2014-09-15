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
    public partial class FrmDetailSurat : Telerik.WinControls.UI.RadForm
    {
        GridViewDataRowInfo dr;
        FrmLoading frmLoading;
        DataTable dtDisposisi, dtPenyelesaian;
        string filter;
        public delegate void addRowDelegate(GridViewDataRowInfo row);
        private delegate void frmLoadingDelegate(bool _val);
        public FrmDetailSurat(GridViewDataRowInfo _dr)
        {
            InitializeComponent();
            dr = _dr;
        }

        private void FrmDetailSurat_Load(object sender, EventArgs e)
        {
            GridHeaderGenerateHistoryDisposisi();
            GridHeaderGenerateHistoryPenyelesaian();
            this.filter = "where nomor_agenda='" + (string)dr.Cells[0].Value + "'";
            lblNomorAgenda.Text = (string)dr.Cells[0].Value;
            lblTglMasuk.Text = (string)dr.Cells[3].Value;
            lblNomorSurat.Text = (string)dr.Cells[5].Value;
            lblTglSurat.Text = (string)dr.Cells[6].Value;
            lblAsalSurat.Text = (string)dr.Cells[7].Value;
            lblPerihal.Text = (string)dr.Cells[8].Value;
            lblTkKeamanan.Text = (string)dr.Cells[9].Value;
            lblRingkasanIsi.Text = (string)dr.Cells[10].Value;
            lblLampiran.Text = (string)dr.Cells[11].Value;
            lblPosisi.Text = SuratQuery.GetPosisiSurat((string)dr.Cells[0].Value);

            BindingInfo();

            lblPenyelesaian.Text = SuratQuery.GetPenyelesaianAkhirSurat((string)dr.Cells[0].Value);
            string str = SuratQuery.GetSuratRefensiSuratMasuk(this.lblNomorAgenda.Text);
            if (str != "")
                lblReferensiSurat.Text = str;
            else
            {
                lblReferensiSurat.Text = "{surat tidak memiliki referensi}";
                lblReferensiSurat.Font = new Font("MS Reference Sans Serif", (float)9.75, FontStyle.Italic);
            }
            BindingDataGrid();
        }

        private void BindingInfo()
        {
            BindingLokasi();

            BindingJenis();

        }

        public void BindingJenis()
        {
            DataTable dtJenisPengiriman = SuratBusiness.getJenisPengiriman(this.lblNomorAgenda.Text);

            if (dtJenisPengiriman.Rows.Count == 0)
            {
                lblJenisPengiriman.Text = "{data kosong}";
                lblJenisPengiriman.Font = new Font("MS Reference Sans Serif", (float)9.75, FontStyle.Italic);

                lblInfoPengiriman.Text = "{data kosong}";
                lblInfoPengiriman.Font = new Font("MS Reference Sans Serif", (float)9.75, FontStyle.Italic);
            }
            else
            {
                lblJenisPengiriman.Text = dtJenisPengiriman.Rows[0][0].ToString();
                lblJenisPengiriman.Font = new Font("MS Reference Sans Serif", (float)9.75, FontStyle.Regular);

                lblInfoPengiriman.Text = dtJenisPengiriman.Rows[0][1].ToString();
                lblInfoPengiriman.Font = new Font("MS Reference Sans Serif", (float)9.75, FontStyle.Regular);
            }
        }

        public void BindingLokasi()
        {
            DataTable dtLokasi = SuratBusiness.GetLokasi(this.lblNomorAgenda.Text);

            if (dtLokasi.Rows.Count == 0)
            {
                lblLokasi.Text = "{data kosong}";
                lblLokasi.Font = new Font("MS Reference Sans Serif", (float)9.75, FontStyle.Italic);

                lblInfoLokasi.Text = "{data kosong}";
                lblInfoLokasi.Font = new Font("MS Reference Sans Serif", (float)9.75, FontStyle.Italic);
            }
            else
            {
                lblLokasi.Text = dtLokasi.Rows[0][0].ToString();
                lblLokasi.Font = new Font("MS Reference Sans Serif", (float)9.75, FontStyle.Regular);

                lblInfoLokasi.Text = dtLokasi.Rows[0][1].ToString();
                lblInfoLokasi.Font = new Font("MS Reference Sans Serif", (float)9.75, FontStyle.Regular);
            }
        }

        private void GenerateDataHistory(object obj)
        {
            dtDisposisi = SuratBusiness.SelectHistoryDisposisi(this.filter);

            Thread.Sleep(50);

            for (int i = dtDisposisi.Rows.Count - 1; i >= 0; i--)
            {
                if (this.gvSejarahDisposisi.InvokeRequired)
                {
                    this.gvSejarahDisposisi.Invoke(new addRowDelegate(this.addRowDisposisi), GetDataRow(dtDisposisi, i));
                }
                else
                {
                    this.gvSejarahDisposisi.Rows.Insert(0, GetDataRow(dtDisposisi, i));
                }

                Thread.Sleep(50);
            }

            dtPenyelesaian = SuratBusiness.SelectHistoryPenyelesaian(this.filter);

            Thread.Sleep(50);

            for (int i = dtPenyelesaian.Rows.Count - 1; i >= 0; i--)
            {
                if (this.gvPenyelesaian.InvokeRequired)
                {
                    this.gvPenyelesaian.Invoke(new addRowDelegate(this.addRowPenyelesaian), GetDataRowPenyelesaian(dtPenyelesaian, i));
                }
                else
                {
                    this.gvPenyelesaian.Rows.Insert(0, GetDataRow(dtPenyelesaian, i));
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

        private GridViewDataRowInfo GetDataRowPenyelesaian(DataTable dt, int i)
        {
            GridViewDataRowInfo dataRowInfo = new GridViewDataRowInfo(this.gvPenyelesaian.MasterView);
            dataRowInfo.Cells[0].Value = dt.Rows[i][0];
            dataRowInfo.Cells[1].Value = dt.Rows[i][1];
            dataRowInfo.Cells[2].Value = string.Format("{0:dd MMM yyyy}", dt.Rows[i][2]);
            dataRowInfo.Cells[3].Value = string.Format("{0:HH:mm:ss}", dt.Rows[i][2]);
            dataRowInfo.Cells[4].Value = string.Format("{0:dd MMM yyyy}", dt.Rows[i][3]);
            dataRowInfo.Cells[5].Value = dt.Rows[i][4];
            dataRowInfo.Cells[6].Value = dt.Rows[i][5];
            dataRowInfo.Cells[7].Value = dt.Rows[i][6];
            return dataRowInfo;
        }

        private GridViewDataRowInfo GetDataRow(DataTable dt, int i)
        {
            GridViewDataRowInfo dataRowInfo = new GridViewDataRowInfo(this.gvSejarahDisposisi.MasterView);
            dataRowInfo.Cells[0].Value = dt.Rows[i][0];
            dataRowInfo.Cells[1].Value = dt.Rows[i][1];
            dataRowInfo.Cells[2].Value = string.Format("{0:dd MMM yyyy}", dt.Rows[i][2]);
            dataRowInfo.Cells[3].Value = string.Format("{0:HH:mm:ss}", dt.Rows[i][2]);
            dataRowInfo.Cells[4].Value = string.Format("{0:dd MMM yyyy}", dt.Rows[i][3]);
            dataRowInfo.Cells[5].Value = dt.Rows[i][4];
            dataRowInfo.Cells[6].Value = dt.Rows[i][5];
            dataRowInfo.Cells[7].Value = dt.Rows[i][6];
            return dataRowInfo;
        }

        private void closeFrmLoading(bool _val)
        {
            frmLoading.Close();
        }

        private void addRowDisposisi(GridViewDataRowInfo row)
        {
            this.gvSejarahDisposisi.Rows.Insert(0, row);
        }

        private void addRowPenyelesaian(GridViewDataRowInfo row)
        {
            this.gvPenyelesaian.Rows.Insert(0, row);
        }

        private void BindingDataGrid()
        {
            gvSejarahDisposisi.Rows.Clear();

            Thread bindingDataSurat;
            bindingDataSurat = new Thread(GenerateDataHistory);
            bindingDataSurat.IsBackground = true;
            bindingDataSurat.Start();

            frmLoading = new FrmLoading();
            frmLoading.ShowDialog();
        }

        private void GridHeaderGenerateHistoryDisposisi()
        {
            ColumnSejarahDisposisi();
            ColumnSejarahDisposisiStyle();
        }
        private void ColumnSejarahDisposisiStyle()
        {
            gvSejarahDisposisi.Columns[0].Width = 40;
            gvSejarahDisposisi.Columns[0].IsVisible = false;
            gvSejarahDisposisi.Columns[0].WrapText = true;
            gvSejarahDisposisi.Columns[0].Width = 50;
            gvSejarahDisposisi.Columns[1].Width = 120;
            gvSejarahDisposisi.Columns[1].IsVisible = false;
            gvSejarahDisposisi.Columns[1].WrapText = true;
            gvSejarahDisposisi.Columns[2].Width = 100;
            gvSejarahDisposisi.Columns[2].IsVisible = false;
            gvSejarahDisposisi.Columns[2].WrapText = true;
            gvSejarahDisposisi.Columns[3].Width = 90;
            gvSejarahDisposisi.Columns[3].IsVisible = false;
            gvSejarahDisposisi.Columns[3].IsVisible = false;
            gvSejarahDisposisi.Columns[3].WrapText = true;
            gvSejarahDisposisi.Columns[4].Width = 90;
            gvSejarahDisposisi.Columns[4].WrapText = true;
            gvSejarahDisposisi.Columns[5].Width = 100;
            gvSejarahDisposisi.Columns[5].WrapText = true;
            gvSejarahDisposisi.Columns[6].Width = 240;
            gvSejarahDisposisi.Columns[6].WrapText = true;
            gvSejarahDisposisi.Columns[7].Width = 100;
            gvSejarahDisposisi.Columns[7].IsVisible = false;
            gvSejarahDisposisi.Columns[7].WrapText = true;
            gvSejarahDisposisi.AutoSizeRows = true;
        }

        private void GridHeaderGenerateHistoryPenyelesaian()
        {
            ColumnSejarahPenyelesaian();
            ColumnSejarahPenyelesaianStyle();
        }
        private void ColumnSejarahPenyelesaianStyle()
        {
            gvPenyelesaian.Columns[0].Width = 40;
            gvPenyelesaian.Columns[0].IsVisible = false;
            gvPenyelesaian.Columns[0].WrapText = true;
            gvPenyelesaian.Columns[0].Width = 50;
            gvPenyelesaian.Columns[1].Width = 120;
            gvPenyelesaian.Columns[1].IsVisible = false;
            gvPenyelesaian.Columns[1].WrapText = true;
            gvPenyelesaian.Columns[2].Width = 100;
            gvPenyelesaian.Columns[2].IsVisible = false;
            gvPenyelesaian.Columns[2].WrapText = true;
            gvPenyelesaian.Columns[3].Width = 90;
            gvPenyelesaian.Columns[3].IsVisible = false;
            gvPenyelesaian.Columns[3].IsVisible = false;
            gvPenyelesaian.Columns[3].WrapText = true;
            gvPenyelesaian.Columns[4].Width = 90;
            gvPenyelesaian.Columns[4].WrapText = true;
            gvPenyelesaian.Columns[5].Width = 100;
            gvPenyelesaian.Columns[5].WrapText = true;
            gvPenyelesaian.Columns[6].Width = 240;
            gvPenyelesaian.Columns[6].WrapText = true;
            gvPenyelesaian.Columns[7].Width = 100;
            gvPenyelesaian.Columns[7].IsVisible = false;
            gvPenyelesaian.Columns[7].WrapText = true;
            gvPenyelesaian.AutoSizeRows = true;
        }

        private void ColumnSejarahDisposisi()
        {
            gvSejarahDisposisi.Columns.Add("clmnID", "ID");
            gvSejarahDisposisi.Columns.Add("clmnNomorAgenda", "Nomor Agenda");
            gvSejarahDisposisi.Columns.Add("clmnTanggalInput", "Tanggal Input");
            gvSejarahDisposisi.Columns.Add("clmnJamInput", "Jam Input");
            gvSejarahDisposisi.Columns.Add("clmnTanggalDisposisi", "Tanggal Disposisi");
            gvSejarahDisposisi.Columns.Add("clmnTujuanDisposisi", "Tujuan Disposisi");
            gvSejarahDisposisi.Columns.Add("clmnKeterangan", "Isi Disposisi");
            gvSejarahDisposisi.Columns.Add("clmnAdmin", "User");
        }

        private void ColumnSejarahPenyelesaian()
        {
            gvPenyelesaian.Columns.Add("clmnID", "ID");
            gvPenyelesaian.Columns.Add("clmnNomorAgenda", "Nomor Agenda");
            gvPenyelesaian.Columns.Add("clmnTanggalInput", "Tanggal Input");
            gvPenyelesaian.Columns.Add("clmnJamInput", "Jam Input");
            gvPenyelesaian.Columns.Add("clmnTanggalDisposisi", "Tanggal Penyelesaian");
            gvPenyelesaian.Columns.Add("clmnTujuanDisposisi", "Penyelesaian Oleh");
            gvPenyelesaian.Columns.Add("clmnKeterangan", "Penyelesaian");
            gvPenyelesaian.Columns.Add("clmnAdmin", "User");
        }


        private void gvSejarahDisposisi_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            Padding pad = new System.Windows.Forms.Padding(3);
            e.CellElement.Padding = pad;
        }

        private void gvSejarahDisposisi_ViewCellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement is GridHeaderCellElement)
            {
                Padding pad = new System.Windows.Forms.Padding(2);
                e.CellElement.Font = new Font("Segoe UI", (float)9, FontStyle.Bold);
                e.CellElement.Padding = pad;
                e.CellElement.TextAlignment = ContentAlignment.MiddleLeft;
            }
        }

        private void radButton3_Click(object sender, EventArgs e)
        {

        }

        private void radButton4_Click(object sender, EventArgs e)
        {
            Surat.frmInfoLokasiSurat frmInfoLokasi = new Surat.frmInfoLokasiSurat(this, lblNomorAgenda.Text);
            frmInfoLokasi.ShowInTaskbar = false;
            frmInfoLokasi.ShowDialog();
        }

        private void radButton5_Click(object sender, EventArgs e)
        {
            Surat.FrmInfoPengiriman frmInfoPengiriman = new Surat.FrmInfoPengiriman(this, lblNomorAgenda.Text);
            frmInfoPengiriman.ShowInTaskbar = false;
            frmInfoPengiriman.ShowDialog();
        }

        private void gvPenyelesaian_ViewCellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement is GridHeaderCellElement)
            {
                Padding pad = new System.Windows.Forms.Padding(2);
                e.CellElement.Font = new Font("Segoe UI", (float)9, FontStyle.Bold);
                e.CellElement.Padding = pad;
                e.CellElement.TextAlignment = ContentAlignment.MiddleLeft;
            }
        }

        private void gvPenyelesaian_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            Padding pad = new System.Windows.Forms.Padding(3);
            e.CellElement.Padding = pad;
        }

        private void radPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radButton1_Click(object sender, EventArgs e)
        {   
            string act;
            if (lblReferensiSurat.Text == "{surat tidak memiliki referensi}")
                act = "new";
            else
                act = "ubah";
            Surat.FrmInputReferensiSurat frmReferensi = new Surat.FrmInputReferensiSurat(this, act, lblNomorAgenda.Text);
            frmReferensi.ShowInTaskbar = false;
            frmReferensi.ShowDialog();
        }
    }
}
