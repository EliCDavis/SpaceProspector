using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EliCDavis.Player
{
	public class BulletBehavior : MonoBehaviour
	{

		[SerializeField]
		private float lifeTime = 5f;

		[SerializeField]
		private GameObject explosionEffect;

		[SerializeField]
		private float effectDuration;

		// Use this for initialization
		void Start ()
		{
			Destroy (gameObject, lifeTime);
		}
	
		// Update is called once per frame
		void OnCollisionEnter (Collision collision)
		{
			EliCDavis.Util.Destructable destroyable = collision.gameObject.GetComponent<EliCDavis.Util.Destructable>();

			if (destroyable != null) {
				destroyable.Damage (.1f);
			}

			Die ();
		}

		private void Die() {
			Destroy (Instantiate (explosionEffect, transform.position, transform.rotation), effectDuration);
			Destroy (gameObject);
		}

	}

}