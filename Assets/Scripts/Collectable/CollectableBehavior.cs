using UnityEngine;

namespace EliCDavis.Collectable {

	public class CollectableBehavior : MonoBehaviour {

		[SerializeField]
		private CollectableType typeOfCollectable = CollectableType.Gold;

		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		public CollectableType GetCollectableType() {
			return this.typeOfCollectable;
		}

	}

}