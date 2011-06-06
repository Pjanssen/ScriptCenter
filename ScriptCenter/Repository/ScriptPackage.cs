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
                Boolean loadManifest = (_rootPath == null || _rootPath == String.Empty) && this.ManifestPathRelative != String.Empty;

                _rootPath = value;
                if (value != "" && !value.EndsWith("/") && !value.EndsWith("\\"))
                    _rootPath += "/";

                this.OnPropertyChanged(new PropertyChangedEventArgs("RootPath"));

                if (loadManifest)
                    this.loadManifest();
            }
        }
        private String _rootPath;


        [JsonProperty("source_path")]
        [DefaultValue("")]
        private String _sourcePath;
        public String SourcePathRelative
        {
            get { return _sourcePath; }
            set
            {
                _sourcePath = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("SourcePathRelative"));
            }
        }
        public String SourcePathAbsolute
        {
            get { return PathHelperMethods.GetAbsolutePath(this.SourcePathRelative, this.RootPath); }
            set
            {
                this.SourcePathRelative = PathHelperMethods.GetRelativePath(value, this.RootPath);
            }
        }

        [JsonProperty("output_path")]
        [DefaultValue(ScriptManifestTokens.Name_Token + "_" + ScriptManifestTokens.Version_Underscores_Token + ".mzp")]
        private String _outputPathRelative;
        public String OutputPathRelative
        {
            get { return _outputPathRelative; }
            set
            {
                _outputPathRelative = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("OutputPathRelative"));
            }
        }
        public String OutputPathAbsolute
        {
            get { return PathHelperMethods.GetAbsolutePath(this.OutputPathRelative, this.RootPath); }
            set
            {
                this.OutputPathRelative = PathHelperMethods.GetRelativePath(value, this.RootPath);
            }
        }

        [JsonProperty("manifest_path")]
        [DefaultValue("")]
        private String _manifestPathRelative;
        public String ManifestPathRelative
        {
            get { return _manifestPathRelative; }
            set
            {
                _manifestPathRelative = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("ManifestPathRelative"));
                this.loadManifest();
            }
        }
        public String ManifestPathAbsolute
        {
            get { return PathHelperMethods.GetAbsolutePath(this.ManifestPathRelative, this.RootPath); }
            set
            {
                this.ManifestPathRelative = PathHelperMethods.GetRelativePath(value, this.RootPath);
            }
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

        [JsonIgnore]
        public ScriptManifest Manifest 
        {
            get { return _manifest; }
            set
            {
                this._manifest = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("Manifest"));
            }
        }
        private ScriptManifest _manifest;

        private void loadManifest()
        {
            if (this.ManifestPathRelative == String.Empty || this.RootPath == String.Empty)
                return;

            try
            {
                JsonFileHandler<ScriptManifest> handler = new JsonFileHandler<ScriptManifest>();
                this.Manifest = handler.Read(this.ManifestPathAbsolute);
            }
            catch { }
        }

        /// <summary>
        /// Reroutes all paths in the package to be relative to the new root path.
        /// </summary>
        /// <param name="newRootPath">The new path all others should be made relative to.</param>
        /// <param name="setRootPath">If true, the supplied new root path will be set as the root path of the package.</param>
        public void ReroutePaths(String newRootPath, Boolean setRootPath)
        {
            if (this.SourcePathRelative != String.Empty)
                this.SourcePathRelative = PathHelperMethods.GetRelativePath(this.SourcePathAbsolute, newRootPath);

            if (this.OutputPathRelative != String.Empty)
                this.OutputPathRelative = PathHelperMethods.GetRelativePath(this.OutputPathAbsolute, newRootPath);

            if (this.ManifestPathRelative != String.Empty)
                this.ManifestPathRelative = PathHelperMethods.GetRelativePath(this.ManifestPathAbsolute, newRootPath);

            if (setRootPath)
                this.RootPath = newRootPath;
        }
        

        [JsonProperty("installer_configuration")]
        public InstallerConfiguration InstallerConfiguration { get; set; }
        


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, e);
        }
    }
}
