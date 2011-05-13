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

namespace ScriptCenter.Installer.UI
{
    public partial class InstallerDialog : Wizard
    {
        public Installer Installer { get; private set; }

        public InstallerDialog()
        {
            InitializeComponent();
        }

        new public void Show() { throw new InvalidOperationException("Use Show(Installer) instead."); }
        new public void Show(IWin32Window owner) { throw new InvalidOperationException("Use Show(Installer) instead."); }
        new public void ShowDialog() { throw new InvalidOperationException("Use ShowDialog(Installer) instead."); }
        new public void ShowDialog(IWin32Window owner) { throw new InvalidOperationException("Use ShowDialog(Installer) instead."); }

        public void Show(Installer installer)
        {
            this.Installer = installer;

            StartPage startPage = new StartPage();
            this.ShowPage(startPage);

            base.Show();
        }

        public void ShowDialog(Installer installer)
        {
            this.Installer = installer;

            StartPage startPage = new StartPage();
            this.ShowPage(startPage);

            base.ShowDialog();
        }
    }
}
