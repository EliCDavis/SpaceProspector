using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EliCDavis.Scenes.MainMenu
{

	public class TextBlink : MonoBehaviour {

		[SerializeField]
		GameObject objectToBlink;

		void Update () {
			objectToBlink.SetActive ((int)Time.time % 2 == 0);
		}
	}

}