using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ScriptCenter.Installer
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
