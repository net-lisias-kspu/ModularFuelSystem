﻿using System.Collections.Generic;
using UnityEngine;
using RUI.Icons.Selectable;

using KSP.UI.Screens;

namespace ModularFuelSystem {

	[KSPAddon (KSPAddon.Startup.EditorAny, false) ]
	public class MFTEditorToolbar : MonoBehaviour
	{
		//static Texture texture;
		static Icon icon;
		static HashSet<string> mftItems;

		bool mftItemFilter (AvailablePart ap)
		{
			return mftItems.Contains (ap.name);
		}

		void onGUIEditorToolbarReady ()
		{
			if (icon == null) {
				IconLoader iconloader = PartCategorizer.Instance.iconLoader;
				icon = iconloader.GetIcon("R&D_node_icon_fuelsystems");
			}
			PartCategorizer.Category cat = PartCategorizer.Instance.filters.Find (c => c.button.categoryName == "Filter by Module");
			PartCategorizer.Category subcat = cat.subcategories.Find (c => c.button.categoryName == "Modular Fuel Tank");
			subcat.button.SetIcon (icon);

			cat = PartCategorizer.Instance.filters.Find (c => c.button.categoryName == "Filter by Function");
			PartCategorizer.AddCustomSubcategoryFilter (cat, "MFT Tanks", "MFT Tanks", icon, mftItemFilter);
		}

		void Awake ()
		{
			GameEvents.onGUIEditorToolbarReady.Add (onGUIEditorToolbarReady);
			if (mftItems == null) {
				mftItems = new HashSet<string> ();
			}
			mftItems.Clear ();
			foreach (AvailablePart ap in PartLoader.LoadedPartsList) {
				Part part = ap.partPrefab;
				Tanks.ModuleFuelTanks mft = part.FindModuleImplementing<Tanks.ModuleFuelTanks> ();
				if (mft != null) {
					mftItems.Add (ap.name);
				}
			}
		}

		void OnDestroy ()
		{
			GameEvents.onGUIEditorToolbarReady.Remove (onGUIEditorToolbarReady);
		}
	}
}
