using ScriptCenter.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ScriptCenterTest
{
    /// <summary>
    ///This is a test class for LocalFileHandlerTest and is intended
    ///to contain all LocalFileHandlerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LocalFileHandlerTest
    {
        private String getOutputDirectory()
        {
            return System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\ScriptCenterTest\\test_output\\";
        }

        private class SimpleObject
        {
            public String property { get; set; }
        }
        private SimpleObject obj;

        [TestInitialize()]
        public void testInitialize()
        {
            this.obj = new SimpleObject();
            this.obj.property = "test";
        }

        [TestMethod()]
        public void WriteTest()
        {
            LocalFileHandler<SimpleObject> handler = new LocalFileHandler<SimpleObject>();

            Assert.IsTrue(handler.Write(this.getOutputDirectory() + "/simple_object.json", this.obj));
        }

        
        [TestMethod()]
        public void WriteToIncorrectPathTest()
        {
            LocalFileHandler<SimpleObject> handler = new LocalFileHandler<SimpleObject>();

            Assert.IsFalse(System.IO.Directory.Exists("R:/"), "Directory actually exists, try another one");
            Assert.IsFalse(handler.Write("R:/incorrect_path.json", this.obj));
        }

        [TestMethod()]
        public void ReadTest()
        {
            // Write manifest.
            this.WriteTest();

            // Read and compare manifest
            LocalFileHandler<SimpleObject> handler = new LocalFileHandler<SimpleObject>();
            SimpleObject readObj = handler.Read(this.getOutputDirectory() + "/simple_object.json");
            Assert.IsNotNull(readObj);
            Assert.AreEqual(this.obj.property, readObj.property);
        }

        [TestMethod()]
        public void ReadNonExistingFileTest()
        {
            LocalFileHandler<SimpleObject> handler = new LocalFileHandler<SimpleObject>();
            Assert.IsNull(handler.Read("R:/nonexistingfile.json"));
        }

        [TestMethod()]
        public void ReadIncorrectFileTest()
        {
            String file = this.getOutputDirectory() + "incorrect_file.json";
            //Write syntactically incorrect file.
            System.IO.StreamWriter w = new System.IO.StreamWriter(file);
            w.Write("{\"incomplete fi..");
            w.Close();

            LocalFileHandler<SimpleObject> handler = new LocalFileHandler<SimpleObject>();
            Assert.IsNull(handler.Read(file));

            //Write syntactically correct file, but with nonsense data
            w = new System.IO.StreamWriter(file);
            w.Write("{\"asd\": 2 }");
            w.Close();

            SimpleObject readObj = handler.Read(file);
            Assert.IsNotNull(readObj);
            Assert.AreEqual(null, readObj.property);
        }
    }
}
