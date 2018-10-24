using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace ModularFuelSystem.TechLevels
{
    public class TechLevel
    {
        protected FloatCurve atmosphereCurve;
        protected FloatCurve velocityCurve;
        protected double TWR;
        protected double thrustMultiplier;
        protected double massMultiplier;
        protected double minThrottleMultiplier;
        protected float gimbalRange;
        protected string techRequired;
        protected float costMult;

        public static ConfigNode globalTechLevels = null;

        // CONSTRUCTORS
        public TechLevel()
        {
            atmosphereCurve = new FloatCurve();
            velocityCurve = new FloatCurve();
            TWR = -1;
            thrustMultiplier = -1;
            massMultiplier = -1;
            minThrottleMultiplier = -1;
            gimbalRange = -1f;
            techRequired = "";
            costMult = 1f;

            LoadGlobals();
        }
        public TechLevel(TechLevel t)
        {
            atmosphereCurve = t.atmosphereCurve;
            velocityCurve = t.velocityCurve;
            TWR = t.TWR;
            thrustMultiplier = t.thrustMultiplier;
            massMultiplier = t.massMultiplier;
            gimbalRange = t.gimbalRange;
            techRequired = t.techRequired;
            minThrottleMultiplier = t.minThrottleMultiplier;
            costMult = t.costMult;

            LoadGlobals();
        }
        public TechLevel(ConfigNode node)
        {
            Load(node);

            LoadGlobals();
        }

        // LOADERS
        // Gets global node
        protected bool LoadGlobals()
        {
            if (globalTechLevels == null)
            {
                globalTechLevels = RFSettings.Instance.techLevels;
            }

            return globalTechLevels != null;
        }

        // loads from an override node
        public bool Load(ConfigNode node)
        {
            if (node.HasNode("atmosphereCurve"))
                atmosphereCurve.Load(node.GetNode("atmosphereCurve"));
            else
            {
                atmosphereCurve = null;
                return false;
            }

            if (node.HasNode("velocityCurve"))
                velocityCurve.Load(node.GetNode("velocityCurve"));
            else
                velocityCurve = null;

			TWR = node.HasValue("TWR") ? double.Parse(node.GetValue("TWR")) : -1;

			thrustMultiplier = node.HasValue("thrustMultiplier") ? double.Parse(node.GetValue("thrustMultiplier")) : -1;

			massMultiplier = node.HasValue("massMultiplier") ? double.Parse(node.GetValue("massMultiplier")) : -1;

			minThrottleMultiplier = node.HasValue("minThrottleMultiplier") ? double.Parse(node.GetValue("minThrottleMultiplier")) : -1;

			gimbalRange = node.HasValue("gimbalRange") ? float.Parse(node.GetValue("gimbalRange")) : -1;

			costMult = node.HasValue("costMult") ? float.Parse(node.GetValue("costMult")) : 1f;

			techRequired = node.HasValue("techRequired") ? node.GetValue("techRequired") : "";

			return true;
        }

        // loads a given techlevel from global techlevels-style node
        public bool Load(ConfigNode node, int level)
        {
			ConfigNode[] tLs = node.GetNodes("TECHLEVEL");
            if (tLs.Any())
            {
                foreach (ConfigNode n in tLs)
                    if (n.HasValue("name") && n.GetValue("name").Trim().Equals(level.ToString()))
                        return Load(n);
                return false;
            }

            if (node.HasValue("techLevelType"))
                return Load(node.GetValue("techLevelType"), level);

            if (node.HasNode("TLISP" + level))
                atmosphereCurve.Load(node.GetNode("TLISP" + level));
            else
            {
                atmosphereCurve = null;
                return false;
            }

            if (node.HasNode("TLVC" + level))
                velocityCurve.Load(node.GetNode("TLVC" + level));
            else
                velocityCurve = null;

			TWR = node.HasValue("TLTWR" + level) ? double.Parse(node.GetValue("TLTWR" + level)) : 60;

			minThrottleMultiplier = node.HasValue("TLTHROTTLE" + level) ? double.Parse(node.GetValue("TLTHROTTLE" + level)) : 0.0;

			gimbalRange = node.HasValue("TLGIMBAL" + level) ? float.Parse(node.GetValue("TLGIMBAL" + level)) : -1;

			costMult = node.HasValue("TLCOST" + level) ? float.Parse(node.GetValue("TLCOST" + level)) : 1;

			techRequired = node.HasValue("TLTECH" + level) ? node.GetValue("TLTECH" + level) : "";

			return true;
        }

        // loads from global techlevels
        public bool Load(string type, int level)
        {

            if (globalTechLevels == null)
                return false;
            foreach (ConfigNode node in globalTechLevels.GetNodes("ENGINETYPE"))
            {
                if (node.HasValue("name") && node.GetValue("name").Equals(type))
                    return Load(node, level);
            }
            return false;
        }

        // loads from anything
        public bool Load(ConfigNode cfg, ConfigNode mod, string type, int level)
        {
            // check local techlevel configs
            if (cfg != null)
            {
				ConfigNode[] tLs = cfg.GetNodes("TECHLEVEL");
                if (tLs.Any())
                {
                    foreach (ConfigNode n in tLs)
                        if (n.HasValue("name") && n.GetValue("name").Equals(level.ToString()))
                            return Load(n);
                    return false;
                }
                if (cfg.HasValue("techLevelType"))
                    return Load(cfg.GetValue("techLevelType"), level);
            }

            // check module techlevel configs
            if (mod != null)
            {
				ConfigNode[] tLs = mod.GetNodes("TECHLEVEL");
                if (tLs.Any())
                {
                    foreach (ConfigNode n in tLs)
                        if (n.HasValue("name") && n.GetValue("name").Equals(level.ToString()))
                            return Load(n);
                    return false;
                }
            }

            // check global
            //log.detail("Fallback to global for type {0}, TL {1}", type, level);
            return Load(type, level);
        }

        // MULTIPLIERS
        public double Thrust(TechLevel oldTL, bool constantMass = false)
        {
			return 
				oldTL.thrustMultiplier > 0 && thrustMultiplier > 0
					? thrustMultiplier / oldTL.thrustMultiplier
				: constantMass
					? TWR / oldTL.TWR
				: TWR / oldTL.TWR * oldTL.atmosphereCurve.Evaluate(0) / atmosphereCurve.Evaluate(0);
		}

		public double Mass(TechLevel oldTL, bool constantThrust = false)
        {
			return
				oldTL.massMultiplier > 0 && massMultiplier > 0
					? massMultiplier / oldTL.massMultiplier
				: constantThrust 
					? oldTL.TWR / TWR 
				: oldTL.atmosphereCurve.Evaluate(0) / atmosphereCurve.Evaluate(0);
		}

		public double Throttle()
        {
			return 
				minThrottleMultiplier < 0 
					? 0.0
				: minThrottleMultiplier > 1.0 
					? 1.0
				: minThrottleMultiplier;
		}

		public float GimbalRange
        {
            get
            {
                return gimbalRange;
            }
        }

        public float CostMult
        {
            get
            {
                return costMult;
            }
        }

        public FloatCurve AtmosphereCurve
        {
            get
            {
                return atmosphereCurve;
            }
        }

        // looks up in global techlevels
        public static int MaxTL(string type)
        {
            int max = -1;
            if (globalTechLevels == null)
                return max;
            foreach (ConfigNode node in globalTechLevels.GetNodes("ENGINETYPE"))
            {
                if (node.HasValue("name") && node.GetValue("name").Equals(type))
                {
					ConfigNode[] tLs = node.GetNodes("TECHLEVEL");
                    if (tLs.Any())
                    {
                        return MaxTL(node);
                    }
                    foreach (ConfigNode.Value val in node.values)
                    {
                        string stmp = val.name;
                        stmp = stmp.Replace("TLTWR", "");
                        int itmp;
                        if (int.TryParse(stmp.Trim(), out itmp))
                            if (itmp > max)
                                max = itmp;
                    }
                }
            }
            return max;
        }

        // looks up in global techlevels
        public static int MinTL(string type)
        {
            int min = int.MaxValue;
            if (globalTechLevels == null)
                return min;
            foreach (ConfigNode node in globalTechLevels.GetNodes("ENGINETYPE"))
            {
                if (node.HasValue("name") && node.GetValue("name").Equals(type))
                {
					ConfigNode[] tLs = node.GetNodes("TECHLEVEL");
                    if (tLs.Any())
                    {
                        return MinTL(node);
                    }
                    foreach (ConfigNode.Value val in node.values)
                    {
                        string stmp = val.name;
                        stmp = stmp.Replace("TLTWR", "");
                        int itmp;
                        if (int.TryParse(stmp.Trim(), out itmp))
                            if (itmp < min)
                                min = itmp;
                    }
                }
            }
            return min;
        }

        // local check, with optional fallback to global
        public static int MaxTL(ConfigNode node, string type = "")
        {
            int max = -1;
            if (node != null)
            {
                foreach (ConfigNode n in node.GetNodes("TECHLEVEL"))
                {
                    int itmp;
                    if (n.HasValue("name") && int.TryParse(n.GetValue("name").Trim(), out itmp))
                        if (itmp > max)
                            max = itmp;
                }
            }
            if (max < 0 && !type.Equals(""))
                max = MaxTL(type);
            return max;
        }

        // local check, with optional fallback to global
        public static int MinTL(ConfigNode node, string type = "")
        {
            int min = int.MaxValue;
            if (node != null)
            {
                foreach (ConfigNode n in node.GetNodes("TECHLEVEL"))
                {
                    int itmp;
                    if (n.HasValue("name") && int.TryParse(n.GetValue("name").Trim(), out itmp))
                        if (itmp < min)
                            min = itmp;
                }
            }
            if (min >= int.MaxValue && !type.Equals(""))
                min = MinTL(type);
            return min;
        }

        // full check
        public static int MaxTL(ConfigNode cfg, ConfigNode mod, string type)
        {
			return 
				cfg.GetNodes("TECHLEVEL").Any()
					? MaxTL(cfg, type)
				: cfg.HasValue("techLevelType")
					? MaxTL(cfg.GetValue("techLevelType"))
				: MaxTL(mod, type);
		}

		// full check
		public static int MinTL(ConfigNode cfg, ConfigNode mod, string type)
        {
			return
				cfg.GetNodes("TECHLEVEL").Any()
					? MinTL(cfg, type)
				: cfg.HasValue("techLevelType")
					? MinTL(cfg.GetValue("techLevelType"))
				: MinTL(mod, type);
		}

		// Check if can switch to TL
		public static bool CanTL(ConfigNode cfg, ConfigNode mod, string type, int level)
        {
            TechLevel nTL = new TechLevel();
            if (!nTL.Load(cfg, mod, type, level))
                return false;
            try
            {
                return HighLogic.CurrentGame.Mode == Game.Modes.SANDBOX || nTL.techRequired.Equals("") || ResearchAndDevelopment.GetTechnologyState(nTL.techRequired) == RDTech.State.Available;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
