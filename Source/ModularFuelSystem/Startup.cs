using UnityEngine;

using ModularFuelSystem;

namespace ModularFuelTanks
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    internal class Startup : MonoBehaviour
	{
        private void Start()
        {
            log.force("Version {0}", Version.Text);

            try
            {
                KSPe.Util.Compatibility.Check<Startup>(typeof(Version), typeof(Configuration));
                KSPe.Util.Installation.Check<Startup>(typeof(Version));
            }
            catch (KSPe.Util.InstallmentException e)
            {
                log.error(e.ToShortMessage());
                KSPe.Common.Dialogs.ShowStopperAlertBox.Show(e);
            }
        }

        private static readonly KSPe.Util.Log.Logger log = KSPe.Util.Log.Logger.CreateForType<Startup>(true);
        static Startup()
        {
            log.level =
#if DEBUG
                    KSPe.Util.Log.Level.TRACE
#else
                    KSPe.Util.Log.Level.INFO
#endif
                ;
        }
    }
}
