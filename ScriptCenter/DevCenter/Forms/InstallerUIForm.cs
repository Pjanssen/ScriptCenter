using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ScriptCenter.Package;
using ScriptCenter.Repository;

namespace ScriptCenter.DevCenter.Forms
{
    // OLD FILE! FOR REFERENCE ONLY.

    public partial class InstallerUIForm : UserControl
    {
        private ScriptPackage package;

        public InstallerUIForm(DevCenter devCenter, ScriptPackage package)
        {
            InitializeComponent();

            if (package == null)
                throw new ArgumentNullException("Package argument cannot be null.");

            this.package = package;

            if (package.RootPath.Path == String.Empty)
            {
                PackageRootPathWarning w = new PackageRootPathWarning();
                w.Dock = DockStyle.Fill;
                this.Controls.Remove(this.tableLayoutPanel);
                this.Controls.Add(w);
            }
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
    }
}
