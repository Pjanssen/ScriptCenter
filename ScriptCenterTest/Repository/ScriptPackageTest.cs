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
            package.RootPath.Path = "C:/code/test/";
            package.OutputPath.Path = "C:/code/test/test.mzp";
            Assert.AreEqual("test.mzp", package.OutputPath.RelativePathComponent);
            Assert.AreEqual("C:/code/test/test.mzp", package.OutputPath.Path);
            
            package.SourcePath.Path = "C:/code/test/source/";
            Assert.AreEqual("source/", package.SourcePath.RelativePathComponent);
            Assert.AreEqual("C:/code/test/source/", package.SourcePath.Path);

            package.OutputPath.Path = "C:/code/output/";
            Assert.AreEqual("../output/", package.OutputPath.RelativePathComponent);
            Assert.AreEqual("C:/code/output/", package.OutputPath.Path);

            package.PackageFile.Path = "C:/code/output/test.mzp";
            Assert.AreEqual("test.mzp", package.PackageFile.RelativePathComponent);
            Assert.AreEqual("C:/code/output/test.mzp", package.PackageFile.Path);
        }
    }
}
