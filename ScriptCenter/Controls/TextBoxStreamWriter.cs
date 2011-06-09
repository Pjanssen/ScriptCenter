using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ScriptCenter.Controls
{
    public class TextBoxStreamWriter : TextWriter
    {
        private TextBox _textBox;

        public TextBoxStreamWriter(TextBox textBox)
        {
            _textBox = textBox;
        }

        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }

        public override void Write(char value)
        {
            _textBox.AppendText(value.ToString());

            //For future reference (for cross-thread calls):
            //MethodInvoker action = delegate { _textBox.AppendText(value.ToString()); };
            // _textBox.BeginInvoke(action);
        }

        public override void Write(string value)
        {
            _textBox.AppendText(value);
        }
    }
}
