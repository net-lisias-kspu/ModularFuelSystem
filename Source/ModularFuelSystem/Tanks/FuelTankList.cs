﻿using System.Collections.ObjectModel;

// ReSharper disable InconsistentNaming, CompareOfFloatsByEqualityOperator

namespace ModularFuelSystem.Tanks
{
	public class FuelTankList : KeyedCollection<string, FuelTank>, IConfigNode
	{
		public FuelTankList ()
		{
		}

		public FuelTankList (ConfigNode node)
		{
			Load (node);
		}

		public bool TryGet(string resource, out FuelTank tank)
		{
			if (Contains(resource)) {
				tank = this[resource];
				return true;
			}
			tank = null;
			return false;
		}

		protected override string GetKeyForItem (FuelTank item)
		{
			return item.name;
		}

		public void Load (ConfigNode node)
		{
			if (node == null)
				return;
			foreach (ConfigNode tankNode in node.GetNodes ("TANK")) {
                if (tankNode.HasValue("name"))
                {
                    if (!Contains(tankNode.GetValue("name")))
                        Add(new FuelTank(tankNode));
                    else
                    {
                        log.warn("Ignored duplicate definition of TANK of type " + tankNode.GetValue("name"));
                    }
                }
                else
                    log.warn("TANK node invalid, lacks name");
			}
		}

		public void Save (ConfigNode node)
		{
			foreach (FuelTank tank in this) {
				ConfigNode tankNode = new ConfigNode ("TANK");
				tank.Save (tankNode);
				node.AddNode (tankNode);
			}
		}

        public void TechAmounts()
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (!this[i].canHave)
                    this[i].maxAmount = 0;
            }
        }

        private static readonly KSPe.Util.Log.Logger log = KSPe.Util.Log.Logger.CreateForType<FuelTankList>(true);
        static FuelTankList()
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
