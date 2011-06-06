namespace ScriptCenter.DevCenter
{
    partial class DevCenter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DevCenter));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.sectionPanel = new System.Windows.Forms.Panel();
            this.titlePanel = new System.Windows.Forms.Panel();
            this.icons = new System.Windows.Forms.ImageList(this.components);
            this.horizontalLine = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.filesTree = new System.Windows.Forms.TreeView();
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.newButton = new System.Windows.Forms.ToolStripSplitButton();
            this.newManifestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newPackageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newRepositoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openButton = new System.Windows.Forms.ToolStripButton();
            this.saveButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeButton = new System.Windows.Forms.ToolStripButton();
            this.duplicateButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exportButton = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.sectionTitle = new ScriptCenter.Controls.ImageBeforeTextLabel();
            this.tableLayoutPanel1.SuspendLayout();
            this.titlePanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.mainToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 182F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.sectionPanel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.titlePanel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(689, 471);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // sectionPanel
            // 
            this.sectionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sectionPanel.Location = new System.Drawing.Point(185, 45);
            this.sectionPanel.Margin = new System.Windows.Forms.Padding(0);
            this.sectionPanel.Name = "sectionPanel";
            this.sectionPanel.Size = new System.Drawing.Size(501, 423);
            this.sectionPanel.TabIndex = 0;
            // 
            // titlePanel
            // 
            this.titlePanel.Controls.Add(this.sectionTitle);
            this.titlePanel.Controls.Add(this.horizontalLine);
            this.titlePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titlePanel.Location = new System.Drawing.Point(188, 10);
            this.titlePanel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.titlePanel.Name = "titlePanel";
            this.titlePanel.Size = new System.Drawing.Size(495, 30);
            this.titlePanel.TabIndex = 4;
            // 
            // icons
            // 
            this.icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("icons.ImageStream")));
            this.icons.TransparentColor = System.Drawing.Color.Transparent;
            this.icons.Images.SetKeyName(0, "project");
            this.icons.Images.SetKeyName(1, "manifest");
            this.icons.Images.SetKeyName(2, "manifest_metadata");
            this.icons.Images.SetKeyName(3, "manifest_version");
            this.icons.Images.SetKeyName(4, "package");
            this.icons.Images.SetKeyName(5, "repository");
            this.icons.Images.SetKeyName(6, "action");
            this.icons.Images.SetKeyName(7, "dialog");
            // 
            // horizontalLine
            // 
            this.horizontalLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.horizontalLine.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.horizontalLine.Location = new System.Drawing.Point(0, 28);
            this.horizontalLine.Name = "horizontalLine";
            this.horizontalLine.Size = new System.Drawing.Size(495, 2);
            this.horizontalLine.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.mainToolStrip);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(6, 8);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel1.SetRowSpan(this.panel1, 2);
            this.panel1.Size = new System.Drawing.Size(176, 457);
            this.panel1.TabIndex = 5;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.filesTree);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1, 29);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.panel2.Size = new System.Drawing.Size(174, 427);
            this.panel2.TabIndex = 3;
            // 
            // filesTree
            // 
            this.filesTree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.filesTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filesTree.HideSelection = false;
            this.filesTree.ImageIndex = 0;
            this.filesTree.ImageList = this.icons;
            this.filesTree.Indent = 19;
            this.filesTree.ItemHeight = 18;
            this.filesTree.Location = new System.Drawing.Point(0, 1);
            this.filesTree.Name = "filesTree";
            this.filesTree.SelectedImageIndex = 0;
            this.filesTree.Size = new System.Drawing.Size(174, 426);
            this.filesTree.TabIndex = 7;
            // 
            // mainToolStrip
            // 
            this.mainToolStrip.AutoSize = false;
            this.mainToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newButton,
            this.openButton,
            this.saveButton,
            this.toolStripSeparator1,
            this.closeButton,
            this.duplicateButton,
            this.toolStripSeparator2,
            this.exportButton});
            this.mainToolStrip.Location = new System.Drawing.Point(1, 1);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.Padding = new System.Windows.Forms.Padding(4, 2, 3, 0);
            this.mainToolStrip.Size = new System.Drawing.Size(174, 28);
            this.mainToolStrip.TabIndex = 2;
            this.mainToolStrip.Text = "toolStrip1";
            // 
            // newButton
            // 
            this.newButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newManifestToolStripMenuItem,
            this.newPackageToolStripMenuItem,
            this.newRepositoryToolStripMenuItem});
            this.newButton.Image = ((System.Drawing.Image)(resources.GetObject("newButton.Image")));
            this.newButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(32, 23);
            this.newButton.Text = "New Manifest";
            this.newButton.ButtonClick += new System.EventHandler(this.newButton_ButtonClick);
            // 
            // newManifestToolStripMenuItem
            // 
            this.newManifestToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newManifestToolStripMenuItem.Image")));
            this.newManifestToolStripMenuItem.Name = "newManifestToolStripMenuItem";
            this.newManifestToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.newManifestToolStripMenuItem.Text = "New Manifest";
            this.newManifestToolStripMenuItem.Click += new System.EventHandler(this.newManifestButton_Click);
            // 
            // newPackageToolStripMenuItem
            // 
            this.newPackageToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newPackageToolStripMenuItem.Image")));
            this.newPackageToolStripMenuItem.Name = "newPackageToolStripMenuItem";
            this.newPackageToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.newPackageToolStripMenuItem.Text = "New Package";
            this.newPackageToolStripMenuItem.Click += new System.EventHandler(this.newPackageButton_Click);
            // 
            // newRepositoryToolStripMenuItem
            // 
            this.newRepositoryToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newRepositoryToolStripMenuItem.Image")));
            this.newRepositoryToolStripMenuItem.Name = "newRepositoryToolStripMenuItem";
            this.newRepositoryToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.newRepositoryToolStripMenuItem.Text = "New Repository";
            this.newRepositoryToolStripMenuItem.Click += new System.EventHandler(this.newRepositoryButton_Click);
            // 
            // openButton
            // 
            this.openButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openButton.Image = ((System.Drawing.Image)(resources.GetObject("openButton.Image")));
            this.openButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 2);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(23, 23);
            this.openButton.Text = "Open";
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveButton.Image = ((System.Drawing.Image)(resources.GetObject("saveButton.Image")));
            this.saveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 2);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(23, 23);
            this.saveButton.Text = "&Save";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 26);
            // 
            // closeButton
            // 
            this.closeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.closeButton.Image = ((System.Drawing.Image)(resources.GetObject("closeButton.Image")));
            this.closeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(23, 23);
            this.closeButton.Text = "Close";
            // 
            // duplicateButton
            // 
            this.duplicateButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.duplicateButton.Image = ((System.Drawing.Image)(resources.GetObject("duplicateButton.Image")));
            this.duplicateButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.duplicateButton.Name = "duplicateButton";
            this.duplicateButton.Size = new System.Drawing.Size(23, 23);
            this.duplicateButton.Text = "duplicate";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 26);
            // 
            // exportButton
            // 
            this.exportButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.exportButton.Enabled = false;
            this.exportButton.Image = ((System.Drawing.Image)(resources.GetObject("exportButton.Image")));
            this.exportButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exportButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 2);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(23, 23);
            this.exportButton.Text = "Export Package";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "ScriptCenter files (*.scmanif, *.scpack, *.screpo)|*.scmanif;*.scpack;*.screpo";
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
            // DevCenter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 471);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DevCenter";
            this.ShowIcon = false;
            this.Text = "Dev Center";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.titlePanel.ResumeLayout(false);
            this.titlePanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel sectionPanel;
        private System.Windows.Forms.Panel titlePanel;
        private Controls.ImageBeforeTextLabel sectionTitle;
        private System.Windows.Forms.ImageList icons;
        private System.Windows.Forms.Label horizontalLine;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TreeView filesTree;
        private System.Windows.Forms.ToolStrip mainToolStrip;
        private System.Windows.Forms.ToolStripButton openButton;
        private System.Windows.Forms.ToolStripButton saveButton;
        private System.Windows.Forms.ToolStripButton exportButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSplitButton newButton;
        private System.Windows.Forms.ToolStripMenuItem newManifestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newPackageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newRepositoryToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripButton duplicateButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripButton closeButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}