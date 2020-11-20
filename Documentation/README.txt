Saddled Edge Editor
===================

Graphical Editor for Party, Inventory, Troops, Settlements, Factions, 
NPCs, Crafted Weapons, Workshops for Mount & Blade II: Bannerlord

==========================================================================
1. What it does
==========================================================================
  
  In-Game Launched Editor for various assets in the Mount & Blade II game.
        
==========================================================================
2. How it works
==========================================================================

  MB2 allows loading .NET Forms from mods so this mod launches when 
  a specific key is pressed.
 
==========================================================================
3. How to use
==========================================================================

  Press F8 key or which ever key is currently mapped in the Commands.json 
  file.  You can rebind the key from the Party page.  F8 key is default.

  I recommend to go to Quest/Journal (J) page to minimize issues before 
  opening editor.  
  
  Editing Inventory while on Inventory Page or Characters while on Character 
  page may lead to inconsistencies and issues.
  
==========================================================================
4. Changing Key Bindings
==========================================================================
 
Create or Edit "%USERPROFILE%\Documents\Mount and Blade II Bannerlord\SaddledEdgeEditor\Commands.json"

Paste the following json. Change the Code to key of interest as well as key modifiers.

This maps to TaleWorlds.InputSystem.InputKey in the game.  List in the KeyCodes.txt file in Modules folder.

{
  "Open": {
    "Code": "E",
    "Control": true,
    "Alt": true,
    "Shift": false
  }
} 
  
==========================================================================
5. Directory Structure Overview
==========================================================================

%GAME%\Modules\
____SaddledEdgeEditor\
________SubModules.xml  -  Mod Definition File
________KeyCodes.txt    -  Copy of InputKeys for remapping keys
        
________bin\Win64_Shipping_Client\
____________SaddledEdgeEditor.dll - Mod Loader Assembly.  Loads the actual mod by version.
____________MBEditor.*.dll        - Main mod Assembly
____________DarkUI.dll            - Library by Robin for doing Dark Themes
____________DarkUI.Support.dll    - Support library for .NET 4 Forms support
____________ObjectListView.dll    - Full featured List and Tree Control by Phillip Piper
____________NewtonsoftJson.dll    - Json support library
            
            
____%USERPROFILE%\Documents\
________Mount and Blade II Bannerlord\  - Game specific config files
____________SaddledEdgeEditor\          - Mod specific config files
________________Commands.json           - Key bindings for opening editor
________________Config.json             - File to save state between games
________________Debug.log               - Minimal log of actions to support debugging errors



==========================================================================
6. Permissions
==========================================================================
DarkUI and ObjectiveTreeView have their own licenses and restrictions.  
DarkUI is MIT Licensed. ObjectTreeList is GPLv3 that means this module is 
also GPLv3 and subject to same constraints.

==========================================================================
7. Credits
==========================================================================
DarkUI by Robin Perris - https://github.com/RobinPerris/DarkUI - MIT License
Object List View by Phillip Piper - http://objectlistview.sourceforge.net/cs/index.html - GPLv3
