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

		private static GameObject nestReference = null;
		private static GameObject GetNestReference() {
			if (nestReference == null) {
				nestReference = Resources.Load <GameObject>("Wasp Nest");
			}
			return nestReference;
		}

		public static GameObject CreateAsteroid(Vector3 position, Quaternion rotation, AsteroidType typeOfAsteroid) {
			GameObject reference = null;

			switch (typeOfAsteroid) {

			case AsteroidType.Ore:
				reference = GetAsteroidReference ();
				break;

			case AsteroidType.Regular:
				reference = GetFloatyAsteroidReference();
				break;

			case AsteroidType.Nest:
				reference = GetNestReference ();
				break;

			default:
				reference = GetFloatyAsteroidReference ();
				break;

			}

			return GameObject.Instantiate (reference, position, rotation);
		}

	}
}
