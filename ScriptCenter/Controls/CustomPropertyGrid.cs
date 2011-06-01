using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.ComponentModel;

namespace ScriptCenter.Controls
{
    /// <summary>
    /// A modification of the standard PropertyGrid to adjust the size of the help area.
    /// </summary>
    public class CustomPropertyGrid : PropertyGrid
    {
        private Control propertyGridView;
        private MethodInfo movePropGridSplitter;
        private Control docComment;

        private Int32 docCommentHeight = 50;
        private Int32 propertyNameColumnWidth = 150;

        public CustomPropertyGrid() : base()
        {
            foreach (Control c in this.Controls)
            {
                if (c.GetType().Name == "DocComment")
                    this.docComment = c;
                else if (c.GetType().Name == "PropertyGridView")
                {
                    this.propertyGridView = c;
                    this.movePropGridSplitter = c.GetType().GetMethod("MoveSplitterTo", BindingFlags.NonPublic | BindingFlags.Instance);
                }
            }
        }

        [DefaultValue(50)]
        public int DescriptionAreaHeight
        {
            get
            {
                return this.docCommentHeight;
            }
            set
            {
                this.docCommentHeight = value;
                int difference = value - this.docComment.Height;
                if (this.docComment.Top - difference > this.propertyGridView.Top)
                {
                    this.docComment.Height = value;
                    this.docComment.Top -= difference;
                    this.propertyGridView.Height -= difference;
                    this.Refresh();
                }
            }
        }

        [DefaultValue(150)]
        public Int32 PropertyNameColumnWidth
        {
            get
            {
                return this.propertyNameColumnWidth;
            }
            set
            {
                this.propertyNameColumnWidth = value;
                this.movePropGridSplitter.Invoke(this.propertyGridView, new Object[1] { value });
                
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.DescriptionAreaHeight = this.docCommentHeight;
            this.PropertyNameColumnWidth = this.propertyNameColumnWidth;
        }

    }
}
