using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EliCDavis.Player;


namespace EliCDavis.Scenes.Mining {

	public class GameManager : MonoBehaviour {

		// Use this for initialization
		void Start () {
			PlayerFactory.CreatePlayer (Vector3.zero);
		}
		
		// Update is called once per frame
		void Update () {
			
		}

	}

}