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
using System.ComponentModel;
using Newtonsoft.Json;
using ScriptCenter.Utils;
using Ionic.Zip;

namespace ScriptCenter.Package.InstallerActions
{
    /// <summary>
    /// Abstract base class for installer actions.
    /// </summary>
    public abstract class InstallerAction
    {
        public InstallerAction()
        {
            this.SetDefaultValues();
        }

        [JsonIgnore]
        [Browsable(false)]
        public InstallerConfiguration Configuration { get; set; }

        public abstract Boolean Do(Installer installer);
        public abstract Boolean Undo(Installer installer);
        public abstract void PackResources(ZipFile zip, String archiveTargetPath, IPath sourcePath);

        [JsonProperty("run_at_install")]
        [DefaultValue(true)]
        [Category("2. Installer Properties")]
        [DisplayName("Install")]
        [Description("When set to true this action will be performed when installing the script.")]
        public virtual Boolean RunAtInstall { get; set; }

        [JsonProperty("run_at_update")]
        [DefaultValue(true)]
        [Category("2. Installer Properties")]
        [DisplayName("Update")]
        [Description("When set to true this action will be undone when uninstalling the script prior to updating it.")]
        public virtual Boolean RunAtUpdate { get; set; }

        [JsonProperty("run_at_uninstall")]
        [DefaultValue(true)]
        [Category("2. Installer Properties")]
        [DisplayName("Uninstall")]
        [Description("When set to true this action will be undone when uninstalling the script.")]
        public virtual Boolean RunAtUninstall { get; set; }

        [JsonIgnore()]
        [Browsable(false)]
        public virtual String ActionName { get { return ""; } }

        [JsonIgnore()]
        [Browsable(false)]
        public virtual String ActionImageKey { get { return "action"; } }

        [JsonIgnore()]
        [Browsable(false)]
        public virtual String ActionDetails { get { return ""; } }
    }
}
