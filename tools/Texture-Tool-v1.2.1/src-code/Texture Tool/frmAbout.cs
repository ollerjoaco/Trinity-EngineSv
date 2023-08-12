using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Script_Tool
{
    /*
     * frmAbout - Developing and version info dialog style form.
     */

    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            // Center form to parent form
            this.CenterToParent();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            // Close and dispose
            Close();
            Dispose();
        }
    }
}
