using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using System.Windows.Forms;
using System.Drawing;
using ScriptCenter.Repository;

namespace ScriptCenter.Controls
{
    public class SupportedMaxVersionsEditor : UITypeEditor
    {
        private SupportedMaxVersionsEditorUI _supportedMaxVersionsUI;

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public override bool IsDropDownResizable { get { return false; } }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (provider != null)
            {
                IWindowsFormsEditorService windowsFormsEditorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
                if (windowsFormsEditorService != null)
                {
                    if (this._supportedMaxVersionsUI == null)
                    {
                        this._supportedMaxVersionsUI = new SupportedMaxVersionsEditorUI();
                    }
                    this._supportedMaxVersionsUI.Start((SupportedMaxVersions)value);
                    windowsFormsEditorService.DropDownControl(this._supportedMaxVersionsUI);
                    value = _supportedMaxVersionsUI.Value;
                }
            }
            return value;
        }


       
    }
}
