using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyProjectile : MonoBehaviour {
	[SerializeField] protected int damage;
	[SerializeField] protected bool pierce;
	const float LIFETIME = 10f; // will despawn after 12 seconds

	private void Start () {
		StartCoroutine ("Despawn");
	}
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

	IEnumerator Despawn () {
		yield return new WaitForSeconds (LIFETIME);
		Destroy (this.gameObject);
	}

}
