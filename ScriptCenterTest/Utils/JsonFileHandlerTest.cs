using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScriptCenter.Repository;
using Newtonsoft.Json;
using System.Threading;
using ScriptCenter.Utils;

namespace ScriptCenterTest.Utils
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
            IPath path = new BasePath(TestHelperMethods.GetTestFilesDirectory() + "SimpleTestObject.json");
            SimpleTestObject readObj = handler.Read(path);
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
            IPath path = new BasePath(TestHelperMethods.GetTestFilesDirectory() + "SimpleBrokenTestObject.json");
            try
            {
                readObj = handler.Read(path);
                Assert.Fail("Read broken file did not throw an exception as expected");
            }
            catch (JsonReaderException e) 
            {
                Assert.IsNotNull(e); //I don't think this will ever fail, but still..
            }
            Assert.IsNull(readObj);
        }
        [TestMethod]
        public void ReadNonExistingFileTest()
        {
            SimpleTestObject readObj = null;
            try
            {
                readObj = handler.Read(new BasePath("C:/nonexistingfile.json"));
                Assert.Fail("Read non-existing file did not throw exception");
            }
            catch (System.IO.FileNotFoundException e) 
            {
                Assert.IsNotNull(e); //I don't think this will ever fail, but still..
            }
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
            catch (Exception e) 
            {
                Assert.IsNotNull(e); //I don't think this will ever fail, but still..
            }
            Assert.IsNull(readObj);
        }
        [TestMethod]
        public void ReadIncorrectPathTest()
        {
            SimpleTestObject readObj = null;
            try
            {
                readObj = handler.Read(new BasePath(":non&existing^%$file.json"));
                Assert.Fail("Read incorrect uri did not throw exception");
            }
            catch (ArgumentException e) 
            {
                Assert.IsNotNull(e); //I don't think this will ever fail, but still..
            }
            Assert.IsNull(readObj);
        }
        [TestMethod]
        public void ReadOnlineFileTest()
        {
            SimpleTestObject readObj = null;
            IPath path = new BasePath(TestHelperMethods.GetOnlineTestFilesDirectory() + "SimpleTestObject.json");
            try
            {
                readObj = handler.Read(path);
                Assert.Fail("Read online uri did not throw exception");
            }
            catch (ArgumentException e) 
            {
                Assert.IsNotNull(e); //I don't think this will ever fail, but still..
            }
            Assert.IsNull(readObj);
        }


        [TestMethod]
        public void WriteTest()
        {
            IPath outputFile = new BasePath(TestHelperMethods.GetOutputDirectory() + "SimpleTestObject.json");
            SimpleTestObject obj = new SimpleTestObject() { Name = SimpleTestObject.DefaultName, Id = SimpleTestObject.DefaultId };

            //Remove the file if it already exists, so we test that it actually writes a file.
            if (System.IO.File.Exists(outputFile.AbsolutePath))
                System.IO.File.Delete(outputFile.AbsolutePath);

            handler.Write(outputFile, obj);
            Assert.IsTrue(System.IO.File.Exists(outputFile.AbsolutePath));

            obj = handler.Read(outputFile);
            Assert.AreEqual(SimpleTestObject.DefaultName, obj.Name);
            Assert.AreEqual(SimpleTestObject.DefaultId, obj.Id);
        }

        [TestMethod]
        public void WriteNullTest()
        {
            IPath outputFile = new BasePath(TestHelperMethods.GetOutputDirectory() + "FileHandlerWriteNullTest.json");
            try
            {
                handler.Write(outputFile, null);
                Assert.Fail("Write null did not throw exception as expected");
            }
            catch (Exception e) 
            {
                Assert.IsNotNull(e); //I don't think this will ever fail, but still..
            }
            Assert.IsFalse(System.IO.File.Exists(outputFile.AbsolutePath));

            SimpleTestObject obj = new SimpleTestObject() { Name = SimpleTestObject.DefaultName, Id = SimpleTestObject.DefaultId };
            try
            {
                IPath path = null;
                handler.Write(path, obj);
                Assert.Fail("Write null did not throw exception as expected");
            }
            catch (Exception e) 
            {
                Assert.IsNotNull(e); //I don't think this will ever fail, but still..
            }
        }
        [TestMethod]
        public void WriteIncorrectPathTest()
        {
            IPath outputFile = new BasePath(":non&existing^%$file.json");
            SimpleTestObject obj = new SimpleTestObject() { Name = SimpleTestObject.DefaultName, Id = SimpleTestObject.DefaultId };
            try
            {
                handler.Write(outputFile, obj);
                Assert.Fail("Write to incorrect path did not throw exception as expected");
            }
            catch (ArgumentException e) 
            {
                Assert.IsNotNull(e); //I don't think this will ever fail, but still..
            }
            Assert.IsFalse(System.IO.File.Exists(outputFile.AbsolutePath));
        }


        [TestMethod]
        public void ReadAsyncTest()
        {
            IPath path = new BasePath(TestHelperMethods.GetTestFilesDirectory() + "SimpleTestObject.json");
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
            IPath path = new BasePath(TestHelperMethods.GetOnlineTestFilesDirectory() + "SimpleTestObject.json");
            ManualResetEvent manualEvent = new ManualResetEvent(false);

            SimpleTestObject obj = null;
            handler.ReadComplete += delegate(object sender, ReadCompleteEventArgs<SimpleTestObject> e)
            {
                obj = e.Data;
                manualEvent.Set();
            };
            handler.ReadError += delegate(object sender, ErrorEventArgs e)
            {
                manualEvent.Set();
            };
            //TODO make sure this really doesn't block the calling thread. The timeout of 15s regardless of waitone seems to suggest that it does..
            handler.ReadAsync(path);
            manualEvent.WaitOne(1000, false);
            Assert.IsNotNull(obj);
            Assert.AreEqual(SimpleTestObject.DefaultName, obj.Name);
            Assert.AreEqual(SimpleTestObject.DefaultId, obj.Id);
        }

        [TestMethod]
        public void ReadBrokenFileAsyncTest()
        {
            IPath path = new BasePath(TestHelperMethods.GetTestFilesDirectory() + "SimpleBrokenTestObject.json");
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
            IPath path = new BasePath("C:/nonexistingfile.json");
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
            handler.ReadAsync(new BasePath(":non&existing^%$file.json"));
            manualEvent.WaitOne(5000, false);
            Assert.IsNotNull(exception);
        }
    }
}
