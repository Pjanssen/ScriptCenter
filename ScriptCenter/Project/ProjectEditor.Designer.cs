namespace ScriptCenter.Project
{
    partial class ProjectEditor
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectEditor));
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.newButton = new System.Windows.Forms.ToolStripButton();
            this.openButton = new System.Windows.Forms.ToolStripButton();
            this.saveButton = new System.Windows.Forms.ToolStripButton();
            this.newManifestButton = new System.Windows.Forms.ToolStripButton();
            this.newPackageButton = new System.Windows.Forms.ToolStripButton();
            this.newRepositoryButton = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.sectionPanel = new System.Windows.Forms.Panel();
            this.titlePanel = new System.Windows.Forms.Panel();
            this.sectionTitle = new ScriptCenter.Controls.ImageBeforeTextLabel();
            this.icons = new System.Windows.Forms.ImageList(this.components);
            this.horizontalLine = new System.Windows.Forms.Label();
            this.filesTree = new System.Windows.Forms.TreeView();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mainToolStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.titlePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(6, 26);
            // 
            // mainToolStrip
            // 
            this.mainToolStrip.AutoSize = false;
            this.mainToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newButton,
            this.openButton,
            this.saveButton,
            toolStripSeparator1,
            this.newManifestButton,
            this.newPackageButton,
            this.newRepositoryButton});
            this.mainToolStrip.Location = new System.Drawing.Point(0, 0);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.Padding = new System.Windows.Forms.Padding(6, 2, 1, 0);
            this.mainToolStrip.Size = new System.Drawing.Size(689, 28);
            this.mainToolStrip.TabIndex = 1;
            this.mainToolStrip.Text = "toolStrip1";
            // 
            // newButton
            // 
            this.newButton.Image = ((System.Drawing.Image)(resources.GetObject("newButton.Image")));
            this.newButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 2);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(48, 23);
            this.newButton.Text = "&New";
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // openButton
            // 
            this.openButton.Image = ((System.Drawing.Image)(resources.GetObject("openButton.Image")));
            this.openButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 2);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(53, 23);
            this.openButton.Text = "Open";
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Image = ((System.Drawing.Image)(resources.GetObject("saveButton.Image")));
            this.saveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 2);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(51, 23);
            this.saveButton.Text = "&Save";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // newManifestButton
            // 
            this.newManifestButton.Image = ((System.Drawing.Image)(resources.GetObject("newManifestButton.Image")));
            this.newManifestButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newManifestButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 2);
            this.newManifestButton.Name = "newManifestButton";
            this.newManifestButton.Size = new System.Drawing.Size(92, 23);
            this.newManifestButton.Text = "New Manifest";
            this.newManifestButton.Click += new System.EventHandler(this.newManifestButton_Click);
            // 
            // newPackageButton
            // 
            this.newPackageButton.Image = ((System.Drawing.Image)(resources.GetObject("newPackageButton.Image")));
            this.newPackageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newPackageButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 2);
            this.newPackageButton.Name = "newPackageButton";
            this.newPackageButton.Size = new System.Drawing.Size(91, 23);
            this.newPackageButton.Text = "New Package";
            this.newPackageButton.Click += new System.EventHandler(this.newPackageButton_Click);
            // 
            // newRepositoryButton
            // 
            this.newRepositoryButton.Image = ((System.Drawing.Image)(resources.GetObject("newRepositoryButton.Image")));
            this.newRepositoryButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newRepositoryButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 2);
            this.newRepositoryButton.Name = "newRepositoryButton";
            this.newRepositoryButton.Size = new System.Drawing.Size(103, 23);
            this.newRepositoryButton.Text = "New Repository";
            this.newRepositoryButton.Click += new System.EventHandler(this.newRepositoryButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 168F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.sectionPanel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.titlePanel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.filesTree, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(689, 443);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // sectionPanel
            // 
            this.sectionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sectionPanel.Location = new System.Drawing.Point(171, 39);
            this.sectionPanel.Margin = new System.Windows.Forms.Padding(0);
            this.sectionPanel.Name = "sectionPanel";
            this.sectionPanel.Size = new System.Drawing.Size(515, 401);
            this.sectionPanel.TabIndex = 2;
            // 
            // titlePanel
            // 
            this.titlePanel.Controls.Add(this.sectionTitle);
            this.titlePanel.Controls.Add(this.horizontalLine);
            this.titlePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titlePanel.Location = new System.Drawing.Point(174, 5);
            this.titlePanel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.titlePanel.Name = "titlePanel";
            this.titlePanel.Size = new System.Drawing.Size(509, 29);
            this.titlePanel.TabIndex = 4;
            // 
            // sectionTitle
            // 
            this.sectionTitle.AutoSize = true;
            this.sectionTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sectionTitle.Image = ((System.Drawing.Image)(resources.GetObject("sectionTitle.Image")));
            this.sectionTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.sectionTitle.ImageKey = "manifest";
            this.sectionTitle.ImageList = this.icons;
            this.sectionTitle.Location = new System.Drawing.Point(4, 3);
            this.sectionTitle.Name = "sectionTitle";
            this.sectionTitle.Size = new System.Drawing.Size(130, 20);
            this.sectionTitle.TabIndex = 4;
            this.sectionTitle.Text = "{section_title}";
            this.sectionTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // icons
            // 
            this.icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("icons.ImageStream")));
            this.icons.TransparentColor = System.Drawing.Color.Transparent;
            this.icons.Images.SetKeyName(0, "manifest");
            this.icons.Images.SetKeyName(1, "manifest_metadata");
            this.icons.Images.SetKeyName(2, "manifest_version");
            this.icons.Images.SetKeyName(3, "package");
            this.icons.Images.SetKeyName(4, "repository");
            this.icons.Images.SetKeyName(5, "action");
            this.icons.Images.SetKeyName(6, "dialog");
            // 
            // horizontalLine
            // 
            this.horizontalLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.horizontalLine.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.horizontalLine.Location = new System.Drawing.Point(0, 27);
            this.horizontalLine.Name = "horizontalLine";
            this.horizontalLine.Size = new System.Drawing.Size(509, 2);
            this.horizontalLine.TabIndex = 3;
            // 
            // filesTree
            // 
            this.filesTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filesTree.HideSelection = false;
            this.filesTree.ImageIndex = 0;
            this.filesTree.ImageList = this.icons;
            this.filesTree.Indent = 19;
            this.filesTree.ItemHeight = 18;
            this.filesTree.Location = new System.Drawing.Point(6, 8);
            this.filesTree.Name = "filesTree";
            this.tableLayoutPanel1.SetRowSpan(this.filesTree, 2);
            this.filesTree.SelectedImageIndex = 0;
            this.filesTree.Size = new System.Drawing.Size(162, 429);
            this.filesTree.TabIndex = 5;
            // 
            // ProjectEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 471);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.mainToolStrip);
            this.Name = "ProjectEditor";
            this.Text = "ProjectEditor";
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.titlePanel.ResumeLayout(false);
            this.titlePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip mainToolStrip;
        private System.Windows.Forms.ToolStripButton newButton;
        private System.Windows.Forms.ToolStripButton openButton;
        private System.Windows.Forms.ToolStripButton saveButton;
        private System.Windows.Forms.ToolStripButton newManifestButton;
        private System.Windows.Forms.ToolStripButton newPackageButton;
        private System.Windows.Forms.ToolStripButton newRepositoryButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel sectionPanel;
        private System.Windows.Forms.Panel titlePanel;
        private System.Windows.Forms.TreeView filesTree;
        private Controls.ImageBeforeTextLabel sectionTitle;
        private System.Windows.Forms.ImageList icons;
        private System.Windows.Forms.Label horizontalLine;
    }
}