using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScriptCenter.Repository;
using ScriptCenter.Utils;

namespace ScriptCenter
{
    public class ScriptCenterCore
    {
        //RegisterScript
        //IsRegisteredScript
        //CheckForUpdates
        //PackInstalledScripts

        private ScriptRepository _installedScriptsRepository;
        private IPath _installedScriptsRepositoryPath;

        public ScriptCenterCore()
        {
            _installedScriptsRepository = new ScriptRepository("installed_scripts");
        }

        public ScriptRepository InstalledScriptsRepository
        {
            get { return _installedScriptsRepository; }
        }

        public IPath InstalledScriptsRepositoryPath
        {
            get { return _installedScriptsRepositoryPath; }
            set { _installedScriptsRepositoryPath = value; }
        }

        public void RegisterScript(ScriptManifest m)
        {
            throw new NotImplementedException();
        }
    }
}
