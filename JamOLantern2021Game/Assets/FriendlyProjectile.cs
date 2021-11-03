using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyProjectile : MonoBehaviour {
	[SerializeField] private int damage;

	private void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.CompareTag ("Enemy")) {
			if (other.gameObject.GetComponent<EnemyHealth> ().Damage (this.damage)) {
				Destroy (other.gameObject);
				FindObjectOfType<AudioManager> ().Play ("enemyDeath");
			} else {
				FindObjectOfType<AudioManager> ().Play ("damageToEnemy");
			}

			Destroy (this.gameObject);

		}
	}
}
