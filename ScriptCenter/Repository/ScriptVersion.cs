using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace ScriptCenter.Repository
{
    /// <summary>
    /// The ScriptVersion class contains the version number, the path to the script and its requirements.
    /// </summary>
    public class ScriptVersion
    {
        [DisplayName("Version")]
        [JsonProperty("version_number")]
        public ScriptVersionNumber VersionNumber { get; set; }


        [DisplayName("Script Path")]
        [JsonProperty("script_path")]
        public String ScriptPath { get; set; }


        [JsonProperty("min_3dsmax_version")]
        [DisplayName("Minimal 3dsmax version")]
        [DefaultValue(0)]
        [TypeConverter(typeof(RequiredMaxVersionConverter))]
        public Int32 Minimal3dsmaxVersion { get; set; }

        [JsonProperty("max_3dsmax_version")]
        [DisplayName("Maximum 3dsmax version")]
        [DefaultValue(0)]
        [TypeConverter(typeof(RequiredMaxVersionConverter))]
        public Int32 Maximum3dsmaxVersion { get; set; }


        public ScriptVersion() : this(1, 0, 0) { }
        public ScriptVersion(Int32 major, Int32 minor, Int32 revision)
        {
            this.VersionNumber = new ScriptVersionNumber(major, minor, revision);
            this.Minimal3dsmaxVersion = 0;
            this.Maximum3dsmaxVersion = 0;
        }
    }



    [TypeConverter(typeof(ScriptVersionConverter))]
    public class ScriptVersionNumber : IComparable<ScriptVersionNumber>
    {
        [JsonIgnore()]
        public Int32 Major { get; set; }

        [JsonIgnore()]
        public Int32 Minor { get; set; }

        [JsonIgnore()]
        public Int32 Revision { get; set; }

        [DisplayName("Release Stage")]
        [DefaultValue(ScriptReleaseStage.Release)]
        [JsonIgnore()]
        public ScriptReleaseStage ReleaseStage { get; set; }

        public ScriptVersionNumber() : this(1, 0, 0, ScriptReleaseStage.Release) { }
        public ScriptVersionNumber(Int32 major, Int32 minor, Int32 revision) : this(major, minor, revision, ScriptReleaseStage.Release) { }
        public ScriptVersionNumber(Int32 major, Int32 minor, Int32 revision, ScriptReleaseStage releaseStage)
        {
            this.Major = major;
            this.Minor = minor;
            this.Revision = revision;
            this.ReleaseStage = releaseStage;
        }
        public ScriptVersionNumber(String version)
        {
            try
            {
                String[] tokens = Regex.Split(version, @"[\. ]");
                this.Major = Int32.Parse(tokens[0]);

                if (tokens.Length > 1)
                    this.Minor = Int32.Parse(tokens[1]);
                else
                    this.Minor = 0;

                if (tokens.Length > 2)
                    this.Revision = Int32.Parse(tokens[2]);
                else
                    this.Revision = 0;

                if (tokens.Length == 4)
                    this.ReleaseStage = (ScriptReleaseStage)Enum.Parse(typeof(ScriptReleaseStage), tokens[3].Substring(0, 1).ToUpper() + tokens[3].Substring(1));
                else
                    this.ReleaseStage = ScriptReleaseStage.Release;
            }
            catch (Exception e)
            {
                throw new ArgumentException("Version string must be in the format \"Int32.Int32.Int32 ScriptReleaseStage\"", e);
            }
        }

        public override string ToString()
        {
            String versionStr = this.Major.ToString() + "." + this.Minor.ToString() + "." + this.Revision.ToString();
            if (this.ReleaseStage != ScriptReleaseStage.Release)
                versionStr += " " + Enum.GetName(typeof(ScriptReleaseStage), this.ReleaseStage).ToLower();

            return versionStr;
        }

        public Int32 CompareTo(ScriptVersionNumber versionB)
        {
            if (this.Major < versionB.Major)
                return -1;
            else if (this.Major > versionB.Major)
                return 1;

            if (this.Minor < versionB.Minor)
                return -1;
            else if (this.Minor > versionB.Minor)
                return 1;

            if (this.Revision < versionB.Revision)
                return -1;
            else if (this.Revision > versionB.Revision)
                return 1;

            if (this.ReleaseStage < versionB.ReleaseStage)
                return -1;
            else if (this.ReleaseStage > versionB.ReleaseStage)
                return 1;

            return 0;
        }
        public override bool Equals(object obj)
        {
            if (!(obj is ScriptVersionNumber))
                return false;

            return this.CompareTo((ScriptVersionNumber)obj) == 0;
        }

        public static bool operator <(ScriptVersionNumber versionA, ScriptVersionNumber versionB)
        {
            return versionA.CompareTo(versionB) == -1;
        }
        public static bool operator <=(ScriptVersionNumber versionA, ScriptVersionNumber versionB)
        {
            return versionA.CompareTo(versionB) <= 0;
        }
        public static bool operator >(ScriptVersionNumber versionA, ScriptVersionNumber versionB)
        {
            return versionA.CompareTo(versionB) == 1;
        }
        public static bool operator >=(ScriptVersionNumber versionA, ScriptVersionNumber versionB)
        {
            return versionA.CompareTo(versionB) >= 0;
        }
        public static bool operator ==(ScriptVersionNumber versionA, ScriptVersionNumber versionB)
        {
            return versionA.Equals(versionB);
        }
        public static bool operator !=(ScriptVersionNumber versionA, ScriptVersionNumber versionB)
        {
            return !versionA.Equals(versionB);
        }
    }

    public enum ScriptReleaseStage : int
    {
        Alpha = 1,
        Beta = 2,
        Release = 3
    }
}
