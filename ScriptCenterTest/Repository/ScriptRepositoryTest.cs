using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScriptCenter.Repository;
using System.IO;
using ScriptCenter.Utils;

namespace ScriptCenterTest.Repository
{
    [TestClass]
    public class ScriptRepositoryTest
    {
        private ScriptRepository repo;

        [TestInitialize]
        public void TestInit()
        {
            repo = new ScriptRepository("testRepo");
            repo.Scripts.Add(new ScriptManifestReference("test.scmanifest"));
            repo.Scripts.Add(new ScriptManifestReference("another_test.scmanifest"));
            ScriptRepositoryCategory cat = new ScriptRepositoryCategory("testCategory");
            cat.Scripts.Add(new ScriptManifestReference("outliner.scmanifest"));
            repo.Categories.Add(cat);
        }

        [TestMethod]
        public void ConstructorCreatesDefaultCategoryTest()
        {
            ScriptRepository repo = new ScriptRepository();
            Assert.IsNotNull(repo.DefaultCategory, "DefaultCategory should not be null");
            Assert.IsNotNull(repo.Scripts, "Scripts should not be null");
            Assert.IsNotNull(repo.Categories, "Categories should not be null");
            Assert.IsFalse(repo.Categories.Contains(repo.DefaultCategory), "Default category should not be in categories list");
        }

        [TestMethod]
        public void CategoryConstructorTest()
        {
            ScriptRepositoryCategory cat = new ScriptRepositoryCategory();
            Assert.IsNotNull(cat.Name);
            Assert.IsNotNull(cat.Scripts, "Scripts should not be null");
        }

        [TestMethod]
        public void AllScriptsTest()
        {
            Assert.IsNotNull(repo.Scripts);
            Assert.AreEqual(3, repo.AllScripts.Count);
        }

        [TestMethod]
        public void WriteTest()
        {
            String outputFile = TestHelperMethods.GetOutputDirectory() + "repo" + ScriptRepository.DefaultExtension;
            if (File.Exists(outputFile))
                File.Delete(outputFile);

            JsonFileHandler<ScriptRepository> handler = new JsonFileHandler<ScriptRepository>();
            handler.Write(outputFile, repo);

            Assert.IsTrue(File.Exists(outputFile));
        }

        [TestMethod]
        public void ReadTest()
        {
            String inputFile = TestHelperMethods.GetOutputDirectory() + "repo" + ScriptRepository.DefaultExtension;
            if (!File.Exists(inputFile))
                this.WriteTest();

            Assert.IsTrue(File.Exists(inputFile), "File to read does not exist");

            JsonFileHandler<ScriptRepository> handler = new JsonFileHandler<ScriptRepository>();
            ScriptRepository readRepo = handler.Read(inputFile);

            Assert.IsNotNull(readRepo, "Repository should not be null");
            Assert.AreEqual(repo.Scripts.Count, readRepo.Scripts.Count, "Number of scripts in default category incorrect");
            Assert.AreEqual(repo.Name, readRepo.Name, "Repository name incorrect");
            Assert.AreEqual(repo.Categories.Count, readRepo.Categories.Count, "Category count incorrect");
            Assert.AreEqual(repo.Categories[0].Scripts.Count, readRepo.Categories[0].Scripts.Count, "Category.Scripts count incorrect");
        }
    }
}
