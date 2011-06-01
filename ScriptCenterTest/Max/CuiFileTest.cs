using ScriptCenter.Installer.Actions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using ScriptCenter.Max;

namespace ScriptCenterTest.Max
{
    /// <summary>
    ///This is a test class for CuiFileTest and is intended
    ///to contain all CuiFileTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CuiFileTest
    {
        String cuiFile = TestHelperMethods.GetTestFilesDirectory() + "ame-light.cui";

        [TestMethod()]
        public void ReadTest()
        {
            CuiFile cui = new CuiFile(cuiFile);
            Assert.IsTrue(cui.Read());
        }

        [TestMethod]
        public void ReadIncorrectUriTest()
        {
            CuiFile cui = new CuiFile(null);
            Assert.IsFalse(cui.Read(), "Reading null file should return false");

            cui = new CuiFile(":asd$@!wrong");
            Assert.IsFalse(cui.Read(), "Reading incorrect uri should return false");

            cui = new CuiFile("C:/nonexistingfile.cui");
            Assert.IsFalse(cui.Read(), "Reading non-existing file should return false");
        }

        [TestMethod()]
        public void WriteTest()
        {
            CuiFile cui = new CuiFile(cuiFile);
            Assert.IsTrue(cui.Read());

            cui.File = TestHelperMethods.GetOutputDirectory() + "test.cui";
            Assert.IsTrue(cui.Write());

            Assert.IsTrue(TestHelperMethods.CompareFiles(cuiFile, cui.File));
        }


        [TestMethod]
        public void AddToolbarTest()
        {
            CuiFile cui = new CuiFile(cuiFile);
            Assert.IsTrue(cui.Read());

            Assert.IsFalse(cui.AddToolbar("Main Toolbar"));

            CuiSection cuiDataSection = cui.Sections.Find(s => s.Name == CuiFile.SectionCuiData);
            CuiItem windowCountItem = cuiDataSection.Items.Find(i => i.Key == CuiFile.KeyWindowCount);
            Int32 windowCount = Int32.Parse(windowCountItem.Value);

            Assert.IsTrue(cui.AddToolbar("Test Toolbar"));
            Assert.IsNotNull(cui.Sections.Find(s => s.Name == "Test Toolbar"));
            Assert.AreEqual(windowCount + 1, Int32.Parse(windowCountItem.Value));

            Assert.IsFalse(cui.AddToolbar("Test Toolbar"));
        }

        [TestMethod]
        public void RemoveToolbarTest()
        {
            CuiFile cui = new CuiFile(cuiFile);
            Assert.IsTrue(cui.Read());

            CuiSection cuiDataSection = cui.Sections.Find(s => s.Name == CuiFile.SectionCuiData);
            CuiItem windowCountItem = cuiDataSection.Items.Find(i => i.Key == CuiFile.KeyWindowCount);
            Int32 windowCount = Int32.Parse(windowCountItem.Value);

            Assert.IsTrue(cui.RemoveToolbar("Main Toolbar"));
            Assert.IsNull(cui.Sections.Find(s => s.Name == "Main Toolbar"));
            Assert.AreEqual(windowCount - 1, Int32.Parse(windowCountItem.Value));

            Assert.IsFalse(cui.RemoveToolbar("Main Toolbar"));
        }


        [TestMethod]
        public void AddRemoveToolbarButtonTest()
        {
            CuiFile cui = new CuiFile(cuiFile);
            Assert.IsTrue(cui.Read());

            String toolbarName = "Main Toolbar";
            String macroName = "toggleOutliner";
            String macroCategory = "Outliner";
            String itemText = "Toggle Outliner";

            CuiSection toolbarSection = cui.Sections.Find(s => s.Name == toolbarName);
            Assert.IsNotNull(toolbarSection);
            Int32 numItems = toolbarSection.Items.Count;

            //Try adding the button.
            Assert.IsTrue(cui.AddToolbarButton(toolbarName, macroName, macroCategory, itemText));
            Assert.AreEqual(numItems + 1, toolbarSection.Items.Count);
            
            //Try adding it again, should return false.
            Assert.IsFalse(cui.AddToolbarButton(toolbarName, macroName, macroCategory, itemText));
            Assert.AreEqual(numItems + 1, toolbarSection.Items.Count);

            //Try removing it.
            Assert.IsTrue(cui.RemoveItem(toolbarName, macroName, macroCategory));
            Assert.AreEqual(numItems, toolbarSection.Items.Count);

            //Try removing it again, should return false.
            Assert.IsFalse(cui.RemoveItem(toolbarName, macroName, macroCategory));
            Assert.AreEqual(numItems, toolbarSection.Items.Count);
        }

        [TestMethod]
        public void AddToolbarSeparatorTest()
        {
            CuiFile cui = new CuiFile(cuiFile);
            Assert.IsTrue(cui.Read());

            String toolbarName = "Main Toolbar";

            CuiSection toolbarSection = cui.Sections.Find(s => s.Name == toolbarName);
            Assert.IsNotNull(toolbarSection);
            Int32 numItems = toolbarSection.Items.Count;

            //Try adding the button.
            Assert.IsTrue(cui.AddToolbarSeparator(toolbarName));
            Assert.AreEqual(numItems + 1, toolbarSection.Items.Count);
        }
    }
}
