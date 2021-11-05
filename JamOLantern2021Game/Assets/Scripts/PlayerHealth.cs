using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
	[SerializeField] private int health;
	[SerializeField] private SpriteRenderer sprite;
	[HideInInspector] public Slider healthSlider;
	public bool isBeserk; // is player in beserk mode? if so they are invincible

	// called on first frame
	private void Start () {
		this.isBeserk = false;
		this.UpdateSlider ();
	}

	// Returns true if still alive, false if not
	public bool Damage (int healthPoints) {
		if (!this.isBeserk) {
			this.health -= healthPoints;
		}

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

	// starts beserker mode
	public void StartBeserk () {
		if (!this.isBeserk) {
			this.isBeserk = true;
			StartCoroutine ("TurnOffBeserk");
			this.sprite.color = Color.magenta;
		}
	}

	IEnumerator TurnOffBeserk () {
		yield return new WaitForSeconds (15f);
		this.isBeserk = false;
		this.sprite.color = Color.white;
	}
}