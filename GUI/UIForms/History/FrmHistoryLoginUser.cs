using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Business;
using Data;
using System.Threading;
using T8CoreEnginee;

namespace GUI.UIForms
{
    public partial class FrmHistoryLoginUser : Telerik.WinControls.UI.RadForm
    {
        public delegate void addRowDelegate(GridViewDataRowInfo row);

        private delegate void frmLoadingDelegate(bool _val);

        private DataTable dt;
        private FrmLoading frmLoading;
        private int page, count_per_page;
        public string filter, temp_filter;
        private int count_no_limit;

        private string username;
        public FrmHistoryLoginUser(string _username)
        {
            InitializeComponent();
            this.ShowInTaskbar = false;

            username = _username;
            this.filter = "where username='" + this.username + "' ";
            this.temp_filter = "where username='" + this.username + "' "; ;
        }

        private void FrmHistoryLogin_Load(object sender, EventArgs e)
        {
            lblUsername.Text = T8UserLoginInfo.Username;
            GridHeaderGenerate(); 
            //this.filter = "where username='" + this.username + "' ";
            if(GeneralSettings.OtomatisSimpanHistoriLocal)
            {
                radCheckBox1.Checked = LocalSettings.AutoSizeHistoryLoginUser;
                radCheckBox2.Checked = LocalSettings.AdministratorTableHistoryLoginUser;
            }
            this.page = 0;
            this.count_no_limit = 0;
            dropDownLimit.SelectedIndex = 0;
        }

        private void GridHeaderGenerate()
        {
            GridColumn();
            GridStyle();
        }

        private void GridStyle()
        {
            gvHistoryLoginUser.Columns[0].Width = 110;
            gvHistoryLoginUser.Columns[0].WrapText = true;
            gvHistoryLoginUser.Columns[0].IsVisible = false;
            gvHistoryLoginUser.Columns[1].Width = 80;
            gvHistoryLoginUser.Columns[1].WrapText = true;
            gvHistoryLoginUser.Columns[2].Width = 100;
            gvHistoryLoginUser.Columns[2].WrapText = true;
            gvHistoryLoginUser.Columns[3].Width = 80;
            gvHistoryLoginUser.Columns[3].WrapText = true;
            gvHistoryLoginUser.Columns[4].Width = 110;
            gvHistoryLoginUser.Columns[4].WrapText = true;
            gvHistoryLoginUser.Columns[5].Width = 80;
            gvHistoryLoginUser.Columns[5].WrapText = true;
            gvHistoryLoginUser.Columns[6].Width = 80;
            gvHistoryLoginUser.Columns[6].WrapText = true;
            gvHistoryLoginUser.Columns[7].Width = 130;
            gvHistoryLoginUser.Columns[7].WrapText = true;
        }

        private void GridColumn()
        {
            gvHistoryLoginUser.Columns.Clear();
            gvHistoryLoginUser.Columns.Add("clmnIdLogin", "GUID");
            gvHistoryLoginUser.Columns.Add("clmnUsername", "Username");
            gvHistoryLoginUser.Columns.Add("clmnTglLogin", "Tanggal Login");
            gvHistoryLoginUser.Columns.Add("clmnJamLogin", "Jam Login");
            gvHistoryLoginUser.Columns.Add("clmnNomorSurat", "Tanggal Logout");
            gvHistoryLoginUser.Columns.Add("clmnTanggalSurat", "Jam Logout");
            gvHistoryLoginUser.Columns.Add("clmnAsalSurat", "PC Name");
            gvHistoryLoginUser.Columns.Add("clmnPerihal", "IP Address");
        }

        private void gvHistoryLoginUser_ViewCellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            if (e.CellElement is GridHeaderCellElement)
            {
                Padding pad = new System.Windows.Forms.Padding(2);
                e.CellElement.Font = new Font("Segoe UI", (float)9, FontStyle.Bold);
                e.CellElement.Padding = pad;
                e.CellElement.TextAlignment = ContentAlignment.MiddleLeft;
            }
        }

        private void BindingDataGrid()
        {
            gvHistoryLoginUser.Rows.Clear();

            Thread bindingDataSurat;
            bindingDataSurat = new Thread(GenerateDataHistory);
            bindingDataSurat.IsBackground = true;
            bindingDataSurat.Start();

            frmLoading = new FrmLoading();
            frmLoading.ShowDialog();
        }

        private void GenerateDataHistory(object obj)
        {
            dt = UserBusiness.SelectHistoryLoginUser(this.filter, this.page* this.count_per_page, this.count_per_page);

            Thread.Sleep(50);

            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                if (this.gvHistoryLoginUser.InvokeRequired)
                {
                    this.gvHistoryLoginUser.Invoke(new addRowDelegate(this.addRow), GetDataRow(dt, i));
                }
                else
                {
                    this.gvHistoryLoginUser.Rows.Insert(0, GetDataRow(dt, i));
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

        private void closeFrmLoading(bool _val)
        {
            frmLoading.Close();
            if (this.dt.Rows.Count > 0)
                radLabel1.Text = SetPaging();
            else
                radLabel1.Text = "1/1";
        }

        private void addRow(GridViewDataRowInfo _row)
        {
            this.gvHistoryLoginUser.Rows.Insert(0, _row);
        }

        private GridViewRowInfo GetDataRow(DataTable dt, int i)
        {
            GridViewDataRowInfo dataRowInfo = new GridViewDataRowInfo(this.gvHistoryLoginUser.MasterView);
            dataRowInfo.Cells[0].Value = dt.Rows[i][0];
            dataRowInfo.Cells[1].Value = dt.Rows[i][1];
            dataRowInfo.Cells[2].Value = string.Format("{0:dd MMM yyyy}", dt.Rows[i][2]);
            dataRowInfo.Cells[3].Value = string.Format("{0:HH:mm:ss}", dt.Rows[i][2]);
            dataRowInfo.Cells[4].Value = string.Format("{0:dd MMM yyyy}", dt.Rows[i][3]);
            dataRowInfo.Cells[5].Value = string.Format("{0:HH:mm:ss}", dt.Rows[i][3]);
            dataRowInfo.Cells[6].Value = dt.Rows[i][4];
            dataRowInfo.Cells[7].Value = dt.Rows[i][5];
            return dataRowInfo;
        }

        private void gvHistoryLoginUser_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            Padding pad = new System.Windows.Forms.Padding(3);
            e.CellElement.Padding = pad;
        }

        private void radCheckBox2_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            gvHistoryLoginUser.Columns[0].IsVisible = radCheckBox2.Checked;

            if (GeneralSettings.OtomatisSimpanHistoriLocal)
            {
                LocalSettings.SetSettings("AdministratorTableHistoryLoginUser", radCheckBox2.Checked);
            }
        }

        private void radCheckBox1_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            gvHistoryLoginUser.AutoSizeRows = radCheckBox1.Checked;

            if (GeneralSettings.OtomatisSimpanHistoriLocal)
            {

                LocalSettings.SetSettings("AutoSizeHistoryLoginUser", radCheckBox1.Checked);
            }
        }

        private void radDropDownList1_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            this.page = 0;
            int.TryParse(dropDownLimit.Text, out this.count_per_page);
            this.count_no_limit = UserQuery.CountNoLimitHistoryLoginUser(this.filter);
            BindingDataGrid();
        }

        private void radButton4_Click(object sender, EventArgs e)
        {
            if (page == 0)
                return;
            page = 0;

            int.TryParse(dropDownLimit.Text, out this.count_per_page);
            this.count_no_limit = UserQuery.CountNoLimitHistoryLoginUser(this.filter);
            BindingDataGrid();       
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

        private void radButton1_Click(object sender, EventArgs e)
        {
            int.TryParse(dropDownLimit.Text, out this.count_per_page);

            this.count_no_limit = UserQuery.CountNoLimitHistoryLoginUser(this.filter);
            int pageCount;
            if (this.count_no_limit % this.count_per_page > 0)
                pageCount = ((this.count_no_limit / this.count_per_page) + 1);
            else
                pageCount = (this.count_no_limit / this.count_per_page);

            if (this.page + 1 < pageCount)
                page = pageCount - 1;
            else
                return;

            BindingDataGrid();
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            int.TryParse(dropDownLimit.Text, out this.count_per_page);

            this.count_no_limit = UserQuery.CountNoLimitHistoryLoginUser(this.filter);

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

        private void radButton3_Click(object sender, EventArgs e)
        {
            if (page > 0)
                page--;
            else
                return;
            int.TryParse(dropDownLimit.Text, out this.count_per_page);

            this.count_no_limit = UserQuery.CountNoLimitHistoryLoginUser(this.filter);
            BindingDataGrid();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            radCheckBoxElement1.Checked = true;
            this.filter = "where username='" + this.username + "' ";
            Filter.FrmFilterHistoriLogin frmFilterHistoryLogin = new Filter.FrmFilterHistoriLogin(this, this.username);
            frmFilterHistoryLogin.ShowDialog();

            if (this.filter == "where username='" + this.username + "' ")
            {
                radCheckBoxElement1.Checked = false;
                return;
            }
            this.count_no_limit = UserQuery.CountNoLimitHistoryLoginUser(this.filter);
            RefreshData();
        }

        private void RefreshData()
        {
            this.page = 0;
            if (dropDownLimit.SelectedIndex != 0)
                dropDownLimit.SelectedIndex = 0;
            else
                BindingDataGrid();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.count_no_limit = UserQuery.CountNoLimitHistoryLoginUser(this.filter);
            RefreshData();
        }

        private void radCheckBoxElement1_Click(object sender, EventArgs e)
        {
            if (radCheckBoxElement1.Checked)
            {
                this.temp_filter = this.filter;
                this.filter = "where username='" + this.username + "' ";
            }
            else
            {
                this.filter = this.temp_filter;
                this.temp_filter = "where username='" + this.username + "' ";
            }

            this.count_no_limit = UserQuery.CountNoLimitHistoryLoginUser(this.filter);
            RefreshData();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Anda yakin akan menghapus data histori?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
            UserBusiness.DeleteHistoryLoginUser(this.username, this.filter);
            RefreshData();
            MessageBox.Show(this, "Data histori sudah di hapus", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            GlobalFunction.ExportExcelProcess(this.gvHistoryLoginUser);
        }
    }
}
