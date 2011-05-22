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
        private String getOutputDirectory()
        {
            return System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\ScriptCenterTest\\test_output\\";
        }

        private InstallerConfiguration config;
        [TestInitialize()]
        public void testInitialize()
        {
            this.config = new InstallerConfiguration();
            this.config.InstallerActions.Add(new CopyFileAction("testFile", ScriptCenter.AppPaths.Directory.Icons));
            this.config.InstallerActions.Add(new CopyDirAction("testDir/", ScriptCenter.AppPaths.Directory.Scripts));
            this.config.InstallerActions.Add(new AssignHotkeyAction(System.Windows.Forms.Keys.H | System.Windows.Forms.Keys.Control, "toggleOutliner", "Outliner"));
            this.config.InstallerActions.Add(new RunMaxscriptAction("test.ms"));
        }

        [TestMethod()]
        public void WriteTest()
        {
            LocalFileHandler<InstallerConfiguration> handler = new LocalFileHandler<InstallerConfiguration>();
            Assert.IsTrue(handler.Write(this.getOutputDirectory() + "/myscript" + InstallerConfiguration.DefaultExtension, this.config));
        }

        [TestMethod()]
        public void ReadTest()
        {
            // Write installer config.
            this.WriteTest();

            // Read and compare manifest
            LocalFileHandler<InstallerConfiguration> handler = new LocalFileHandler<InstallerConfiguration>();
            InstallerConfiguration readConfig = handler.Read(this.getOutputDirectory() + "/myscript" + InstallerConfiguration.DefaultExtension);
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
