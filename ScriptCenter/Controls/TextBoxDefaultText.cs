using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace ScriptCenter.Controls
{
    public class TextBoxDefaultText : TextBox
    {
        private Boolean _showingDefaultText = true;
        private String _text = "";
        private String _defaultText = "";
        private Color _defaultTextForeColor = Color.Black;
        private Color _origForeColor;

        public TextBoxDefaultText()
            : base()
        {
            _origForeColor = base.ForeColor;
        }
        

        [DisplayName("Default Text")]
        public String DefaultText 
        {
            get { return _defaultText; }
            set
            {
                this._defaultText = value;
                if (_showingDefaultText)
                    base.Text = value;
            }
        }

        [DisplayName("Default Text Color")]
        public Color DefaultTextForeColor 
        {
            get { return _defaultTextForeColor; }
            set
            {
                _defaultTextForeColor = value;
                if (_showingDefaultText)
                    base.ForeColor = value;
            }
        }

        
        private void SetDefaultText()
        {
            base.Text = this.DefaultText;
            base.ForeColor = this.DefaultTextForeColor;
        }
        private void RemoveDefaultText()
        {
            base.Clear();
            //base.Text = String.Empty;
            base.ForeColor = _origForeColor;
        }

        public override Color ForeColor
        {
            get
            {
                return _origForeColor;
            }
            set
            {
                _origForeColor = value;
                if (!_showingDefaultText)
                    base.ForeColor = value;
            }
        }

        public override string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                _showingDefaultText = !this.Focused && (value == String.Empty);
                if (_showingDefaultText)
                    SetDefaultText();
                else
                    base.Text = value;
            }
        }

        protected override void OnGotFocus(EventArgs e)
        {
            if (_showingDefaultText)
                RemoveDefaultText();

            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            if (base.Text == String.Empty)
            {
                _showingDefaultText = true;
                SetDefaultText();
            }

            base.OnLostFocus(e);
        }
    }
}
