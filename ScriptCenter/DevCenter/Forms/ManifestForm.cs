using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ScriptCenter.Repository;
using ScriptCenter.Controls;

namespace ScriptCenter.DevCenter.Forms
{
    public partial class ManifestForm : UserControl
    {
        private ScriptManifest manifest;

        public ManifestForm(DevCenter devCenter, ScriptManifest manifest)
        {
            InitializeComponent();

            if (manifest == null)
                throw new ArgumentNullException("Manifest cannot be null");

            this.manifest = manifest;

            this.versionPropertyGrid.PropertyValueChanged += versionPropertyGrid_PropertyValueChanged;


            this.scriptManifestBindingSource.Add(manifest);

            this.versionsListView.BeginUpdate();
            foreach (ScriptVersion version in manifest.Versions)
                this.addVersionToListView(version);
            this.versionsListView.EndUpdate();
        }

        private void scriptName_Validated(object sender, EventArgs e)
        {
            setDefaultID();
        }

        private void scriptAuthor_Validated(object sender, EventArgs e)
        {
            setDefaultID();
        }

        private void setDefaultID()
        {
            if (this.scriptName.Text == String.Empty || this.scriptAuthor.Text == String.Empty || (this.manifest.Id != null && this.manifest.Id != String.Empty))
                return;

            String defaultId = System.Text.RegularExpressions.Regex.Replace(this.scriptAuthor.Text.ToLower(), @"\s", "");
            defaultId += ".";
            defaultId += System.Text.RegularExpressions.Regex.Replace(this.scriptName.Text.ToLower(), @"\s", "");
            
            this.manifest.Id = defaultId;
        }


        private ListViewItem addVersionToListView(ScriptVersion version)
        {
            ListViewItem item = new ListViewItem();
            item.SubItems.Add(new ListViewItem.ListViewSubItem());
            item.Tag = version;
            setVersionListViewItemText(version, item);

            this.versionsListView.Items.Add(item);
           
            return item;
        }
        private void setVersionListViewItemText(ScriptVersion version, ListViewItem item)
        {
            if (version == null || item == null)
                return;

            item.Text = version.VersionNumber.ToString();
            item.SubItems[1].Text = version.ScriptPath;

            this.versionsListView.Sort();
        }


        private void addVersionButton_Click(object sender, EventArgs e)
        {
            ScriptVersion version = new ScriptVersion();
            this.manifest.Versions.Add(version);

            ListViewItem item = this.addVersionToListView(version);
            item.Selected = true;
        }
        private void removeVersionButton_Click(object sender, EventArgs e)
        {
            if (this.versionsListView.SelectedItems.Count != 1)
                return;

            ListViewItem selItem = this.versionsListView.SelectedItems[0];
            this.versionsListView.Items.Remove(selItem);

            if (selItem.Tag == null || !(selItem.Tag is ScriptVersion))
                return;

            this.manifest.Versions.Remove((ScriptVersion)selItem.Tag);
        }


        private void versionsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.versionsListView.SelectedItems.Count != 1)
            {
                this.versionPropertyGrid.SelectedObject = null;
                return;
            }

            ListViewItem selItem = this.versionsListView.SelectedItems[0];

            if (selItem.Tag == null || !(selItem.Tag is ScriptVersion))
                return;

            this.versionPropertyGrid.SelectedObject = selItem.Tag;
            this.versionPropertyGrid.ExpandAllGridItems();
        }
        private void versionPropertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (this.versionsListView.SelectedItems.Count != 1)
                return;

            ListViewItem selItem = this.versionsListView.SelectedItems[0];

            if (!(selItem.Tag is ScriptVersion))
                return;

            this.setVersionListViewItemText((ScriptVersion)selItem.Tag, selItem);
        }

        private void versionsListView_Resize(object sender, EventArgs e)
        {
            this.versionsListView.Columns[1].Width = this.versionsListView.Width - this.versionsListView.Columns[0].Width - 24;
        }

        

    }
}
