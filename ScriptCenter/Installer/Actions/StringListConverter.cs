using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace ScriptCenter.Installer.Actions
{
public class StringListConverter : StringConverter
{
    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
    {
        if (sourceType == typeof(String))
            return true;

        return base.CanConvertFrom(context, sourceType);
    }

    public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
    {
        if (value is String)
        {
            List<String> l = new List<String>();
            String[] splitStr = Regex.Replace((String)value, @"[ ]", "").Split(';');
            foreach (String s in splitStr)
            {
                if (s != String.Empty)
                    l.Add(s);
            }
            return l;
        }

        return base.ConvertFrom(context, culture, value);
    } 

    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
    {
        if (destinationType == typeof(String))
            return true;

        return base.CanConvertTo(context, destinationType);
    }

    public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
    {
        if (destinationType == typeof(String))
        {
            StringBuilder str = new StringBuilder();
            List<String> source = (List<String>)value;
            foreach (String s in source)
            {
                str.Append(s);
                str.Append("; ");
            }
            return str.ToString();
        }

        return base.ConvertTo(context, culture, value, destinationType);
    }
}
}