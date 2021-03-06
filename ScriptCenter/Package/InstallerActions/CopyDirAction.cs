﻿//  Copyright 2011 P.J. Janssen
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
using ScriptCenter.Utils;

namespace ScriptCenter.Package.InstallerActions
{
/// <summary>
/// Copies the contents of a directory to the specified target directory, including all files and subdirectories.
/// </summary>
public class CopyDirAction : InstallerAction
{
    public CopyDirAction() : this("", AppPaths.Directory.Scripts) { }
    public CopyDirAction(String source, AppPaths.Directory target) 
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
    [Editor(typeof(ScriptCenter.Controls.CopyDirActionSourceEditor), typeof(System.Drawing.Design.UITypeEditor))]
    public String Source { get; set; }

    /// <summary>
    /// The target directory to copy to.
    /// </summary>
    [JsonProperty("target")]
    [DefaultValue(AppPaths.Directory.Scripts)]
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
    [JsonProperty("exclude_files")]
    [DefaultValue("._*; Thumbs.db; .DS_Store; .svn;")]
    [Category("1. Action Properties")]
    [DisplayName("Exclude files")]
    [Description("A semicolon separated list of files that will be ignored when creating the package.")]
    public String ExcludeFiles { get; set; }


    /// <summary>
    /// Copies the directory and all subdirectories.
    /// </summary>
    public override bool Do(Installer installer)
    {
        String sourcePath = installer.ResourcesDirectory + this.Source;
        String targetPath = AppPaths.GetApplicationPaths().GetPath(this.Target).AbsolutePath;
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

        InstallerLog.WriteLine("Copied directory " + targetPath);

        return true;
    }

    /// <summary>
    /// Removes the directory from the target directory.
    /// </summary>
    public override bool Undo(Installer installer)
    {
        String scriptPath = AppPaths.GetApplicationPaths().GetPath(AppPaths.Directory.Scripts).AbsolutePath;
        //TODO add check for UseScriptId
        String targetPath = scriptPath + "/" + installer.Manifest.Id;

        if (Directory.Exists(targetPath))
        {
            Directory.Delete(targetPath, true);
            InstallerLog.WriteLine("Deleted directory " + targetPath);
        }

        return true;
    }

    public override void PackResources(Ionic.Zip.ZipFile zip, String archiveTargetPath, IPath sourcePath)
    {
        //Create selection criteria string from ExcludeFiles property.
        StringBuilder selectionCriteria = new StringBuilder();
        String[] splitExcludeFiles = this.ExcludeFiles.Replace(" ", "").Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (String exludeFile in splitExcludeFiles)
        {
            if (selectionCriteria.Length > 0)
                selectionCriteria.Append(" AND ");
            selectionCriteria.Append("name != '");
            selectionCriteria.Append(exludeFile);
            selectionCriteria.Append("'");
        }

        //Create source path and archive path.
        RelativePath path = new RelativePath(this.Source, sourcePath);
        if (!archiveTargetPath.EndsWith("\\"))
            archiveTargetPath += "\\";
        archiveTargetPath += path.PathComponents[path.PathComponents.Count - 1];

        //Add files to zip.
        zip.AddSelectedFiles(selectionCriteria.ToString(), path.AbsolutePath.Replace('/', '\\'), archiveTargetPath, true);
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
