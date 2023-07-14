namespace Script_Tool
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
            this.strmenuApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.strpmenuStart = new System.Windows.Forms.ToolStripMenuItem();
            this.strpmenuSeparator01 = new System.Windows.Forms.ToolStripSeparator();
            this.strpmenuitemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.strpmenuInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.strpmenuitemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTextures = new System.Windows.Forms.Label();
            this.txtTexturesPath = new System.Windows.Forms.TextBox();
            this.cmdBrowse01 = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdStart = new System.Windows.Forms.Button();
            this.fbdTextures = new System.Windows.Forms.FolderBrowserDialog();
            this.gbxParsing = new System.Windows.Forms.GroupBox();
            this.lblParsing = new System.Windows.Forms.Label();
            this.cbxBMP = new System.Windows.Forms.CheckBox();
            this.cbxTGA = new System.Windows.Forms.CheckBox();
            this.cbxDDS = new System.Windows.Forms.CheckBox();
            this.gbxGeneration = new System.Windows.Forms.GroupBox();
            this.cbxModelTextures = new System.Windows.Forms.CheckBox();
            this.cbxWorldTextures = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.gbxParsing.SuspendLayout();
            this.gbxGeneration.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.strmenuApplication,
            this.strpmenuInfo});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(506, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // strmenuApplication
            // 
            this.strmenuApplication.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.strpmenuStart,
            this.strpmenuSeparator01,
            this.strpmenuitemClose});
            this.strmenuApplication.Name = "strmenuApplication";
            this.strmenuApplication.Size = new System.Drawing.Size(80, 20);
            this.strmenuApplication.Text = "Application";
            // 
            // strpmenuStart
            // 
            this.strpmenuStart.Name = "strpmenuStart";
            this.strpmenuStart.Size = new System.Drawing.Size(103, 22);
            this.strpmenuStart.Text = "Start";
            this.strpmenuStart.Click += new System.EventHandler(this.Run);
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
            this.strpmenuitemClose.Click += new System.EventHandler(this.Close);
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
            // lblTextures
            // 
            this.lblTextures.Location = new System.Drawing.Point(12, 47);
            this.lblTextures.Name = "lblTextures";
            this.lblTextures.Size = new System.Drawing.Size(100, 23);
            this.lblTextures.TabIndex = 1;
            this.lblTextures.Text = "Textures folder";
            this.lblTextures.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTexturesPath
            // 
            this.txtTexturesPath.Location = new System.Drawing.Point(118, 47);
            this.txtTexturesPath.Multiline = true;
            this.txtTexturesPath.Name = "txtTexturesPath";
            this.txtTexturesPath.Size = new System.Drawing.Size(295, 23);
            this.txtTexturesPath.TabIndex = 2;
            // 
            // cmdBrowse01
            // 
            this.cmdBrowse01.Location = new System.Drawing.Point(419, 47);
            this.cmdBrowse01.Name = "cmdBrowse01";
            this.cmdBrowse01.Size = new System.Drawing.Size(75, 23);
            this.cmdBrowse01.TabIndex = 3;
            this.cmdBrowse01.Text = "Browse";
            this.cmdBrowse01.UseVisualStyleBackColor = true;
            this.cmdBrowse01.Click += new System.EventHandler(this.BrowsePath);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(419, 193);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 30;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.Close);
            // 
            // cmdStart
            // 
            this.cmdStart.Location = new System.Drawing.Point(338, 193);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.Size = new System.Drawing.Size(75, 23);
            this.cmdStart.TabIndex = 32;
            this.cmdStart.Text = "Start";
            this.cmdStart.UseVisualStyleBackColor = true;
            this.cmdStart.Click += new System.EventHandler(this.Run);
            // 
            // fbdTextures
            // 
            this.fbdTextures.Description = "Select the textures folder located inside the gfx folder";
            // 
            // gbxParsing
            // 
            this.gbxParsing.Controls.Add(this.lblParsing);
            this.gbxParsing.Controls.Add(this.cbxBMP);
            this.gbxParsing.Controls.Add(this.cbxTGA);
            this.gbxParsing.Controls.Add(this.cbxDDS);
            this.gbxParsing.Location = new System.Drawing.Point(12, 93);
            this.gbxParsing.Name = "gbxParsing";
            this.gbxParsing.Size = new System.Drawing.Size(320, 65);
            this.gbxParsing.TabIndex = 4;
            this.gbxParsing.TabStop = false;
            this.gbxParsing.Text = "File Parsing";
            // 
            // lblParsing
            // 
            this.lblParsing.Location = new System.Drawing.Point(6, 16);
            this.lblParsing.Name = "lblParsing";
            this.lblParsing.Size = new System.Drawing.Size(308, 23);
            this.lblParsing.TabIndex = 0;
            this.lblParsing.Text = "Formats to look for:";
            this.lblParsing.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxBMP
            // 
            this.cbxBMP.AutoSize = true;
            this.cbxBMP.Location = new System.Drawing.Point(121, 42);
            this.cbxBMP.Name = "cbxBMP";
            this.cbxBMP.Size = new System.Drawing.Size(52, 17);
            this.cbxBMP.TabIndex = 3;
            this.cbxBMP.Text = ".BMP";
            this.cbxBMP.UseVisualStyleBackColor = true;
            // 
            // cbxTGA
            // 
            this.cbxTGA.AutoSize = true;
            this.cbxTGA.Location = new System.Drawing.Point(64, 42);
            this.cbxTGA.Name = "cbxTGA";
            this.cbxTGA.Size = new System.Drawing.Size(51, 17);
            this.cbxTGA.TabIndex = 2;
            this.cbxTGA.Text = ".TGA";
            this.cbxTGA.UseVisualStyleBackColor = true;
            // 
            // cbxDDS
            // 
            this.cbxDDS.AutoSize = true;
            this.cbxDDS.Location = new System.Drawing.Point(6, 42);
            this.cbxDDS.Name = "cbxDDS";
            this.cbxDDS.Size = new System.Drawing.Size(52, 17);
            this.cbxDDS.TabIndex = 1;
            this.cbxDDS.Text = ".DDS";
            this.cbxDDS.UseVisualStyleBackColor = true;
            // 
            // gbxGeneration
            // 
            this.gbxGeneration.Controls.Add(this.cbxModelTextures);
            this.gbxGeneration.Controls.Add(this.cbxWorldTextures);
            this.gbxGeneration.Location = new System.Drawing.Point(338, 93);
            this.gbxGeneration.Name = "gbxGeneration";
            this.gbxGeneration.Size = new System.Drawing.Size(156, 65);
            this.gbxGeneration.TabIndex = 5;
            this.gbxGeneration.TabStop = false;
            this.gbxGeneration.Text = "Flag Generation";
            // 
            // cbxModelTextures
            // 
            this.cbxModelTextures.AutoSize = true;
            this.cbxModelTextures.Location = new System.Drawing.Point(6, 42);
            this.cbxModelTextures.Name = "cbxModelTextures";
            this.cbxModelTextures.Size = new System.Drawing.Size(95, 17);
            this.cbxModelTextures.TabIndex = 1;
            this.cbxModelTextures.Text = "Model textures";
            this.cbxModelTextures.UseVisualStyleBackColor = true;
            // 
            // cbxWorldTextures
            // 
            this.cbxWorldTextures.AutoSize = true;
            this.cbxWorldTextures.Location = new System.Drawing.Point(6, 19);
            this.cbxWorldTextures.Name = "cbxWorldTextures";
            this.cbxWorldTextures.Size = new System.Drawing.Size(94, 17);
            this.cbxWorldTextures.TabIndex = 0;
            this.cbxWorldTextures.Text = "World textures";
            this.cbxWorldTextures.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 228);
            this.Controls.Add(this.gbxGeneration);
            this.Controls.Add(this.gbxParsing);
            this.Controls.Add(this.cmdStart);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdBrowse01);
            this.Controls.Add(this.txtTexturesPath);
            this.Controls.Add(this.lblTextures);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Script Tool";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbxParsing.ResumeLayout(false);
            this.gbxParsing.PerformLayout();
            this.gbxGeneration.ResumeLayout(false);
            this.gbxGeneration.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label lblTextures;
        private System.Windows.Forms.TextBox txtTexturesPath;
        private System.Windows.Forms.Button cmdBrowse01;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdStart;
        private System.Windows.Forms.FolderBrowserDialog fbdTextures;
        private System.Windows.Forms.GroupBox gbxParsing;
        private System.Windows.Forms.Label lblParsing;
        private System.Windows.Forms.CheckBox cbxBMP;
        private System.Windows.Forms.CheckBox cbxTGA;
        private System.Windows.Forms.CheckBox cbxDDS;
        private System.Windows.Forms.GroupBox gbxGeneration;
        private System.Windows.Forms.CheckBox cbxModelTextures;
        private System.Windows.Forms.CheckBox cbxWorldTextures;
        private System.Windows.Forms.ToolStripMenuItem strmenuApplication;
        private System.Windows.Forms.ToolStripMenuItem strpmenuStart;
        private System.Windows.Forms.ToolStripSeparator strpmenuSeparator01;
        private System.Windows.Forms.ToolStripMenuItem strpmenuitemClose;
        private System.Windows.Forms.ToolStripMenuItem strpmenuInfo;
        private System.Windows.Forms.ToolStripMenuItem strpmenuitemAbout;
    }
}