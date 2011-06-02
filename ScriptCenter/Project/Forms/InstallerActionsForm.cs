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
using ScriptCenter.Installer;

namespace ScriptCenter.Project.Forms
{
    public partial class InstallerActionsForm : UserControl
    {
        private InstallerConfiguration installerConfig;

        public InstallerActionsForm(InstallerConfiguration installerConfig)
        {
            InitializeComponent();

            if (installerConfig == null)
                throw new ArgumentNullException("InstallerConfig argument cannot be null");

            this.installerConfig = installerConfig;

            actionsComboBox.Format += new ListControlConvertEventHandler(actionsComboBox_Format);
            actionPropertyGrid.PropertyValueChanged += new PropertyValueChangedEventHandler(actionPropertyGrid_PropertyValueChanged);

            fillActionsCombobox();
            fillActionsListView();
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
            foreach (InstallerAction action in this.installerConfig.Actions)
            {
                addActionToListView(action);
            }

            this.actionsListView.EndUpdate();
        }

        private void addActionButton_Click(object sender, EventArgs e)
        {
            ActionComboBoxItem item = (ActionComboBoxItem)actionsComboBox.SelectedItem;
            InstallerAction action = (InstallerAction)Activator.CreateInstance(item.ActionType);
            this.installerConfig.AddAction(action);

            ListViewItem lvItem = addActionToListView(action);
            lvItem.Selected = true;
        }


        private void removeActionButton_Click(object sender, EventArgs e)
        {
            if (actionsListView.SelectedItems.Count == 0)
                return;

            InstallerAction action = (InstallerAction)actionsListView.SelectedItems[0].Tag;
            this.installerConfig.RemoveAction(action);

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
            InstallerConfiguration.MoveActionDirection moveDirection = (direction == -1) ? InstallerConfiguration.MoveActionDirection.Down : InstallerConfiguration.MoveActionDirection.Up;
            if ((actionPos + direction) >= 0 && (actionPos + direction) < this.installerConfig.Actions.Count)
            {
                this.installerConfig.MoveAction(action, moveDirection);
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
