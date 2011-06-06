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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Panel spacerPanel;
            this.helpLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.sourceTextBox = new System.Windows.Forms.TextBox();
            this.rootTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.browseSourceButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.browseOutputButton = new System.Windows.Forms.Button();
            this.browseRootButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.manifestComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.browseManifestButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.versionComboBox = new System.Windows.Forms.ComboBox();
            this.packageNameTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.outputPathDialog = new System.Windows.Forms.SaveFileDialog();
            this.browseManifestDialog = new System.Windows.Forms.OpenFileDialog();
            this.copyToOutputCheck = new System.Windows.Forms.CheckBox();
            this.scriptPackageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            label7 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            spacerPanel = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scriptPackageBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(3, 35);
            label7.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(73, 13);
            label7.TabIndex = 31;
            label7.Text = "Source Folder";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 6);
            label1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(81, 13);
            label1.TabIndex = 29;
            label1.Text = "Package Name";
            // 
            // spacerPanel
            // 
            spacerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            spacerPanel.Location = new System.Drawing.Point(3, 195);
            spacerPanel.Name = "spacerPanel";
            spacerPanel.Size = new System.Drawing.Size(499, 8);
            spacerPanel.TabIndex = 44;
            // 
            // helpLabel
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.helpLabel, 2);
            this.helpLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.helpLabel.Location = new System.Drawing.Point(91, 90);
            this.helpLabel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.helpLabel.Name = "helpLabel";
            this.helpLabel.Size = new System.Drawing.Size(399, 56);
            this.helpLabel.TabIndex = 46;
            this.helpLabel.Text = "Source and output paths are relative to the root path.\r\nInclude dynamic manifest " +
                "information in the paths using:\r\n";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(499, 165);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Paths";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel2.Controls.Add(this.helpLabel, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.sourceTextBox, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.rootTextBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.outputTextBox, 1, 2);
            this.tableLayoutPanel2.Controls.Add(label7, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.browseSourceButton, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.browseOutputButton, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.browseRootButton, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(493, 146);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // sourceTextBox
            // 
            this.sourceTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.scriptPackageBindingSource, "SourcePathRelative", true));
            this.sourceTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourceTextBox.Location = new System.Drawing.Point(91, 33);
            this.sourceTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.sourceTextBox.Name = "sourceTextBox";
            this.sourceTextBox.Size = new System.Drawing.Size(324, 20);
            this.sourceTextBox.TabIndex = 3;
            // 
            // rootTextBox
            // 
            this.rootTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.scriptPackageBindingSource, "RootPath", true));
            this.rootTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rootTextBox.Location = new System.Drawing.Point(91, 4);
            this.rootTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.rootTextBox.Name = "rootTextBox";
            this.rootTextBox.Size = new System.Drawing.Size(324, 20);
            this.rootTextBox.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 6);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Root Folder";
            // 
            // outputTextBox
            // 
            this.outputTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.scriptPackageBindingSource, "OutputPathRelative", true));
            this.outputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputTextBox.Location = new System.Drawing.Point(91, 62);
            this.outputTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.Size = new System.Drawing.Size(324, 20);
            this.outputTextBox.TabIndex = 5;
            // 
            // browseSourceButton
            // 
            this.browseSourceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseSourceButton.Location = new System.Drawing.Point(423, 32);
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
            this.label8.Location = new System.Drawing.Point(3, 64);
            this.label8.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Output File";
            // 
            // browseOutputButton
            // 
            this.browseOutputButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseOutputButton.Location = new System.Drawing.Point(423, 61);
            this.browseOutputButton.Name = "browseOutputButton";
            this.browseOutputButton.Size = new System.Drawing.Size(67, 22);
            this.browseOutputButton.TabIndex = 6;
            this.browseOutputButton.Text = "Browse";
            this.browseOutputButton.UseVisualStyleBackColor = true;
            this.browseOutputButton.Click += new System.EventHandler(this.browseOutputButton_Click);
            // 
            // browseRootButton
            // 
            this.browseRootButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseRootButton.Location = new System.Drawing.Point(423, 3);
            this.browseRootButton.Name = "browseRootButton";
            this.browseRootButton.Size = new System.Drawing.Size(67, 22);
            this.browseRootButton.TabIndex = 2;
            this.browseRootButton.Text = "Browse";
            this.browseRootButton.UseVisualStyleBackColor = true;
            this.browseRootButton.Click += new System.EventHandler(this.browseRootButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 203);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(499, 102);
            this.groupBox2.TabIndex = 43;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Manifest";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel3.Controls.Add(this.manifestComboBox, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.browseManifestButton, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.label10, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.versionComboBox, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.copyToOutputCheck, 1, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(493, 83);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // manifestComboBox
            // 
            this.manifestComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.manifestComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.manifestComboBox.FormattingEnabled = true;
            this.manifestComboBox.Location = new System.Drawing.Point(91, 3);
            this.manifestComboBox.Name = "manifestComboBox";
            this.manifestComboBox.Size = new System.Drawing.Size(324, 21);
            this.manifestComboBox.TabIndex = 1;
            this.manifestComboBox.SelectedIndexChanged += new System.EventHandler(this.manifestComboBox_SelectedIndexChanged);
            this.manifestComboBox.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.manifestComboBox_Format);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 6);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "Manifest File";
            // 
            // browseManifestButton
            // 
            this.browseManifestButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseManifestButton.Location = new System.Drawing.Point(423, 3);
            this.browseManifestButton.Name = "browseManifestButton";
            this.browseManifestButton.Size = new System.Drawing.Size(67, 22);
            this.browseManifestButton.TabIndex = 2;
            this.browseManifestButton.Text = "Browse";
            this.browseManifestButton.UseVisualStyleBackColor = true;
            this.browseManifestButton.Click += new System.EventHandler(this.browseManifestButton_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 35);
            this.label10.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 39;
            this.label10.Text = "Version";
            // 
            // versionComboBox
            // 
            this.versionComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.scriptPackageBindingSource, "ManifestVersion", true));
            this.versionComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.versionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.versionComboBox.FormattingEnabled = true;
            this.versionComboBox.Location = new System.Drawing.Point(91, 32);
            this.versionComboBox.Name = "versionComboBox";
            this.versionComboBox.Size = new System.Drawing.Size(324, 21);
            this.versionComboBox.TabIndex = 3;
            this.versionComboBox.SelectedIndexChanged += new System.EventHandler(this.versionComboBox_SelectedIndexChanged);
            // 
            // packageNameTextBox
            // 
            this.packageNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.scriptPackageBindingSource, "Name", true));
            this.packageNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.packageNameTextBox.Location = new System.Drawing.Point(94, 4);
            this.packageNameTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.packageNameTextBox.Name = "packageNameTextBox";
            this.packageNameTextBox.Size = new System.Drawing.Size(323, 20);
            this.packageNameTextBox.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.tableLayoutPanel1.Controls.Add(this.packageNameTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(499, 30);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // outputPathDialog
            // 
            this.outputPathDialog.Filter = "Maxscript Zip Package (*.mzp)|*.mzp";
            // 
            // browseManifestDialog
            // 
            this.browseManifestDialog.Filter = "Script Manifest (*.scmanif)|*.scmanif";
            // 
            // copyToOutputCheck
            // 
            this.copyToOutputCheck.AutoSize = true;
            this.copyToOutputCheck.Location = new System.Drawing.Point(91, 61);
            this.copyToOutputCheck.Name = "copyToOutputCheck";
            this.copyToOutputCheck.Size = new System.Drawing.Size(164, 17);
            this.copyToOutputCheck.TabIndex = 40;
            this.copyToOutputCheck.Text = "Copy manifest to output path.";
            this.copyToOutputCheck.UseVisualStyleBackColor = true;
            // 
            // scriptPackageBindingSource
            // 
            this.scriptPackageBindingSource.DataSource = typeof(ScriptCenter.Repository.ScriptPackage);
            // 
            // PackageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(spacerPanel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PackageForm";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.Size = new System.Drawing.Size(505, 358);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scriptPackageBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource scriptPackageBindingSource;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox sourceTextBox;
        private System.Windows.Forms.TextBox rootTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.Button browseSourceButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button browseOutputButton;
        private System.Windows.Forms.Button browseRootButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button browseManifestButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox versionComboBox;
        private System.Windows.Forms.TextBox packageNameTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox manifestComboBox;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label helpLabel;
        private System.Windows.Forms.SaveFileDialog outputPathDialog;
        private System.Windows.Forms.OpenFileDialog browseManifestDialog;
        private System.Windows.Forms.CheckBox copyToOutputCheck;
    }
}
