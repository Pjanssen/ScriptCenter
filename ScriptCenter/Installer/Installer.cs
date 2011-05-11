using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScriptCenter.Xml;

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
            this.Manifest = manifestHandler.Load(manifestFile);
            LocalFileHandler<InstallerConfiguration> configHandler = new LocalFileHandler<InstallerConfiguration>();
            this.Configuration = configHandler.Load(configFile);
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
