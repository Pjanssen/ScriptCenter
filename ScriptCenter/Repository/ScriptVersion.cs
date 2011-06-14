using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Runtime.Serialization.Formatters.Binary;
using ScriptCenter.Utils;

namespace ScriptCenter.Repository
{
    /// <summary>
    /// The ScriptVersion class contains the version number, the path to the script and its requirements.
    /// </summary>
    [Serializable]
    public class ScriptVersion
    {
        [JsonProperty("version")]
        [DisplayName("Version")]
        public ScriptVersionNumber VersionNumber { get; set; }


        [JsonProperty("supported_max_versions")]
        [DisplayName("Supported 3dsmax Versions")]
        [Editor(typeof(ScriptCenter.Controls.SupportedMaxVersionsEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public SupportedMaxVersions SupportedMaxVersions { get; set; }


        [JsonProperty("uri")]
        [DisplayName("Script/Package File")]
        [Description("The path to the script or package for this version. Make sure this reflects the situation on your (web)host!")]
        [Editor(typeof(ScriptCenter.Controls.VersionScriptPathEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public String ScriptPath { get; set; }

        

        public ScriptVersion() : this(1, 0, 0, ScriptReleaseStage.Release) { }
        public ScriptVersion(Int32 major, Int32 minor, Int32 revision, ScriptReleaseStage releaseStage) 
            : this(new ScriptVersionNumber(major, minor, revision, releaseStage)) { }
        public ScriptVersion(ScriptVersionNumber versionNumber)
        {
            this.VersionNumber = versionNumber;
            this.SupportedMaxVersions = SupportedMaxVersions.All;
        }
        
        /// <summary>
        /// Creates a deep-copy of the ScriptVersion object.
        /// </summary>
        public ScriptVersion Copy()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            System.IO.MemoryStream memStream = new System.IO.MemoryStream();
            formatter.Serialize(memStream, this);
            memStream.Position = 0;
            return (ScriptVersion)formatter.Deserialize(memStream);
        }
    }



    [Serializable]
    [TypeConverter(typeof(ScriptVersionConverter))]
    [JsonConverter(typeof(StringJsonConverter))]
    public class ScriptVersionNumber : INotifyPropertyChanged, IComparable<ScriptVersionNumber>
    {
        private Int32 _major;
        private Int32 _minor;
        private Int32 _revision;
        private ScriptReleaseStage _releaseStage;

        [DefaultValue(1)]
        [Description("The major component of the version.")]
        public Int32 Major 
        {
            get { return _major; }
            set
            {
                _major = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("Major"));
            }
        }

        [DefaultValue(0)]
        [Description("The minor component of the version.")]
        public Int32 Minor 
        {
            get { return _minor; }
            set
            {
                _minor = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("Minor"));
            }
        }

        [DefaultValue(0)]
        [Description("The revision component of the version.")]
        public Int32 Revision 
        {
            get { return _revision; }
            set
            {
                _revision = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("Revision"));
            }
        }

        [DisplayName("Release Stage")]
        [Description("The stage of this version indicating the stability of the script.")]
        [DefaultValue(ScriptReleaseStage.Release)]
        public ScriptReleaseStage ReleaseStage 
        {
            get { return _releaseStage; }
            set
            {
                _releaseStage = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("ReleaseStage"));
            }
        }

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

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, e);
        }

        public override String ToString()
        {
            return this.ToString(false);
        }
        public String ToString(Boolean useUnderscores)
        {
            Char numSeparatorChar = (useUnderscores) ? '_' : '.';
            Char stageSeparatorChar = (useUnderscores) ? '_' : ' ';

            String versionStr = this.Major.ToString() + numSeparatorChar + this.Minor.ToString() + numSeparatorChar + this.Revision.ToString();
            if (this.ReleaseStage != ScriptReleaseStage.Release)
                versionStr += stageSeparatorChar + Enum.GetName(typeof(ScriptReleaseStage), this.ReleaseStage).ToLower();

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
        public override Boolean Equals(object obj)
        {
            if (!(obj is ScriptVersionNumber))
                return false;

            return this.CompareTo((ScriptVersionNumber)obj) == 0;
        }
        public override Int32 GetHashCode()
        {
            return base.GetHashCode();
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
