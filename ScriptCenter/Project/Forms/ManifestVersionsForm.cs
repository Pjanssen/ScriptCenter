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
    public partial class ManifestVersionsForm : UserControl
    {
        private ScriptManifest manifest;

        public ManifestVersionsForm(ScriptManifest manifest)
        {
            InitializeComponent();

            if (manifest == null)
                throw new ArgumentNullException("Manifest argument cannot be null.");

            this.manifest = manifest;
            this.fillVersionsListView();
        }

        private void fillVersionsListView()
        {
            this.versionsListView.BeginUpdate();
            this.versionsListView.Items.Clear();
            foreach (ScriptVersion version in manifest.Versions)
                this.addVersionToListView(version);
            this.versionsListView.EndUpdate();
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
            this.versionsListView.Columns[1].Width = this.versionsListView.Width - this.versionsListView.Columns[0].Width - 8;
        }
    }
}
