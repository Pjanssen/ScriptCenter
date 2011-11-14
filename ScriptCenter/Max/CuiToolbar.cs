using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ScriptCenter.Max
{
   public class CuiToolbar : CuiSection
   {
      private const String HiddenPropName = "Hidden";
      private const String PositionPropName = "CurPos";

      public const Int32 ToolbarBaseWidth = 16;
      public const Int32 ToolbarBaseHeight = 69;
      public const Int32 ButtonWidth = 32;
      public const Int32 SeparatorWidth = 6;

      public String EntryType { get; set; }
      public List<CuiToolbarItem> Items { get; set; }

      internal CuiToolbar() : base()
      {
         this.Items = new List<CuiToolbarItem>();
      }
      public CuiToolbar(String name) : this()
      {
         this.Name = name;
         this.EntryType = "T";
         this.createDefaultProperties();
      }
      public CuiToolbar(String name, Int32 numButtons, Int32 numSeparators) : this(name)
      {
         this.Bounds = new Rectangle(100, 
                                     150,
                                     ToolbarBaseWidth + numButtons * ButtonWidth + numSeparators * SeparatorWidth, 
                                     ToolbarBaseHeight);
      }

      private void createDefaultProperties()
      {
         String defaultRect = Int32.MaxValue.ToString() + " " + Int32.MaxValue.ToString() + " " +
                              Int32.MinValue.ToString() + " " + Int32.MinValue.ToString();

         this.Properties.Add("Rank", "0");
         this.Properties.Add("SubRank", "0");
         this.Properties.Add(HiddenPropName, "0");
         this.Properties.Add("FRect", defaultRect);
         this.Properties.Add("DRect", defaultRect);
         this.Properties.Add("DRectPref", defaultRect);
         this.Properties.Add("DPanel", "0");
         this.Properties.Add("Tabbed", "0");
         this.Properties.Add("TabCt", "0");
         this.Properties.Add("CurTab", "-1");
         this.Properties.Add(PositionPropName, "16 100 150 200 213");
         this.Properties.Add("CType", "1");
         this.Properties.Add("ToolbarRows", "1");
         this.Properties.Add("ToolbarType", "16");
      }


      public Boolean Hidden
      {
         get { return this.GetProperty(HiddenPropName) == "1"; }
         set { this.SetProperty(HiddenPropName, value ? "1" : "0"); }
      }

      public Rectangle Bounds
      {
         get
         {
            String[] value = this.GetProperty(PositionPropName).Split(' ');
            return new Rectangle(Int32.Parse(value[1]), 
                                 Int32.Parse(value[2]),
                                 Int32.Parse(value[3]) - Int32.Parse(value[1]),
                                 Int32.Parse(value[4]) - Int32.Parse(value[2]));
         }
         set
         {
            String[] val = this.GetProperty(PositionPropName).Split(' ');
            String newVal = val[0] + " " + value.X.ToString() 
                                   + " " + value.Y.ToString()
                                   + " " + (value.X + value.Width).ToString()
                                   + " " + (value.Y + value.Height).ToString();
            this.SetProperty(PositionPropName, newVal);
         }
      }

      public Point Location
      {
         get { return this.Bounds.Location; }
         set { this.Bounds = new Rectangle(value, this.Bounds.Size); }
      }

      public Size Size
      {
         get { return this.Bounds.Size; }
         set { this.Bounds = new Rectangle(this.Bounds.Location, value); }
      }

      public void AddButton(String macroName, String macroCategory)
      {
         this.AddButton(macroName, macroCategory, String.Empty, String.Empty);
      }

      public void AddButton(String macroName, String macroCategory, String tooltip, String label)
      {
         this.Items.Add(new CuiToolbarMacroButton(macroName, macroCategory, tooltip, label));
      }

      public void AddSeparator()
      {
         this.Items.Add(new CuiToolbarSeparator());
      }

      public Int32 RemoveButton(String macroName, String macroCategory)
      {
         return this.Items.RemoveAll(b => b is CuiToolbarMacroButton &&
                                          ((CuiToolbarMacroButton)b).MacroName == macroName &&
                                          ((CuiToolbarMacroButton)b).MacroCategory == macroCategory);
      }
   }

}
