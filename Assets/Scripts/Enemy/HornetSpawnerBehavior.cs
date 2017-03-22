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

		// Use this for initialization
		void Start ()
		{
			StartCoroutine (StartSpawning());
		}
	
		// Update is called once per frame
		void Update ()
		{
		
		}

		private IEnumerator StartSpawning(){
			while (target != null) {
				yield return new WaitForSeconds (spawnRate);
				GameObject hornetInstance = Instantiate (hornet, transform.position + (transform.forward * 4), transform.rotation);
				hornetInstance.GetComponent<HornetBehavior> ().SetTarget (target);
			}
		}

	}

}