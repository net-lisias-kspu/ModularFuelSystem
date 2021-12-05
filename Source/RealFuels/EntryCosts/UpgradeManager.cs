using System.Collections.Generic;
using System.Collections;

using UnityEngine;

namespace ModularFuelSystem
{
    [KSPScenario(ScenarioCreationOptions.AddToAllGames, new GameScenes[] { GameScenes.EDITOR, GameScenes.SPACECENTER })]
    public class EntryCostManager : ScenarioModule
    {
        #region Fields

        protected static Dictionary<string, EngineConfigUpgrade> configUpgrades;
        protected static Dictionary<string, TLUpgrade> techLevelUpgrades;

        #region Instance

        private static EntryCostManager _instance = null;
        public static EntryCostManager Instance
        {
            get
            {
                return _instance;
            }
        }

        #endregion

        #endregion

        #region Overrides and Monobehaviour methods

        public override void OnAwake()
        {
            base.OnAwake();

            if (_instance != null)
            {
                Object.Destroy(_instance);
            }
            _instance = this;

            if (configUpgrades == null) // just in case
                FillUpgrades();

            EntryCostDatabase.Initialize(); // should not be needed though.
        }

        public void Destroy()
        {
            if (_instance == this)
                _instance = null;
        }

        protected IEnumerator UpdateEntryCosts_Coroutine()
        {
            yield return null;
            yield return null;

            EntryCostDatabase.UpdatePartEntryCosts();
            EntryCostDatabase.UpdateUpgradeEntryCosts();
        }

        public override void OnLoad(ConfigNode node)
        {
            base.OnLoad(node);

            EntryCostDatabase.Load(node.GetNode("Unlocks"));

            string tlName = string.Empty;
            if (HighLogic.CurrentGame.Mode == Game.Modes.CAREER)
            {
                foreach (ConfigNode n in node.GetNodes("TLUpgrade"))
                {
                    if (n.TryGetValue("name", ref tlName))
                    {
                        if (techLevelUpgrades.TryGetValue(tlName, out TLUpgrade tU))
                            tU.Load(n);
                        else
                            techLevelUpgrades[tlName] = new TLUpgrade(n);
                    }
                }
            }

            // Do this in a coroutine so we run after the PartUpgradeManager loads.
            StartCoroutine(UpdateEntryCosts_Coroutine());
        }
        public override void OnSave(ConfigNode node)
        {
            base.OnSave(node);
            if (HighLogic.CurrentGame.Mode == Game.Modes.CAREER)
            {
                foreach (TLUpgrade tU in techLevelUpgrades.Values)
                {
                    tU.Save(node.AddNode("TLUpgrade"));
                }
            }

            EntryCostDatabase.Save(node.AddNode("Unlocks"));
        }
        #endregion

        #region Methods

        public static void FillUpgrades()
        {
            if (PartLoader.Instance == null || PartLoader.LoadedPartsList == null)
            {
                log.error("Partloader instance null or list null!");
                return;
            }

            configUpgrades = new Dictionary<string, EngineConfigUpgrade>();
            techLevelUpgrades = new Dictionary<string, TLUpgrade>();

            for (int a = PartLoader.LoadedPartsList.Count; a-- > 0;)
            {
                AvailablePart ap = PartLoader.LoadedPartsList[a];

                if (ap == null || ap.partPrefab == null)
                    continue;

                Part part = ap.partPrefab;
                if (part.Modules == null)
                    continue;

                for (int i = part.Modules.Count; i-- > 0;)
                {
                    PartModule m = part.Modules[i];
                    if (m is ModuleEngineConfigs)
                    {
                        ModuleEngineConfigs mec = m as ModuleEngineConfigs;
                        mec.CheckConfigs();
                        for (int j = mec.configs.Count; j-- > 0;)
                        {
                            ConfigNode cfg = mec.configs[j];
                            string cfgName = cfg.GetValue("name");
                            if (!string.IsNullOrEmpty(cfgName))
                            {
                                if (RFSettings.Instance.usePartNameInConfigUnlock)
                                    cfgName = Utilities.GetPartName(ap) + cfgName;

                                // config upgrades
                                if (!configUpgrades.ContainsKey(cfgName))
                                {
                                    EngineConfigUpgrade eConfig = new EngineConfigUpgrade(cfg, cfgName);
                                    configUpgrades[cfgName] = eConfig;
                                }

                                // TL upgrades
                                if (mec.techLevel >= 0)
                                {
                                    TLUpgrade tU = new TLUpgrade(cfg, mec);
                                    techLevelUpgrades[tU.name] = tU;
                                }
                            }
                        }
                    }
                }
            }
        }

        public void OnPartPurchased(AvailablePart ap)
        {
            EntryCostDatabase.SetUnlocked(ap);

            if (ap.partPrefab is Part part)
            {
                for(int i = part.Modules.Count - 1; i >= 0; --i)
                {
                    PartModule m = part.Modules[i];
                    if(m is ModuleEngineConfigs)
                    {
                        ModuleEngineConfigs mec = m as ModuleEngineConfigs;
                        mec.CheckConfigs();
                        for(int j = mec.configs.Count - 1; j >= 0; --j)
                        {
                            ConfigNode cfg = mec.configs[j];
                            if(cfg.HasValue("name"))
                            {
                                string cfgName = cfg.GetValue("name");
                                
                                // TL upgrades
                                if (mec.techLevel >= 0)
                                {
                                    string tUName = Utilities.GetPartName(ap) + cfgName;
                                    SetTLUnlocked(tUName, mec.techLevel);
                                }
                            }
                        }
                    }
                }
            }

            EntryCostDatabase.UpdatePartEntryCosts();
        }

        public void OnPartUpgradePurchased(PartUpgradeHandler.Upgrade up)
        {
            EntryCostDatabase.SetUnlocked(up);

            EntryCostDatabase.UpdateUpgradeEntryCosts();
        }
        
        public bool ConfigUnlocked(string cfgName)
        {
            return EntryCostDatabase.IsUnlocked(cfgName);
        }

        public double ConfigEntryCost(string cfgName)
        {
            EntryCostDatabase.ClearTracker();
            return EntryCostDatabase.GetCost(cfgName);
        }

        public double ConfigEntryCost(IEnumerable<string> cfgNames)
        {
            EntryCostDatabase.ClearTracker();
            double sum = 0;
            foreach (string cfgName in cfgNames)
            {
                sum += EntryCostDatabase.GetCost(cfgName);
            }

            return sum;
        }

        public bool PurchaseConfig(string cfgName)
        {
            if (ConfigUnlocked(cfgName))
                return false;

            double cfgCost = ConfigEntryCost(cfgName);
            if (!HighLogic.CurrentGame.Parameters.Difficulty.BypassEntryPurchaseAfterResearch)
            {
                if (Funding.Instance.Funds < cfgCost)
                    return false;

                Funding.Instance.AddFunds(-cfgCost, TransactionReasons.RnDPartPurchase);
            }

            EntryCostDatabase.SetUnlocked(cfgName);

            EntryCostDatabase.UpdatePartEntryCosts();

            return true;
        }

        public int TLUnlocked(string tUName)
        {
            TLUpgrade tU = null;
            if (techLevelUpgrades.TryGetValue(tUName, out tU))
                return tU.currentTL;
            log.error("TL {0} does not exist!", tUName);
            return -1;
        }

        public void SetTLUnlocked(string tUName, int newVal)
        {
            TLUpgrade tU = null;
            if (techLevelUpgrades.TryGetValue(tUName, out tU))
            {
                if (newVal > tU.currentTL)
                    tU.currentTL = newVal;
            }
            else
                log.error("TL {0} does not exist!", tUName);
        }
        public double TLEntryCost(string tUName)
        {
            TLUpgrade tU = null;
            if (techLevelUpgrades.TryGetValue(tUName, out tU))
                return tU.techLevelEntryCost;

            log.error("TL " + tUName + " does not exist!", tUName);
            return 0d;
        }
        public double TLSciEntryCost(string tUName)
        {
            TLUpgrade tU = null;
            if (techLevelUpgrades.TryGetValue(tUName, out tU))
                return tU.techLevelSciEntryCost;
            log.error("TL {0} does not exist!", tUName);
            return 0d;
        }
        public bool PurchaseTL(string tUName, int tl, double multiplier)
        {
            if (TLUnlocked(tUName) >= tl)
                return false;

            double tuCost = TLEntryCost(tUName) * multiplier;
            if (!HighLogic.CurrentGame.Parameters.Difficulty.BypassEntryPurchaseAfterResearch)
            {
                if (Funding.Instance.Funds < tuCost)
                    return false;

                Funding.Instance.AddFunds(-tuCost, TransactionReasons.RnDPartPurchase);
            }
            float sciCost = (float)(TLSciEntryCost(tUName) * multiplier);
            if (sciCost > 0f && ResearchAndDevelopment.Instance != null)
            {
                if (!ResearchAndDevelopment.CanAfford(sciCost))
                    return false;
                ResearchAndDevelopment.Instance.AddScience(-sciCost, TransactionReasons.RnDPartPurchase);
            }
            SetTLUnlocked(tUName, tl);
            return true;
        }
        #endregion

		private static readonly KSPe.Util.Log.Logger log = KSPe.Util.Log.Logger.CreateForType<EntryCostManager>(true);
        static EntryCostManager()
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
