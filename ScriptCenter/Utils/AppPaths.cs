﻿//  Copyright 2011 P.J. Janssen
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
    public abstract class AppPaths
    {
        public abstract IPath GetPath(Directory dir);

        public static AppPaths GetApplicationPaths()
        {
#if DEBUG
            return new AppPathsDebug();
#else
            return new ScriptCenter.Max.AppPaths3dsmax();
#endif
        }

        public enum Directory
        {
            Root,
            Scripts,
            StartupScripts,
            MacroScripts,
            Icons
        }
    }
}
