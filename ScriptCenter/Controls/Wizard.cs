using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScriptCenter.Controls
{
    public class Wizard : Form
    {
        private WizardPage currentPage;

        public void ShowPage(WizardPage c)
        {
            if (this.currentPage != null)
                this.Controls.Remove(this.currentPage);

            c.Dock = DockStyle.Fill;
            c.Wizard = this;

            this.Controls.Add(c);
            this.currentPage = c;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            foreach (Control c in this.Controls)
            {
                if (c is WizardPage)
                {
                    this.currentPage = (WizardPage)c;
                    ((WizardPage)c).Wizard = this;
                    break;
                }
            }
        }
    }

    public class WizardPage : UserControl
    {
        public Wizard Wizard { get; set; }
    }
}
