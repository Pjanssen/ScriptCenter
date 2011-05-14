using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace ScriptCenter.Installer.Actions
{
internal struct KeyboardAction
{
    public String MacroName;
    public String MacroCategory;
    public Keys Keys;
    public Int32 TableId;
    public Int32 PersistentId;
}
internal class KeyboardActionsFile
{
    public KeyboardActionsFile(String file)
    {
        this.File = file;
        this.Actions = new List<KeyboardAction>();
    }

    public const Int32 MainTableId = 0;
    public const Int32 MacroTableId = 647394;


    /// <summary>
    /// The KBD file to read/write.
    /// </summary>
    public String File { get; set; }

    /// <summary>
    /// The KeyboardActions read from or to be written to the KBD file.
    /// </summary>
    public List<KeyboardAction> Actions { get; set; }

    public Boolean AddAction(String macroName, String macroCategory, Keys keys)
    {
        if (this.Actions.Exists(a => a.MacroName.Equals(macroName) && a.MacroCategory.Equals(macroCategory) && a.Keys == keys))
            return false;

        KeyboardAction action = new KeyboardAction { MacroName = macroName, MacroCategory = macroCategory, Keys = keys, TableId = MacroTableId };
        this.Actions.Add(action);
        return true;
    }

    public Boolean RemoveAction(KeyboardAction action)
    {
        return this.Actions.Remove(action);
    }
    public Int32 RemoveAction(String macroName, String macroCategory)
    {
        Boolean removedAction = true;
        Int32 numActionsRemoved = 0;
        while (removedAction)
        {
            KeyboardAction action = this.Actions.Find(a => a.MacroName.Equals(macroName) && a.MacroCategory.Equals(macroCategory));
            removedAction = this.RemoveAction(action);
            if (removedAction)
                numActionsRemoved++;
        }

        return numActionsRemoved;
    }
    public Int32 RemoveAction(Int32 persistentId)
    {
        Boolean removedAction = true;
        Int32 numActionsRemoved = 0;
        while (removedAction)
        {
            KeyboardAction action = this.Actions.Find(a => a.PersistentId == persistentId);
            removedAction = this.RemoveAction(action);
            if (removedAction)
                numActionsRemoved++;
        }

        return numActionsRemoved;
    }

    /// <summary>
    /// Gets the currently active keyboard actions file from 3dsmax.
    /// </summary>
    public static String MaxGetActiveKbdFile() 
    {
        try
        {
            return ManagedServices.MaxscriptSDK.ExecuteStringMaxscriptQuery("actionMan.getKeyboardFile()");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return String.Empty;
        }
    }

    /// <summary>
    /// Tells 3dsmax to load the keyboard actions file.
    /// </summary>
    public void MaxLoadKbdFile() 
    {
        try
        {
            ManagedServices.MaxscriptSDK.ExecuteMaxscriptCommand("actionMan.loadKeyboardFile " + this.File);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }


    private Keys modKeycodeToKeys(Int32 keycode)
    {
        Keys keys = Keys.None;
        if ((keycode & 4) == 4) keys |= Keys.Shift;
        if ((keycode & 8) == 8) keys |= Keys.Control;
        if ((keycode & 16) == 16) keys |= Keys.Alt;
        return keys;
    }
    private Int32 keysToModKeycode(Keys keys)
    {
        Int32 keycode = 3;
        if ((keys & Keys.Shift) == Keys.Shift) keycode += 4;
        if ((keys & Keys.Control) == Keys.Control) keycode += 8;
        if ((keys & Keys.Alt) == Keys.Alt) keycode += 16;
        return keycode;
    }


    /// <summary>
    /// Reads and parses the KBD file.
    /// </summary>
    /// <returns>True when successful.</returns>
    public Boolean Read()
    {
        if (!System.IO.File.Exists(this.File))
            return false;

        using (StreamReader r = new StreamReader(this.File))
        {
            this.Actions.Clear();

            while(!r.EndOfStream)
            {
                try
                {
                    //KBD Line format:
                    //18=7 38 51 1127307088
                    //index=modkeycode keycode persistent_id table_id
                    //9=3 82 SmartScale`Tools 647394
                    //index=modkeycode keycode macroname`macrocategory table_id

                    String line = r.ReadLine();
                    List<String> line_split = new List<string>();
                    String[] split = line.Split('=');
                    line_split.Add(split[0]);
                    line_split.AddRange(split[1].Split(' '));

                    if (line_split.Count < 5)
                        continue;

                    KeyboardAction action = new KeyboardAction();
                    action.Keys = modKeycodeToKeys(Int32.Parse(line_split[1])) | (Keys)Enum.Parse(typeof(Keys), line_split[2]);
                    action.TableId = Int32.Parse(line_split[line_split.Count - 1]);

                    if (line_split.Count > 5 || !Int32.TryParse(line_split[3], out action.PersistentId))
                    {
                        String macro = line_split[3];
                        for (int i = 4; i < (line_split.Count - 1); i++)
                            macro += " " + line_split[i];

                        if (System.Text.RegularExpressions.Regex.IsMatch(macro, @"\S`\S"))
                        {
                            String[] macro_split = macro.Split('`');
                            action.MacroName = macro_split[0];
                            action.MacroCategory = macro_split[1];
                        }
                        else
                        {
                            action.MacroName = macro;
                            action.MacroCategory = String.Empty;
                        }
                    }

                    this.Actions.Add(action);
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        return true;
    }


    /// <summary>
    /// Writes all actions to a KBD file.
    /// </summary>
    /// <returns>True upon success.</returns>
    public Boolean Write()
    {
        //Create backup.
        if (System.IO.File.Exists(this.File))
            System.IO.File.Copy(this.File, this.File + ".bak", true);

        try
        {
            using (StreamWriter w = new StreamWriter(this.File, false))
            {
                Int32 table_index = 0;
                Int32 prevTableId = 0;
                foreach(KeyboardAction action in this.Actions)
                {
                    if (action.TableId != prevTableId)
                        table_index = 0;

                    //Write index.
                    w.Write(table_index);
                    w.Write('=');

                    //Write modifier keycode.
                    w.Write(keysToModKeycode(action.Keys));
                    w.Write(' ');
                    
                    //Write keycode.
                    w.Write((Int32)(action.Keys & Keys.KeyCode));
                    w.Write(' ');

                    //Write persistent id or macro name and category.
                    if (action.PersistentId == 0 && !action.MacroName.Equals(String.Empty))
                    {
                        w.Write(action.MacroName);
                        if (!action.MacroCategory.Equals(String.Empty))
                        {
                            w.Write('`');
                            w.Write(action.MacroCategory);
                        }
                    }
                    else
                        w.Write(action.PersistentId);

                    w.Write(' ');

                    //Write table id.
                    w.Write(action.TableId);
                    w.Write(Environment.NewLine);
                    
                    table_index++;
                    prevTableId = action.TableId;
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
