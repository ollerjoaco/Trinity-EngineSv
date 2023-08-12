using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Detail_Tool
{
    /*
     * frmMain - Application entry point and primary form.
     */

    public partial class frmMain : Form
    {
        // Variables exclusive to this class

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Globals.Startup();

            // Load saved settings
            GetUserSettings();

            if (txtMaterialsPath.Text == "")
                txtMaterialsPath.Text = Globals.MATERIALSPATHTEXT;

            if (txtTexturesPath.Text == "")
                txtTexturesPath.Text = Globals.TEXTURESPATHTEXT;
        }

        private void txtMaterialsPath_Click(object sender, EventArgs e)
        {
            if (txtMaterialsPath.Text == Globals.MATERIALSPATHTEXT)
                txtMaterialsPath.Clear();
        }

        private void txtTexturesPath_Click(object sender, EventArgs e)
        {
            if (txtTexturesPath.Text == Globals.TEXTURESPATHTEXT)
                txtTexturesPath.Clear();
        }

        private void txtMaterialsPath_Leave(object sender, EventArgs e)
        {
            if (txtMaterialsPath.Text == "")
                txtMaterialsPath.Text = Globals.MATERIALSPATHTEXT;
        }

        private void txtTexturesPath_Leave(object sender, EventArgs e)
        {
            if (txtTexturesPath.Text == "")
                txtTexturesPath.Text = Globals.TEXTURESPATHTEXT;
        }

        private void strpmenuitemAbout_Click(object sender, EventArgs e)
        {
            // Create instance
            frmAbout frm = new frmAbout();

            // Show as dialog
            frm.ShowDialog(this);
        }

        //==============================
        // BrowseMaterialsPath()
        // Open a folder browser dialog and assign selected path
        //==============================
        private void BrowseMaterialsPath(object sender, EventArgs e)
        {
            // Open folder browser dialog
            if (fbdMaterials.ShowDialog() == DialogResult.OK)
            {
                // Get selected path
                this.txtMaterialsPath.Text = fbdMaterials.SelectedPath;
            }
        }

        //==============================
        // BrowseTexturesPath()
        // Open a folder browser dialog and assign selected path
        //==============================
        private void BrowseTexturesPath(object sender, EventArgs e)
        {
            // Open folder browser dialog
            if (fbdTextures.ShowDialog() == DialogResult.OK)
            {
                // Get selected path
                this.txtTexturesPath.Text = fbdTextures.SelectedPath;
            }
        }

        //==============================
        // OpenMaterialList()
        // Open material list editor
        //==============================
        private void OpenMaterialList(object sender, EventArgs e)
        {
            // Create instance
            frmMaterials frm = new frmMaterials();

            // Show as dialog
            frm.ShowDialog(this);
        }

        //==============================
        // Run()
        // Start core algorithms
        //==============================
        private void Run(object sender, EventArgs e)
        {
            // Don't pass if no path is specified
            if (txtMaterialsPath.Text == Globals.MATERIALSPATHTEXT || txtMaterialsPath.Text == "")
            {
                MessageBox.Show("No material path specified, aborting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Don't pass if no path is specified
            if (txtTexturesPath.Text == Globals.TEXTURESPATHTEXT || txtTexturesPath.Text == "")
            {
                MessageBox.Show("No texture path specified, aborting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Don't pass if no entries were added to material list
            if (Globals.g_szMaterials[0, 1] == null)
            {
                MessageBox.Show("No materials have been added to the list, aborting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // All checks were valid, start algorithms

            // Read materials from material files
            ParseMaterials();
        }

        //==============================
        // ParseMaterials()
        // Read materials from material text files
        //==============================
        private void ParseMaterials()
        {
            string[] szFiles;

            string szWorkingDir = txtMaterialsPath.Text;

            // Make sure it isn't empty
            if (txtMaterialsPath.Text != null)
            {
                // Check if this path exists
                if (Directory.Exists(szWorkingDir))
                {
                    // Get existing files
                    szFiles = Directory.GetFiles(szWorkingDir);

                    // Got any files?
                    if (szFiles.Length > 0)
                    {
                        // Declare at this point
                        Globals.g_szMaterialFiles = new string[Globals.MAXMATERIALFILES];
                        Globals.g_iNumMaterialFiles = 0;

                        Globals.g_szMaterialTextures = new string[Globals.MAXMATERIALTEXTURES];
                        Globals.g_iNumMaterialTextures = 0;

                        // Loop each file
                        for (int i = 0; i < szFiles.Length; i++)
                        {
                            // Get extension of current file
                            string ext = Path.GetExtension(szFiles[i]);

                            if (String.Equals(ext, Globals.g_szFormats[3], StringComparison.CurrentCultureIgnoreCase))
                            {
                                // Only file name for comparision
                                string filename = Path.GetFileNameWithoutExtension(szFiles[i]);

                                // Only file names with specific sufix
                                if (filename.EndsWith("materials", StringComparison.CurrentCultureIgnoreCase))
                                {
                                    // Got a valid material file, add to array
                                    Globals.g_szMaterialFiles[Globals.g_iNumMaterialFiles] = szFiles[i];
                                    Globals.g_iNumMaterialFiles++;
                                }
                            }
                        }

                        // Now that we selected the desired files from the folder its time to read them

                        // Loop each file in the array
                        for (int i = 0; i < Globals.g_iNumMaterialFiles; i++)
                        {
                            string[] lines = File.ReadAllLines(Globals.g_szMaterialFiles[i]);

                            // Now loop each line of the current file
                            for (int j = 0; j < lines.Length; j++)
                            {
                                // And loop recognized material keys to match first letter in the current line
                                for (int k = 0; k < Globals.g_iNumMaterials; k++)
                                {
                                    if (lines[j].StartsWith(Globals.g_szMaterials[k, 0], StringComparison.CurrentCulture))
                                    {
                                        // Found a possible material entry, add it
                                        Globals.g_szMaterialTextures[Globals.g_iNumMaterialTextures] = lines[j];
                                        Globals.g_iNumMaterialTextures++;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Materials directory is empty, aborting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Materials directory does not exist, aborting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Pick all textures from selected folder
            ParseTextures();
        }

        //==============================
        // ParseTextures()
        // Grab textures from selected folder
        //==============================
        private void ParseTextures()
        {
            string[] szFiles;

            string szWorkingDir = txtTexturesPath.Text;

            // Make sure it isn't empty
            if (txtTexturesPath.Text != null)
            {
                // Check if this path exists
                if (Directory.Exists(szWorkingDir))
                {
                    // Get existing files
                    szFiles = Directory.GetFiles(szWorkingDir);

                    // Got any files?
                    if (szFiles.Length > 0)
                    {
                        // Declare at this point
                        Globals.g_szTextureFiles = new string[Globals.MAXTEXTURES];
                        Globals.g_iNumTextureFiles = 0;

                        // Loop each texture
                        for (int i = 0; i < szFiles.Length; i++)
                        {
                            // Get extension of current texture
                            string ext = Path.GetExtension(szFiles[i]);

                            // Only .BMP textures
                            if (String.Equals(ext, Globals.g_szFormats[2], StringComparison.CurrentCultureIgnoreCase))
                            {
                                // Include current texture
                                Globals.g_szTextureFiles[Globals.g_iNumTextureFiles] = Path.GetFileNameWithoutExtension(szFiles[i]);
                                Globals.g_iNumTextureFiles++;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Textures directory is empty, aborting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Textures directory does not exist, aborting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Build the detail textures script
            MakeDetailScript();
        }

        //==============================
        // MakeDetailScript()
        // Generate detail textures list
        //==============================
        private void MakeDetailScript()
        {
            Globals.g_szScriptData = new List<string>();

            string[] szSubstrings = null;

            // Is there anything to write at all
            if (Globals.g_iNumMaterialTextures < 1)
            {
                // No material definitions found inside material files
                MessageBox.Show("No materials to read!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Loop parsed textures
            for (int i = 0; i < Globals.g_iNumTextureFiles; i++)
            {
                bool bMatch = false;

                // Loop parsed material texture names
                for (int j = 0; j < Globals.g_iNumMaterialTextures; j++)
                {
                    // Split material key from material texture
                    szSubstrings = Globals.g_szMaterialTextures[j].Split(new string[] { " " }, StringSplitOptions.None);

                    // Check if material texture matches any part of the current texture name
                    if (Globals.g_szTextureFiles[i].Contains(szSubstrings[1]))
                    {
                        bMatch = true;

                        // Loop materials
                        for (int k = 0; k < Globals.g_iNumMaterials; k++)
                        {
                            // Gotta find if material key exists in the recognized material key set
                            if (Globals.g_szMaterials[k, 0].Equals(szSubstrings[0], StringComparison.CurrentCultureIgnoreCase))
                            {
                                // Add to the script data list
                                Globals.g_szScriptData.Add(Globals.g_szTextureFiles[i] + " " + Path.GetFileNameWithoutExtension(Globals.g_szMaterials[k, 2]));
                                break;
                            }
                        }

                        break;
                    }
                }

                // Current texture isn't specified in the material file
                if (!bMatch)
                {
                    // Set the default material for it
                    Globals.g_szScriptData.Add(Globals.g_szTextureFiles[i] + " " + Path.GetFileNameWithoutExtension(Globals.g_szMaterials[0, 2]));
                }
            }

            // Write the script
            WriteScript();
        }

        //==============================
        // WriteScript()
        // Write existing virtual script file
        //==============================
        private void WriteScript()
        {
            // Open folder browser dialog
            if (fbdDetail.ShowDialog() == DialogResult.Cancel)
                return;

            // Generate flag script in textures folder
            string szFinalPath = String.Concat(fbdDetail.SelectedPath, @"\detailtextures.txt");

            // Does a detail script exist already
            if (File.Exists(szFinalPath))
            {
                DialogResult Result = MessageBox.Show("detailtextures.txt already exists, do you want to overwrite?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (Result == DialogResult.No)
                    return;
            }

            try
            {
                // Create a writer and open the file
                TextWriter tw = new StreamWriter(szFinalPath);

                // Write what we gathered
                for (int i = 0; i < Globals.g_szScriptData.Count; i++)
                    tw.WriteLine(Globals.g_szScriptData[i]);

                // Close the stream
                tw.Close();

                // Sucessfully generated file
                MessageBox.Show("Detail script successfully generated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                // Generation failed
                MessageBox.Show("Could not generate detail script, make sure the existing file is not Read-only.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        //==============================
        // SaveUserSettings()
        // Save application data
        //==============================
        private void SaveUserSettings()
        {
            // Save user material info
            GenerateMaterialList();

            // Save application control info
            GenerateUserDataFile();
        }

        //==============================
        // GenerateMaterialList()
        // Generate Material list data
        //==============================
        private void GenerateMaterialList()
        {
            // Get user material data file directorty
            CreateFilePath(true, Globals.FILETYPE_MATLIST);

            try
            {
                // Create a writer and open the file
                TextWriter tw = new StreamWriter(Globals.g_szUserDataDir);

                // Header
                tw.WriteLine("// Material list data (do not modify)");
                tw.WriteLine("// " + DateTime.Now);

                tw.WriteLine();
                tw.WriteLine();
                tw.WriteLine();

                for (int i = 0; i < Globals.g_iNumMaterials; i++)
                {
                    tw.WriteLine("block" + Globals.CONTROLDELIMITER + i);
                    tw.WriteLine(Globals.g_szMaterials[i, 0]);
                    tw.WriteLine(Globals.g_szMaterials[i, 1]);
                    tw.WriteLine(Globals.g_szMaterials[i, 2]);

                    tw.WriteLine();
                    tw.WriteLine();
                }

                tw.WriteLine();
                tw.WriteLine("Total materials" + Globals.CONTROLDELIMITER + Globals.g_iNumMaterials);

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
        // GenerateUserDataFile()
        // Save relevant control state to user file
        //==============================
        private void GenerateUserDataFile()
        {
            // Get user config data file directorty
            CreateFilePath(true, Globals.FILETYPE_USERDATA);

            // No custom text entered
            if (txtMaterialsPath.Text == Globals.MATERIALSPATHTEXT)
                txtMaterialsPath.Clear();

            // No custom text entered
            if (txtTexturesPath.Text == Globals.TEXTURESPATHTEXT)
                txtTexturesPath.Clear();

            try
            {
                // Create a writer and open the file
                TextWriter tw = new StreamWriter(Globals.g_szUserDataDir);

                // Header
                tw.WriteLine("// User settings data file (do not modify)");
                tw.WriteLine("// " + DateTime.Now);

                tw.WriteLine();

                // Write settings
                tw.WriteLine(txtTexturesPath.Name + Globals.CONTROLDELIMITER + txtTexturesPath.Text);
                tw.WriteLine(txtMaterialsPath.Name + Globals.CONTROLDELIMITER + txtMaterialsPath.Text);

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
            // Get user material info
            ReadMaterialList();

            // Get application control info
            ReadUserDataFile();
        }

        //==============================
        // ReadMaterialList()
        // Load saved material data list if existent
        //==============================
        private void ReadMaterialList()
        {
            // Get user material data file directorty
            CreateFilePath(false, Globals.FILETYPE_MATLIST);

            try
            {
                // Create reader & open file
                TextReader tr = new StreamReader(Globals.g_szUserDataDir);

                // Current line
                string szCurLine;

                string[] szSubstrings = null;

                int numblock;

                // Get line string
                szCurLine = tr.ReadLine();

                // Loop the whole file
                while (szCurLine != null)
                {
                    // Search for data blocks
                    if (szCurLine.Contains("block"))
                    {
                        // Split desired value from current string
                        szSubstrings = szCurLine.Split(new string[] { Globals.CONTROLDELIMITER }, StringSplitOptions.None);

                        numblock = Convert.ToInt32(szSubstrings[1]);

                        // Refill material array
                        Globals.g_szMaterials[numblock, 0] = tr.ReadLine();
                        Globals.g_szMaterials[numblock, 1] = tr.ReadLine();
                        Globals.g_szMaterials[numblock, 2] = tr.ReadLine();
                    }

                    // Search for material blocks count
                    if (szCurLine.Contains("Total materials"))
                    {
                        // Split desired value from current string
                        szSubstrings = szCurLine.Split(new string[] { Globals.CONTROLDELIMITER }, StringSplitOptions.None);

                        Globals.g_iNumMaterials = Convert.ToInt32(szSubstrings[1]);
                    }

                    // Move to next line
                    szCurLine = tr.ReadLine();
                }

                // Close the stream
                tr.Close();
            }
            catch
            {
                // Could not read the data correctly :(

                // Bother to loop the whole shit because YES!
                for (int i = 0; i < Globals.MAXMATERIALS; i++)
                {
                    Globals.g_szMaterials[i, 0] = null;
                    Globals.g_szMaterials[i, 1] = null;
                    Globals.g_szMaterials[i, 2] = null;
                }

                // And make sure this is reset too
                Globals.g_iNumMaterials = 0;
            }
        }

        //==============================
        // ReadUserDataFile()
        // Load saved control state list if existent
        //==============================
        private void ReadUserDataFile()
        {
            // Get user config data file directorty
            CreateFilePath(false, Globals.FILETYPE_USERDATA);

            try
            {
                // Create reader & open file
                TextReader tr = new StreamReader(Globals.g_szUserDataDir);

                Globals.g_szUserData = new List<string>();

                // Current line
                string szCurLine;

                // Get line string
                szCurLine = tr.ReadLine();

                // Loop the whole file
                while (szCurLine != null)
                {
                    Globals.g_szUserData.Add(szCurLine);
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
                txtTexturesPath.Text = Globals.TEXTURESPATHTEXT;
                txtMaterialsPath.Text = Globals.MATERIALSPATHTEXT;
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

            // txtTexturesPath
            txtMaterialsPath.Text = (GetValue(txtMaterialsPath.Name)).ToString();
        }

        //==============================
        // GetValue()
        // Loop state list for wanted control value
        //==============================
        private string GetValue(string szControlName)
        {
            string[] szSubstrings = null;

            // Loop the list
            for (int i = 0; i < Globals.g_szUserData.Count; i++)
            {
                // Check if current string bears the specific control name
                if (Globals.g_szUserData[i].Contains(szControlName))
                {
                    // Split desired control value from current string
                    szSubstrings = Globals.g_szUserData[i].Split(new string[] { Globals.CONTROLDELIMITER }, StringSplitOptions.None);
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
        private void CreateFilePath(bool bCreate, int iType)
        {
            // Get user application data folder
            string szAppdataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            // Application folder
            string szScriptToolDir = String.Concat(szAppdataDir, @"\Detail Tool\");

            // Create the folder if necessary
            if (bCreate == true)
                Directory.CreateDirectory(szScriptToolDir);

            // Mount the full directory
            if (iType == Globals.FILETYPE_MATLIST)
                Globals.g_szUserDataDir = String.Concat(szScriptToolDir, Globals.MATERIALDATAFILENAME);
            else if (iType == Globals.FILETYPE_USERDATA)
                Globals.g_szUserDataDir = String.Concat(szScriptToolDir, Globals.USERDATAFILENAME);
            else
                MessageBox.Show("Invalid reference type value sent to CreateFilePath().", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //==============================
        // ExitApp()
        // Wrap everything up and exit
        //==============================
        private void ExitApp(object sender, EventArgs e)
        {
            // Save user settings
            SaveUserSettings();

            // Close and dispose
            Close();
            Dispose();
        }
    }
}
