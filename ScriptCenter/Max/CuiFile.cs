using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace ScriptCenter.Max
{
class CuiFile
{
   internal const String CuiDataSectionName    = "CUIData";
   internal const String WindowCountItemName   = "WindowCount";
   internal const String CuiWindowsSectionName = "CUIWindows";

   internal static Regex sectionMatchPattern   = new Regex(@"^\[[\w ]+\]$", RegexOptions.Compiled); //Matches "[section title]"
   internal static Regex sectionReplacePattern = new Regex(@"[\[\]\r\n]", RegexOptions.Compiled);
   internal static Regex toolbarEntryPattern   = new Regex(@"^F\d{3}=(T|S):([\w ]+)$", RegexOptions.Compiled); //Matches "F000=T:Anything"
   internal static Regex propertyPattern       = new Regex(@"^(\w+)=(.+)$", RegexOptions.Compiled); //Matches "anything=anything else"
   internal static Regex itemCountPattern      = new Regex(@"^ItemCount=(\d+)$", RegexOptions.Compiled); //Matches "ItemCount=10"
   internal static Regex itemPattern           = new Regex(@"^Item\d+=(.+)$", RegexOptions.Compiled); //Matches "Item1=anything"
   internal static Regex flyOffPattern         = new Regex(@"(^FlyOffCt\d+=.+$)|(^Fly\d+=.+$)", RegexOptions.Compiled);

   public String File { get; set; }
   private List<CuiToolbar> toolbars;
   private List<CuiSection> otherSections;

   /// <summary>
   /// All toolbars in the CuiFile.
   /// </summary>
   public IList<CuiToolbar> Toolbars 
   {
      get { return this.toolbars.AsReadOnly(); }
   }

   /// <summary>
   /// All non-toolbar sections in the CuiFile.
   /// </summary>
   public IList<CuiSection> OtherSections
   {
      get { return this.otherSections.AsReadOnly(); }
   }

   public CuiFile() 
   {
      this.File          = String.Empty;
      this.toolbars      = new List<CuiToolbar>();
      this.otherSections = new List<CuiSection>();
   }
   public CuiFile(String file) : this()
   {
      this.File = file;
      this.Read();
   }

   /// <summary>
   /// Returns true if the CuiFile contains a toolbar definition with the given name.
   /// </summary>
   public Boolean ContainsToolbar(String name)
   {
      return this.toolbars.Exists(t => t.Name == name);
   }

   /// <summary>
   /// Returns the toolbar object with the given name, null if it isn't present in the CuiFile.
   /// </summary>
   public CuiToolbar GetToolbar(String name)
   {
      return this.toolbars.Find(t => t.Name == name);
   }

   /// <summary>
   /// Adds the toolbar to the CuiFile and returns true if it was added, false if a toolbar with the same name already exists.
   /// </summary>
   public Boolean AddToolbar(CuiToolbar toolbar)
   {
      if (this.toolbars.Exists(t => t.Name == toolbar.Name))
         return false;
         
      this.toolbars.Add(toolbar);
      return true;
   }

   /// <summary>
   /// Adds a new toolbar to the CuiFile and returns the CuiToolbar object.
   /// </summary>
   /// <param name="name">The name of the toolbar to create.</param>
   /// <param name="numButtons">The number of (image) buttons to allocate size for.</param>
   /// <param name="numSeparators">The number of separators to allocate size for.</param>
   public CuiToolbar AddToolbar(String name, Int32 numButtons, Int32 numSeparators)
   {
      CuiToolbar toolbar = new CuiToolbar(name, numButtons, numSeparators);
      if (this.AddToolbar(toolbar))
         return toolbar;
      else
         return null;
   }

   /// <summary>
   /// Removes the toolbar object from the CuiFile and returns true anything was removed.
   /// </summary>
   public Boolean RemoveToolbar(CuiToolbar toolbar)
   {
      return this.toolbars.Remove(toolbar);
   }

   /// <summary>
   /// If a toolbar with the given name exists in the CuiFile, removes it and returns true.
   /// Returns false if no toolbar with that name exists.
   /// </summary>
   public Boolean RemoveToolbar(String name)
   {
      return this.RemoveToolbar(this.GetToolbar(name));
   }

   /// <summary>
   /// Reads and parses the CuiFile.
   /// </summary>
   public Boolean Read() 
   {
      if (!System.IO.File.Exists(this.File))
         return false;

      using (FileStream stream = new FileStream(File, FileMode.Open))
      {
         return this.Read(stream);
      }
   }

   internal Boolean Read(Stream stream) 
   {
      StreamReader reader = new StreamReader(stream);
      while (!reader.EndOfStream)
      {
         String line = reader.ReadLine();

         //Skip to next line if it's not a section heading.
         if (sectionMatchPattern.IsMatch(line))
         {
            String sectionName = sectionReplacePattern.Replace(line, "");
            if (sectionName == CuiDataSectionName)
               continue; //Skip CuiData section.
            else if (sectionName == CuiWindowsSectionName)
               readCuiWindowsSection(reader);
            else if (this.GetToolbar(sectionName) != null)
               readCuiToolbarSection(reader, sectionName);
            else
               readCuiSection(reader, sectionName);
         }
      }

      return true;
   }

   private void readCuiWindowsSection(StreamReader reader)
   {
      while (!reader.EndOfStream)
      {
         if (reader.Peek() == '[')
            break;

         String line = reader.ReadLine();

         //Check if the line matches F000=T: or F000=S:
         if (toolbarEntryPattern.IsMatch(line))
         {
            String[] splitLine = toolbarEntryPattern.Split(line);
            CuiToolbar tb = new CuiToolbar();
            tb.Name = splitLine[2];
            tb.EntryType = splitLine[1];
            this.toolbars.Add(tb);
         }
      }
   }

   private void readCuiSection(StreamReader reader, String sectionName)
   {
      CuiSection section = new CuiSection();
      section.Name = sectionName;

      while (!reader.EndOfStream)
      {
         if (reader.Peek() == '[')
            break;
            
         String line = reader.ReadLine();
         if (propertyPattern.IsMatch(line))
         {
            String[] propSplit = propertyPattern.Split(line);
            section.SetProperty(propSplit[1], propSplit[2]);
         }
      }
      this.otherSections.Add(section);
   }

   private void readCuiToolbarSection(StreamReader reader, String sectionName)
   {
      CuiToolbar tb = this.GetToolbar(sectionName);
      while (!reader.EndOfStream)
      {
         if (reader.Peek() == '[')
            break;

         String line = reader.ReadLine();
         if (itemCountPattern.IsMatch(line))
            continue;
         else if (itemPattern.IsMatch(line))
            tb.Items.Add(CuiToolbarItem.NewItemFromValue(itemPattern.Split(line)[1]));
         else if (flyOffPattern.IsMatch(line))
            tb.Items[tb.Items.Count - 1].FlyOffItems.Add(line);
         else if (propertyPattern.IsMatch(line))
         {
            String[] propSplit = propertyPattern.Split(line);
            tb.SetProperty(propSplit[1], propSplit[2]);
         }
      }
   }


   /// <summary>
   /// Writes the CuiFile object to a file.
   /// </summary>
   public Boolean Write() 
   {
      Boolean result = false;
      try
      {
         //Create directory for output.
         String dir = new FileInfo(this.File).DirectoryName;
         if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir);

         //Create backup.
         if (System.IO.File.Exists(this.File))
            System.IO.File.Copy(this.File, this.File + ".bak", true);

         using (FileStream stream = new FileStream(this.File, FileMode.Create))
         {
            result = this.Write(stream);
         }
      }
      catch (Exception e)
      {
         //Restore backup.
         if (System.IO.File.Exists(this.File + ".bak"))
            System.IO.File.Copy(this.File + ".bak", this.File, true);

         Console.WriteLine(e.Message);
      }
      return result;
   }


   internal Boolean Write(Stream stream) 
   {
      StreamWriter writer = new StreamWriter(stream);
            
      //Write CUIData section.
      writer.WriteLine("[{0}]", CuiDataSectionName);
      writer.WriteLine("{0}={1}", WindowCountItemName, this.toolbars.Count.ToString());
            
      //Write CuiWindows section.
      writer.WriteLine("[{0}]", CuiWindowsSectionName);
      for (int i = 0; i < this.toolbars.Count; i++)
         writer.WriteLine("F{0}={1}:{2}", i.ToString("D3"), this.toolbars[i].EntryType, this.toolbars[i].Name);

      //Write toolbar sections.
      foreach (CuiToolbar toolbar in this.toolbars)
         this.writeToolbar(writer, toolbar);

      //Write other sections.
      foreach (CuiSection section in this.otherSections)
         this.writeSection(writer, section);

      writer.Flush();

      return true;
   }

   private void writeSection(StreamWriter writer, CuiSection section)
   {
      writer.WriteLine("[{0}]", section.Name);
      //Write properties
      foreach (KeyValuePair<String, String> prop in section.Properties)
         writer.WriteLine("{0}={1}", prop.Key, prop.Value);
   }

   private void writeToolbar(StreamWriter writer, CuiToolbar toolbar)
   {
      this.writeSection(writer, toolbar);

      //Write items.
      if (toolbar.Items.Count > 0)
      {
         writer.WriteLine("ItemCount={0}", toolbar.Items.Count.ToString());
         for (int i = 0; i < toolbar.Items.Count; i++)
         {
            writer.WriteLine("Item{0}={1}", i.ToString(), toolbar.Items[i].Value);
            foreach (String flyoff in toolbar.Items[i].FlyOffItems)
               writer.WriteLine(flyoff);
         }
      }
   }



   /// <summary>
   /// Gets the currently active cui file from 3dsmax.
   /// </summary>
   public static String MaxGetActiveCuiFile()
   {
      try
      {
         return ManagedServices.MaxscriptSDK.ExecuteStringMaxscriptQuery("cui.getConfigFile()");
      }
      catch (Exception e)
      {
         Console.WriteLine(e.Message);
         return String.Empty;
      }
   }

   /// <summary>
   /// Saves the current Cui config in the supplied file.
   /// </summary>
   public static void MaxBackupCuiFile(String file)
   {
      try
      {
         ManagedServices.MaxscriptSDK.ExecuteMaxscriptCommand("cui.saveConfigAs @\"" + file + "\"");
      }
      catch (Exception e)
      {
         Console.WriteLine(e.Message);
      }
   }

   /// <summary>
   /// Signals 3dsmax to load the cui file.
   /// </summary>
   public void MaxLoadCuiFile()
   {
      try
      {
         ManagedServices.MaxscriptSDK.ExecuteMaxscriptCommand("cui.loadConfig @\"" + this.File + "\"");
      }
      catch (Exception e)
      {
         Console.WriteLine(e.Message);
      }
   }
}

   
}
