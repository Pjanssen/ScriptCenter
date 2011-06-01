using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ScriptCenter.Installer;

namespace ScriptCenter.Project.Forms
{
    // OLD FILE! FOR REFERENCE ONLY.

    public partial class InstallerPathsForm : UserControl
    {
        public InstallerPathsForm()
        {
            InitializeComponent();
            enableControls();
        }


        private void enableControls()
        {
            /*
            ValidationResult validationResult = InstallerCreator.Validate(this.ProjectData);
            Boolean enabled = ((validationResult & ValidationResult.RootPathEmpty) != ValidationResult.RootPathEmpty) && ((validationResult & ValidationResult.RootPathNonExisting) != ValidationResult.RootPathNonExisting);
            this.exportTargetLabel.Enabled = enabled;
            this.exportTarget.Enabled = enabled;
            this.browseExportLocation.Enabled = enabled;
            this.icon16Label.Enabled = enabled;
            this.icon16PictureBox.Enabled = enabled;
            this.icon16.Enabled = enabled;
            this.browseIcon16.Enabled = enabled;
            this.icon32Label.Enabled = enabled;
            this.icon32.Enabled = enabled;
            this.browseIcon32.Enabled = enabled;
            this.icon32PictureBox.Enabled = enabled;
            this.icon64Label.Enabled = enabled;
            this.icon64.Enabled = enabled;
            this.icon64PictureBox.Enabled = enabled;
            this.browseIcon64.Enabled = enabled;
             */
        }

        private void browseRootPath_Click(object sender, EventArgs e)
        {
            /*
            this.exportMzpDialog.InitialDirectory = this.ProjectData.RootPath;
            DialogResult result = rootPathBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.ProjectData.RootPath = rootPathBrowserDialog.SelectedPath + Path.DirectorySeparatorChar;
            }
            */
        }
        private void browseExportLocation_Click(object sender, EventArgs e)
        {
            /*
            this.exportMzpDialog.InitialDirectory = this.ProjectData.RootPath;
            DialogResult result = this.exportMzpDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.ProjectData.ExportTarget = InstallerCreator.GetRelativePath(exportMzpDialog.FileName, this.ProjectData.RootPath);
            }
            */
        }

        private void loadIcons()
        {
            /*
            if (this.ProjectData == null)
                return;
            if (this.ProjectData.Icon16 != null)
                this.icon16PictureBox.Image = Image.FromFile(InstallerCreator.GetAbsolutePath(this.ProjectData.Icon16, this.ProjectData.RootPath));

            if (this.ProjectData.Icon32 != null)
                this.icon32PictureBox.Image = Image.FromFile(InstallerCreator.GetAbsolutePath(this.ProjectData.Icon32, this.ProjectData.RootPath));

            if (this.ProjectData.Icon64 != null)
                this.icon64PictureBox.Image = Image.FromFile(InstallerCreator.GetAbsolutePath(this.ProjectData.Icon64, this.ProjectData.RootPath));
            */
        }
        private String browseIcon()
        {
            //selectIconDialog.InitialDirectory = this.ProjectData.RootPath;
            DialogResult result = selectIconDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                //return InstallerCreator.GetRelativePath(selectIconDialog.FileName, this.ProjectData.RootPath);
            }

            return String.Empty;
        }
        private void browseIcon16_Click(object sender, EventArgs e)
        {
            String iconFile = this.browseIcon();
            if (iconFile == String.Empty)
                return;
            
            //this.ProjectData.Icon16 = iconFile;
            loadIcons();
        }
        private void browseIcon32_Click(object sender, EventArgs e)
        {
            String iconFile = this.browseIcon();
            if (iconFile == String.Empty)
                return;

            //this.ProjectData.Icon32 = iconFile;
            loadIcons();
        }
        private void browseIcon64_Click(object sender, EventArgs e)
        {
            String iconFile = this.browseIcon();
            if (iconFile == String.Empty)
                return;

            //this.ProjectData.Icon64 = iconFile;
            loadIcons();
        }

        private void scriptProjectDataBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            enableControls();
        }
        
    }
}
