﻿using ScriptCenter.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ScriptCenter.Utils;

namespace ScriptCenterTest.Repository
{
    /// <summary>
    ///This is a test class for ScriptRepositoryListTest and is intended
    ///to contain all ScriptRepositoryListTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ScriptRepositoryListTest
    {
        private String getOutputDirectory()
        {
            return System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\ScriptCenterTest\\test_output\\";
        }

        private ScriptRepositoryList repoList;

        [TestInitialize()]
        public void testInit()
        {
            this.repoList = new ScriptRepositoryList();
            this.repoList.Repositories.Add(new ScriptRepositoryReference("Pier's Scripts", "http://script.threesixty.nl/"));
            this.repoList.Repositories.Add(new ScriptRepositoryReference("ScriptSpot", "http://www.scriptspot.com"));
        }

        [TestMethod()]
        public void WriteRepositoryListTest()
        {
            JsonFileHandler<ScriptRepositoryList> handler = new JsonFileHandler<ScriptRepositoryList>();
            IPath path = new BasePath(this.getOutputDirectory() + "repositoryList.json");
            try
            {
                handler.Write(path, this.repoList);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod()]
        public void ReadRepositoryListTest()
        {
            this.WriteRepositoryListTest();

            JsonFileHandler<ScriptRepositoryList> handler = new JsonFileHandler<ScriptRepositoryList>();
            IPath path = new BasePath(TestHelperMethods.GetOutputDirectory() + "repositoryList.json");
            ScriptRepositoryList readList = handler.Read(path);
            Assert.IsNotNull(readList);
            Assert.IsNotNull(readList.Repositories);
            Assert.AreEqual(this.repoList.Repositories.Count, readList.Repositories.Count);
            Assert.AreEqual(this.repoList.Repositories[0].Name, readList.Repositories[0].Name);
            Assert.AreEqual(this.repoList.Repositories[0].URI, readList.Repositories[0].URI);
        }
    }
}
