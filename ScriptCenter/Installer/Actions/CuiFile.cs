//  Copyright 2011 P.J. Janssen
//  This file is part of ScriptCenter.

//  ScriptCenter is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.

//  ScriptCenter is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.

//  You should have received a copy of the GNU General Public License
//  along with ScriptCenter.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace ScriptCenter.Installer.Actions
{
    internal class CuiFile
    {
        internal class CuiSection
        {
            public String Name;
            public List<KeyValuePair<String, String>> Items;

            public CuiSection()
            {
                this.Items = new List<KeyValuePair<String, String>>();
            }
            public CuiSection(String name) : this()
            {
                this.Name = name;
            }

            public void AddItem(String key, String value)
            {
                if (!this.Items.Exists(i => i.Key == key))
                    this.Items.Add(new KeyValuePair<string, string>(key, value));
            }
        }

        public const String CuiDataSectionName = "CUIData";
        public const String WindowCountKeyName = "WindowCount";
        public const String CuiWindowsSectionName = "CUIWindows";

        public CuiFile(String file)
        {
            this.File = file;
            this.Sections = new List<CuiSection>();
        }

        /// <summary>
        /// The Cui file to read/write.
        /// </summary>
        public String File { get; set; }

        public List<CuiSection> Sections { get; set; }

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
        /// Tells 3dsmax to load the cui file.
        /// </summary>
        public void MaxLoadCuiFile()
        {
            try
            {
                ManagedServices.MaxscriptSDK.ExecuteMaxscriptCommand("cui.loadConfig " + this.File);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Adds an empty toolbar to the cui file.
        /// </summary>
        public Boolean AddToolbar(String name)
        {
            if (this.Sections.Exists(s => s.Name.Equals(name)))
                return false;
            
            //Increment the WindowCount property in CUIData section.
            CuiSection cuiDataSection = this.Sections.Find(s => s.Name == CuiDataSectionName);
            if (cuiDataSection == null)
                return false;
            KeyValuePair<String, String> windowCountItem = cuiDataSection.Items.Find(i => i.Key == WindowCountKeyName);
            if (windowCountItem.Key == null)
                return false;
            Int32 windowCount = Int32.Parse(windowCountItem.Value) + 1;
            cuiDataSection.Items.Remove(windowCountItem);
            cuiDataSection.AddItem(WindowCountKeyName, windowCount.ToString());

            //Add the window to the CUIWindows section.
            CuiSection cuiWindowsSection = this.Sections.Find(s => s.Name == CuiWindowsSectionName);
            if (cuiWindowsSection == null)
                return false;
            String cuiWindowsKey = "F" + (windowCount - 1).ToString("D3");
            String cuiWindowsValue = "T:" + name;
            cuiWindowsSection.AddItem(cuiWindowsKey, cuiWindowsValue);

            //Add the toolbar section.
            CuiSection toolbarSection = new CuiSection(name);
            toolbarSection.AddItem("ItemCount", "0");
            toolbarSection.AddItem("Rank", "0");
            toolbarSection.AddItem("SubRank", "0");
            toolbarSection.AddItem("Hidden", "0");
            toolbarSection.AddItem("FRect", "262 249 320 310");
            toolbarSection.AddItem("DRect", "2147483647 2147483647 -2147483648 -2147483648");
            toolbarSection.AddItem("DRectPref", "2147483647 2147483647 -2147483648 -2147483648");
            toolbarSection.AddItem("DPanel", "0");
            toolbarSection.AddItem("Tabbed", "0");
            toolbarSection.AddItem("TabCt", "0");
            toolbarSection.AddItem("CurTab", "-1");
            toolbarSection.AddItem("CurPos", "16 262 249 320 310");
            toolbarSection.AddItem("CType", "1");
            toolbarSection.AddItem("ToolbarRows", "1");
            toolbarSection.AddItem("ToolbarType", "16");

            this.Sections.Add(toolbarSection);

            return true;
        }

        /// <summary>
        /// Removes the specified toolbar.
        /// </summary>
        public Boolean RemoveToolbar(String name)
        {
            if (!this.Sections.Exists(s => s.Name.Equals(name)))
                return false;

            //Decrement the WindowCount property in CUIData section.
            CuiSection cuiDataSection = this.Sections.Find(s => s.Name == CuiDataSectionName);
            if (cuiDataSection == null)
                return false;
            KeyValuePair<String, String> windowCountItem = cuiDataSection.Items.Find(i => i.Key == WindowCountKeyName);
            if (windowCountItem.Key == null)
                return false;
            Int32 windowCount = Int32.Parse(windowCountItem.Value) - 1;
            cuiDataSection.Items.Remove(windowCountItem);
            cuiDataSection.AddItem(WindowCountKeyName, windowCount.ToString());

            //Remove the window from the CUIWindows section.
            CuiSection cuiWindowsSection = this.Sections.Find(s => s.Name == CuiWindowsSectionName);
            if (cuiWindowsSection == null)
                return false;
            String windowValueName = "T:" + name;
            List<KeyValuePair<String, String>> newWindowsItems = new List<KeyValuePair<string, string>>();
            Boolean windowItemFound = false;
            for (int i = 0; i < cuiWindowsSection.Items.Count; i++)
            {
                KeyValuePair<String, String> item = cuiWindowsSection.Items[i];
                if (item.Value == windowValueName)
                {
                    windowItemFound = true;
                    continue;
                }
                else if (windowItemFound)
                {
                    String newKey = "F";
                    Int32 index = Int32.Parse(Regex.Replace(item.Key, "F", ""));
                    newKey += (index - 1).ToString("D3");
                    KeyValuePair<String, String> newItem = new KeyValuePair<String, String>(newKey, item.Value);
                    newWindowsItems.Add(newItem);
                }
                else
                    newWindowsItems.Add(item);
            }
            cuiWindowsSection.Items = newWindowsItems;

            //Remove the toolbar section
            this.Sections.RemoveAll(s => s.Name == name);

            return true;
        }

        /// <summary>
        /// Adds an item to a toolbar.
        /// </summary>
        /// <param name="toolbarName">The name of the toolbar to add the item to.</param>
        /// <param name="macroName">The name of the macroscript for this item.</param>
        /// <param name="macroCategory">The cateogry of the macroscript for this item.</param>
        /// <param name="itemText">The text to show on the item.</param>
        /// <returns>True if an item was added, false if it failed or already exists.</returns>
        public Boolean AddToolbarItem(String toolbarName, String macroName, String macroCategory, String itemText)
        {
            return true;
        }

        /// <summary>
        /// Removes any item assigned to the given macroscript on any toolbar.
        /// </summary>
        public Boolean RemoveToolbarItem(String macroName, String macroCategory)
        {
            return true;
        }

        /// <summary>
        /// Reads and parses the cui file.
        /// </summary>
        public Boolean Read()
        {
            if (!System.IO.File.Exists(this.File))
               return false;

            this.Sections.Clear();

            using (StreamReader r = new StreamReader(this.File))
            {
                CuiSection section = null;
                while (!r.EndOfStream)
                {
                    String line = r.ReadLine();
                    // Check if line is a new section "[section title]"
                    if (Regex.IsMatch(line, @"^\[[\w ]+\]"))
                    {
                        section = new CuiSection();
                        section.Name = Regex.Replace(line, @"[\[\]\r\n]", "");
                        this.Sections.Add(section);
                    }
                    else
                    {
                        if (section == null)
                            return false;

                        String key = Regex.Replace(line, @"=.*", "");
                        String value = Regex.Replace(line, @".*=", "");
                        section.Items.Add(new KeyValuePair<String, String>(key, value));
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Writes the cui file to disk.
        /// </summary>
        public Boolean Write()
        {
            //Create backup.
            if (System.IO.File.Exists(this.File))
                System.IO.File.Copy(this.File, this.File + ".bak", true);

            try
            {
                using (StreamWriter w = new StreamWriter(this.File, false))
                {
                    foreach (CuiSection section in this.Sections)
                    {
                        //Write section start.
                        w.WriteLine("[{0}]", section.Name);

                        //Write items.
                        foreach (KeyValuePair<String, String> item in section.Items)
                        {
                            w.WriteLine("{0}={1}", item.Key, item.Value);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                //Restore backup.
                if (System.IO.File.Exists(this.File + ".bak"))
                    System.IO.File.Copy(this.File + ".bak", this.File, true);

                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }
    }
}
