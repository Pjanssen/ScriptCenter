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
            this.outputTextBox.Enabled = this.browseOutputButton.Enabled = enable;
            this.manifestComboBox.Enabled = this.browseManifestButton.Enabled = enable;
            this.versionComboBox.Enabled = enable;
            this.copyToOutputCheck.Enabled = enable;

            if (enable)
                this.fillManifestComboBox();
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
            outputPathDialog.FileName = package.OutputPathAbsolute.Replace('/', '\\');
            DialogResult result = outputPathDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                package.OutputPathAbsolute = outputPathDialog.FileName;
            }
        }
        private void browseManifestButton_Click(object sender, EventArgs e)
        {
            browseManifestDialog.InitialDirectory = package.ManifestPathAbsolute.Replace('/', '\\');
            DialogResult result = browseManifestDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                package.ManifestPathAbsolute = browseManifestDialog.FileName;
            }
        }

        private void fillManifestComboBox()
        {
            this.manifestComboBox.Items.Clear();

            //Loop through loaded manifests and add them to the combobox.
            Int32 manifestIndex = -1;
            Int32 i = 0;
            foreach (KeyValuePair<Object, String> file in devCenter.Files)
            {
                if (!(file.Key is ScriptManifest) || file.Value == String.Empty)
                    continue;

                String localPath = PathHelperMethods.GetRelativePath(file.Value, package.RootPath);
                KeyValuePair<ScriptManifest, String> item = new KeyValuePair<ScriptManifest, String>((ScriptManifest)file.Key, localPath);
                this.manifestComboBox.Items.Add(item);

                if (localPath == package.ManifestPathRelative)
                    manifestIndex = i;

                i++;
            }

            //Grab manifest from the package if it isn't loaded by the DevCenter already.
            if (manifestIndex == -1 && package.ManifestPathRelative != String.Empty)
            {
                KeyValuePair<ScriptManifest, String> file = new KeyValuePair<ScriptManifest, String>(package.Manifest, package.ManifestPathRelative);
                this.manifestComboBox.Items.Add(file);
                manifestIndex = this.manifestComboBox.Items.Count - 1;
            }

            //Select the manifest.
            if (manifestIndex != -1)
                this.manifestComboBox.SelectedIndex = manifestIndex;
        }
        private void fillVersionsComboBox()
        {
            if (this.manifestComboBox.SelectedItem is KeyValuePair<ScriptManifest, String>)
            {
                KeyValuePair<ScriptManifest, String> item = (KeyValuePair<ScriptManifest, String>)this.manifestComboBox.SelectedItem;
                this.versionComboBox.Items.Clear();
                this.versionComboBox.Items.Add("-use latest-");
                foreach (ScriptVersion v in item.Key.Versions)
                {
                    this.versionComboBox.Items.Add(v.VersionNumber.ToString());
                }
                this.versionComboBox.SelectedValue = package.ManifestVersion;
            }
        }

        private void manifestComboBox_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is KeyValuePair<ScriptManifest, String>)
            {
                KeyValuePair<ScriptManifest, String> item = (KeyValuePair<ScriptManifest, String>)e.ListItem;
                e.Value = String.Format("{0} - {1}", item.Key.Name, item.Value);
            }
        }

        private void manifestComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.fillVersionsComboBox();

            if (this.manifestComboBox.SelectedItem is KeyValuePair<ScriptManifest, String>)
            {
                KeyValuePair<ScriptManifest, String> selValue = (KeyValuePair<ScriptManifest, String>)this.manifestComboBox.SelectedItem;
                this.package.ManifestPathRelative = selValue.Value;
            }
        }

        private void versionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.versionComboBox.SelectedItem is String)
            {
                this.package.ManifestVersion = (String)this.versionComboBox.SelectedItem;
            }
        }

        

       
    }
}
