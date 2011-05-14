using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace ScriptCenter.Installer.Actions
{
    public class CreateToolbarAction : InstallerAction
    {
        /// <summary>
        /// The name of the toolbar to create.
        /// </summary>
        [JsonProperty("name")]
        public String Name { get; set; }



        /// <summary>
        /// Creates a new toolbar.
        /// </summary>
        public override bool Do(Installer installer)
        {
            CuiFile cui = new CuiFile(CuiFile.MaxGetActiveCuiFile());
            if (!cui.Read())
                return false;

            if (cui.AddToolbar(this.Name))
            {
                if (!cui.Write())
                    return false;
                else
                    cui.MaxLoadCuiFile();
            }

            return true;
        }

        /// <summary>
        /// Removes the created toolbar.
        /// </summary>
        public override bool Undo(Installer installer)
        {
            CuiFile cui = new CuiFile(CuiFile.MaxGetActiveCuiFile());
            if (!cui.Read())
                return false;

            if (cui.RemoveToolbar(this.Name))
            {
                if (!cui.Write())
                    return false;
                else
                    cui.MaxLoadCuiFile();
            }

            return true;
        }
    }
}
