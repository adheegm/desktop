namespace GUI.UIForms
{
    partial class FrmEditSuratMasuk
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditSuratMasuk));
            this.txtAsalSurat = new Telerik.WinControls.UI.RadTextBox();
            this.btnSimpan = new Telerik.WinControls.UI.RadButton();
            this.btnBatal = new Telerik.WinControls.UI.RadButton();
            this.btnBersihkan = new Telerik.WinControls.UI.RadButton();
            this.radSeparator2 = new Telerik.WinControls.UI.RadSeparator();
            this.txtPerihalSurat = new Telerik.WinControls.UI.RadTextBox();
            this.txtLampiran = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel11 = new Telerik.WinControls.UI.RadLabel();
            this.dropDownTingkatKeamanan = new Telerik.WinControls.UI.RadDropDownList();
            this.txtNomorSurat = new Telerik.WinControls.UI.RadTextBox();
            this.dtTanggalSurat = new Telerik.WinControls.UI.RadDateTimePicker();
            this.radLabel18 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel17 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel16 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel15 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel12 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel13 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.lblTanggalMasuk = new Telerik.WinControls.UI.RadLabel();
            this.txtRingkasanIsi = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.lblNomorAgenda = new Telerik.WinControls.UI.RadAutoCompleteBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtAsalSurat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSimpan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBatal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBersihkan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPerihalSurat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLampiran)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dropDownTingkatKeamanan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNomorSurat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTanggalSurat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTanggalMasuk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRingkasanIsi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNomorAgenda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAsalSurat
            // 
            this.txtAsalSurat.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAsalSurat.Location = new System.Drawing.Point(153, 135);
            this.txtAsalSurat.MaxLength = 45;
            this.txtAsalSurat.Name = "txtAsalSurat";
            this.txtAsalSurat.Padding = new System.Windows.Forms.Padding(4);
            this.txtAsalSurat.Size = new System.Drawing.Size(337, 26);
            this.txtAsalSurat.TabIndex = 4;
            this.txtAsalSurat.ThemeName = "Windows8";
            // 
            // btnSimpan
            // 
            this.btnSimpan.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSimpan.Image = ((System.Drawing.Image)(resources.GetObject("btnSimpan.Image")));
            this.btnSimpan.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSimpan.Location = new System.Drawing.Point(153, 368);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Padding = new System.Windows.Forms.Padding(3);
            this.btnSimpan.Size = new System.Drawing.Size(106, 33);
            this.btnSimpan.TabIndex = 9;
            this.btnSimpan.Text = "&Simpan";
            this.btnSimpan.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSimpan.ThemeName = "Windows8";
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnBatal
            // 
            this.btnBatal.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBatal.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBatal.Image = ((System.Drawing.Image)(resources.GetObject("btnBatal.Image")));
            this.btnBatal.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnBatal.Location = new System.Drawing.Point(383, 368);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Padding = new System.Windows.Forms.Padding(3);
            this.btnBatal.Size = new System.Drawing.Size(106, 33);
            this.btnBatal.TabIndex = 11;
            this.btnBatal.Text = "&Batal";
            this.btnBatal.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnBatal.ThemeName = "Windows8";
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);
            // 
            // btnBersihkan
            // 
            this.btnBersihkan.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBersihkan.Image = ((System.Drawing.Image)(resources.GetObject("btnBersihkan.Image")));
            this.btnBersihkan.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnBersihkan.Location = new System.Drawing.Point(268, 368);
            this.btnBersihkan.Name = "btnBersihkan";
            this.btnBersihkan.Padding = new System.Windows.Forms.Padding(3);
            this.btnBersihkan.Size = new System.Drawing.Size(106, 33);
            this.btnBersihkan.TabIndex = 10;
            this.btnBersihkan.Text = "&Bersihkan";
            this.btnBersihkan.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnBersihkan.ThemeName = "Windows8";
            this.btnBersihkan.Click += new System.EventHandler(this.btnBersihkan_Click);
            // 
            // radSeparator2
            // 
            this.radSeparator2.Location = new System.Drawing.Point(-9, 359);
            this.radSeparator2.Name = "radSeparator2";
            this.radSeparator2.Size = new System.Drawing.Size(524, 2);
            this.radSeparator2.TabIndex = 44;
            this.radSeparator2.Text = "radSeparator1";
            this.radSeparator2.ThemeName = "Windows8";
            // 
            // txtPerihalSurat
            // 
            this.txtPerihalSurat.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPerihalSurat.Location = new System.Drawing.Point(153, 167);
            this.txtPerihalSurat.MaxLength = 100;
            this.txtPerihalSurat.Modified = true;
            this.txtPerihalSurat.Name = "txtPerihalSurat";
            this.txtPerihalSurat.Padding = new System.Windows.Forms.Padding(4);
            this.txtPerihalSurat.Size = new System.Drawing.Size(337, 26);
            this.txtPerihalSurat.TabIndex = 5;
            this.txtPerihalSurat.ThemeName = "Windows8";
            // 
            // txtLampiran
            // 
            this.txtLampiran.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLampiran.Location = new System.Drawing.Point(153, 326);
            this.txtLampiran.MaxLength = 20;
            this.txtLampiran.Modified = true;
            this.txtLampiran.Name = "txtLampiran";
            this.txtLampiran.Padding = new System.Windows.Forms.Padding(4);
            this.txtLampiran.Size = new System.Drawing.Size(337, 26);
            this.txtLampiran.TabIndex = 8;
            this.txtLampiran.ThemeName = "Windows8";
            // 
            // radLabel11
            // 
            this.radLabel11.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel11.Location = new System.Drawing.Point(4, 328);
            this.radLabel11.Name = "radLabel11";
            this.radLabel11.Padding = new System.Windows.Forms.Padding(2);
            this.radLabel11.Size = new System.Drawing.Size(80, 23);
            this.radLabel11.TabIndex = 43;
            this.radLabel11.Text = "Lampiran:";
            this.radLabel11.ThemeName = "Windows8";
            // 
            // dropDownTingkatKeamanan
            // 
            this.dropDownTingkatKeamanan.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.dropDownTingkatKeamanan.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dropDownTingkatKeamanan.Location = new System.Drawing.Point(153, 198);
            this.dropDownTingkatKeamanan.MaxLength = 45;
            this.dropDownTingkatKeamanan.Name = "dropDownTingkatKeamanan";
            this.dropDownTingkatKeamanan.NullText = "Pilih tk keamanan...";
            this.dropDownTingkatKeamanan.Padding = new System.Windows.Forms.Padding(2);
            this.dropDownTingkatKeamanan.Size = new System.Drawing.Size(337, 25);
            this.dropDownTingkatKeamanan.TabIndex = 6;
            this.dropDownTingkatKeamanan.ThemeName = "Windows8";
            // 
            // txtNomorSurat
            // 
            this.txtNomorSurat.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomorSurat.Location = new System.Drawing.Point(153, 71);
            this.txtNomorSurat.MaxLength = 100;
            this.txtNomorSurat.Name = "txtNomorSurat";
            this.txtNomorSurat.Padding = new System.Windows.Forms.Padding(4);
            this.txtNomorSurat.Size = new System.Drawing.Size(337, 26);
            this.txtNomorSurat.TabIndex = 2;
            this.txtNomorSurat.ThemeName = "Windows8";
            // 
            // dtTanggalSurat
            // 
            this.dtTanggalSurat.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTanggalSurat.Location = new System.Drawing.Point(153, 103);
            this.dtTanggalSurat.Name = "dtTanggalSurat";
            this.dtTanggalSurat.Padding = new System.Windows.Forms.Padding(2);
            this.dtTanggalSurat.Size = new System.Drawing.Size(337, 25);
            this.dtTanggalSurat.TabIndex = 3;
            this.dtTanggalSurat.TabStop = false;
            this.dtTanggalSurat.Text = "Wednesday, April 2, 2014";
            this.dtTanggalSurat.ThemeName = "Windows8";
            this.dtTanggalSurat.Value = new System.DateTime(2014, 4, 2, 20, 26, 30, 407);
            // 
            // radLabel18
            // 
            this.radLabel18.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel18.Location = new System.Drawing.Point(4, 169);
            this.radLabel18.Name = "radLabel18";
            this.radLabel18.Padding = new System.Windows.Forms.Padding(2);
            this.radLabel18.Size = new System.Drawing.Size(104, 23);
            this.radLabel18.TabIndex = 33;
            this.radLabel18.Text = "Perihal Surat:";
            this.radLabel18.ThemeName = "Windows8";
            // 
            // radLabel17
            // 
            this.radLabel17.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel17.Location = new System.Drawing.Point(4, 199);
            this.radLabel17.Name = "radLabel17";
            this.radLabel17.Padding = new System.Windows.Forms.Padding(2);
            this.radLabel17.Size = new System.Drawing.Size(115, 23);
            this.radLabel17.TabIndex = 32;
            this.radLabel17.Text = "TK. Keamanan:";
            this.radLabel17.ThemeName = "Windows8";
            // 
            // radLabel16
            // 
            this.radLabel16.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel16.Location = new System.Drawing.Point(4, 73);
            this.radLabel16.Name = "radLabel16";
            this.radLabel16.Padding = new System.Windows.Forms.Padding(2);
            this.radLabel16.Size = new System.Drawing.Size(103, 23);
            this.radLabel16.TabIndex = 29;
            this.radLabel16.Text = "Nomor Surat:";
            this.radLabel16.ThemeName = "Windows8";
            // 
            // radLabel15
            // 
            this.radLabel15.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel15.Location = new System.Drawing.Point(4, 137);
            this.radLabel15.Name = "radLabel15";
            this.radLabel15.Padding = new System.Windows.Forms.Padding(2);
            this.radLabel15.Size = new System.Drawing.Size(86, 23);
            this.radLabel15.TabIndex = 27;
            this.radLabel15.Text = "Asal Surat:";
            this.radLabel15.ThemeName = "Windows8";
            // 
            // radLabel12
            // 
            this.radLabel12.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel12.Location = new System.Drawing.Point(4, 7);
            this.radLabel12.Name = "radLabel12";
            this.radLabel12.Padding = new System.Windows.Forms.Padding(2);
            this.radLabel12.Size = new System.Drawing.Size(117, 23);
            this.radLabel12.TabIndex = 21;
            this.radLabel12.Text = "Nomor Agenda:";
            this.radLabel12.ThemeName = "Windows8";
            // 
            // radLabel13
            // 
            this.radLabel13.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel13.Location = new System.Drawing.Point(4, 40);
            this.radLabel13.Name = "radLabel13";
            this.radLabel13.Padding = new System.Windows.Forms.Padding(2);
            this.radLabel13.Size = new System.Drawing.Size(117, 23);
            this.radLabel13.TabIndex = 24;
            this.radLabel13.Text = "Tanggal Masuk:";
            this.radLabel13.ThemeName = "Windows8";
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(4, 104);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Padding = new System.Windows.Forms.Padding(2);
            this.radLabel3.Size = new System.Drawing.Size(111, 23);
            this.radLabel3.TabIndex = 25;
            this.radLabel3.Text = "Tanggal Surat:";
            this.radLabel3.ThemeName = "Windows8";
            // 
            // lblTanggalMasuk
            // 
            this.lblTanggalMasuk.AutoSize = false;
            this.lblTanggalMasuk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblTanggalMasuk.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTanggalMasuk.Location = new System.Drawing.Point(153, 38);
            this.lblTanggalMasuk.Name = "lblTanggalMasuk";
            this.lblTanggalMasuk.Padding = new System.Windows.Forms.Padding(3);
            this.lblTanggalMasuk.Size = new System.Drawing.Size(337, 27);
            this.lblTanggalMasuk.TabIndex = 1;
            this.lblTanggalMasuk.Text = "nomor agenda";
            this.lblTanggalMasuk.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTanggalMasuk.ThemeName = "Windows8";
            // 
            // txtRingkasanIsi
            // 
            this.txtRingkasanIsi.AutoSize = false;
            this.txtRingkasanIsi.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRingkasanIsi.Location = new System.Drawing.Point(153, 229);
            this.txtRingkasanIsi.MaxLength = 255;
            this.txtRingkasanIsi.Modified = true;
            this.txtRingkasanIsi.Multiline = true;
            this.txtRingkasanIsi.Name = "txtRingkasanIsi";
            this.txtRingkasanIsi.Padding = new System.Windows.Forms.Padding(4);
            this.txtRingkasanIsi.Size = new System.Drawing.Size(337, 91);
            this.txtRingkasanIsi.TabIndex = 7;
            this.txtRingkasanIsi.ThemeName = "Windows8";
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(4, 229);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Padding = new System.Windows.Forms.Padding(2);
            this.radLabel2.Size = new System.Drawing.Size(107, 23);
            this.radLabel2.TabIndex = 94;
            this.radLabel2.Text = "Ringkasan Isi:";
            this.radLabel2.ThemeName = "Windows8";
            // 
            // lblNomorAgenda
            // 
            this.lblNomorAgenda.Delimiter = '\0';
            this.lblNomorAgenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomorAgenda.Location = new System.Drawing.Point(153, 5);
            this.lblNomorAgenda.MaxLength = 100;
            this.lblNomorAgenda.Name = "lblNomorAgenda";
            this.lblNomorAgenda.SelectionOpacity = 50;
            this.lblNomorAgenda.ShowRemoveButton = false;
            this.lblNomorAgenda.Size = new System.Drawing.Size(337, 27);
            this.lblNomorAgenda.TabIndex = 0;
            this.lblNomorAgenda.ThemeName = "Windows8";
            this.lblNomorAgenda.TextChanged += new System.EventHandler(this.lblNomorAgenda_TextChanged);
            // 
            // FrmEditSuratMasuk
            // 
            this.AcceptButton = this.btnSimpan;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnBatal;
            this.ClientSize = new System.Drawing.Size(494, 405);
            this.Controls.Add(this.lblNomorAgenda);
            this.Controls.Add(this.txtRingkasanIsi);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.lblTanggalMasuk);
            this.Controls.Add(this.txtAsalSurat);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.btnBatal);
            this.Controls.Add(this.btnBersihkan);
            this.Controls.Add(this.radSeparator2);
            this.Controls.Add(this.txtPerihalSurat);
            this.Controls.Add(this.txtLampiran);
            this.Controls.Add(this.radLabel11);
            this.Controls.Add(this.dropDownTingkatKeamanan);
            this.Controls.Add(this.txtNomorSurat);
            this.Controls.Add(this.dtTanggalSurat);
            this.Controls.Add(this.radLabel18);
            this.Controls.Add(this.radLabel17);
            this.Controls.Add(this.radLabel16);
            this.Controls.Add(this.radLabel15);
            this.Controls.Add(this.radLabel12);
            this.Controls.Add(this.radLabel13);
            this.Controls.Add(this.radLabel3);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmEditSuratMasuk";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Surat Masuk";
            this.ThemeName = "Windows8";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmEditSuratMasuk_FormClosing);
            this.Load += new System.EventHandler(this.FrmEditSuratMasuk_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtAsalSurat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSimpan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBatal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBersihkan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPerihalSurat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLampiran)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dropDownTingkatKeamanan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNomorSurat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTanggalSurat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTanggalMasuk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRingkasanIsi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNomorAgenda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private Telerik.WinControls.Themes.Windows8Theme windows8Theme1;
        public Telerik.WinControls.UI.RadTextBox txtAsalSurat;
        private Telerik.WinControls.UI.RadButton btnSimpan;
        private Telerik.WinControls.UI.RadButton btnBatal;
        private Telerik.WinControls.UI.RadButton btnBersihkan;
        private Telerik.WinControls.UI.RadSeparator radSeparator2;
        public Telerik.WinControls.UI.RadTextBox txtPerihalSurat;
        public Telerik.WinControls.UI.RadTextBox txtLampiran;
        private Telerik.WinControls.UI.RadLabel radLabel11;
        public Telerik.WinControls.UI.RadDropDownList dropDownTingkatKeamanan;
        public Telerik.WinControls.UI.RadTextBox txtNomorSurat;
        public Telerik.WinControls.UI.RadDateTimePicker dtTanggalSurat;
        private Telerik.WinControls.UI.RadLabel radLabel18;
        private Telerik.WinControls.UI.RadLabel radLabel17;
        private Telerik.WinControls.UI.RadLabel radLabel16;
        private Telerik.WinControls.UI.RadLabel radLabel15;
        private Telerik.WinControls.UI.RadLabel radLabel12;
        //private Telerik.WinControls.Themes.Windows8Theme windows8Theme2;
        private Telerik.WinControls.UI.RadLabel radLabel13;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel lblTanggalMasuk;
        public Telerik.WinControls.UI.RadTextBox txtRingkasanIsi;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadAutoCompleteBox lblNomorAgenda;
    }
}
