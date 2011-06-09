using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScriptCenter.Controls;
using System.Windows.Forms;
using System.IO;

namespace ScriptCenterTest.Controls
{
    [TestClass]
    public class TextBoxStreamWriterTest
    {
        TextWriter consoleStdOut;
        TextBox textBox;
        TextBoxStreamWriter writer;

        [TestInitialize]
        public void TestInitialize()
        {
            textBox = new TextBox();
            writer = new TextBoxStreamWriter(textBox);
            consoleStdOut = Console.Out;
            Console.SetOut(writer);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Console.SetOut(consoleStdOut);
        }

        [TestMethod]
        public void EncodingTest()
        {
            Assert.AreEqual(System.Text.Encoding.UTF8, writer.Encoding, "Encoding should be UTF8");
        }

        [TestMethod]
        public void WriteTest()
        {
            Assert.AreEqual("", textBox.Text, "Initial textbox text");
            String line = "test";
            Console.Out.Write(line);
            Assert.AreEqual(line, textBox.Text, "Textbox text after Write to console.");

            textBox.Text = String.Empty;
            Assert.AreEqual(String.Empty, textBox.Text, "Reset textBox text.");

            Console.Out.WriteLine(line);
            Assert.AreEqual(line + Environment.NewLine, textBox.Text, "Textbox text after WriteLine to console.");
        }
    }
}
