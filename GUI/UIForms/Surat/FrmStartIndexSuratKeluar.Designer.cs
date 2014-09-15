namespace GUI.UIForms.Surat
{
    partial class FrmStartIndexSuratKeluar
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
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.btnBatal = new Telerik.WinControls.UI.RadButton();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.nStartIndex = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBatal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nStartIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel2
            // 
            this.radLabel2.AutoSize = false;
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.ForeColor = System.Drawing.Color.Red;
            this.radLabel2.Location = new System.Drawing.Point(5, 67);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(214, 39);
            this.radLabel2.TabIndex = 30;
            this.radLabel2.Text = "Data surat masih kosong atau baru direset. Inputkan index awal surat.";
            // 
            // radButton1
            // 
            this.radButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.radButton1.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButton1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radButton1.Location = new System.Drawing.Point(124, 35);
            this.radButton1.Name = "radButton1";
            this.radButton1.Padding = new System.Windows.Forms.Padding(3);
            this.radButton1.Size = new System.Drawing.Size(90, 28);
            this.radButton1.TabIndex = 29;
            this.radButton1.Text = "&Batal";
            this.radButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.radButton1.ThemeName = "Windows8";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // btnBatal
            // 
            this.btnBatal.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBatal.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBatal.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnBatal.Location = new System.Drawing.Point(12, 36);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Padding = new System.Windows.Forms.Padding(3);
            this.btnBatal.Size = new System.Drawing.Size(93, 28);
            this.btnBatal.TabIndex = 28;
            this.btnBatal.Text = "&OK";
            this.btnBatal.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnBatal.ThemeName = "Windows8";
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(12, 7);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Padding = new System.Windows.Forms.Padding(2);
            this.radLabel1.Size = new System.Drawing.Size(93, 23);
            this.radLabel1.TabIndex = 27;
            this.radLabel1.Text = "Start Index:";
            this.radLabel1.ThemeName = "Windows8";
            // 
            // nStartIndex
            // 
            this.nStartIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nStartIndex.Location = new System.Drawing.Point(111, 7);
            this.nStartIndex.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nStartIndex.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nStartIndex.Name = "nStartIndex";
            this.nStartIndex.Size = new System.Drawing.Size(103, 22);
            this.nStartIndex.TabIndex = 26;
            this.nStartIndex.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // FrmStartIndexSuratKeluar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 110);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.btnBatal);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.nStartIndex);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmStartIndexSuratKeluar";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmStartIndexSuratKeluar";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.FrmStartIndexSuratKeluar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBatal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nStartIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadButton btnBatal;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private System.Windows.Forms.NumericUpDown nStartIndex;
    }
}
