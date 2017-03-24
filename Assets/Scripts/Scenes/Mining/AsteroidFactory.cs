using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EliCDavis.Scenes.Mining
{

	public static class AsteroidFactory  {

		private static GameObject asteroidReference = null;
		private static GameObject GetAsteroidReference(){
			if (asteroidReference == null) {
				asteroidReference = Resources.Load <GameObject>("Asteroid");
			}
			return asteroidReference;
		}

		public static GameObject CreateAsteroid(Vector3 position, Quaternion rotation, bool withOres) {
			return GameObject.Instantiate (GetAsteroidReference(), position, rotation);
		}

	}
}
