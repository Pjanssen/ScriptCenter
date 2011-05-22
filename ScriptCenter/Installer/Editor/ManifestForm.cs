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

            comboBox1.Items.Add(-1);
            comboBox2.Items.Add(-1);
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            for (int i = 2008; i < DateTime.Now.Year + 2; i++)
            {
                comboBox1.Items.Add(i);
                comboBox2.Items.Add(i);
            }
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
                    //TODO fix script version binding.
                    //this.scriptVersionBindingSource.DataSource = manifest.Versions[0];
                    //this.scriptRequirementsBindingSource.DataSource = manifest.Versions[0].Requirements;
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

        private void comboBox1_Format(object sender, ListControlConvertEventArgs e)
        {
            if ((Int32)e.ListItem == -1)
                e.Value = "-";
            else
                e.Value = e.ListItem.ToString();
        }
    }
}
