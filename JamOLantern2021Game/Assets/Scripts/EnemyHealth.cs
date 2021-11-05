using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyHealth : MonoBehaviour {
	[SerializeField] private int health;
	[SerializeField] private SpriteRenderer sprite;
	private GunGirlClass gunGirlInScene; // if there is a gungirl in scene

	private void Start () {
		try { // try to find a gun girl in teh scene, whether to take beserk damage or not
			gunGirlInScene = FindObjectOfType<GunGirlClass> ();
		}
		catch (Exception ex) {

		}
	}
	// Returns true if still alive, false if not
	public bool Damage (int healthPoints) {

		if (gunGirlInScene != null && gunGirlInScene.gameObject.GetComponent<PlayerHealth> ().isBeserk) {
			this.health -= 2 * healthPoints;
		} else {
			this.health -= healthPoints;
		}

		StartCoroutine ("Blink");
		return health <= 0;
	}

	IEnumerator Blink () {
		this.sprite.enabled = false;
		yield return new WaitForSeconds (.05f);
		this.sprite.enabled = true;
	}

}
