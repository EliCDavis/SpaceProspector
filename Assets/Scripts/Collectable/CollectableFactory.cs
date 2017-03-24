using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EliCDavis.Collectable {
	
	public static class CollectableFactory {

		private static GameObject goldOreReference = null;
		private static GameObject GetGoldOreReference(){
			if (goldOreReference == null) {
				goldOreReference = Resources.Load <GameObject>("Gold Ore Collectable");
			}
			return goldOreReference;
		}

		public static GameObject CreateCollectable(CollectableType typeOfCollectable, Vector3 position){
			GameObject collectable = null;
		
			switch (typeOfCollectable) {

			case CollectableType.Gold:
				collectable = GameObject.Instantiate(GetGoldOreReference (), position, Quaternion.identity);
				break;
			
			default:
				collectable = GameObject.Instantiate(GetGoldOreReference (), position, Quaternion.identity);
				break;

			}

			return collectable;
		}

	}

}