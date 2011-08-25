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
using System.ComponentModel;

namespace ScriptCenter.Package
{
    public class Installer
    {
        public String InstallerDirectory { get; private set; }
        public String ResourcesDirectory { get; private set; }

        public ScriptManifest Manifest { get; private set; }
        public InstallerConfiguration Configuration { get; private set; }

        private FileStream logFileStream;
        private StreamWriter logFileStreamWriter;

        public Installer(String installerDirectory, ScriptManifest manifest, InstallerConfiguration config)
        {
            this.InstallerDirectory = installerDirectory;
            this.Manifest = manifest;
            this.Configuration = config;
        }
        public Installer(IPath installerDirectory, IPath manifestFile, IPath configFile)
        {
            this.InstallerDirectory = installerDirectory.AbsolutePath;
            this.ResourcesDirectory = this.InstallerDirectory + "\\" + PackageBuilder.ResourcesArchivePath;

            JsonFileHandler<ScriptManifest> manifestHandler = new JsonFileHandler<ScriptManifest>();
            this.Manifest = manifestHandler.Read(manifestFile);
            JsonFileHandler<InstallerConfiguration> configHandler = new JsonFileHandler<InstallerConfiguration>();
            this.Configuration = configHandler.Read(configFile);
        }

        private void addLogStream()
        {
            //TODO: set correct log path
            this.logFileStream = new FileStream("C:/temp/scriptcenter/installer.log", FileMode.OpenOrCreate);
            this.logFileStreamWriter = new StreamWriter(this.logFileStream);
            InstallerLog.AddWriter(this.logFileStreamWriter, InstallerLog.TimeStampedLineFormat);
        }

        private void removeLogStream()
        {
            InstallerLog.RemoveWriter(this.logFileStreamWriter);
            this.logFileStreamWriter.Dispose();
        }


        /// <summary>
        /// Installs the script.
        /// </summary>
        public void Install() 
        {
            this.addLogStream();

            InstallerLog.WriteLine("Installing " + this.Manifest.Id);
            InstallerLog.WriteLine("---------------------");

            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += new DoWorkEventHandler(install_DoWork);
            worker.ProgressChanged += new ProgressChangedEventHandler(install_ProgressChanged);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(install_RunWorkerCompleted);
            worker.RunWorkerAsync();
        }

        private void install_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            Int32 numActions = this.Configuration.Actions.Count;
            for (Int32 i = 0; i < numActions; i++)
            {
                InstallerAction action = this.Configuration.Actions[i];

                if (!action.RunAtInstall)
                    continue;
                
                //Execute action.
                Boolean actionSuccess = false;
                try
                {
                    actionSuccess = action.Do(this);
                }
                catch (Exception ex)
                {
                    this.OnFailed(new InstallerFailedEventArgs(ex));
                }

                //If action failed, cancel backgroundworker.
                if (!actionSuccess)
                {
                    worker.CancelAsync();
                    break;
                }

                //Report progress.
                Int32 progress = (Int32)(((i + 1) / (float)numActions) * 100);
                worker.ReportProgress(progress);
            }
        }

        private void install_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            InstallerLog.WriteLine("---------------------");

            if (!e.Cancelled && e.Error == null)
            {
                InstallerLog.WriteLine("Installation successful");
                this.OnCompleted(new EventArgs());
            }
            else
            {
                InstallerLog.WriteLine("Installation failed");
            }

            InstallerLog.WriteLine(String.Empty);
            this.removeLogStream();
        }

        private void install_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.OnProgress(new InstallerProgressEventArgs(e.ProgressPercentage));
        }

        
        

        /// <summary>
        /// Uninstalls the script.
        /// </summary>
        public void Uninstall() 
        {
            this.addLogStream();
            InstallerLog.WriteLine("Installing " + this.Manifest.Id);
            InstallerLog.WriteLine("---------------------");

            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += new DoWorkEventHandler(uninstall_DoWork);
            worker.ProgressChanged += new ProgressChangedEventHandler(uninstall_ProgressChanged);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(uninstall_RunWorkerCompleted);
            worker.RunWorkerAsync();
        }

        private void uninstall_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            Int32 numActions = this.Configuration.Actions.Count;
            for (Int32 i = 0; i < numActions; i++)
            {
                InstallerAction action = this.Configuration.Actions[i];

                if (!action.RunAtUninstall)
                    continue;
                
                //Undo action.
                Boolean actionSuccess = false;
                try
                {
                    actionSuccess = action.Undo(this);
                }
                catch (Exception ex)
                {
                    this.OnFailed(new InstallerFailedEventArgs(ex));
                }

                //If action failed cancel backgroundworker.
                if (!actionSuccess)
                {
                    worker.CancelAsync();
                    break;
                }
                
                //Report progress.
                Int32 progress = (Int32)(((i + 1) / (float)numActions) * 100);
                worker.ReportProgress(progress);
            }
        }

        private void uninstall_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            InstallerLog.WriteLine("---------------------");

            if (!e.Cancelled && e.Error == null)
            {
                InstallerLog.WriteLine("Uninstallation successful");
                this.OnCompleted(new EventArgs());
            }
            else
            {
                InstallerLog.WriteLine("Uninstallation failed");
            }

            InstallerLog.WriteLine(String.Empty);
            this.removeLogStream();
        }

        private void uninstall_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.OnProgress(new InstallerProgressEventArgs(e.ProgressPercentage));
        }




        public event InstallerProgressEventHandler Progress;
        public event EventHandler Completed;
        public event InstallerFailedEventHandler Failed;
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
        protected void OnFailed(InstallerFailedEventArgs e)
        {
            if (e.Exception != null)
                InstallerLog.WriteLine(e.Exception.Message);

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

    public delegate void InstallerFailedEventHandler(object sender, InstallerFailedEventArgs args);
    public class InstallerFailedEventArgs : EventArgs
    {
        public Exception Exception { get; private set; }

        public InstallerFailedEventArgs(Exception exception)
        {
            this.Exception = exception;
        }
    }
}
