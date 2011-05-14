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
using ScriptCenter.Installer.Actions;

namespace ScriptCenter.Installer
{
    public class Installer
    {
        public String InstallerDirectory { get; private set; }
        public Exception InstallerException { get; internal set; }

        public ScriptManifest Manifest { get; private set; }
        public InstallerConfiguration Configuration { get; private set; }
        public InstallerLog Log { get; private set; }

        private Installer() 
        {
            this.Log = new InstallerLog("C:/temp/scriptcenter/installer_log.txt"); //TODO: set correct path
        }
        public Installer(String installerDirectory, ScriptManifest manifest, InstallerConfiguration config) : this() 
        {
            this.InstallerDirectory = installerDirectory;
            this.Manifest = manifest;
            this.Configuration = config;
        }
        public Installer(String installerDirectory, String manifestFile, String configFile) : this() 
        {
            this.InstallerDirectory = installerDirectory;

            LocalFileHandler<ScriptManifest> manifestHandler = new LocalFileHandler<ScriptManifest>();
            this.Manifest = manifestHandler.Read(manifestFile);
            LocalFileHandler<InstallerConfiguration> configHandler = new LocalFileHandler<InstallerConfiguration>();
            this.Configuration = configHandler.Read(configFile);
        }

        /// <summary>
        /// Installs the script.
        /// </summary>
        /// <returns>True if install was successful.</returns>
        public Boolean Install() 
        {
            Boolean success = true;

            this.Log.Append("Installing " + this.Manifest.Id, 1);

            Int32 i = 0;
            float numActions = (float)this.Configuration.InstallerActions.Count;
            foreach (InstallerAction action in this.Configuration.InstallerActions)
            {
                //TODO: Check if this might have to be done on a separate thread to allow UI updates.
                if (!(success = action.Do(this)))
                    break;

                i++;
                this.OnProgress(new InstallerProgressEventArgs((int)(i / numActions) * 100));
            }

            if (success)
            {
                this.Log.Append("Finished installing " + this.Manifest.Id);
                this.OnCompleted(new EventArgs());
            }
            else
            {
                this.Log.Append("Failed to install " + this.Manifest.Id);
                this.OnFailed(new EventArgs());
            }

            return success;
        }
        

        /// <summary>
        /// Uninstalls the script.
        /// </summary>
        /// <returns>True if uninstall was successful.</returns>
        public Boolean Uninstall() 
        {
            Boolean success = true;

            this.Log.Append("Uninstalling " + this.Manifest.Id, 1);

            Int32 i = 0;
            float numActions = (float)this.Configuration.InstallerActions.Count;
            foreach (InstallerAction action in this.Configuration.InstallerActions)
            {
                if (!action.Undo(this))
                    success = false;

                i++;
                this.OnProgress(new InstallerProgressEventArgs((int)(i / numActions) * 100));
            }

            if (success)
            {
                this.Log.Append("Finished uninstalling " + this.Manifest.Id);
                this.OnCompleted(new EventArgs());
            }
            else
            {
                this.Log.Append("Failed to uninstall " + this.Manifest.Id);
                this.OnFailed(new EventArgs());
            }

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
