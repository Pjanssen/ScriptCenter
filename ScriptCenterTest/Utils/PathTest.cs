using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScriptCenter.Utils;

namespace ScriptCenterTest.Utils
{
    [TestClass]
    public class PathTest
    {
        [TestMethod]
        public void BasePathConstructorTest()
        {
            BasePath path = new BasePath("C:/code/test/");
            Assert.AreEqual("C:/code/test/", path.Path, "Path set by the constructor");

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
            Assert.AreEqual("C:/code/test/", path.Path, "Path set by the constructor");

            path.Path = "C:/test/";
            Assert.AreEqual("C:/test/", path.Path, "Change path.");

            try
            {
                path.Path = null;
                Assert.Fail("Setting Path to null should throw ArgumentNullException.");
            }
            catch (ArgumentNullException e)
            {
                Assert.IsNotNull(e);
            }
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

        [TestMethod]
        public void RelativePathConstructorTest()
        {
            BasePath path = new BasePath("C:/code/");
            RelativePath relPath = new RelativePath("test/", path);
            Assert.AreEqual("test/", relPath.RelativePathComponent, "Relative path from constructor.");
            Assert.AreEqual(path, relPath.RelativeTo, "Relative to from constructor.");

            try
            {
                relPath = new RelativePath(null, path);
                Assert.Fail("Passing null path to constructor should throw exception");
            }
            catch (ArgumentNullException e)
            {
                Assert.IsNotNull(e);
            }

            try
            {
                relPath = new RelativePath("test/", null);
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
                relPath = new RelativePath("../folder/", filePath);
                Assert.Fail("Creating a path relative to a file should throw exception");
            }
            catch (ArgumentException e)
            {
                Assert.IsNotNull(e);
            }
        }

        [TestMethod]
        public void RelativePathGetPathTest()
        {
            BasePath path = new BasePath("C:/code/");
            RelativePath relPath = new RelativePath("test/", path);
            Assert.AreEqual("C:/code/test/", relPath.Path, "Absolute path.");

            relPath = new RelativePath("../test/", path);
            Assert.AreEqual("C:/test/", relPath.Path, "Absolute path 2.");
        }

        [TestMethod]
        public void RelativePathChainedPathTest()
        {
            BasePath path = new BasePath("C:/code/");
            RelativePath relPath = new RelativePath("test/", path);
            RelativePath relPath2 = new RelativePath("file.txt", relPath);
            Assert.AreEqual("C:/code/test/file.txt", relPath2.Path, "Chained relative path.");
        }

        [TestMethod]
        public void RelativePathSetPathTest()
        {
            BasePath path = new BasePath("C:/code/");
            RelativePath relPath = new RelativePath("test/", path);
            Assert.AreEqual("C:/code/test/", relPath.Path, "Initial path.");

            relPath.Path = "C:/test/newPath/";
            Assert.AreEqual("C:/test/newPath/", relPath.Path, "Changed path.");
            Assert.AreEqual("../test/newPath/", relPath.RelativePathComponent, "Changed relativePathComponent.");
        }

        [TestMethod]
        public void RelativePathSetRelativeComponentTest()
        {
            BasePath path = new BasePath("C:/code/");
            RelativePath relPath = new RelativePath("test/", path);
            Assert.AreEqual("C:/code/test/", relPath.Path, "Initial path.");

            relPath.RelativePathComponent = "newPath/test/";
            Assert.AreEqual("newPath/test/", relPath.RelativePathComponent, "Changed RelativePathComponent.");
            Assert.AreEqual("C:/code/newPath/test/", relPath.Path, "Absolute path after changing RelativePathComponent.");

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
        public void RelativePathSetRelativeToTest()
        {
            BasePath path = new BasePath("C:/code/");
            BasePath path2 = new BasePath("C:/path/");
            RelativePath relPath = new RelativePath("test/", path);
            Assert.AreEqual("C:/code/test/", relPath.Path, "Initial path.");

            relPath.RelativeTo = path2;
            Assert.AreEqual("C:/path/test/", relPath.Path, "Absolute path after changing RelativeTo.");

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
    }
}
