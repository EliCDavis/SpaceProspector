using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EliCDavis.Scenes.MainMenu
{

	public class MenuControl : MonoBehaviour {

		[SerializeField]
		AudioSource spaceBarSound;

		[SerializeField]
		private GameObject mainCamera;

		[SerializeField]
		private GameObject storyObjects;

		[SerializeField]
		private GameObject[] titleUI;

		[SerializeField]
		private GameObject[] storyUI;

		[SerializeField]
		private GameObject[] controlsUI;

		[SerializeField]
		private Rigidbody missileToShoot;

		bool story = false;
		bool controls = false;

		void Update () {
		
			if (Input.GetKeyDown(KeyCode.Space)) {

				spaceBarSound.Play ();

				if (story && controls) {
					SceneManager.LoadScene ("Mining");
				}

				if(story && !controls){
					StartCoroutine (ShowControls());
					missileToShoot.AddForce (missileToShoot.transform.up*100, ForceMode.Impulse);
					controls = true;
				}

				if(!story){
					mainCamera.transform.parent = null;
					storyObjects.transform.parent = null;
					StartCoroutine (ShowStory());
					story = true;
				}

			}

		}

		private IEnumerator ShowStory(){
			yield return new WaitForSeconds(1f);
			storyObjects.SetActive (true);
			foreach (GameObject item in titleUI) {
				item.SetActive (false);
			}

			foreach (GameObject item in storyUI) {
				item.SetActive (true);
			}
		}

		private IEnumerator ShowControls(){
			yield return new WaitForSeconds(1f);
			storyObjects.SetActive (false);
			foreach (GameObject item in storyUI) {
				item.SetActive (false);
			}

			foreach (GameObject item in controlsUI) {
				item.SetActive (true);
			}
		}
	}

}