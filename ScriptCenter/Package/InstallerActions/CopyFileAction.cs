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
using System.ComponentModel;
using System.IO;
using Newtonsoft.Json;
using ScriptCenter.Utils;

namespace ScriptCenter.Package.InstallerActions
{
/// <summary>
/// Copies a single file to the specified target directory.
/// </summary>
public class CopyFileAction : InstallerAction
{
    public CopyFileAction() : this("", AppPaths.Directory.MacroScripts) { }
    public CopyFileAction(String source, AppPaths.Directory target)
    {
        //TODO: test if omission of SetDefaultValues here has indeed got no consequences (since its called in the baseclass).
        this.Source = source;
        this.Target = target;
    }


    /// <summary>
    /// The source directory to copy. Relative to the installer path.
    /// </summary>
    [JsonProperty("source")]
    [DefaultValue("")]
    [Category("1. Action Properties")]
    [DisplayName("Source File")]
    [Description("The file to be included in the package and to copy from.")]
    [Editor(typeof(ScriptCenter.Controls.CopyFileActionSourceEditor), typeof(System.Drawing.Design.UITypeEditor))]
    public String Source { get; set; }

    /// <summary>
    /// The target directory to copy to.
    /// </summary>
    [JsonProperty("target")]
    [DefaultValue(AppPaths.Directory.MacroScripts)]
    [Category("1. Action Properties")]
    [DisplayName("Target Directory")]
    [Description("The 3dsmax directory to copy the file to.")]
    public AppPaths.Directory Target { get; set; }

    /// <summary>
    /// Create a directory with the script id in which to place the source directory.
    /// Default value: true.
    /// </summary>
    [JsonProperty("use_script_id")]
    [Category("1. Action Properties")]
    [DefaultValue(true)]
    [Description("When set to true, the script identifier will be included in the output path of the copied file. This is recommended.")]
    public Boolean UseScriptId { get; set; }


    /// <summary>
    /// Copies the source file to the target directory.
    /// </summary>
    public override bool Do(Installer installer)
    {
        String sourceFile = installer.ResourcesDirectory + this.Source;
        String targetFile = AppPaths.GetApplicationPaths().GetPath(this.Target).AbsolutePath;
        if (this.UseScriptId)
            targetFile += "/" + installer.Manifest.Id;

        FileInfo sourceFileInfo = new FileInfo(sourceFile);
        targetFile += "/" + sourceFileInfo.Name;
        FileInfo targetFileInfo = new FileInfo(targetFile);
        if (!targetFileInfo.Directory.Exists)
        {
            targetFileInfo.Directory.Create();
            InstallerLog.WriteLine("Created directory " + targetFileInfo.DirectoryName);
        }

        File.Copy(sourceFile, targetFile, true);

        if (this.Target == AppPaths.Directory.MacroScripts)
            ManagedServices.MaxscriptSDK.ExecuteMaxscriptCommand("fileIn " + targetFile);

        InstallerLog.WriteLine("Copied file " + targetFile);

        return true;
    }

    /// <summary>
    /// Removes the file from the target directory.
    /// </summary>
    public override bool Undo(Installer installer)
    {
        //TODO: implement
        throw new NotImplementedException();
    }

    public override void PackResources(Ionic.Zip.ZipFile zip, String archiveTargetPath, IPath sourcePath) 
    {
        RelativePath path = new RelativePath(this.Source, sourcePath);
        zip.AddFile(path.AbsolutePath, archiveTargetPath);
    }

    public override string ActionName { get { return "Copy File"; } }
    public override string ActionImageKey { get { return "copy_file"; } }
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
