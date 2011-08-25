﻿//  Copyright 2011 P.J. Janssen
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

namespace ScriptCenter.Max
{
    internal class CuiFile
    {
        public const String SectionCuiData = "CUIData";
        public const String SectionCuiWindows = "CUIWindows";
        public const String KeyWindowCount = "WindowCount";
        public const String KeyItemCount = "ItemCount";

        public CuiFile()
        {
            this.Sections = new List<CuiSection>();
        }
        public CuiFile(String file) : this()
        {
            this.File = file;
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
                ManagedServices.MaxscriptSDK.ExecuteMaxscriptCommand("cui.loadConfig @\"" + this.File + "\"");
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
            CuiSection cuiDataSection = this.Sections.Find(s => s.Name == SectionCuiData);
            if (cuiDataSection == null)
                return false;
            CuiItem windowCountItem = cuiDataSection.Items.Find(i => i.Key == KeyWindowCount);
            if (windowCountItem.Key == null)
                return false;
            Int32 windowCount = Int32.Parse(windowCountItem.Value) + 1;
            windowCountItem.Value = windowCount.ToString();

            //Add the window to the CUIWindows section.
            CuiSection cuiWindowsSection = this.Sections.Find(s => s.Name == SectionCuiWindows);
            if (cuiWindowsSection == null)
                return false;
            String cuiWindowsKey = "F" + (windowCount - 1).ToString("D3");
            String cuiWindowsValue = "T:" + name;
            cuiWindowsSection.AddItem(cuiWindowsKey, cuiWindowsValue);

            //Add the toolbar section.
            CuiSection toolbarSection = new CuiSection(name);
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
            toolbarSection.AddItem("ItemCount", "0");

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
            CuiSection cuiDataSection = this.Sections.Find(s => s.Name == SectionCuiData);
            if (cuiDataSection == null)
                return false;
            CuiItem windowCountItem = cuiDataSection.Items.Find(i => i.Key == KeyWindowCount);
            if (windowCountItem.Key == null)
                return false;
            Int32 windowCount = Int32.Parse(windowCountItem.Value) - 1;
            windowCountItem.Value = windowCount.ToString();

            //Remove the window from the CUIWindows section.
            CuiSection cuiWindowsSection = this.Sections.Find(s => s.Name == SectionCuiWindows);
            if (cuiWindowsSection == null)
                return false;
            String windowValueName = "T:" + name;
            CuiItem itemToRemove = null;
            for (int i = 0; i < cuiWindowsSection.Items.Count; i++)
            {
                CuiItem item = cuiWindowsSection.Items[i];
                if (itemToRemove == null && item.Value == windowValueName)
                {
                    itemToRemove = item;
                    continue;
                }
                else
                {
                    String newKey = "F";
                    Int32 index = Int32.Parse(Regex.Replace(item.Key, "F", ""));
                    newKey += (index - 1).ToString("D3");
                    item.Key = newKey;
                }
            }
            if (itemToRemove != null)
                cuiWindowsSection.Items.Remove(itemToRemove);

            //Remove the toolbar section
            this.Sections.RemoveAll(s => s.Name == name);

            return true;
        }


        private Boolean AddItem(CuiSection toolbar, String value)
        {
            CuiItem itemCountProp = toolbar.Items.Find(p => p.Key == KeyItemCount);
            if (itemCountProp == null)
                return false;

            Int32 itemCount = Int32.Parse(itemCountProp.Value) + 1;
            itemCountProp.Value = itemCount.ToString();

            String itemKey = "Item" + (itemCount - 1).ToString();
            toolbar.AddItem(itemKey, value);

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
        public Boolean AddToolbarButton(String toolbarName, String macroName, String macroCategory, String itemText, String tooltipText)
        {
            //Button item format
            //Item0=2|0|0|31|3|647394|createOutlinerInstaller`Outliner Dev|0|0|"Create Outliner Installer"|"Create Outliner Installer"|-1|
                // item type
                    // #define MB_TYPE_KBD                 1
                    // #define MB_TYPE_SCRIPT              2
                    // #define MB_TYPE_ACTION              3
                    // #define MB_TYPE_ACTION_CUSTOM       4
                // width (where 0 is auto-size?)
                // height (where 0 is auto-size?)
                // ?
                // ?
                // action_table_id
                // macro_name`macro_category
                // ?
                // ?
                // tooltip_text
                // button_label (empty if not set)
                // icon_index (-1 if using label)
                // icon_set (empty if not set)
            
            CuiSection toolbarSection = this.Sections.Find(s => s.Name == toolbarName);
            if (toolbarSection == null)
                return false;

            String buttonFormat = "2|0|0|31|3|647394|{0}`{1}|0|0|\"{2}\"|\"{3}\"|-1|";
            String itemValue = String.Format(buttonFormat, macroName, macroCategory, tooltipText, itemText);

            if (toolbarSection.Items.Exists(i => i.Value == itemValue))
                return false;

            return this.AddItem(toolbarSection, itemValue);
        }
        /// <summary>
        /// Adds a separator to the toolbar.
        /// </summary>
        /// <param name="toolbarName">The name of the toolbar to add the separator to.</param>
        public Boolean AddToolbarSeparator(String toolbarName)
        {
            //Separator item format
            //Item5=3|6|16|31|1
                // item type ?
                // width
                // height
                // ?
                // ?

            CuiSection toolbarSection = this.Sections.Find(s => s.Name == toolbarName);
            if (toolbarSection == null)
                return false;

            return this.AddItem(toolbarSection, "3|6|16|31|1");
        }
        /// <summary>
        /// Not implemented yet.
        /// </summary>
        public Boolean AddToolbarFlyOffItem(String toolbarName)
        {
            throw new NotImplementedException();
            /*
             * This is what I've been able to figure out about the flyoffs. 
             * I fear that it might not be possible to use them with macroscripts.
             * 
             * Item2=0|0|0|50031|0|31|-1|-1|-1|-1|0|0|0||Maintoolbar|70
             * FlyOffCt2=4|0|300|3
               * number of subitems
               * ?
               * timeout (time in ms it takes before the flyoff opens)
               * ?
               * 
            * Fly0200=-1|-1|-1|1|Maintoolbar|52
               * SDK Doc: These four data members are indices into the image list. 
               * They indicate which images to use for each of the four possible button states:
               * int iOutEn;
               * int iInEn;
               * int iOutDis;
               * int iInDis;    
               * MaxBmpFileIcon* mpIcon;
               * MaxBmpFileIcon* mpInIcon;
               * 
               * note: it seems that these Fly items don't specify what the button will do, merely set the image of the button.
            */
        }

        private void RemoveItem(CuiSection toolbar, CuiItem item)
        {
            CuiItem itemCountProp = toolbar.Items.Find(p => p.Key == KeyItemCount);
            if (itemCountProp == null)
                return;

            Int32 itemCount = Int32.Parse(itemCountProp.Value) - 1;
            itemCountProp.Value = itemCount.ToString();

            Int32 itemIndex = Int32.Parse(Regex.Replace(item.Key, "^Item", ""));

            foreach (CuiItem i in toolbar.Items)
            {
                if (Regex.IsMatch(i.Key, @"^Item\d+"))
                {
                    Int32 iIndex = Int32.Parse(Regex.Replace(i.Key, "^Item", ""));
                    if (iIndex > itemIndex)
                        i.Key = "Item" + (iIndex - 1).ToString();
                }
            }
            toolbar.Items.Remove(item);
        }
        /// <summary>
        /// Removes any item assigned to the given macroscript from the given toolbar.
        /// </summary>
        public Boolean RemoveItem(String toolbarName, String macroName, String macroCategory)
        {
            CuiSection toolbarSection = this.Sections.Find(s => s.Name == toolbarName);
            if (toolbarSection == null)
                return false;

            Boolean itemRemoved = false;
            List<CuiItem> itemsToRemove = new List<CuiItem>();
            foreach (CuiItem item in toolbarSection.Items)
            {
                if (Regex.IsMatch(item.Value, (macroName + "`" + macroCategory)))
                {
                    itemRemoved = true;
                    itemsToRemove.Add(item);
                }
            }

            foreach (CuiItem item in itemsToRemove)
                this.RemoveItem(toolbarSection, item);

            return itemRemoved;
        }
        /// <summary>
        /// Removes any item assigned to the given macroscript from any toolbar.
        /// </summary>
        public Boolean RemoveItem(String macroName, String macroCategory)
        {
            Boolean itemRemoved = false;
            foreach (CuiSection section in this.Sections)
            {
                if (this.RemoveItem(section.Name, macroName, macroCategory))
                    itemRemoved = true;
            }
            return itemRemoved;
        }

        /// <summary>
        /// Reads and parses a CUI File.
        /// </summary>
        /// <returns></returns>
        public Boolean Read() 
        {
            if (!System.IO.File.Exists(this.File))
                return false;

            using (FileStream stream = new FileStream(File, FileMode.Open))
            {
                return this.Read(stream);
            }
        }
        /// <summary>
        /// Reads and parses a CUI File from a Stream.
        /// </summary>
        public Boolean Read(Stream stream)
        {
            this.Sections.Clear();

            using (StreamReader reader = new StreamReader(stream))
            {
                CuiSection section = null;
                while (!reader.EndOfStream)
                {
                    String line = reader.ReadLine();
                    if (line == String.Empty)
                        continue;

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

                        CuiItem prop = new CuiItem();
                        prop.Key = Regex.Replace(line, @"=.*", "");
                        prop.Value = Regex.Replace(line, @".*=", "");
                        section.Items.Add(prop);
                    }
                }
            }
            

            return true;
        }

        /// <summary>
        /// Writes the CUI File.
        /// </summary>
        /// <returns></returns>
        public Boolean Write() 
        {
            try
            {
                //Create directory for output.
                String dir = new FileInfo(this.File).DirectoryName;
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                //Create backup.
                if (System.IO.File.Exists(this.File))
                    System.IO.File.Copy(this.File, this.File + ".bak", true);

                using (FileStream stream = new FileStream(this.File, FileMode.OpenOrCreate))
                {
                    return this.Write(stream);
                }
            }
            catch(Exception e)
            {
                //Restore backup.
                if (System.IO.File.Exists(this.File + ".bak"))
                    System.IO.File.Copy(this.File + ".bak", this.File, true);
                
                Console.WriteLine(e.Message);
                return false;
            }
        }
        /// <summary>
        /// Writes the CUI File to a Stream.
        /// </summary>
        public Boolean Write(Stream stream)
        {
            using (StreamWriter writer = new StreamWriter(stream))
            {
                foreach (CuiSection section in this.Sections)
                {
                    //Write section start.
                    writer.WriteLine("[{0}]", section.Name);

                    //Write items.
                    foreach (CuiItem item in section.Items)
                    {
                        writer.WriteLine("{0}={1}", item.Key, item.Value);
                    }
                }
            }

            return true;
        }
    }

    internal class CuiSection
    {
        public String Name { get; set; }
        public List<CuiItem> Items { get; set; }

        public CuiSection()
        {
            this.Items = new List<CuiItem>();
        }
        public CuiSection(String name) : this()
        {
            this.Name = name;
        }

        public void AddItem(String key, String value)
        {
            if (!this.Items.Exists(i => i.Key == key))
                this.Items.Add(new CuiItem(key, value));
        }
    }

    internal class CuiItem
    {
        public String Key { get; set; }
        public String Value { get; set; }
        public CuiItem() { }
        public CuiItem(String key, String value)
        {
            this.Key = key;
            this.Value = value;
        }
    }
}
