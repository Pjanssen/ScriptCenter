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
using Ionic.Zip;
using System.IO;
using ScriptCenter.Repository;
using ScriptCenter.Installer.UI;
using System.Text.RegularExpressions;
using ScriptCenter.Installer.Actions;

namespace ScriptCenter.Installer
{
    public class InstallerCreator
    {
        /// <summary>
        /// Packs a directory into a .mzp installer.
        /// </summary>
        /// <param name="dir">The directory with files to pack.</param>
        /// <param name="output">The location to write the .mzp file.</param>
        /// <param name="manifest">The manifest to include.</param>
        /// <param name="config">The installer configuration to include.</param>
        
        //TODO: refactor
        /*
        public static void Pack(legacy_ScriptProjectData projectData)
        {
            if (Validate(projectData) != ValidationResult.Valid)
                throw new Exception("Invalid project data");

            //Create temp directory.
            String tempPath = Path.GetTempPath() + "ScriptCenter\\";
            if (!Directory.Exists(tempPath))
                Directory.CreateDirectory(tempPath);


            //Copy files for actions to temp directory.
            foreach (InstallerAction action in projectData.InstallerConfig.InstallerActions)
            {
                if (action is CopyFileAction)
                {
                    String sourcePath = GetAbsolutePath(((CopyFileAction)action).Source, projectData.RootPath);
                    String targetPath = GetAbsolutePath(((CopyFileAction)action).Source, tempPath + "resources\\");
                    if (!Directory.Exists(Path.GetDirectoryName(targetPath)))
                        Directory.CreateDirectory(Path.GetDirectoryName(targetPath));
                    File.Copy(sourcePath, targetPath, true);
                }
                else if (action is CopyDirAction)
                {
                    String[] excludedFiles = Regex.Replace(((CopyDirAction)action).ExcludeFiles, @"[ ]", "").Split(';');
                    for (int i = 0; i < excludedFiles.Length; i++)
                    {
                        excludedFiles[i] = Regex.Escape(excludedFiles[i]);
                        excludedFiles[i] = Regex.Replace(excludedFiles[i], @"\\\*", ".*"); //Replace any asterisk with Regex equivalent.
                    }

                    String sourcePath = GetAbsolutePath(((CopyDirAction)action).Source, projectData.RootPath);
                    String[] files = Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories);
                    foreach (String file in files)
                    {
                        Boolean skip = false;
                        foreach (String excludedFile in excludedFiles)
                        {
                            if (excludedFile != String.Empty && Regex.IsMatch(file, excludedFile))
                            {
                                skip = true;
                                break;
                            }
                        }
                        if (skip)
                            continue;

                        String targetFile = tempPath + "resources\\" + file.Substring(projectData.RootPath.Length);
                        FileInfo fileInfo = new FileInfo(targetFile);
                        if (!fileInfo.Directory.Exists)
                        {
                            fileInfo.Directory.Create();
                        }

                        File.Copy(file, targetFile, true);
                    }
                }
            }


            //Write manifest, installer configuration and ui configuration.
            JsonFileHandler<ScriptManifest> manifestHandler = new JsonFileHandler<ScriptManifest>();
            manifestHandler.Write(tempPath + "script.scmanifest", projectData.Manifest);
            JsonFileHandler<InstallerConfiguration> configHandler = new JsonFileHandler<InstallerConfiguration>();
            configHandler.Write(tempPath + "/script.scinstaller", projectData.InstallerConfig);
            JsonFileHandler<InstallerUIConfiguration> uiConfigHandler = new JsonFileHandler<InstallerUIConfiguration>();
            uiConfigHandler.Write(tempPath + "script.scinstallerui", projectData.UIConfig);

            //Write mzp.run and install.ms
            String str = InstallerHelperMethods.ReplaceTokens(InstallerResources.mzp, projectData.Manifest);
            StreamWriter wr = new StreamWriter(tempPath + "/mzp.run");
            wr.Write(str);
            wr.Close();
            str = InstallerHelperMethods.ReplaceTokens(InstallerResources.install, projectData.Manifest);
            wr = new StreamWriter(tempPath + "/install.ms");
            wr.Write(str);
            wr.Close();

            String output = InstallerHelperMethods.ReplaceTokens(projectData.ExportTarget, projectData.Manifest);
            String outputFileName = Path.GetFileNameWithoutExtension(output);
            String outputPath = GetAbsolutePath(Path.GetDirectoryName(output), projectData.RootPath);

            if (!Directory.Exists(outputPath))
                Directory.CreateDirectory(outputPath);

            ZipFile zip = new ZipFile();
            zip.AddDirectory(tempPath);
            String scAssemblyPath = System.Reflection.Assembly.GetCallingAssembly().Location;
            zip.AddFile(scAssemblyPath, "");
            zip.AddFile(Path.GetDirectoryName(scAssemblyPath) + "\\Newtonsoft.Json.Net35.dll", "");
            zip.Save(GetAbsolutePath(output, projectData.RootPath));

            //Remove temp dir
            Directory.Delete(tempPath, true);
        }
        */
        public static void UnPack(String file, String targetDir)
        {
            ZipFile zip = new ZipFile(file);
            zip.ExtractAll(targetDir, ExtractExistingFileAction.OverwriteSilently);
        }


        

        //Matches all characters that are non-alphanumeric and not a dash or space.
        private const String special_characters_filter = @"[^\w\- ]";
        
        //TODO: find solution for validate
        /*
        public static ValidationResult Validate(legacy_ScriptProjectData projectData)
        {
            ValidationResult result = ValidationResult.Valid;

            if (projectData == null || projectData.Manifest == null)
                return ValidationResult.Invalid;

            //Check whether rootpath is set and exists.
            if (projectData.RootPath == null || projectData.RootPath == String.Empty)
                result |= ValidationResult.RootPathEmpty;
            else if (!Directory.Exists(projectData.RootPath))
                result |= ValidationResult.RootPathNonExisting;

            //Check whether export target is set and valid.
            if (projectData.ExportTarget == null || projectData.ExportTarget == String.Empty)
                result |= ValidationResult.ExportTargetEmpty;
            else if (Regex.IsMatch(projectData.ExportTarget, @"[^\w\.\{\}\(\)\-\/\\]")) //Matches anything that is not alphanumeric, ., \, /, {. }, (, ), or -
                result |= ValidationResult.ExportTargetInvalid;

            //Check manifest name.
            if (projectData.Manifest.Name == null || projectData.Manifest.Name == String.Empty)
                result |= ValidationResult.ScriptNameEmpty;
            else if (Regex.IsMatch(projectData.Manifest.Name, special_characters_filter))
                result |= ValidationResult.ScriptNameInvalid;

            //Check manifest author.
            if (projectData.Manifest.Author == null || projectData.Manifest.Author == String.Empty)
                result |= ValidationResult.ScriptAuthorEmpty;
            else if (Regex.IsMatch(projectData.Manifest.Author, special_characters_filter))
                result |= ValidationResult.ScriptAuthorInvalid;

            //Check manifest id.
            if (projectData.Manifest.Id == null || projectData.Manifest.Id == String.Empty)
                result |= ValidationResult.ScriptIdEmpty;
            else if (Regex.IsMatch(projectData.Manifest.Id, @"[^\w\.]"))
                result |= ValidationResult.ScriptIdInvalid;

            if (result != ValidationResult.Valid)
                result |= ValidationResult.Invalid;

            return result;
        }
        */

        public static string GetRelativePath(string absolutePath, string relativeTo)
        {
            Uri fileUri = new Uri(absolutePath);
            Uri rootUri = new Uri(relativeTo);
            return Uri.UnescapeDataString(rootUri.MakeRelativeUri(fileUri).ToString());
        }

        public static string GetAbsolutePath(String relativePath, String relativeTo)
        {
            Uri absoluteUri = new Uri(relativeTo + relativePath);
            return Uri.UnescapeDataString(absoluteUri.AbsolutePath);
        }
    }

    [Flags]
    public enum ValidationResult : int
    {
        Valid               = 0,
        Invalid             = 0x0001,
        RootPathEmpty       = 0x0002,
        RootPathNonExisting = 0x0004,
        ExportTargetEmpty   = 0x0008,
        ExportTargetInvalid = 0x0010,
        ScriptNameEmpty     = 0x0020,
        ScriptNameInvalid   = 0x0040,
        ScriptAuthorEmpty   = 0x0080,
        ScriptAuthorInvalid = 0x0100,
        ScriptIdEmpty       = 0x0200,
        ScriptIdInvalid     = 0x0400
    }
}
