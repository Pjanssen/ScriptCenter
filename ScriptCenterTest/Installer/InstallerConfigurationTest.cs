using ScriptCenter.Package;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ScriptCenter.Repository;
using ScriptCenter.Package.InstallerActions;
using System.Collections.Generic;
using ScriptCenter.Utils;

namespace ScriptCenterTest.Installer
{
    /// <summary>
    ///This is a test class for InstallerConfigurationTest and is intended
    ///to contain all InstallerConfigurationTest Unit Tests
    ///</summary>
    [TestClass()]
    public class InstallerConfigurationTest
    {
        private InstallerConfiguration config;
        [TestInitialize()]
        public void testInitialize()
        {
            this.config = new InstallerConfiguration();
            this.config.AddAction(new CopyFileAction("testFile", AppPaths.Directory.Icons));
            this.config.AddAction(new CopyDirAction("testDir/", AppPaths.Directory.Scripts));
            this.config.AddAction(new AssignHotkeyAction(System.Windows.Forms.Keys.H | System.Windows.Forms.Keys.Control, "toggleOutliner", "Outliner"));
            this.config.AddAction(new RunMaxscriptAction("test.ms"));
        }

        [TestMethod()]
        public void ActionsIsReadOnlyPropertyTest()
        {
            IList<InstallerAction> actions = config.Actions;
            Assert.AreEqual(4, actions.Count);
            try
            {
                actions.Add(new CopyFileAction());
                Assert.Fail("Actions.Add should throw exception, since it should be readonly.");
            }
            catch (Exception e) 
            {
                Assert.IsNotNull(e); //I don't think this will ever fail, but still..
            }
            Assert.AreEqual(4, actions.Count);
        }

        [TestMethod()]
        public void AddActionTest()
        {
            Assert.AreEqual(4, config.Actions.Count, "Initial action count not as expected");
            InstallerAction newAction = new CopyDirAction();
            config.AddAction(newAction);
            Assert.AreEqual(5, config.Actions.Count);
            Assert.IsTrue(config.Actions.Contains(newAction));

            //Add action again.
            config.AddAction(newAction);
            Assert.AreEqual(5, config.Actions.Count, "Adding an action that is already in the config should not add it again");
        }

        [TestMethod()]
        public void RemoveActionTest()
        {
            Assert.AreEqual(4, config.Actions.Count, "Initial action count not as expected");
            InstallerAction action = config.Actions[3];
            config.RemoveAction(action);
            Assert.AreEqual(3, config.Actions.Count);
        }

        [TestMethod()]
        public void MoveActionTest()
        {
            InstallerAction action = config.Actions[2];
            Assert.AreEqual(1, config.MoveAction(action, InstallerConfiguration.MoveActionDirection.Up));
            Assert.AreEqual(1, config.Actions.IndexOf(action));
            Assert.AreEqual(2, config.MoveAction(action, InstallerConfiguration.MoveActionDirection.Down));
            Assert.AreEqual(2, config.Actions.IndexOf(action));

            //Check moving up when index is 0.
            action = config.Actions[0];
            Assert.AreEqual(0, config.MoveAction(action, InstallerConfiguration.MoveActionDirection.Up));
            Assert.AreEqual(0, config.Actions.IndexOf(action));

            //Check moving down when index is last.
            action = config.Actions[config.Actions.Count - 1];
            Assert.AreEqual(config.Actions.Count - 1, config.MoveAction(action, InstallerConfiguration.MoveActionDirection.Down));
            Assert.AreEqual(config.Actions.Count - 1, config.Actions.IndexOf(action));

            try
            {
                config.MoveAction(new CopyDirAction(), InstallerConfiguration.MoveActionDirection.Up);
                Assert.Fail("Moving an action that is not contained in the config should throw an exception");
            }
            catch (ArgumentException e) 
            {
                Assert.IsNotNull(e); //I don't think this will ever fail, but still..
            }
        }

        [TestMethod()]
        public void WriteTest()
        {
            JsonFileHandler<InstallerConfiguration> handler = new JsonFileHandler<InstallerConfiguration>();
            try
            {
                handler.Write(TestHelperMethods.GetOutputDirectory() + "/myscript" + InstallerConfiguration.DefaultExtension, this.config);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod()]
        public void ReadTest()
        {
            // Write installer config.
            this.WriteTest();

            // Read and compare manifest
            JsonFileHandler<InstallerConfiguration> handler = new JsonFileHandler<InstallerConfiguration>();
            InstallerConfiguration readConfig = handler.Read(TestHelperMethods.GetOutputDirectory() + "/myscript" + InstallerConfiguration.DefaultExtension);
            Assert.IsNotNull(readConfig);
            Assert.AreEqual(config.Actions.Count, readConfig.Actions.Count);
            Assert.AreEqual(config, config.Actions[0].Configuration);
            Assert.AreEqual(((CopyFileAction)config.Actions[0]).Source, ((CopyFileAction)readConfig.Actions[0]).Source);
            Assert.AreEqual(((CopyFileAction)config.Actions[0]).Target, ((CopyFileAction)readConfig.Actions[0]).Target);
            Assert.AreEqual(((CopyFileAction)config.Actions[0]).UseScriptId, ((CopyFileAction)readConfig.Actions[0]).UseScriptId);
            Assert.AreEqual(((CopyDirAction)config.Actions[1]).Source, ((CopyDirAction)readConfig.Actions[1]).Source);
            Assert.AreEqual(((CopyDirAction)config.Actions[1]).Target, ((CopyDirAction)readConfig.Actions[1]).Target);
            Assert.AreEqual(((CopyDirAction)config.Actions[1]).UseScriptId, ((CopyDirAction)readConfig.Actions[1]).UseScriptId);
            Assert.AreEqual(((AssignHotkeyAction)config.Actions[2]).Keys, ((AssignHotkeyAction)readConfig.Actions[2]).Keys);
            Assert.AreEqual(((RunMaxscriptAction)config.Actions[3]).Source, ((RunMaxscriptAction)readConfig.Actions[3]).Source);
            
        }
    }
}
