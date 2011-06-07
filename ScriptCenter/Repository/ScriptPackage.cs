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

            this.RootPath = new BasePath("");
            this.SourcePath = new RelativePath("", this.RootPath);
            this.OutputPath = new RelativePath("", this.RootPath);
            this.PackageFile = new RelativePath(ScriptManifestTokens.Name_Token + "_" + ScriptManifestTokens.Version_Underscores_Token + ".mzp", this.OutputPath);
            this.ManifestFile = new RelativePath(ScriptManifestTokens.Name_Token + ScriptManifest.DefaultExtension, this.OutputPath);
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
        [JsonConverter(typeof(BasePathJsonConverter))]
        public BasePath RootPath 
        {
            get { return _rootPath; }
            set
            {
                if (this.SourcePath != null && this.SourcePath.RelativeTo == _rootPath)
                    SourcePath.RelativeTo = value;
                if (this.OutputPath != null && this.OutputPath.RelativeTo == _rootPath) 
                    OutputPath.RelativeTo = value;

                _rootPath = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("RootPath"));
            }
        }
        private BasePath _rootPath;

        [JsonProperty("source_path")]
        [JsonConverter(typeof(BasePathJsonConverter))]
        public RelativePath SourcePath { get; set; }

        [JsonProperty("output_path")]
        [JsonConverter(typeof(BasePathJsonConverter))]
        public RelativePath OutputPath 
        {
            get { return _outputPath; }
            set
            {
                if (this.ManifestFile != null && this.ManifestFile.RelativeTo == _rootPath)
                    ManifestFile.RelativeTo = value;
                if (this.PackageFile != null && this.PackageFile.RelativeTo == _rootPath)
                    PackageFile.RelativeTo = value;

                _outputPath = value;
            }
        }
        private RelativePath _outputPath;

        [JsonProperty("manifest_file")]
        [JsonConverter(typeof(BasePathJsonConverter))]
        public RelativePath ManifestFile { get; set; }

        [JsonProperty("package_file")]
        [JsonConverter(typeof(BasePathJsonConverter))]
        public RelativePath PackageFile { get; set; }


        
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
