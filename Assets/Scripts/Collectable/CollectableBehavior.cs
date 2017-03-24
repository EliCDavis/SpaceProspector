using UnityEngine;

namespace EliCDavis.Collectable {

	public class CollectableBehavior : MonoBehaviour {

		[SerializeField]
		private CollectableType typeOfCollectable = CollectableType.Gold;

		private Transform moveTowards;

		// Use this for initialization
		void Start () {
			moveTowards = EliCDavis.Player.PlayerManager.GetInstance ().GetPlayer ().transform;
		}
		
		// Update is called once per frame
		void Update () {
			if (transform == null) {
				Destroy (this);
				return;
			}
			transform.Translate ((moveTowards.position - transform.position).normalized*10*Time.deltaTime);
		}

		public CollectableType GetCollectableType() {
			return this.typeOfCollectable;
		}

	}

}