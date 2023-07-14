using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Script_Tool
{
    /*
     * frmMain - Application entry point and primary form.
     */

    public partial class frmMain : Form
    {
        // Constant variables
        const int MAXWORLDTEXTURES = 8192;
        const int MAXMODELTEXTURES = 2048;
        const int MAXSUBFOLDERS = 4096;

        public const string CONTROLDELIMITER = ": ";

        const string USERDATAFILENAME = "userdata.udf";

        // Extensions
        public static string[] m_szFormats =
        { 
          ".DDS", 
          ".TGA", 
          ".BMP" 
        };

        // Texture info variables
        string[] m_szWorldTextures;
        int m_iNumWorldTextures;

        string[,] m_szModelTextures;
        int[] m_iNumModelTextures;

        string[] m_szSubFolders;
        int m_iNumModelIndexes;

        // User data array list
        public static List<string> m_szUserData;

        // Texture script data
        public static List<string> m_szScriptData;

        // User config data file directorty
        public static string m_szFullDir;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Get user settings
            GetUserSettings();
        }

        private void strpmenuitemAbout_Click(object sender, EventArgs e)
        {
            // Create instance
            frmAbout frm = new frmAbout();

            // Show as dialog
            frm.ShowDialog(this);
        }

        private void BrowsePath(object sender, EventArgs e)
        {
            // Open file browser dialog
            if (fbdTextures.ShowDialog() == DialogResult.OK)
            {
                // Get selected path
                this.txtTexturesPath.Text = fbdTextures.SelectedPath;
            }
        }

        //==============================
        // Run()
        // Start core algorithms
        //==============================
        private void Run(object sender, EventArgs e)
        {
            // Dn't pass if no path is specified
            if (txtTexturesPath.Text == "")
            {
                MessageBox.Show("No texture path specified, aborting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Don't pass if no formats were selected
            if (!cbxDDS.Checked && !cbxTGA.Checked && !cbxBMP.Checked)
            {
                MessageBox.Show("No file formats selected, aborting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Don't pass if no generation type was selected
            if (!cbxWorldTextures.Checked && !cbxModelTextures.Checked)
            {
                MessageBox.Show("No generation type was selected, aborting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Parse world textures
            if (cbxWorldTextures.Checked)
                ParseWorldTextures();

            // Parse model textures
            if (cbxModelTextures.Checked)
                ParseModelTextures();

            // Build the texture script
            MakeScript();
        }

        //==============================
        // ParseModelTextures()
        // Grab textures from world folder
        //==============================
        private void ParseWorldTextures()
        {
            string[] szFiles;

            string szWorkingDir;

            // Make sure it isn't empty
            if (txtTexturesPath.Text != null)
            {
                // Go to world folder
                szWorkingDir = String.Concat(txtTexturesPath.Text, @"\world");

                // Check if this path exists
                if (Directory.Exists(szWorkingDir))
                {
                    // Get existing files
                    szFiles = Directory.GetFiles(szWorkingDir);

                    // Check if any files were parsed
                    if (szFiles.Length > 0)
                    {
                        // Declare at this point
                        m_szWorldTextures = new string[MAXWORLDTEXTURES];
                        m_iNumWorldTextures = 0;

                        // Loop each texture
                        for (int i = 0; i < szFiles.Length; i++)
                        {
                            // Get extension of current texture
                            string ext = Path.GetExtension(szFiles[i]);

                            // Check all file formats, but only include selected formats

                            if (String.Equals(ext, m_szFormats[0], StringComparison.CurrentCultureIgnoreCase))
                            {
                                if (cbxDDS.Checked)
                                {
                                    // Include current texture
                                    m_szWorldTextures[m_iNumWorldTextures] = Path.GetFileNameWithoutExtension(szFiles[i]);
                                    m_iNumWorldTextures++;
                                }
                            }
                            else if (String.Equals(ext, m_szFormats[1], StringComparison.CurrentCultureIgnoreCase))
                            {
                                if (cbxTGA.Checked)
                                {
                                    // Include current texture
                                    m_szWorldTextures[m_iNumWorldTextures] = Path.GetFileNameWithoutExtension(szFiles[i]);
                                    m_iNumWorldTextures++;
                                }
                            }
                            else if (String.Equals(ext, m_szFormats[2], StringComparison.CurrentCultureIgnoreCase))
                            {
                                if (cbxBMP.Checked)
                                {
                                    // Include current texture
                                    m_szWorldTextures[m_iNumWorldTextures] = Path.GetFileNameWithoutExtension(szFiles[i]);
                                    m_iNumWorldTextures++;
                                }
                            }
                            else
                            {
                                MessageBox.Show("No valid formats found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                    else
                        MessageBox.Show("World directory contains no textures, aborting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("World directory does not exist, aborting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //==============================
        // ParseModelTextures()
        // Grab textures from models folder
        //==============================
        private void ParseModelTextures()
        {
            string[,] szFiles;
            int[] iNumFiles;
            int iNumFolders;

            string szWorkingDir;

            // Make sure it isn't empty
            if (txtTexturesPath.Text != null)
            {
                // Go to models folder
                szWorkingDir = String.Concat(txtTexturesPath.Text, @"\models");

                // Check if this path exists
                if (Directory.Exists(szWorkingDir))
                {
                    // Get existing subfolders
                    m_szSubFolders = Directory.GetDirectories(szWorkingDir);

                    // Check if any folders were parsed
                    if (m_szSubFolders.Length > 0)
                    {
                        // Declare at this point
                        m_szModelTextures = new string[MAXSUBFOLDERS, MAXMODELTEXTURES];
                        m_iNumModelTextures = new int[MAXSUBFOLDERS];
                        m_iNumModelIndexes = 0;

                        iNumFiles = new int[MAXSUBFOLDERS];
                        iNumFolders = 0;

                        szFiles = new string[MAXSUBFOLDERS, MAXMODELTEXTURES];

                        // Loop each subfolder
                        for (int i = 0; i < m_szSubFolders.Length; i++)
                        {
                            // Get contents of current subfolder
                            string[] files = Directory.GetFiles(m_szSubFolders[i]);

                            // Check if any files were parsed in this folder
                            if (files.Length > 0)
                            {
                                // Get all textures from current subfolder
                                for (int j = 0; j < files.Length; j++)
                                {
                                    szFiles[iNumFolders, j] = files[j];
                                    iNumFiles[iNumFolders]++;
                                }

                                iNumFolders++;
                            }
                            else
                            {
                                MessageBox.Show(String.Concat(m_szSubFolders[i], " ", "contains no textures."), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                continue;
                            }
                        }

                        // Loop each texture
                        for (int i = 0; i < iNumFolders; i++)
                        {
                            for (int j = 0; j < iNumFiles[i]; j++)
                            {
                                // Get extension of current texture
                                string ext = Path.GetExtension(szFiles[i, j]);

                                // Check all file formats, but only include selected formats

                                if (String.Equals(ext, m_szFormats[0], StringComparison.CurrentCultureIgnoreCase))
                                {
                                    if (cbxDDS.Checked)
                                    {
                                        // Include current texture
                                        m_szModelTextures[m_iNumModelIndexes, m_iNumModelTextures[m_iNumModelIndexes]] = Path.GetFileNameWithoutExtension(szFiles[i, j]);
                                        m_iNumModelTextures[m_iNumModelIndexes]++;
                                    }
                                }
                                else if (String.Equals(ext, m_szFormats[1], StringComparison.CurrentCultureIgnoreCase))
                                {
                                    if (cbxTGA.Checked)
                                    {
                                        // Include current texture
                                        m_szModelTextures[m_iNumModelIndexes, m_iNumModelTextures[m_iNumModelIndexes]] = Path.GetFileNameWithoutExtension(szFiles[i, j]);
                                        m_iNumModelTextures[m_iNumModelIndexes]++;
                                    }
                                }
                                else if (String.Equals(ext, m_szFormats[2], StringComparison.CurrentCultureIgnoreCase))
                                {
                                    if (cbxBMP.Checked)
                                    {
                                        // Include current texture
                                        m_szModelTextures[m_iNumModelIndexes, m_iNumModelTextures[m_iNumModelIndexes]] = Path.GetFileNameWithoutExtension(szFiles[i, j]);
                                        m_iNumModelTextures[m_iNumModelIndexes]++;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("No valid formats found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }

                            m_iNumModelIndexes++;
                        }
                    }
                    else
                        MessageBox.Show("Models directory contains no subdirectories, aborting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Models directory does not exist, aborting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //==============================
        // MakeScript()
        // Generate texture script file
        //==============================
        private void MakeScript()
        {
            m_szScriptData = new List<string>();

            int iModelIndexes = 0;

            // Header
            m_szScriptData.Add("//");
            m_szScriptData.Add("// Texture flag script");
            m_szScriptData.Add("//");

            m_szScriptData.Add("");
            m_szScriptData.Add("");

            // Sum all values of m_iNumModelTextures for a positive reference value
            for (int i = 0; i < m_iNumModelIndexes; i++)
                iModelIndexes += m_iNumModelTextures[i];

            // Is there anything to write at all
            if (m_iNumWorldTextures == 0 && iModelIndexes == 0)
            {
                MessageBox.Show("No textures to write!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // World textures
            if (m_iNumWorldTextures > 0)
            {
                // Header
                m_szScriptData.Add("");
                m_szScriptData.Add("// World");
                m_szScriptData.Add("");

                // Loop world array
                for (int i = 0; i < m_iNumWorldTextures; i++)
                    m_szScriptData.Add("world " + m_szWorldTextures[i] + " alternate");

                m_szScriptData.Add("");
            }
            else
                MessageBox.Show("No world textures to write!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            // Model textures
            if (m_iNumModelIndexes > 0)
            {
                // Header
                m_szScriptData.Add("");
                m_szScriptData.Add("// Models");
                m_szScriptData.Add("");

                // Loop model array
                for (int i = 0; i < m_iNumModelIndexes; i++)
                {
                    for (int j = 0; j < m_iNumModelTextures[i]; j++)
                        m_szScriptData.Add(Path.GetFileName(m_szSubFolders[i]) + " " + m_szModelTextures[i, j] + " alternate");

                    m_szScriptData.Add("");
                }
            }
            else
                MessageBox.Show("No model textures to write!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            // Write the script
            WriteScript();
        }


        //==============================
        // WriteScript()
        // Write existing virtual script file
        //==============================
        private void WriteScript()
        {
            // Does a texture script exist already
            if (File.Exists(String.Concat(txtTexturesPath.Text, @"\texture_flags.txt")))
            {
                DialogResult Result = MessageBox.Show("texture_flags.txt already exists, do you want to overwrite?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (Result == DialogResult.No)
                    return;
            }

            // Generate flag script in textures folder
            string szFinalPath = String.Concat(txtTexturesPath.Text, @"\texture_flags.txt");

            try
            {
                // Create a writer and open the file
                TextWriter tw = new StreamWriter(szFinalPath);

                // Print script
                for (int i = 0; i < m_szScriptData.Count; i++)
                    tw.WriteLine(m_szScriptData[i]);

                // Close the stream
                tw.Close();

                // Sucessfully generated file
                MessageBox.Show("Texture script successfully generated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                // Could not generate .cfg file
                MessageBox.Show("Could not generate texture script, make sure the previous saved config file is not Read-only.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //==============================
        // SaveUserSettings()
        // Save relevant control state to user file
        //==============================
        private void SaveUserSettings()
        {
            // Get user config data file directorty
            CreateFilePath(true);

            try
            {
                // Create a writer and open the file
                TextWriter tw = new StreamWriter(m_szFullDir);

                // Header
                tw.WriteLine("// User settings data file (do not modify)");
                tw.WriteLine("// " + DateTime.Now);

                tw.WriteLine();

                // Write settings
                tw.WriteLine(txtTexturesPath.Name + CONTROLDELIMITER + txtTexturesPath.Text);
                tw.WriteLine(cbxWorldTextures.Name + CONTROLDELIMITER + cbxWorldTextures.Checked);
                tw.WriteLine(cbxModelTextures.Name + CONTROLDELIMITER + cbxWorldTextures.Checked);
                tw.WriteLine(cbxDDS.Name + CONTROLDELIMITER + cbxDDS.Checked);
                tw.WriteLine(cbxTGA.Name + CONTROLDELIMITER + cbxTGA.Checked);
                tw.WriteLine(cbxBMP.Name + CONTROLDELIMITER + cbxBMP.Checked);

                // Close the stream
                tw.Close();
            }
            catch
            {
                // Could not generate .udf file
                MessageBox.Show("User settings could not be saved, make sure the previous user settings file is not Read-only.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //==============================
        // GetUserSettings()
        // Load saved control state list if existent
        //==============================
        private void GetUserSettings()
        {
            // Get user config data file directorty
            CreateFilePath(false);

            try
            {
                // Create reader & open file
                TextReader tr = new StreamReader(m_szFullDir);

                m_szUserData = new List<string>();

                // Current line
                string szCurLine;

                // Get line string
                szCurLine = tr.ReadLine();

                // Loop the whole file
                while (szCurLine != null)
                {
                    m_szUserData.Add(szCurLine);
                    szCurLine = tr.ReadLine();
                }

                // Close the stream
                tr.Close();

                // Populate the objects
                SetUserSettings();
            }
            catch
            {
                // Set default items if otherwise something went wrong
                cbxWorldTextures.Checked = true;
                cbxModelTextures.Checked = true;
                cbxDDS.Checked = true;
                cbxTGA.Checked = true;
                cbxBMP.Checked = true;
            }
        }

        //==============================
        // SetUserSettings()
        // Apply loaded settings to respective control name
        //==============================
        private void SetUserSettings()
        {
            // Parse values of every saved control and assign them

            // txtTexturesPath
            txtTexturesPath.Text = (GetValue(txtTexturesPath.Name)).ToString();

            // cbxWorldTextures
            try
            {
                cbxWorldTextures.Checked = bool.Parse(GetValue(cbxWorldTextures.Name));
            }
            catch
            {
                cbxWorldTextures.Checked = false;
            }

            // cbxModelTextures
            try
            {
                cbxModelTextures.Checked = bool.Parse(GetValue(cbxModelTextures.Name));
            }
            catch
            {
                cbxModelTextures.Checked = false;
            }

            // cbxDDS
            try
            {
                cbxDDS.Checked = bool.Parse(GetValue(cbxDDS.Name));
            }
            catch
            {
                cbxDDS.Checked = false;
            }

            // cbxTGA
            try
            {
                cbxTGA.Checked = bool.Parse(GetValue(cbxTGA.Name));
            }
            catch
            {
                cbxTGA.Checked = false;
            }

            // cbxBMP
            try
            {
                cbxBMP.Checked = bool.Parse(GetValue(cbxBMP.Name));
            }
            catch
            {
                cbxBMP.Checked = false;
            }
        }

        //==============================
        // GetValue()
        // Loop state list for wanted control value
        //==============================
        private string GetValue(string szControlName)
        {
            string[] szSubstrings = null;

            // Loop the list
            for (int i = 0; i < m_szUserData.Count; i++)
            {
                // Check if current string bears the specific control name
                if (m_szUserData[i].Contains(szControlName))
                {
                    // Split desired control value from current string
                    szSubstrings = m_szUserData[i].Split(new string[] { CONTROLDELIMITER }, StringSplitOptions.None);
                    break;
                }
            }

            // Return value
            return szSubstrings[1];
        }

        //==============================
        // CreateFilePath()
        // Create path to save user state list to
        //==============================
        private void CreateFilePath(bool bCreate)
        {
            // Get user application data folder
            string szAppdataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            // Application folder
            string szScriptToolDir = String.Concat(szAppdataDir, @"\Script Tool\");

            // Create the folder if necessary
            if (bCreate == true)
                Directory.CreateDirectory(szScriptToolDir);

            // Mount the full directory
            m_szFullDir = String.Concat(szScriptToolDir, USERDATAFILENAME);
        }

        //==============================
        // ExitApp()
        // Wrap everything up and exit
        //==============================
        private void Close(object sender, EventArgs e)
        {
            // Save user settings
            SaveUserSettings();

            // Close and dispose
            Close();
            Dispose();
        }
    }
}
