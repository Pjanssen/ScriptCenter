using ScriptCenter.Installer.Actions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using ScriptCenter.Max;

namespace ScriptCenterTest
{
    /// <summary>
    ///This is a test class for KeyboardActionsFileTest and is intended
    ///to contain all KeyboardActionsFileTest Unit Tests
    ///</summary>
    [TestClass()]
    public class KbdFileTest
    {
        [TestMethod()]
        public void ReadTest()
        {
            String kbdFile = TestHelperMethods.GetTestFilesDirectory() + "ame-light.kbd";
            Assert.IsTrue(System.IO.File.Exists(kbdFile));
            KbdFile kbd = new KbdFile(kbdFile);
            Assert.IsTrue(kbd.Read());
        }

        [TestMethod()]
        public void WriteTest()
        {
            String kbdFile = TestHelperMethods.GetTestFilesDirectory() + "ame-light.kbd";
            Assert.IsTrue(System.IO.File.Exists(kbdFile));
            KbdFile kbd = new KbdFile(kbdFile);
            Assert.IsTrue(kbd.Read());

            kbd.File = TestHelperMethods.GetOutputDirectory() + "test.kbd";
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

        [TestMethod()]
        public void RemoveActionTest()
        {
            String kbdFile = TestHelperMethods.GetTestFilesDirectory() + "ame-light.kbd";
            Assert.IsTrue(System.IO.File.Exists(kbdFile));
            KbdFile kbd = new KbdFile(kbdFile);
            Assert.IsTrue(kbd.Read());

            Assert.AreEqual(1, kbd.RemoveAction("toggleOutliner", "Outliner"));
        }
    }
}
