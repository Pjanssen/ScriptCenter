using ScriptCenter.Installer.Actions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ScriptCenterTest
{
    /// <summary>
    ///This is a test class for KeyboardActionsFileTest and is intended
    ///to contain all KeyboardActionsFileTest Unit Tests
    ///</summary>
    [TestClass()]
    public class KbdFileTest
    {
        private String getTestFilesDirectory()
        {
            return System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\ScriptCenterTest\\test_files\\";
        }
        private String getOutputDirectory()
        {
            return System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\ScriptCenterTest\\test_output\\";
        }

        /// <summary>
        ///A test for Read
        ///</summary>
        [TestMethod()]
        public void ReadTest()
        {
            String kbdFile = getTestFilesDirectory() + "ame-light.kbd";
            Assert.IsTrue(System.IO.File.Exists(kbdFile));
            KbdFile kbd = new KbdFile(kbdFile);
            Assert.IsTrue(kbd.Read());
        }

        [TestMethod()]
        public void WriteTest()
        {
            String kbdFile = getTestFilesDirectory() + "ame-light.kbd";
            Assert.IsTrue(System.IO.File.Exists(kbdFile));
            KbdFile kbd = new KbdFile(kbdFile);
            Assert.IsTrue(kbd.Read());

            kbd.File = getOutputDirectory() + "test.kbd";
            Assert.IsTrue(kbd.Write());

            Boolean compare_result = true;
            using (StreamReader r_orig = new StreamReader(kbdFile), r_new = new StreamReader(kbd.File))
            {
                while (!r_orig.EndOfStream)
                {
                    if (r_new.EndOfStream || !r_orig.ReadLine().Equals(r_new.ReadLine()))
                    {
                        compare_result = false;
                        break;
                    }
                }
            }

            Assert.IsTrue(compare_result);
        }
    }
}
