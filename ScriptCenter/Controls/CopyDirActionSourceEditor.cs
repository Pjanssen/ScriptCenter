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
    public class CopyDirActionSourceEditor : UITypeEditor
    {
        private FolderBrowserDialog folderBrowserDialog;
        protected virtual void InitializeDialog()
        {
            this.folderBrowserDialog = new FolderBrowserDialog();
            this.folderBrowserDialog.Description = "Select directory to copy";
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

            if (this.folderBrowserDialog == null)
            {
                this.InitializeDialog();
            }

            if (value is String)
            {
                if (action.Configuration != null && action.Configuration.Package != null)
                {
                    RelativePath path = new RelativePath((string)value, action.Configuration.Package.SourcePath);
                    this.folderBrowserDialog.SelectedPath = path.Path.Replace('/', '\\');
                }
                else
                    this.folderBrowserDialog.SelectedPath = (string)value;
            }

            if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                if (action.Configuration != null && action.Configuration.Package != null)
                    value = PathHelperMethods.GetRelativePath(this.folderBrowserDialog.SelectedPath + "\\", action.Configuration.Package.SourcePath.Path);
                else
                    value = (new System.IO.DirectoryInfo(this.folderBrowserDialog.SelectedPath)).Name;
            }
            
            return value;

        }
    }
}
