namespace GUI.UIForms
{
    partial class FrmPenyelesaian
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPenyelesaian));
            this.chkOtomatisCetakLembarDisposisi = new Telerik.WinControls.UI.RadCheckBox();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.lblNomorAgenda = new Telerik.WinControls.UI.RadAutoCompleteBox();
            this.txtPenyelesaian = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.btnSimpan = new Telerik.WinControls.UI.RadButton();
            this.btnBatal = new Telerik.WinControls.UI.RadButton();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radSeparator1 = new Telerik.WinControls.UI.RadSeparator();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.dtTanggalPenyelesaian = new Telerik.WinControls.UI.RadDateTimePicker();
            this.lblPosisiSaatIni = new Telerik.WinControls.UI.RadLabel();
            this.radLabel19 = new Telerik.WinControls.UI.RadLabel();
            this.txtPenyelesaianOleh = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.chkOtomatisCetakLembarDisposisi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNomorAgenda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPenyelesaian)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSimpan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBatal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTanggalPenyelesaian)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPosisiSaatIni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPenyelesaianOleh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // chkOtomatisCetakLembarDisposisi
            // 
            this.chkOtomatisCetakLembarDisposisi.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkOtomatisCetakLembarDisposisi.Location = new System.Drawing.Point(167, 196);
            this.chkOtomatisCetakLembarDisposisi.Name = "chkOtomatisCetakLembarDisposisi";
            this.chkOtomatisCetakLembarDisposisi.Size = new System.Drawing.Size(232, 21);
            this.chkOtomatisCetakLembarDisposisi.TabIndex = 5;
            this.chkOtomatisCetakLembarDisposisi.Text = "Otomatis cetak lembar penyelesaian";
            this.chkOtomatisCetakLembarDisposisi.TextWrap = true;
            this.chkOtomatisCetakLembarDisposisi.ThemeName = "Windows8";
            // 
            // radLabel5
            // 
            this.radLabel5.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel5.Location = new System.Drawing.Point(167, 221);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Padding = new System.Windows.Forms.Padding(2);
            this.radLabel5.Size = new System.Drawing.Size(272, 22);
            this.radLabel5.TabIndex = 105;
            this.radLabel5.Text = "*) Data harus diisi / Required Information";
            this.radLabel5.ThemeName = "Windows8";
            // 
            // lblNomorAgenda
            // 
            this.lblNomorAgenda.Delimiter = '\0';
            this.lblNomorAgenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomorAgenda.Location = new System.Drawing.Point(167, 5);
            this.lblNomorAgenda.MaxLength = 100;
            this.lblNomorAgenda.Name = "lblNomorAgenda";
            this.lblNomorAgenda.SelectionOpacity = 50;
            this.lblNomorAgenda.ShowRemoveButton = false;
            this.lblNomorAgenda.Size = new System.Drawing.Size(289, 27);
            this.lblNomorAgenda.TabIndex = 0;
            this.lblNomorAgenda.ThemeName = "Windows8";
            this.lblNomorAgenda.TextChanged += new System.EventHandler(this.lblNomorAgenda_TextChanged);
            // 
            // txtPenyelesaian
            // 
            this.txtPenyelesaian.AutoSize = false;
            this.txtPenyelesaian.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPenyelesaian.Location = new System.Drawing.Point(167, 128);
            this.txtPenyelesaian.MaxLength = 255;
            this.txtPenyelesaian.Multiline = true;
            this.txtPenyelesaian.Name = "txtPenyelesaian";
            this.txtPenyelesaian.Padding = new System.Windows.Forms.Padding(4);
            this.txtPenyelesaian.Size = new System.Drawing.Size(289, 65);
            this.txtPenyelesaian.TabIndex = 4;
            this.txtPenyelesaian.ThemeName = "Windows8";
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(5, 100);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Padding = new System.Windows.Forms.Padding(2);
            this.radLabel3.Size = new System.Drawing.Size(156, 23);
            this.radLabel3.TabIndex = 103;
            this.radLabel3.Text = "Tanggal Penyelesaian";
            this.radLabel3.ThemeName = "Windows8";
            // 
            // btnSimpan
            // 
            this.btnSimpan.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSimpan.Image = ((System.Drawing.Image)(resources.GetObject("btnSimpan.Image")));
            this.btnSimpan.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSimpan.Location = new System.Drawing.Point(167, 258);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Padding = new System.Windows.Forms.Padding(3);
            this.btnSimpan.Size = new System.Drawing.Size(137, 33);
            this.btnSimpan.TabIndex = 6;
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
            this.btnBatal.Location = new System.Drawing.Point(319, 258);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Padding = new System.Windows.Forms.Padding(3);
            this.btnBatal.Size = new System.Drawing.Size(137, 33);
            this.btnBatal.TabIndex = 7;
            this.btnBatal.Text = "&Batal";
            this.btnBatal.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnBatal.ThemeName = "Windows8";
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(5, 130);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Padding = new System.Windows.Forms.Padding(2);
            this.radLabel2.Size = new System.Drawing.Size(111, 23);
            this.radLabel2.TabIndex = 102;
            this.radLabel2.Text = "Penyelesaian *";
            this.radLabel2.ThemeName = "Windows8";
            // 
            // radSeparator1
            // 
            this.radSeparator1.Location = new System.Drawing.Point(-9, 249);
            this.radSeparator1.Name = "radSeparator1";
            this.radSeparator1.Size = new System.Drawing.Size(484, 3);
            this.radSeparator1.TabIndex = 101;
            this.radSeparator1.Text = "radSeparator1";
            this.radSeparator1.ThemeName = "Windows8";
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(5, 7);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Padding = new System.Windows.Forms.Padding(2);
            this.radLabel1.Size = new System.Drawing.Size(124, 23);
            this.radLabel1.TabIndex = 99;
            this.radLabel1.Text = "Nomor Agenda *";
            this.radLabel1.ThemeName = "Windows8";
            // 
            // dtTanggalPenyelesaian
            // 
            this.dtTanggalPenyelesaian.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTanggalPenyelesaian.Location = new System.Drawing.Point(167, 99);
            this.dtTanggalPenyelesaian.Name = "dtTanggalPenyelesaian";
            this.dtTanggalPenyelesaian.Padding = new System.Windows.Forms.Padding(2);
            this.dtTanggalPenyelesaian.Size = new System.Drawing.Size(289, 25);
            this.dtTanggalPenyelesaian.TabIndex = 3;
            this.dtTanggalPenyelesaian.TabStop = false;
            this.dtTanggalPenyelesaian.Text = "Thursday, April 10, 2014";
            this.dtTanggalPenyelesaian.ThemeName = "Windows8";
            this.dtTanggalPenyelesaian.Value = new System.DateTime(2014, 4, 10, 15, 1, 58, 295);
            // 
            // lblPosisiSaatIni
            // 
            this.lblPosisiSaatIni.AutoSize = false;
            this.lblPosisiSaatIni.BackColor = System.Drawing.Color.White;
            this.lblPosisiSaatIni.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosisiSaatIni.Location = new System.Drawing.Point(167, 37);
            this.lblPosisiSaatIni.Name = "lblPosisiSaatIni";
            this.lblPosisiSaatIni.Size = new System.Drawing.Size(289, 27);
            this.lblPosisiSaatIni.TabIndex = 1;
            this.lblPosisiSaatIni.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPosisiSaatIni.ThemeName = "Windows8";
            // 
            // radLabel19
            // 
            this.radLabel19.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel19.Location = new System.Drawing.Point(5, 39);
            this.radLabel19.Name = "radLabel19";
            this.radLabel19.Padding = new System.Windows.Forms.Padding(2);
            this.radLabel19.Size = new System.Drawing.Size(102, 23);
            this.radLabel19.TabIndex = 108;
            this.radLabel19.Text = "Posisi saat ini";
            this.radLabel19.ThemeName = "Windows8";
            // 
            // txtPenyelesaianOleh
            // 
            this.txtPenyelesaianOleh.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPenyelesaianOleh.Location = new System.Drawing.Point(167, 69);
            this.txtPenyelesaianOleh.MaxLength = 45;
            this.txtPenyelesaianOleh.Name = "txtPenyelesaianOleh";
            this.txtPenyelesaianOleh.Padding = new System.Windows.Forms.Padding(4);
            this.txtPenyelesaianOleh.Size = new System.Drawing.Size(289, 26);
            this.txtPenyelesaianOleh.TabIndex = 2;
            this.txtPenyelesaianOleh.ThemeName = "Windows8";
            // 
            // radLabel4
            // 
            this.radLabel4.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel4.Location = new System.Drawing.Point(5, 71);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Padding = new System.Windows.Forms.Padding(2);
            this.radLabel4.Size = new System.Drawing.Size(147, 23);
            this.radLabel4.TabIndex = 110;
            this.radLabel4.Text = "Penyelesaian Oleh *";
            this.radLabel4.ThemeName = "Windows8";
            // 
            // FrmPenyelesaian
            // 
            this.AcceptButton = this.btnSimpan;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnBatal;
            this.ClientSize = new System.Drawing.Size(461, 295);
            this.Controls.Add(this.txtPenyelesaianOleh);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.lblPosisiSaatIni);
            this.Controls.Add(this.radLabel19);
            this.Controls.Add(this.chkOtomatisCetakLembarDisposisi);
            this.Controls.Add(this.radLabel5);
            this.Controls.Add(this.lblNomorAgenda);
            this.Controls.Add(this.txtPenyelesaian);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.btnBatal);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radSeparator1);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.dtTanggalPenyelesaian);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmPenyelesaian";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Penyelesaian";
            this.ThemeName = "Windows8";
            this.Load += new System.EventHandler(this.FrmPenyelesaian_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chkOtomatisCetakLembarDisposisi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNomorAgenda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPenyelesaian)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSimpan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBatal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTanggalPenyelesaian)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPosisiSaatIni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPenyelesaianOleh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private Telerik.WinControls.Themes.Windows8Theme windows8Theme3;
        //private Telerik.WinControls.Themes.Windows8Theme windows8Theme2;
        //private Telerik.WinControls.Themes.Windows8Theme windows8Theme1;
        //private Telerik.WinControls.Themes.Windows8Theme windows8Theme4;
        private Telerik.WinControls.UI.RadCheckBox chkOtomatisCetakLembarDisposisi;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadAutoCompleteBox lblNomorAgenda;
        public Telerik.WinControls.UI.RadTextBox txtPenyelesaian;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadButton btnSimpan;
        private Telerik.WinControls.UI.RadButton btnBatal;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadSeparator radSeparator1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        //private Telerik.WinControls.Themes.Windows8Theme windows8Theme5;
        private Telerik.WinControls.UI.RadDateTimePicker dtTanggalPenyelesaian;
        private Telerik.WinControls.UI.RadLabel lblPosisiSaatIni;
        private Telerik.WinControls.UI.RadLabel radLabel19;
        public Telerik.WinControls.UI.RadTextBox txtPenyelesaianOleh;
        private Telerik.WinControls.UI.RadLabel radLabel4;

    }
}
