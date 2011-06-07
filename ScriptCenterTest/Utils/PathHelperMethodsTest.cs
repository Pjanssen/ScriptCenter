using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScriptCenter.Utils;

namespace ScriptCenterTest.Utils
{
    [TestClass]
    public class PathHelperMethodsTest
    {
        [TestMethod]
        public void IsAbsolutePathTest()
        {
            //Feed it some proper data.
            Assert.IsTrue(PathHelperMethods.IsAbsolutePath("C:"), "Absolute 1");
            Assert.IsTrue(PathHelperMethods.IsAbsolutePath("C:/"), "Absolute 2");
            Assert.IsTrue(PathHelperMethods.IsAbsolutePath("C:/test/"), "Absolute 3");
            Assert.IsTrue(PathHelperMethods.IsAbsolutePath("C:\\test\\"), "Absolute 4");
            Assert.IsTrue(PathHelperMethods.IsAbsolutePath("http://www.test.nl/"), "Absolute 5");
            Assert.IsFalse(PathHelperMethods.IsAbsolutePath("/"), "Relative 1");
            Assert.IsFalse(PathHelperMethods.IsAbsolutePath("/code.cpp"), "Relative 2");
            Assert.IsFalse(PathHelperMethods.IsAbsolutePath("code.cpp"), "Relative 3");
            Assert.IsFalse(PathHelperMethods.IsAbsolutePath("/test/code.cpp"), "Relative 4");
            Assert.IsFalse(PathHelperMethods.IsAbsolutePath("test/code.cpp"), "Relative 5");

            //Feed it some rubbish.
            Assert.IsFalse(PathHelperMethods.IsAbsolutePath(null), "Rubbish 1");
            Assert.IsFalse(PathHelperMethods.IsAbsolutePath(""), "Rubbish 2");
            Assert.IsFalse(PathHelperMethods.IsAbsolutePath("   "), "Rubbish 3");
        }

        [TestMethod]
        public void IsFilePathTest()
        {
            Assert.IsFalse(PathHelperMethods.IsFilePath("C:/"), "Path 1");
            Assert.IsFalse(PathHelperMethods.IsFilePath("C:/test/"), "Path 2");
            Assert.IsFalse(PathHelperMethods.IsFilePath("test/relative/path/"), "Path 3");
            Assert.IsTrue(PathHelperMethods.IsFilePath("C:/test.txt"), "File 1");
            Assert.IsTrue(PathHelperMethods.IsFilePath("/test.txt"), "File 2");
            Assert.IsTrue(PathHelperMethods.IsFilePath("C:/test"), "File 3");
            Assert.IsFalse(PathHelperMethods.IsFilePath(""), "Rubbish 1");
            Assert.IsFalse(PathHelperMethods.IsFilePath(null), "Rubbish 2");
            Assert.IsFalse(PathHelperMethods.IsFilePath("  "), "Rubbish 3");
        }


        [TestMethod]
        public void GetAbsolutePathTest()
        {
            //TODO test identical paths.
            String basePath = "C:/test/";
            String relPath = "";
            Assert.AreEqual("C:/test/", PathHelperMethods.GetAbsolutePath(relPath, basePath), "Test1");

            basePath = "C:/test/";
            relPath = "/";
            Assert.AreEqual("C:/test/", PathHelperMethods.GetAbsolutePath(relPath, basePath), "Test2");

            basePath = "C:/test/";
            relPath = "/source.txt";
            Assert.AreEqual("C:/test/source.txt", PathHelperMethods.GetAbsolutePath(relPath, basePath), "Test3");

            basePath = "C:/test/";
            relPath = "../source";
            Assert.AreEqual("C:/source", PathHelperMethods.GetAbsolutePath(relPath, basePath), "Test4");

            basePath = "C:/code/test/script/";
            relPath = "../../../henk.txt";
            Assert.AreEqual("C:/henk.txt", PathHelperMethods.GetAbsolutePath(relPath, basePath), "Test5");
            
            basePath = "C:/test/";
            relPath = "D:/test/";
            Assert.AreEqual("D:/test/", PathHelperMethods.GetAbsolutePath(relPath, basePath), "Test6");

            basePath = "http://www.test.nl/";
            relPath = "test/code.txt";
            Assert.AreEqual("http://www.test.nl/test/code.txt", PathHelperMethods.GetAbsolutePath(relPath, basePath), "Test7");

            basePath = "file://C:/code/";
            relPath = "test/code.txt";
            Assert.AreEqual("file://C:/code/test/code.txt", PathHelperMethods.GetAbsolutePath(relPath, basePath), "Test8");
        }

        [TestMethod]
        public void GetRelativePathTest()
        {
            //TODO test identical paths.

            String basePath = "C:/";
            String convertPath = "C:/test/";
            Assert.AreEqual("test/", PathHelperMethods.GetRelativePath(convertPath, basePath), "Test1");

            basePath = "C:";
            convertPath = "C:/test/";
            Assert.AreEqual("/test/", PathHelperMethods.GetRelativePath(convertPath, basePath), "Test2");

            basePath = "C:/test/";
            convertPath = "C:/test/very/very/long/never/ending/path/code/";
            Assert.AreEqual("very/very/long/never/ending/path/code/", PathHelperMethods.GetRelativePath(convertPath, basePath), "Test3");

            basePath = "C:/test/";
            convertPath = "C:/code/";
            Assert.AreEqual("../code/", PathHelperMethods.GetRelativePath(convertPath, basePath), "Test4");

            basePath = "C:/test/very/long/path/code/";
            convertPath = "C:/test/code/source/";
            Assert.AreEqual("../../../../code/source/", PathHelperMethods.GetRelativePath(convertPath, basePath), "Test5");

            basePath = "C:/test/";
            convertPath = "C:/test/";
            Assert.AreEqual("", PathHelperMethods.GetRelativePath(convertPath, basePath), "Test6");

            basePath = "C:/test/";
            convertPath = "C:/code/file.txt";
            Assert.AreEqual("../code/file.txt", PathHelperMethods.GetRelativePath(convertPath, basePath), "Test7");

            basePath = "C:/test/";
            convertPath = "D:/code/file.txt";
            Assert.AreEqual("D:/code/file.txt", PathHelperMethods.GetRelativePath(convertPath, basePath), "Test8");
        }
    }
}
