using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EliCDavis.Enemy
{

	public class HornetSpawnerBehavior : MonoBehaviour
	{

		[SerializeField]
		private GameObject hornet;

		[SerializeField]
		private float spawnRate;

		[SerializeField]
		private GameObject target;

		private bool currentlySpawning;

		void Start()
		{
			currentlySpawning = false;
		}

		public void BeginSpawning (GameObject target, float spawnRate)
		{
			this.target = target;
			this.spawnRate = spawnRate;
			if (!currentlySpawning) {
				StartCoroutine (StartSpawning());
			}
		}

		private IEnumerator StartSpawning(){
			currentlySpawning = true;
			while (target != null && Vector3.Distance(transform.position, target.transform.position) < 800) {
				GameObject hornetInstance = Instantiate (hornet, transform.position + (transform.forward * 4), transform.rotation);
				hornetInstance.GetComponent<HornetBehavior> ().SetTarget (target);
				yield return new WaitForSeconds (spawnRate);
			}
			currentlySpawning = false;
		}

	}

}