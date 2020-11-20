[b]Saddled Edge Editor[/b]

This is an Editor for Mount & Blade II: Bannerlord for Party, Inventory, Troops, NPCs, Settlements, Factions, Crafted Weapons, Workshops.

Installation:
[list]
[*]Unzip the zip file to Modules subfolder under installed game location.
[*]Check Saddled Edge Editor under Mods section when starting Single Player game in 
[/list]
Using:
[list]
[*]Type F8 after reaching the game.  I recommend going to Quest/Journal (J) page to minimize issues before opening editor.
[*]Key can be rebound by editing the Commands.json file in the MB2 Documents folder or the Party Page in the Editor

[/list]
Changing Key Bindings:
[list]
[*]Create or Edit "%USERPROFILE%\Documents\Mount and Blade II Bannerlord\SaddledEdgeEditor\Commands.json"
[*]Paste the following json. Change the Code to Key of interest as well as key modifiers.  
(This maps to TaleWorlds.InputSystem.InputKey in the game.  List in the KeyCodes.txt file)[/list][code]{
  "Open": {
    "Code": "E",
    "Control": true,
    "Alt": true,
    "Shift": false
  }
}[/code]