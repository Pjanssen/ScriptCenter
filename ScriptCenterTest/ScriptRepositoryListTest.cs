using ScriptCenter.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ScriptCenterTest
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
            FileHandler<ScriptRepositoryList> handler = new FileHandler<ScriptRepositoryList>();
            try
            {
                handler.Write(this.getOutputDirectory() + "repositoryList.json", this.repoList);
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

            FileHandler<ScriptRepositoryList> handler = new FileHandler<ScriptRepositoryList>();
            ScriptRepositoryList readList = handler.Read(this.getOutputDirectory() + "repositoryList.json");
            Assert.IsNotNull(readList);
            Assert.IsNotNull(readList.Repositories);
            Assert.AreEqual(this.repoList.Repositories.Count, readList.Repositories.Count);
            Assert.AreEqual(this.repoList.Repositories[0].Name, readList.Repositories[0].Name);
            Assert.AreEqual(this.repoList.Repositories[0].URI, readList.Repositories[0].URI);
        }
    }
}
