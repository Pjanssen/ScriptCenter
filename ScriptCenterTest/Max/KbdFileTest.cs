using ScriptCenter.Package.InstallerActions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using ScriptCenter.Max;
using System.Windows.Forms;

namespace ScriptCenterTest.Max
{
    /// <summary>
    ///This is a test class for KeyboardActionsFileTest and is intended
    ///to contain all KeyboardActionsFileTest Unit Tests
    ///</summary>
    [TestClass()]
    public class KbdFileTest
    {
        String kbdFile = TestHelperMethods.GetTestFilesDirectory() + "ame-light.kbd";


        [TestMethod()]
        public void ReadTest()
        {
            KbdFile kbd = new KbdFile(kbdFile);
            Assert.IsTrue(kbd.Read());
        }

        [TestMethod]
        public void ReadNullTest()
        {
            KbdFile kbd = new KbdFile(null);
            Assert.IsFalse(kbd.Read());
        }

        [TestMethod]
        public void ReadNonExistingFileTest()
        {
            KbdFile kbd = new KbdFile(":asd?$#");
            Assert.IsFalse(kbd.Read());

            kbd = new KbdFile("C:/nonexistingFile.kbd");
            Assert.IsFalse(kbd.Read());
        }

        [TestMethod()]
        public void WriteTest()
        {
            KbdFile kbd = new KbdFile(kbdFile);
            Assert.IsTrue(kbd.Read());

            kbd.File = TestHelperMethods.GetOutputDirectory() + "test.kbd";
            Assert.IsTrue(kbd.Write());
            Assert.IsTrue(TestHelperMethods.CompareFiles(kbdFile, kbd.File));
        }

        [TestMethod()]
        public void RemoveActionTest()
        {
            KbdFile kbd = new KbdFile(kbdFile);
            Assert.IsTrue(kbd.Read());

            Assert.AreEqual(1, kbd.RemoveAction("toggleOutliner", "Outliner"));
            Assert.AreEqual(0, kbd.RemoveAction("toggleOutliner", "Outliner"));
        }

        [TestMethod]
        public void AddNewActionTest()
        {
            KbdFile kbd = new KbdFile(kbdFile);
            Assert.IsTrue(kbd.Read());

            String macroName = "test";
            String macroCategory = "TestCat";
            Keys keys = Keys.A;
            Assert.IsTrue(kbd.AddAction(macroName, macroCategory, keys, true));
            KeyboardAction action = kbd.Actions.Find(a => a.TableId == KbdFile.MacroTableId && a.Keys == keys && a.MacroName == macroName && a.MacroCategory == macroCategory);
            Assert.IsNotNull(action);
        }

        [TestMethod]
        public void AddExistingActionTest()
        {
            KbdFile kbd = new KbdFile(kbdFile);
            Assert.IsTrue(kbd.Read());

            String macroName = "test";
            String macroCategory = "TestCat";
            Keys keys = Keys.H;

            //Test adding exactly existing action.
            Assert.IsFalse(kbd.AddAction("toggleOutliner", "Outliner", Keys.H, true));

            //Test with replace=false.
            Assert.IsFalse(kbd.AddAction(macroName, macroCategory, keys, false));
            KeyboardAction action = kbd.Actions.Find(a => a.TableId == KbdFile.MacroTableId && a.Keys == keys && a.MacroName == macroName && a.MacroCategory == macroCategory);
            Assert.IsNull(action);

            //Test with replace=true.
            Assert.IsTrue(kbd.AddAction(macroName, macroCategory, keys, true));
            action = kbd.Actions.Find(a => a.TableId == KbdFile.MacroTableId && a.Keys == keys && a.MacroName == macroName && a.MacroCategory == macroCategory);
            Assert.IsNotNull(action);
        }
    }
}
