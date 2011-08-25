using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ScriptCenter.Repository;

namespace ScriptCenter.DevCenter.Forms
{
    public partial class RepositoryForm : UserControl
    {
        private ScriptRepository repository;

        public RepositoryForm(DevCenter devCenter, ScriptRepository repository)
        {
            InitializeComponent();

            if (repository == null)
                throw new ArgumentNullException("Repository argument cannot be null");

            this.repository = repository;

            this.scriptRepositoryBindingSource.Add(repository);

            this.fillScriptsTreeView();
        }

        private void fillScriptsTreeView()
        {
            if (this.repository == null)
                return;

            this.scriptsTreeView.BeginUpdate();

            foreach (ScriptRepositoryCategory c in repository.Categories)
            {
                this.addCategoryToTreeView(c);
            }
            foreach (ScriptManifestReference s in this.repository.Scripts)
            {
                this.addScriptToTreeView(s, this.scriptsTreeView.Nodes);
            }

            this.scriptsTreeView.EndUpdate();
        }
        private TreeNode addScriptToTreeView(ScriptManifestReference script, TreeNodeCollection parentNodeCollection)
        {
            TreeNode tn = new TreeNode(script.ToString());
            tn.ImageKey = tn.SelectedImageKey = "manifest_link";
            tn.Tag = script;
            parentNodeCollection.Add(tn);

            return tn;
        }
        private TreeNode addCategoryToTreeView(ScriptRepositoryCategory cat)
        {
            TreeNode tn = new TreeNode(cat.Name);
            tn.ImageKey = tn.SelectedImageKey = "repository_category";
            tn.Tag = cat;
            foreach (ScriptManifestReference s in cat.Scripts)
            {
                this.addScriptToTreeView(s, tn.Nodes);
            }

            this.scriptsTreeView.Nodes.Add(tn);

            return tn;
        }

        private void addScriptButton_Click(object sender, EventArgs e)
        {
            ScriptManifestReference newScriptRef = new ScriptManifestReference("new script reference");

            TreeNode selNode = this.scriptsTreeView.SelectedNode;
            TreeNodeCollection targetNodeCollection = this.scriptsTreeView.Nodes;
            ScriptRepositoryCategory targetCat = this.repository.DefaultCategory;
            if (selNode != null)
            {
                if (selNode.Tag is ScriptRepositoryCategory)
                {
                    targetNodeCollection =selNode.Nodes;
                    targetCat = (ScriptRepositoryCategory)selNode.Tag;
                }
                else if (selNode.Parent != null && selNode.Parent.Tag is ScriptRepositoryCategory)
                {
                    targetNodeCollection = selNode.Parent.Nodes;
                    targetCat = (ScriptRepositoryCategory)selNode.Parent.Tag;
                }
            }
            
            targetCat.Scripts.Add(newScriptRef);
            TreeNode tn = this.addScriptToTreeView(newScriptRef, targetNodeCollection);
            this.scriptsTreeView.SelectedNode = tn;
            tn.BeginEdit();
        }
        private void addCategoryButton_Click(object sender, EventArgs e)
        {
            ScriptRepositoryCategory newCat = new ScriptRepositoryCategory("new category");
            this.repository.Categories.Add(newCat);
            TreeNode tn = this.addCategoryToTreeView(newCat);
            this.scriptsTreeView.SelectedNode = tn;
            tn.BeginEdit();
        }
        private void removeButton_Click(object sender, EventArgs e)
        {
            TreeNode selNode = this.scriptsTreeView.SelectedNode;
            if (selNode == null)
                return;

            if (selNode.Tag is ScriptRepositoryCategory)
                this.repository.Categories.Remove((ScriptRepositoryCategory)selNode.Tag);
            else if (selNode.Tag is ScriptManifestReference)
            {
                if (selNode.Parent != null)
                {
                    if (selNode.Parent.Tag is ScriptRepositoryCategory)
                        ((ScriptRepositoryCategory)selNode.Parent.Tag).Scripts.Remove((ScriptManifestReference)selNode.Tag);
                }
                else
                    this.repository.Scripts.Remove((ScriptManifestReference)selNode.Tag);

            }

            selNode.Remove();
        }

        private void scriptsTreeView_MouseUp(object sender, MouseEventArgs e)
        {
            TreeNode tn = this.scriptsTreeView.GetNodeAt(e.Location);
            if (tn == null)
                this.scriptsTreeView.SelectedNode = null;
        }
        private void scriptsTreeView_DoubleClick(object sender, EventArgs e)
        {
            TreeNode tn = this.scriptsTreeView.SelectedNode;
            if (tn != null && !tn.IsEditing)
            {
                tn.BeginEdit();
            }
        }
        private void scriptsTreeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.CancelEdit || e.Label == null)
                return;

            e.Node.Text = e.Label;
            if (e.Node.Tag is ScriptRepositoryCategory)
                ((ScriptRepositoryCategory)e.Node.Tag).Name = e.Label;
            else if (e.Node.Tag is ScriptManifestReference)
                ((ScriptManifestReference)e.Node.Tag).Uri.AbsolutePath = e.Label;
        }


        private TreeNode highlightedNode;
        private void setNodeHighlight(TreeNode tn)
        {
            this.removeNodeHighlight();
            tn.BackColor = SystemColors.Control;
            highlightedNode = tn;
        }
        private void removeNodeHighlight()
        {
            if (highlightedNode != null)
                highlightedNode.BackColor = this.scriptsTreeView.BackColor;

            highlightedNode = null;
        }
        private void scriptsTreeView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (this.scriptsTreeView.SelectedNode != null && this.scriptsTreeView.SelectedNode.Tag is ScriptManifestReference)
                this.scriptsTreeView.DoDragDrop(e.Item, DragDropEffects.Move);
        }
        private void scriptsTreeView_DragOver(object sender, DragEventArgs e)
        {
            TreeNode tn = this.scriptsTreeView.GetNodeAt(this.scriptsTreeView.PointToClient(new Point(e.X, e.Y)));
            if (tn == null || (tn != this.scriptsTreeView.SelectedNode && tn.Tag is ScriptRepositoryCategory))
            {
                e.Effect = DragDropEffects.Move;
                if (tn != null)
                    this.setNodeHighlight(tn);
            }
            else
            {
                e.Effect = DragDropEffects.None;
                this.removeNodeHighlight();
            }
        }
        private void scriptsTreeView_DragLeave(object sender, EventArgs e)
        {
            this.removeNodeHighlight();
        }
        private void scriptsTreeView_DragDrop(object sender, DragEventArgs e)
        {
            this.removeNodeHighlight();

            TreeNode selNode = this.scriptsTreeView.SelectedNode;
            TreeNode tn = this.scriptsTreeView.GetNodeAt(this.scriptsTreeView.PointToClient(new Point(e.X, e.Y)));
            if (tn == null || (tn != selNode && tn.Tag is ScriptRepositoryCategory))
            {
                ScriptRepositoryCategory oldParentCategory = this.repository.DefaultCategory;
                if (selNode.Parent != null && selNode.Parent.Tag is ScriptRepositoryCategory)
                    oldParentCategory = (ScriptRepositoryCategory)selNode.Parent.Tag;

                ScriptRepositoryCategory newParentCategory = this.repository.DefaultCategory;
                if (tn != null)
                    newParentCategory = (ScriptRepositoryCategory)tn.Tag;

                oldParentCategory.Scripts.Remove((ScriptManifestReference)selNode.Tag);
                newParentCategory.Scripts.Add((ScriptManifestReference)selNode.Tag);

                selNode.Remove();
                TreeNodeCollection newParentCollection = this.scriptsTreeView.Nodes;
                if (tn != null)
                    newParentCollection = tn.Nodes;
                newParentCollection.Add(selNode);
                this.scriptsTreeView.SelectedNode = selNode;
            }
        }



    }
}
