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

		private static GameObject floatyAsteroidReference = null;
		private static GameObject GetFloatyAsteroidReference() {
			if (floatyAsteroidReference == null) {
				floatyAsteroidReference = Resources.Load <GameObject>("Asteroid B");
			}
			return floatyAsteroidReference;
		}

		public static GameObject CreateAsteroid(Vector3 position, Quaternion rotation, bool withOres) {
			return GameObject.Instantiate (withOres? GetAsteroidReference() : GetFloatyAsteroidReference(), position, rotation);
		}

	}
}
