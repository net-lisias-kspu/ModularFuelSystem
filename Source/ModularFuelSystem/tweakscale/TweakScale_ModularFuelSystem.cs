using TweakScale;

namespace ModularFuelSystem
{
    public class TweakScaleModularFuelTanksUpdater : IRescalable<ModularFuelSystem.Tanks.ModuleFuelTanks>
    {
		private ModularFuelSystem.Tanks.ModuleFuelTanks Module { get; }
		private Part Part => Module.part;

		public TweakScaleModularFuelTanksUpdater(ModularFuelSystem.Tanks.ModuleFuelTanks pm)
        {
			Module = pm;
        }

        public void OnRescale(ScalingFactor factor)
        {
            Module.ChangeVolumeRatio(factor.relative.cubic, false); // do not propagate since TS itself will.
            // hacky; will fix.
            /*foreach (PartResource f in Part.Resources)
            {
                f.amount /= factor.relative.cubic;
                f.maxAmount /= factor.relative.cubic;
            }*/
        }
    }
}
