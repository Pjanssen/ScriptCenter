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

namespace ScriptCenter.Installer.Editor
{
    public partial class ManifestForm : InstallerEditorPage
    {
        public ManifestForm()
        {
            InitializeComponent();
            this.versionPropertyGrid.PropertyValueChanged += versionPropertyGrid_PropertyValueChanged;
        }

        public override ScriptProjectData ProjectData
        {
            get
            {
                return base.ProjectData;
            }
            set
            {
                base.ProjectData = value;
                if (value != null && value.Manifest != null)
                {
                    this.scriptManifestBindingSource.Clear();
                    this.scriptManifestBindingSource.Add(value.Manifest);

                    this.versionsListView.BeginUpdate();
                    this.versionsListView.Items.Clear();
                    foreach (ScriptVersion version in value.Manifest.Versions)
                        this.addVersionToListView(version);
                    this.versionsListView.EndUpdate();
                }
            }
        }

        private void scriptAuthor_Validated(object sender, EventArgs e)
        {
            setDefaultID();
        }
        private void scriptName_Validated(object sender, EventArgs e)
        {
            setDefaultID();
        }
        private void setDefaultID()
        {
            //TODO: Use manifest instead of textfields
            if (this.scriptName.Text != String.Empty && this.scriptAuthor.Text != String.Empty && this.scriptId.Text == String.Empty)
            {
                this.scriptId.Text = System.Text.RegularExpressions.Regex.Replace(this.scriptAuthor.Text.ToLower(), @"\s", "");
                this.scriptId.Text += ".";
                this.scriptId.Text += System.Text.RegularExpressions.Regex.Replace(this.scriptName.Text.ToLower(), @"\s", "");
            }
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
            this.ProjectData.Manifest.Versions.Add(version);

            ListViewItem item = this.addVersionToListView(version);
            item.Selected = true;
        }
        private void removeVersionButton_Click(object sender, EventArgs e)
        {
            if (this.versionsListView.SelectedItems.Count != 1)
                return;

            ListViewItem selItem = this.versionsListView.SelectedItems[0];
            this.versionsListView.Items.Remove(selItem);

            if (this.ProjectData == null || this.ProjectData.Manifest == null || selItem.Tag == null || !(selItem.Tag is ScriptVersion))
                return;

            this.ProjectData.Manifest.Versions.Remove((ScriptVersion)selItem.Tag);
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
