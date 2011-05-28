using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ScriptCenterTest
{
    internal static class TestHelperMethods
    {
        public static String GetTestFilesDirectory()
        {
            return Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\ScriptCenterTest\\test_files\\";
        }

        public static String GetOnlineTestFilesDirectory()
        {
            return "http://script.threesixty.nl/scriptcenter/test_files/";
        }

        public static String GetOutputDirectory()
        {
            return Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\ScriptCenterTest\\test_output\\";
        }

        public static Boolean CompareFiles(String path1, String path2)
        {
            using (StreamReader r_orig = new StreamReader(path1), r_new = new StreamReader(path2))
            {
                while (!r_orig.EndOfStream)
                {
                    if (r_new.EndOfStream)
                        return false;

                    String origLine = r_orig.ReadLine();
                    if (origLine == String.Empty)
                        continue;

                    String newLine = r_new.ReadLine();
                    if (origLine != newLine)
                        return false;
                }
            }

            return true;
        }
    }

    internal class SimpleTestObject
    {
        public const String DefaultName = "test";
        public const Int32 DefaultId = 42;

        public String Name;
        public Int32 Id;
    }
}
