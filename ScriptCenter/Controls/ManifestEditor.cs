using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ScriptCenter.Xml;

namespace ScriptCenter.Controls
{
    public partial class ManifestEditor : WizardPage
    {
        private ScriptManifest manifest;

        public ManifestEditor(ScriptManifest manifest)
        {
            InitializeComponent();

            this.manifest = manifest;
            this.scriptManifestBindingSource.DataSource = manifest;
            //TODO fix script version binding.
            //this.scriptVersionBindingSource.DataSource = manifest.Version;
            this.scriptInfoBindingSource.DataSource = manifest.Info;
        }
    }
}
