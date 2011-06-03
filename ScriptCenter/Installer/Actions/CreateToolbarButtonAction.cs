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
        public CreateToolbarButtonAction() : this("", "", "") { }
        public CreateToolbarButtonAction(String toolbarName, String macroName, String macroCategory)
        {
            this.ToolbarName = toolbarName;
            this.MacroName = macroName;
            this.MacroCategory = macroCategory;
        }


        /// <summary>
        /// The name of the toolbar to add the item to.
        /// </summary>
        [JsonProperty("toolbar_name")]
        [Category("1. Action Properties")]
        [DisplayName("Toolbar Name")]
        [Description("The name of the toolbar to add the button to.")]
        [TypeConverter(typeof(ToolbarNameConverter))]
        public String ToolbarName { get; set; }

        /// <summary>
        /// The category of the macroscript.
        /// </summary>
        [JsonProperty("macro_category")]
        [Category("1. Action Properties")]
        [DisplayName("Macroscript Category")]
        [Description("The category of the macroscript associated with the button.")]
        public String MacroCategory { get; set; }

        /// <summary>
        /// The name of the macroscript.
        /// </summary>
        [JsonProperty("macro_name")]
        [Category("1. Action Properties")]
        [DisplayName("Macroscript Name")]
        [Description("The name of the macroscript associated with the button.")]
        public String MacroName { get; set; }


        /// <summary>
        /// The text displayed for the button.
        /// </summary>
        [JsonProperty("button_text")]
        [Category("1. Action Properties")]
        [DisplayName("Button Text")]
        [Description("The text displayed on the button when not using an image.")]
        public String ButtonText { get; set; }

        /// <summary>
        /// The tooltip text of the button.
        /// </summary>
        [JsonProperty("tooltip_text")]
        [Category("1. Action Properties")]
        [DisplayName("Tooltip Text")]
        [Description("The text for the tooltip of the button.")]
        public String TooltipText { get; set; }


        /// <summary>
        /// Create a button on a toolbar.
        /// </summary>
        public override bool Do(Installer installer)
        {
            CuiFile cui = new CuiFile(CuiFile.MaxGetActiveCuiFile());
            if (!cui.Read())
                return false;

            if (cui.AddToolbarButton(this.ToolbarName, this.MacroName, this.MacroCategory, this.ButtonText, this.TooltipText))
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

            if (cui.RemoveItem(this.MacroName, this.MacroCategory))
            {
                if (!cui.Write())
                    return false;
                else
                    cui.MaxLoadCuiFile();
            }

            return true;
        }


        public override string ActionName { get { return "Create Toolbar Button"; } }
        public override string ActionImageKey { get { return "toolbar_button"; } }
        public override string ActionDetails
        {
            get
            {
                if (this.ToolbarName != String.Empty && this.MacroName != String.Empty && this.MacroCategory != String.Empty)
                    return String.Format("{0} -> {1}::{2}", this.ToolbarName, this.MacroCategory, this.MacroName);
                else
                    return String.Empty;
            }
        }
    }
}
