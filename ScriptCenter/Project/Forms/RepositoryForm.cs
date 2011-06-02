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
            //this.fillScriptRefsListView();
        }

        /*
        private ListViewItem addScriptRefToListView(ScriptManifestReference r)
        {
            ListViewItem item = new ListViewItem();
            item.SubItems.Add(new ListViewItem.ListViewSubItem());
            item.Tag = r;
            this.setScriptRefListViewItemText(r, item);

            this.scriptRefsListView.Items.Add(item);

            return item;
        }
        private void setScriptRefListViewItemText(ScriptManifestReference r, ListViewItem item)
        {
            if (r == null || item == null)
                return;

            item.Text = r.Id;
            item.SubItems[1].Text = r.URI;
        }

        private void fillScriptRefsListView()
        {
            this.scriptRefsListView.Items.Clear();
            foreach (ScriptManifestReference r in this.repository.Scripts)
            {
                this.addScriptRefToListView(r);
            }
        }

        private void addScriptRefButton_Click(object sender, EventArgs e)
        {
            ScriptManifestReference r = new ScriptManifestReference();
            //this.repository.Scripts.Add(r);

            ListViewItem item = this.addScriptRefToListView(r);
            item.Selected = true;
        }
        private void removeScriptRefButton_Click(object sender, EventArgs e)
        {
            if (this.scriptRefsListView.SelectedItems.Count != 1)
                return;

            ListViewItem item = this.scriptRefsListView.SelectedItems[0];
            if (!(item.Tag is ScriptManifestReference))
                return;

            //this.repository.Scripts.Remove((ScriptManifestReference)item.Tag);
            this.scriptRefsListView.Items.Remove(item);
            this.scriptRefPropertyGrid.SelectedObject = null;
        }
        private void moveSelectedScriptRef(Int32 direction)
        {
            if (scriptRefsListView.SelectedItems.Count == 0)
                return;

            ListViewItem selItem = scriptRefsListView.SelectedItems[0];
            if (!(selItem.Tag is ScriptManifestReference))
                return;

            ScriptManifestReference r = (ScriptManifestReference)selItem.Tag;
            Int32 refPos = selItem.Index;
            if ((refPos + direction) >= 0 && (refPos + direction) < this.repository.Scripts.Count)
            {
                this.repository.Scripts.Remove(r);
                this.repository.Scripts.Insert(refPos + direction, r);
                scriptRefsListView.Items.Remove(selItem);
                scriptRefsListView.Items.Insert(refPos + direction, selItem);
            }
        }
        private void moveScriptRefUpButton_Click(object sender, EventArgs e)
        {
            this.moveSelectedScriptRef(-1);
        }
        private void moveScriptRefDownButton_Click(object sender, EventArgs e)
        {
            this.moveSelectedScriptRef(1);
        }

        private void scriptRefsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.scriptRefsListView.SelectedItems.Count != 1)
            {
                this.scriptRefPropertyGrid.SelectedObject = null;
                return;
            }

            ListViewItem item = this.scriptRefsListView.SelectedItems[0];
            if (!(item.Tag is ScriptManifestReference))
                return;

            this.scriptRefPropertyGrid.SelectedObject = this.scriptRefsListView.SelectedItems[0].Tag;
        }
        private void scriptRefPropertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (this.scriptRefsListView.SelectedItems.Count != 1)
                return;

            ListViewItem item = this.scriptRefsListView.SelectedItems[0];
            if (!(item.Tag is ScriptManifestReference))
                return;

            this.setScriptRefListViewItemText((ScriptManifestReference)item.Tag, item);
        }

        private void scriptRefsListView_Resize(object sender, EventArgs e)
        {
            columnHeader2.Width = scriptRefsListView.Width - columnHeader1.Width - 4;
        }
        */
        

        
    }
}
