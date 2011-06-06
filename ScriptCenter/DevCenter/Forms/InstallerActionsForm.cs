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
using ScriptCenter.Repository;
using ScriptCenter.Controls;

namespace ScriptCenter.DevCenter.Forms
{
    public partial class InstallerActionsForm : UserControl
    {
        private ScriptPackage package;
        private InstallerConfiguration installerConfig;

        public InstallerActionsForm(DevCenter devCenter, ScriptPackage package)
        {
            InitializeComponent();

            if (package == null)
                throw new ArgumentNullException("Package argument cannot be null");

            this.package = package;
            this.installerConfig = package.InstallerConfiguration;

            actionsComboBox.Format += new ListControlConvertEventHandler(actionsComboBox_Format);
            actionPropertyGrid.PropertyValueChanged += new PropertyValueChangedEventHandler(actionPropertyGrid_PropertyValueChanged);

            if (package.RootPath == String.Empty)
            {
                PackageRootPathWarning w = new PackageRootPathWarning();
                w.Dock = DockStyle.Fill;
                this.Controls.Remove(this.tableLayoutPanel);
                this.Controls.Add(w);
            }
            else
            {
                fillActionsCombobox();
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
            Type actionBaseType = typeof(InstallerAction);
            Assembly assembly = Assembly.GetAssembly(actionBaseType);
            List<Type> types = assembly.GetTypes().Where(type => type.IsSubclassOf(actionBaseType)).ToList();

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


        private void moveSelectedAction(InstallerConfiguration.MoveActionDirection direction)
        {
            if (actionsListView.SelectedItems.Count == 0)
                return;

            ListViewItem selItem = actionsListView.SelectedItems[0];
            Int32 oldIndex = selItem.Index;
            Int32 newIndex = this.installerConfig.MoveAction((InstallerAction)selItem.Tag, direction);
            if (oldIndex != newIndex)
            {
                actionsListView.Items.Remove(selItem);
                actionsListView.Items.Insert(newIndex, selItem);
            }
        }
        private void moveActionUpButton_Click(object sender, EventArgs e)
        {
            moveSelectedAction(InstallerConfiguration.MoveActionDirection.Up);
        }

        private void moveActionDownButton_Click(object sender, EventArgs e)
        {
            moveSelectedAction(InstallerConfiguration.MoveActionDirection.Down);
        }

        private void actionsListView_SizeChanged(object sender, EventArgs e)
        {
            columnHeader2.Width = actionsListView.Width - columnHeader1.Width - 4;
        }

    }
}
