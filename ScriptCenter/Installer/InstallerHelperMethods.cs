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
using ScriptCenter.Repository;
using System.ComponentModel;

namespace ScriptCenter.Installer
{
    internal class InstallerHelperMethods
    {
        internal const String Id_Token              = "{id}";
        internal const String Name_Token            = "{name}";
        internal const String Version_Token         = "{version}";
        internal const String VersionMajor_Token    = "{version_major}";
        internal const String VersionMinor_Token    = "{version_minor}";
        internal const String VersionRevision_Token = "{version_revision}";

        internal static String ReplaceTokens(String str, ScriptManifest manifest)
        {
            if (str == null || manifest == null)
                return null;

            str = str.Replace(Id_Token, manifest.Id);
            str = str.Replace(Name_Token, manifest.Name);
            str = str.Replace(Version_Token, manifest.Version.Version);
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
