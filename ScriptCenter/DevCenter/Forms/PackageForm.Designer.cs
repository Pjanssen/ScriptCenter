namespace ScriptCenter.DevCenter.Forms
{
    partial class PackageForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            this.helpLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.sourceTextBox = new System.Windows.Forms.TextBox();
            this.rootTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.packageTextBox = new System.Windows.Forms.TextBox();
            this.browseSourceButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.browsePackageButton = new System.Windows.Forms.Button();
            this.browseRootButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.savePackageFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.browseManifestDialog = new System.Windows.Forms.OpenFileDialog();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.browseOutputFolder = new System.Windows.Forms.Button();
            this.packageNameTextBox = new System.Windows.Forms.TextBox();
            this.scriptPackageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            label7 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scriptPackageBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(3, 67);
            label7.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(73, 13);
            label7.TabIndex = 31;
            label7.Text = "Source Folder";
            // 
            // helpLabel
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.helpLabel, 2);
            this.helpLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.helpLabel.Location = new System.Drawing.Point(91, 151);
            this.helpLabel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.helpLabel.Name = "helpLabel";
            this.helpLabel.Size = new System.Drawing.Size(405, 204);
            this.helpLabel.TabIndex = 46;
            this.helpLabel.Text = "Source and output paths are relative to the root path.\r\nInclude dynamic manifest " +
                "information in the paths using:\r\n";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel2.Controls.Add(this.packageNameTextBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.browseOutputFolder, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.outputTextBox, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.helpLabel, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.sourceTextBox, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.rootTextBox, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.packageTextBox, 1, 4);
            this.tableLayoutPanel2.Controls.Add(label7, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.browseSourceButton, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.browsePackageButton, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.browseRootButton, 2, 1);
            this.tableLayoutPanel2.Controls.Add(label2, 0, 3);
            this.tableLayoutPanel2.Controls.Add(label1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(499, 355);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // sourceTextBox
            // 
            this.sourceTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.scriptPackageBindingSource, "SourcePathRelative", true));
            this.sourceTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourceTextBox.Location = new System.Drawing.Point(91, 65);
            this.sourceTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.sourceTextBox.Name = "sourceTextBox";
            this.sourceTextBox.Size = new System.Drawing.Size(330, 20);
            this.sourceTextBox.TabIndex = 3;
            // 
            // rootTextBox
            // 
            this.rootTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.scriptPackageBindingSource, "RootPath", true));
            this.rootTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rootTextBox.Location = new System.Drawing.Point(91, 36);
            this.rootTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.rootTextBox.Name = "rootTextBox";
            this.rootTextBox.Size = new System.Drawing.Size(330, 20);
            this.rootTextBox.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 38);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Root Folder";
            // 
            // packageTextBox
            // 
            this.packageTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.scriptPackageBindingSource, "OutputFileRelative", true));
            this.packageTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.packageTextBox.Location = new System.Drawing.Point(91, 123);
            this.packageTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.packageTextBox.Name = "packageTextBox";
            this.packageTextBox.Size = new System.Drawing.Size(330, 20);
            this.packageTextBox.TabIndex = 5;
            // 
            // browseSourceButton
            // 
            this.browseSourceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseSourceButton.Location = new System.Drawing.Point(429, 64);
            this.browseSourceButton.Name = "browseSourceButton";
            this.browseSourceButton.Size = new System.Drawing.Size(67, 22);
            this.browseSourceButton.TabIndex = 4;
            this.browseSourceButton.Text = "Browse";
            this.browseSourceButton.UseVisualStyleBackColor = true;
            this.browseSourceButton.Click += new System.EventHandler(this.browseSourceButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 125);
            this.label8.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Package file";
            // 
            // browsePackageButton
            // 
            this.browsePackageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browsePackageButton.Location = new System.Drawing.Point(429, 122);
            this.browsePackageButton.Name = "browsePackageButton";
            this.browsePackageButton.Size = new System.Drawing.Size(67, 22);
            this.browsePackageButton.TabIndex = 6;
            this.browsePackageButton.Text = "Browse";
            this.browsePackageButton.UseVisualStyleBackColor = true;
            this.browsePackageButton.Click += new System.EventHandler(this.browsePackageFileButton_Click);
            // 
            // browseRootButton
            // 
            this.browseRootButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseRootButton.Location = new System.Drawing.Point(429, 35);
            this.browseRootButton.Name = "browseRootButton";
            this.browseRootButton.Size = new System.Drawing.Size(67, 22);
            this.browseRootButton.TabIndex = 2;
            this.browseRootButton.Text = "Browse";
            this.browseRootButton.UseVisualStyleBackColor = true;
            this.browseRootButton.Click += new System.EventHandler(this.browseRootButton_Click);
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // savePackageFileDialog
            // 
            this.savePackageFileDialog.Filter = "Maxscript Zip Package (*.mzp)|*.mzp";
            // 
            // browseManifestDialog
            // 
            this.browseManifestDialog.Filter = "Script Manifest (*.scmanif)|*.scmanif";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(3, 96);
            label2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(71, 13);
            label2.TabIndex = 47;
            label2.Text = "Output Folder";
            // 
            // outputTextBox
            // 
            this.outputTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.scriptPackageBindingSource, "OutputPathRelative", true));
            this.outputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputTextBox.Location = new System.Drawing.Point(91, 94);
            this.outputTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.Size = new System.Drawing.Size(330, 20);
            this.outputTextBox.TabIndex = 48;
            // 
            // browseOutputFolder
            // 
            this.browseOutputFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseOutputFolder.Location = new System.Drawing.Point(429, 93);
            this.browseOutputFolder.Name = "browseOutputFolder";
            this.browseOutputFolder.Size = new System.Drawing.Size(67, 22);
            this.browseOutputFolder.TabIndex = 49;
            this.browseOutputFolder.Text = "Browse";
            this.browseOutputFolder.UseVisualStyleBackColor = true;
            this.browseOutputFolder.Click += new System.EventHandler(this.browseOutputButton_Click);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 6);
            label1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(81, 13);
            label1.TabIndex = 50;
            label1.Text = "Package Name";
            // 
            // packageNameTextBox
            // 
            this.packageNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.scriptPackageBindingSource, "Name", true));
            this.packageNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.packageNameTextBox.Location = new System.Drawing.Point(91, 4);
            this.packageNameTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.packageNameTextBox.Name = "packageNameTextBox";
            this.packageNameTextBox.Size = new System.Drawing.Size(330, 20);
            this.packageNameTextBox.TabIndex = 51;
            // 
            // scriptPackageBindingSource
            // 
            this.scriptPackageBindingSource.DataSource = typeof(ScriptCenter.Repository.ScriptPackage);
            // 
            // PackageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "PackageForm";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.Size = new System.Drawing.Size(505, 358);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scriptPackageBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource scriptPackageBindingSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox sourceTextBox;
        private System.Windows.Forms.TextBox rootTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox packageTextBox;
        private System.Windows.Forms.Button browseSourceButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button browsePackageButton;
        private System.Windows.Forms.Button browseRootButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label helpLabel;
        private System.Windows.Forms.SaveFileDialog savePackageFileDialog;
        private System.Windows.Forms.OpenFileDialog browseManifestDialog;
        private System.Windows.Forms.Button browseOutputFolder;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.TextBox packageNameTextBox;
    }
}
