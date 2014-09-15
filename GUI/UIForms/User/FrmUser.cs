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
    public partial class FrmUser : Telerik.WinControls.UI.RadForm
    {
        public delegate void addRowDelegate(GridViewDataRowInfo row);

        private delegate void frmLoadingDelegate(bool _val);

        private DataTable dt;
        private FrmLoading frmLoading;
        private int page, count_per_page;
        public string filter, temp_filter;
        private int count_no_limit;

        public FrmUser()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;

        }

        private void FrmPengguna_Load(object sender, EventArgs e)
        {
            lblUsername.Text = T8UserLoginInfo.Username; 
            GenerateHeader();
            InitUserMenu();
            this.page = 0;
            this.count_no_limit = 0;
            this.Hide();
            dropDownLimit.SelectedIndex = 0;
        }

        private void InitUserMenu()
        {

            if (GeneralSettings.OtomatisSimpanHistoriLocal)
            {
                radCheckBox1.Checked = LocalSettings.AutoSizeUser;
                radCheckBox2.Checked = LocalSettings.AdministratorTableUser;
                radCheckBox3.Checked = LocalSettings.ShowPasswordUser;
            }

            if (!T8UserLoginInfo.HakAkses.Contains("Administrator"))
                radCheckBox2.Dispose();
        }

        private void GenerateUserData()
        {
            dt = UserBusiness.ShowUserData(this.filter, this.page * this.count_per_page, this.count_per_page);

            Thread.Sleep(50);

            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                if (this.gvUser.InvokeRequired)
                {
                    this.gvUser.Invoke(new addRowDelegate(this.addRow), GetDataRow(dt, i));
                }
                else
                {
                    this.gvUser.Rows.Insert(0, GetDataRow(dt, i));
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

        private void closeFrmLoading(bool _val)
        {
            frmLoading.Close();
            if (this.dt.Rows.Count > 0)
                radLabel1.Text = SetPaging();
            else
                radLabel1.Text = "1/1";
        }

        private GridViewRowInfo GetDataRow(DataTable dt, int i)
        {
            GridViewDataRowInfo dataRowInfo = new GridViewDataRowInfo(this.gvUser.MasterView);
            dataRowInfo.Cells[0].Value = dt.Rows[i][0];
            dataRowInfo.Cells[1].Value = dt.Rows[i][1];
            dataRowInfo.Cells[2].Value = dt.Rows[i][2];
            dataRowInfo.Cells[3].Value = string.Format("{0:dd MMM yyyy}", dt.Rows[i][3]);
            dataRowInfo.Cells[4].Value = string.Format("{0:HH:mm:ss}", dt.Rows[i][3]);
            dataRowInfo.Cells[5].Value = string.Format("{0:dd MMM yyyy}", dt.Rows[i][4]);
            dataRowInfo.Cells[6].Value = string.Format("{0:HH:mm:ss}", dt.Rows[i][4]);
            dataRowInfo.Cells[7].Value = dt.Rows[i][5];
            dataRowInfo.Cells[8].Value = string.Format("{0:dd MMM yyyy}", dt.Rows[i][6]);
            dataRowInfo.Cells[9].Value = string.Format("{0:HH:mm:ss}", dt.Rows[i][6]);
            dataRowInfo.Cells[10].Value = dt.Rows[i][7];
            return dataRowInfo;
        }

        private void addRow(GridViewDataRowInfo row)
        {
            this.gvUser.Rows.Insert(0, row);
        }

        private void GenerateHeader()
        {
            GridColumn();
            GridStyle();
        }

        private void GridStyle()
        {
            gvUser.Columns[0].Width = 90;
            gvUser.Columns[0].WrapText = true;
            gvUser.Columns[1].Width = 90;
            gvUser.Columns[1].WrapText = true;
            gvUser.Columns[1].IsVisible = false;
            gvUser.Columns[2].Width = 330;
            gvUser.Columns[2].WrapText = true;
            gvUser.Columns[3].Width = 160;
            gvUser.Columns[3].WrapText = true;
            gvUser.Columns[4].Width = 130;
            gvUser.Columns[4].WrapText = true;
            gvUser.Columns[5].Width = 160;
            gvUser.Columns[5].WrapText = true;
            gvUser.Columns[6].Width = 130;
            gvUser.Columns[6].WrapText = true;
            gvUser.Columns[7].Width = 100;
            gvUser.Columns[7].WrapText = true;
            gvUser.Columns[8].Width = 100;
            gvUser.Columns[8].WrapText = true;
            gvUser.Columns[8].IsVisible = false;
            gvUser.Columns[9].Width = 80;
            gvUser.Columns[9].WrapText = true;
            gvUser.Columns[9].IsVisible = false;
            gvUser.Columns[10].Width = 120;
            gvUser.Columns[10].WrapText = true;
            gvUser.Columns[10].IsVisible = false;
        }

        private void GridColumn()
        {
            gvUser.Columns.Add("clmnUsername", "Username");
            gvUser.Columns.Add("clmnPassword", "Password");
            gvUser.Columns.Add("clmnHakAkses", "Hak Akses");
            gvUser.Columns.Add("clmnLastLogin", "Tanggal Terakhir Login");
            gvUser.Columns.Add("clmnJamTerakhirLogin", "Jam Terakhir Login");
            gvUser.Columns.Add("clmnLastLogout", "Tanggal Terakhir Logout");
            gvUser.Columns.Add("clmnJamTerakhirLogout", "Jam Terakhir Logout");
            gvUser.Columns.Add("clmnStatus", "Status");
            gvUser.Columns.Add("clmnTglInput", "Tanggal Input");
            gvUser.Columns.Add("clmnJamInput", "Jam Input");
            gvUser.Columns.Add("clmnUser", "User");

        }

        private void gvUser_ViewCellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            if (e.CellElement is GridHeaderCellElement)
            {
                Padding pad = new System.Windows.Forms.Padding(2);
                e.CellElement.Font = new Font("Segoe UI", (float)9, FontStyle.Bold);
                e.CellElement.Padding = pad;
                e.CellElement.TextAlignment = ContentAlignment.MiddleLeft;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (!FillPassword()) return;
            FrmTambahUser frmTambahUser = new FrmTambahUser(this);
            frmTambahUser.ShowDialog();
        }

        private bool ValidGrid()
        {
            if (gvUser.Rows.Count < 1) return false;
            else
                return true;
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

        public void InsertSingleData(FrmTambahUser _frmTambahUser)
        {
            GridViewDataRowInfo dataRowInfo = new GridViewDataRowInfo(this.gvUser.MasterView);
            dataRowInfo.Cells[0].Value = _frmTambahUser.txtUsername.Text;
            dataRowInfo.Cells[1].Value = T8GlobalFunc.MD5Encrypt(_frmTambahUser.txtPassword.Text);
            dataRowInfo.Cells[2].Value = _frmTambahUser.hakAksesUser;
            dataRowInfo.Cells[3].Value = null;
            dataRowInfo.Cells[4].Value = null;
            dataRowInfo.Cells[5].Value = _frmTambahUser.status;
            dataRowInfo.Cells[6].Value = string.Format("{0:dd MMM yyyy}", DateTime.Now);
            dataRowInfo.Cells[7].Value = string.Format("{0:HH:mm:ss}", DateTime.Now);
            dataRowInfo.Cells[8].Value = T8UserLoginInfo.Username;
            gvUser.Rows.Insert(0, dataRowInfo);
        }

        public void UpdateSingleData(FrmUbahHakAkses _frmUbahHakAkses, string _username)
        {
            for (int i = 0; i < gvUser.RowCount; i++)
            {
                if (_username == gvUser.MasterView.Rows[i].Cells[0].Value.ToString())
                {
                    gvUser.MasterView.Rows[i].Cells[2].Value = _frmUbahHakAkses.hakAksesUser.ToString();
                    break;
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (!ValidGrid()) return; 
            if (!FillPassword()) return;
            string username = gvUser.MasterView.Rows[gvUser.SelectedRows[0].Index].Cells[0].Value.ToString();
            if (username == T8UserLoginInfo.Username) return; 

            string _selectedUser = "", _hakAkses;
            _selectedUser = gvUser.MasterView.Rows[gvUser.SelectedRows[0].Index].Cells[0].Value.ToString();
            _hakAkses = gvUser.MasterView.Rows[gvUser.SelectedRows[0].Index].Cells[2].Value.ToString();
            if (_selectedUser != "")
            {
                FrmUbahHakAkses frmUbahHakAkses = new FrmUbahHakAkses(this, _selectedUser, _hakAkses);
                frmUbahHakAkses.ShowDialog();
                if (frmUbahHakAkses.is_update)
                    gvUser.MasterView.Rows[gvUser.SelectedRows[0].Index].Cells[2].Value = frmUbahHakAkses.hakAksesUser.ToString();
            }
        }

        private void gvUser_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            Padding pad = new System.Windows.Forms.Padding(3);
            e.CellElement.Padding = pad;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (!ValidGrid()) return;
            if (!FillPassword()) return;
            FrmHistoryLoginUser frmHistoryLoginUser =
                new FrmHistoryLoginUser(gvUser.MasterView.Rows[gvUser.SelectedRows[0].Index].Cells[0].Value.ToString());
            frmHistoryLoginUser.ShowDialog();
        }

        private void FrmPengguna_Shown(object sender, EventArgs e)
        {

        }

        private void BindingDataGrid()
        {

            gvUser.Rows.Clear();


            Thread.Sleep(50);

            Thread bindingData;
            bindingData = new Thread(GenerateUserData);
            bindingData.IsBackground = true;
            bindingData.Start();

            frmLoading = new FrmLoading();
            frmLoading.ShowDialog();

            //Thread.Sleep(200);
        }

        private void radCheckBox2_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            gvUser.Columns[8].IsVisible = radCheckBox2.Checked;
            gvUser.Columns[9].IsVisible = radCheckBox2.Checked;
            gvUser.Columns[10].IsVisible = radCheckBox2.Checked;
            //if (_var == "AutoSizeMain") AutoSizeMain = _val;
            //if (_var == "AdministratorTableMain") AdministratorTableMain = _val;
            //if (_var == "AutoSizeUser") AutoSizeUser = _val;
            //if (_var == "ShowPasswordUser") ShowPasswordUser = _val;
            //if (_var == "AdministratorTableUser") AdministratorTableUser = _val;
            //if (_var == "AutoSizeHistoryLoginUser") AutoSizeHistoryLoginUser = _val;
            //if (_var == "AdministratorTableHistoryLoginUser") AdministratorTableHistoryLoginUser = _val;
            //AdministratorViewer(chkAdministratorTable.Checked);

            if (GeneralSettings.OtomatisSimpanHistoriLocal)
            {
                LocalSettings.SetSettings("AdministratorTableUser", radCheckBox2.Checked);
            }
        }

        private void radCheckBox1_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            gvUser.AutoSizeRows = radCheckBox1.Checked;
            
            //if (_var == "AutoSizeMain") AutoSizeMain = _val;
            //if (_var == "AdministratorTableMain") AdministratorTableMain = _val;
            //if (_var == "AutoSizeUser") AutoSizeUser = _val;
            //if (_var == "ShowPasswordUser") ShowPasswordUser = _val;
            //if (_var == "AdministratorTableUser") AdministratorTableUser = _val;
            //if (_var == "AutoSizeHistoryLoginUser") AutoSizeHistoryLoginUser = _val;
            //if (_var == "AdministratorTableHistoryLoginUser") AdministratorTableHistoryLoginUser = _val;
            //AdministratorViewer(chkAdministratorTable.Checked);

            if (GeneralSettings.OtomatisSimpanHistoriLocal)
            {
                LocalSettings.SetSettings("AutoSizeUser", radCheckBox1.Checked);
            }
        }

        private void radDropDownList1_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            this.page = 0;
            int.TryParse(dropDownLimit.Text, out this.count_per_page);
            this.count_no_limit = UserQuery.CountNoLimit(this.filter);
            BindingDataGrid();
        }

        private void radButton4_Click(object sender, EventArgs e)
        {
            if (page == 0)
                return;
            page = 0;

            int.TryParse(dropDownLimit.Text, out this.count_per_page);
            this.count_no_limit = UserQuery.CountNoLimit(this.filter);
            BindingDataGrid();
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            if (page > 0)
                page--;
            else
                return;
            int.TryParse(dropDownLimit.Text, out this.count_per_page);
            this.count_no_limit = UserQuery.CountNoLimit(this.filter);

            BindingDataGrid();
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            int.TryParse(dropDownLimit.Text, out this.count_per_page);
            this.count_no_limit = UserQuery.CountNoLimit(this.filter);

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

        private void radButton1_Click(object sender, EventArgs e)
        {
            int.TryParse(dropDownLimit.Text, out this.count_per_page);
            this.count_no_limit = UserQuery.CountNoLimit(this.filter);

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

        private void radCheckBox3_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            gvUser.Columns[1].IsVisible = radCheckBox3.Checked;
            //if (_var == "AutoSizeMain") AutoSizeMain = _val;
            //if (_var == "AdministratorTableMain") AdministratorTableMain = _val;
            //if (_var == "AutoSizeUser") AutoSizeUser = _val;
            //if (_var == "ShowPasswordUser") ShowPasswordUser = _val;
            //if (_var == "AdministratorTableUser") AdministratorTableUser = _val;
            //if (_var == "AutoSizeHistoryLoginUser") AutoSizeHistoryLoginUser = _val;
            //if (_var == "AdministratorTableHistoryLoginUser") AdministratorTableHistoryLoginUser = _val;
            //AdministratorViewer(chkAdministratorTable.Checked);

            if (GeneralSettings.OtomatisSimpanHistoriLocal)
            {
                LocalSettings.SetSettings("ShowPasswordUser", radCheckBox3.Checked);
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (!ValidGrid()) return;
            if (!FillPassword()) return;
            string newStat;
            string username = gvUser.MasterView.Rows[gvUser.SelectedRows[0].Index].Cells[0].Value.ToString();
            string dataLama = gvUser.MasterView.Rows[gvUser.SelectedRows[0].Index].Cells[7].Value.ToString();

            if (username == T8UserLoginInfo.Username) return;

            if (gvUser.MasterView.Rows[gvUser.SelectedRows[0].Index].Cells[7].Value.ToString() == "Aktif")
                newStat = "Non Aktif";
            else
                newStat = "Aktif";
            if (MessageBox.Show(this, "Anda yakin akan mengubah status user " + username + " menjadi "
                + newStat + "?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No) return;
            else
            {
                UserBusiness.UbahStatus(username, newStat);
                UserBusiness.InsertHistoryEditUser(username, "status", dataLama, newStat, T8UserLoginInfo.Username);
                gvUser.MasterView.Rows[gvUser.SelectedRows[0].Index].Cells[7].Value = newStat;
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (!ValidGrid()) return;
            if (!FillPassword()) return;
            string username = gvUser.MasterView.Rows[gvUser.SelectedRows[0].Index].Cells[0].Value.ToString();

            if (username == T8UserLoginInfo.Username) return;

            if (MessageBox.Show(this, "Anda yakin akan menghapus data user?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                == System.Windows.Forms.DialogResult.No) return;
            gvUser.Rows.RemoveAt(gvUser.SelectedRows[0].Index);
            UserBusiness.HapusUser(gvUser.MasterView.Rows[gvUser.SelectedRows[0].Index].Cells[0].Value.ToString());
            MessageBox.Show(this, "Data user sudah dihapus.", "Data dihapus", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            radCheckBoxElement1.Checked = true;
            this.filter = "";
            Filter.FrmFilterUser frmFilterUser = new Filter.FrmFilterUser(this);
            frmFilterUser.ShowDialog();

            if (this.filter == "")
            {
                radCheckBoxElement1.Checked = false;
                return;
            }

            this.count_no_limit = UserQuery.CountNoLimit(this.filter);
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

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            this.count_no_limit = UserQuery.CountNoLimit(this.filter);
            RefreshData();
        }

        private void radCheckBoxElement1_Click(object sender, EventArgs e)
        {
            if (radCheckBoxElement1.Checked)
            {
                this.temp_filter = this.filter;
                this.filter = "";
            }
            else
            {
                this.filter = this.temp_filter;
                this.temp_filter = "";
            }


            this.count_no_limit = UserQuery.CountNoLimit(this.filter);
            RefreshData();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            GlobalFunction.ExportExcelProcess(this.gvUser);
        }
    }
}
