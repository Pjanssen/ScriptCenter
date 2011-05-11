using ScriptCenter.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ScriptCenterTest
{
    
    
    /// <summary>
    ///This is a test class for LocalFileHandlerTest and is intended
    ///to contain all LocalFileHandlerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LocalFileHandlerTest
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

        private String GetTestOutputDir()
        {
            System.IO.FileInfo assemblyFile = new System.IO.FileInfo(System.Reflection.Assembly.GetCallingAssembly().Location);
            return assemblyFile.DirectoryName + "/test_output/";
        }

        private ScriptManifest manifest;

        [TestInitialize()]
        public void testInitialize()
        {
            this.manifest = new ScriptManifest();
            this.manifest.Id = "pier.janssen.outliner";
            this.manifest.Name = "Outliner";
            this.manifest.Info = new ScriptInfo();
            this.manifest.Info.Author = "Pier Janssen";
            this.manifest.Info.Description = "descr";
            this.manifest.Versions.Add(new ScriptVersion(2, 0, 96));
            this.manifest.Versions.Add(new ScriptVersion(2, 0, 95));
            this.manifest.Versions.Add(new ScriptVersion(2, 0, 94));
        }

        [TestMethod()]
        public void WriteTest()
        {
            LocalFileHandler<ScriptManifest> handler = new LocalFileHandler<ScriptManifest>();
            
            Assert.IsTrue(handler.Write(this.GetTestOutputDir() + "/outliner.manifest.json", this.manifest));
        }

        [TestMethod()]
        public void WriteToIncorrectPathTest()
        {
            LocalFileHandler<ScriptManifest> handler = new LocalFileHandler<ScriptManifest>();

            Assert.IsFalse(System.IO.Directory.Exists("R:/"), "Directory actually exists, try another one");
            Assert.IsFalse(handler.Write("R:/incorrect_path.json", this.manifest));
        }

        [TestMethod()]
        public void ReadTest()
        {
            // Write manifest.
            this.WriteTest();

            // Read and compare manifest
            LocalFileHandler<ScriptManifest> handler = new LocalFileHandler<ScriptManifest>();
            ScriptManifest readManifest = handler.Read(this.GetTestOutputDir() + "/outliner.manifest.json");
            Assert.IsNotNull(readManifest);
            Assert.AreEqual(this.manifest.Id, readManifest.Id);
            Assert.AreEqual(this.manifest.Name, readManifest.Name);
            Assert.IsNotNull(readManifest.Info);
            Assert.AreEqual(this.manifest.Info.Author, readManifest.Info.Author);
            Assert.AreEqual(this.manifest.Info.Description, readManifest.Info.Description);
            Assert.AreEqual(this.manifest.Versions.Count, readManifest.Versions.Count);
            Assert.AreEqual(this.manifest.Versions[0].Major, readManifest.Versions[0].Major);
            Assert.AreEqual(this.manifest.Versions[0].Minor, readManifest.Versions[0].Minor);
            Assert.AreEqual(this.manifest.Versions[0].Revision, readManifest.Versions[0].Revision);
        }

        [TestMethod()]
        public void ReadNonExistingFileTest()
        {
            LocalFileHandler<ScriptManifest> handler = new LocalFileHandler<ScriptManifest>();
            Assert.IsNull(handler.Read("R:/nonexistingfile.json"));
        }

        [TestMethod()]
        public void ReadIncorrectFileTest()
        {
            String file = this.GetTestOutputDir() + "incorrect_file.json";
            //Write syntactically incorrect file.
            System.IO.StreamWriter w = new System.IO.StreamWriter(file);
            w.Write("{\"incomplete fi..");
            w.Close();
            
            LocalFileHandler<ScriptManifest> handler = new LocalFileHandler<ScriptManifest>();
            Assert.IsNull(handler.Read(file));

            //Write syntactically correct file, but with nonsense data
            w = new System.IO.StreamWriter(file);
            w.Write("{\"asd\": 2 }");
            w.Close();

            ScriptManifest readManifest = handler.Read(file);
            Assert.IsNotNull(readManifest);
            Assert.AreEqual(String.Empty, readManifest.Id);
            Assert.AreEqual(String.Empty, readManifest.Name);
        }
    }
}
