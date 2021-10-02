# BringMoreDamnit
Multiplies the number of items merchants can bring and the chance of any given item appearing in their inventories by configurable values.
## Config
This mod allows for certain settings to be configured, those settings are listed below:
- `deliveryMinCount`  The amount of times the minimum ingredient count is multiplied by. MUST BE SMALLER THAN OR EQUAL TO deliveryMaxCount. Default: 10
- `deliveryMaxCount` The amount of times the maximum ingredient count is multiplied by. Default: 10
- `deliveryAppearingChanceBonus` The bonus chance of any given item appearing. 0.5 = +50%. Default: 0.5
## Installation
This mod uses BepInEx 5! BepInEx is a mod loader, basically it is what puts the edited code into the game.
- Install [BepInEx 5](https://github.com/BepInEx/BepInEx/releases) and extract the zip file.
- Drag the extracted folder into your Potion Craft folder, you should be able to find the Potion Craft folder at `C:\Program Files (x86)\Steam\steamapps\common\Potion Craft`
- Run Potion Craft once with BepInEx installed.
- Download the mod from the [GitHub](https://github.com/RoboPhred/potioncraft-bringmoredamnit/releases) page.
- Drag `potioncraft-bringmoredamnit.dll` into `Potion Craft\BepInEx\Plugins`
- You are good to go!
## Deinstallation
Uninstalling this mod is as easy as deleting one file, you don't even need to delete [BepInEx](https://github.com/BepInEx/BepInEx/releases)!
- Navigate to `Potion Craft\BepInEx\Plugins`
- Remove `potioncraft-bringmoredamnit.dll` from the folder.
- You are done!
## Development

Dependencies are placed on the `/externals` folder. See the csproj file for required files.
