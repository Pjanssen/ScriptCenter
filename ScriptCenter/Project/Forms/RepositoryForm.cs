using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ScriptCenter.Repository;

namespace ScriptCenter.Project.Forms
{
    public partial class RepositoryForm : UserControl
    {
        private ScriptRepository repository;

        public RepositoryForm(ScriptRepository repository)
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
            foreach (String s in this.repository.Scripts)
            {
                this.addScriptToTreeView(s, this.scriptsTreeView.Nodes);
            }

            this.scriptsTreeView.EndUpdate();
        }
        private TreeNode addScriptToTreeView(String script, TreeNodeCollection parentNodeCollection)
        {
            TreeNode tn = new TreeNode(script);
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
            foreach (String s in cat.Scripts)
            {
                this.addScriptToTreeView(s, tn.Nodes);
            }

            this.scriptsTreeView.Nodes.Add(tn);

            return tn;
        }

        private void addScriptButton_Click(object sender, EventArgs e)
        {
            String newScriptRef = "new script reference";

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
        }
        private void addCategoryButton_Click(object sender, EventArgs e)
        {
            ScriptRepositoryCategory newCat = new ScriptRepositoryCategory("new category");
            this.repository.Categories.Add(newCat);
            TreeNode tn = this.addCategoryToTreeView(newCat);
            this.scriptsTreeView.SelectedNode = tn;
        }
        private void removeButton_Click(object sender, EventArgs e)
        {
            TreeNode selNode = this.scriptsTreeView.SelectedNode;
            if (selNode == null)
                return;

            if (selNode.Tag is ScriptRepositoryCategory)
                this.repository.Categories.Remove((ScriptRepositoryCategory)selNode.Tag);
            else if (selNode.Tag is String)
            {
                if (selNode.Parent != null)
                {
                    if (selNode.Parent.Tag is ScriptRepositoryCategory)
                        ((ScriptRepositoryCategory)selNode.Parent.Tag).Scripts.Remove((String)selNode.Tag);
                }
                else
                    this.repository.Scripts.Remove((String)selNode.Tag);

            }

            selNode.Remove();
        }

    }
}
