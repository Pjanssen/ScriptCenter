using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScriptCenter.Package;

namespace ScriptCenterTest.Package
{
    [TestClass]
    public class ScriptPackageTest
    {
        [TestMethod]
        public void RelativePathTest()
        {
            ScriptPackage package = new ScriptPackage("test_package");
            package.RootPath.AbsolutePath = "C:/code/test/";
            package.OutputPath.AbsolutePath = "C:/code/test/test.mzp";
            Assert.AreEqual("test.mzp", package.OutputPath.RelativePathComponent);
            Assert.AreEqual("C:/code/test/test.mzp", package.OutputPath.AbsolutePath);
            
            package.SourcePath.AbsolutePath = "C:/code/test/source/";
            Assert.AreEqual("source/", package.SourcePath.RelativePathComponent);
            Assert.AreEqual("C:/code/test/source/", package.SourcePath.AbsolutePath);

            package.OutputPath.AbsolutePath = "C:/code/output/";
            Assert.AreEqual("../output/", package.OutputPath.RelativePathComponent);
            Assert.AreEqual("C:/code/output/", package.OutputPath.AbsolutePath);

            package.PackageFile.AbsolutePath = "C:/code/output/test.mzp";
            Assert.AreEqual("test.mzp", package.PackageFile.RelativePathComponent);
            Assert.AreEqual("C:/code/output/test.mzp", package.PackageFile.AbsolutePath);
        }
    }
}
