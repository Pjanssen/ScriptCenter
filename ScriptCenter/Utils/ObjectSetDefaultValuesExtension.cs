using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Reflection;

namespace ScriptCenter.Utils
{
    public static class ObjectSetDefaultValuesExtension
    {
        public static void SetDefaultValues(this ScriptCenter.Package.ScriptPackage package)
        {
            _setDefaultValues(package);
        }

        public static void SetDefaultValues(this ScriptCenter.Package.InstallerActions.InstallerAction installerAction)
        {
            _setDefaultValues(installerAction);
        }


        private static void _setDefaultValues(Object obj)
        {
            Type t = obj.GetType();
            BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

            PropertyInfo[] properties = t.GetProperties(flags);
            foreach (PropertyInfo pi in properties)
            {
                Object[] defaultValueAttr = pi.GetCustomAttributes(typeof(DefaultValueAttribute), true);
                if (defaultValueAttr.Length > 0)
                    pi.SetValue(obj, ((DefaultValueAttribute)defaultValueAttr[0]).Value, null);
            }

            FieldInfo[] fields = t.GetFields(flags);
            foreach (FieldInfo fi in fields)
            {
                Object[] defaultValueAttr = fi.GetCustomAttributes(typeof(DefaultValueAttribute), true);
                if (defaultValueAttr.Length > 0)
                    fi.SetValue(obj, ((DefaultValueAttribute)defaultValueAttr[0]).Value);
            }
        }
    }
}
