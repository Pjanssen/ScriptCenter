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
        private String getOutputDirectory()
        {
            return System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\ScriptCenterTest\\test_output\\";
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

            Assert.IsTrue(handler.Write(this.getOutputDirectory() + "/outliner.manifest.json", this.manifest));
        }

        [TestMethod()]
        public void ReadTest()
        {
            // Write manifest.
            this.WriteTest();

            // Read and compare manifest
            LocalFileHandler<ScriptManifest> handler = new LocalFileHandler<ScriptManifest>();
            ScriptManifest readManifest = handler.Read(this.getOutputDirectory() + "/outliner.manifest.json");
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
    }
}
