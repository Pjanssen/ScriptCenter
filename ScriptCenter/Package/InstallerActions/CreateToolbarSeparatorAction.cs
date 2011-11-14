//  Copyright 2011 P.J. Janssen
//  This file is part of ScriptCenter.

//  ScriptCenter is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.

//  ScriptCenter is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.

//  You should have received a copy of the GNU General Public License
//  along with ScriptCenter.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Xml.Serialization;
using ScriptCenter.Max;
using System.ComponentModel;

namespace ScriptCenter.Package.InstallerActions
{
    /// <summary>
    /// Creates an item on a toolbar.
    /// </summary>
    public class CreateToolbarSeparatorAction : InstallerAction
    {
        public CreateToolbarSeparatorAction() : this("") { }
        public CreateToolbarSeparatorAction(String name)
        {
            this.ToolbarName = name;
        }

        /// <summary>
        /// The name of the toolbar to add the item to.
        /// </summary>
        [JsonProperty("toolbar_name")]
        [Category("1. Action Properties")]
        [DisplayName("Toolbar Name")]
        [Description("The name of the toolbar to add the separator to.")]
        [TypeConverter(typeof(ToolbarNameConverter))]
        public String ToolbarName { get; set; }


        /// <summary>
        /// Creates a separator on the toolbar.
        /// </summary>
        public override bool Do(Installer installer)
        {
           //TODO: save config before reading (to catch modifications made in current session).
            CuiFile cui = new CuiFile(CuiFile.MaxGetActiveCuiFile());
            if (!cui.Read())
                return false;

            CuiToolbar toolbar = cui.GetToolbar(this.ToolbarName);
            if (toolbar != null)
            {
               toolbar.AddSeparator();
               if (cui.Write())
                  cui.MaxLoadCuiFile();  //TODO: Find way to not have to hard-reload for every action. (Post-install event?)
               else
                  return false;
            }

            return true;
        }

        /// <summary>
        /// This action cannot be undone.
        /// </summary>
        public override bool Undo(Installer installer)
        {
            return true;
        }

        public override void PackResources(Ionic.Zip.ZipFile zip, String archiveTargetPath, ScriptCenter.Utils.IPath sourcePath) 
        {
            //No resources to pack for this action.
        }

        public override string ActionName { get { return "Create Toolbar Separator"; } }
        public override string ActionImageKey { get { return "toolbar_separator"; } }
        public override string ActionDetails { get { return this.ToolbarName; } }

        [DefaultValue(true)]
        [Description("When set to true this action will be performed when installing the script. \r\nNote: this action cannot be undone.")]
        public override bool RunAtInstall
        {
            get { return base.RunAtInstall; }
            set { base.RunAtInstall = value; }
        }

        [DefaultValue(false)]
        [Browsable(false)]
        public override bool RunAtUpdate
        {
            get { return false; }
            set
            {
                if (value != false)
                    throw new NotSupportedException("The Create Toolbar Separator action cannot be undone.");
            }
        }

        [DefaultValue(false)]
        [Browsable(false)]
        public override bool RunAtUninstall
        {
            get { return false; }
            set
            {
                if (value != false)
                    throw new NotSupportedException("The Create Toolbar Separator action cannot be undone.");
            }
        }
    }
}
