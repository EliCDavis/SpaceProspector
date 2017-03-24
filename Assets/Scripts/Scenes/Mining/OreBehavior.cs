using System.Collections;
using UnityEngine;
using EliCDavis.Collectable;

namespace EliCDavis.Scenes.Mining
{

	public class OreBehavior : EliCDavis.Util.Destructable
	{

		GameObject graphics;
		Color originalColor;

		void Start() {
			graphics = transform.FindChild ("Graphics").gameObject;
			originalColor = graphics.GetComponent<MeshRenderer> ().material.color;
		}

		/// <summary>
		/// Here we should probably expell lots of ore or omething
		/// </summary>
		protected override void OnDeath ()
		{
			CollectableFactory.CreateCollectable (CollectableType.Gold, transform.position);
		}

		protected override void OnDamage ()
		{
			StartCoroutine (AnimateTakingDamage());
		}

		private IEnumerator AnimateTakingDamage(){
			graphics.GetComponent<MeshRenderer> ().material.color = Color.blue;
			yield return new WaitForSeconds(.2f);
			graphics.GetComponent<MeshRenderer> ().material.color = originalColor;
		}

	}

}