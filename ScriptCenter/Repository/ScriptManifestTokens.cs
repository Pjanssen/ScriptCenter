using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScriptCenter.Repository;

namespace ScriptCenter.Repository
{
    internal static class ScriptManifestTokens
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
        internal const String Date_Token = "{date}";

        /// <summary>
        /// Replaces any tokens in the string with values taken from the manifest.
        /// </summary>
        /// <param name="str">The string to replace tokens in.</param>
        /// <param name="manifest">The manifest to take values from.</param>
        /// <param name="version">The version to use for version-related tokens.</param>
        /// <returns>Returns the new string.</returns>
        internal static String Replace(String str, ScriptManifest manifest, ScriptVersion version)
        {
            if (str == null || manifest == null || version == null)
                return String.Empty;

            StringBuilder newString = new StringBuilder(str);

            newString.Replace(Id_Token, manifest.Id.ToString());
            newString.Replace(Name_Token, manifest.Name);
            newString.Replace(Author_Token, manifest.Author);
            newString.Replace(Version_Token, version.VersionNumber.ToString());
            newString.Replace(Version_Underscores_Token, version.VersionNumber.ToString(true));
            newString.Replace(VersionMajor_Token, version.VersionNumber.Major.ToString());
            newString.Replace(VersionMinor_Token, version.VersionNumber.Minor.ToString());
            newString.Replace(VersionRevision_Token, version.VersionNumber.Revision.ToString());
            newString.Replace(VersionStage_Token, version.VersionNumber.ReleaseStage.ToString().ToLower());
            newString.Replace(Date_Token, DateTime.Today.ToString("yyyy'-'MM'-'dd"));

            return newString.ToString();
        }
    }
}
