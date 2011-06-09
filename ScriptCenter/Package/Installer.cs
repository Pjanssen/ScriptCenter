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
using ScriptCenter.Repository;
using ScriptCenter.Package.InstallerActions;
using ScriptCenter.Utils;
using System.IO;

namespace ScriptCenter.Package
{
    public class Installer
    {
        public String InstallerDirectory { get; private set; }
        public String ResourcesDirectory { get; private set; }

        private Exception installerException;
        public Exception InstallerException 
        {
            get { return this.installerException; }
            internal set
            {
                this.installerException = value;
                if (installerException != null)
                    InstallerLog.WriteLine(this.installerException.Message);
            }
        }

        public ScriptManifest Manifest { get; private set; }
        public InstallerConfiguration Configuration { get; private set; }

        private FileStream logStream;
        private StreamWriter logStreamWriter;

        public Installer(String installerDirectory, ScriptManifest manifest, InstallerConfiguration config)
        {
            this.InstallerDirectory = installerDirectory;
            this.Manifest = manifest;
            this.Configuration = config;
        }
        public Installer(String installerDirectory, String manifestFile, String configFile)
        {
            this.InstallerDirectory = installerDirectory;
            this.ResourcesDirectory = this.InstallerDirectory + "\\resources\\";

            JsonFileHandler<ScriptManifest> manifestHandler = new JsonFileHandler<ScriptManifest>();
            this.Manifest = manifestHandler.Read(manifestFile);
            JsonFileHandler<InstallerConfiguration> configHandler = new JsonFileHandler<InstallerConfiguration>();
            this.Configuration = configHandler.Read(configFile);
        }

        private void addLogStream()
        {
            //TODO: set correct log path
            this.logStream = new FileStream("C:/temp/scriptcenter/installer.log", FileMode.OpenOrCreate);
            this.logStreamWriter = new StreamWriter(this.logStream);
            InstallerLog.AddWriter(this.logStreamWriter, InstallerLog.TimeStampedLineFormat);
        }

        private void removeLogStream()
        {
            InstallerLog.RemoveWriter(this.logStreamWriter);
            this.logStreamWriter.Dispose();
        }

        /// <summary>
        /// Installs the script.
        /// </summary>
        /// <returns>True if install was successful.</returns>
        public Boolean Install() 
        {
            Boolean success = true;

            this.addLogStream();

            InstallerLog.WriteLine("Installing " + this.Manifest.Id);
            InstallerLog.WriteLine("---------------------");

            Int32 i = 0;
            float numActions = (float)this.Configuration.Actions.Count; //type is float to avoid having to cast it each time when calculating progress.
            foreach (InstallerAction action in this.Configuration.Actions)
            {
                if (!action.RunAtInstall)
                    continue;

                //TODO: Check if this might have to be done on a separate thread to allow UI updates.
                if (!(success = action.Do(this)))
                    break;

                i++;
                this.OnProgress(new InstallerProgressEventArgs((int)(i / numActions) * 100));
            }

            InstallerLog.WriteLine("---------------------");
            if (success)
            {
                InstallerLog.WriteLine("Installation successful");
                this.OnCompleted(new EventArgs());
            }
            else
            {
                InstallerLog.WriteLine("Installation failed");
                this.OnFailed(new EventArgs());
            }
            InstallerLog.WriteLine("");
            this.removeLogStream();

            return success;
        }
        

        /// <summary>
        /// Uninstalls the script.
        /// </summary>
        /// <returns>True if uninstall was successful.</returns>
        public Boolean Uninstall() 
        {
            Boolean success = true;

            this.addLogStream();
            InstallerLog.WriteLine("Installing " + this.Manifest.Id);
            InstallerLog.WriteLine("---------------------");

            Int32 i = 0;
            float numActions = (float)this.Configuration.Actions.Count; //type is float to avoid having to cast it each time when calculating progress.
            foreach (InstallerAction action in this.Configuration.Actions)
            {
                if (!action.RunAtUninstall)
                    continue;

                if (!action.Undo(this))
                    success = false;

                i++;
                this.OnProgress(new InstallerProgressEventArgs((int)(i / numActions) * 100));
            }

            InstallerLog.WriteLine("---------------------");
            if (success)
            {
                InstallerLog.WriteLine("Uninstallation successful");
                this.OnCompleted(new EventArgs());
            }
            else
            {
                InstallerLog.WriteLine("Uninstallation failed");
                this.OnFailed(new EventArgs());
            }
            InstallerLog.WriteLine("");
            this.removeLogStream();

            return success;
        }


        public event InstallerProgressEventHandler Progress;
        public event EventHandler Completed;
        public event EventHandler Failed;
        protected void OnProgress(InstallerProgressEventArgs e)
        {
            if (this.Progress != null)
                this.Progress(this, e);
        }
        protected void OnCompleted(EventArgs e)
        {
            if (this.Completed != null)
                this.Completed(this, e);
        }
        protected void OnFailed(EventArgs e)
        {
            if (this.Failed != null)
                this.Failed(this, e);
        }
    }


    public delegate void InstallerProgressEventHandler(object sender, InstallerProgressEventArgs args);
    public class InstallerProgressEventArgs : EventArgs
    {
        public Int32 Progress { get; private set; }

        public InstallerProgressEventArgs(Int32 progress)
        {
            this.Progress = progress;
        }
    }
}
