using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EliCDavis.Scenes.Mining
{

	public static class OreFactory  {

		private static GameObject goldOreReference = null;
		private static GameObject GetGoldOreReference(){
			if (goldOreReference == null) {
				goldOreReference = Resources.Load <GameObject>("Gold Ore");
			}
			return goldOreReference;
		}


		public static GameObject CreateOre(OreType typeOfOre, Vector3 position, Quaternion rotation) {

			GameObject ore = null;

			switch (typeOfOre) {

			case OreType.Gold:
				ore = GameObject.Instantiate (GetGoldOreReference (), position, Quaternion.identity);
				break;

			default:
				ore = GameObject.Instantiate (GetGoldOreReference (), position, Quaternion.identity);
				break;

			}

			return ore;
		}

	}

}