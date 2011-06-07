using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScriptCenter.Repository;

namespace ScriptCenter.Repository
{
    public class ScriptManifestTokens
    {
        internal const String Id_Token = "{id}";
        internal const String Name_Token = "{name}";
        internal const String Author_Token = "{author}";
        internal const String Version_Token = "{version}";
        internal const String Version_Underscores_Token = "{version_undersc}";
        internal const String VersionMajor_Token = "{version_major}";
        internal const String VersionMinor_Token = "{version_minor}";
        internal const String VersionRevision_Token = "{version_rev}";
        internal const String VersionStage_Token = "{version_stage}";

        internal static String Replace(String str, ScriptManifest manifest)
        {
            if (str == null || manifest == null)
                return String.Empty;

            StringBuilder newString = new StringBuilder(str);

            newString.Replace(Id_Token, manifest.Id);
            newString.Replace(Name_Token, manifest.Name);
            newString.Replace(Author_Token, manifest.Author);

            if (manifest.Versions.Count != 0)
            {
                //TODO: find a solution for getting the actual version, not just the first one.
                newString.Replace(Version_Token, manifest.Versions[0].VersionNumber.ToString());
                newString.Replace(Version_Underscores_Token, manifest.Versions[0].VersionNumber.ToString(true));
                newString.Replace(VersionMajor_Token, manifest.Versions[0].VersionNumber.Major.ToString());
                newString.Replace(VersionMinor_Token, manifest.Versions[0].VersionNumber.Minor.ToString());
                newString.Replace(VersionRevision_Token, manifest.Versions[0].VersionNumber.Revision.ToString());
                newString.Replace(VersionStage_Token, manifest.Versions[0].VersionNumber.ReleaseStage.ToString().ToLower());
            }

            return newString.ToString();
        }
    }
}
