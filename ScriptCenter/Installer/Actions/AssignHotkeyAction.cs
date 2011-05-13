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
using System.Xml.Serialization;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ScriptCenter.Installer.Actions
{
/// <summary>
/// Assigns a hotkey to a macscript.
/// </summary>
public class AssignHotkeyAction : InstallerAction
{
    public AssignHotkeyAction() { }
    public AssignHotkeyAction(Keys keys)
    {
        this.Keys = keys;
    }

    /// <summary>
    /// String representation of the 'Keys' property.
    /// </summary>
    [JsonProperty(PropertyName = "key")]
    [XmlAttribute("key")]
    public String KeysString 
    {
        get { return this.Keys.ToString(); }
        set
        {
            try
            {
                this.Keys = (Keys)Enum.Parse(typeof(Keys), value);
            }
            catch
            {
                this.Keys = Keys.None;
            }
        }
    }

    /// <summary>
    /// The hotkey to assign.
    /// </summary>
    [JsonIgnore()]
    [XmlIgnore()]
    public Keys Keys { get; set; }


    /// <summary>
    /// The name of the macroscript.
    /// </summary>
    [JsonProperty("macro_name")]
    [XmlAttribute("macro_name")]
    public String MacroName { get; set; }

    /// <summary>
    /// The category of the macroscript.
    /// </summary>
    [JsonProperty("macro_category")]
    [XmlAttribute("macro_category")]
    public String MacroCategory { get; set; }



    /// <summary>
    /// Assigns the hotkey to the macroscript.
    /// </summary>
    public override bool Do(Installer installer)
    {
        //TODO: implement
        return true;
    }

    /// <summary>
    /// Removes the hotkey assignment.
    /// </summary>
    public override bool Undo(Installer installer)
    {
        //TODO: implement
        return true;
    }
}
}
