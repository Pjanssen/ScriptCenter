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
using ScriptCenter.Max;
using System.ComponentModel;

namespace ScriptCenter.Installer.Actions
{
    public class CreateToolbarAction : InstallerAction
    {
        /// <summary>
        /// The name of the toolbar to create.
        /// </summary>
        [JsonProperty("name")]
        public String Name { get; set; }


        public CreateToolbarAction() { }
        public CreateToolbarAction(String name)
        {
            this.Name = name;
        }


        /// <summary>
        /// Creates a new toolbar.
        /// </summary>
        public override bool Do(Installer installer)
        {
            CuiFile cui = new CuiFile(CuiFile.MaxGetActiveCuiFile());
            if (!cui.Read())
                return false;

            if (cui.AddToolbar(this.Name))
            {
                if (!cui.Write())
                    return false;
                else
                    cui.MaxLoadCuiFile();
            }

            return true;
        }

        /// <summary>
        /// Removes the created toolbar.
        /// </summary>
        public override bool Undo(Installer installer)
        {
            CuiFile cui = new CuiFile(CuiFile.MaxGetActiveCuiFile());
            if (!cui.Read())
                return false;

            if (cui.RemoveToolbar(this.Name))
            {
                if (!cui.Write())
                    return false;
                else
                    cui.MaxLoadCuiFile();
            }

            return true;
        }

        public override string ActionName { get { return "Create Toolbar"; } }
        public override string ActionDetails { get { return this.Name; } }
    }
}
