using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ScriptCenter.Repository;

namespace ScriptCenter.DevCenter.Forms
{
    public partial class ManifestMetadataForm : UserControl
    {
        public ManifestMetadataForm(DevCenter devCenter, ScriptManifest manifest)
        {
            InitializeComponent();
        }
    }
}
