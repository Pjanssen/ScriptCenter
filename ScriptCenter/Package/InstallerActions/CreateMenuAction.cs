using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScriptCenter.Package.InstallerActions
{
    class CreateMenuAction : InstallerAction
    {
        /*
         if menuMan.registerMenuContext 0x1ee76d8e then
        (
            -- Get the main menu bar
            local mainMenuBar = menuMan.getMainMenuBar()

            -- Create a new menu
            local subMenu = menuMan.createMenu "Test Menu"

            -- create a menu item that calls the sample macroScript
            local testItem = menuMan.createActionItem "MyTest" "Menu Test"

            -- Add the item to the menu
            subMenu.addItem testItem -1

            -- Create a new menu item with the menu as it's sub-menu
            local subMenuItem = menuMan.createSubMenuItem "Test Menu" subMenu

            -- compute the index of the next-to-last menu item in the main menu bar
            local subMenuIndex = mainMenuBar.numItems() - 1

            -- Add the sub-menu just at the second to last slot
            mainMenuBar.addItem subMenuItem subMenuIndex

            -- redraw the menu bar with the new item
            menuMan.updateMenuBar()
         )
         */
        public override bool Do(Installer installer)
        {
            throw new NotImplementedException();
        }

        public override bool Undo(Installer installer)
        {
            throw new NotImplementedException();
        }

        public override void PackResources(Ionic.Zip.ZipFile zip, string archiveTargetPath, Utils.IPath sourcePath)
        {
            //No resources to pack for this action.
        }
    }
}
