using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ScriptCenter.Installer.Actions
{
    public class CreateRibbonAction : InstallerAction
    {
        public override bool Do(Installer installer)
        {
            throw new NotImplementedException();
        }
            //ManagedServices.MaxActionItem x = ManagedServices.MaxActionItemResolver.ResolveMacroItem("toggleOutliner", "Outliner");
        public void Do()
        {
            /*
            String ribbonConfig = ManagedServices.PathSDK.GetRibbonConfigPath() + "/ModelingRibbon.xaml";
            ComponentManager.Ribbon.LoadState(ribbonConfig);
            RibbonTab t = new RibbonTab();
            t.Id = "Test";
            t.Name = "Test";
            t.Title = "Test";
            RibbonPanel panel = new RibbonPanel();
            RibbonPanelSource source = new RibbonPanelSource();
            RibbonButton btn = new RibbonButton();
            btn.Text = "Test Btn";
            btn.ShowText = true;
            source.Items.Add(btn);
            panel.Source = source;
            t.Panels.Add(panel);
            ComponentManager.Ribbon.Tabs.Add(t);
            
            String ribbonState = ComponentManager.Ribbon.SaveState();
            
            using (System.IO.StreamWriter str = new System.IO.StreamWriter(ribbonConfig))
            {
                str.Write(ribbonState);
            }
            //ComponentManager.SaveState();
            */
            /*
             dotnet.loadassembly "C:/code/scriptcenter/scriptcenter/bin/debug/scriptcenter.dll"
            a = dotnetobject "scriptcenter.installer.actions.createribbonaction"
            a.do()
             */
            /*
             ComponentManager=dotnetclass "Autodesk.Windows.ComponentManager"
              ComponentManager.Ribbon.Tabs.Clear()
              Mx_Tab=dotnetobject "Autodesk.Windows.RibbonTab"
              Mx_Tab.Title="Test Martin"
             
              Mx_Panel=dotnetobject "Autodesk.Windows.RibbonPanel"
              
              RibbonPanelSource=dotnetobject "Autodesk.Windows.RibbonPanelSource"
             
              Mx_Button1=dotnetobject "Autodesk.Windows.RibbonButton"
              Mx_Button1.Text="1"
              Mx_Button1.showtext=true
             
              Mx_Button2=dotnetobject "Autodesk.Windows.RibbonButton"
              Mx_Button2.Text="2"
              Mx_Button2.showtext=true
             
              Mx_Button3=dotnetobject "Autodesk.Windows.RibbonButton"
              Mx_Button3.Text="3"
              Mx_Button3.showtext=true
             
              Mx_Button4=dotnetobject "Autodesk.Windows.RibbonButton"
              Mx_Button4.Text="4"
              Mx_Button4.showtext=true
             
              ComponentManager.Ribbon.Tabs.Add(Mx_Tab)
              Mx_Panel.Source=RibbonPanelSource
              RibbonPanelSource.items.add(Mx_Button1)
              RibbonPanelSource.items.add(Mx_Button2)
              RibbonPanelSource.items.add(Mx_Button3)
              RibbonPanelSource.items.add(Mx_Button4)
              Mx_Tab.Panels.Add(Mx_Panel)
                  */
        }

        public override bool Undo(Installer installer)
        {
            throw new NotImplementedException();
        }

        public override string ActionName { get { return "Create Ribbon"; } }
    }
}
