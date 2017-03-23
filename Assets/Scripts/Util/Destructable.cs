using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EliCDavis.Util {

	public class Destructable : MonoBehaviour {

		[SerializeField]
		private float health = 1f;

		[SerializeField]
		private GameObject deathEffect; 

		[SerializeField]
		private float deathEffectDuration = 0.95f;

		/// <summary>
		/// Damages the object, potentially killing it
		/// </summary>
		/// <param name="amount">Amount.</param>
		public void Damage(float amount) {
			health = Mathf.Max (0, health - amount);
			if(health == 0){
				Die ();
			}
		}

		/// <summary>
		/// Kills the object, invoking an OnDeath event
		/// </summary>
		public void Die() {
			OnDeath ();
			if(deathEffect != null){
				Destroy(Instantiate (deathEffect, transform.position, transform.rotation),deathEffectDuration);
			}
			Destroy (gameObject);
		}

		/// <summary>
		/// Raises the death event.
		/// Used to be overriden in parent classes
		/// </summary>
		protected virtual void OnDeath() {}

	}

}