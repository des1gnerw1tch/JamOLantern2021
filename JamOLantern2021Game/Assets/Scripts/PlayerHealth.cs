using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {
	[SerializeField] private int health;
	[SerializeField] private SpriteRenderer sprite;
	[HideInInspector] public Slider healthSlider;
	[SerializeField] private GameObject GameOverText;
	public bool isBeserk; // is player in beserk mode? if so they are invincible

	// called on first frame
	private void Start () {
		this.GameOverText.SetActive (false);
		this.isBeserk = false;
		this.UpdateSlider ();
	}

	// Returns true if still alive, false if not
	public bool Damage (int healthPoints) {
		if (!this.isBeserk) {
			int healthInitial = health;
			this.health -= healthPoints;
			Debug.Log (this.health + "" + healthInitial);

			if (this.health < 20 && healthInitial >= 20) {
				FindObjectOfType<AudioManager> ().Play ("HealthWarning");
			}
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
		yield return new WaitForSeconds (7f);
		this.isBeserk = false;
		this.sprite.color = Color.white;
	}

	// When player dies
	public void Die () {
		this.GameOverText.SetActive (true);
		Time.timeScale = .1f;
		StartCoroutine ("GoToPlayerSelect");
	}

	IEnumerator GoToPlayerSelect () {
		yield return new WaitForSeconds (.3f);
		KeepOnSceneChange [] objs = FindObjectsOfType<KeepOnSceneChange> ();

		foreach (KeepOnSceneChange obj in objs) {
			Destroy (obj.gameObject);
		}
		Time.timeScale = 1f;
		SceneManager.LoadScene ("PlayerSelect");
	}

	/*private void Update () {
		if (Input.GetKeyDown ("space")) {
			Time.timeScale = 100f;
			this.health = 10000;
		}
		if (Input.GetKeyDown ("o")) {
			Time.timeScale = 1f;
			this.health = 100;
		}
	}*/
}