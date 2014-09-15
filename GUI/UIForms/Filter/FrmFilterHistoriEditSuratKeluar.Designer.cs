namespace GUI.UIForms.Filter
{
    partial class FrmFilterHistoriEditSuratKeluar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.WinControls.UI.RadListDataItem radListDataItem1 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem2 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem3 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem4 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem5 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem6 = new Telerik.WinControls.UI.RadListDataItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFilterHistoriEditSuratKeluar));
            this.chkKolom = new Telerik.WinControls.UI.RadCheckBox();
            this.ddKolom = new Telerik.WinControls.UI.RadDropDownList();
            this.chkNomorAgenda = new Telerik.WinControls.UI.RadCheckBox();
            this.txtUserInput = new Telerik.WinControls.UI.RadTextBox();
            this.chkUserInput = new Telerik.WinControls.UI.RadCheckBox();
            this.txtNomorAgenda = new Telerik.WinControls.UI.RadTextBox();
            this.radSeparator1 = new Telerik.WinControls.UI.RadSeparator();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.dtTglInput2 = new Telerik.WinControls.UI.RadDateTimePicker();
            this.chkTglInput = new Telerik.WinControls.UI.RadCheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtJamInput2 = new Telerik.WinControls.UI.RadDateTimePicker();
            this.chkJamInput = new Telerik.WinControls.UI.RadCheckBox();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.btnBatal = new Telerik.WinControls.UI.RadButton();
            this.dtJamInput1 = new Telerik.WinControls.UI.RadDateTimePicker();
            this.dtTglInput1 = new Telerik.WinControls.UI.RadDateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.chkKolom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddKolom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNomorAgenda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUserInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNomorAgenda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTglInput2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTglInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtJamInput2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkJamInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBatal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtJamInput1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTglInput1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // chkKolom
            // 
            this.chkKolom.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkKolom.Location = new System.Drawing.Point(4, 78);
            this.chkKolom.Name = "chkKolom";
            this.chkKolom.Size = new System.Drawing.Size(59, 21);
            this.chkKolom.TabIndex = 8;
            this.chkKolom.Text = "Kolom";
            this.chkKolom.ThemeName = "Windows8";
            this.chkKolom.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.cbPcName_ToggleStateChanged);
            // 
            // ddKolom
            // 
            this.ddKolom.Enabled = false;
            this.ddKolom.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radListDataItem1.Text = "lampiran";
            radListDataItem1.TextWrap = true;
            radListDataItem2.Text = "perihal";
            radListDataItem2.TextWrap = true;
            radListDataItem3.Text = "ringkasan_isi";
            radListDataItem3.TextWrap = true;
            radListDataItem4.Text = "tanggal_kirim";
            radListDataItem4.TextWrap = true;
            radListDataItem5.Text = "tingkat_keamanan";
            radListDataItem5.TextWrap = true;
            radListDataItem6.Text = "tujuan";
            radListDataItem6.TextWrap = true;
            this.ddKolom.Items.Add(radListDataItem1);
            this.ddKolom.Items.Add(radListDataItem2);
            this.ddKolom.Items.Add(radListDataItem3);
            this.ddKolom.Items.Add(radListDataItem4);
            this.ddKolom.Items.Add(radListDataItem5);
            this.ddKolom.Items.Add(radListDataItem6);
            this.ddKolom.Location = new System.Drawing.Point(131, 78);
            this.ddKolom.MaxLength = 45;
            this.ddKolom.Name = "ddKolom";
            this.ddKolom.Size = new System.Drawing.Size(282, 21);
            this.ddKolom.SortStyle = Telerik.WinControls.Enumerations.SortStyle.Ascending;
            this.ddKolom.TabIndex = 9;
            this.ddKolom.ThemeName = "Windows8";
            // 
            // chkNomorAgenda
            // 
            this.chkNomorAgenda.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNomorAgenda.Location = new System.Drawing.Point(5, 5);
            this.chkNomorAgenda.Name = "chkNomorAgenda";
            this.chkNomorAgenda.Size = new System.Drawing.Size(112, 21);
            this.chkNomorAgenda.TabIndex = 0;
            this.chkNomorAgenda.Text = "Nomor Agenda";
            this.chkNomorAgenda.ThemeName = "Windows8";
            this.chkNomorAgenda.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.chkNomorAgenda_ToggleStateChanged_1);
            // 
            // txtUserInput
            // 
            this.txtUserInput.Enabled = false;
            this.txtUserInput.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserInput.Location = new System.Drawing.Point(131, 102);
            this.txtUserInput.MaxLength = 45;
            this.txtUserInput.Name = "txtUserInput";
            this.txtUserInput.Padding = new System.Windows.Forms.Padding(2);
            this.txtUserInput.Size = new System.Drawing.Size(282, 22);
            this.txtUserInput.TabIndex = 11;
            this.txtUserInput.ThemeName = "Windows8";
            // 
            // chkUserInput
            // 
            this.chkUserInput.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUserInput.Location = new System.Drawing.Point(5, 103);
            this.chkUserInput.Name = "chkUserInput";
            this.chkUserInput.Size = new System.Drawing.Size(82, 21);
            this.chkUserInput.TabIndex = 10;
            this.chkUserInput.Text = "User Input";
            this.chkUserInput.ThemeName = "Windows8";
            this.chkUserInput.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.chkUserInput_ToggleStateChanged_1);
            // 
            // txtNomorAgenda
            // 
            this.txtNomorAgenda.Enabled = false;
            this.txtNomorAgenda.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomorAgenda.Location = new System.Drawing.Point(131, 5);
            this.txtNomorAgenda.MaxLength = 100;
            this.txtNomorAgenda.Modified = true;
            this.txtNomorAgenda.Name = "txtNomorAgenda";
            this.txtNomorAgenda.Padding = new System.Windows.Forms.Padding(2);
            this.txtNomorAgenda.Size = new System.Drawing.Size(282, 22);
            this.txtNomorAgenda.TabIndex = 1;
            this.txtNomorAgenda.ThemeName = "Windows8";
            // 
            // radSeparator1
            // 
            this.radSeparator1.Location = new System.Drawing.Point(-13, 130);
            this.radSeparator1.Name = "radSeparator1";
            this.radSeparator1.Size = new System.Drawing.Size(449, 2);
            this.radSeparator1.TabIndex = 236;
            this.radSeparator1.Text = "radSeparator1";
            this.radSeparator1.ThemeName = "Windows8";
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(259, 30);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(26, 21);
            this.radLabel1.TabIndex = 234;
            this.radLabel1.Text = "s/d";
            // 
            // dtTglInput2
            // 
            this.dtTglInput2.CustomFormat = "dd MMM yyyy";
            this.dtTglInput2.Enabled = false;
            this.dtTglInput2.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTglInput2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTglInput2.Location = new System.Drawing.Point(289, 30);
            this.dtTglInput2.Name = "dtTglInput2";
            this.dtTglInput2.Size = new System.Drawing.Size(124, 21);
            this.dtTglInput2.TabIndex = 4;
            this.dtTglInput2.TabStop = false;
            this.dtTglInput2.Text = "02 Apr 2014";
            this.dtTglInput2.ThemeName = "Windows8";
            this.dtTglInput2.Value = new System.DateTime(2014, 4, 2, 20, 26, 30, 407);
            // 
            // chkTglInput
            // 
            this.chkTglInput.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTglInput.Location = new System.Drawing.Point(5, 30);
            this.chkTglInput.Name = "chkTglInput";
            this.chkTglInput.Size = new System.Drawing.Size(103, 21);
            this.chkTglInput.TabIndex = 2;
            this.chkTglInput.Text = "Tanggal Input";
            this.chkTglInput.ThemeName = "Windows8";
            this.chkTglInput.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.cbTglLogin_ToggleStateChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(262, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 17);
            this.label1.TabIndex = 235;
            this.label1.Text = "to";
            // 
            // dtJamInput2
            // 
            this.dtJamInput2.CustomFormat = "HH:mm:ss";
            this.dtJamInput2.Enabled = false;
            this.dtJamInput2.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F);
            this.dtJamInput2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtJamInput2.Location = new System.Drawing.Point(289, 54);
            this.dtJamInput2.Name = "dtJamInput2";
            this.dtJamInput2.ShowUpDown = true;
            this.dtJamInput2.Size = new System.Drawing.Size(124, 21);
            this.dtJamInput2.TabIndex = 7;
            this.dtJamInput2.TabStop = false;
            this.dtJamInput2.Text = "21:51:11";
            this.dtJamInput2.ThemeName = "Windows8";
            this.dtJamInput2.Value = new System.DateTime(2014, 6, 14, 21, 51, 11, 357);
            // 
            // chkJamInput
            // 
            this.chkJamInput.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkJamInput.Location = new System.Drawing.Point(5, 54);
            this.chkJamInput.Name = "chkJamInput";
            this.chkJamInput.Size = new System.Drawing.Size(79, 21);
            this.chkJamInput.TabIndex = 5;
            this.chkJamInput.Text = "Jam Input";
            this.chkJamInput.ThemeName = "Windows8";
            this.chkJamInput.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.cbJamLogin_ToggleStateChanged_1);
            // 
            // radButton1
            // 
            this.radButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.radButton1.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButton1.Image = ((System.Drawing.Image)(resources.GetObject("radButton1.Image")));
            this.radButton1.Location = new System.Drawing.Point(129, 139);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(138, 30);
            this.radButton1.TabIndex = 12;
            this.radButton1.Text = "&Filter";
            this.radButton1.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.radButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.radButton1.TextWrap = true;
            this.radButton1.ThemeName = "Windows8";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // btnBatal
            // 
            this.btnBatal.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBatal.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBatal.Image = ((System.Drawing.Image)(resources.GetObject("btnBatal.Image")));
            this.btnBatal.Location = new System.Drawing.Point(275, 139);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(138, 30);
            this.btnBatal.TabIndex = 13;
            this.btnBatal.Text = "&Batal";
            this.btnBatal.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBatal.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnBatal.TextWrap = true;
            this.btnBatal.ThemeName = "Windows8";
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);
            // 
            // dtJamInput1
            // 
            this.dtJamInput1.CustomFormat = "HH:mm:ss";
            this.dtJamInput1.Enabled = false;
            this.dtJamInput1.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F);
            this.dtJamInput1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtJamInput1.Location = new System.Drawing.Point(131, 54);
            this.dtJamInput1.Name = "dtJamInput1";
            this.dtJamInput1.ShowUpDown = true;
            this.dtJamInput1.Size = new System.Drawing.Size(124, 21);
            this.dtJamInput1.TabIndex = 6;
            this.dtJamInput1.TabStop = false;
            this.dtJamInput1.Text = "21:51:11";
            this.dtJamInput1.ThemeName = "Windows8";
            this.dtJamInput1.Value = new System.DateTime(2014, 6, 14, 21, 51, 11, 357);
            // 
            // dtTglInput1
            // 
            this.dtTglInput1.CustomFormat = "dd MMM yyyy";
            this.dtTglInput1.Enabled = false;
            this.dtTglInput1.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTglInput1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTglInput1.Location = new System.Drawing.Point(131, 30);
            this.dtTglInput1.Name = "dtTglInput1";
            this.dtTglInput1.Size = new System.Drawing.Size(124, 21);
            this.dtTglInput1.TabIndex = 3;
            this.dtTglInput1.TabStop = false;
            this.dtTglInput1.Text = "02 Apr 2014";
            this.dtTglInput1.ThemeName = "Windows8";
            this.dtTglInput1.Value = new System.DateTime(2014, 4, 2, 20, 26, 30, 407);
            // 
            // FrmFilterHistoriEditSuratKeluar
            // 
            this.AcceptButton = this.radButton1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnBatal;
            this.ClientSize = new System.Drawing.Size(417, 173);
            this.Controls.Add(this.chkKolom);
            this.Controls.Add(this.ddKolom);
            this.Controls.Add(this.chkNomorAgenda);
            this.Controls.Add(this.txtUserInput);
            this.Controls.Add(this.chkUserInput);
            this.Controls.Add(this.txtNomorAgenda);
            this.Controls.Add(this.radSeparator1);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.dtTglInput2);
            this.Controls.Add(this.chkTglInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtJamInput2);
            this.Controls.Add(this.chkJamInput);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.btnBatal);
            this.Controls.Add(this.dtJamInput1);
            this.Controls.Add(this.dtTglInput1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "FrmFilterHistoriEditSuratKeluar";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filter Histori Edit Surat Keluar";
            this.ThemeName = "Windows8";
            this.Load += new System.EventHandler(this.FrmFilterHistoriEditSuratKeluar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chkKolom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddKolom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNomorAgenda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUserInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNomorAgenda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTglInput2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTglInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtJamInput2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkJamInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBatal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtJamInput1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTglInput1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadCheckBox chkKolom;
        //private Telerik.WinControls.Themes.Windows8Theme windows8Theme2;
        public Telerik.WinControls.UI.RadDropDownList ddKolom;
        private Telerik.WinControls.UI.RadCheckBox chkNomorAgenda;
        public Telerik.WinControls.UI.RadTextBox txtUserInput;
        private Telerik.WinControls.UI.RadCheckBox chkUserInput;
        public Telerik.WinControls.UI.RadTextBox txtNomorAgenda;
        private Telerik.WinControls.UI.RadSeparator radSeparator1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        public Telerik.WinControls.UI.RadDateTimePicker dtTglInput2;
        private Telerik.WinControls.UI.RadCheckBox chkTglInput;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadDateTimePicker dtJamInput2;
        private Telerik.WinControls.UI.RadCheckBox chkJamInput;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadButton btnBatal;
        private Telerik.WinControls.UI.RadDateTimePicker dtJamInput1;
        //private Telerik.WinControls.Themes.Windows8Theme windows8Theme1;
        public Telerik.WinControls.UI.RadDateTimePicker dtTglInput1;

    }
}
