
namespace EliCDavis.Player {

	public class PlayerManager {

		private static PlayerManager instance = null;
		public static PlayerManager GetInstance(){
			if (instance == null) {
				instance = new PlayerManager();
			}
			return instance;
		}

		private PlayerBehavior currentPlayer;

		private PlayerManager(){
			currentPlayer = null;
		}

		public PlayerBehavior GetPlayer() {
			return currentPlayer;
		}

		public void SetPlayer(PlayerBehavior player){
			currentPlayer = player;
		}

	}

}