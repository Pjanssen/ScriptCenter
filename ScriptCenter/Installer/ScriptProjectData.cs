using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScriptCenter.Repository;
using Newtonsoft.Json;
using ScriptCenter.Installer.UI;
using System.ComponentModel;

namespace ScriptCenter.Installer
{
    public class ScriptProjectData : INotifyPropertyChanged
    {
        public const String DefaultExtension = ".scproj";

        public ScriptProjectData()
        {
            InstallerHelperMethods.SetDefaultValues(this);
            this.Manifest = new ScriptManifest();
            this.InstallerConfig = new InstallerConfiguration();
            this.UIConfig = new InstallerUIConfiguration();
        }

        private String rootPath;
        [JsonProperty("root_path")]
        public String RootPath 
        {
            get { return this.rootPath; }
            set
            {
                this.rootPath = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("RootPath"));
            }
        }

        private String exportTarget;
        [JsonProperty("export_target")]
        [DefaultValue("builds\\" + InstallerHelperMethods.Id_Token + "_" + InstallerHelperMethods.VersionMajor_Token + "_" + InstallerHelperMethods.VersionMinor_Token + "_" + InstallerHelperMethods.VersionRevision_Token + ".mzp")]
        public String ExportTarget
        {
            get { return this.exportTarget; }
            set
            {
                this.exportTarget = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("ExportLocation"));
            }
        }

        [JsonProperty("exclude")]
        [DefaultValue(@"builds\; *.scproj; ._*; Thumbs.db; .DS_Store")]
        public String ExcludeFiles { get; set; }

        [JsonProperty("manifest")]
        public ScriptManifest Manifest { get; set; }

        [JsonProperty("installer_configuration")]
        public InstallerConfiguration InstallerConfig { get; set; }

        [JsonProperty("installer_ui_configuration")]
        public InstallerUIConfiguration UIConfig { get; set; }

        private String icon16;
        [JsonProperty("icon_16")]
        public String Icon16
        {
            get { return this.icon16; }
            set
            {
                this.icon16 = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("Icon16"));
            }
        }

        private String icon32;
        [JsonProperty("icon_32")]
        public String Icon32
        {
            get { return this.icon32; }
            set
            {
                this.icon32 = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("Icon32"));
            }
        }

        private String icon64;
        [JsonProperty("icon_64")]
        public String Icon64
        {
            get { return this.icon64; }
            set
            {
                this.icon64 = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("Icon64"));
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, e);
        }

        #endregion
    }
}
