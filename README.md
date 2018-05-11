# BattleTechModTools

BattleTech Mods Tools is an easy to install compilation of various modding libraries and tools for mod users and modders alike.

## Requirements

** Warning: Uses the experimental mod loaders BTML, ModTek and DynModLib **

Able to help with finding issues and reporting them.

## Features

Includes the following mod tools:
* [ModTek](https://github.com/Mpstark/ModTek) by Mpstark, is a sophisticated mod loader with dependency management and easy json patching without needing VersionManifest.csv modifications.
* [DynModLib](https://github.com/CptMoore/DynModLib) by CptMoore, provides C# scripting by compiling mods when launching the game.
* [BattleTechModLoader](https://github.com/Mpstark/BattleTechModLoader) by Mpstark, a.k.a BTML, a simple mod loader which is required by various mods including other mod tools like ModTek and DynModLib.
* [BattleTechModLauncher](https://github.com/CptMoore/BattleTechModTools) by CptMoore, makes sure that BTML loads correctly after BattleTech updates, use this to always start BattleTech.
* [BattleTechModInstaller](https://github.com/CptMoore/BattleTechModTools) by CptMoore, installs this compilation.

## Mods to Test out

Recommended (due to advertised features being implemented by the BattleTech makers later):
* [CommanderPortraitLoader](https://github.com/Morphyum/CommanderPortraitLoader)
* [SpeedMod](https://github.com/CptMoore/SpeedMod)

Other mods to check out:
* [HardpointFixMod](https://github.com/CptMoore/HardpointFixMod)
* [StatsFixMod](https://github.com/CptMoore/StatsFixMod)
* [bt-real-hit-chance](https://github.com/alexanderabramov/bt-real-hit-chance)
* [BrokenSalvagedMechs](https://github.com/Morphyum/BrokenSalvagedMechs)
* [MechMaintenanceByCost](https://github.com/Morphyum/MechMaintenanceByCost)
* [PermanentEvasion](https://github.com/Morphyum/PermanentEvasion)

For more mods check out:
* https://www.reddit.com/r/BattleTechMods/
* https://www.nexusmods.com/battletech *please don't publish mods yet on nexus that rely on BTML or ModTek*

## Install and Use

Follow the setups instruction, if the battletech directory cannot be found, just make it point to the directory where BattleTech.exe is located in.

Once finished installing, the injector should have patched your battletech installation to load up mods. The injector has to run again after every game update, use the mod launcher to make this happen automatically.

## Uninstall

Just uninstall as you would any other program using "Programs and Features". Will undo the injections done by BTML.

## Modding

> I want to mod myself

Go visit the short list of TODOs at https://github.com/CptMoore/DynModLib#how-to-use

## Download

Downloads can be found on [github](https://github.com/CptMoore/BattleTechModTools/releases).
