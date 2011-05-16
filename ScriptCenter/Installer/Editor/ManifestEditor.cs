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
    public partial class ManifestEditor : WizardPage
    {
        private ScriptManifest manifest;

        public ManifestEditor()
        {
            InitializeComponent();
        }

        public ScriptManifest Manifest
        {
            set
            {
                this.manifest = value;
                this.scriptManifestBindingSource.DataSource = manifest;
                //TODO fix script version binding.
                this.scriptVersionBindingSource.DataSource = manifest.Versions[0];
                this.scriptInfoBindingSource.DataSource = manifest.Info;
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
    }
}
