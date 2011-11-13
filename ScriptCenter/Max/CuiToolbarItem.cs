using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ScriptCenter.Max
{
   public class CuiToolbarItem
   {
      protected static Regex separatorPattern = new Regex(@"^3\|6\|16\|31\|1", RegexOptions.Compiled);
      protected static Regex macroButtonPattern = new Regex("^2\\|0\\|0\\|31\\|3\\|647394\\|(.+)`(.+)\\|0\\|0\\|\"(.*)\"\\|\"(.*)\"\\|[\\-\\d]*\\|");

      public virtual String Value { get; set; }
      public virtual List<String> FlyOffItems { get; set; }

      public CuiToolbarItem()
      {
         this.FlyOffItems = new List<String>();
      }

      public CuiToolbarItem(String value) : this()
      {
         this.Value = value;
      }

      public static CuiToolbarItem NewItemFromValue(String value)
      {
         if (separatorPattern.IsMatch(value))
            return new CuiToolbarSeparator();
         else if (macroButtonPattern.IsMatch(value))
         {
            String[] btnParams = macroButtonPattern.Split(value);
            return new CuiToolbarMacroButton(btnParams[1], btnParams[2], btnParams[3], btnParams[4]);
         }
         else
            return new CuiToolbarItem(value);
      }
   }

   public class CuiToolbarMacroButton : CuiToolbarItem
   {
      private String btnFormatString = "2|0|0|31|3|647394|{0}`{1}|0|0|\"{2}\"|\"{3}\"|-1|";

      public String MacroName { get; set; }
      public String MacroCategory { get; set; }
      public String Tooltip { get; set; }
      public String Label { get; set; }

      public CuiToolbarMacroButton(String macroName, String macroCategory) 
         : base()
      {
         this.MacroName = macroName;
         this.MacroCategory = macroCategory;
      }

      public CuiToolbarMacroButton(String macroName, String macroCategory, 
                                   String tooltip, String label)
         : this(macroName, macroCategory)
      {
         this.Tooltip = tooltip;
         this.Label = label;
      }


      public override string Value
      {
         get { return String.Format(btnFormatString, MacroName, MacroCategory, Tooltip, Label); }
         set { }
      }
   }

   public class CuiToolbarSeparator : CuiToolbarItem
   {
      public CuiToolbarSeparator() { }

      public override string Value
      {
         get { return "3|6|16|31|1"; }
         set { }
      }
   }
}
