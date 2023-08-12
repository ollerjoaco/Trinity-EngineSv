namespace Detail_Tool
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.strpmenuApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.strpmenuitemStart = new System.Windows.Forms.ToolStripMenuItem();
            this.strpmenuSeparator01 = new System.Windows.Forms.ToolStripSeparator();
            this.strpmenuitemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.strpmenuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.strpmenuitemMaterials = new System.Windows.Forms.ToolStripMenuItem();
            this.strpmenuInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.strpmenuitemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdStart = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.txtTexturesPath = new System.Windows.Forms.TextBox();
            this.fbdTextures = new System.Windows.Forms.FolderBrowserDialog();
            this.cmdTexturesBrowse = new System.Windows.Forms.Button();
            this.cmdMaterialList = new System.Windows.Forms.Button();
            this.txtMaterialsPath = new System.Windows.Forms.TextBox();
            this.cmdMaterialsBrowser = new System.Windows.Forms.Button();
            this.fbdMaterials = new System.Windows.Forms.FolderBrowserDialog();
            this.fbdDetail = new System.Windows.Forms.FolderBrowserDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.strpmenuApplication,
            this.strpmenuEdit,
            this.strpmenuInfo});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(378, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // strpmenuApplication
            // 
            this.strpmenuApplication.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.strpmenuitemStart,
            this.strpmenuSeparator01,
            this.strpmenuitemClose});
            this.strpmenuApplication.Name = "strpmenuApplication";
            this.strpmenuApplication.Size = new System.Drawing.Size(80, 20);
            this.strpmenuApplication.Text = "Application";
            // 
            // strpmenuitemStart
            // 
            this.strpmenuitemStart.Name = "strpmenuitemStart";
            this.strpmenuitemStart.Size = new System.Drawing.Size(103, 22);
            this.strpmenuitemStart.Text = "Start";
            // 
            // strpmenuSeparator01
            // 
            this.strpmenuSeparator01.Name = "strpmenuSeparator01";
            this.strpmenuSeparator01.Size = new System.Drawing.Size(100, 6);
            // 
            // strpmenuitemClose
            // 
            this.strpmenuitemClose.Name = "strpmenuitemClose";
            this.strpmenuitemClose.Size = new System.Drawing.Size(103, 22);
            this.strpmenuitemClose.Text = "Close";
            this.strpmenuitemClose.Click += new System.EventHandler(this.ExitApp);
            // 
            // strpmenuEdit
            // 
            this.strpmenuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.strpmenuitemMaterials});
            this.strpmenuEdit.Name = "strpmenuEdit";
            this.strpmenuEdit.Size = new System.Drawing.Size(39, 20);
            this.strpmenuEdit.Text = "Edit";
            // 
            // strpmenuitemMaterials
            // 
            this.strpmenuitemMaterials.Name = "strpmenuitemMaterials";
            this.strpmenuitemMaterials.Size = new System.Drawing.Size(135, 22);
            this.strpmenuitemMaterials.Text = "Material list";
            this.strpmenuitemMaterials.Click += new System.EventHandler(this.OpenMaterialList);
            // 
            // strpmenuInfo
            // 
            this.strpmenuInfo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.strpmenuitemAbout});
            this.strpmenuInfo.Name = "strpmenuInfo";
            this.strpmenuInfo.Size = new System.Drawing.Size(40, 20);
            this.strpmenuInfo.Text = "Info";
            // 
            // strpmenuitemAbout
            // 
            this.strpmenuitemAbout.Name = "strpmenuitemAbout";
            this.strpmenuitemAbout.Size = new System.Drawing.Size(107, 22);
            this.strpmenuitemAbout.Text = "About";
            this.strpmenuitemAbout.Click += new System.EventHandler(this.strpmenuitemAbout_Click);
            // 
            // cmdStart
            // 
            this.cmdStart.Location = new System.Drawing.Point(210, 256);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.Size = new System.Drawing.Size(75, 23);
            this.cmdStart.TabIndex = 5;
            this.cmdStart.Text = "Start";
            this.cmdStart.UseVisualStyleBackColor = true;
            this.cmdStart.Click += new System.EventHandler(this.Run);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(291, 256);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 6;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.ExitApp);
            // 
            // txtTexturesPath
            // 
            this.txtTexturesPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTexturesPath.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTexturesPath.Location = new System.Drawing.Point(12, 111);
            this.txtTexturesPath.Name = "txtTexturesPath";
            this.txtTexturesPath.Size = new System.Drawing.Size(354, 20);
            this.txtTexturesPath.TabIndex = 2;
            this.txtTexturesPath.Click += new System.EventHandler(this.txtTexturesPath_Click);
            this.txtTexturesPath.Leave += new System.EventHandler(this.txtTexturesPath_Leave);
            // 
            // fbdTextures
            // 
            this.fbdTextures.Description = "Select the folder where your textures are located";
            // 
            // cmdTexturesBrowse
            // 
            this.cmdTexturesBrowse.Location = new System.Drawing.Point(12, 137);
            this.cmdTexturesBrowse.Name = "cmdTexturesBrowse";
            this.cmdTexturesBrowse.Size = new System.Drawing.Size(354, 23);
            this.cmdTexturesBrowse.TabIndex = 3;
            this.cmdTexturesBrowse.Text = "Browse Textures";
            this.cmdTexturesBrowse.UseVisualStyleBackColor = true;
            this.cmdTexturesBrowse.Click += new System.EventHandler(this.BrowseTexturesPath);
            // 
            // cmdMaterialList
            // 
            this.cmdMaterialList.Location = new System.Drawing.Point(12, 166);
            this.cmdMaterialList.Name = "cmdMaterialList";
            this.cmdMaterialList.Size = new System.Drawing.Size(354, 75);
            this.cmdMaterialList.TabIndex = 4;
            this.cmdMaterialList.Text = "Material manager";
            this.cmdMaterialList.UseVisualStyleBackColor = true;
            this.cmdMaterialList.Click += new System.EventHandler(this.OpenMaterialList);
            // 
            // txtMaterialsPath
            // 
            this.txtMaterialsPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaterialsPath.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtMaterialsPath.Location = new System.Drawing.Point(12, 27);
            this.txtMaterialsPath.Name = "txtMaterialsPath";
            this.txtMaterialsPath.Size = new System.Drawing.Size(354, 20);
            this.txtMaterialsPath.TabIndex = 0;
            this.txtMaterialsPath.Click += new System.EventHandler(this.txtMaterialsPath_Click);
            this.txtMaterialsPath.Leave += new System.EventHandler(this.txtMaterialsPath_Leave);
            // 
            // cmdMaterialsBrowser
            // 
            this.cmdMaterialsBrowser.Location = new System.Drawing.Point(12, 53);
            this.cmdMaterialsBrowser.Name = "cmdMaterialsBrowser";
            this.cmdMaterialsBrowser.Size = new System.Drawing.Size(354, 23);
            this.cmdMaterialsBrowser.TabIndex = 1;
            this.cmdMaterialsBrowser.Text = "Browse Materials";
            this.cmdMaterialsBrowser.UseVisualStyleBackColor = true;
            this.cmdMaterialsBrowser.Click += new System.EventHandler(this.BrowseMaterialsPath);
            // 
            // fbdMaterials
            // 
            this.fbdMaterials.Description = "Select the folder where your material files are located";
            // 
            // fbdDetail
            // 
            this.fbdDetail.Description = "Select a folder to save the detail script";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 291);
            this.Controls.Add(this.cmdMaterialsBrowser);
            this.Controls.Add(this.txtMaterialsPath);
            this.Controls.Add(this.cmdMaterialList);
            this.Controls.Add(this.cmdTexturesBrowse);
            this.Controls.Add(this.txtTexturesPath);
            this.Controls.Add(this.cmdStart);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detail Tool";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem strpmenuApplication;
        private System.Windows.Forms.ToolStripMenuItem strpmenuInfo;
        private System.Windows.Forms.ToolStripMenuItem strpmenuitemAbout;
        private System.Windows.Forms.Button cmdStart;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.TextBox txtTexturesPath;
        private System.Windows.Forms.FolderBrowserDialog fbdTextures;
        private System.Windows.Forms.Button cmdTexturesBrowse;
        private System.Windows.Forms.ToolStripMenuItem strpmenuitemStart;
        private System.Windows.Forms.ToolStripSeparator strpmenuSeparator01;
        private System.Windows.Forms.ToolStripMenuItem strpmenuitemClose;
        private System.Windows.Forms.ToolStripMenuItem strpmenuEdit;
        private System.Windows.Forms.ToolStripMenuItem strpmenuitemMaterials;
        private System.Windows.Forms.Button cmdMaterialList;
        private System.Windows.Forms.TextBox txtMaterialsPath;
        private System.Windows.Forms.Button cmdMaterialsBrowser;
        private System.Windows.Forms.FolderBrowserDialog fbdMaterials;
        private System.Windows.Forms.FolderBrowserDialog fbdDetail;
    }
}