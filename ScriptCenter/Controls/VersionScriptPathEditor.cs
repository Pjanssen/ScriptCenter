using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.Design;
using System.Drawing.Design;
using System.Windows.Forms;
using System.ComponentModel;

namespace ScriptCenter.Controls
{
    public class VersionScriptPathEditor : UITypeEditor
    {
        private OpenFileDialog openFileDialog;
        protected virtual void InitializeDialog()
        {
            this.openFileDialog = new OpenFileDialog();
            this.openFileDialog.Filter = "Macroscripts and Packages (*.mcr; *.mzp)|*.mcr;*.mzp";
            this.openFileDialog.Title = "Select a macroscript or maxscript package";
        }

        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (provider != null)
            {
                if (this.openFileDialog == null)
                {
                    this.InitializeDialog();
                }
                if (value is string)
                {
                    this.openFileDialog.FileName = (string)value;
                }
                if (this.openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    value = (new System.IO.FileInfo(this.openFileDialog.FileName)).Name;
                }
            }
            return value;

        }
    }
}
