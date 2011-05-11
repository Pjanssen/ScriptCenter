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

namespace ScriptCenter.Installer.Actions
{
public class AssignHotkeyAction : InstallerAction
{
    [XmlAttribute("key")]
    [JsonProperty(PropertyName="key")]
    public String KeysString { get; set; }

    [XmlIgnore()]
    [JsonIgnore()]
    public Keys Keys
    {
        get
        {
            try
            {
                return (Keys)Enum.Parse(typeof(Keys), this.KeysString);
            }
            catch
            {
                return Keys.None;
            }
        }
        set
        {
            this.KeysString = value.ToString();
        }
    }

    public AssignHotkeyAction() { }
    public AssignHotkeyAction(Keys keys)
    {
        this.Keys = keys;
    }

    public override bool Do(Installer installer)
    {
        return true;
    }

    public override bool Undo(Installer installer)
    {
        return true;
    }
}
}
