//  Copyright 2011 P.J. Janssen
//  This file is part of ScriptCenter.

//  ScriptCenter is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.

//  ScriptCenter is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.

//  You should have received a copy of the GNU General Public License
//  along with ScriptCenter.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.ComponentModel;
using Newtonsoft.Json;

namespace ScriptCenter.Installer.Actions
{
/// <summary>
/// Copies the contents of a directory to the specified target directory, including all files and subdirectories.
/// </summary>
public class CopyDirAction : InstallerAction
{
    public CopyDirAction()
    {
        InstallerHelperMethods.SetDefaultValues(this);
        this.ExcludeFiles = new List<string>() { "._*", "Thumbs.db", ".DS_Store" };
    }
    public CopyDirAction(String source, AppPaths.Directory target) : this()
    {
        this.Source = source;
        this.Target = target;
    }


    /// <summary>
    /// The source directory to copy. Relative to the installer path.
    /// </summary>
    [JsonProperty("source")]
    [DefaultValue("")]
    [Category("1. Action Properties")]
    [DisplayName("Source Directory")]
    [Description("The directory to be included in the package and to copy from.")]
    [Editor(typeof(System.Windows.Forms.Design.FolderNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
    public String Source { get; set; }

    /// <summary>
    /// The target directory to copy to.
    /// </summary>
    [JsonProperty("target")]
    [DefaultValue(AppPaths.Directory.MacroScripts)]
    [Category("1. Action Properties")]
    [DisplayName("Target Directory")]
    [Description("The 3dsmax directory to copy the directory to.")]
    public AppPaths.Directory Target { get; set; }

    /// <summary>
    /// Create a directory with the script id in which to place the source directory.
    /// Default value: true.
    /// </summary>
    [JsonProperty("use_script_id")]
    [DefaultValue(true)]
    [Category("1. Action Properties")]
    [DisplayName("Use Script ID")]
    [Description("When set to true, the script identifier will be included in the output path of the copied directory. This is recommended.")]
    public Boolean UseScriptId { get; set; }


    /// <summary>
    /// A semicolon separated list of files to exclude when packing files.
    /// </summary>
    [JsonProperty("exclude")]
    [Category("1. Action Properties")]
    [DisplayName("Exclude files")]
    [Description("A semicolon separated list of files that will be ignored when creating the package.")]
    [TypeConverter(typeof(StringListConverter))]
    [Editor(@"System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
    public List<String> ExcludeFiles { get; set; }


    /// <summary>
    /// Copies the directory and all subdirectories.
    /// </summary>
    public override bool Do(Installer installer)
    {
        try
        {
            String sourcePath = installer.ResourcesDirectory + this.Source;
            String targetPath = AppPaths.GetApplicationPaths().GetPath(this.Target);
            if (this.UseScriptId)
                targetPath += "/" + installer.Manifest.Id;
            String[] files = Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories);

            foreach (String file in files)
            {
                String targetFile = targetPath + "/" + file.Substring(sourcePath.Length);
                FileInfo fileInfo = new FileInfo(targetFile);
                if (!fileInfo.Directory.Exists)
                {
                    fileInfo.Directory.Create();
                }

                File.Copy(file, targetFile, true);

                if (this.Target == AppPaths.Directory.MacroScripts)
                    ManagedServices.MaxscriptSDK.ExecuteMaxscriptCommand("fileIn " + targetFile);
            }

            installer.Log.Append("Copied directory " + targetPath);
        }
        catch (Exception e)
        {
            installer.InstallerException = e;
            installer.Log.Append(e.Message);
            return false;
        }

        return true;
    }

    /// <summary>
    /// Removes the directory from the target directory.
    /// </summary>
    public override bool Undo(Installer installer)
    {
        try
        {
            String scriptPath = AppPaths.GetApplicationPaths().GetPath(AppPaths.Directory.Scripts);
            //TODO add check for UseScriptId
            String targetPath = scriptPath + "/" + installer.Manifest.Id;

            if (Directory.Exists(targetPath))
            {
                Directory.Delete(targetPath, true);
                installer.Log.Append("Deleted directory " + targetPath);
            }
        }
        catch (Exception e)
        {
            installer.InstallerException = e;
            installer.Log.Append(e.Message);
            return false;
        }

        return true;
    }


    public override string ActionName { get { return "Copy Directory"; } }
    public override string ActionImageKey { get { return "copy_dir"; } }
    public override string ActionDetails
    {
        get
        {
            if (this.Source == String.Empty)
                return "";
            else
                return String.Format("{0} -> ${1}", this.Source, this.Target.ToString());
        }
    }
}
}
