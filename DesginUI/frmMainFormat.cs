using Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator.DesignUI
{
    public partial class frmMainFormat : KryptonForm
    {

        public frmMainFormat()
        {
            InitializeComponent();

            _SetFormPositionCenterScreen();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = true;
        }


        protected void _SetFormPositionCenterScreen()
        {
            this.Location = new Point(
               (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2,
               (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2
            );
        }

        private void frmMainFormat_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.MinimizeBox = false;
            }
            else
            {
                this.MinimizeBox = true;
            }
        }



    }
}
