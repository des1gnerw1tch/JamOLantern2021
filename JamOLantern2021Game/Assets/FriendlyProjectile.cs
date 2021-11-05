using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyProjectile : MonoBehaviour {
	[SerializeField] protected int damage;
	[SerializeField] protected bool pierce;

	public virtual void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.CompareTag ("Enemy")) {
			if (other.gameObject.GetComponent<EnemyHealth> ().Damage (this.damage)) { // if enemy dies
				other.gameObject.GetComponent<Enemy> ().DropCard ();
				Destroy (other.gameObject);
				FindObjectOfType<AudioManager> ().Play ("enemyDeath");
			} else {
				FindObjectOfType<AudioManager> ().Play ("damageToEnemy");
			}

			if (!pierce)
				Destroy (this.gameObject);

		}
	}
}
