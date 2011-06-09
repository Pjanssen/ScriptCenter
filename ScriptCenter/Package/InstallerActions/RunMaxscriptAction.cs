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
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.IO;
using System.ComponentModel;

namespace ScriptCenter.Package.InstallerActions
{
    /// <summary>
    /// Runs a maxscript file. The script to run should return true upon success, false upon failure.
    /// </summary>
    public class RunMaxscriptAction : InstallerAction
    {
        public RunMaxscriptAction() : this("") { }
        public RunMaxscriptAction(String source)
        {
            this.Source = source;
        }


        /// <summary>
        /// The path to the maxscript file to execute. Relative to installer path.
        /// </summary>
        [JsonProperty("source")]
        [Category("1. Action Properties")]
        [DisplayName("Source File")]
        [Description("The maxscript file to run. Do not use this to run macroscripts.")]
        [Editor(typeof(System.Windows.Forms.Design.FileNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public String Source { get; set; }

        /// <summary>
        /// Reads and executes the maxscript file.
        /// </summary>
        public override bool Do(Installer installer)
        {
            try
            {
                using (StreamReader sr = new StreamReader(this.Source))
                {
                    String script = sr.ReadToEnd();
                    Boolean scriptResult = ManagedServices.MaxscriptSDK.ExecuteBooleanMaxscriptQuery(script);
                    InstallerLog.WriteLine("RunMaxscript returned " + scriptResult.ToString());
                    return scriptResult;
                }
            }
            catch (Exception e)
            {
                installer.InstallerException = e;
                return false;
            }
        }

        /// <summary>
        /// Not implemented for this action.
        /// </summary>
        public override bool Undo(Installer installer) { return Do(installer); }


        public override string ActionName { get { return "Run Maxscript"; } }
        public override string ActionDetails
        {
            get
            {
                String formatStr = String.Empty;
                if (this.Source != null)
                    formatStr = "{0}";

                return String.Format(formatStr, this.Source);
            }
        }

        [DefaultValue(true)]
        [Description("When set to true, the maxscript is executed when installing the script.")]
        public override bool RunAtInstall
        {
            get { return base.RunAtInstall; }
            set { base.RunAtInstall = value; }
        }

        [DefaultValue(false)]
        [Description("When set to true, the maxscript is executed when updating the script.")]
        public override bool RunAtUpdate
        {
            get { return base.RunAtUpdate; }
            set { base.RunAtUpdate = value; }
        }

        [DefaultValue(false)]
        [Description("When set to true, the maxscript is executed when uninstalling the script.")]
        public override bool RunAtUninstall
        {
            get { return base.RunAtUninstall; }
            set { base.RunAtUninstall = value; }
        }
    }
}
