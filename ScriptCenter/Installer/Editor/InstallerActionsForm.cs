using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using ScriptCenter.Installer.Actions;

namespace ScriptCenter.Installer.Editor
{
    public partial class InstallerActionsForm : InstallerEditorPage
    {
        public InstallerActionsForm()
        {
            InitializeComponent();

            actionsComboBox.Format += new ListControlConvertEventHandler(actionsComboBox_Format);
            actionPropertyGrid.PropertyValueChanged += new PropertyValueChangedEventHandler(actionPropertyGrid_PropertyValueChanged);

            fillActionsCombobox();
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
                fillActionsListView();
            }
        }


        private class ActionComboBoxItem
        {
            public Type ActionType { get; set; }
            public String ActionName { get; set; }
        }

        void actionsComboBox_Format(object sender, ListControlConvertEventArgs e)
        {
            e.Value = ((ActionComboBoxItem)e.ListItem).ActionName;
        }

        private void fillActionsCombobox()
        {
            Type actionType = typeof(InstallerAction);
            Assembly assembly = Assembly.GetAssembly(actionType);
            List<Type> types = assembly.GetTypes().Where(type => type.IsSubclassOf(actionType)).ToList();

            foreach (Type t in types)
            {
                if (!t.IsAbstract && !t.IsInterface)
                {
                    ActionComboBoxItem item = new ActionComboBoxItem();
                    item.ActionName = ((InstallerAction)Activator.CreateInstance(t)).ActionName; //Probably not the best way to handle this..
                    item.ActionType = t;
                    actionsComboBox.Items.Add(item);
                }
            }

            actionsComboBox.SelectedIndex = 0;
        }

        private ListViewItem addActionToListView(InstallerAction action)
        {
            ListViewItem lvItem = new ListViewItem();
            lvItem.Text = action.ActionName;
            lvItem.Tag = action;
            lvItem.ImageKey = action.ActionImageKey;
            lvItem.SubItems.Add(new ListViewItem.ListViewSubItem(lvItem, action.ActionDetails));

            actionsListView.Items.Add(lvItem);

            return lvItem;
        }

        private void fillActionsListView()
        {
            this.actionsListView.BeginUpdate();

            this.actionsListView.Items.Clear();
            foreach (InstallerAction action in this.ProjectData.InstallerConfig.InstallerActions)
            {
                addActionToListView(action);
            }

            this.actionsListView.EndUpdate();
        }

        private void addActionButton_Click(object sender, EventArgs e)
        {
            ActionComboBoxItem item = (ActionComboBoxItem)actionsComboBox.SelectedItem;
            InstallerAction action = (InstallerAction)Activator.CreateInstance(item.ActionType);
            this.ProjectData.InstallerConfig.InstallerActions.Add(action);

            ListViewItem lvItem = addActionToListView(action);
            lvItem.Selected = true;
        }


        private void removeActionButton_Click(object sender, EventArgs e)
        {
            if (actionsListView.SelectedItems.Count == 0)
                return;

            InstallerAction action = (InstallerAction)actionsListView.SelectedItems[0].Tag;
            this.ProjectData.InstallerConfig.InstallerActions.Remove(action);

            actionsListView.Items.Remove(actionsListView.SelectedItems[0]);
        }

        private void actionsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (actionsListView.SelectedItems.Count > 0)
            {
                InstallerAction action = (InstallerAction)actionsListView.SelectedItems[0].Tag;
                actionPropertyGrid.SelectedObject = action;
            }
            else
                actionPropertyGrid.SelectedObject = null;
        }


        void actionPropertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (actionsListView.SelectedItems.Count == 0)
                return;
            
            InstallerAction action = (InstallerAction)actionsListView.SelectedItems[0].Tag;
            actionsListView.SelectedItems[0].SubItems[1].Text = action.ActionDetails;
        }

        private void moveSelectedAction(Int32 direction)
        {
            if (actionsListView.SelectedItems.Count == 0)
                return;

            ListViewItem selItem = actionsListView.SelectedItems[0];
            InstallerAction action = (InstallerAction)selItem.Tag;
            Int32 actionPos = selItem.Index;
            if ((actionPos + direction) >= 0 && (actionPos + direction) < this.ProjectData.InstallerConfig.InstallerActions.Count)
            {
                this.ProjectData.InstallerConfig.InstallerActions.Remove(action);
                this.ProjectData.InstallerConfig.InstallerActions.Insert(actionPos + direction, action);
                actionsListView.Items.Remove(selItem);
                actionsListView.Items.Insert(actionPos + direction, selItem);
            }
        }
        private void moveActionUpButton_Click(object sender, EventArgs e)
        {
            moveSelectedAction(-1);
        }

        private void moveActionDownButton_Click(object sender, EventArgs e)
        {
            moveSelectedAction(1);
        }

        private void actionsListView_SizeChanged(object sender, EventArgs e)
        {
            columnHeader2.Width = actionsListView.Width - columnHeader1.Width - 4;
        }

    }
}
