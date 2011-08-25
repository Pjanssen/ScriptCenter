using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScriptCenter.Controls
{
    class CheckedToolStripButton : ToolStripButton
    {
        private class ButtonColorTable : ProfessionalColorTable
        {
            public override System.Drawing.Color ButtonCheckedGradientBegin { get { return System.Drawing.Color.FromArgb(123, ButtonPressedHighlight.R, ButtonPressedHighlight.G, ButtonPressedHighlight.B); } }
            public override System.Drawing.Color ButtonCheckedGradientEnd { get { return base.ButtonPressedHighlight; } }
            public override System.Drawing.Color ButtonSelectedBorder
            {
                get
                {
                    return System.Drawing.Color.FromArgb(175, ButtonPressedHighlight.R, ButtonPressedHighlight.G, ButtonPressedHighlight.B);
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            ToolStripProfessionalRenderer renderer = new ToolStripProfessionalRenderer(new ButtonColorTable());
            renderer.DrawButtonBackground(new ToolStripItemRenderEventArgs(e.Graphics, this));
            /*
            if ((this.DisplayStyle & ToolStripItemDisplayStyle.Image) == ToolStripItemDisplayStyle.Image)
            {
                renderer.DrawItemImage(new ToolStripItemImageRenderEventArgs(e.Graphics, this, base.InternalLayout.ImageRectangle)
                {
                    ShiftOnPress = true
                });
            }
            if ((this.DisplayStyle & ToolStripItemDisplayStyle.Text) == ToolStripItemDisplayStyle.Text)
            {
                renderer.DrawItemText(new ToolStripItemTextRenderEventArgs(e.Graphics, this, this.Text, base.InternalLayout.TextRectangle, this.ForeColor, this.Font, base.InternalLayout.TextFormat));
            }
            */
        }
    }
}
