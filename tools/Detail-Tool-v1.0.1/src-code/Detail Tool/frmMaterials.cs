using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Detail_Tool
{
    /*
     * frmMaterials - Textures and materials management form.
     */

    public partial class frmMaterials : Form
    {
        // Variables exclusive to this class
        bool m_bDeleting;
        bool m_bEditing;
        int m_iCurIndex;
        string m_szCurMat;

        public frmMaterials()
        {
            InitializeComponent();
        }

        private void frmMaterials_Load(object sender, EventArgs e)
        {
            // At form load
            UpdateKeys();

            // Center form to parent form
            this.CenterToParent();

            // Repopulate listboxes with saved data
            for (int i = 0; Globals.g_szMaterials[i, 0] != null; i++)
            {
                lstMatType.Items.Add(Globals.g_szMaterials[i, 0]);
                lstMatName.Items.Add(Globals.g_szMaterials[i, 1]);
                lstMatTexture.Items.Add(Globals.g_szMaterials[i, 2]);
            }
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            // Make sure no text boxes are empty
            if (txtMatType.Text == "" || txtMatName.Text == "" || txtMatTexture.Text == "")
            {
                MessageBox.Show("One or more required fields are empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Don't add the same key twice
                if (lstMatType.Items.Contains(txtMatType.Text))
                {
                    MessageBox.Show("Specified key already in use.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Get extension of current file
                    string ext = Path.GetExtension(txtMatTexture.Text);

                    bool extmatch = false;

                    // Match to one of the recognized formats
                    for (int i = 0; i < Globals.g_szFormats.Length; i++)
                    {
                        if (String.Equals(ext, Globals.g_szFormats[i]))
                        {
                            // Found a match
                            extmatch = true;
                            break;
                        }
                    }

                    if (extmatch)
                    {
                        // Insert entry
                        lstMatType.Items.Add(txtMatType.Text);
                        lstMatName.Items.Add(txtMatName.Text);
                        lstMatTexture.Items.Add(txtMatTexture.Text);

                        // Add to the array
                        Globals.g_szMaterials[Globals.g_iNumMaterials, 0] = txtMatType.Text;
                        Globals.g_szMaterials[Globals.g_iNumMaterials, 1] = txtMatName.Text;
                        Globals.g_szMaterials[Globals.g_iNumMaterials, 2] = txtMatTexture.Text;

                        Globals.g_iNumMaterials++;

                        // Reset content
                        ClearTextboxes();

                        // Available keys
                        UpdateKeys();
                    }
                    else
                    {
                        MessageBox.Show("Unallowed file type selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            // Make sure there is something to delete
            if (Globals.g_iNumMaterials > 0)
            {
                // No indexes below zero
                if (lstMatType.SelectedIndex >= 0 || lstMatName.SelectedIndex >= 0 || lstMatTexture.SelectedIndex >= 0)
                {
                    m_bDeleting = true;

                    // Remove entry at current index
                    lstMatType.Items.RemoveAt(lstMatType.SelectedIndex);
                    lstMatName.Items.RemoveAt(lstMatName.SelectedIndex);
                    lstMatTexture.Items.RemoveAt(lstMatTexture.SelectedIndex);

                    // Delete also from the array and push following entries over the deleted one
                    for (int i = 0; m_iCurIndex + i < Globals.g_iNumMaterials - 1; i++)
                    {
                        Globals.g_szMaterials[m_iCurIndex + i, 0] = Globals.g_szMaterials[m_iCurIndex + i + 1, 0];
                        Globals.g_szMaterials[m_iCurIndex + i, 1] = Globals.g_szMaterials[m_iCurIndex + i + 1, 1];
                        Globals.g_szMaterials[m_iCurIndex + i, 2] = Globals.g_szMaterials[m_iCurIndex + i + 1, 2];
                    }

                    Globals.g_iNumMaterials--;

                    // And delete the copy of the last entry
                    Globals.g_szMaterials[Globals.g_iNumMaterials, 0] = null;
                    Globals.g_szMaterials[Globals.g_iNumMaterials, 1] = null;
                    Globals.g_szMaterials[Globals.g_iNumMaterials, 2] = null;

                    m_bDeleting = false;

                    // Available keys
                    UpdateKeys();
                }
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            // A global variable is used to call the current selected index on this function because of an issue related to the local variable
            // resetting itself by the time it is called to an argument that removes a list entry at specified index, causing the application to crash.

            // The reason for the crash wasn't searched so the cause remains unknown.

            // In what state is the object function?
            if (m_bEditing)
            {
                // Make sure no text boxes are empty
                if (txtMatType.Text == "" || txtMatName.Text == "" || txtMatTexture.Text == "")
                {
                    MessageBox.Show("One or more required fields are empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Don't add the same key twice
                    if (lstMatType.Items.Contains(txtMatType.Text))
                    {
                        // But discard the currently selected one
                        if (m_szCurMat != txtMatType.Text)
                        {
                            MessageBox.Show("Specified key already in use.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            // Get extension of current file
                            string ext = Path.GetExtension(txtMatTexture.Text);

                            bool extmatch = false;

                            // Match to one of the recognized formats
                            for (int i = 0; i < Globals.g_szFormats.Length; i++)
                            {
                                if (String.Equals(ext, Globals.g_szFormats[i]))
                                {
                                    // Found a match
                                    extmatch = true;
                                    break;
                                }
                            }

                            if (extmatch)
                            {
                                // Remove entry at current index
                                lstMatType.Items.RemoveAt(Globals.g_iCurIndex);
                                lstMatName.Items.RemoveAt(Globals.g_iCurIndex);
                                lstMatTexture.Items.RemoveAt(Globals.g_iCurIndex);

                                // And insert entry in old index
                                lstMatType.Items.Insert(Globals.g_iCurIndex, txtMatType.Text);
                                lstMatName.Items.Insert(Globals.g_iCurIndex, txtMatName.Text);
                                lstMatTexture.Items.Insert(Globals.g_iCurIndex, txtMatTexture.Text);

                                // Add to the array
                                Globals.g_szMaterials[Globals.g_iCurIndex, 0] = txtMatType.Text;
                                Globals.g_szMaterials[Globals.g_iCurIndex, 1] = txtMatName.Text;
                                Globals.g_szMaterials[Globals.g_iCurIndex, 2] = txtMatTexture.Text;

                                // Reset content
                                ClearTextboxes();

                                // Re-enable these objects
                                cmdAdd.Enabled = true;
                                cmdDelete.Enabled = true;

                                // Change the button's description
                                cmdEdit.Text = "Edit";

                                // Re-allow the lists
                                lstMatType.Enabled = true;
                                lstMatName.Enabled = true;
                                lstMatTexture.Enabled = true;

                                // Left edit mode
                                m_bEditing = false;

                                // Available keys
                                UpdateKeys();
                            }
                            else
                            {
                                MessageBox.Show("Unallowed file type selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    else
                    {
                        // Get extension of current file
                        string ext = Path.GetExtension(txtMatTexture.Text);

                        bool extmatch = false;

                        // Match to one of the recognized formats
                        for (int i = 0; i < Globals.g_szFormats.Length; i++)
                        {
                            if (String.Equals(ext, Globals.g_szFormats[i]))
                            {
                                // Found a match
                                extmatch = true;
                                break;
                            }
                        }

                        if (extmatch)
                        {
                            // Remove entry at current index
                            lstMatType.Items.RemoveAt(Globals.g_iCurIndex);
                            lstMatName.Items.RemoveAt(Globals.g_iCurIndex);
                            lstMatTexture.Items.RemoveAt(Globals.g_iCurIndex);

                            // And insert entry in old index
                            lstMatType.Items.Insert(Globals.g_iCurIndex, txtMatType.Text);
                            lstMatName.Items.Insert(Globals.g_iCurIndex, txtMatName.Text);
                            lstMatTexture.Items.Insert(Globals.g_iCurIndex, txtMatTexture.Text);

                            // Add to the array
                            Globals.g_szMaterials[Globals.g_iCurIndex, 0] = txtMatType.Text;
                            Globals.g_szMaterials[Globals.g_iCurIndex, 1] = txtMatName.Text;
                            Globals.g_szMaterials[Globals.g_iCurIndex, 2] = txtMatTexture.Text;

                            // Reset content
                            ClearTextboxes();

                            // Re-enable these objects
                            cmdAdd.Enabled = true;
                            cmdDelete.Enabled = true;

                            // Change the button's description
                            cmdEdit.Text = "Edit";

                            // Re-allow the lists
                            lstMatType.Enabled = true;
                            lstMatName.Enabled = true;
                            lstMatTexture.Enabled = true;

                            // Left edit mode
                            m_bEditing = false;

                            // Available keys
                            UpdateKeys();
                        }
                        else
                        {
                            MessageBox.Show("Unallowed file type selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            else
            {
                // Make sure there is something to edit
                if (Globals.g_iNumMaterials > 0)
                {
                    // No indexes below zero
                    if (lstMatType.SelectedIndex >= 0 || lstMatName.SelectedIndex >= 0 || lstMatTexture.SelectedIndex >= 0)
                    {
                        // Entered edit mode
                        m_bEditing = true;

                        // Disable these objects
                        cmdAdd.Enabled = false;
                        cmdDelete.Enabled = false;

                        // Change the button's description
                        cmdEdit.Text = "Done";

                        // Save index to globals
                        Globals.g_iCurIndex = m_iCurIndex;

                        // Save the material type key too
                        m_szCurMat = lstMatType.SelectedItem.ToString();

                        // Copy the text of the selected entries to the textboxes
                        txtMatType.Text = Globals.g_szMaterials[lstMatType.SelectedIndex, 0];
                        txtMatName.Text = Globals.g_szMaterials[lstMatName.SelectedIndex, 1];
                        txtMatTexture.Text = Globals.g_szMaterials[lstMatTexture.SelectedIndex, 2];

                        // Disallow the lists
                        lstMatType.Enabled = false;
                        lstMatName.Enabled = false;
                        lstMatTexture.Enabled = false;

                        // Available keys
                        UpdateKeys();
                    }
                }
            }
        }

        private void cmdTextureBrowse_Click(object sender, EventArgs e)
        {
            // Open file browser dialog
            if (ofdBrowseTexture.ShowDialog() == DialogResult.OK)
            {
                // Get selected file path
                this.txtMatTexture.Text = ofdBrowseTexture.FileName;
            }
        }

        private void lstMatTexture_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Prevent updating index value if were deleting an entry
            if (!m_bDeleting)
                EqualizeIndexes(lstMatTexture.SelectedIndex);
        }

        private void lstMatName_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Prevent updating index value if were deleting an entry
            if (!m_bDeleting)
                EqualizeIndexes(lstMatName.SelectedIndex);
        }

        private void lstMatType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Prevent updating index value if were deleting an entry
            if (!m_bDeleting)
                EqualizeIndexes(lstMatType.SelectedIndex);
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            if (m_bEditing)
            {
                DialogResult Result = MessageBox.Show("Changes made so far will be lost, continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // Save first
                if (Result == DialogResult.Yes)
                {
                    // Close and dispose
                    Close();
                    Dispose();
                }
            }
            else
            {
                // Close and dispose
                Close();
                Dispose();
            }
        }

        //==============================
        // ClearTextboxes()
        // Erase entered text on all textboxes
        //==============================
        private void ClearTextboxes()
        {
            txtMatType.Clear();
            txtMatName.Clear();
            txtMatTexture.Clear();
        }


        //==============================
        // EqualizeIndexes()
        // Connect index selection on all lists
        //==============================
        private void EqualizeIndexes(int listindex)
        {
            lstMatType.SelectedIndex = listindex;
            lstMatName.SelectedIndex = listindex;
            lstMatTexture.SelectedIndex = listindex;

            m_iCurIndex = listindex;
        }

        //==============================
        // UpdateKeys()
        // Isolate unused material keys
        //==============================
        private void UpdateKeys()
        {
            string szKeys = Globals.ALLOWEDCHARACTERS;

            // Loop used keys
            for (int i = 0; i < Globals.g_iNumMaterials; i++)
            {
                // Match used keys
                if (szKeys.Contains(Globals.g_szMaterials[i, 0]))
                {
                    int pos;

                    // Found match, find index in material array
                    pos = szKeys.IndexOf(Globals.g_szMaterials[i, 0]);

                    // Remove from unused keys
                    szKeys = szKeys.Remove(pos, 1);
                }
            }

            // Send to global var
            Globals.g_szUsableKeys = szKeys;

            // Now that we isolated the unused keys, highlight the labels whose key isn't currently in use
            lblQ.Enabled = CheckLabelState(lblQ.Name);
            lblW.Enabled = CheckLabelState(lblW.Name);
            lblE.Enabled = CheckLabelState(lblE.Name);
            lblR.Enabled = CheckLabelState(lblR.Name);
            lblT.Enabled = CheckLabelState(lblT.Name);
            lblY.Enabled = CheckLabelState(lblY.Name);
            lblU.Enabled = CheckLabelState(lblU.Name);
            lblI.Enabled = CheckLabelState(lblI.Name);
            lblO.Enabled = CheckLabelState(lblO.Name);
            lblP.Enabled = CheckLabelState(lblP.Name);
            lblA.Enabled = CheckLabelState(lblA.Name);
            lblS.Enabled = CheckLabelState(lblS.Name);
            lblD.Enabled = CheckLabelState(lblD.Name);
            lblF.Enabled = CheckLabelState(lblF.Name);
            lblG.Enabled = CheckLabelState(lblG.Name);
            lblH.Enabled = CheckLabelState(lblH.Name);
            lblJ.Enabled = CheckLabelState(lblJ.Name);
            lblK.Enabled = CheckLabelState(lblK.Name);
            lblL.Enabled = CheckLabelState(lblL.Name);
            lblZ.Enabled = CheckLabelState(lblZ.Name);
            lblX.Enabled = CheckLabelState(lblX.Name);
            lblC.Enabled = CheckLabelState(lblC.Name);
            lblV.Enabled = CheckLabelState(lblV.Name);
            lblB.Enabled = CheckLabelState(lblB.Name);
            lblN.Enabled = CheckLabelState(lblN.Name);
            lblM.Enabled = CheckLabelState(lblM.Name);
        }

        //==============================
        // CheckLabelState()
        // Check the state of the handled label name
        //==============================
        private bool CheckLabelState(string szName)
        {
            // szLabelKey is assigned the value of szName which contains a string representing the name
            // of a specific object, material key labels always include the key they represent in it's object name
            // so by removing the type prefix from it leaves the name string with only the key character.

            // First make sure we were handled a string with pretended syntax
            if (szName.StartsWith("lbl"))
            {
                // Remove first three letters from the inherited string
                string szLabelKey = szName.Remove(0, 3);

                for (int i = 0; i < Globals.g_szUsableKeys.Length; i++)
                {
                    // Look for respective label character
                    if (Globals.g_szUsableKeys.Contains(szLabelKey))
                    {
                        // Found match
                        return true;
                    }
                    else
                    {
                        // Found nothing
                        return false;
                    }
                }
            }

            return false;
        }

        //==============================
        // ValidateString()
        // Validation of a string with a key limit
        //==============================
        private void ValidateString(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;

            string szVal = txt.Text.ToString();

            // Look for specific control name
            if (txt.Name == txtMatType.Name)
            {
                // Only allow specified characters
                if (Globals.ALLOWEDCHARACTERS.Contains(szVal))
                {
                    // Only one key allowed
                    if (szVal.Length > 1)
                    {
                        // Delete new key
                        int CursorIndex = txt.SelectionStart - 1;
                        txt.Text = txt.Text.Remove(CursorIndex, 1);

                        // Align Cursor to same index
                        txt.SelectionStart = CursorIndex;
                        txt.SelectionLength = 0;

                        System.Media.SystemSounds.Beep.Play();
                    }
                }
                else
                {
                    // Delete undesired key
                    int CursorIndex = txt.SelectionStart - 1;
                    txt.Text = txt.Text.Remove(CursorIndex, 1);

                    // Align Cursor to same index
                    txt.SelectionStart = CursorIndex;
                    txt.SelectionLength = 0;

                    System.Media.SystemSounds.Beep.Play();
                }
            }
            else
            {
                // Only this much keys allowed
                if (szVal.Length > Globals.MAXKEYS)
                {
                    // Delete new key
                    int CursorIndex = txt.SelectionStart - 1;
                    txt.Text = txt.Text.Remove(CursorIndex, 1);

                    // Align Cursor to same index
                    txt.SelectionStart = CursorIndex;
                    txt.SelectionLength = 0;

                    System.Media.SystemSounds.Beep.Play();
                }
            }
        }
    }
}
