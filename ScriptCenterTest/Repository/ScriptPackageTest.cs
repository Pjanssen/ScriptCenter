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
            package.OutputPathAbsolute = "C:/code/test/test.mzp";
            Assert.AreEqual("test.mzp", package.OutputPathRelative);
            Assert.AreEqual("C:/code/test/test.mzp", package.OutputPathAbsolute);

            package.SourcePathAbsolute = "C:/code/test/source/";
            Assert.AreEqual("source/", package.SourcePathRelative);
            Assert.AreEqual("C:/code/test/source/", package.SourcePathAbsolute);

            package.OutputPathAbsolute = "C:/code/output/";
            Assert.AreEqual("../output/", package.OutputPathRelative);
            Assert.AreEqual("C:/code/output/", package.OutputPathAbsolute);

            package.OutputFileAbsolute = "C:/code/output/test.mzp";
            Assert.AreEqual("test.mzp", package.OutputFileRelative);
            Assert.AreEqual("C:/code/output/test.mzp", package.OutputFileAbsolute);
        }


        [TestMethod]
        public void ReroutePathsTest()
        {
            ScriptPackage package = new ScriptPackage("test_package");
            package.RootPath = "C:/code/test/";
            package.SourcePathAbsolute = "C:/code/source/";
            package.OutputPathAbsolute = "C:/code/test/output/";
            Assert.AreEqual("C:/code/test/", package.RootPath);
            Assert.AreEqual("../source/", package.SourcePathRelative);
            Assert.AreEqual("output/", package.OutputPathRelative);

            package.ReroutePaths("C:/code/", true);
            Assert.AreEqual("C:/code/", package.RootPath);
            Assert.AreEqual("source/", package.SourcePathRelative);
            Assert.AreEqual("test/output/", package.OutputPathRelative);

            package.SourcePathRelative = "";
            Assert.AreEqual("", package.SourcePathRelative, "Test empty source path");
            package.ReroutePaths("C:/code/test/", true);
            Assert.AreEqual("", package.SourcePathRelative, "Test source path is still empty");
        }
    }
}
