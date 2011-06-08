using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ScriptCenter.Controls;
using ScriptCenter.Repository;

namespace ScriptCenter.Package.InstallerUI
{
    public partial class InstallerDialog : Wizard
    {
        public Installer Installer { get; set; }
        public InstallerUIConfiguration UIConfig { get; set; }

        public InstallerDialog(Installer installer, InstallerUIConfiguration uiConfig)
        {
            InitializeComponent();

            this.Installer = installer;
            this.UIConfig = uiConfig;
        }

        private void setStartPage()
        {
            StartPage startPage = new StartPage();
            this.ShowPage(startPage);
        }

        new public void Show() 
        {
            this.setStartPage();
            base.Show();
        }
        new public void Show(IWin32Window owner) 
        {
            this.setStartPage();
            base.Show(owner);
        }
        new public void ShowDialog() 
        {
            this.setStartPage();
            base.ShowDialog();
        }
        new public void ShowDialog(IWin32Window owner) 
        {
            this.setStartPage();
            base.ShowDialog(owner);
        }
    }
}
