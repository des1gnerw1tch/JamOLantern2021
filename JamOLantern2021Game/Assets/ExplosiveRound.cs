using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A friendly projectile that is explosive
public class ExplosiveRound : FriendlyProjectile {
	[SerializeField] private GameObject explosion;
	public override void OnTriggerEnter2D (Collider2D other) {
		//base.OnTriggerEnter2D (other);
		if (other.gameObject.CompareTag ("Enemy")) {
			if (other.gameObject.GetComponent<EnemyHealth> ().Damage (this.damage)) { // if enemy dies
				other.gameObject.GetComponent<Enemy> ().DropCard ();
				Destroy (other.gameObject);
				FindObjectOfType<AudioManager> ().Play ("enemyDeath");

			} else {
				FindObjectOfType<AudioManager> ().Play ("damageToEnemy");
			}

			Instantiate (this.explosion, new Vector3 (this.transform.position.x, this.transform.position.y,
				this.transform.position.z), Quaternion.identity);

			if (!pierce)
				Destroy (this.gameObject);

		}
	}
}
