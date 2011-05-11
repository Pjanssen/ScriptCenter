using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScriptCenter.Xml;
using System.ComponentModel;

namespace ScriptCenter.Installer
{
    internal class InstallerHelperMethods
    {
        internal const String Id_Token              = "{script_id}";
        internal const String Name_Token            = "{script_name}";
        internal const String Version_Token         = "{script_version}";
        internal const String VersionMajor_Token    = "{script_version_major}";
        internal const String VersionMinor_Token    = "{script_version_minor}";
        internal const String VersionRevision_Token = "{script_version_revision}";

        internal static String ReplaceTokens(String str, ScriptManifest manifest)
        {
            if (str == null || manifest == null)
                return null;

            str = str.Replace(Id_Token, manifest.Id);
            str = str.Replace(Name_Token, manifest.Name);
            str = str.Replace(Version_Token, manifest.Version.ToString());
            str = str.Replace(VersionMajor_Token, manifest.Version.Major.ToString());
            str = str.Replace(VersionMinor_Token, manifest.Version.Minor.ToString());
            str = str.Replace(VersionRevision_Token, manifest.Version.Revision.ToString());

            return str;
        }

        internal static void SetDefaultValues(Object obj)
        {
            //Set default values from DefaultValue property annotation.
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
