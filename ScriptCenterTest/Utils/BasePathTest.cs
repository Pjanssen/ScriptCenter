using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScriptCenter.Utils;

namespace ScriptCenterTest.Utils
{
    [TestClass]
    public class BasePathTest
    {
        [TestMethod]
        public void BasePathConstructorTest()
        {
            BasePath path = new BasePath("C:/code/test/");
            Assert.AreEqual("C:/code/test/", path.AbsolutePath, "Path set by the constructor");

            try
            {
                path = new BasePath(null);
                Assert.Fail("Passing null to constructor should throw exception");
            }
            catch (ArgumentNullException e)
            {
                Assert.IsNotNull(e);
            }
        }

        [TestMethod]
        public void BasePathSetPathTest()
        {
            BasePath path = new BasePath("C:/code/test/");
            Assert.AreEqual("C:/code/test/", path.AbsolutePath, "Path set by the constructor");

            path.AbsolutePath = "C:/test/";
            Assert.AreEqual("C:/test/", path.AbsolutePath, "Change path.");

            try
            {
                path.AbsolutePath = null;
                Assert.Fail("Setting Path to null should throw ArgumentNullException.");
            }
            catch (ArgumentNullException e)
            {
                Assert.IsNotNull(e);
            }
        }

        [TestMethod]
        public void PathComponentsTest()
        {
            BasePath path = new BasePath("C:/code/test/");
            Assert.AreEqual(3, path.PathComponents.Count, "PathComponents count");
            Assert.AreEqual("C:", path.PathComponents[0], "First path component");
            Assert.AreEqual("code", path.PathComponents[1], "Second path component");
            Assert.AreEqual("test", path.PathComponents[2], "Third path component");
        }

        [TestMethod]
        public void IsFilePathTest()
        {
            BasePath path = new BasePath("C:/code/test/");
            Assert.IsFalse(path.IsFilePath, "Directory path IsFilePath");
            Assert.IsTrue(path.IsDirectoryPath, "Directory path IsDirectoryPath");

            path = new BasePath("C:/code/test/test.txt");
            Assert.IsTrue(path.IsFilePath, "File path IsFilePath");
            Assert.IsFalse(path.IsDirectoryPath, "File path IsDirectoryPath");
        }
    }
}
