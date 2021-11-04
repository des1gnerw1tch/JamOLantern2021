using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
	[SerializeField] private int health;
	[SerializeField] private SpriteRenderer sprite;
	[SerializeField] private Slider healthSlider;

	void SartHealth () {
		this.health = 100;
		this.UpdateSlider ();
	}

	// Returns true if still alive, false if not
	public bool Damage (int healthPoints) {
		this.health -= healthPoints;
		StartCoroutine ("Blink");
		this.UpdateSlider ();
		return health <= 0;
	}

	// Adds Health by points, no overheal
	public void Heal (int healthPoints) {
		if (this.health < 100) {
			this.health = Math.Min (100, this.health + healthPoints);
		}
		this.UpdateSlider ();
	}

	// Adds Health by points, with overheal to 120
	public void HealOver (int healthPoints) {
		this.health = Math.Min (120, this.health + healthPoints);
		this.UpdateSlider ();
	}

	IEnumerator Blink () {
		this.sprite.enabled = false;
		yield return new WaitForSeconds (.1f);
		this.sprite.enabled = true;
	}

	// updates the slider to current value of health 
	void UpdateSlider () {
		this.healthSlider.value = ((float)(health)) / 100f;
	}
}