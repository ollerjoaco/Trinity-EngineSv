namespace Detail_Tool
{
    partial class frmMaterials
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMaterials));
            this.cmdAdd = new System.Windows.Forms.Button();
            this.lblMatType = new System.Windows.Forms.Label();
            this.txtMatType = new System.Windows.Forms.TextBox();
            this.gbxAddMaterial = new System.Windows.Forms.GroupBox();
            this.lblDefault = new System.Windows.Forms.Label();
            this.cmdTextureBrowse = new System.Windows.Forms.Button();
            this.txtMatTexture = new System.Windows.Forms.TextBox();
            this.lblMatTexture = new System.Windows.Forms.Label();
            this.lblMatName = new System.Windows.Forms.Label();
            this.txtMatName = new System.Windows.Forms.TextBox();
            this.cmdClose = new System.Windows.Forms.Button();
            this.ofdBrowseTexture = new System.Windows.Forms.OpenFileDialog();
            this.lblMaterials = new System.Windows.Forms.Label();
            this.lblQ = new System.Windows.Forms.Label();
            this.lblE = new System.Windows.Forms.Label();
            this.lblW = new System.Windows.Forms.Label();
            this.lblR = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.lblT = new System.Windows.Forms.Label();
            this.lblU = new System.Windows.Forms.Label();
            this.lblO = new System.Windows.Forms.Label();
            this.lblI = new System.Windows.Forms.Label();
            this.lblP = new System.Windows.Forms.Label();
            this.lblS = new System.Windows.Forms.Label();
            this.lblA = new System.Windows.Forms.Label();
            this.lblD = new System.Windows.Forms.Label();
            this.lblG = new System.Windows.Forms.Label();
            this.lblF = new System.Windows.Forms.Label();
            this.lblH = new System.Windows.Forms.Label();
            this.lblK = new System.Windows.Forms.Label();
            this.lblJ = new System.Windows.Forms.Label();
            this.lblL = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.lblZ = new System.Windows.Forms.Label();
            this.lblC = new System.Windows.Forms.Label();
            this.lblB = new System.Windows.Forms.Label();
            this.lblV = new System.Windows.Forms.Label();
            this.lblM = new System.Windows.Forms.Label();
            this.lblN = new System.Windows.Forms.Label();
            this.lstMatType = new System.Windows.Forms.ListBox();
            this.lstMatName = new System.Windows.Forms.ListBox();
            this.lstMatTexture = new System.Windows.Forms.ListBox();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.gbxManageMaterials = new System.Windows.Forms.GroupBox();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.gbxAddMaterial.SuspendLayout();
            this.gbxManageMaterials.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(334, 51);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(270, 23);
            this.cmdAdd.TabIndex = 8;
            this.cmdAdd.Text = "Add";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // lblMatType
            // 
            this.lblMatType.Location = new System.Drawing.Point(6, 16);
            this.lblMatType.Name = "lblMatType";
            this.lblMatType.Size = new System.Drawing.Size(32, 23);
            this.lblMatType.TabIndex = 1;
            this.lblMatType.Text = "Key:";
            this.lblMatType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMatType
            // 
            this.txtMatType.Location = new System.Drawing.Point(44, 18);
            this.txtMatType.Name = "txtMatType";
            this.txtMatType.Size = new System.Drawing.Size(42, 20);
            this.txtMatType.TabIndex = 2;
            this.txtMatType.TextChanged += new System.EventHandler(this.ValidateString);
            // 
            // gbxAddMaterial
            // 
            this.gbxAddMaterial.Controls.Add(this.lblDefault);
            this.gbxAddMaterial.Controls.Add(this.cmdTextureBrowse);
            this.gbxAddMaterial.Controls.Add(this.txtMatTexture);
            this.gbxAddMaterial.Controls.Add(this.lblMatTexture);
            this.gbxAddMaterial.Controls.Add(this.lblMatName);
            this.gbxAddMaterial.Controls.Add(this.txtMatName);
            this.gbxAddMaterial.Controls.Add(this.lblMatType);
            this.gbxAddMaterial.Controls.Add(this.txtMatType);
            this.gbxAddMaterial.Controls.Add(this.cmdAdd);
            this.gbxAddMaterial.Location = new System.Drawing.Point(12, 12);
            this.gbxAddMaterial.Name = "gbxAddMaterial";
            this.gbxAddMaterial.Size = new System.Drawing.Size(610, 80);
            this.gbxAddMaterial.TabIndex = 0;
            this.gbxAddMaterial.TabStop = false;
            this.gbxAddMaterial.Text = "Add material";
            // 
            // lblDefault
            // 
            this.lblDefault.Location = new System.Drawing.Point(6, 51);
            this.lblDefault.Name = "lblDefault";
            this.lblDefault.Size = new System.Drawing.Size(268, 23);
            this.lblDefault.TabIndex = 9;
            this.lblDefault.Text = "Note: First entry in the list is the default material.";
            this.lblDefault.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdTextureBrowse
            // 
            this.cmdTextureBrowse.Location = new System.Drawing.Point(529, 16);
            this.cmdTextureBrowse.Name = "cmdTextureBrowse";
            this.cmdTextureBrowse.Size = new System.Drawing.Size(75, 23);
            this.cmdTextureBrowse.TabIndex = 7;
            this.cmdTextureBrowse.Text = "Browse";
            this.cmdTextureBrowse.UseVisualStyleBackColor = true;
            this.cmdTextureBrowse.Click += new System.EventHandler(this.cmdTextureBrowse_Click);
            // 
            // txtMatTexture
            // 
            this.txtMatTexture.Location = new System.Drawing.Point(334, 18);
            this.txtMatTexture.Name = "txtMatTexture";
            this.txtMatTexture.ReadOnly = true;
            this.txtMatTexture.Size = new System.Drawing.Size(189, 20);
            this.txtMatTexture.TabIndex = 6;
            // 
            // lblMatTexture
            // 
            this.lblMatTexture.Location = new System.Drawing.Point(280, 16);
            this.lblMatTexture.Name = "lblMatTexture";
            this.lblMatTexture.Size = new System.Drawing.Size(48, 23);
            this.lblMatTexture.TabIndex = 5;
            this.lblMatTexture.Text = "Texture:";
            this.lblMatTexture.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMatName
            // 
            this.lblMatName.Location = new System.Drawing.Point(92, 16);
            this.lblMatName.Name = "lblMatName";
            this.lblMatName.Size = new System.Drawing.Size(48, 23);
            this.lblMatName.TabIndex = 3;
            this.lblMatName.Text = "Name:";
            this.lblMatName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMatName
            // 
            this.txtMatName.Location = new System.Drawing.Point(146, 18);
            this.txtMatName.Name = "txtMatName";
            this.txtMatName.Size = new System.Drawing.Size(128, 20);
            this.txtMatName.TabIndex = 4;
            this.txtMatName.TextChanged += new System.EventHandler(this.ValidateString);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(547, 322);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 42;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // lblMaterials
            // 
            this.lblMaterials.Location = new System.Drawing.Point(12, 317);
            this.lblMaterials.Name = "lblMaterials";
            this.lblMaterials.Size = new System.Drawing.Size(68, 31);
            this.lblMaterials.TabIndex = 15;
            this.lblMaterials.Text = "Usable keys:";
            this.lblMaterials.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblQ
            // 
            this.lblQ.Location = new System.Drawing.Point(86, 317);
            this.lblQ.Name = "lblQ";
            this.lblQ.Size = new System.Drawing.Size(10, 32);
            this.lblQ.TabIndex = 16;
            this.lblQ.Text = "Q";
            this.lblQ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblE
            // 
            this.lblE.Location = new System.Drawing.Point(118, 317);
            this.lblE.Name = "lblE";
            this.lblE.Size = new System.Drawing.Size(10, 32);
            this.lblE.TabIndex = 18;
            this.lblE.Text = "E";
            this.lblE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblW
            // 
            this.lblW.Location = new System.Drawing.Point(102, 317);
            this.lblW.Name = "lblW";
            this.lblW.Size = new System.Drawing.Size(10, 32);
            this.lblW.TabIndex = 17;
            this.lblW.Text = "W";
            this.lblW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblR
            // 
            this.lblR.Location = new System.Drawing.Point(134, 317);
            this.lblR.Name = "lblR";
            this.lblR.Size = new System.Drawing.Size(10, 32);
            this.lblR.TabIndex = 19;
            this.lblR.Text = "R";
            this.lblR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblY
            // 
            this.lblY.Location = new System.Drawing.Point(166, 317);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(10, 32);
            this.lblY.TabIndex = 21;
            this.lblY.Text = "Y";
            this.lblY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblT
            // 
            this.lblT.Location = new System.Drawing.Point(150, 317);
            this.lblT.Name = "lblT";
            this.lblT.Size = new System.Drawing.Size(10, 32);
            this.lblT.TabIndex = 20;
            this.lblT.Text = "T";
            this.lblT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblU
            // 
            this.lblU.Location = new System.Drawing.Point(182, 317);
            this.lblU.Name = "lblU";
            this.lblU.Size = new System.Drawing.Size(10, 32);
            this.lblU.TabIndex = 22;
            this.lblU.Text = "U";
            this.lblU.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblO
            // 
            this.lblO.Location = new System.Drawing.Point(214, 317);
            this.lblO.Name = "lblO";
            this.lblO.Size = new System.Drawing.Size(10, 32);
            this.lblO.TabIndex = 24;
            this.lblO.Text = "O";
            this.lblO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblI
            // 
            this.lblI.Location = new System.Drawing.Point(198, 317);
            this.lblI.Name = "lblI";
            this.lblI.Size = new System.Drawing.Size(10, 32);
            this.lblI.TabIndex = 23;
            this.lblI.Text = "I";
            this.lblI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblP
            // 
            this.lblP.Location = new System.Drawing.Point(230, 317);
            this.lblP.Name = "lblP";
            this.lblP.Size = new System.Drawing.Size(10, 32);
            this.lblP.TabIndex = 25;
            this.lblP.Text = "P";
            this.lblP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblS
            // 
            this.lblS.Location = new System.Drawing.Point(262, 317);
            this.lblS.Name = "lblS";
            this.lblS.Size = new System.Drawing.Size(10, 32);
            this.lblS.TabIndex = 27;
            this.lblS.Text = "S";
            this.lblS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblA
            // 
            this.lblA.Location = new System.Drawing.Point(246, 317);
            this.lblA.Name = "lblA";
            this.lblA.Size = new System.Drawing.Size(10, 32);
            this.lblA.TabIndex = 26;
            this.lblA.Text = "A";
            this.lblA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblD
            // 
            this.lblD.Location = new System.Drawing.Point(278, 317);
            this.lblD.Name = "lblD";
            this.lblD.Size = new System.Drawing.Size(10, 32);
            this.lblD.TabIndex = 28;
            this.lblD.Text = "D";
            this.lblD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblG
            // 
            this.lblG.Location = new System.Drawing.Point(310, 317);
            this.lblG.Name = "lblG";
            this.lblG.Size = new System.Drawing.Size(10, 32);
            this.lblG.TabIndex = 30;
            this.lblG.Text = "G";
            this.lblG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblF
            // 
            this.lblF.Location = new System.Drawing.Point(294, 317);
            this.lblF.Name = "lblF";
            this.lblF.Size = new System.Drawing.Size(10, 32);
            this.lblF.TabIndex = 29;
            this.lblF.Text = "F";
            this.lblF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblH
            // 
            this.lblH.Location = new System.Drawing.Point(326, 317);
            this.lblH.Name = "lblH";
            this.lblH.Size = new System.Drawing.Size(10, 32);
            this.lblH.TabIndex = 31;
            this.lblH.Text = "H";
            this.lblH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblK
            // 
            this.lblK.Location = new System.Drawing.Point(358, 317);
            this.lblK.Name = "lblK";
            this.lblK.Size = new System.Drawing.Size(10, 32);
            this.lblK.TabIndex = 33;
            this.lblK.Text = "K";
            this.lblK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblJ
            // 
            this.lblJ.Location = new System.Drawing.Point(342, 317);
            this.lblJ.Name = "lblJ";
            this.lblJ.Size = new System.Drawing.Size(10, 32);
            this.lblJ.TabIndex = 32;
            this.lblJ.Text = "J";
            this.lblJ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblL
            // 
            this.lblL.Location = new System.Drawing.Point(374, 317);
            this.lblL.Name = "lblL";
            this.lblL.Size = new System.Drawing.Size(10, 32);
            this.lblL.TabIndex = 34;
            this.lblL.Text = "L";
            this.lblL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblX
            // 
            this.lblX.Location = new System.Drawing.Point(406, 317);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(10, 32);
            this.lblX.TabIndex = 36;
            this.lblX.Text = "X";
            this.lblX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblZ
            // 
            this.lblZ.Location = new System.Drawing.Point(390, 317);
            this.lblZ.Name = "lblZ";
            this.lblZ.Size = new System.Drawing.Size(10, 32);
            this.lblZ.TabIndex = 35;
            this.lblZ.Text = "Z";
            this.lblZ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblC
            // 
            this.lblC.Location = new System.Drawing.Point(422, 317);
            this.lblC.Name = "lblC";
            this.lblC.Size = new System.Drawing.Size(10, 32);
            this.lblC.TabIndex = 37;
            this.lblC.Text = "C";
            this.lblC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblB
            // 
            this.lblB.Location = new System.Drawing.Point(454, 317);
            this.lblB.Name = "lblB";
            this.lblB.Size = new System.Drawing.Size(10, 32);
            this.lblB.TabIndex = 39;
            this.lblB.Text = "B";
            this.lblB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblV
            // 
            this.lblV.Location = new System.Drawing.Point(438, 317);
            this.lblV.Name = "lblV";
            this.lblV.Size = new System.Drawing.Size(10, 32);
            this.lblV.TabIndex = 38;
            this.lblV.Text = "V";
            this.lblV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblM
            // 
            this.lblM.Location = new System.Drawing.Point(486, 317);
            this.lblM.Name = "lblM";
            this.lblM.Size = new System.Drawing.Size(10, 32);
            this.lblM.TabIndex = 41;
            this.lblM.Text = "M";
            this.lblM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblN
            // 
            this.lblN.Location = new System.Drawing.Point(470, 317);
            this.lblN.Name = "lblN";
            this.lblN.Size = new System.Drawing.Size(10, 32);
            this.lblN.TabIndex = 40;
            this.lblN.Text = "N";
            this.lblN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstMatType
            // 
            this.lstMatType.FormattingEnabled = true;
            this.lstMatType.HorizontalScrollbar = true;
            this.lstMatType.Location = new System.Drawing.Point(44, 28);
            this.lstMatType.Name = "lstMatType";
            this.lstMatType.ScrollAlwaysVisible = true;
            this.lstMatType.Size = new System.Drawing.Size(42, 173);
            this.lstMatType.TabIndex = 10;
            this.lstMatType.SelectedIndexChanged += new System.EventHandler(this.lstMatType_SelectedIndexChanged);
            // 
            // lstMatName
            // 
            this.lstMatName.FormattingEnabled = true;
            this.lstMatName.HorizontalScrollbar = true;
            this.lstMatName.Location = new System.Drawing.Point(146, 28);
            this.lstMatName.Name = "lstMatName";
            this.lstMatName.ScrollAlwaysVisible = true;
            this.lstMatName.Size = new System.Drawing.Size(128, 173);
            this.lstMatName.TabIndex = 11;
            this.lstMatName.SelectedIndexChanged += new System.EventHandler(this.lstMatName_SelectedIndexChanged);
            // 
            // lstMatTexture
            // 
            this.lstMatTexture.FormattingEnabled = true;
            this.lstMatTexture.HorizontalScrollbar = true;
            this.lstMatTexture.Location = new System.Drawing.Point(334, 28);
            this.lstMatTexture.Name = "lstMatTexture";
            this.lstMatTexture.ScrollAlwaysVisible = true;
            this.lstMatTexture.Size = new System.Drawing.Size(189, 173);
            this.lstMatTexture.TabIndex = 12;
            this.lstMatTexture.SelectedIndexChanged += new System.EventHandler(this.lstMatTexture_SelectedIndexChanged);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Location = new System.Drawing.Point(529, 86);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(75, 69);
            this.cmdDelete.TabIndex = 14;
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // gbxManageMaterials
            // 
            this.gbxManageMaterials.Controls.Add(this.cmdEdit);
            this.gbxManageMaterials.Controls.Add(this.cmdDelete);
            this.gbxManageMaterials.Controls.Add(this.lstMatTexture);
            this.gbxManageMaterials.Controls.Add(this.lstMatName);
            this.gbxManageMaterials.Controls.Add(this.lstMatType);
            this.gbxManageMaterials.Location = new System.Drawing.Point(12, 98);
            this.gbxManageMaterials.Name = "gbxManageMaterials";
            this.gbxManageMaterials.Size = new System.Drawing.Size(610, 216);
            this.gbxManageMaterials.TabIndex = 9;
            this.gbxManageMaterials.TabStop = false;
            this.gbxManageMaterials.Text = "Manage materials";
            // 
            // cmdEdit
            // 
            this.cmdEdit.Location = new System.Drawing.Point(529, 57);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(75, 23);
            this.cmdEdit.TabIndex = 13;
            this.cmdEdit.Text = "Edit";
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // frmMaterials
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 357);
            this.Controls.Add(this.lblN);
            this.Controls.Add(this.lblM);
            this.Controls.Add(this.lblV);
            this.Controls.Add(this.lblB);
            this.Controls.Add(this.lblC);
            this.Controls.Add(this.lblZ);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.lblL);
            this.Controls.Add(this.lblJ);
            this.Controls.Add(this.lblK);
            this.Controls.Add(this.lblH);
            this.Controls.Add(this.lblF);
            this.Controls.Add(this.lblG);
            this.Controls.Add(this.lblD);
            this.Controls.Add(this.lblA);
            this.Controls.Add(this.lblS);
            this.Controls.Add(this.lblP);
            this.Controls.Add(this.lblI);
            this.Controls.Add(this.lblO);
            this.Controls.Add(this.lblU);
            this.Controls.Add(this.lblT);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.lblR);
            this.Controls.Add(this.lblW);
            this.Controls.Add(this.lblE);
            this.Controls.Add(this.lblQ);
            this.Controls.Add(this.lblMaterials);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.gbxManageMaterials);
            this.Controls.Add(this.gbxAddMaterial);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMaterials";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Material manager";
            this.Load += new System.EventHandler(this.frmMaterials_Load);
            this.gbxAddMaterial.ResumeLayout(false);
            this.gbxAddMaterial.PerformLayout();
            this.gbxManageMaterials.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Label lblMatType;
        private System.Windows.Forms.TextBox txtMatType;
        private System.Windows.Forms.GroupBox gbxAddMaterial;
        private System.Windows.Forms.TextBox txtMatName;
        private System.Windows.Forms.Label lblMatName;
        private System.Windows.Forms.Button cmdTextureBrowse;
        private System.Windows.Forms.TextBox txtMatTexture;
        private System.Windows.Forms.Label lblMatTexture;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.OpenFileDialog ofdBrowseTexture;
        private System.Windows.Forms.Label lblMaterials;
        private System.Windows.Forms.Label lblQ;
        private System.Windows.Forms.Label lblE;
        private System.Windows.Forms.Label lblW;
        private System.Windows.Forms.Label lblR;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblT;
        private System.Windows.Forms.Label lblU;
        private System.Windows.Forms.Label lblO;
        private System.Windows.Forms.Label lblI;
        private System.Windows.Forms.Label lblP;
        private System.Windows.Forms.Label lblS;
        private System.Windows.Forms.Label lblA;
        private System.Windows.Forms.Label lblD;
        private System.Windows.Forms.Label lblG;
        private System.Windows.Forms.Label lblF;
        private System.Windows.Forms.Label lblH;
        private System.Windows.Forms.Label lblK;
        private System.Windows.Forms.Label lblJ;
        private System.Windows.Forms.Label lblL;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblZ;
        private System.Windows.Forms.Label lblC;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.Label lblV;
        private System.Windows.Forms.Label lblM;
        private System.Windows.Forms.Label lblN;
        private System.Windows.Forms.ListBox lstMatType;
        private System.Windows.Forms.ListBox lstMatName;
        private System.Windows.Forms.ListBox lstMatTexture;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.GroupBox gbxManageMaterials;
        private System.Windows.Forms.Button cmdEdit;
        private System.Windows.Forms.Label lblDefault;

    }
}