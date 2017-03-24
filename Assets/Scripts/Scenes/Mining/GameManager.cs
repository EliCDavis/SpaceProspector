using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EliCDavis.Player;


namespace EliCDavis.Scenes.Mining {

	public class GameManager : MonoBehaviour {

		// Use this for initialization
		void Start () {
			PlayerFactory.CreatePlayer (Vector3.zero);
			GenerateAsteroids (20);
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		private float RandomAngle(){
			return Random.Range (0f, Mathf.PI * 2);
		}

		private void GenerateAsteroids(int layers) {

			for(int layer = 1; layer < layers + 1; layer++){

				int numOfAsteroids = Random.Range (25, 25 + (layer * 2 * layer));

				for (int asteroid = 0; asteroid < numOfAsteroids; asteroid++) {

					bool ore = Random.Range (0f, 1f) > .6f;

					GameObject ast = AsteroidFactory.CreateAsteroid (
						Random.onUnitSphere*(layer*200), 
						Quaternion.Euler(
							Random.Range(0, 180),
							Random.Range(0, 180),
							Random.Range(0, 180)
						), 
						ore
					);

					if (!ore) {
						ast.GetComponent<Rigidbody> ().AddTorque (Random.onUnitSphere*2000, ForceMode.Impulse);
					}

				}

			}

		}

	}

}