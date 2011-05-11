using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScriptCenter
{
    public abstract class AppPaths
    {
        public abstract String GetPath(Directory dir);

        public static AppPaths GetApplicationPaths()
        {
            return new AppPathsDebug();
            //return new AppPaths3dsmax();
        }

        public enum Directory
        {
            Root,
            Scripts,
            StartupScripts,
            Macros,
            Icons
        }
    }
}
