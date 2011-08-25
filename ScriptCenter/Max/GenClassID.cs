using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScriptCenter.Max
{
    public static class GenClassID
    {
        private static Random _random;

        public static String GetStringSingle()
        {
            if (_random == null)
                _random = new Random();

            Int32 id = _random.Next();
            return "0x" + id.ToString("x");
        }

        public static String GetStringDouble()
        {
            StringBuilder b = new StringBuilder();
            b.Append("#(");
            b.Append(GenClassID.GetStringSingle());
            b.Append(", ");
            b.Append(GenClassID.GetStringSingle());
            b.Append(")");
            return b.ToString();
        }
    }
}
