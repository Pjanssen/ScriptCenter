using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScriptCenter.Utils;

namespace ScriptCenterTest.Utils
{
    [TestClass]
    public class RelativePathTest
    {
        [TestMethod]
        public void ConstructFromRelativePathTest()
        {
            BasePath path = new BasePath("C:/code/");
            RelativePath relPath = new RelativePath("test/", path);
            Assert.AreEqual("test/", relPath.RelativePathComponent, "Relative path from constructor.");
            Assert.AreEqual(path, relPath.RelativeTo, "Relative to from constructor.");
        }

        [TestMethod]
        public void ConstructFromAbsolutePathTest()
        {
            BasePath path = new BasePath("C:/code/");
            RelativePath relPath = new RelativePath("C:/code/test/", path);
            Assert.AreEqual("test/", relPath.RelativePathComponent, "Relative path from constructor when supplying absolute path.");
        }

        [TestMethod]
        public void ConstructorIncorrectInputTest()
        {
            BasePath path = new BasePath("C:/code/");

            try
            {
                RelativePath relPath = new RelativePath(null, path);
                Assert.Fail("Passing null path to constructor should throw exception");
            }
            catch (ArgumentNullException e)
            {
                Assert.IsNotNull(e);
            }

            try
            {
                RelativePath relPath = new RelativePath("test/", null);
                Assert.Fail("Passing null relativeTo to constructor should throw exception");
            }
            catch (ArgumentNullException e)
            {
                Assert.IsNotNull(e);
            }

            BasePath filePath = new BasePath("C:/code/test.txt");
            Assert.IsTrue(filePath.IsFilePath);
            try
            {
                RelativePath relPath = new RelativePath("../folder/", filePath);
                Assert.Fail("Creating a path relative to a file should throw exception");
            }
            catch (ArgumentException e)
            {
                Assert.IsNotNull(e);
            }
        }

        [TestMethod]
        public void GetAbsolutePathTest()
        {
            BasePath path = new BasePath("C:/code/");
            RelativePath relPath = new RelativePath("test/", path);
            Assert.AreEqual("C:/code/test/", relPath.AbsolutePath, "Absolute path.");

            relPath = new RelativePath("../test/", path);
            Assert.AreEqual("C:/test/", relPath.AbsolutePath, "Absolute path 2.");
        }

        [TestMethod]
        public void ChainedPathTest()
        {
            BasePath path = new BasePath("C:/code/");
            RelativePath relPath = new RelativePath("test/", path);
            RelativePath relPath2 = new RelativePath("file.txt", relPath);
            Assert.AreEqual("C:/code/test/file.txt", relPath2.AbsolutePath, "Chained relative path.");
        }

        [TestMethod]
        public void SetAbsolutePathTest()
        {
            BasePath path = new BasePath("C:/code/");
            RelativePath relPath = new RelativePath("test/", path);
            Assert.AreEqual("C:/code/test/", relPath.AbsolutePath, "Initial path.");

            relPath.AbsolutePath = "C:/test/newPath/";
            Assert.AreEqual("C:/test/newPath/", relPath.AbsolutePath, "Changed path.");
            Assert.AreEqual("../test/newPath/", relPath.RelativePathComponent, "Changed relativePathComponent.");
        }

        [TestMethod]
        public void SetRelativeComponentTest()
        {
            BasePath path = new BasePath("C:/code/");
            RelativePath relPath = new RelativePath("test/", path);
            Assert.AreEqual("C:/code/test/", relPath.AbsolutePath, "Initial path.");

            relPath.RelativePathComponent = "newPath/test/";
            Assert.AreEqual("newPath/test/", relPath.RelativePathComponent, "Changed RelativePathComponent.");
            Assert.AreEqual("C:/code/newPath/test/", relPath.AbsolutePath, "Absolute path after changing RelativePathComponent.");

            try
            {
                relPath.RelativePathComponent = null;
                Assert.Fail("Setting RelativePathComponent to null should throw ArgumentNullException.");
            }
            catch (ArgumentNullException e)
            {
                Assert.IsNotNull(e);
            }
        }

        [TestMethod]
        public void SetRelativeToTest()
        {
            BasePath path = new BasePath("C:/code/");
            BasePath path2 = new BasePath("C:/path/");
            RelativePath relPath = new RelativePath("test/", path);
            Assert.AreEqual("C:/code/test/", relPath.AbsolutePath, "Initial path.");

            relPath.RelativeTo = path2;
            Assert.AreEqual("C:/path/test/", relPath.AbsolutePath, "Absolute path after changing RelativeTo.");

            try
            {
                relPath.RelativeTo = null;
                Assert.Fail("Setting RelativeTo to null should throw ArgumentNullException.");
            }
            catch (ArgumentNullException e)
            {
                Assert.IsNotNull(e);
            }
        }

        [TestMethod]
        public void PathComponentsTest()
        {
            BasePath root = new BasePath("C:/code/");
            RelativePath path = new RelativePath("test/", root);
            Assert.AreEqual(3, path.PathComponents.Count, "PathComponents count.");
            Assert.AreEqual("C:", path.PathComponents[0], "First PathComponent.");
            Assert.AreEqual("code", path.PathComponents[1], "Second PathComponent.");
            Assert.AreEqual("test", path.PathComponents[2], "Third PathComponent.");
        }
    }
}
