using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Script_Tool
{
    /*
     * Program - Primary class with Main() definition.
     */

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
