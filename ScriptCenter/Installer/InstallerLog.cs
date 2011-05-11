using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ScriptCenter.Installer
{
    public class InstallerLog
    {
        private String logFile;
        public InstallerLog(String file)
        {
            logFile = file;
        }

        public void Clear()
        {
            try
            {
                File.Create(logFile);
            }
            catch { }
        }

        public void Append(String message)
        {
            try
            {
                File.AppendAllText(logFile, String.Format(("{0} | {1}" + Environment.NewLine), DateTime.Now, message));
            }
            catch { }
        }

        public void Append(String message, Int32 numBlankLines)
        {
            try
            {
                String lines = "";
                for (int i = 0; i < numBlankLines; i++)
                    lines += Environment.NewLine;

                File.AppendAllText(logFile, lines);
            }
            catch { }

            this.Append(message);
        }
    }
}
