using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.Windows.Forms;
using System.ComponentModel;
using ScriptCenter.Package.InstallerActions;
using ScriptCenter.Utils;
using ScriptCenter.Repository;
using ScriptCenter.Package;

namespace ScriptCenter.Controls
{
    public class CopyFileActionSourceEditor : UITypeEditor
    {
        private OpenFileDialog openFileDialog;
        protected virtual void InitializeDialog()
        {
            this.openFileDialog = new OpenFileDialog();
            this.openFileDialog.Filter = "Maxscript Files (*.ms; *.mcr; *.mse)|*.ms;*.mcr;*.mse|All Files (*.*)|*.*";
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
            ScriptPackage package = action.Configuration.Package;
            ScriptManifest manifest = package.Manifest;

            if (this.openFileDialog == null)
            {
                this.InitializeDialog();
            }

            if (value is String)
            {
                if (action.Configuration != null && action.Configuration.Package != null)
                {
                    RelativePath path = new RelativePath((string)value, package.SourcePath);
                    String pathStr = ScriptManifestTokens.Replace(path.AbsolutePath, manifest, manifest.LatestVersion);
                    if (path.IsFilePath)
                    {
                        this.openFileDialog.FileName = pathStr.Replace('/', '\\');
                    }
                    else
                    {
                        this.openFileDialog.FileName = "";
                        this.openFileDialog.InitialDirectory = pathStr.Replace('/', '\\');
                    }
                }
                else
                    this.openFileDialog.FileName = (string)value;
            }

            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (action.Configuration != null && action.Configuration.Package != null)
                {
                    String sourcePath = ScriptManifestTokens.Replace(package.SourcePath.AbsolutePath, manifest, manifest.LatestVersion);
                    value = PathHelperMethods.GetRelativePath(this.openFileDialog.FileName, sourcePath);
                }
                else
                    value = (new System.IO.FileInfo(this.openFileDialog.FileName)).Name;
            }
            
            return value;

        }
    }
}
