using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ScriptCenter.Repository;
using System.IO;
using ScriptCenter.Utils;
using ScriptCenter.Installer;

namespace ScriptCenter.DevCenter.Forms
{
    public partial class PackageForm : UserControl
    {
        private DevCenter devCenter;
        private ScriptPackage package;

        public PackageForm(DevCenter devCenter, ScriptPackage package)
        {
            InitializeComponent();

            if (package == null)
                throw new ArgumentNullException("Package argument cannot be null.");

            this.package = package;
            this.devCenter = devCenter;
            this.scriptPackageBindingSource.Add(package);
            this.package.PropertyChanged += new PropertyChangedEventHandler(package_PropertyChanged);

            this.setHelpLabelText();
            this.enableControls();
        }

        void package_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "RootPath")
                this.enableControls();
            else if (e.PropertyName == "Name")
            {
                if (package.Manifest.Name == "")
                    package.Manifest.Name = package.Name;
            }
        }

        private void setHelpLabelText() 
        {
            this.helpLabel.Text += ScriptManifestTokens.Id_Token + ", ";
            this.helpLabel.Text += ScriptManifestTokens.Name_Token + ", ";
            this.helpLabel.Text += ScriptManifestTokens.Author_Token + ", ";
            this.helpLabel.Text += ScriptManifestTokens.Version_Token + ", ";
            this.helpLabel.Text += ScriptManifestTokens.Version_Underscores_Token + ",\r\n";
            this.helpLabel.Text += ScriptManifestTokens.VersionMajor_Token + ", ";
            this.helpLabel.Text += ScriptManifestTokens.VersionMinor_Token + ", ";
            this.helpLabel.Text += ScriptManifestTokens.VersionRevision_Token + ", ";
            this.helpLabel.Text += ScriptManifestTokens.VersionStage_Token;
        }
        private void enableControls() 
        {
            Boolean enable = package.RootPath != String.Empty;

            this.sourceTextBox.Enabled = this.browseSourceButton.Enabled = enable;
            this.outputTextBox.Enabled = this.browseOutputFolder.Enabled = enable;
            this.packageTextBox.Enabled = this.browsePackageButton.Enabled = enable;
        }

        private void browseRootButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = package.RootPath.Replace('/', '\\');
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                String path = folderBrowserDialog.SelectedPath.Replace('\\', '/');
                Boolean reroute = false;
                if (package.RootPath != String.Empty)
                {
                    String message = "Do you want to reroute the paths to the new root path?\r\nE.g. when changing the root path from \"C:\\code\\\" to \"C:\\\", a source path \"source\\\" will become \"code\\source\\\".";
                    reroute = MessageBox.Show(message, "Reroute paths", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
                }
                if (reroute)
                    package.ReroutePaths(path, true);
                else
                    package.RootPath = path;
            }
        }
        private void browseSourceButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = package.SourcePathAbsolute.Replace('/', '\\');
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                package.SourcePathAbsolute = folderBrowserDialog.SelectedPath + "\\";
            }
        }
        private void browseOutputButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = package.OutputPathAbsolute.Replace('/', '\\');
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                package.OutputPathAbsolute = folderBrowserDialog.SelectedPath + "\\";
            }
        }
        private void browsePackageFileButton_Click(object sender, EventArgs e)
        {
            savePackageFileDialog.FileName = package.OutputFileAbsolute.Replace('/', '\\');
            DialogResult result = savePackageFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                package.OutputFileAbsolute = savePackageFileDialog.FileName;
            }
        }
    }
}
