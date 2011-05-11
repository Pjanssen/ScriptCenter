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


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        private String getTestOutputDir()
        {
            System.IO.FileInfo assemblyFile = new System.IO.FileInfo(System.Reflection.Assembly.GetCallingAssembly().Location);
            return assemblyFile.DirectoryName + "/test_output/";
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
            LocalFileHandler<ScriptRepositoryList> handler = new LocalFileHandler<ScriptRepositoryList>();
            Assert.IsTrue(handler.Write(this.getTestOutputDir() + "repositoryList.json", this.repoList));
        }

        [TestMethod()]
        public void ReadRepositoryListTest()
        {
            this.WriteRepositoryListTest();

            LocalFileHandler<ScriptRepositoryList> handler = new LocalFileHandler<ScriptRepositoryList>();
            ScriptRepositoryList readList = handler.Read(this.getTestOutputDir() + "repositoryList.json");
            Assert.IsNotNull(readList);
            Assert.IsNotNull(readList.Repositories);
            Assert.AreEqual(this.repoList.Repositories.Count, readList.Repositories.Count);
            Assert.AreEqual(this.repoList.Repositories[0].Name, readList.Repositories[0].Name);
            Assert.AreEqual(this.repoList.Repositories[0].URI, readList.Repositories[0].URI);
        }
    }
}
