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

namespace ScriptCenter.Utils
{
    public class AppPathsDebug : AppPaths
    {
        public override IPath GetPath(AppPaths.Directory dir)
        {
            String path;
            switch (dir)
            {
                case Directory.Root:
                    path = "C:/temp/scriptcenter/install_test";
                    break;
                case Directory.Scripts:
                    path = "C:/temp/scriptcenter/install_test/scripts";
                    break;
                case Directory.StartupScripts:
                    path = "C:/temp/scriptcenter/install_test/startup_scripts";
                    break;
                case Directory.MacroScripts:
                    path = "C:/temp/scriptcenter/install_test/macros";
                    break;
                case Directory.Icons:
                    path = "C:/temp/scriptcenter/install_test/icons";
                    break;
                default:
                    path = "C:/temp/scriptcenter/install_test";
                    break;
            }

            return new BasePath(path);
        }
    }
}
