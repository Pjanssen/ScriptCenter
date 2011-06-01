using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ScriptCenter.Project.Forms;
using ScriptCenter.Repository;
using ScriptCenter.Installer;

namespace ScriptCenter.Project
{
    public partial class ProjectEditor : Form
    {
        public ProjectEditor()
        {
            InitializeComponent();

            this.filesTree.AfterSelect += new TreeViewEventHandler(filesTree_AfterSelect);
        }

        void filesTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null || !(e.Node.Tag is TreeNodeData))
                return;

            TreeNodeData data = (TreeNodeData)e.Node.Tag;
            Control form = (Control)Activator.CreateInstance(data.FormType, data.Data);

            this.setSectionPanel(e.Node.Text, e.Node.ImageKey, form);
        }


        private void setSectionPanel(String title, String imageKey, Control c)
        {
            this.sectionTitle.Text = title;
            this.sectionTitle.ImageKey = imageKey;
            this.sectionPanel.Controls.Clear();
            this.sectionPanel.Controls.Add(c);
            c.Dock = DockStyle.Fill;
        }


        private void addManifestToTree(ScriptManifest manifest)
        {
            TreeNode tn = new TreeNode(manifest.Name);
            tn.ImageKey = tn.SelectedImageKey = "manifest";
            tn.Tag = new TreeNodeData(manifest, typeof(ManifestForm));

            TreeNode manifestTn = new TreeNode("Manifest");
            manifestTn.ImageKey = manifestTn.SelectedImageKey = "manifest";
            manifestTn.Tag = new TreeNodeData(manifest, typeof(ManifestForm));
            tn.Nodes.Add(manifestTn);

            TreeNode metadataTn = new TreeNode("Metadata");
            metadataTn.ImageKey = metadataTn.SelectedImageKey = "manifest_metadata";
            metadataTn.Tag = new TreeNodeData(manifest, typeof(ManifestMetadataForm));
            tn.Nodes.Add(metadataTn);

            this.filesTree.Nodes.Add(tn);
        }
        private void addPackageToTree(InstallerConfiguration config)
        {
            TreeNode tn = new TreeNode("Test");
            tn.ImageKey = tn.SelectedImageKey = "package";
            tn.Tag = new TreeNodeData(config, typeof(InstallerActionsForm));

            TreeNode actionsTn = new TreeNode("Installer Actions");
            actionsTn.ImageKey = actionsTn.SelectedImageKey = "action";
            actionsTn.Tag = new TreeNodeData(config, typeof(InstallerActionsForm));
            tn.Nodes.Add(actionsTn);

            TreeNode uiTn = new TreeNode("Installer UI");
            uiTn.ImageKey = uiTn.SelectedImageKey = "dialog";
            uiTn.Tag = new TreeNodeData(config, typeof(InstallerActionsForm));
            tn.Nodes.Add(uiTn);

            this.filesTree.Nodes.Add(tn);
        }
        private void addRepositoryToTree(ScriptRepository repo)
        {
            TreeNode tn = new TreeNode(repo.Name);
            tn.ImageKey = tn.SelectedImageKey = "repository";
            tn.Tag = new TreeNodeData(repo, typeof(RepositoryForm));

            this.filesTree.Nodes.Add(tn);
        }

        private void newButton_Click(object sender, EventArgs e)
        {

        }
        private void openButton_Click(object sender, EventArgs e)
        {

        }
        private void saveButton_Click(object sender, EventArgs e)
        {

        }

        private void newManifestButton_Click(object sender, EventArgs e)
        {
            ScriptManifest m = new ScriptManifest() { Name = "Outliner" };
            addManifestToTree(m);
        }
        private void newPackageButton_Click(object sender, EventArgs e)
        {
            InstallerConfiguration c = new InstallerConfiguration();
            addPackageToTree(c);
        }
        private void newRepositoryButton_Click(object sender, EventArgs e)
        {
            ScriptRepository r = new ScriptRepository("Pier's repo");
            addRepositoryToTree(r);
        }
    }
}
