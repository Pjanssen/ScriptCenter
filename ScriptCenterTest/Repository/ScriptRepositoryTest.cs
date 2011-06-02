using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScriptCenter.Repository;
using System.IO;

namespace ScriptCenterTest.Repository
{
    [TestClass]
    public class ScriptRepositoryTest
    {
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
            Assert.IsNotNull(cat.Scripts, ".Scripts should not be null");
        }

        [TestMethod]
        public void AllScriptsTest()
        {
            ScriptRepository repo = new ScriptRepository();
            repo.Scripts.Add("test.scmanifest");
            ScriptRepositoryCategory cat = new ScriptRepositoryCategory("testCategory");
            cat.Scripts.Add("outliner.scmanifest");
            repo.Categories.Add(cat);

            Assert.IsNotNull(repo.Scripts);
            Assert.AreEqual(2, repo.AllScripts.Count);
        }

        [TestMethod]
        public void WriteTest()
        {
            ScriptRepository repo = new ScriptRepository();
            repo.Scripts.Add("test.scmanifest");
            ScriptRepositoryCategory cat = new ScriptRepositoryCategory("testCategory");
            cat.Scripts.Add("outliner.scmanifest");
            repo.Categories.Add(cat);

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
            ScriptRepository repo = handler.Read(inputFile);

            Assert.IsNotNull(repo, "Repository should not be null");
            Assert.AreEqual(1, repo.Scripts.Count, "Number of scripts in default category incorrect");
        }
    }
}
