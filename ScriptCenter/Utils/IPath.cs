using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScriptCenter.Utils
{
    public interface IPath
    {
        String AbsolutePath { get; set; }
        IList<String> PathComponents { get; }

        Boolean IsFilePath { get; }
        Boolean IsDirectoryPath { get; }

        IPath Combine(String path);
        Uri ToUri();
    }
}
