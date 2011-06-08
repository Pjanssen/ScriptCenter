using ScriptCenter.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ScriptCenterTest.Repository
{
    /// <summary>
    ///This is a test class for ScriptManifestTest and is intended
    ///to contain all ScriptManifestTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ScriptManifestTest
    {
        private ScriptManifest manifest;
        private String outputFile;

        [TestInitialize()]
        public void testInitialize()
        {
            this.outputFile = TestHelperMethods.GetOutputDirectory() + "/outliner" + ScriptManifest.DefaultExtension;

            this.manifest = new ScriptManifest();
            this.manifest.Id = "pierjanssen.outliner";
            this.manifest.Name = "Outliner";
            this.manifest.Author = "Pier Janssen";
            this.manifest.Versions.Add(new ScriptVersion(2, 0, 96, ScriptReleaseStage.Release));
            this.manifest.Versions.Add(new ScriptVersion(2, 0, 95, ScriptReleaseStage.Release));
            this.manifest.Versions.Add(new ScriptVersion(2, 0, 94, ScriptReleaseStage.Release));
            this.manifest.Metadata.Add("description", "descr");
        }

        [TestMethod()]
        public void WriteTest()
        {
            JsonFileHandler<ScriptManifest> handler = new JsonFileHandler<ScriptManifest>();

            //Remove the file if it already exists, so we test that it actually writes a file.
            if (System.IO.File.Exists(outputFile))
                System.IO.File.Delete(outputFile);

            handler.Write(outputFile, this.manifest);

            Assert.IsTrue(System.IO.File.Exists(outputFile));
        }

        [TestMethod()]
        public void ReadTest()
        {
            // Write manifest.
            this.WriteTest();

            // Read and compare manifest
            JsonFileHandler<ScriptManifest> handler = new JsonFileHandler<ScriptManifest>();
            ScriptManifest readManifest = handler.Read(outputFile);
            Assert.IsNotNull(readManifest);
            Assert.AreEqual(this.manifest.Id, readManifest.Id);
            Assert.AreEqual(this.manifest.Name, readManifest.Name);
            Assert.AreEqual(this.manifest.Author, readManifest.Author);
            Assert.AreEqual(this.manifest.Versions.Count, readManifest.Versions.Count);
            Assert.AreEqual(this.manifest.Versions[0].VersionNumber.Major, readManifest.Versions[0].VersionNumber.Major);
            Assert.AreEqual(this.manifest.Versions[0].VersionNumber.Minor, readManifest.Versions[0].VersionNumber.Minor);
            Assert.AreEqual(this.manifest.Versions[0].VersionNumber.Revision, readManifest.Versions[0].VersionNumber.Revision);
            Assert.AreEqual(this.manifest.Metadata["description"], readManifest.Metadata["description"]);
        }


        [TestMethod]
        public void LatestVersionTest()
        {
            ScriptVersionNumber expectedVersion = new ScriptVersionNumber(2, 0, 96, ScriptReleaseStage.Release);
            Assert.AreEqual(expectedVersion, manifest.LatestVersion.VersionNumber, "Latest version");

            expectedVersion = new ScriptVersionNumber(3, 0, 0);
            manifest.Versions.Add(new ScriptVersion(expectedVersion));
            Assert.AreEqual(expectedVersion, manifest.LatestVersion.VersionNumber, "Added latest version");

            expectedVersion.Major = 1;
            Assert.AreNotEqual(expectedVersion, manifest.LatestVersion, "Changed version so that it no longer is the latest version.");

            ScriptManifest m = new ScriptManifest();
            Assert.AreEqual(0, m.Versions.Count, "Version count should be 0.");
            Assert.AreEqual(null, m.LatestVersion, "LatestVersion in empty manifest should be null");
        }

        [TestMethod]
        public void LatestStableVersionTest()
        {
            ScriptVersionNumber expectedVersion = new ScriptVersionNumber(2, 0, 96, ScriptReleaseStage.Release);
            Assert.AreEqual(expectedVersion, manifest.LatestStableVersion.VersionNumber, "Latest stable version 1");

            manifest.Versions.Add(new ScriptVersion(new ScriptVersionNumber(3, 0, 0, ScriptReleaseStage.Alpha)));
            manifest.Versions.Add(new ScriptVersion(new ScriptVersionNumber(3, 0, 0, ScriptReleaseStage.Beta)));
            Assert.AreEqual(expectedVersion, manifest.LatestStableVersion.VersionNumber, "Latest stable version 2");

            expectedVersion = new ScriptVersionNumber(3, 0, 0, ScriptReleaseStage.Release);
            manifest.Versions.Add(new ScriptVersion(expectedVersion));
            Assert.AreEqual(expectedVersion, manifest.LatestStableVersion.VersionNumber, "Latest stable version 3");

            ScriptManifest m = new ScriptManifest();
            Assert.AreEqual(0, m.Versions.Count, "Version count should be 0.");
            Assert.AreEqual(null, m.LatestStableVersion, "LatestStableVersion in empty manifest should be null");
        }

        [TestMethod]
        public void ScriptVersionCloneTest()
        {
            ScriptVersion version = new ScriptVersion(2, 1, 3, ScriptReleaseStage.Alpha);
            ScriptVersion newVersion = (ScriptVersion)version.Clone();
            Assert.AreEqual(version.VersionNumber, newVersion.VersionNumber, "Version numbers are equal");
            Assert.AreEqual(version.Minimal3dsmaxVersion, newVersion.Minimal3dsmaxVersion, "Min 3dsmax are equal");
            Assert.AreEqual(version.Maximum3dsmaxVersion, newVersion.Maximum3dsmaxVersion, "Max 3dsmax are equal");
            Assert.AreEqual(version.ScriptPath, newVersion.ScriptPath, "Scriptpaths are equal");
        }
    }
}
