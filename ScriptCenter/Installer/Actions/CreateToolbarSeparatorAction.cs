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
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace ScriptCenter.Installer.Actions
{
    /// <summary>
    /// Creates an item on a toolbar.
    /// </summary>
    public class CreateToolbarSeparatorAction : InstallerAction
    {
        /// <summary>
        /// The name of the toolbar to add the item to.
        /// </summary>
        [JsonProperty("toolbar_name")]
        public String ToolbarName { get; set; }


        /// <summary>
        /// Creates a separator on the toolbar.
        /// </summary>
        public override bool Do(Installer installer)
        {
            CuiFile cui = new CuiFile(CuiFile.MaxGetActiveCuiFile());
            if (!cui.Read())
                return false;

            if (cui.AddToolbarSeparator(this.ToolbarName))
            {
                if (!cui.Write())
                    return false;
                else
                    cui.MaxLoadCuiFile();
            }

            return true;
        }


        /// <summary>
        /// This action cannot be undone.
        /// </summary>
        public override bool Undo(Installer installer)
        {
            return true;
        }
    }
}
