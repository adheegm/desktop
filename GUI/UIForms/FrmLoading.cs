using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Threading;
namespace GUI.UIForms
{
    public partial class FrmLoading : Telerik.WinControls.UI.RadForm
    {
        //private FrmMain frmMain;
        public FrmLoading()
        {
            InitializeComponent();
            radWaitingBar1.StartWaiting();
            this.ShowInTaskbar = false;
            //frmMain = _frmMain;
            //this.MinimumSize = new System.Drawing.Size(35, 35);
            //this.TopMost = true;
        }

        private void FrmLoading_Initialized(object sender, EventArgs e)
        {
            
        }

        //private void AdjustLocation()
        //{
        //    // Adjust the position relative to main form
        //    int dx = (frmMain.Width - this.Width) / 2;
        //    int dy = (frmMain.Height - this.Height) / 2;
        //    Point loc = new Point(frmMain.Location.X, frmMain.Location.Y);
        //    loc.Offset(dx, dy);
        //    this.Location = loc;
        //}

        private void FrmLoading_Load(object sender, EventArgs e)
        {
            //radWaitingBar1.StartWaiting();
          //  int x, y;
            //x = (this.Width / 2) - (radWaitingBar1.Width / 2);
          //  y = (this.Height / 2) - (radWaitingBar1.Height / 2);
            //radWaitingBar1.Location = new Point(x,y);
            //this.Size = new System.Drawing.Size(230, 20);
        }

        private void FrmLoading_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void FrmLoading_Shown(object sender, EventArgs e)
        {

            this.Size = new System.Drawing.Size(230, 20);
            //Thread.Sleep(100);
            //this.Width = 50;
            //this.Height = 50;
        }

        private void FrmLoading_Activated(object sender, EventArgs e)
        {

            //this.Size = new System.Drawing.Size(230, 20);
            //this.Width = 50;
            //this.Height = 50;
        }
    }
}
