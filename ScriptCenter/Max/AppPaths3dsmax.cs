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
using ScriptCenter.Utils;

namespace ScriptCenter.Max
{
    public class AppPaths3dsmax : AppPaths
    {
        public override string GetPath(AppPaths.Directory dir)
        {
            ManagedServices.PathSDK.DirectoryID dirId;
            switch (dir)
            {
                case Directory.Root :
                    dirId = ManagedServices.PathSDK.DirectoryID.MaxStart;
                    break;
                case Directory.Scripts :
                    dirId = ManagedServices.PathSDK.DirectoryID.UserScripts;
                    break;
                case Directory.StartupScripts :
                    dirId = ManagedServices.PathSDK.DirectoryID.UserStartupScripts;
                    break;
                case Directory.MacroScripts :
                    dirId = ManagedServices.PathSDK.DirectoryID.UserMacros;
                    break;
                case Directory.Icons :
                    dirId = ManagedServices.PathSDK.DirectoryID.UserIcons;
                    break;
                default :
                    dirId = ManagedServices.PathSDK.DirectoryID.Temp;
                    break;
            }

            return ManagedServices.PathSDK.GetDirectoryPath(dirId);
        }
    }
}
