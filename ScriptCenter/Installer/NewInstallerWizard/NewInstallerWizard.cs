﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ScriptCenter.Controls;
using ScriptCenter.Repository;

namespace ScriptCenter.Installer.NewInstallerWizard
{
    public partial class NewInstallerWizard : Wizard
    {
        public NewInstallerWizard()
        {
            InitializeComponent();

            ScriptManifest manifest = new ScriptManifest();
            manifest.Name = "Outliner";
            manifest.Versions.Add(new ScriptVersion(2, 5, 21));

            this.ShowPage(new ManifestEditor(manifest));
        }
    }
}
