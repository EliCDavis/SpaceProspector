using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EliCDavis.Player;


namespace EliCDavis.Scenes.Mining {

	public class GameManager : MonoBehaviour {

		// Use this for initialization
		void Start () {
			PlayerFactory.CreatePlayer (Vector3.zero);
			GenerateAsteroids (10);
		}
		
		// Update is called once per frame
		void Update () {
			
		}


		void GenerateAsteroids(int layers) {

			for(int layer = 1; layer < layers + 1; layer++){

				int numOfAsteroids = Random.Range (5, 5 + (5 * layer));

				for (int asteroid = 0; asteroid < numOfAsteroids; asteroid++) {

					// http://mathworld.wolfram.com/SpherePointPicking.html
					float angle = Random.Range (0f, Mathf.PI * 2);
					float u = Mathf.Cos(angle);

					AsteroidFactory.CreateAsteroid (
						new Vector3(
							Mathf.Sqrt(1-(u*u))*u,
							Mathf.Sqrt(1-(u*u))*Mathf.Sin(angle),
							u
						)*(layer*500), Quaternion.Euler(
							Random.Range(0, 180),
							Random.Range(0, 180),
							Random.Range(0, 180)
						), true
					);
				}

			}

		}

	}

}