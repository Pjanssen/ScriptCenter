using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ScriptCenter.Repository;

namespace ScriptCenter.Controls
{
    internal partial class SupportedMaxVersionsEditorUI : UserControl
    {
        public SupportedMaxVersionsEditorUI()
        {
            InitializeComponent();
            this.minVersionSpinner.Maximum = DateTime.Today.Year + 1;
            this.maxVersionSpinner.Maximum = DateTime.Today.Year + 1;
        }

        public void Start(SupportedMaxVersions value) 
        {
            if (value.LowerBound != SupportedMaxVersions.NoBound)
            {
                this.minVersionCheckBox.Checked = true;
                this.minVersionSpinner.Value = value.LowerBound;
            }
            else
                this.minVersionCheckBox.Checked = false;

            if (value.UpperBound != SupportedMaxVersions.NoBound)
            {
                this.maxVersionCheckBox.Checked = true;
                this.maxVersionSpinner.Value = value.UpperBound;
            }
            else
                this.maxVersionCheckBox.Checked = false;
        }

        public SupportedMaxVersions Value
        {
            get
            {
                if (!this.minVersionCheckBox.Checked && !this.maxVersionCheckBox.Checked)
                    return SupportedMaxVersions.All;

                Int32 minVersion = (Int32)this.minVersionSpinner.Value;
                Int32 maxVersion = (Int32)this.maxVersionSpinner.Value;

                if (!this.maxVersionCheckBox.Checked)
                    return new SupportedMaxVersions(minVersion, SupportedMaxVersions.NoBound);
                else if (!this.minVersionCheckBox.Checked)
                    return new SupportedMaxVersions(SupportedMaxVersions.NoBound, maxVersion);
                else
                    return new SupportedMaxVersions(minVersion, maxVersion);
            }
        }

        private void minVersionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.minVersionSpinner.Enabled = this.minVersionCheckBox.Checked;
        }

        private void maxVersionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.maxVersionSpinner.Enabled = this.maxVersionCheckBox.Checked;
        }

        private void minVersionSpinner_ValueChanged(object sender, EventArgs e)
        {
            if (this.maxVersionSpinner.Value < this.minVersionSpinner.Value)
                this.maxVersionSpinner.Value = this.minVersionSpinner.Value;
        }

        private void maxVersionSpinner_ValueChanged(object sender, EventArgs e)
        {
            if (this.minVersionSpinner.Value > this.maxVersionSpinner.Value)
                this.minVersionSpinner.Value = this.maxVersionSpinner.Value;
        }
    }
}
