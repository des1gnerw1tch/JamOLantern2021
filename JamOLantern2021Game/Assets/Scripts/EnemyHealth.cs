using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyHealth : MonoBehaviour {
	[SerializeField] private int health;
	[SerializeField] private SpriteRenderer sprite;

	// Returns true if still alive, false if not
	public bool Damage (int healthPoints) {
		this.health -= healthPoints;
		StartCoroutine ("Blink");
		return health <= 0;
	}

	IEnumerator Blink () {
		this.sprite.enabled = false;
		yield return new WaitForSeconds (.1f);
		this.sprite.enabled = true;
	}

}
