using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ScriptCenter.Repository;

namespace ScriptCenter.Installer.Editor
{
    public partial class InstallerEditor : Form
    {
        private String projectDataPath;
        private ScriptProjectData projectData;
        private InstallerEditorPage page;

        public InstallerEditor()
        {
            InitializeComponent();

            projectData = new ScriptProjectData();
            this.bindingSource1.Add(projectData);
            this.bindingSource2.Add(projectData.Manifest);

            ListViewItem item = listView1.Items.Add("Paths and Files");
            item.Tag = typeof(InstallerPathsForm);
            item = listView1.Items.Add("Manifest");
            item.Tag = typeof(ManifestForm);
            item = listView1.Items.Add("Installer Actions");
            item.Tag = typeof(InstallerActionsForm);
            item = listView1.Items.Add("Installer UI");
            item.Tag = typeof(ManifestForm);

            listView1.Items[0].Selected = true;
            listView1.Columns[0].Width = listView1.Width - 8;

            ValidateProjectData();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;

            ListViewItem item = listView1.SelectedItems[0];
            sectionTitle.Text = item.Text;
            sectionPanel.Controls.Clear();
            this.page = (InstallerEditorPage)Activator.CreateInstance((Type)item.Tag);
            sectionPanel.Controls.Add(this.page);
            this.page.Dock = DockStyle.Fill;
            this.page.ProjectData = this.projectData;
        }


        private void openToolStripButton_ButtonClick(object sender, EventArgs e)
        {
            DialogResult result = openInstallerConfigDialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                LocalFileHandler<ScriptProjectData> handler = new LocalFileHandler<ScriptProjectData>();
                this.projectData = handler.Read(openInstallerConfigDialog.FileName);
                
                if (this.page != null && this.projectData != null)
                {
                    this.projectDataPath = openInstallerConfigDialog.FileName;
                    this.bindingSource1.Clear();
                    this.bindingSource1.Add(this.projectData);
                    this.page.ProjectData = this.projectData;
                    this.ValidateProjectData();
                }
            }
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            this.projectData = new ScriptProjectData();
            if (this.page != null)
                this.page.ProjectData = this.projectData;

            this.ValidateProjectData();
        }


        private void saveButton_Click(object sender, EventArgs e)
        {
            if (this.projectDataPath == null || this.projectDataPath == String.Empty)
            {
                saveInstallerConfigDialog.InitialDirectory = this.projectData.RootPath;
                DialogResult result = saveInstallerConfigDialog.ShowDialog();
                if (result == DialogResult.Cancel)
                    return;

                this.projectDataPath = this.saveInstallerConfigDialog.FileName;
            }

            LocalFileHandler<ScriptProjectData> handler = new LocalFileHandler<ScriptProjectData>();
            if (!handler.Write(this.projectDataPath, this.projectData))
                MessageBox.Show("Failed to write file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            InstallerCreator.Pack(this.projectData);
        }


        private void warningLabel_Click(object sender, EventArgs e)
        {

        }
        private void ValidateProjectData()
        {
            ValidationResult result = InstallerCreator.Validate(this.projectData);

            warningLabel.Visible = !(result == ValidationResult.Valid);
            exportButton.Enabled = (result == ValidationResult.Valid);

            if (result == ValidationResult.Valid)
                return;

            String warningText = "";
            if ((result & ValidationResult.RootPathEmpty) == ValidationResult.RootPathEmpty)
                warningText = "Root path must be set.";
            else if ((result & ValidationResult.RootPathNonExisting) == ValidationResult.RootPathNonExisting)
                warningText = "Root path does not exist";
            else if ((result & ValidationResult.ExportTargetEmpty) == ValidationResult.ExportTargetEmpty)
                warningText = "Export target must be set.";
            else if ((result & ValidationResult.ExportTargetInvalid) == ValidationResult.ExportTargetInvalid)
                warningText = "Export target contains invalid characters.";
            else if ((result & ValidationResult.ScriptNameEmpty) == ValidationResult.ScriptNameEmpty)
                warningText = "Script name must be set.";
            else if ((result & ValidationResult.ScriptNameInvalid) == ValidationResult.ScriptNameInvalid)
                warningText = "Script name contains invalid characters.";
            else if ((result & ValidationResult.ScriptAuthorEmpty) == ValidationResult.ScriptAuthorEmpty)
                warningText = "Script author must be set.";
            else if ((result & ValidationResult.ScriptAuthorInvalid) == ValidationResult.ScriptAuthorInvalid)
                warningText = "Script author contains invalid characters.";
            else if ((result & ValidationResult.ScriptIdEmpty) == ValidationResult.ScriptIdEmpty)
                warningText = "Script identifier must be set.";
            else if ((result & ValidationResult.ScriptIdInvalid) == ValidationResult.ScriptIdInvalid)
                warningText = "Script identifier contains invalid characters.";

            warningLabel.Text = warningText;
        }

        private void bindingSource1_CurrentItemChanged(object sender, EventArgs e)
        {
            ValidateProjectData();
        }

        private void bindingSource2_CurrentItemChanged(object sender, EventArgs e)
        {
            ValidateProjectData();
        }
    }
}
