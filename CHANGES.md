# Modular Fuel System :: Changes

* 2019-0122: MFT 5.11.2.1 ; RF 12.7.4.1 (Lisias) for KSP >= 1.4
	+ Syncing with upstream:
		-  Analytic thermal improvements:
		-  Assign value to part.analyticInternalInsulationFactor approximating what actual heat transfer would be. (i.e. temperature interpolation at a rate equal to what it should be out of analytic mode)
		-  In analytic mode, adjust part.temperature *immediately* since the lerp rate would retard temperature adjustment.
		- Fix "part already contains resource" log spam.
		- Probably fix incorrect delta-v readouts for vessels with edited tanks.
	+ Addded [INSTALL.md ](https://github.com/net-lisias-kspu/ModularFuelSystem/blob/master/INSTALL.md) with installing instructions.
* 2018-1024: MFT 5.11.0.1 ; RF 12.7.1.1 (Lisias) for KSP 1.4
	+ Adding KSPe hard dependency
		- Using KSPe logging facilities
	+ Code optimizations for compliance and performance
	+ Changing namespace back to ModularFuelSystem, to prevent code conflicts to the official RealFuels namespace
		- Experimental.  
* 2018-0523: 12.7.1 (blowfishpro) for KSP 1.4.3
	+ Fix exceptions when initializing ModuleEnginesRF
	+ Fix mass display in the part action window not accounting for MLI
	+ Remove a bit of log spam
