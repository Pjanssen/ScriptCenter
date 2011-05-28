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
            Assert.IsTrue(TestHelperMethods.CompareFiles(kbdFile, kbd.File));
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
