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
using System.ComponentModel;

namespace ScriptCenter.Installer.Actions
{
    /// <summary>
    /// Abstract base class for installer actions.
    /// </summary>
    public abstract class InstallerAction
    {
        public InstallerAction()
        {
            InstallerHelperMethods.SetDefaultValues(this);
        }

        public abstract Boolean Do(Installer installer);
        public abstract Boolean Undo(Installer installer);

        [JsonProperty("run_at_install")]
        [XmlAttribute("run_at_install")]
        [DefaultValue(true)]
        [DisplayName("Install")]
        public Boolean RunAtInstall { get; set; }

        [JsonProperty("run_at_uninstall")]
        [XmlAttribute("run_at_uninstall")]
        [DefaultValue(true)]
        [DisplayName("Uninstall")]
        public Boolean RunAtUninstall { get; set; }

        [JsonIgnore()]
        [XmlIgnore()]
        [Browsable(false)]
        public virtual String ActionName { get { return ""; } }

        [JsonIgnore()]
        [XmlIgnore()]
        [Browsable(false)]
        public virtual String ActionImageKey { get { return "action"; } }

        [JsonIgnore()]
        [XmlIgnore()]
        [Browsable(false)]
        public virtual String ActionDetails { get { return ""; } }
    }
}
