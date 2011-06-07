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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label10;
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.packageNameTextBox = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.savePackageFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.browseManifestDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.browseOutputButton = new System.Windows.Forms.Button();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.sourceTextBox = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.browseSourceButton = new System.Windows.Forms.Button();
            this.browseRootButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.browseManifestButton = new System.Windows.Forms.Button();
            this.manifestTextBox = new System.Windows.Forms.TextBox();
            this.helpLabel = new System.Windows.Forms.Label();
            this.packageTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.browsePackageButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.sourcePathBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rootPathBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.scriptPackageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.outputPathBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.packageFileBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.manifestFileBindingSource = new System.Windows.Forms.BindingSource(this.components);
            label1 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sourcePathBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rootPathBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scriptPackageBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputPathBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.packageFileBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.manifestFileBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(6, 6);
            label1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(81, 13);
            label1.TabIndex = 50;
            label1.Text = "Package Name";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(3, 35);
            label6.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(73, 13);
            label6.TabIndex = 31;
            label6.Text = "Source Folder";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(3, 64);
            label10.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(71, 13);
            label10.TabIndex = 47;
            label10.Text = "Output Folder";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel2.Controls.Add(this.packageNameTextBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(label1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(546, 38);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // packageNameTextBox
            // 
            this.packageNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.scriptPackageBindingSource, "Name", true));
            this.packageNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.packageNameTextBox.Location = new System.Drawing.Point(94, 4);
            this.packageNameTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.packageNameTextBox.Name = "packageNameTextBox";
            this.packageNameTextBox.Size = new System.Drawing.Size(371, 20);
            this.packageNameTextBox.TabIndex = 51;
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
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(546, 131);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Paths";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.browseOutputButton, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.outputTextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.sourceTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(label6, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.browseSourceButton, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.browseRootButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(label10, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(540, 112);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(91, 90);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(371, 20);
            this.label2.TabIndex = 50;
            this.label2.Text = "Source and output paths are relative to the root path.";
            // 
            // browseOutputButton
            // 
            this.browseOutputButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseOutputButton.Location = new System.Drawing.Point(470, 61);
            this.browseOutputButton.Name = "browseOutputButton";
            this.browseOutputButton.Size = new System.Drawing.Size(67, 22);
            this.browseOutputButton.TabIndex = 49;
            this.browseOutputButton.Text = "Browse";
            this.browseOutputButton.UseVisualStyleBackColor = true;
            this.browseOutputButton.Click += new System.EventHandler(this.browseOutputButton_Click);
            // 
            // outputTextBox
            // 
            this.outputTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.outputPathBindingSource, "RelativePathComponent", true));
            this.outputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputTextBox.Location = new System.Drawing.Point(91, 62);
            this.outputTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.Size = new System.Drawing.Size(371, 20);
            this.outputTextBox.TabIndex = 48;
            // 
            // sourceTextBox
            // 
            this.sourceTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sourcePathBindingSource, "RelativePathComponent", true));
            this.sourceTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourceTextBox.Location = new System.Drawing.Point(91, 33);
            this.sourceTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.sourceTextBox.Name = "sourceTextBox";
            this.sourceTextBox.Size = new System.Drawing.Size(371, 20);
            this.sourceTextBox.TabIndex = 3;
            // 
            // textBox4
            // 
            this.textBox4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rootPathBindingSource, "Path", true));
            this.textBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox4.Location = new System.Drawing.Point(91, 4);
            this.textBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(371, 20);
            this.textBox4.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 6);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Root Folder";
            // 
            // browseSourceButton
            // 
            this.browseSourceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseSourceButton.Location = new System.Drawing.Point(470, 32);
            this.browseSourceButton.Name = "browseSourceButton";
            this.browseSourceButton.Size = new System.Drawing.Size(67, 22);
            this.browseSourceButton.TabIndex = 4;
            this.browseSourceButton.Text = "Browse";
            this.browseSourceButton.UseVisualStyleBackColor = true;
            this.browseSourceButton.Click += new System.EventHandler(this.browseSourceButton_Click);
            // 
            // browseRootButton
            // 
            this.browseRootButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseRootButton.Location = new System.Drawing.Point(470, 3);
            this.browseRootButton.Name = "browseRootButton";
            this.browseRootButton.Size = new System.Drawing.Size(67, 22);
            this.browseRootButton.TabIndex = 2;
            this.browseRootButton.Text = "Browse";
            this.browseRootButton.UseVisualStyleBackColor = true;
            this.browseRootButton.Click += new System.EventHandler(this.browseRootButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.tableLayoutPanel3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 169);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(546, 131);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel3.Controls.Add(this.browseManifestButton, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.manifestTextBox, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.helpLabel, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.packageTextBox, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label12, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.browsePackageButton, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(540, 112);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // browseManifestButton
            // 
            this.browseManifestButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseManifestButton.Location = new System.Drawing.Point(470, 32);
            this.browseManifestButton.Name = "browseManifestButton";
            this.browseManifestButton.Size = new System.Drawing.Size(67, 22);
            this.browseManifestButton.TabIndex = 49;
            this.browseManifestButton.Text = "Browse";
            this.browseManifestButton.UseVisualStyleBackColor = true;
            this.browseManifestButton.Click += new System.EventHandler(this.browseManifestButton_Click);
            // 
            // manifestTextBox
            // 
            this.manifestTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.manifestFileBindingSource, "RelativePathComponent", true));
            this.manifestTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.manifestTextBox.Location = new System.Drawing.Point(91, 33);
            this.manifestTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.manifestTextBox.Name = "manifestTextBox";
            this.manifestTextBox.Size = new System.Drawing.Size(371, 20);
            this.manifestTextBox.TabIndex = 48;
            // 
            // helpLabel
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.helpLabel, 2);
            this.helpLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.helpLabel.Location = new System.Drawing.Point(91, 61);
            this.helpLabel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.helpLabel.Name = "helpLabel";
            this.helpLabel.Size = new System.Drawing.Size(446, 51);
            this.helpLabel.TabIndex = 46;
            this.helpLabel.Text = "Include dynamic manifest information in paths and files using:\r\n";
            // 
            // packageTextBox
            // 
            this.packageTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.packageFileBindingSource, "RelativePathComponent", true));
            this.packageTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.packageTextBox.Location = new System.Drawing.Point(91, 4);
            this.packageTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.packageTextBox.Name = "packageTextBox";
            this.packageTextBox.Size = new System.Drawing.Size(371, 20);
            this.packageTextBox.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 6);
            this.label12.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "Package File";
            // 
            // browsePackageButton
            // 
            this.browsePackageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browsePackageButton.Location = new System.Drawing.Point(470, 3);
            this.browsePackageButton.Name = "browsePackageButton";
            this.browsePackageButton.Size = new System.Drawing.Size(67, 22);
            this.browsePackageButton.TabIndex = 6;
            this.browsePackageButton.Text = "Browse";
            this.browsePackageButton.UseVisualStyleBackColor = true;
            this.browsePackageButton.Click += new System.EventHandler(this.browsePackageFileButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 35);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 47;
            this.label5.Text = "Manifest File";
            // 
            // sourcePathBindingSource
            // 
            this.sourcePathBindingSource.DataSource = typeof(ScriptCenter.Utils.RelativePath);
            // 
            // rootPathBindingSource
            // 
            this.rootPathBindingSource.AllowNew = true;
            this.rootPathBindingSource.DataSource = typeof(ScriptCenter.Utils.BasePath);
            // 
            // scriptPackageBindingSource
            // 
            this.scriptPackageBindingSource.DataSource = typeof(ScriptCenter.Repository.ScriptPackage);
            // 
            // outputPathBindingSource
            // 
            this.outputPathBindingSource.DataSource = typeof(ScriptCenter.Utils.RelativePath);
            // 
            // packageFileBindingSource
            // 
            this.packageFileBindingSource.DataSource = typeof(ScriptCenter.Utils.RelativePath);
            // 
            // manifestFileBindingSource
            // 
            this.manifestFileBindingSource.DataSource = typeof(ScriptCenter.Utils.RelativePath);
            // 
            // PackageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "PackageForm";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.Size = new System.Drawing.Size(552, 472);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sourcePathBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rootPathBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scriptPackageBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputPathBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.packageFileBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.manifestFileBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource scriptPackageBindingSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.SaveFileDialog savePackageFileDialog;
        private System.Windows.Forms.OpenFileDialog browseManifestDialog;
        private System.Windows.Forms.TextBox packageNameTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button browseOutputButton;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.TextBox sourceTextBox;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button browseSourceButton;
        private System.Windows.Forms.Button browseRootButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label helpLabel;
        private System.Windows.Forms.TextBox packageTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button browsePackageButton;
        private System.Windows.Forms.Button browseManifestButton;
        private System.Windows.Forms.TextBox manifestTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.BindingSource rootPathBindingSource;
        private System.Windows.Forms.BindingSource sourcePathBindingSource;
        private System.Windows.Forms.BindingSource outputPathBindingSource;
        private System.Windows.Forms.BindingSource manifestFileBindingSource;
        private System.Windows.Forms.BindingSource packageFileBindingSource;
    }
}
