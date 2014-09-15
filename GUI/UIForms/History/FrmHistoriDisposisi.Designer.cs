namespace GUI.UIForms
{
    partial class FrmHistoriDisposisi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHistoriDisposisi));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.gvSejarahDisposisi = new Telerik.WinControls.UI.RadGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.panel7 = new System.Windows.Forms.Panel();
            this.radCheckBox2 = new Telerik.WinControls.UI.RadCheckBox();
            this.radCheckBox1 = new Telerik.WinControls.UI.RadCheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblPosisiSaatIni = new Telerik.WinControls.UI.RadLabel();
            this.radLabel19 = new Telerik.WinControls.UI.RadLabel();
            this.lblNomorAgenda = new Telerik.WinControls.UI.RadLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvSejarahDisposisi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSejarahDisposisi.MasterTemplate)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblPosisiSaatIni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNomorAgenda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(771, 303);
            this.panel1.TabIndex = 19;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.gvSejarahDisposisi);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 33);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(765, 235);
            this.panel4.TabIndex = 0;
            // 
            // gvSejarahDisposisi
            // 
            this.gvSejarahDisposisi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvSejarahDisposisi.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvSejarahDisposisi.Location = new System.Drawing.Point(0, 0);
            // 
            // gvSejarahDisposisi
            // 
            this.gvSejarahDisposisi.MasterTemplate.AllowAddNewRow = false;
            this.gvSejarahDisposisi.MasterTemplate.EnableAlternatingRowColor = true;
            this.gvSejarahDisposisi.MasterTemplate.EnableGrouping = false;
            this.gvSejarahDisposisi.Name = "gvSejarahDisposisi";
            this.gvSejarahDisposisi.Padding = new System.Windows.Forms.Padding(3);
            this.gvSejarahDisposisi.ReadOnly = true;
            this.gvSejarahDisposisi.Size = new System.Drawing.Size(765, 235);
            this.gvSejarahDisposisi.TabIndex = 2;
            this.gvSejarahDisposisi.Text = "radGridView1";
            this.gvSejarahDisposisi.ThemeName = "Windows8";
            this.gvSejarahDisposisi.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.gvHistoryLoginUser_CellFormatting);
            this.gvSejarahDisposisi.ViewCellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.gvSejarahDisposisi_ViewCellFormatting_1);
            this.gvSejarahDisposisi.Click += new System.EventHandler(this.gvSejarahDisposisi_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 268);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(765, 32);
            this.panel3.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.radButton1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(631, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(134, 32);
            this.panel5.TabIndex = 1;
            // 
            // radButton1
            // 
            this.radButton1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButton1.Image = ((System.Drawing.Image)(resources.GetObject("radButton1.Image")));
            this.radButton1.Location = new System.Drawing.Point(2, 2);
            this.radButton1.Name = "radButton1";
            this.radButton1.Padding = new System.Windows.Forms.Padding(2);
            this.radButton1.Size = new System.Drawing.Size(130, 28);
            this.radButton1.TabIndex = 0;
            this.radButton1.Text = "&Cetak Disposisi";
            this.radButton1.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.radButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.radButton1.ThemeName = "Windows8";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Transparent;
            this.panel7.Controls.Add(this.radCheckBox2);
            this.panel7.Controls.Add(this.radCheckBox1);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(252, 32);
            this.panel7.TabIndex = 0;
            // 
            // radCheckBox2
            // 
            this.radCheckBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radCheckBox2.Location = new System.Drawing.Point(106, 5);
            this.radCheckBox2.Name = "radCheckBox2";
            this.radCheckBox2.Size = new System.Drawing.Size(135, 21);
            this.radCheckBox2.TabIndex = 1;
            this.radCheckBox2.Text = "Administrator table";
            this.radCheckBox2.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.radCheckBox2_ToggleStateChanged);
            // 
            // radCheckBox1
            // 
            this.radCheckBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radCheckBox1.Location = new System.Drawing.Point(4, 5);
            this.radCheckBox1.Name = "radCheckBox1";
            this.radCheckBox1.Size = new System.Drawing.Size(97, 21);
            this.radCheckBox1.TabIndex = 0;
            this.radCheckBox1.Text = "Autosize row";
            this.radCheckBox1.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.radCheckBox1_ToggleStateChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblPosisiSaatIni);
            this.panel2.Controls.Add(this.radLabel19);
            this.panel2.Controls.Add(this.lblNomorAgenda);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(765, 30);
            this.panel2.TabIndex = 18;
            // 
            // lblPosisiSaatIni
            // 
            this.lblPosisiSaatIni.AutoSize = false;
            this.lblPosisiSaatIni.BackColor = System.Drawing.Color.White;
            this.lblPosisiSaatIni.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosisiSaatIni.Location = new System.Drawing.Point(501, 0);
            this.lblPosisiSaatIni.Name = "lblPosisiSaatIni";
            this.lblPosisiSaatIni.Size = new System.Drawing.Size(263, 27);
            this.lblPosisiSaatIni.TabIndex = 92;
            this.lblPosisiSaatIni.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPosisiSaatIni.ThemeName = "Windows8";
            // 
            // radLabel19
            // 
            this.radLabel19.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel19.Location = new System.Drawing.Point(384, 2);
            this.radLabel19.Name = "radLabel19";
            this.radLabel19.Padding = new System.Windows.Forms.Padding(2);
            this.radLabel19.Size = new System.Drawing.Size(108, 23);
            this.radLabel19.TabIndex = 93;
            this.radLabel19.Text = "Posisi saat ini:";
            this.radLabel19.ThemeName = "Windows8";
            // 
            // lblNomorAgenda
            // 
            this.lblNomorAgenda.AutoSize = false;
            this.lblNomorAgenda.BackColor = System.Drawing.Color.White;
            this.lblNomorAgenda.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomorAgenda.Location = new System.Drawing.Point(113, 0);
            this.lblNomorAgenda.Name = "lblNomorAgenda";
            this.lblNomorAgenda.Padding = new System.Windows.Forms.Padding(3);
            this.lblNomorAgenda.Size = new System.Drawing.Size(261, 27);
            this.lblNomorAgenda.TabIndex = 91;
            this.lblNomorAgenda.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNomorAgenda.ThemeName = "Windows8";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nomor Agenda:";
            // 
            // FrmHistoriDisposisi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 303);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmHistoriDisposisi";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Histori Disposisi";
            this.ThemeName = "Windows8";
            this.Load += new System.EventHandler(this.FrmSejarahDisposisi_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvSejarahDisposisi.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSejarahDisposisi)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblPosisiSaatIni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNomorAgenda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        //private Telerik.WinControls.Themes.Windows8Theme windows8Theme1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadLabel lblNomorAgenda;
        private Telerik.WinControls.UI.RadLabel lblPosisiSaatIni;
        private Telerik.WinControls.UI.RadLabel radLabel19;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel7;
        private Telerik.WinControls.UI.RadCheckBox radCheckBox2;
        private Telerik.WinControls.UI.RadCheckBox radCheckBox1;
        private Telerik.WinControls.UI.RadGridView gvSejarahDisposisi;
        private System.Windows.Forms.Panel panel5;
        private Telerik.WinControls.UI.RadButton radButton1;
    }
}
