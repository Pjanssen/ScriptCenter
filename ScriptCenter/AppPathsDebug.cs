using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScriptCenter
{
    public class AppPathsDebug : AppPaths
    {
        public override string GetPath(AppPaths.Directory dir)
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
                case Directory.Macros:
                    path = "C:/temp/scriptcenter/install_test/macros";
                    break;
                case Directory.Icons:
                    path = "C:/temp/scriptcenter/install_test/icons";
                    break;
                default:
                    path = "C:/temp/scriptcenter/install_test";
                    break;
            }

            return path;
        }
    }
}
