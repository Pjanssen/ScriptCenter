using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScriptCenter.Repository;

namespace ScriptCenterTest.Repository
{
    [TestClass]
    public class ScriptPackageTest
    {
        [TestMethod]
        public void RelativePathTest()
        {
            ScriptPackage package = new ScriptPackage("test_package");
            package.RootPath = "C:/code/test/";
            package.ManifestPathAbsolute = "C:/code/test/test.scmanif";
            Assert.AreEqual("test.scmanif", package.ManifestPathRelative);
            Assert.AreEqual("C:/code/test/test.scmanif", package.ManifestPathAbsolute);

            package.SourcePathAbsolute = "C:/code/test/source/";
            Assert.AreEqual("source/", package.SourcePathRelative);
            Assert.AreEqual("C:/code/test/source/", package.SourcePathAbsolute);

            package.OutputPathAbsolute = "C:/code/output/test.mzp";
            Assert.AreEqual("../output/test.mzp", package.OutputPathRelative);
            Assert.AreEqual("C:/code/output/test.mzp", package.OutputPathAbsolute);
        }

        [TestMethod]
        public void ManifestSetRootBeforeManifestPathTest()
        {
            ScriptPackage package = new ScriptPackage("test_package");
            package.RootPath = TestHelperMethods.GetTestFilesDirectory();
            package.ManifestPathAbsolute = TestHelperMethods.GetTestFilesDirectory() + "outliner" + ScriptManifest.DefaultExtension;
            Assert.IsNotNull(package.Manifest);
            Assert.AreEqual("Outliner", package.Manifest.Name);
        }

        /// <summary>
        /// Test what happens when the manifest path is set before the root path.
        /// This is a scenario that might occur when deserializing.
        /// </summary>
        [TestMethod]
        public void ManifestSetManifestPathBeforeRootTest()
        {
            ScriptPackage package = new ScriptPackage("test_package");
            package.ManifestPathAbsolute = TestHelperMethods.GetTestFilesDirectory() + "outliner" + ScriptManifest.DefaultExtension;
            package.RootPath = TestHelperMethods.GetTestFilesDirectory();
            Assert.IsNotNull(package.Manifest);
            Assert.AreEqual("Outliner", package.Manifest.Name);
        }

        [TestMethod]
        public void ReroutePathsTest()
        {
            ScriptPackage package = new ScriptPackage("test_package");
            package.RootPath = "C:/code/test/";
            package.ManifestPathAbsolute = "C:/code/test/test.scmanif";
            package.SourcePathAbsolute = "C:/code/source/";
            package.OutputPathAbsolute = "C:/code/test/output/";
            Assert.AreEqual("C:/code/test/", package.RootPath);
            Assert.AreEqual("test.scmanif", package.ManifestPathRelative);
            Assert.AreEqual("../source/", package.SourcePathRelative);
            Assert.AreEqual("output/", package.OutputPathRelative);

            package.ReroutePaths("C:/code/", true);
            Assert.AreEqual("C:/code/", package.RootPath);
            Assert.AreEqual("test/test.scmanif", package.ManifestPathRelative);
            Assert.AreEqual("source/", package.SourcePathRelative);
            Assert.AreEqual("test/output/", package.OutputPathRelative);

            package.ManifestPathRelative = "";
            Assert.AreEqual("", package.ManifestPathRelative, "Test empty manifest path");
            package.ReroutePaths("C:/code/test/", true);
            Assert.AreEqual("", package.ManifestPathRelative, "Test manifest path is still empty");
        }
    }
}
