using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.ComponentModel;
using ScriptCenter.Installer;
using ScriptCenter.Utils;

namespace ScriptCenter.Repository
{
    public class ScriptPackage : INotifyPropertyChanged
    {
        public const String DefaultExtension = ".scpack";

        public ScriptPackage() : this("") { }
        public ScriptPackage(String name) 
        {
            this.SetDefaultValues();
            this.Name = name;
            this.InstallerConfiguration = new InstallerConfiguration();
            this.Manifest = new ScriptManifest();
        }


        [JsonProperty("name")]
        [DefaultValue("")]
        public String Name 
        {
            get { return _name; }
            set
            {
                _name = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("Name"));
            }
        }
        private String _name;

        [JsonProperty("root_path")]
        [DefaultValue("")]
        public String RootPath 
        {
            get { return _rootPath; }
            set
            {
                _rootPath = value;
                if (value != "" && !value.EndsWith("/") && !value.EndsWith("\\"))
                    _rootPath += "/";

                this.OnPropertyChanged(new PropertyChangedEventArgs("RootPath"));
            }
        }
        private String _rootPath;


        [JsonProperty("source_path")]
        [DefaultValue("")]
        public String SourcePathRelative 
        {
            get { return _sourcePath; }
            set
            {
                _sourcePath = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("SourcePathRelative"));
            }
        }
        private String _sourcePath;
        [JsonIgnore]
        public String SourcePathAbsolute 
        {
            get { return PathHelperMethods.GetAbsolutePath(ScriptManifestTokens.Replace(this.SourcePathRelative, this.Manifest), this.RootPath); }
            set { this.SourcePathRelative = PathHelperMethods.GetRelativePath(value, this.RootPath); }
        }

        [JsonProperty("output_path")]
        [DefaultValue("")]
        public String OutputPathRelative 
        {
            get { return _outputPathRelative; }
            set
            {
                _outputPathRelative = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("OutputPathRelative"));
            }
        }
        private String _outputPathRelative;
        [JsonIgnore]
        public String OutputPathAbsolute 
        {
            get { return PathHelperMethods.GetAbsolutePath(ScriptManifestTokens.Replace(this.OutputPathRelative, this.Manifest), this.RootPath); }
            set { this.OutputPathRelative = PathHelperMethods.GetRelativePath(value, this.RootPath); }
        }

        [JsonProperty("output_file")]
        [DefaultValue(ScriptManifestTokens.Name_Token + "_" + ScriptManifestTokens.Version_Underscores_Token + ".mzp")]
        public String OutputFileRelative 
        {
            get { return _outputFileRelative; }
            set
            {
                _outputFileRelative = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("OutputFile"));
            }
        }
        private String _outputFileRelative;
        [JsonIgnore]
        public String OutputFileAbsolute 
        {
            get { return PathHelperMethods.GetAbsolutePath(ScriptManifestTokens.Replace(this.OutputFileRelative, this.Manifest), this.OutputPathAbsolute); }
            set { this.OutputFileRelative = PathHelperMethods.GetRelativePath(value, this.OutputPathAbsolute); }
        }

        [JsonProperty("manifest_version")]
        [DefaultValue("-use latest-")]
        public String ManifestVersion 
        {
            get { return _manifestVersion; }
            set
            {
                this._manifestVersion = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("ManifestVersion"));
            }
        }
        private String _manifestVersion;

        

        /// <summary>
        /// Reroutes all paths in the package to be relative to the new root path.
        /// </summary>
        /// <param name="newRootPath">The new path all others should be made relative to.</param>
        /// <param name="setRootPath">If true, the supplied new root path will be set as the root path of the package.</param>
        public void ReroutePaths(String newRootPath, Boolean setRootPath) 
        {
            //TODO: verify that this does not overwrite manifest tokens!
            if (this.SourcePathRelative != String.Empty)
                this.SourcePathRelative = PathHelperMethods.GetRelativePath(this.SourcePathAbsolute, newRootPath);

            if (this.OutputPathRelative != String.Empty)
                this.OutputPathRelative = PathHelperMethods.GetRelativePath(this.OutputPathAbsolute, newRootPath);

            if (this.OutputFileRelative != String.Empty)
                this.OutputFileRelative = PathHelperMethods.GetRelativePath(this.OutputFileAbsolute, PathHelperMethods.GetAbsolutePath(this.OutputPathRelative, newRootPath));

            if (setRootPath)
                this.RootPath = newRootPath;
        }

        [JsonProperty("manifest")]
        public ScriptManifest Manifest { get; set; }

        [JsonProperty("installer_configuration")]
        public InstallerConfiguration InstallerConfiguration 
        {
            get { return _installerConfiguration; }
            set
            {
                _installerConfiguration = value;
                _installerConfiguration.Package = this;
            }
        }
        private InstallerConfiguration _installerConfiguration;
        


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, e);
        }
    }
}
