# Modular Fuel System /L Unofficial

Modular Fuel System allows any supported tank to be filled with exactly how much or how little fuel you want, of whatever type you want.

Modular Fuel Tanks use the Stock Fuels.

Real Fuels implements a new engines subsystems, where realistic fuels are used instead.

Unofficial fork by Lisias.


## Installation Instructions

To install, place the GameData folder inside your Kerbal Space Program folder. Optionally, you can also do the same for the PluginData (be careful to do not overwrite your custom settings):

* **REMOVE ANY OLD VERSIONS OF THE PRODUCT BEFORE INSTALLING**, including any other fork:
	+ Delete `<KSP_ROOT>/GameData/ModularFuelSystem`
	+ or
	+ Delete `<KSP_ROOT>/GameData/RealFues`
* **CAUTION** `Modular Fuel Tanks` and `Real Fuels` are **_mutually incompatible_**. **DO NOT** install both on the same `GameData`!
* Extract the package's `GameData` folder into your KSP's root:
	+ `<PACKAGE>/GameData` --> `<KSP_ROOT>/GameData`
* Extract the package's `PluginData` folder (if available) into your KSP's root, taking precautions to do not overwrite your custom settings if this is not what you want to.
	+ `<PACKAGE>/PluginData` --> `<KSP_ROOT>/PluginData`
	+ You can safely ignore this step if you already had installed it previously and didn't deleted your custom configurable files.

The following file layout must be present after installation:

```
<KSP_ROOT>
	[GameData]
		[ModularFuelSystem]  (or RealFuels)
			[Parts] (only RealFuels)
				...
			[Plugins]
				...
			[Resources]
				...
			CHANGE_LOG.md
			LICENSE
			NOTICE
			...
		000_KSPe.dll
		...
	[PluginData]
		[ModularFuelSystem] <not present until you run it for the fist time>
		...
	KSP.log
	PartDatabase.cfg
	...
```


### Dependencies

No dependencies are included. Please refer to the links below to fulfill them.

#### All

* Hard Dependencies
	+ [KSPe](https://github.com/net-lisias-ksp/KSPAPIExtensions)
* Soft Dependencies
	+ [Module Manager](https://github.com/net-lisias-ksp/ModuleManager)

#### Real Fuels

Real Fuels also needs:

* Hard Dependencies
	+ [Solver Engines](https://github.com/net-lisias-kspu/SolverEngines)
* Soft Dependencies
	+ [Community Resource Pack](https://forum.kerbalspaceprogram.com/index.php?/topic/83007-community-resource-pack/)
