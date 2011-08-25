using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScriptCenter.Package.InstallerActions;
using ScriptCenter.Package;
using ScriptCenter.Repository;
using System.Threading;

namespace ScriptCenterTest.Package
{
    [TestClass]
    public class InstallerTest
    {
        private class MockInstallerAction : InstallerAction
        {
            public Boolean ActionInstalled = false;
            public Boolean ActionUninstalled = false;

            public override bool Do(ScriptCenter.Package.Installer installer)
            {
                ActionInstalled = true;
                return true;
            }

            public override bool Undo(ScriptCenter.Package.Installer installer)
            {
                ActionUninstalled = true;
                return true;
            }

            public override void PackResources(Ionic.Zip.ZipFile zip, string archiveTargetPath, ScriptCenter.Utils.IPath sourcePath)
            {
            }
        }

        ScriptManifest manifest;

        [TestInitialize]
        public void Init()
        {
            this.manifest = new ScriptManifest();
            this.manifest.Name = "Outliner";
            this.manifest.Author = "Pier Janssen";
            this.manifest.Id = new ScriptId(this.manifest.Name, this.manifest.Author);
            this.manifest.Versions.Add(new ScriptVersion(1, 0, 0, ScriptReleaseStage.Release));
        }


        [TestMethod]
        public void InstallTest()
        {
            InstallerConfiguration config = new InstallerConfiguration();
            MockInstallerAction action = new MockInstallerAction();
            config.AddAction(action);

            Installer installer = new Installer("", manifest, config);

            Assert.IsFalse(action.ActionInstalled);

            Boolean installerCompleted = false;
            ManualResetEvent manualEvent = new ManualResetEvent(false);
            installer.Completed += delegate(object sender, EventArgs e)
            {
                installerCompleted = true;
                manualEvent.Set();
            };
            installer.Install();
            manualEvent.WaitOne(1000, false);

            Assert.IsTrue(installerCompleted, "Installer completed.");
            Assert.IsTrue(action.ActionInstalled, "Action installed.");
        }


        [TestMethod]
        public void UninstallTest()
        {
            InstallerConfiguration config = new InstallerConfiguration();
            MockInstallerAction action = new MockInstallerAction();
            config.AddAction(action);
            Installer installer = new Installer("", manifest, config);

            Assert.IsFalse(action.ActionUninstalled);

            Boolean installerCompleted = false;
            ManualResetEvent manualEvent = new ManualResetEvent(false);
            installer.Completed += delegate(object sender, EventArgs e)
            {
                installerCompleted = true;
                manualEvent.Set();
            };
            installer.Uninstall();
            manualEvent.WaitOne(1000, false);

            Assert.IsTrue(installerCompleted, "Installer completed.");
            Assert.IsTrue(action.ActionUninstalled, "Action uninstalled.");
        }


        [TestMethod]
        public void ProgressTest()
        {
            InstallerConfiguration config = new InstallerConfiguration();
            config.AddAction(new MockInstallerAction());
            config.AddAction(new MockInstallerAction());
            config.AddAction(new MockInstallerAction());

            Installer installer = new Installer("", manifest, config);

            Int32 prevProgress = 0;
            ManualResetEvent manualEvent = new ManualResetEvent(false);
            installer.Progress += delegate(object sender, InstallerProgressEventArgs e)
            {
                Assert.IsTrue(e.Progress > prevProgress);
                prevProgress = e.Progress;
            };
            installer.Completed += delegate(object sender, EventArgs e)
            {
                manualEvent.Set();
            };
            installer.Install();
            manualEvent.WaitOne(1000, false);

            Assert.AreEqual(100, prevProgress, "Installer progress.");
        }



        private class MockFailingAction : InstallerAction
        {
            public Exception Exception = new Exception();
            public override bool Do(Installer installer)
            {
                throw Exception;
            }

            public override bool Undo(Installer installer)
            {
                throw Exception;
            }

            public override void PackResources(Ionic.Zip.ZipFile zip, string archiveTargetPath, ScriptCenter.Utils.IPath sourcePath)
            {
            }
        }

        [TestMethod]
        public void InstallFailTest()
        {
            InstallerConfiguration config = new InstallerConfiguration();
            MockFailingAction action = new MockFailingAction();
            config.AddAction(action);
            Installer installer = new Installer("", manifest, config);

            ManualResetEvent manualEvent = new ManualResetEvent(false);
            InstallerFailedEventArgs raisedEventArgs = null;
            installer.Failed += delegate(object sender, InstallerFailedEventArgs e)
            {
                raisedEventArgs = e;
                manualEvent.Set();
            };
            installer.Install();
            manualEvent.WaitOne(1000, false);

            Assert.IsNotNull(raisedEventArgs, "Failed event should be fired.");
            Assert.AreEqual(action.Exception, raisedEventArgs.Exception, "Exception should be set.");
        }

        [TestMethod]
        public void UninstallFailTest()
        {
            InstallerConfiguration config = new InstallerConfiguration();
            MockFailingAction action = new MockFailingAction();
            config.AddAction(action);
            Installer installer = new Installer("", manifest, config);

            ManualResetEvent manualEvent = new ManualResetEvent(false);
            InstallerFailedEventArgs raisedEventArgs = null;
            installer.Failed += delegate(object sender, InstallerFailedEventArgs e)
            {
                raisedEventArgs = e;
                manualEvent.Set();
            };
            installer.Uninstall();
            manualEvent.WaitOne(1000, false);

            Assert.IsNotNull(raisedEventArgs, "Failed event should be fired.");
            Assert.AreEqual(action.Exception, raisedEventArgs.Exception, "Exception should be set.");
        }
    }
}
