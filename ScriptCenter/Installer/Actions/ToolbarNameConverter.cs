using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ScriptCenter.Installer.Actions
{
    public class ToolbarNameConverter : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return false;
        }

        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            List<String> toolbarNames = new List<String>();
            if (context.Instance is InstallerAction && ((InstallerAction)context.Instance).Configuration != null)
            {
                InstallerAction action = (InstallerAction)context.Instance;
                foreach (InstallerAction a in action.Configuration.Actions)
                {
                    if (a is CreateToolbarAction)
                        toolbarNames.Add(((CreateToolbarAction)a).ToolbarName);
                }
            }
            toolbarNames.Add("Main Toolbar");
            return new StandardValuesCollection(toolbarNames);
        }
    }
}
