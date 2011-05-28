using ScriptCenter.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ScriptCenterTest
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
            this.manifest.Description = "descr";
            this.manifest.Versions.Add(new ScriptVersion(2, 0, 96));
            this.manifest.Versions.Add(new ScriptVersion(2, 0, 95));
            this.manifest.Versions.Add(new ScriptVersion(2, 0, 94));
        }

        [TestMethod()]
        public void WriteTest()
        {
            FileHandler<ScriptManifest> handler = new FileHandler<ScriptManifest>();

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
            FileHandler<ScriptManifest> handler = new FileHandler<ScriptManifest>();
            ScriptManifest readManifest = handler.Read(outputFile);
            Assert.IsNotNull(readManifest);
            Assert.AreEqual(this.manifest.Id, readManifest.Id);
            Assert.AreEqual(this.manifest.Name, readManifest.Name);
            Assert.AreEqual(this.manifest.Author, readManifest.Author);
            Assert.AreEqual(this.manifest.Description, readManifest.Description);
            Assert.AreEqual(this.manifest.Versions.Count, readManifest.Versions.Count);
            Assert.AreEqual(this.manifest.Versions[0].Major, readManifest.Versions[0].Major);
            Assert.AreEqual(this.manifest.Versions[0].Minor, readManifest.Versions[0].Minor);
            Assert.AreEqual(this.manifest.Versions[0].Revision, readManifest.Versions[0].Revision);
        }
    }
}
