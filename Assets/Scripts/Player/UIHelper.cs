using UnityEngine;
using UnityEngine.SceneManagement;

namespace EliCDavis.Player
{
	
	public class UIHelper : MonoBehaviour {

		public void RestartLevel() {
			SceneManager.LoadScene (1);
		}

		public void ToMainMenu() {
			SceneManager.LoadScene (0);
		}

	}

}