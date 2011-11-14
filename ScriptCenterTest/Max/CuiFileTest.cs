using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScriptCenter.Max;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing;

namespace ScriptCenterTest.Max
{
   [TestClass]
   public class CuiFileTest
   {
      private CuiFile cui;
      private String cuiFile = TestHelperMethods.GetTestFilesDirectory() + "ame-light.cui";

      [TestInitialize]
      public void TestInit()
      {
         cui = new CuiFile();
         FileStream stream = new FileStream(cuiFile, FileMode.Open);
         Assert.IsTrue(cui.Read(stream), "Read cui file");
         stream.Close();
      }

      [TestMethod]
      public void CTorTest()
      {
         cui = new CuiFile();
         Assert.AreEqual(String.Empty, cui.File, "Empty ctor should set File to String.Empty");
         Assert.IsNotNull(cui.Toolbars, "Empty ctor should initialize toolbars property");
         Assert.AreEqual(0, cui.Toolbars.Count, "Empty ctor should create Toolbars property with count 0");

         cui = new CuiFile("testfile");
         Assert.AreEqual("testfile", cui.File, "File property should be set");
         Assert.IsNotNull(cui.Toolbars, "Toolbars property should be initialized");
         Assert.AreEqual(0, cui.Toolbars.Count, "Toolbars property count should be 0");
      }


      [TestMethod]
      public void GetToolbarTest()
      {
         String tbName = "Command Panel";
         CuiToolbar tb = cui.GetToolbar(tbName);
         Assert.IsNotNull(tb);
         Assert.AreEqual(tbName, tb.Name);

         tb = cui.GetToolbar("non existing toolbar");
         Assert.IsNull(tb);
      }

      [TestMethod]
      public void ContainsToolbarTest()
      {
         Assert.IsTrue(cui.ContainsToolbar("Command Panel"));
         Assert.IsFalse(cui.ContainsToolbar("NonExisting Toolbar"));
      }


      [TestMethod]
      public void ReadTest()
      {
         Assert.IsNotNull(cui, "Test init");

         //Find toolbar and sections count.
         FileStream stream = new FileStream(cuiFile, FileMode.Open);
         StreamReader reader = new StreamReader(stream);
         Int32 numToolbars = -1;
         List<KeyValuePair<String, Int32>> itemCounts = new List<KeyValuePair<String, int>>();

         String sectionName = String.Empty;
         Dictionary<String, Int32> propCount = new Dictionary<string, int>();
         Dictionary<String, Int32> itemCount = new Dictionary<string, int>();

         while (!reader.EndOfStream) {
            String line = reader.ReadLine();
            if (CuiFile.sectionMatchPattern.IsMatch(line))
            {
               sectionName = CuiFile.sectionReplacePattern.Replace(line, "");
               if (!propCount.ContainsKey(sectionName))
               {
                  propCount.Add(sectionName, 0);
                  itemCount.Add(sectionName, 0);
               }
            }
            else
            {
               if (CuiFile.itemPattern.IsMatch(line))
                  itemCount[sectionName]++;
               else if (CuiFile.propertyPattern.IsMatch(line) &&
                        !CuiFile.itemCountPattern.IsMatch(line) &&
                        !CuiFile.flyOffPattern.IsMatch(line))
                  propCount[sectionName]++;

               if (Regex.IsMatch(line, @"^WindowCount="))
                  numToolbars = Int32.Parse(Regex.Replace(line, @"^WindowCount=", ""));
            }

         }
         reader.Close();

         Assert.AreNotEqual(-1, numToolbars, "Numer of expected toolbars should not be -1");

         Assert.AreEqual(numToolbars, cui.Toolbars.Count, "Number of toolbars");
         Assert.AreEqual(propCount.Count - numToolbars - 2, cui.OtherSections.Count, "Number of other sections");

         foreach (CuiToolbar t in cui.Toolbars)
         {
            Assert.AreEqual(propCount[t.Name], t.Properties.Count, "Property count for toolbar " + t.Name);
            Assert.AreEqual(itemCount[t.Name], t.Items.Count, "Item count for toolbar " + t.Name);
         }

         foreach (CuiSection s in cui.OtherSections)
         {
            Assert.IsTrue(propCount[s.Name] <= s.Properties.Count, "Property count for section " + s.Name);
         }
      }


      [TestMethod]
      public void AddToolbarTest()
      {
         Boolean result = cui.AddToolbar(new CuiToolbar("New Toolbar"));
         Assert.IsTrue(result, "Adding new toolbar");

         result = cui.AddToolbar(new CuiToolbar("Command Panel"));
         Assert.IsFalse(result, "Adding existing toolbar");
      }


      [TestMethod]
      public void RemoveToolbarTest()
      {
         CuiToolbar tbToRemove = cui.Toolbars[2];
         Boolean result = cui.RemoveToolbar(tbToRemove);
         Assert.IsTrue(result, "Remove toolbar");
         Assert.IsFalse(cui.Toolbars.Contains(tbToRemove), "Toolbars no longer contains tbToRemove");

         result = cui.RemoveToolbar(tbToRemove);
         Assert.IsFalse(result, "Remove toolbar again");

         result = cui.RemoveToolbar(new CuiToolbar("New Toolbar"));
         Assert.IsFalse(result, "Remove toolbar not in Toolbars");
      }

      [TestMethod]
      public void RemoveToolbarByName()
      {
         CuiToolbar tbToRemove = cui.Toolbars[2];
         Boolean result = cui.RemoveToolbar(tbToRemove.Name);
         Assert.IsTrue(result, "Remove toolbar");
         Assert.IsFalse(cui.Toolbars.Contains(tbToRemove), "Toolbars no longer contains tbToRemove");

         result = cui.RemoveToolbar(tbToRemove.Name);
         Assert.IsFalse(result, "Remove toolbar again");

         result = cui.RemoveToolbar("New Toolbar");
         Assert.IsFalse(result, "Remove toolbar not in Toolbars");
      }

      [TestMethod]
      public void WriteTest()
      {
         //Write cui to memstream.
         MemoryStream resultStream = new MemoryStream();
         Boolean result = cui.Write(resultStream);
         Assert.IsTrue(result, "Write result");

         //Reset stream position.
         resultStream.Seek(0, SeekOrigin.Begin);

         //Read source as stream.
         StreamReader sourceReader = new StreamReader(new FileStream(cuiFile, FileMode.Open));
         String sectionName = String.Empty;

         while (!sourceReader.EndOfStream)
         {
            //Get next source line (skip empty lines).
            String sourceLine = String.Empty;
            while (sourceLine == String.Empty && !sourceReader.EndOfStream)
               sourceLine = sourceReader.ReadLine();

            //Store source section name.
            if (CuiFile.sectionMatchPattern.IsMatch(sourceLine))
               sectionName = CuiFile.sectionReplacePattern.Replace(sourceLine, "");

            Boolean sectionFound = false;
            Boolean lineFound = false;
            String resultLine = String.Empty;
            StreamReader resultReader = new StreamReader(resultStream);

            //Read through result until the section is found.
            while(!resultReader.EndOfStream && !sectionFound)
            {
               resultLine = resultReader.ReadLine();
               if (Regex.IsMatch(resultLine, @"\[" + sectionName + @"\]"))
               {
                  sectionFound = true;
                  lineFound = resultLine == sourceLine;
               }
            }

            //Read through the result until the line is found, or the next section is encountered.
            while(!resultReader.EndOfStream && !lineFound)
            {
               resultLine = resultReader.ReadLine();
               lineFound = resultLine == sourceLine;
               if (CuiFile.sectionMatchPattern.IsMatch(resultLine))
                  break;
            }

            Assert.IsTrue(lineFound, "Line found");

            //Reset the result stream for the next line.
            resultStream.Seek(0, SeekOrigin.Begin);
         }

         sourceReader.Close();
         resultStream.Close();
      }


      [TestMethod]
      public void HiddenTest()
      {
         CuiToolbar tb = new CuiToolbar("Test");
         Assert.AreEqual("0", tb.Properties["Hidden"]);
         Assert.IsFalse(tb.Hidden);

         tb.Hidden = true;
         Assert.IsTrue(tb.Hidden);
         Assert.AreEqual("1", tb.Properties["Hidden"]);
      }

      [TestMethod]
      public void BoundsTestMethod()
      {
         CuiToolbar tb = new CuiToolbar("Test");
         Assert.AreEqual("16 100 150 200 213", tb.Properties["CurPos"]);
         Assert.AreEqual(new Rectangle(100, 150, 100, 63), tb.Bounds);

         tb.Bounds = new Rectangle(50, 60, 200, 70);
         Assert.AreEqual(new Rectangle(50, 60, 200, 70), tb.Bounds);
         Assert.AreEqual("16 50 60 250 130", tb.Properties["CurPos"]);
      }
   }

}
