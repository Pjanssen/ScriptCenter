using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScriptCenter.DevCenter
{
    internal class TreeNodeData
    {
        public Object Data { get; private set; }
        public Type FormType { get; private set; }

        public TreeNodeData(Object data, Type formType)
        {
            this.Data = data;
            this.FormType = formType;
        }
    }
}
