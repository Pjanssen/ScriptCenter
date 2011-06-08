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

namespace ScriptCenter.Package.InstallerUI
{
    public partial class InstallPage : WizardPage
    {
        public InstallPage()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (this.Wizard is InstallerDialog)
            {
                ((InstallerDialog)this.Wizard).Installer.Progress += new InstallerProgressEventHandler(Installer_Progress);
                ((InstallerDialog)this.Wizard).Installer.Completed += new EventHandler(Installer_Completed);
                ((InstallerDialog)this.Wizard).Installer.Failed += new EventHandler(Installer_Failed);
            }
        }

        void Installer_Failed(object sender, EventArgs e)
        {
            this.button1.Enabled = true;
        }

        void Installer_Completed(object sender, EventArgs e)
        {
            this.button1.Enabled = true;
        }

        void Installer_Progress(object sender, InstallerProgressEventArgs args)
        {
            this.progressBar1.Value = args.Progress;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.Wizard != null)
                this.Wizard.Close();
        }
    }
}
