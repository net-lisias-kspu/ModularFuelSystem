using System.Reflection;
using System.Runtime.CompilerServices;

// Information about this assembly is defined by the following attributes.
// Change them to the values specific to your project.

[assembly: AssemblyTitle("ModularFuelTanks")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("")]
[assembly: AssemblyCopyright("NathanKell")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// The assembly version has the format "{Major}.{Minor}.{Build}.{Revision}".
// The form "{Major}.{Minor}.*" will automatically update the build and revision,
// and "{Major}.{Minor}.{Build}.*" will update just the revision.

[assembly: AssemblyVersion(ModularFuelTanks.Version.Number)]
[assembly: AssemblyInformationalVersionAttribute(ModularFuelTanks.Version.Number)]
[assembly: AssemblyFileVersion(ModularFuelTanks.Version.Number)]

// The following attributes are used to specify the signing key for the assembly,
// if desired. See the Mono documentation for more information about signing.

//[assembly: AssemblyDelaySign(false)]
//[assembly: AssemblyKeyFile("")]

[assembly: KSPAssembly("ModularFuelTanks", ModularFuelTanks.Version.major, ModularFuelTanks.Version.minor)]

[assembly: KSPAssemblyDependency("KSPe", 2, 1)]
[assembly: KSPAssemblyDependency("KSPe.UI", 2, 1)]
