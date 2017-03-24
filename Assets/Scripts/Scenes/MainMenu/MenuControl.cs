using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EliCDavis.Scenes.MainMenu
{

	public class MenuControl : MonoBehaviour {

		[SerializeField]
		private GameObject mainCamera;

		[SerializeField]
		private GameObject storyObjects;

		[SerializeField]
		private GameObject[] titleUI;

		[SerializeField]
		private GameObject[] storyUI;

		bool story = false;

		void Update () {
		
			if (Input.GetKeyDown(KeyCode.Space) && !story) {
				mainCamera.transform.parent = null;
				storyObjects.transform.parent = null;
				StartCoroutine (ShowStory());
				story = true;
			}

		}

		private IEnumerator ShowStory(){
			yield return new WaitForSeconds(1f);
			storyObjects.SetActive (true);
			foreach (GameObject item in titleUI) {
				item.SetActive (false);
			}
		}

	}

}