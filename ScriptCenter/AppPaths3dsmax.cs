using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScriptCenter
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
                case Directory.Macros :
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
