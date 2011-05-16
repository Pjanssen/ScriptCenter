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
using ScriptCenter.Max;
using System.ComponentModel;

namespace ScriptCenter.Installer.Actions
{
    /// <summary>
    /// Creates an item on a toolbar.
    /// </summary>
    public class CreateToolbarButtonAction : InstallerAction
    {
        /// <summary>
        /// The name of the toolbar to add the item to.
        /// </summary>
        [JsonProperty("toolbar_name")]
        [DisplayName("Toolbar Name")]
        public String ToolbarName { get; set; }

        /// <summary>
        /// The name of the macroscript.
        /// </summary>
        [JsonProperty("macro_name")]
        [XmlAttribute("macro_name")]
        [DisplayName("Macroscript Name")]
        public String MacroName { get; set; }

        /// <summary>
        /// The category of the macroscript.
        /// </summary>
        [JsonProperty("macro_category")]
        [XmlAttribute("macro_category")]
        [DisplayName("Macroscript Category")]
        public String MacroCategory { get; set; }

        /// <summary>
        /// The text displayed for the item.
        /// </summary>
        [JsonProperty("item_text")]
        [XmlAttribute("item_text")]
        [DisplayName("Item Text")]
        public String ItemText { get; set; }


        public CreateToolbarButtonAction() { }
        public CreateToolbarButtonAction(String toolbarName, String macroName, String macroCategory)
        {
            this.ToolbarName = toolbarName;
            this.MacroName = macroName;
            this.MacroCategory = macroCategory;
        }

        /// <summary>
        /// Create a button on a toolbar.
        /// </summary>
        public override bool Do(Installer installer)
        {
            CuiFile cui = new CuiFile(CuiFile.MaxGetActiveCuiFile());
            if (!cui.Read())
                return false;

            if (cui.AddToolbarButton(this.ToolbarName, this.MacroName, this.MacroCategory, this.ItemText))
            {
                if (!cui.Write())
                    return false;
                else
                    cui.MaxLoadCuiFile();
            }

            return true;
        }


        /// <summary>
        /// Remove a button from a toolbar.
        /// </summary>
        public override bool Undo(Installer installer)
        {
            CuiFile cui = new CuiFile(CuiFile.MaxGetActiveCuiFile());
            if (!cui.Read())
                return false;

            if (cui.RemoveToolbarButton(this.MacroName, this.MacroCategory))
            {
                if (!cui.Write())
                    return false;
                else
                    cui.MaxLoadCuiFile();
            }

            return true;
        }


        public override string ActionName { get { return "Create Toolbar Button"; } }
    }
}
