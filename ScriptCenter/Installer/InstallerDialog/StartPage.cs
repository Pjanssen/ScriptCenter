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

namespace ScriptCenter.Installer
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
                InstallerConfiguration config = ((InstallerDialog)this.Wizard).Installer.Configuration;

                this.titleTxt.Text = InstallerHelperMethods.ReplaceTokens(config.StartPageUI.Title, manifest);
                this.mainTxt.Text = InstallerHelperMethods.ReplaceTokens(config.StartPageUI.Text, manifest);
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
