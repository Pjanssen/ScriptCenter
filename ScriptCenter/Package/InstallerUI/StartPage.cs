using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ScriptCenter.Controls;
using ScriptCenter.Repository;
using ScriptCenter.Utils;

namespace ScriptCenter.Package.InstallerUI
{
    public partial class StartPage : WizardPage
    {
        public StartPage()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (this.Wizard is InstallerDialog)
            {
                ScriptManifest manifest = ((InstallerDialog)this.Wizard).Installer.Manifest;
                InstallerUIConfiguration uiConfig = ((InstallerDialog)this.Wizard).UIConfig;

                this.titleTxt.Text = ScriptManifestTokens.Replace(uiConfig.Title, manifest, manifest.LatestVersion);
                this.mainTxt.Text = ScriptManifestTokens.Replace(uiConfig.StartPageText, manifest, manifest.LatestVersion);

            }
        }

        private void installBtn_Click(object sender, EventArgs e)
        {
            if (this.Wizard != null)
            {
                this.Wizard.ShowPage(new InstallPage());
                ((InstallerDialog)this.Wizard).Installer.Uninstall();
                ((InstallerDialog)this.Wizard).Installer.Install();
            }
        }

        private void uninstallBtn_Click(object sender, EventArgs e)
        {
            if (this.Wizard != null)
            {
                this.Wizard.ShowPage(new UninstallPage());
                ((InstallerDialog)this.Wizard).Installer.Uninstall();
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            if (this.Wizard != null)
                this.Wizard.Close();
        }
    }
}
