using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScriptCenter.Package;
using System.IO;

namespace ScriptCenterTest.Package
{
    [TestClass]
    public class InstallerLogTest
    {
        [TestInitialize]
        public void TestInitialize()
        {
            InstallerLog.RemoveAllWriters();
        }

        [TestMethod]
        public void RemoveWriterTest()
        {
            MemoryStream memStream = new MemoryStream();
            StreamWriter writer = new StreamWriter(memStream);
            
            InstallerLog.AddWriter(writer);
            String message = "test";
            InstallerLog.Write(message);

            writer.Flush();
            memStream.Position = 0;
            StreamReader reader = new StreamReader(memStream);
            Assert.AreEqual(message, reader.ReadToEnd(), "Stream after writing.");

            InstallerLog.RemoveWriter(writer, false);
            InstallerLog.Write(message);
            
            writer.Flush();
            memStream.Position = 0;
            Assert.AreEqual(message, reader.ReadToEnd(), "Stream after removing, then writing.");

            writer.Dispose();
            reader.Dispose();
        }

        [TestMethod]
        public void RemoveAllWritersTest()
        {
            MemoryStream memStream = new MemoryStream();
            StreamWriter writer = new StreamWriter(memStream);

            InstallerLog.AddWriter(writer);
            String message = "test";
            InstallerLog.Write(message);

            writer.Flush();
            memStream.Position = 0;
            StreamReader reader = new StreamReader(memStream);
            Assert.AreEqual(message, reader.ReadToEnd(), "Stream after writing.");

            InstallerLog.RemoveAllWriters(false);
            InstallerLog.Write(message);
            writer.Flush();
            memStream.Position = 0;
            Assert.AreEqual(message, reader.ReadToEnd(), "Stream after removing, then writing.");

            writer.Dispose();
            reader.Dispose();
        }

        [TestMethod]
        public void WriteTest()
        {
            String w1 = "test";
            String w2 = "anothertest";
            MemoryStream memStream = new MemoryStream();
            StreamWriter writer = new StreamWriter(memStream);

            InstallerLog.AddWriter(writer);
            InstallerLog.Write(w1);
            InstallerLog.Write(w2);

            writer.Flush();
            memStream.Position = 0;
            StreamReader reader = new StreamReader(memStream);
            Assert.AreEqual(w1 + w2, reader.ReadLine(), "Reading line after writing to log.");
        }

        [TestMethod]
        public void WriteLineTest()
        {
            String line = "Test";

            MemoryStream memStream = new MemoryStream();
            StreamWriter writer = new StreamWriter(memStream);
            
            InstallerLog.AddWriter(writer);
            InstallerLog.WriteLine(line);

            writer.Flush();
            memStream.Position = 0;
            StreamReader reader = new StreamReader(memStream);
            Assert.AreEqual(line, reader.ReadLine(), "Reading line after writing to log.");
        }

        [TestMethod]
        public void OutOptionsTest()
        {
            MemoryStream memStream = new MemoryStream();
            StreamWriter writer = new StreamWriter(memStream);
            InstallerLog.AddWriter(writer, InstallerLog.DefaultLineFormat);

            String line = "test";
            InstallerLog.WriteLine(line);

            writer.Flush();
            memStream.Position = 0;
            StreamReader reader = new StreamReader(memStream);
            Assert.AreEqual(line, reader.ReadLine(), "DefaultLineFormat should only write the line itself.");
            
            reader.Close();
            memStream = new MemoryStream();
            writer = new StreamWriter(memStream);
            InstallerLog.RemoveAllWriters();
            InstallerLog.AddWriter(writer, InstallerLog.TimeStampedLineFormat);
            InstallerLog.WriteLine(line);

            writer.Flush();
            memStream.Position = 0;
            reader = new StreamReader(memStream);
            String expectedLine = String.Format(InstallerLog.TimeStampedLineFormat, line, DateTime.Now.ToString());
            Assert.AreEqual(expectedLine, reader.ReadLine(), "TimeStampLineFormat should include timestamp.");

            writer.Dispose();
            reader.Dispose();
        }
    }
}
