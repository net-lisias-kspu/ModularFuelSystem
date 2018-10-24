using System;
using UnityEngine;
using System.Reflection;

using KSP.IO;

namespace ModularFuelSystem {

	[KSPAddon(KSPAddon.Startup.Instantly, true)]
	public class MFSVersionReport : MonoBehaviour
	{
		static string version = null;

        public static string GetAssemblyVersionString (Assembly assembly)
        {
            string version = assembly.GetName().Version.ToString ();

			object[] cattrs = assembly.GetCustomAttributes(true);
            foreach (object attr in cattrs) {
                if (attr is AssemblyInformationalVersionAttribute) {
					AssemblyInformationalVersionAttribute ver = attr as AssemblyInformationalVersionAttribute;
                    version = ver.InformationalVersion;
                    break;
                }
            }

            return version;
        }

        public static string GetAssemblyTitle (Assembly assembly)
        {
            string title = assembly.GetName().Name;

			object[] cattrs = assembly.GetCustomAttributes(true);
            foreach (object attr in cattrs) {
                if (attr is AssemblyTitleAttribute) {
					AssemblyTitleAttribute ver = attr as AssemblyTitleAttribute;
                    title = ver.Title;
                    break;
                }
            }

            return title;
        }

		public static string GetVersion ()
		{
			if (version != null) {
				return version;
			}
			Assembly asm = Assembly.GetCallingAssembly ();
			string title = GetAssemblyTitle (asm);
			version = title + " " + GetAssemblyVersionString (asm);
			return version;
		}

		void Start ()
		{
			log.info (GetVersion ());
			Destroy (this);
		}

		private static readonly KSPe.Util.Log.Logger log = KSPe.Util.Log.Logger.CreateForType<MFSVersionReport>(true);
	}
}
