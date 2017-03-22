using UnityEngine;
using EliCDavis.Player;

namespace EliCDavis.Enemy {

	/// <summary>
	/// Potiential Field Code ripped frome drone behavior from Project Lydia!
	/// </summary>
	public class HornetBehavior : MonoBehaviour {

		[SerializeField]
		private Transform target;

		[SerializeField]
		private float speed = 35f;

		[SerializeField]
		private GameObject explosionEffect;

		[SerializeField]
		private float effectDuration;

		[SerializeField]
		private float damageToDeal = .15f;

		private float targetAttractiveForce = 5;

		public void SetTarget (GameObject target){
			this.target = target.transform;
		}

		// Use this for initialization
		void Start () {
		}
		
		float GetDistance(Vector3 dir) {
			Debug.DrawRay (transform.position, dir*3);
			RaycastHit hit;
			if (Physics.Raycast (transform.position, dir, out hit, 100)) {
				if(hit.collider.gameObject != target.gameObject){
					return hit.collider.gameObject.GetInstanceID() == target.GetInstanceID() ? -1 : hit.distance;
				} else {
					return -1;
				}
			}
			return -1;
		}

		void Update () {

			if (target == null) {
				return;
			}

			Vector3 repulsion = Vector3.zero;

			for (int angle = -80; angle <= 80; angle+=10) {

				// x axis
				Vector3 dirx = Quaternion.AngleAxis (angle, Vector3.up) * transform.forward;
				float distx = GetDistance (dirx);
				if (distx  > 0 && distx < 50) {
					repulsion += (dirx * (1f/distx*2))*2;
				}

				// y axis
				Vector3 diry = Quaternion.AngleAxis (angle, Vector3.right) * transform.forward;
				float disty = GetDistance (diry);
				if (disty  > 0 && disty < 50) {
					repulsion += (diry * (1f/disty*2))*2;
				}

			}

			Vector3 movementDirection = Vector3.Normalize (( (target.transform.position - this.transform.position).normalized * targetAttractiveForce) - repulsion);

			// Smoothly rotate towards the target point.
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movementDirection), speed * Time.deltaTime);

			// Move forwards
			transform.Translate (Vector3.forward* Time.deltaTime * speed);

		}

		void OnCollisionEnter (Collision collision)
		{

			PlayerBehavior player = collision.gameObject.GetComponent<PlayerBehavior> ();

			if (player != null) {
				player.Damage (damageToDeal);
			}

			Die ();
		}

		private void Die() {
			Destroy (Instantiate (explosionEffect, transform.position, transform.rotation), effectDuration);
			Destroy (gameObject);
		}

	}

}