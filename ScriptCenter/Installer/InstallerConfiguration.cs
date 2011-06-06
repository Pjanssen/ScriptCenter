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
using System.Xml.Serialization;
using System.ComponentModel;
using ScriptCenter.Repository;
using System.Windows.Forms;
using ScriptCenter.Installer.Actions;
using Newtonsoft.Json;

namespace ScriptCenter.Installer
{
    /// <summary>
    /// Container for installer actions.
    /// </summary>
    [XmlRoot("installer_configuration")]
    public class InstallerConfiguration
    {
        public const String DefaultExtension = ".scinstaller";

        public InstallerConfiguration()
        {
            this.installerActions = new List<InstallerAction>();
        }

        [JsonIgnore]
        public ScriptPackage Package { get; set; }


        [JsonProperty("manifest_uri")]
        public String ManifestUri { get; set; }

        private List<InstallerAction> _installerActions;
        [JsonProperty("installer_actions")]
        private List<InstallerAction> installerActions 
        {
            get { return _installerActions; }
            set
            {
                foreach (InstallerAction action in value)
                {
                    action.Configuration = this;
                }
                _installerActions = value;
            }
        }

        [JsonIgnore]
        public IList<InstallerAction> Actions
        {
            get
            {
                //Return a readonly IList to avoid addition outside of this class.
                return this.installerActions.AsReadOnly();
            }
        }

        /// <summary>
        /// Adds an installer action to the configuration.
        /// </summary>
        /// <param name="action">The action to add.</param>
        public void AddAction(InstallerAction action) 
        {
            if (this.installerActions.Contains(action))
                return;

            this.installerActions.Add(action);
            action.Configuration = this;
        }

        /// <summary>
        /// Removes an action from the configuration.
        /// </summary>
        /// <param name="action">The action to remove.</param>
        public void RemoveAction(InstallerAction action)
        {
            this.installerActions.Remove(action);
            action.Configuration = null;
        }

        /// <summary>
        /// Moves an action up or down in the installer action collection.
        /// </summary>
        /// <param name="action">The action to move.</param>
        /// <param name="direction">The direction to move the action in.</param>
        /// <returns>The new index of the moved action.</returns>
        public Int32 MoveAction(InstallerAction action, MoveActionDirection direction)
        {
            if (!this.installerActions.Contains(action))
                throw new ArgumentException("The action to move is not contained in the configuration.");

            Int32 index = this.installerActions.IndexOf(action);
            if (direction == MoveActionDirection.Up && index == 0)
                return index;
            if (direction == MoveActionDirection.Down && index == this.installerActions.Count - 1)
                return index;

            this.installerActions.Remove(action);

            Int32 newIndex = index;
            if (direction == MoveActionDirection.Up)
                newIndex = index - 1;
            else if (direction == MoveActionDirection.Down)
                newIndex = index + 1;

            this.installerActions.Insert(newIndex, action);
            return newIndex;
        }

        public enum MoveActionDirection
        {
            Up,
            Down
        }
    }
}
