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
using System.Xml.Serialization;
using System.Windows.Forms;
using Newtonsoft.Json;
using ScriptCenter.Max;
using System.ComponentModel;

namespace ScriptCenter.Installer.Actions
{
/// <summary>
/// Assigns a hotkey to a macscript.
/// </summary>
public class AssignHotkeyAction : InstallerAction
{
    public AssignHotkeyAction() : this(Keys.None, "", "") { }
    public AssignHotkeyAction(Keys keys, String macroName, String macroCategory)
    {
        this.Keys = keys;
        this.MacroName = macroName;
        this.MacroCategory = macroCategory;
    }

    /// <summary>
    /// String representation of the 'Keys' property.
    /// </summary>
    [JsonProperty("key")]
    [Browsable(false)]
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
    [Category("1. Action Properties")]
    [DisplayName("Hotkey")]
    [Description("The hotkey the macroscript will be assigned to.")]
    [Editor(typeof(System.Windows.Forms.Design.ShortcutKeysEditor), typeof(System.Drawing.Design.UITypeEditor))]
    public Keys Keys { get; set; }


    /// <summary>
    /// The name of the macroscript.
    /// </summary>
    [JsonProperty("macro_name")]
    [Category("1. Action Properties")]
    [DisplayName("Macroscript Name")]
    [Description("The name of the macroscript that will be assigned to the hotkey.")]
    public String MacroName { get; set; }

    /// <summary>
    /// The category of the macroscript.
    /// </summary>
    [JsonProperty("macro_category")]
    [Category("1. Action Properties")]
    [DisplayName("Macroscript Category")]
    [Description("The category of the macroscript that will be assigned to the hotkey.")]
    public String MacroCategory { get; set; }

    //TODO: test in 3dsmax.

    /// <summary>
    /// Assigns the hotkey to the macroscript.
    /// </summary>
    public override bool Do(Installer installer)
    {
        KbdFile kbd = new KbdFile(KbdFile.MaxGetActiveKbdFile());
        if (!kbd.Read())
            return false;
        if (kbd.AddAction(this.MacroName, this.MacroCategory, this.Keys))
        {
            if (!kbd.Write())
                return false;

            kbd.MaxLoadKbdFile();
        }
        return true;
    }

    /// <summary>
    /// Removes the hotkey assignment.
    /// </summary>
    public override bool Undo(Installer installer)
    {
        KbdFile kbd = new KbdFile(KbdFile.MaxGetActiveKbdFile());
        if (!kbd.Read())
            return false;

        kbd.RemoveAction(this.MacroName, this.MacroCategory);

        if (!kbd.Write())
            return false;

        kbd.MaxLoadKbdFile();
        return true;
    }

    public override string ActionName { get { return "Assign Hotkey"; } }
    public override string ActionImageKey { get { return "hotkey"; } }
    public override string ActionDetails
    {
        get
        {
            String formatStr = String.Empty;
            if (this.Keys != System.Windows.Forms.Keys.None)
            {
                if (this.MacroName != null & this.MacroCategory != null)
                    formatStr = "{0} -> {1}::{2}";
                else
                    formatStr = "{0}";
            }
            return String.Format(formatStr, this.KeysString, this.MacroCategory, this.MacroName);
        }
    }
}
}
