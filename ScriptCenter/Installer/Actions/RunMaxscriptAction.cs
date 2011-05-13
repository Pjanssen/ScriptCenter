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

namespace ScriptCenter.Installer.Actions
{
    /// <summary>
    /// Runs a maxscript file. The script to run should return true upon success, false upon failure.
    /// </summary>
    public class RunMaxscriptAction : InstallerAction
    {
        public RunMaxscriptAction() { }
        public RunMaxscriptAction(String source)
        {
            this.Source = source;
        }


        /// <summary>
        /// The path to the maxscript file to execute. Relative to installer path.
        /// </summary>
        [JsonProperty("source")]
        [XmlAttribute("source")]
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
                    installer.Log.Append("RunMaxscript returned " + scriptResult.ToString());
                    return scriptResult;
                }
            }
            catch (Exception e)
            {
                installer.InstallerException = e;
                installer.Log.Append(e.Message);
                return false;
            }
        }

        /// <summary>
        /// Not implemented for this action.
        /// </summary>
        public override bool Undo(Installer installer) { return true; }
    }
}
