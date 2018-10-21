# Modular Fuel Systems :: Change Log

* 2014-0702: 6.3 (NathanKell) for KSP 0.23.5
	+ Changelog:
		- Add Roxette's Spaceplane Plus support
		- Fix HGR so engines are not modified (done via engine config sets instead)
		- Add RedAV8R's Kethane volume fixes
		- Update ECLSS config; add TACLS config. Both should work correctly when their respective mods are present and not do anything when they're not.
		- Made the refueling pump toggleable (in VAB/SPH and in flight)
* 2014-0620: 6.2 (NathanKell) for KSP 0.23.5
	+ Changelog:
		- Added new fuels from RedAV8R
		- Updated HGR patch from Sandworm
		- Tweaked some Firespitter part volumes, added support for more fuselage parts
		- swamp_ig:
		- Fixed cloning
		- Fixed default amounts not loading
		- Fixed ProcParts interoperability issues
		- Fixed compatibility with Engine Ignitor
* 2014-0607: 6.1 (Swamp-Ig) for KSP 0.23.5
	+ I've fixed a couple of bugs, and NK is away, so I thought I'd do an interim release.
	+ Fixed:
		- Issue with SRBs not working
		- 18 Phantom tanks
		- Trimmed down the amount of guff being saved to the persistence files
* 2014-0605: 6.0 (NathanKell) for KSP 0.23.5
	+ Changelog:
		- Updated plane parts (C7, Firespitter) to have B9-esque levels of resources. No more magic volume-disapppearing tricks when fuel tanks become fuselages.
		- Massive improvements from swamp_ig, for integration with Procedural Parts and other mods, and UI improvements.
		- Switchable tanks
		- fixed symmetry bug
		- (optional) tweakable utilization
		- Better integration support
		- loading fixes
		- Display GUI from tweakables
		- SI units
		- taniwha: show version on GUI
		- support more Firespitter parts
		- Update to ModuleManager v2.1.5
		- Sandworm: support HGR tanks
		- NOTE_: At this point it is recommended to switch from StretchyTanks to Procedural Parts (if you have not already done so).
* 2014-0504: 5.3 (NathanKell) for KSP 0.23.5
	+ Fix DLL
	+ Upgrade Kethane converter config to eadrom's.
	+ Fix ModuleRCSFX compatibility to be non-destructive
	+ Fix fixed launch clamp pumps (taniwha)
	+ Upgrade to ModuleManager v2.1.0
* 2014-0429: 5.2 (NathanKell) for KSP 0.23.5
	+ Changelog:
		- Add support for Nazari's Mk3 expansion, add ECLSS fix, fix ARM patches.
		- Fix launch clamps so they pump to all parts.
		- ialdabaoth: add support for RF adjustments via tweakables.
		- Fix RCS tank basemass
		- Support ModuleRCSFX
		- Fix some engine patches to play nicer with HotRockets
* 2014-0408: 5.1 (NathanKell) for KSP 0.23.5
	+ Fixed RCS Sounds compatibility
	+ Fixed g0 constant in all RF-compatible engines to be the real 9.80665m/s rather than KSP's 9.82m/s (even though elsewhere they use 9.81, for engines they use 9.82).
	+ Fixed semi-automatic ModuleEnginesFX support to actually work.
	+ Preliminary tweakables support from swamp_ig
	+ Support new ARM tanks (taniwha)
	+ Support TurboNiso tanks (Spanier)
	+ Recompiled for .23.5
	+ Changed DLL name. YOU MUST DELETE OLD RF FOLDER BEFORE INSTALLING v5.1!
* 2013-0613: 1.3 (ialdabaoth) for KSP 0.20
	+ fixed a bug where Isp wouldn't set properly when choosing engine configurations
	+ changed TANK_DEFINITION format for proportional tanks from 'maxAmount = number * volume' to 'maxAmount = number%'
	+ added 'utilization' as a synonym for 'efficiency'
	+ added ModuleHybridEngines as a replacement for ExsurgentEngineering's HydraEngineController, with improved fuel gauges
	+ abandoned experimental modular RCS blocks.
	+ removed ASAS from pods, since adding ASAS apparently disables the pod's gyro.
* 2013-????: 1.2 (ialdabaoth) for KSP 0.20 NO BINARY AVAILABLE
	+ fixed a bug where tanks couldn't be configured empty
	+ fixed a bug where the UI would sometimes glitch
* 2013-????: 1.1 (ialdabaoth) for KSP 0.20 NO BINARY AVAILABLE
	+ Now comes packaged in a convenient /GameData folder for clearer installation!
	+ Added a 'fillable = false' line to TANK_DEFINITIONS, to support resources like Kethane that shouldn't be fillable in the VAB
	+ Added configurable ASAS modules! Now, when you click on a customizable ASAS module in the Action Group editor, you will have the option to configure up to 3 PID settings for that ASAS module. If you configure 2 or more PID settings, a set of Actions will appear that can be assigned to Action Groups, which will allow you to switch between PID settings in-flight. For example, you could set up an ASAS module with an Avionics setting (Ki = 0.0, Kp = 0.2, Kd = 0.2) and an ASAS setting (Ki = 1.0, Kp = 0.6, Kd = 1.0), and assign the switch to the same button that changes your SABRE rocket settings - so that when you switch to air-breathing mode, your ASAS changes to the Avionics control scheme, and when you switch to rocket mode, your ASAS changes back to the Rocket control scheme. You could also set up two separate control schemes for low-mach and high-mach, or for early-stage and late-stage for rockets that drastically change their control authority as they stage.
* 2013-????: 1.0 (ialdabaoth) for KSP 0.20 NO BINARY AVAILABLE
	+ merged Advanced and Basic distributions; the Advanced version is now simply a set of configuration files in RealFuels.zip - if you want to play with LOX and LH2 and realistic nuclear engines, unzip RealFuels.zip after unzipping ModularFuelTanks.zip
	+ moved the install folder to /GameData/ModularFuelTanks instead of /GameData/Ialdabaoth (doesn't change anything, but people can read it better)
	+ ditched using Liters in the advanced version, because apparently I suck at the maths.
	+ Xenon is no longer absurdly heavy.
	+ All engine heats are halved, so that they won't explode in DeadlyReentry 2.0
