using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EliCDavis.Player
{

	[RequireComponent (typeof(Rigidbody))]
	public class PlayerBehavior : MonoBehaviour
	{

		private float speed = 30f;

		private float rollSpeed = 100f;

		private float pitchSpeed = 75f;

		private Rigidbody rb;

		private float maxVelocityChange = 10.0f;

		private float health;

		[SerializeField]
		private Slider healthBar;

		[SerializeField]
		private ParticleSystem normalExaustEffect;

		[SerializeField]
		/// <summary>
		/// The graphics of the player used for rendering
		/// </summary>
		private GameObject graphics;

		[SerializeField]
		/// <summary>
		/// Where projectiles will spawn from the player
		/// </summary>
		private Transform bulletSpawn;

		[SerializeField]
		/// <summary>
		/// Bullet reference we'll use for firing
		/// </summary>
		private GameObject bullet;

		[SerializeField]
		/// <summary>
		/// The booster particle effect.
		/// </summary>
		private ParticleSystem boosterEffect;

		// Use this for initialization
		void Start ()
		{
			rb = gameObject.GetComponent<Rigidbody> ();
			health = 1f;
		}
		
		// Update is called once per frame
		void Update ()
		{

			if(Input.GetKeyDown(KeyCode.Space)){
				Fire ();
			}
				
			// Calculate how fast we should be moving
			Vector3 targetVelocity = transform.forward * speed * CurrentBoostSpeed() * CurrentStallSpeed();

			// Apply a force that attempts to reach our target velocity
			Vector3 velocity = rb.velocity;
			Vector3 velocityChange = (targetVelocity - velocity);
			velocityChange.x = Mathf.Clamp (velocityChange.x, -maxVelocityChange, maxVelocityChange);
			velocityChange.z = Mathf.Clamp (velocityChange.z, -maxVelocityChange, maxVelocityChange);
			rb.AddForce (velocityChange, ForceMode.VelocityChange);

			// Rotate appropriatly
			transform.Rotate (
				Input.GetAxis ("Vertical") * Time.deltaTime * pitchSpeed,
				0,
				-Input.GetAxis ("Horizontal") * Time.deltaTime * rollSpeed
			);

			BoosterEffectUpdate ();

			NormalExaustUpdate ();

		}

		void NormalExaustUpdate() {
			if (Input.GetKeyDown(KeyCode.LeftControl)) {
				normalExaustEffect.Stop ();
			}

			if (Input.GetKeyUp(KeyCode.LeftControl)) {
				normalExaustEffect.Play ();
			}
		}

		void BoosterEffectUpdate(){
			if(Input.GetKeyDown (KeyCode.LeftShift)){
				boosterEffect.Play();
			}

			if(Input.GetKeyUp (KeyCode.LeftShift)){
				boosterEffect.Stop();
			}
		}

		void Fire () {
			GameObject bulletInstance = Instantiate (bullet, bulletSpawn.position, bulletSpawn.rotation);
			Rigidbody brb = bulletInstance.GetComponent<Rigidbody> ();
			brb.velocity = rb.velocity;
			brb.AddForce (bulletInstance.transform.forward*100, ForceMode.Impulse);
		}


		private float CurrentBoostSpeed() {
			return Input.GetKey (KeyCode.LeftShift)? 2f : 1f;
		}
	
		private float CurrentStallSpeed() {
			return Input.GetKey (KeyCode.LeftControl)? 0.5f : 1f;
		}

		void OnCollisionEnter (Collision collision)
		{
			rb.AddForce ((transform.forward - collision.collider.transform.position).normalized * -100, ForceMode.Impulse);
		}


		public void Damage(float amountOfDamage){
			StartCoroutine (AnimateTakingDamage());

			health = Mathf.Max (0, health - amountOfDamage);
			healthBar.value = health;
		}

		private IEnumerator AnimateTakingDamage(){
			graphics.GetComponent<MeshRenderer> ().material.color = Color.red;
			yield return new WaitForSeconds(.2f);
			graphics.GetComponent<MeshRenderer> ().material.color = Color.white;
		}

	}

}