using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace ScriptCenter.Max
{
internal class KeyboardAction
{
    public String MacroName;
    public String MacroCategory;
    public Keys Keys;
    public Int32 TableId;
    public Int32 PersistentId;

    public KeyboardAction()
    {
        this.MacroName = "";
        this.MacroCategory = "";
        this.Keys = System.Windows.Forms.Keys.None;
    }
}
internal class KbdFile
{
    public KbdFile()
    {
        this.Actions = new List<KeyboardAction>();
    }
    public KbdFile(String file) : this()
    {
        this.File = file;
        this.Read();
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

    /// <summary>
    /// Adds a hotkey assignment to the kbd file.
    /// </summary>
    /// <param name="macroName">The name of the macroscript to be called.</param>
    /// <param name="macroCategory">The category of the macroscript to be called.</param>
    /// <param name="keys">The keys associated with the hotkey assignment.</param>
    /// <param name="replace">Whether to replace an assignment with the same keys if it already exists.</param>
    /// <returns>True if the hotkey assignment was added, false if the exact assignment already existed or if it should not be replaced.</returns>
    public Boolean AddAction(String macroName, String macroCategory, Keys keys, Boolean replace)
    {
        KeyboardAction existingAction = this.Actions.Find(a => a.TableId == MacroTableId && a.Keys == keys);
        if (existingAction != null)
        {
            if (!replace || (existingAction.MacroName == macroName && existingAction.MacroCategory == macroCategory))
                return false;
            else
                this.Actions.Remove(existingAction);
        }

        KeyboardAction action = new KeyboardAction { MacroName = macroName, MacroCategory = macroCategory, Keys = keys, TableId = MacroTableId };
        Int32 insertLocation = this.Actions.FindLastIndex(a => a.TableId == MacroTableId) + 1;
        if (insertLocation == 0)
            insertLocation = this.Actions.Count;

        this.Actions.Insert(insertLocation, action);
        
        return true;
    }

    /// <summary>
    /// Adds a hotkey assignment to the kbd file, replacing an action with the same keys if it already exists.
    /// </summary>
    /// <param name="macroName">The name of the macroscript to be called.</param>
    /// <param name="macroCategory">The category of the macroscript to be called.</param>
    /// <param name="keys">The keys associated with the hotkey assignment.</param>
    /// <returns>True if the hotkey assignment was added, false if the exact assignment already existed.</returns>
    public Boolean AddAction(String macroName, String macroCategory, Keys keys)
    {
        return AddAction(macroName, macroCategory, keys, true);
    }

    public Int32 RemoveAction(KeyboardAction action)
    {
        if (this.Actions.Remove(action))
            return 1;
        else
            return 0;
    }
    public Int32 RemoveAction(String macroName, String macroCategory)
    {
        Boolean removedAction = true;
        Int32 numActionsRemoved = 0;
        while (removedAction)
        {
            KeyboardAction action = this.Actions.Find(a => a.MacroName.Equals(macroName) && a.MacroCategory.Equals(macroCategory));
            if (removedAction = (this.RemoveAction(action) == 1))
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
            if (removedAction = (this.RemoveAction(action) == 1))
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
    public Boolean MaxLoadKbdFile() 
    {
        try
        {
            return ManagedServices.MaxscriptSDK.ExecuteBooleanMaxscriptQuery("actionMan.loadKeyboardFile @\"" + this.File + "\"");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
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

        using (FileStream stream = new FileStream(this.File, FileMode.Open))
        {
            return this.Read(stream);
        }
    }
    /// <summary>
    /// Reads and parses a KBD file from a stream.
    /// </summary>
    /// <returns>True when successful.</returns>
    public Boolean Read(Stream stream)
    {
        using (StreamReader reader = new StreamReader(stream))
        {
            this.Actions.Clear();

            while(!reader.EndOfStream)
            {
                try
                {
                    //KBD Line format:
                    //18=7 38 51 1127307088
                    //index=modkeycode keycode persistent_id table_id
                    //9=3 82 SmartScale`Tools 647394
                    //index=modkeycode keycode macroname`macrocategory table_id

                    String line = reader.ReadLine();
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
                return this.Write(stream);
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
    }
    /// <summary>
    /// Writes all the KBD file to a stream.
    /// </summary>
    /// <returns>True upon success.</returns>
    public Boolean Write(Stream stream)
    {
        using (StreamWriter w = new StreamWriter(stream))
        {
            Int32 table_index = 0;
            Int32 prevTableId = 0;
            foreach (KeyboardAction action in this.Actions)
            {
                if (action.TableId != prevTableId)
                    table_index = 0;

                Int32 modKeyCode = keysToModKeycode(action.Keys);
                Int32 keyCode = (Int32)(action.Keys & Keys.KeyCode);
                String macro;
                if (action.PersistentId == 0 && !action.MacroName.Equals(String.Empty))
                {
                    macro = action.MacroName;
                    if (!action.MacroCategory.Equals(String.Empty))
                        macro += "`" + action.MacroCategory;
                }
                else
                    macro = action.PersistentId.ToString();

                w.WriteLine("{0}={1} {2} {3} {4}", table_index, modKeyCode, keyCode, macro, action.TableId);

                table_index++;
                prevTableId = action.TableId;
            }
        }

        return true;
    }
}
}
