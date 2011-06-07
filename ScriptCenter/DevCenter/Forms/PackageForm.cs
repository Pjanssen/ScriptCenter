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
            this.package.RootPath.PropertyChanged += new PropertyChangedEventHandler(RootPath_PropertyChanged);
            this.rootPathBindingSource.Add(package.RootPath);
            this.sourcePathBindingSource.Add(package.SourcePath);
            this.outputPathBindingSource.Add(package.OutputPath);
            this.packageFileBindingSource.Add(package.PackageFile);
            this.manifestFileBindingSource.Add(package.ManifestFile);

            this.setHelpLabelText();
            this.enableControls();
        }

        void RootPath_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.enableControls();
        }

        void package_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "RootPath")
            {
                this.rootPathBindingSource.Clear();
                this.rootPathBindingSource.Add(package.RootPath);
                this.enableControls();
            }
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
            Boolean enable = package.RootPath.Path != String.Empty;

            this.sourceTextBox.Enabled = this.browseSourceButton.Enabled = enable;
            this.outputTextBox.Enabled = this.browseOutputButton.Enabled = enable;
            this.packageTextBox.Enabled = this.browsePackageButton.Enabled = enable;
            this.manifestTextBox.Enabled = this.browseManifestButton.Enabled = enable;
        }

        private void browseRootButton_Click(object sender, EventArgs e) 
        {
            folderBrowserDialog.SelectedPath = package.RootPath.Path.Replace('/', '\\');
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                String path = folderBrowserDialog.SelectedPath.Replace('\\', '/') + "/";
                package.RootPath = new BasePath(path);
            }
        }
        private void browseSourceButton_Click(object sender, EventArgs e) 
        {
            folderBrowserDialog.SelectedPath = package.SourcePath.Path.Replace('/', '\\');
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                package.SourcePath.Path = folderBrowserDialog.SelectedPath + "\\";
            }
        }
        private void browseOutputButton_Click(object sender, EventArgs e) 
        {
            folderBrowserDialog.SelectedPath = package.OutputPath.Path.Replace('/', '\\');
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                package.OutputPath.Path = folderBrowserDialog.SelectedPath + "\\";
            }
        }
        private void browsePackageFileButton_Click(object sender, EventArgs e) 
        {
            savePackageFileDialog.FileName = package.PackageFile.Path.Replace('/', '\\');
            DialogResult result = savePackageFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                package.PackageFile.Path = savePackageFileDialog.FileName;
            }
        }
        private void browseManifestButton_Click(object sender, EventArgs e) 
        {
            savePackageFileDialog.FileName = package.ManifestFile.Path.Replace('/', '\\');
            DialogResult result = savePackageFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                package.ManifestFile.Path = savePackageFileDialog.FileName;
            }
        }
    }
}
