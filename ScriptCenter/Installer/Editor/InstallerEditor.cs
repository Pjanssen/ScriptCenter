using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScriptCenter.Installer.Editor
{
    public partial class InstallerEditor : Form
    {
        private List<KeyValuePair<String, Type>> sections;

        public InstallerEditor()
        {
            InitializeComponent();
            this.sections = new List<KeyValuePair<string, Type>>();
            this.sections.Add(new KeyValuePair<String, Type>("Manifest", typeof(ManifestEditor)));
            this.sections.Add(new KeyValuePair<String, Type>("Installer Actions", typeof(InstallerActionsForm)));
            this.sections.Add(new KeyValuePair<String, Type>("Installer UI", typeof(ManifestEditor)));

            foreach (KeyValuePair<String, Type> i in this.sections)
            {
                listBox1.Items.Add(i.Key);
            }
            listBox1.SelectedIndex = 0;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyValuePair<String, Type> item = this.sections[listBox1.SelectedIndex];
            sectionTitle.Text = item.Key;
            sectionPanel.Controls.Clear();
            Control c = (Control)Activator.CreateInstance(item.Value);
            sectionPanel.Controls.Add(c);
            c.Dock = DockStyle.Fill;
        }
    }
}
