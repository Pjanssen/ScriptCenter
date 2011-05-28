using ScriptCenter.Installer.Actions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using ScriptCenter.Max;

namespace ScriptCenterTest
{
    /// <summary>
    ///This is a test class for CuiFileTest and is intended
    ///to contain all CuiFileTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CuiFileTest
    {
        [TestMethod()]
        public void ReadTest()
        {
            String cuiFile = TestHelperMethods.GetTestFilesDirectory() + "MaxStartUI.cui";
            Assert.IsTrue(System.IO.File.Exists(cuiFile));
            CuiFile cui = new CuiFile(cuiFile);
            Assert.IsTrue(cui.Read());
        }

        [TestMethod()]
        public void WriteTest()
        {
            String cuiFile = TestHelperMethods.GetTestFilesDirectory() + "MaxStartUI.cui";
            Assert.IsTrue(System.IO.File.Exists(cuiFile));
            CuiFile cui = new CuiFile(cuiFile);
            Assert.IsTrue(cui.Read());

            cui.File = TestHelperMethods.GetOutputDirectory() + "test.cui";
            Assert.IsTrue(cui.Write());

            Assert.IsTrue(TestHelperMethods.CompareFiles(cuiFile, cui.File));
        }
    }
}
