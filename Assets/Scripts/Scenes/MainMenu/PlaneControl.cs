using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EliCDavis.Scenes.MainMenu
{

	public class PlaneControl : MonoBehaviour {

		[SerializeField]
		GameObject graphics;

		void Update () {
			graphics.transform.Rotate (Vector3.left*Mathf.Sin(Time.time)*.5f*Mathf.PerlinNoise(0, Time.time));
			transform.Translate (transform.forward*20*Time.deltaTime);	
		}

	}

}