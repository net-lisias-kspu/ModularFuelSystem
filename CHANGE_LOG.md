# Modular Fuel Systems :: Change Log

* 2018-0520: 12.6.0 (blowfishpro) for KSP 1.3.1
	+ Add multi-layer insulation and dewar (vacuum) bottles
		- MLI is configured by `numberOfMLILayers` on the `TANK_DEFINITION`
			- Each layer adds cost and mass
			- Cryo and balloon cryo tank types now come with 10 layers of MLI
		- Dewar / vacuum bottles defind by `isDewar = true` on the `TANK`
			- Cryogenic fuels in the Serivce Module tank type use this
			- Does not work with other types of insulation
* 2018-0403: 12.5.0 (blowfishpro) for KSP 1.3.1
	+ Fix vesion checker which reported KSP 1.3.1 as incompatible
	+ Implement new entry cost system for RP-0/1
	+ Disable thrust limiter when no throttling
	+ Implement min and max utilization support on tanks
* 2017-1025: 12.4.1 (blowfishpro) for KSP 1.3.1
	+ Don't double heat flux (workaround which is no longer necessary in KSP 1.3.1)
	+ Actually update .version file
* 2017-1024: 12.4.0 (blowfishpro) for KSP 1.3.1
	+ Recompile for KSP 1.3.1
	+ Fix MM configs with more than one pass in kethane tanks config
* 2017-0817: 12.3.1 (blowfishpro) for KSP 1.3
	+ Actually fix the bug with tanks not getting their contents correctly (not fixed in v12.3.0)
* 2017-0813: 12.3.0 (blowfishpro) for KSP 1.3
	+ Fix bug with tanks not loading their contents correctly
	+ Add .version file
* 2017-0813: 12.2.4 (blowfishpro) for KSP 1.2.2
	+ Fix bug with tanks not loading their contents correctly
	+ Add .version file
* 2017-0731: 12.2.3 (blowfishpro) for KSP 1.3
	+ Recompile for KSP 1.3
* 2017-0731: 12.2.2 (blowfishpro) for KSP 1.2.2
	+ Fix bug in how tank surface area is calculated
	+ Fix tank copying when cloning via symmetry
	+ Don't delete tanks during loading or part placement
	+ Fix patches marked :FINAL
	+ Disable part heating due to engine on RF engines, since engine overheat is handled separately and engine heat shouldn't spill to other parts
* 2017-0708: 12.2.1 (blowfishpro) for KSP 1.2.2
	+ Fix tank's initial temperature not being set correctly on vessel spawn and when launch clamps are attached
	+ Remove some logspam for boiloff in analytic mode (high timewarp)
	+ Make sure tank's lowest temperature is calculated correctly and that part temp is only set if cryogenic resources are present
	+ Fix negative temperature caused by conduction compensation in analytic mode (high timewarp)
	+ Fix sign error on flux in analytic mode (high timewarp)
* 2017-0707: 12.2.0 (blowfishpro) for KSP 1.2.2
	+ Fix for engines not properly loading pressure fed setting from
	+ ModuleEngineConfig
		- Fix for cryogenic tanks exploding during analytic mode after long
	+ periods unloaded
		- Avoid possible NRE on fuel pumps when launching with Extraplanetary Launchpads
		- Fuel pumps must now be present and active in order to avoid boiloff during prelaunch (previously being on the launch pad was enough)
		- Fuel pumps are now enabled by default and enabled setting respects symmetry in the editor
		- Streamline fuel pump enable/disable UI - now a simple button rather than display + button
* 2017-0424: 12.1.0 (blowfishpro) for KSP 1.2.2
	+ Reinstate analytic boiloff with improvements
	+ Set specific heat to zero for cryogenic resources (assumption that part and resource temperature are the same doesn't make sense here)
	+ Disable ferociousBoilOff since changing cryogenic resource specific heat makes it unnecessary
	+ Add the ability for ignitions to be allowed only when attached to launch clamps
	+ Make sure cost only gets multiplied by scale once
	+ Fix issue where engines would explode after being decoupled (due to KSP reporting the wrong ambient temperature for a couple of frames)
	+ Fix resource mix buttons not showing up when a ship is first loaded
	+ Fix fuel tank related NRE in flight
	+ Make burn time formatting consistent
	+ Fix vacuum thrust displaying the same as sea level thrust
* 2017-0121: 12.0.1 (blowfishpro) for KSP 1.2.2
	+ Fix TestFlight integration
	+ Fix engine configs in career that aren't unlocked by upgrade nodes
	+ Fix harmless but noisy error message when using thrust curves
* 2016-1221: 12.0.0 (blowfishpro) for KSP 1.2.2
	+ Update to KSP 1.2.2
	+ Update to SolverEngines v3.0
* 2016-0708: 11.3.1 (NathanKell) for KSP 1.1.3
	+ Fix an issue with verniers and TestFlight.
* 2016-0704: 11.3.0 (NathanKell) for KSP 1.1.3
	+ Changelog:
		- Tweak to boiloff and to how conduction is compensated.
		- Slight optimization in the ullage VesselModule.
		- Attempting to add back tweakscale support for ModuleEngineConfigs.
		- Update to KSP 1.1.3.
* 2016-0515: 11.2.0 (NathanKell) for KSP 1.1.2
	+ Correct a bug in tank basemass calculation such that parts sometimes mass less than they should in flight. Thanks soundnfury for finding this!
	+ New UI skin thanks to Agathorn!
	+ Fix an issue with scaling down tanks during utilization changes.
	+ Round displayed available volume when below 1mL (no more -322 femtoliters).
* 2016-0508: 11.1.1 (NathanKell) for KSP 1.1.2
	+ Fix an NRE that was messing up staging in the VAB/SPH
* 2016-0507: 11.1.0 (NathanKell) for KSP 1.1.2
	+ Enable conduction compensation (now that FAR no longer lowers conduction).
	+ Set resources to volume=1 for compatibility with other mods.
	+ Don't set wrong massDelta when basemass is negative (fixes the B9 proc wings mass issue amongst others).
	+ Fix an NRE in database reloading at main menu.
	+ Fix issue with configs getting lost (affected LR91 verniers).
* 2016-0501: 11.0.0 (NathanKell) for KSP 1.1.2
	+ Changelog:
		- Port to KSP 1.1, thanks to taniwha, Agathorn, Starwaster!
		- Make sure clamps with the pump do pump EC even when the EC is not in a ModuleFuelTanks tank.
		- Change boiloff to use wetted tank area and other boiloff improvements.
		- Temprorarily remove TweakScale support until we can get it non-buggy.
		- Infinite Propellants cheat now allows reignition even with no ignitions remaining / no ignitor resources remaining.
* 2016-0312: 10.8.5 (NathanKell) for KSP 1.0.5
	+ Don't try to stop other-config FX every frame, do more null checking (should speed things up a abit and avoid NREs).
	+ Allow setting (in MFSSettings) the multiplier to lowest boiling point to use for radiator calls.
	+ Rework engine throttle response speed, make it tunable in RealSettings and in per-engine cfg.
* 2016-0228: 10.8.4 (NathanKell) for KSP 1.0.5
	+ Update propellant status info line during warp as well.
	+ Change background color of engine stack icon based on propellant stability (like parachutes).
	+ Add the tech required to unlock a config to the info tooltip for that config (for unavailable configs).
* 2016-0201: 10.8.3 (NathanKell) for KSP 1.0.5
	+ Changelog:
		- Fix engine thrust display formatting in tooltips.
		- Add a bit of insulation to tank type Default (it represents S-IVB-level insulation).
		- Show cost display again in the tank GUI.
		- Update for SolverEngines 1.15.
* 2016-0123: 10.8.2 (NathanKell) for KSP 1.0.5
	+ Changelog:
		- Fix log spam.
		- Fix a typo in heat anim patch.
		- Fix bug with stock radiator interaction.
* 2015-1119: 10.8.1 (NathanKell) for KSP 1.0.5
	+ Changelog
		- Update to SolverEngines v1.13.
		- Fix emissives patch for 1.0.5.
		- Add some patch magic to the emissives patch to fix VenStockRevamp engine emissives.
		- Add LOX insulation to tank type Cryogenic.
* 2015-1119: 10.8 (NathanKell) for KSP 1.0.5
	+ Update for KSP 1.0.5, start to tune boiloff for new thermo.
	+ Add tooltips when hovering over (locked or unlocked) engine configs in the engine GUI.
	+ Support descriptions for engine configs (key 'description' in the CONFIG). They are shown on the editor tooltip and in the config tooltip in the engine GUI.
* 2015-1110: 10.7.2 (Starwaster) for KSP 1.0.
	+ Increased boiloff rate can be switched off by adding ferociousBoilOff = False to MFSSETTINGS (best use MM patch for that)
	+ PhysicsGlobal.conductionFactor can be compensated for by adding globalConductionCompensation = true to MFSSETTINGS (use at own risk)
	+ cryogenic outerInsulation improved to 0.0005 (previous value 0.01)
	+ All LOX tanks now assume stainless steel tanks, except the ServiceModule.
* 2015-1107: 10.7.1 (Starwaster) for KSP 1.0.
	+ Fixed bug where individual tank insulation/tank values weren't loading
	+ in.
	+ Increased heat leak flux based on  part thermal mass (total) / part
	+ thermal mass - resource mass.
	+ Tweaked ServiceModule and Default tank insulation values. (service module insulation calculated assuming Inconel/Titanium + vacuum/vapor shielded tanks.)
* 2015-1024: 10.7.0 (Starwaster) for KSP 1.0.
	+ Revamped boiloff code for cryogenic propellants to be compatible with KSP 1.0.x thermodynamics
	+ (tanks will be properly cooled by evaporation of boiled off resources)
	+ For now, only LqdOxygen, LqdHydrogen, LqdMethane and LqdAmmonia use the new system. (others may be added if needed)
	+ Insulation can be either for the whole tank part or per each internal tank.
	+ Fix issue where TL was not being correctly reset on config change.
* 2015-0909: 10.6.1 (NathanKell) for KSP 1.0.4.
	+ Changelog:
		- Fix throttling via `throttle` in CONFIG (minThrust was not being set properly).
		- Work around an ignition resource issue (due to, apparently, either a float precision issue or a bug in stock KSP code).
* 2015-0827: 10.6 (NathanKell) for KSP 1.0.4.
	+ Changelog:
		- New throttling behavior. Old bugs with it were fixed, and now there is a proper delay while thrust builds up, when igniting a liquid engine. It will take about two seconds for an F-1 class engine to build up to full thrust. The rate can be tweaked, set throttleResponseRate in the ModuleEnginesRF (or in a CONFIG that's applied to one). By default when the current throttle is within 0.5% of the desired throttle, the engine clamps to the desired throttle. Further, when setting 0 throttle, the engine instantly shuts off (the latter will change, later). WORD TO THE WISE: Use launch clamps, and make sure your engines are at full thrust before disengaging the clamps!
		- Fix for sometime "says stable but fails to ignite" issue. Supreme thanks for stratochief66 for figuring out where to look!
		- Increase ullage acceleration threshold. Cryo stages will no longer keep themselves at Very Stable, but it won't take much thrust to ullage them.
		- Add tanks for the other Ethanol resources.
* 2015-0803: 10.5.1 (NathanKell) for KSP 1.0.4.
	+ Fix an issue with CONFIG entryCost being lost.
* 2015-0729: 10.5 (NathanKell) for KSP 1.0.4.
	+ Changelog:
		- Update to SolverEngines v1.9.
		- Auto-remove Interstellar Fuel Switch or FS Fuel Switch modules on parts that have RF tank modules on them too.
		- Add a new setting to disable natural diffusion when there is acceleration greater than (this threshold). Makes ullaging stages easier since only minimal acceleration is needed (it just can take a while).
		- Fix some flameout issues (and the 'flameout' sound on load with a pressure-fed engine).
		- Fix issue with a typo in ullage sim's rotation bit. Spinning axially will no longer cause ullage-outs so rapidly.
		- Attempt to load/save 'ignited' property.
		- Added other solid fuels to 'instant throttling' list.
		- Tellion: more NF Propulsion support, MkIV support.
		- Update engine/TL upgrade tracking to not keep the costs persistent (i.e. changing files no longer needs starting a new save).
		- Support maxSubtraction for entryCostSubtractors, do all subtraction(s) before all multiplications.
		- Update all heat animations on ModuleEnginesRF parts to use new animation module from SolverEngines.
		- Fix a big bug with ignition in CONFIG nodes. Now tracked properly.
		- Display pressure/ullage/ignitions info in GetInfo for ModuleEnginesRF and for MEC's alternate configs info text (if it differs from default config).
* 2015-0721: 10.4.9 (NathanKell) for KSP 1.0.4.
	+ Changelog:
		- Hotfix for the hotfix.
		- Don't load/save ullage sim data in editor.
		- NOTE: You may have to detach and reattach your engines in saved craft. Also, action groups involving engines will need to be remade.
* 2015-0720: 10.4.8 (NathanKell) for KSP 1.0.4.
	+ Changelog:
		- Hotfix for duplicated actions on engines (requires SolverEngines 1.7).
* 2015-0717: 10.4.7 (NathanKell) for KSP 1.0.4.
	+ Changelog:
		- Tellion: add NF Spacecraft and Construction tank configs.
		- Un-break the cost of CONFIG upgrades (and a bunch of other settings).
* 2015-0713: 10.4.6 (NathanKell) for KSP 1.0.4.
	+ Hotfix for PP Proc SRB issue.
* 2015-0710: 10.4.5 (NathanKell) for KSP 1.0.4.
	+ Changelog:
		- Update to CRP 4.3. Remove no-longer-needed hsp changes.
		- Add a fix to TEATEB flow mode until next CRP.
		- Clean up behavior when igntions are specified in a CONFIG.
		- Make the simulateUllage setting be respected.
		- Add a limitedIgnitions setting (which can be set to false).
		- Default origTechLevel to -1 to avoid an issue on engine configuration change.
		- SolverEngines update fixes "can't activate when shielded" issue.
* 2015-0706: 10.4.4 (NathanKell) for KSP 1.0.4.
	+ Changelog:
		- Fix bug where tanks that had flow disabled in partactionmenu were not counted for pressure-fed checks.
		- Fix bug where legacy EI configs were not being applied.
		- Fix issues with fuel ratio for ullage.
		- Show ignitions and pressure-fed-ness in Editor tooltips.
* 2015-0704: 10.4.3 (NathanKell) for KSP 1.0.4.
	+ Changelog:
		- Fix an NRE in ullage code in editor.
		- Fix a bug with multFlow not being used correctly.
	+ (EDIT: Archive fixed, thanks @Gerry1135 )
* 2015-0703: 10.4.2 (NathanKell) for KSP 1.0.4.
	+ Recompile/repack with correct KSPAPIExtensions
* 2015-0626: 10.4.1 (NathanKell) for KSP 1.0.4.
	+ Changelog:
		- Fix throttle/ignition for throttle-locked (solids).
		- Fix to report nominal propellant status when pressurefed OK and ullage disabled.
* 2015-0625: 10.4 (NathanKell) for KSP 1.0.4.
	+ Changelog:
		- Update for KSP 1.0.4.
		- Ullage and limited ignitions now included, works like EngineIgnitor though the module configuration is different. If you set EI configs in your ModuleEngineConfigs CONFIG nodes, however, those will be read just fine by RF.
		- Spaceplane part volumes and tank types tweaked for better utility.
		- TweakScale support for engines.
* 2015-0616: 10.3.1 (NathanKell) for KSP 1.0
	+ Changelog:
		- Readme update,
		- Fixed an NRE that killed loading under certain circumstances.
		- Do a better search for which engines are on a ship.
* 2015-0615: 10.3 (NathanKell) for KSP 1.0
	+ Changelog:
		- Added cost to unlock new configurations and new TLs for engines. Cost can be fully configured both globally and per part config, and can take from funds and/or science. See UPGRADE COSTS below.
		- Add hsp for Furfurfyl Alcohol.
		- Make the GUI draggable in action editor too.
		- Update for latest SolverEngines.
		- Clamp chamber temp to be no lower than part internal temp.
		- Allow random variation in fuel flow (defaults to 0 variation, set varyThrust to a >0 number to enable). Thrust variation is multiplicative, and will be in the range +/- (global varyThrust \* ModuleEnginesRF.varyThrust). ModuleEnginesRF.varyThrust defaults to 1.0. Example: you set global varyThrust (in RFSETTINGS) to 0.008. Then all engines that use ModuleEnginesRF will have +/- 0.8% variation in their thrust during flight.
		- Fix a bug in detecting engines to autoconfigure for: let's check ourselves too.
		- Fix issues in basemass / basecost overrides in ModuleFuelTank nodes.
* 2015-0610: 10.2 (NathanKell) for KSP 1.0
	+ Changelog:
		- Allow time-based thrust curves.
		- Fix thrust curves to actually work.
		- Add more specific heat capacities for resources.
		- Fix NaN with SolverEngines.
		- basemass now defaults for being for the entire part, not just the utilized portion (i.e. utilization slider is ignored for basemass, always 100%). This will marginally increase tank masses. This can be toggled in MFSSettings.cfg.
		- Update volume and type of some spaceplane adapter tanks.
		- (Finally!) add nacelleBody and radialEngineBody.
		- Fix typo with large Xenon tank; properly patched now.
		- Support any case for 'Full' when setting amount in a TANK.
		- Fix when engine configs could sometimes be empty.
		- Fix up boiloff loss rates for KSP 1.0 heating.
		- Add some heat loss when propellant boils off (due to vaporization heat).
* 2015-0606: 10.1 (NathanKell) for KSP 1.0
	+ Changelog:
		- Added specific heats for most of the resources (thanks stratochief!).
		- Revised temperature gauge for rocket engines.
		- Set tanks with cryo propellants to their boiling points during prelaunch when pumps (i.e. launch clamps) are connected, so they don't start way above BP.
		- Make life support waste resources not fillable.
		- Compatibility with Ven's Stock Revamp for the RF cloned parts
* 2015-0525: 10.0 (NathanKell) for KSP 1.0
	+ Changelog:
		- SAVE-BREAKING.
		- KSP 1.0 support.
		- Remove thermal fin and radiator.
		- Use Community Resource Pack for our resources, don't add resources in RF.
		- Xenon tank type is removed; all of these tanks use ElectricPropulsion now.
		- Now have multiple different solid fuel resources, and thus multiple different solid fuel tank types.
		- Add module info in the editor tooltip for tanks
		- Engine info / configuration info will only display for the master ModuleEngineConfigs on the part.
		- Disable MEC event firing on configuration change (was killing FAR).
		- Updating an engine config will properly propagate to symmetry counterparts.
		- Updating the engine config of an isMaster=true module can propagate changes to isMaster=false modules on the same part (and will propagate properly across symmetry counterparts). Example: Change the main engine config and the vernier config will auto-update. Done by, for each CONFIG, adding an OtherModules {} node. Inside are key-value pairs, where key = engineID of other module and value is config to switch to.
		- Separate settings for RF engines (RFSETTINGS) and tanks (still MFSSETTINGS).
		- Remove deprecated old version of hybrid engines (the one that is essentially MultiModeEngine).
		- Speed up ModuleEngineConfigs a lot, cut the excess bits from ModuleHybridEngines.
		- Fix issue with heat multiplier
		- Rewrite floatcurve-modder to respect tangents.
		- Massively refactor engines code. RealFuels, like AJE, will use an engine solver now. The new engine module (ModuleEnginesRF) handles thrust curves, throttle speed, emission and internal engine temperature, automatically extending Isp curves to 0 Isp, etc.
		- MEC (and MHE) default to using weak typing: type = ModuleEngines means apply to ModuleEngines or anything derived from it (same for ModuleRCS etc). You can disable this feature per-module if needed.
* 2015-0424: 9.1 (NathanKell) for KSP 0.90
	+ Changelog:
		- Fixed stock RCS and xenon tank volumes.
		- Don't pump into tanks if their flow has been turned off.
		- Clamp utilization slider to 1% (avoids a divide-by-zero).
		- Fix typos in Tantares tanks. Thanks komodo!
		- Unlock input when the RF GUI disappears (fixes a bug where clicking can be locked).
* 2015-0404: 9.0 (NathanKell) for KSP 0.90
	+ Changelog:
		- Added notes on tank types to the notes section at the bottom of the readme.
		- Switch to taniwha's refactor of MFT (should fix a lot of bugs).
		- Refactor TechLevels, fix longstanding techlevel override bug.
		- Change so it's not ElectricCharge the resource that costs funds, but rather how much capacity you have.
		- Fixed bug where an engine that shares FX betwqeen CONFIGs could have its FX shut down.
		- Removed deprecated StretchyTanks clones.
		- Add techRequired support for resources and for tank types.
		- Add gimbal support to modular engines (TechLevel changing or CONFIG changing can change gimbal). Supports only stock gimbal for now.
		- Cost for engines increases with TechLevel.
* 2015-0225: 8.4 (NathanKell) for KSP 0.90
	+ Changelog:
		- Fixed stock KSP mass calculation (for engineer's report and for pad limits).
		- Added TestFlight integration support.
		- Remove KSPI config so that RF will no longer be a bottleneck.
		- Add support for per-CONFIG effects settings (running, power, or directThrottle FX not listed in the current CONFIG but listed in other CONFIGs will be turned off).
		- aristurtle: add support for TurboNisuReloaded.
		- Maeyanie: add missing SXT LMiniAircaftTail, Tantares tanks.
		- Raptor831: add Firespitter helicopter crewtank.
		- Raptor831, Starwaster: Fix & to , for MM.
		- ImAHungryMan: add support for missing tanks in RS Capsuldyne (Taurus), Nertea's Mk IV system, RetroFuture, SXT; Convert some Mk2 and Mk3 tanks to cryogenic and add missnig Mk3 tanks.
* 2014-1220: 8.3 (NathanKell) for KSP 0.90
	+ Changelog:
		- Update to .90 (thanks ckfinite and taniwha)
		- Don't fire editor events when we shouldn't
		- Add cost info to engine change GUI
		- Show engine configs that are not available due to tech (not having that node)
* 2014-1211: 8.2 (NathanKell) for KSP 0.24.2
	+ Changelog:
		- Update heat pumps (thanks Starwaster)
		- Fix added parts to be MM clones
		- taniwha: lots of refactoring
		- regex: add lots of missing tanks (FASA, HGR, NP2, RLA, SXT)
		- dreadicon: improved KSPI config
		- camlost: RetroFuture tank configs
		- TriggerAu: include icons for ARP in RealFuels rather than in ARP
		- taniwha: correct tank cost calcs
		- Raptor831: Add missing NP2, HGR tanks; Add Taurus pod/SM tanks
		- lilienthal: fix Thermal Fin description
		- Starman-4308: Add configs for Modular Rocket System
		- Add support for the 0.625m tanks in Ven's Stock Part Revamp
		- Show tank/fuel cost in GUI
		- Lower Solid Fuel and ElectricCharge costs (oops)
		- Fix so science sandbox is still detected as "has R&D tree"
		- Add setting for unit label
		- A Modular Engine will switch to the first available config if its current config is not available (due to requiring a tech tree node you don't have researched).
		- Starman4308: SpaceY tank configs
		- Starwaster: configs for TT's Mk2 nosecone and Nertea's MkIV system.
* 2014-1124: 8.2pre (NathanKell) for KSP 0.24.2 PRE-RELEASE
	+ Update heat pumps (thanks Starwaster)
	+ Fix added parts to be MM clones
	+ taniwha: lots of refactoring
	+ regex: add lots of missing tanks (FASA, HGR, NP2, RLA, SXT)
	+ dreadicon: improved KSPI config
	+ camlost: RetroFuture tank configs
	+ TriggerAu: include icons for ARP in RealFuels rather than in ARP
	+ taniwha: correct tank cost calcs
	+ Raptor831: Add missing NP2, HGR tanks; Add Taurus pod/SM tanks
	+ lilienthal: fix Thermal Fin description
	+ Starman-4308: Add configs for Modular Rocket System
	+ Add support for the 0.625m tanks in Ven's Stock Part Revamp
	+ Show tank/fuel cost in GUI
	+ Lower Solid Fuel and ElectricCharge costs (oops)
	+ Fix so science sandbox is still detected as "has R&D tree"
* 2014-1018: 8.1 (NathanKell) for KSP 0.24.2
	+ Fix my stupidity; I forgot to change some of RF's own patches to account for the new resource names.
	+ camlost: fix tank name for new FS.
	+ Fix applying changes to resource amounts more than once on TweakScale rescale.
	+ Change FS fuselages to calculate their own basemass.
	+ Fix a GUI click-locking issue.
	+ Remove old/broken KSPI interaction config; a new one is in the works by dreadicon and Northstar1989.
* 2014-1018: 8.1pre (jbengtson) for KSP 0.24.2 PRE-RELEASE
	+ Interim release to handle the incorrect fuel names per NathanKell's last commit.
* 2014-1013: 8.0 (NathanKell) for KSP 0.24.2
	+ Changelog:
		- SAVE-BRREAKING - however, regex made a tool to attempt to update saves. Post on the thread if you want to try it out.
		- Redone resources by regex: some resources have changed name, a couple generic ones have been made into various specific ones, and many new (often scary) resources have been added. Note that all resources now have costs, normalized for 1 fund = $1000 in 1965 US Dollars.
		- Redone tank masses to better match extant launch vehicles. LV performance will decrease, since mostly that means dry mass went up.
		- Cryogenic tank type is now modeled on the Delta IV and Ariane 5 cores; the Shuttle ET is best modeled as a BalloonCryo tank with some ballast.
		- RCS, RCSHighEfficiency, Jet, and Oxy tanks are deprecated. Fuselage is ServiceModule with slightly higher mass (used for planes) and Structural is Default with the same basemass as Fuselage (used for planes when the tank doesn't need to be highly pressurized, or have electricity, life support, etc.)
		- Updated to MM 2.5.1 (and added FOR[] to the patches).
		- Updated SPP patches for .25, redid volumes.
		- Fixed for current Tweakscale; should now finally work right!
		- taniwha: refueling pump now works, costs funds, and only works if at KSC.
		- Disabled when incompatible KSP detected (.24 or any non-.25 version, .25Winx64), though unlocked versions are available on request by PM (on condition of no redistribution and no support)
* 2014-1001: 7.4 (NathanKell) for KSP 0.24.2
	+ Changelog:
		- B9 configs removed from RF; they are included in B9 itself.
		- Fixed so tank-switching can be done after a database reload
		- Added procedural cost, with taniwha
		- Fixed refueling pumps again, with taniwha (they respect flow and flow type, and cost funds)
		- Autoconfig buttons moved to the top of the list, and fixed (will now treat jets etc properly, and both multimode modes)
		- Supports multiple ModuleEngineConfigs per part (i.e. Multi mode engines, engine+RCS, etc)
		- Maeyanie: add support for SXT and KAX
		- Removed some unneeded Firespitter entries
		- Supports Tweakscale again, internally. NOTE if you do not have tweakscale, you will get a harmless exception in the log about failing to load Tweakscale_Realfuels.dll. Ignore it.
		- Made all RCS tanks into ServiceModule tanks (finally); deprecated old RCS tank type.
		- Aristurtle Support blackheart's AJKD and KSLO mods.
		- Raptor831: Support for Kommit Nucleonics, KSPI improvement, Near Future
* 2014-0815: 7.3 (NathanKell) for KSP 0.24.2
	+ Changelog:
		- Change versioning to 0.x.y internally.
		- Only apply SF patch to parts with SolidFuel (less log spam)
		- Fixed KIDS interoperabilty
		- Fixed so that throttle and massMult work for CONFIGs that don't use techlevels.
		- thrustCurves now modify heat in proportion to thrust
		- Launch clamp refuel pumps default to off (note: the value is persistent, so if you have a saved craft from before this change, and it has clamps, they will still be defaulting to on).
		- aristurtle: fix bugs in HGR config, fix KW typos, add more KW tanks, add KSO tanks
		- Increase B9 spaceplane parts fuel capacity by 1.5x to bring them more in line with their physical volume, switch them to using Fuselage tank type
		- Fix right-click menu displays regarding rated thrust; now there is only one display, and it only shows up when there is a thrustCurve in use.
* 2014-0803: 7.2 (NathanKell) for KSP 0.24.2
	+ Changelog
		- Fix bug with auto-rescaling of solid fuel resources.
		- aristurtle: add support for 5m KW tanks
		- Add back ModuleRCSFX support (get ModuleRCSFX from Realism Overhaul)
		- Fix the exposed Isp multipliers (for interoperability)
		- Add more failsafe checks and ways to avoid issues in Win x64
		- Add support for thrustCurve in CONFIG (x = ratio of currentFuel/maxFuel, y = multiplier to thrust)
		- Allow local overriding of the visbility of the Volume Utilization slider
		- Update to KSPAPIExtensions 1.7.0
* 2014-0725: 7.1 (NathanKell) for KSP 0.24.2
	+ Update to KSP 0.24.2
* 2014-0725: 7.0 (NathanKell) for KSP 0.24.1
	+ Add tanks to more FS parts
	+ Disable TweakScale on any part with a ModuleEngineConfigs / ModuleHybridEngine_
	+ TACLS now supports RF/MFT natively, so removed TACLS interaction cfg.
	+ Enable ElectricCharge in fuselages
	+ Update ElectricCharge utilization to be 500 rather than 100 (mass per EC unchanged). Now it quite closely matches Silver Zinc Oxide batteries in volume as well as mass.
	+ Spanier: add KSPX Short 2.5m RCS config.
	+ Revert to showing the full precision volume of tanks.
	+ Removed configs for B9 jets and rockets; use AJE.
	+ Removed last remaining engine configs (Starwaster's NTRs, TT Vector engine)--use an engine pack!
	+ By default bring back up the mass of solid fuel in a part to where it was pre-RF. Later configs will override.
	+ Temporarily disable the "dedicated" setting for tanks, it's just causing issues.
	+ Update to 0.24.1
* 2014-0703: 6.4 (NathanKell) for KSP 0.23.5
	+ Changelog:
		- Allow fuselages to hold life support resources
		- Allow CONFIGs to have techRequired items (can limit available Engine Configs based on R&D nodes researched)
		- Fix service modules to not start full when TACLS/ECLSS is installed
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
