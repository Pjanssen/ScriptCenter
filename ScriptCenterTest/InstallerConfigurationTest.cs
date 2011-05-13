using ScriptCenter.Installer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ScriptCenter.Repository;
using ScriptCenter.Installer.Actions;

namespace ScriptCenterTest
{
    /// <summary>
    ///This is a test class for InstallerConfigurationTest and is intended
    ///to contain all InstallerConfigurationTest Unit Tests
    ///</summary>
    [TestClass()]
    public class InstallerConfigurationTest
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

        private InstallerConfiguration config;
        [TestInitialize()]
        public void testInitialize()
        {
            this.config = new InstallerConfiguration();
            this.config.InstallerActions.Add(new CopyFileAction("testFile", ScriptCenter.AppPaths.Directory.Icons));
            this.config.InstallerActions.Add(new CopyDirAction("testDir/", ScriptCenter.AppPaths.Directory.Scripts));
            this.config.InstallerActions.Add(new AssignHotkeyAction(System.Windows.Forms.Keys.H | System.Windows.Forms.Keys.Control));
            this.config.InstallerActions.Add(new RunMaxscriptAction("test.ms"));
        }

        [TestMethod()]
        public void WriteTest()
        {
            LocalFileHandler<InstallerConfiguration> handler = new LocalFileHandler<InstallerConfiguration>();
            Assert.IsTrue(handler.Write(this.GetTestOutputDir() + "/installer.config.json", this.config));
        }

        [TestMethod()]
        public void ReadTest()
        {
            // Write installer config.
            this.WriteTest();

            // Read and compare manifest
            LocalFileHandler<InstallerConfiguration> handler = new LocalFileHandler<InstallerConfiguration>();
            InstallerConfiguration readConfig = handler.Read(this.GetTestOutputDir() + "/installer.config.json");
            Assert.IsNotNull(readConfig);
            Assert.AreEqual(config.InstallerActions.Count, readConfig.InstallerActions.Count);
            Assert.AreEqual(((CopyFileAction)config.InstallerActions[0]).Source, ((CopyFileAction)readConfig.InstallerActions[0]).Source);
            Assert.AreEqual(((CopyFileAction)config.InstallerActions[0]).Target, ((CopyFileAction)readConfig.InstallerActions[0]).Target);
            Assert.AreEqual(((CopyFileAction)config.InstallerActions[0]).UseScriptId, ((CopyFileAction)readConfig.InstallerActions[0]).UseScriptId);
            Assert.AreEqual(((CopyDirAction)config.InstallerActions[1]).Source, ((CopyDirAction)readConfig.InstallerActions[1]).Source);
            Assert.AreEqual(((CopyDirAction)config.InstallerActions[1]).Target, ((CopyDirAction)readConfig.InstallerActions[1]).Target);
            Assert.AreEqual(((CopyDirAction)config.InstallerActions[1]).UseScriptId, ((CopyDirAction)readConfig.InstallerActions[1]).UseScriptId);
            Assert.AreEqual(((AssignHotkeyAction)config.InstallerActions[2]).Keys, ((AssignHotkeyAction)readConfig.InstallerActions[2]).Keys);
            Assert.AreEqual(((RunMaxscriptAction)config.InstallerActions[3]).Source, ((RunMaxscriptAction)readConfig.InstallerActions[3]).Source);
            
        }
    }
}
