using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EliCDavis.Player {

	public static class PlayerFactory  {

		private static GameObject playerReference = null;
		private static GameObject GetPlayerReference(){
			if (playerReference == null) {
				playerReference = Resources.Load <GameObject>("Player");
			}
			return playerReference;
		}

		public static GameObject CreatePlayer(Vector3 position) {
			GameObject instance = GameObject.Instantiate (GetPlayerReference(), position, Quaternion.identity);
			PlayerManager.GetInstance ().SetPlayer (instance.GetComponent<PlayerBehavior>());
			return instance;
		}
	}

}