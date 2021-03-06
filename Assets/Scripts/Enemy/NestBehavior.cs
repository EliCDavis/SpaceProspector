﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EliCDavis.Enemy {

	public class NestBehavior : EliCDavis.Util.Destructable {

		[SerializeField]
		HornetSpawnerBehavior[] spawners;

		GameObject target;

		void Start()
		{
			target = EliCDavis.Player.PlayerManager.GetInstance ().GetPlayer ().gameObject;
		}

		void Update()
		{
			if (target == null) {
				Destroy (this);
				return;
			}

			if(Vector3.Distance(target.transform.position, transform.position) < 100){
				foreach(HornetSpawnerBehavior spawner in spawners){
					spawner.BeginSpawning (target, 4f);
				}
			}
		}

		protected override void OnDamage ()
		{
			foreach(HornetSpawnerBehavior spawner in spawners){
				spawner.BeginSpawning (target, 1.5f);
			}
		}

		private IEnumerator AnimateTakingDamage(){
			gameObject.GetComponent<MeshRenderer> ().material.color = Color.red;
			yield return new WaitForSeconds(.2f);
			gameObject.GetComponent<MeshRenderer> ().material.color = Color.white;
		}
	}

}