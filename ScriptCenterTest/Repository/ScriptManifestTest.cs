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
            this.manifest.Id = "pier.janssen.outliner";
            this.manifest.Name = "Outliner";
            this.manifest.Author = "Pier Janssen";
            this.manifest.Versions.Add(new ScriptVersion(2, 0, 96));
            this.manifest.Versions.Add(new ScriptVersion(2, 0, 95));
            this.manifest.Versions.Add(new ScriptVersion(2, 0, 94));
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
    }
}
