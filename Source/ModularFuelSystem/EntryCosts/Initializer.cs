using UnityEngine;

namespace ModularFuelSystem
{
    [KSPAddon(KSPAddon.Startup.MainMenu, true)]
    public class EntryCostInitializer : MonoBehaviour
    {
        public void Start()
        {
            EntryCostManager.FillUpgrades();

            EntryCostDatabase.Initialize();

            EntryCostDatabase.UpdatePartEntryCosts();
        }
    }
}
