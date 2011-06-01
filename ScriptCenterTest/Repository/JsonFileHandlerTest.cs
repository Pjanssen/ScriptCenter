using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScriptCenter.Repository;
using Newtonsoft.Json;
using System.Threading;

namespace ScriptCenterTest.Repository
{
    [TestClass]
    public class JsonFileHandlerTest
    {
        private JsonFileHandler<SimpleTestObject> handler;
        
        [TestInitialize]
        public void Init()
        {
            handler = new JsonFileHandler<SimpleTestObject>();
        }
        [TestCleanup]
        public void Cleanup()
        {
            handler = null;
        }


        [TestMethod]
        public void ReadTest()
        {
            //Read a simple test object file and check the results.
            SimpleTestObject readObj = handler.Read(TestHelperMethods.GetTestFilesDirectory() + "SimpleTestObject.json");
            Assert.IsNotNull(readObj, "Read object is null");
            Assert.IsNotNull(readObj.Name, "Read object's name is null");
            Assert.AreEqual(SimpleTestObject.DefaultName, readObj.Name, "Read object's name incorrect");
            Assert.AreEqual(SimpleTestObject.DefaultId, readObj.Id, "Read object's Id incorrect");
        }

        [TestMethod]
        public void ReadBrokenFileTest()
        {
            //Read a simple test object file that is not formed correctly and check the results.
            SimpleTestObject readObj = null;
            try
            {
                readObj = handler.Read(TestHelperMethods.GetTestFilesDirectory() + "SimpleBrokenTestObject.json");
                Assert.Fail("Read broken file did not throw an exception as expected");
            }
            catch (JsonReaderException e) { }
            Assert.IsNull(readObj);
        }
        [TestMethod]
        public void ReadNonExistingFileTest()
        {
            SimpleTestObject readObj = null;
            try
            {
                readObj = handler.Read("C:/nonexistingfile.json");
                Assert.Fail("Read non-existing file did not throw exception");
            }
            catch (System.IO.FileNotFoundException e) { }
            Assert.IsNull(readObj);
        }
        [TestMethod]
        public void ReadNullTest()
        {
            SimpleTestObject readObj = null;
            try
            {
                readObj = handler.Read(null);
                Assert.Fail("Read null did not throw exception");
            }
            catch (ArgumentNullException e) { }
            Assert.IsNull(readObj);
        }
        [TestMethod]
        public void ReadIncorrectPathTest()
        {
            SimpleTestObject readObj = null;
            try
            {
                readObj = handler.Read(":non&existing^%$file.json");
                Assert.Fail("Read incorrect uri did not throw exception");
            }
            catch (ArgumentException e) { }
            Assert.IsNull(readObj);
        }
        [TestMethod]
        public void ReadOnlineFileTest()
        {
            SimpleTestObject readObj = null;
            try
            {
                readObj = handler.Read(TestHelperMethods.GetOnlineTestFilesDirectory() + "SimpleTestObject.json");
                Assert.Fail("Read online uri did not throw exception");
            }
            catch (ArgumentException e) { }
            Assert.IsNull(readObj);
        }


        [TestMethod]
        public void WriteTest()
        {
            String outputFile = TestHelperMethods.GetOutputDirectory() + "SimpleTestObject.json";
            SimpleTestObject obj = new SimpleTestObject() { Name = SimpleTestObject.DefaultName, Id = SimpleTestObject.DefaultId };

            //Remove the file if it already exists, so we test that it actually writes a file.
            if (System.IO.File.Exists(outputFile))
                System.IO.File.Delete(outputFile);

            handler.Write(outputFile, obj);
            Assert.IsTrue(System.IO.File.Exists(outputFile));

            obj = handler.Read(outputFile);
            Assert.AreEqual(SimpleTestObject.DefaultName, obj.Name);
            Assert.AreEqual(SimpleTestObject.DefaultId, obj.Id);
        }

        [TestMethod]
        public void WriteNullTest()
        {
            String outputFile = TestHelperMethods.GetOutputDirectory() + "FileHandlerWriteNullTest.json";
            try
            {
                handler.Write(outputFile, null);
                Assert.Fail("Write null did not throw exception as expected");
            }
            catch (ArgumentNullException e) { }
            Assert.IsFalse(System.IO.File.Exists(outputFile));

            SimpleTestObject obj = new SimpleTestObject() { Name = SimpleTestObject.DefaultName, Id = SimpleTestObject.DefaultId };
            try
            {
                handler.Write(null, obj);
                Assert.Fail("Write null did not throw exception as expected");
            }
            catch (ArgumentNullException e) { }
        }
        [TestMethod]
        public void WriteIncorrectPathTest()
        {
            String outputFile = ":non&existing^%$file.json";
            SimpleTestObject obj = new SimpleTestObject() { Name = SimpleTestObject.DefaultName, Id = SimpleTestObject.DefaultId };
            try
            {
                handler.Write(outputFile, obj);
                Assert.Fail("Write to incorrect path did not throw exception as expected");
            }
            catch (ArgumentException e) { }
            Assert.IsFalse(System.IO.File.Exists(outputFile));
        }


        [TestMethod]
        public void ReadAsyncTest()
        {
            String path = TestHelperMethods.GetTestFilesDirectory() + "SimpleTestObject.json";
            ManualResetEvent manualEvent = new ManualResetEvent(false);

            SimpleTestObject obj = null;
            handler.ReadComplete += delegate(object sender, ReadCompleteEventArgs<SimpleTestObject> e)
            {
                obj = e.Data;
                manualEvent.Set();
            };
            handler.ReadAsync(path);
            manualEvent.WaitOne(5000, false);
            Assert.IsNotNull(obj);
            Assert.AreEqual(SimpleTestObject.DefaultName, obj.Name);
            Assert.AreEqual(SimpleTestObject.DefaultId, obj.Id);
        }
        [TestMethod]
        public void ReadOnlineFileAsyncTest()
        {
            String path = TestHelperMethods.GetOnlineTestFilesDirectory() + "SimpleTestObject.json";
            ManualResetEvent manualEvent = new ManualResetEvent(false);

            SimpleTestObject obj = null;
            handler.ReadComplete += delegate(object sender, ReadCompleteEventArgs<SimpleTestObject> e)
            {
                obj = e.Data;
                manualEvent.Set();
            };
            handler.ReadAsync(path);
            manualEvent.WaitOne(5000, false);
            Assert.IsNotNull(obj);
            Assert.AreEqual(SimpleTestObject.DefaultName, obj.Name);
            Assert.AreEqual(SimpleTestObject.DefaultId, obj.Id);
        }

        [TestMethod]
        public void ReadBrokenFileAsyncTest()
        {
            String path = TestHelperMethods.GetTestFilesDirectory() + "SimpleBrokenTestObject.json";
            ManualResetEvent manualEvent = new ManualResetEvent(false);

            Exception exception = null;
            handler.ReadComplete += delegate(object sender, ReadCompleteEventArgs<SimpleTestObject> e)
            {
                Assert.Fail("LoadComplete event should not fire when parsing broken file.");
            };
            handler.SerializationError += delegate(object sender, ErrorEventArgs e)
            {
                exception = e.Exception;
                manualEvent.Set();
            };
            handler.ReadAsync(path);
            manualEvent.WaitOne(5000, false);
            Assert.IsNotNull(exception);
        }
        [TestMethod]
        public void ReadNonExistingFileAsyncTest()
        {
            String path = "C:/nonexistingfile.json";
            ManualResetEvent manualEvent = new ManualResetEvent(false);

            Exception exception = null;
            handler.ReadComplete += delegate(object sender, ReadCompleteEventArgs<SimpleTestObject> e)
            {
                Assert.Fail("LoadComplete event should not fire when trying to read non-existing file.");
            };
            handler.ReadError += delegate(object sender, ErrorEventArgs e)
            {
                exception = e.Exception;
                manualEvent.Set();
            };
            handler.ReadAsync(path);
            manualEvent.WaitOne(5000, false);
            Assert.IsNotNull(exception);
        }
        [TestMethod]
        public void ReadNullAsyncTest()
        {
            ManualResetEvent manualEvent = new ManualResetEvent(false);

            Exception exception = null;
            handler.ReadComplete += delegate(object sender, ReadCompleteEventArgs<SimpleTestObject> e)
            {
                Assert.Fail("LoadComplete event should not fire when trying to read null file.");
            };
            handler.ReadError += delegate(object sender, ErrorEventArgs e)
            {
                exception = e.Exception;
                manualEvent.Set();
            };
            handler.ReadAsync(null);
            manualEvent.WaitOne(5000, false);
            Assert.IsNotNull(exception);
        }
        [TestMethod]
        public void ReadIncorrectPathAsyncTest()
        {
            ManualResetEvent manualEvent = new ManualResetEvent(false);

            Exception exception = null;
            handler.ReadComplete += delegate(object sender, ReadCompleteEventArgs<SimpleTestObject> e)
            {
                Assert.Fail("LoadComplete event should not fire when trying to read null file.");
            };
            handler.ReadError += delegate(object sender, ErrorEventArgs e)
            {
                exception = e.Exception;
                manualEvent.Set();
            };
            handler.ReadAsync(":non&existing^%$file.json");
            manualEvent.WaitOne(5000, false);
            Assert.IsNotNull(exception);
        }
    }
}
