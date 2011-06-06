using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ScriptCenter.Repository
{
    public static class ScriptPacker
    {
        public static void Pack(ScriptPackage package)
        {
            //Create temp directory.
            String tempPath = Path.GetTempPath() + "ScriptCenter\\";
            if (!Directory.Exists(tempPath))
                Directory.CreateDirectory(tempPath);


        }
    }
}
