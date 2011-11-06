using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ScriptCenter.Max
{
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
         this.AddItem(new CuiItem(key, value));
      }

      public void AddItem(CuiItem item)
      {
         if (!this.Items.Exists(i => i.Key == item.Key))
            this.Items.Add(item);
      }
   }

   internal class CuiItem
   {
      public virtual String Key { get; set; }
      public virtual String Value { get; set; }
      public CuiItem() { }
      public CuiItem(String key, String value)
      {
         this.Key = key;
         this.Value = value;
      }
   }



   internal class RectItem : CuiItem
   {
      public Rectangle Rect { get; set; }
      public override string Value
      {
         get
         {
            return String.Format("{0} {1} {2} {3}", this.Rect.Left,
                                                    this.Rect.Top,
                                                    this.Rect.Right,
                                                    this.Rect.Bottom);
         }
         set
         {
            throw new InvalidOperationException("Use Rect property to set RectItem's value.");
         }
      }

      public RectItem(String key, Rectangle value)
      {
         this.Key = key;
         this.Rect = value;
      }
   }



   internal class CurPosItem : RectItem
   {
      public enum DockFlags : int
      {
         Top = 1,
         Bottom = 2,
         Left = 4,
         Right = 8,
         Float = 16
      }
      public DockFlags DockFlag { get; set; }
      public override string Value
      {
         get
         {
            return String.Format("{0} {1} {2} {3} {4}", (int)this.DockFlag,
                                                        this.Rect.Left,
                                                        this.Rect.Top,
                                                        this.Rect.Right,
                                                        this.Rect.Bottom);
         }
         set
         {
            throw new InvalidOperationException("Use Rect property to set CurPosItem's value.");
         }
      }

      public CurPosItem(DockFlags dockFlag, Rectangle value)
         : base("CurPos", value)
      {
         this.DockFlag = dockFlag;
      }
   }
}
