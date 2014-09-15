namespace GUI.UIForms.Surat
{
    partial class FrmInputReferensiSurat
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
            this.lblNomorAgenda = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.radSeparator1 = new Telerik.WinControls.UI.RadSeparator();
            this.txtReferensiSurat = new Telerik.WinControls.UI.RadAutoCompleteBox();
            ((System.ComponentModel.ISupportInitialize)(this.lblNomorAgenda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferensiSurat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNomorAgenda
            // 
            this.lblNomorAgenda.AutoSize = false;
            this.lblNomorAgenda.BackColor = System.Drawing.Color.White;
            this.lblNomorAgenda.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomorAgenda.ForeColor = System.Drawing.Color.Black;
            this.lblNomorAgenda.Location = new System.Drawing.Point(3, 28);
            this.lblNomorAgenda.Name = "lblNomorAgenda";
            this.lblNomorAgenda.Padding = new System.Windows.Forms.Padding(3);
            this.lblNomorAgenda.Size = new System.Drawing.Size(269, 27);
            this.lblNomorAgenda.TabIndex = 0;
            this.lblNomorAgenda.ThemeName = "Windows8";
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(3, 3);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Padding = new System.Windows.Forms.Padding(2);
            this.radLabel1.Size = new System.Drawing.Size(200, 23);
            this.radLabel1.TabIndex = 129;
            this.radLabel1.Text = "Nomor Agenda Surat Masuk";
            this.radLabel1.ThemeName = "Windows8";
            // 
            // radLabel7
            // 
            this.radLabel7.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel7.Location = new System.Drawing.Point(3, 60);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Padding = new System.Windows.Forms.Padding(2);
            this.radLabel7.Size = new System.Drawing.Size(145, 23);
            this.radLabel7.TabIndex = 127;
            this.radLabel7.Text = "Nomor Surat Keluar";
            this.radLabel7.ThemeName = "Windows8";
            // 
            // radButton2
            // 
            this.radButton2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButton2.Location = new System.Drawing.Point(3, 125);
            this.radButton2.Name = "radButton2";
            this.radButton2.Size = new System.Drawing.Size(130, 29);
            this.radButton2.TabIndex = 2;
            this.radButton2.Text = "&Simpan";
            this.radButton2.ThemeName = "Windows8";
            this.radButton2.Click += new System.EventHandler(this.radButton2_Click);
            // 
            // radButton1
            // 
            this.radButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.radButton1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButton1.Location = new System.Drawing.Point(142, 125);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(130, 29);
            this.radButton1.TabIndex = 3;
            this.radButton1.Text = "&Keluar";
            this.radButton1.ThemeName = "Windows8";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // radSeparator1
            // 
            this.radSeparator1.Location = new System.Drawing.Point(-10, 115);
            this.radSeparator1.Name = "radSeparator1";
            this.radSeparator1.Size = new System.Drawing.Size(307, 4);
            this.radSeparator1.TabIndex = 131;
            this.radSeparator1.Text = "radSeparator1";
            this.radSeparator1.ThemeName = "Windows8";
            // 
            // txtReferensiSurat
            // 
            this.txtReferensiSurat.Delimiter = '\0';
            this.txtReferensiSurat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReferensiSurat.Location = new System.Drawing.Point(3, 82);
            this.txtReferensiSurat.MaxLength = 100;
            this.txtReferensiSurat.Name = "txtReferensiSurat";
            this.txtReferensiSurat.SelectionOpacity = 50;
            this.txtReferensiSurat.ShowRemoveButton = false;
            this.txtReferensiSurat.Size = new System.Drawing.Size(269, 27);
            this.txtReferensiSurat.TabIndex = 1;
            this.txtReferensiSurat.ThemeName = "Windows8";
            // 
            // FrmInputReferensiSurat
            // 
            this.AcceptButton = this.radButton2;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.radButton1;
            this.ClientSize = new System.Drawing.Size(275, 157);
            this.Controls.Add(this.txtReferensiSurat);
            this.Controls.Add(this.radSeparator1);
            this.Controls.Add(this.lblNomorAgenda);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.radLabel7);
            this.Controls.Add(this.radButton2);
            this.Controls.Add(this.radButton1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmInputReferensiSurat";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Referensi Surat Masuk";
            this.ThemeName = "Windows8";
            this.Load += new System.EventHandler(this.FrmInputReferensiSurat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lblNomorAgenda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferensiSurat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel lblNomorAgenda;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        //private Telerik.WinControls.Themes.Windows8Theme windows8Theme1;
        private Telerik.WinControls.UI.RadButton radButton2;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadSeparator radSeparator1;
        private Telerik.WinControls.UI.RadAutoCompleteBox txtReferensiSurat;
    }
}
