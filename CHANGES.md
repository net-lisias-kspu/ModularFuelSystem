# Modular Fuel System :: Changes

* 2020-0216: MFT 5.13.0.1 ; RF 12.8.4.2 (Lisias) for KSP >= 1.4
	+ Added KSPe facilities
		- Log
		- Installment check 
	+ Syncing with upstream:
		- Fixed cases where MonoBehaviour derived classes were being called before Awake()
		- Close tank window when tank part is deleted. (Fixes nullref issues when part is deleted with tank window open)
		- Boil-off PAW information visible by default (controlled by config file)
		- Exception handling added for procedural part checks.
		- PARTUPGRADE handling. (both to handle the upgrade and prevent unnecessary and game breaking calls to OnLoad) 
		- Last ditch attempt to patch SSTU parts in conflict with Real Fuels. (tells SSTUModularParts to defer to RF on mass/cost issues and defers to SSTUModularRCS on mass issues) 
		- Fixed issue with tank PAW not being marked dirty by tank GUI window when updating under some conditions.
		- Make MLI cost, mass and max layers configurable (in part config file)
		- Changed Show UI and Hide UI to Show Tank UI and Hide Tank UI (PAW text)
		- Unmanaged resources. ModuleFuelTanks can have UNMANAGED_RESOURCE node to declare a resource name, amount and maxAmount (same format as RESOURCE). Even if all tanks are removed, this unmanaged resource will always be present and all tank resource amounts are in addition to the unmanaged quantity.
		- tank type initializes with Default if no type is specified. (fixes edge case physics breaking bug)
		- GUI performance improvements by @yump
		- Fixed TANK_DEFINITION fallback system
		- Fixes and improvements for engine GUI and engine GUI symmetry handling
		- Fixed issue where selecting different MEC engine configurations would cause a tank PAW to fill with duplicate config buttons. by @todi
added new TANK_DEFINITION fields by @siimav
actually find a fallback MEC config instead of lying and saying we couldn't find one when we didn't look for one!
		- boiloff data available in PAW without spamming the log with debug data.
		- Stock Real Fuels now has MLI Tech Upgrades. Max layers will increase as you progress through fuel / construction nodes in career.
		- Certain procedural parts will correctly calculate tank surface area in editor. (by correct we mean it should match up with what you see in flight mode so costs and mass will be consistent). Does this for SSTU, Procedural Parts, B9 Procedural Wings and ROTanks