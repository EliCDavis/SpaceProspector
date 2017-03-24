using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EliCDavis.Player;


namespace EliCDavis.Scenes.Mining {

	public class GameManager : MonoBehaviour {

		// Use this for initialization
		void Start () {
			PlayerFactory.CreatePlayer (Vector3.zero);
			GenerateAsteroids (15);
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		private void GenerateAsteroids(int layers) {

			for(int layer = 1; layer < layers + 1; layer++){

				int numOfAsteroids = Random.Range (25, 25 + (int)(layer * layer*.8f));

				for (int asteroid = 0; asteroid < numOfAsteroids; asteroid++) {

					AsteroidType asteroidType = AsteroidType.Ore;
					float decision = Random.Range (0f, 1f);
					if(decision> .4f){
						asteroidType = decision > .9f ? AsteroidType.Regular: AsteroidType.Nest;
					}

					GameObject ast = AsteroidFactory.CreateAsteroid (
						Random.onUnitSphere*(layer*200), 
						Quaternion.Euler(
							Random.Range(0, 180),
							Random.Range(0, 180),
							Random.Range(0, 180)
						), 
						asteroidType
					);

					if (asteroidType != AsteroidType.Ore) {
						ast.GetComponent<Rigidbody> ().AddTorque (Random.onUnitSphere*2000, ForceMode.Impulse);
					}

				}

			}

		}

	}

}