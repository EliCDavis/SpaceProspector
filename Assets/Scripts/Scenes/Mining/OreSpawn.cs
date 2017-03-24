using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EliCDavis.Scenes.Mining
{
	
	public class OreSpawn : MonoBehaviour {

		[SerializeField, RangeAttribute(0f,1f)]
		private float chanceForSpawningOre = .5f;

		void Start () {
			if (Random.Range (0f, 1f) <= chanceForSpawningOre) {
				OreFactory.CreateOre (OreType.Gold, transform.position, transform.rotation).transform.parent = transform.parent;
			}

			Destroy (gameObject);
		}
		
	}

}