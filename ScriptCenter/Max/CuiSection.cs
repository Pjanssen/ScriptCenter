using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScriptCenter.Max
{
   public class CuiSection
   {
      public String Name { get; set; }
      public Dictionary<String, String> Properties { get; set; }

      internal CuiSection() 
      {
         this.Name = String.Empty;
         this.Properties = new Dictionary<String, String>();
      }

      public CuiSection(String name) : this()
      {
         this.Name = name;
      }

      public String GetProperty(String key)
      {
         String value = String.Empty;
         this.Properties.TryGetValue(key, out value);
         return value;
      }

      public void SetProperty(String key, String value)
      {
         if (!this.Properties.ContainsKey(key))
            this.Properties.Add(key, value);
         else
            this.Properties[key] = value;
      }
   }
}
