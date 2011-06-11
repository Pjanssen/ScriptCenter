using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ScriptCenter.DevCenter.Forms;
using ScriptCenter.Repository;
using ScriptCenter.Package;
using ScriptCenter.Utils;

namespace ScriptCenter.DevCenter
{
public partial class DevCenter : Form
{
    public Dictionary<Object, String> Files { get; set; }

    public DevCenter()
    {
        InitializeComponent();

        this.Files = new Dictionary<Object, String>();

        this.titlePanel.Visible = false;

        this.filesTree.AfterSelect += new TreeViewEventHandler(filesTree_AfterSelect);
        this.newButtonClickHandler = newManifestButton_Click;
    }

    void filesTree_AfterSelect(object sender, TreeViewEventArgs e)
    {
        if (e.Node == null || !(e.Node.Tag is TreeNodeData))
            return;

        TreeNodeData data = (TreeNodeData)e.Node.Tag;
        Control form = (Control)Activator.CreateInstance(data.FormType, this, data.Data);

        this.setSectionPanel(e.Node.Text, e.Node.ImageKey, form);

        TreeNode rootNode = this.getRootNode(e.Node);
        this.exportButton.Enabled = (rootNode != null && rootNode.Tag is TreeNodeData && ((TreeNodeData)rootNode.Tag).Data is ScriptPackage);
    }
    private TreeNode getRootNode(TreeNode treeNode)
    {
        if (treeNode == null)
            return null;

        TreeNode rootNode = treeNode;
        while (rootNode.Parent != null)
            rootNode = rootNode.Parent;

        return rootNode;
    }

    private void setSectionPanel(String title, String imageKey, Control c)
    {
        this.titlePanel.Visible = true;

        this.sectionTitle.Text = title;
        this.sectionTitle.ImageKey = imageKey;
        this.sectionPanel.Controls.Clear();
        this.sectionPanel.Controls.Add(c);
        c.Dock = DockStyle.Fill;
    }

    private TreeNode addManifestToTree(ScriptManifest manifest, String filePath)
    {
        TreeNode tn = new TreeNode(manifest.Name);
        tn.ImageKey = tn.SelectedImageKey = "manifest";
        tn.Tag = new TreeNodeData(manifest, typeof(ManifestForm));
        
        TreeNode metadataTn = new TreeNode("Metadata");
        metadataTn.ImageKey = metadataTn.SelectedImageKey = "manifest_metadata";
        metadataTn.Tag = new TreeNodeData(manifest, typeof(ManifestMetadataForm));
        tn.Nodes.Add(metadataTn);

        this.filesTree.Nodes.Add(tn);
        this.Files.Add(manifest, filePath);

        manifest.PropertyChanged += new PropertyChangedEventHandler(propertyChanged);

        return tn;
    }
    private TreeNode addPackageToTree(ScriptPackage package, String filePath)
    {
        TreeNode tn = new TreeNode(package.Name);
        tn.ImageKey = tn.SelectedImageKey = "package";
        tn.Tag = new TreeNodeData(package, typeof(PackageForm));

        TreeNode manifestTn = new TreeNode("Manifest");
        manifestTn.ImageKey = manifestTn.SelectedImageKey = "manifest";
        manifestTn.Tag = new TreeNodeData(package.Manifest, typeof(ManifestForm));
        tn.Nodes.Add(manifestTn);

        TreeNode metadataTn = new TreeNode("Metadata");
        metadataTn.ImageKey = metadataTn.SelectedImageKey = "manifest_metadata";
        metadataTn.Tag = new TreeNodeData(package.Manifest, typeof(ManifestMetadataForm));
        manifestTn.Nodes.Add(metadataTn);

        TreeNode actionsTn = new TreeNode("Installer Actions");
        actionsTn.ImageKey = actionsTn.SelectedImageKey = "action";
        actionsTn.Tag = new TreeNodeData(package, typeof(InstallerActionsForm));
        tn.Nodes.Add(actionsTn);

        TreeNode uiTn = new TreeNode("Installer UI");
        uiTn.ImageKey = uiTn.SelectedImageKey = "dialog";
        uiTn.Tag = new TreeNodeData(package, typeof(InstallerUIForm));
        tn.Nodes.Add(uiTn);

        this.filesTree.Nodes.Add(tn);
        this.Files.Add(package, filePath);

        package.PropertyChanged += new PropertyChangedEventHandler(propertyChanged);
        return tn;
    }
    private TreeNode addRepositoryToTree(ScriptRepository repo, String filePath)
    {
        TreeNode tn = new TreeNode(repo.Name);
        tn.ImageKey = tn.SelectedImageKey = "repository";
        tn.Tag = new TreeNodeData(repo, typeof(RepositoryForm));

        this.filesTree.Nodes.Add(tn);
        this.Files.Add(repo, filePath);

        repo.PropertyChanged += new PropertyChangedEventHandler(propertyChanged);
        return tn;
    }


    void propertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "Name")
        {
            //Get the new value using reflection.
            Type t = sender.GetType();
            System.Reflection.PropertyInfo pi = t.GetProperty(e.PropertyName);
            String newName = (String)pi.GetValue(sender, null);

            //Set the new section title.
            this.sectionTitle.Text = newName;

            //Find the matching treenode and set its text.
            foreach (TreeNode tn in this.filesTree.Nodes)
            {
                if (tn.Tag is TreeNodeData && ((TreeNodeData)tn.Tag).Data == sender)
                {
                    tn.Text = newName;
                    break;
                }
            }
        }
    }

    private void openButton_Click(object sender, EventArgs e)
    {
        DialogResult result = openFileDialog.ShowDialog();
        if (result == System.Windows.Forms.DialogResult.OK)
        {
            String selFile = openFileDialog.FileName;
            if (selFile.EndsWith(ScriptManifest.DefaultExtension))
                this.readManifest(selFile);
            else if (selFile.EndsWith(ScriptPackage.DefaultExtension))
                this.readPackage(selFile);
            else if (selFile.EndsWith(ScriptRepository.DefaultExtension))
                this.readRepository(selFile);
        }
    }
    private void saveButton_Click(object sender, EventArgs e)
    {
        if (this.filesTree.SelectedNode == null || !(this.filesTree.SelectedNode.Tag is TreeNodeData))
            return;

        TreeNode rootNode = this.getRootNode(this.filesTree.SelectedNode);
        if (rootNode == null)
            return;

        TreeNodeData data = (TreeNodeData)rootNode.Tag;
        String filePath = this.Files[data.Data];
        if (filePath == String.Empty)
        {
            if (data.Data is ScriptManifest)
            {
                saveFileDialog.FileName = ((ScriptManifest)data.Data).Name.Replace(' ', '_');
                saveFileDialog.Filter = "Script Manifest (*.scmanif)|*.scmanif";
            }
            else if (data.Data is ScriptPackage)
            {
                saveFileDialog.FileName = ((ScriptPackage)data.Data).Name.Replace(' ', '_');
                saveFileDialog.Filter = "Script Package (*.scpack)|*.scpack";
            }
            else if (data.Data is ScriptRepository)
            {
                saveFileDialog.FileName = ((ScriptRepository)data.Data).Name.Replace(' ', '_');
                saveFileDialog.Filter = "Script Repository (*.screpo)|*.screpo";
            }

            DialogResult result = saveFileDialog.ShowDialog();
            if (result != System.Windows.Forms.DialogResult.OK)
                return;
            filePath = this.Files[data.Data] = saveFileDialog.FileName;
        }

        if (data.Data is ScriptManifest)
            this.writeManifest(filePath, (ScriptManifest)data.Data);
        else if (data.Data is ScriptPackage)
            this.writePackage(filePath, (ScriptPackage)data.Data);
        else if (data.Data is ScriptRepository)
            this.writeRepository(filePath, (ScriptRepository)data.Data);
    }
    private void exportButton_Click(object sender, EventArgs e)
    {
        TreeNode rootNode = this.getRootNode(this.filesTree.SelectedNode);
        if (rootNode != null && rootNode.Tag is TreeNodeData && ((TreeNodeData)rootNode.Tag).Data is ScriptPackage)
        {
            if (ScriptPacker.Pack((ScriptPackage)((TreeNodeData)rootNode.Tag).Data))
                MessageBox.Show("Package export successful.", "Package Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void switchNewButtonImageText(object sender, ClickHandler handler)
    {
        if (!(sender is ToolStripMenuItem))
            return;

        this.newButtonClickHandler = handler;
        newButton.Image = ((ToolStripMenuItem)sender).Image;
        newButton.Text = ((ToolStripMenuItem)sender).Text;
    }
    private delegate void ClickHandler(object sender, EventArgs e);
    private ClickHandler newButtonClickHandler;
    private void newButton_ButtonClick(object sender, EventArgs e)
    {
        if (newButtonClickHandler != null)
            this.newButtonClickHandler(sender, e);
    }

    private void newManifestButton_Click(object sender, EventArgs e)
    {
        this.switchNewButtonImageText(sender, newManifestButton_Click);

        ScriptManifest m = new ScriptManifest() { Name = "New Script" };
        m.Versions.Add(new ScriptVersion());
        TreeNode tn = addManifestToTree(m, String.Empty);
        tn.Expand();
        this.filesTree.SelectedNode = tn;
    }
    private void newPackageButton_Click(object sender, EventArgs e)
    {
        this.switchNewButtonImageText(sender, newPackageButton_Click);

        ScriptPackage p = new ScriptPackage("New Package");
        ScriptVersion v = new ScriptVersion();
        v.ScriptPath = p.PackageFile.RelativePathComponent;
        p.Manifest.Versions.Add(v);
        TreeNode tn = addPackageToTree(p, String.Empty);
        tn.Expand();
        this.filesTree.SelectedNode = tn;
    }
    private void newRepositoryButton_Click(object sender, EventArgs e)
    {
        this.switchNewButtonImageText(sender, newRepositoryButton_Click);

        ScriptRepository r = new ScriptRepository("New Repository");
        TreeNode tn = addRepositoryToTree(r, String.Empty);
        tn.Expand();
        this.filesTree.SelectedNode = tn;
    }

    private void readManifest(String file)
    {
        JsonFileHandler<ScriptManifest> handler = new JsonFileHandler<ScriptManifest>();
        try
        {
            ScriptManifest manif = handler.Read(file);
            TreeNode tn = this.addManifestToTree(manif, file);
            filesTree.SelectedNode = tn;
        }
        catch (Exception exc)
        {
            MessageBox.Show(exc.Message);
        }
    }
    private void readPackage(String file)
    {
        JsonFileHandler<ScriptPackage> handler = new JsonFileHandler<ScriptPackage>();
        try
        {
            ScriptPackage pack = handler.Read(file);
            TreeNode tn = this.addPackageToTree(pack, file);
            filesTree.SelectedNode = tn;
        }
        catch (Exception exc)
        {
            MessageBox.Show(exc.Message);
        }
    }
    private void readRepository(String file)
    {
        JsonFileHandler<ScriptRepository> handler = new JsonFileHandler<ScriptRepository>();
        try
        {
            ScriptRepository repo = handler.Read(file);
            TreeNode tn = this.addRepositoryToTree(repo, file);
            filesTree.SelectedNode = tn;
        }
        catch (Exception exc)
        {
            MessageBox.Show(exc.Message);
        }
    }

    private void writeManifest(String filePath, ScriptManifest manifest)
    {
        JsonFileHandler<ScriptManifest> handler = new JsonFileHandler<ScriptManifest>();
        try
        {
            handler.Write(filePath, manifest);
        }
        catch (Exception exc)
        {
            MessageBox.Show(exc.Message);
        }
    }
    private void writePackage(String filePath, ScriptPackage package)
    {
        JsonFileHandler<ScriptPackage> handler = new JsonFileHandler<ScriptPackage>();
        try
        {
            handler.Write(filePath, package);
        }
        catch (Exception exc)
        {
            MessageBox.Show(exc.Message);
        }
    }
    private void writeRepository(String filePath, ScriptRepository repository)
    {
        JsonFileHandler<ScriptRepository> handler = new JsonFileHandler<ScriptRepository>();
        try
        {
            handler.Write(filePath, repository);
        }
        catch (Exception exc)
        {
            MessageBox.Show(exc.Message);
        }
    }

    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        foreach (Control c in ((Control)sender).Controls)
        {
            e.Graphics.DrawRectangle(SystemPens.ControlDark, new Rectangle(c.Location.X - 1, c.Location.Y - 1, c.Width + 1, c.Height + 1));
        }
    }
    
    
}
}
