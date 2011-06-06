using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.Windows.Forms;
using System.ComponentModel;
using ScriptCenter.Installer.Actions;
using ScriptCenter.Utils;

namespace ScriptCenter.Controls
{
    public class CopyFileActionSourceEditor : UITypeEditor
    {
        private OpenFileDialog openFileDialog;
        protected virtual void InitializeDialog()
        {
            this.openFileDialog = new OpenFileDialog();
            this.openFileDialog.Filter = "Maxscript Files (*.ms; *.mcr)|*.ms|All Files (*.*)|*.*";
            this.openFileDialog.Title = "Select the file to copy";
        }

        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (context == null || context.Instance == null || !(context.Instance is InstallerAction))
                return value;

            InstallerAction action = (InstallerAction)context.Instance;

            if (this.openFileDialog == null)
            {
                this.InitializeDialog();
            }

            if (value is String)
            {
                if (action.Configuration != null && action.Configuration.Package != null)
                {
                    String path = PathHelperMethods.GetAbsolutePath((string)value, action.Configuration.Package.SourcePathAbsolute);
                    path = path.Replace('/', '\\');
                    if (PathHelperMethods.IsFilePath(path))
                    {
                        this.openFileDialog.FileName = path;
                    }
                    else
                    {
                        this.openFileDialog.FileName = "";
                        this.openFileDialog.InitialDirectory = path;
                    }
                }
                else
                    this.openFileDialog.FileName = (string)value;
            }

            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (action.Configuration != null && action.Configuration.Package != null)
                    value = PathHelperMethods.GetRelativePath(this.openFileDialog.FileName, action.Configuration.Package.SourcePathAbsolute);
                else
                    value = (new System.IO.FileInfo(this.openFileDialog.FileName)).Name;
            }
            
            return value;

        }
    }
}
