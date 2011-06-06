using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ScriptCenter.Utils
{
    public static class ObjectSetDefaultValuesExtension
    {
        public static void SetDefaultValues(this Object obj)
        {
            Type t = obj.GetType();
            foreach (System.Reflection.PropertyInfo pi in t.GetProperties())
            {
                Object[] defaultValueAttr = pi.GetCustomAttributes(typeof(DefaultValueAttribute), true);
                if (defaultValueAttr.Length > 0)
                {
                    pi.SetValue(obj, ((DefaultValueAttribute)defaultValueAttr[0]).Value, null);
                }
            }
        }
    }
}
