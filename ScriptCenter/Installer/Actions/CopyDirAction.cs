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

namespace ScriptCenter.Installer.Actions
{
/// <summary>
/// Copies an entire directory, including all files and subdirectories.
/// </summary>
public class CopyDirAction : InstallerAction
{
    /// <summary>
    /// The source directory to copy. Relative to the installer path.
    /// </summary>
    [JsonProperty("source")]
    [XmlAttribute("source")]
    public String Source { get; set; }

    /// <summary>
    /// The target directory to copy to.
    /// </summary>
    [JsonProperty("target")]
    [XmlAttribute("target")]
    public AppPaths.Directory Target { get; set; }

    /// <summary>
    /// Create a directory with the script id in which to place the source directory.
    /// Default value: true.
    /// </summary>
    [XmlAttribute("use_script_id")]
    [DefaultValue(true)]
    public Boolean UseScriptId { get; set; }

    public CopyDirAction() 
    {
        InstallerHelperMethods.SetDefaultValues(this);
    }
    public CopyDirAction(String source, AppPaths.Directory target) : this()
    {
        this.Source = source;
        this.Target = target;
    }


    public override bool Do(Installer installer)
    {
        try
        {
            String sourcePath = installer.InstallerDirectory + "/" + this.Source;
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

    public override bool Undo(Installer installer)
    {
        try
        {
            String scriptPath = AppPaths.GetApplicationPaths().GetPath(AppPaths.Directory.Scripts);
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
}
}
